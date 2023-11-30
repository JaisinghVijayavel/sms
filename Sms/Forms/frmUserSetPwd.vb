Public Class frmUserSetPwd
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        MyBase.Close()
    End Sub

    Private Function ValidatePwd(ByVal pwd As String) As Boolean
        ValidatePwd = False

        If Len(pwd) <> 8 Then
            MsgBox("Password must have eight characters !", vbInformation, gsProjectName)
            Exit Function
        End If

        Select Case False
            Case SearchChar(pwd, "A", "Z")
                MsgBox("There must be atleast one captial alphabet A-Z !", vbInformation)
                Exit Function
            Case SearchChar(pwd, "a", "z")
                MsgBox("There must be atleast one small alphabet a-z !", vbInformation)
                Exit Function
            Case SearchChar(pwd, "0", "9")
                MsgBox("There must be atleast one character 0-9 !", vbInformation)
                Exit Function
            Case SearchStr(pwd, "!,#,@,$,+,^")
                MsgBox("Password must have atleast one special character (!,#,@,$,+,^) ! ", vbInformation)
                Exit Function
        End Select

        ValidatePwd = True
    End Function

    Private Function SearchChar(ByVal SrcStr As String, ByVal SearchStartChar As String, ByVal SearchEndChar As String) As Boolean
        Dim i As Integer, l As Integer
        Dim CharAsc As Integer
        Dim StartCharAsc As Integer
        Dim EndCharAsc As Integer

        l = Len(SrcStr)
        SearchChar = False

        For i = 1 To l
            CharAsc = Asc(Mid(SrcStr, i, 1))
            StartCharAsc = Asc(SearchStartChar)
            EndCharAsc = Asc(SearchEndChar)

            If CharAsc >= StartCharAsc And CharAsc <= EndCharAsc Then
                SearchChar = True
                Exit Function
            End If
        Next i
    End Function

    Private Function SearchStr(ByVal SrcStr As String, ByVal SearchChar As String) As Boolean
        Dim i As Integer, n As Integer
        Dim lsChar As String

        n = SrcStr.Length
        SearchStr = False

        For i = 1 To n
            lsChar = Mid(SrcStr, i, 1)

            If SearchChar.Contains(lsChar) = True Then
                SearchStr = True
                Exit Function
            End If
        Next i
    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim lnUserId As Integer
        Dim lsUserCode As String
        Dim lsNewPwd As String
        Dim lnPwdSno As Integer
        Dim lsPwdExpDate As String
        Dim lsSql As String
        Dim lnResult As Integer

        Dim ds As New DataSet

        lsUserCode = QuoteFilter(txtUserCode.Text)

        lsNewPwd = EncryptTripleDES(txtNewPwd.Text)
        lsNewPwd = lsNewPwd.Replace("'", "''")
        lsNewPwd = lsNewPwd.Replace("\", "\\")

        lsSql = ""
        lsSql &= " select user_gid,pwd_sno,user_status from soft_mst_tuser "
        lsSql &= " where user_code = '" & lsUserCode & "' "
        lsSql &= " and delete_flag = 'N' "

        gpDataSet(lsSql, "user", gOdbcConn, ds)

        If ds.Tables("user").Rows.Count = 1 Then
            gsLoginUserCode = txtUserCode.Text
            lnUserId = ds.Tables("user").Rows(0).Item("user_gid")
            lnPwdSno = ds.Tables("user").Rows(0).Item("pwd_sno")

            If ValidatePwd(txtNewPwd.Text) = True Then
                If txtNewPwd.Text = txtRetypePwd.Text Then
                    Select Case ds.Tables("user").Rows(0).Item("user_status")
                        Case "N"
                            MsgBox("Password not changed ! Id was deactivated !", MsgBoxStyle.Critical, gsProjectName)
                            Exit Sub
                        Case "D"
                            MsgBox("Password not changed ! Id was blocked !", MsgBoxStyle.Critical, gsProjectName)
                            Exit Sub
                    End Select

                    ' Check With Password History Table
                    lsSql = ""
                    lsSql &= " select password_gid from soft_mst_tpassword "
                    lsSql &= " where user_gid = '" & lnUserId & "' "
                    lsSql &= " and pwd = '" & lsNewPwd & "' "
                    lsSql &= " and delete_flag = 'N' "

                    gpDataSet(lsSql, "pwd", gOdbcConn, ds)

                    If ds.Tables("pwd").Rows.Count > 0 Then
                        MsgBox("Your password not changed ! " _
                              & "New password matched with previous " & gnMaxPwdSno & " passwords !" _
                              , MsgBoxStyle.Critical, gsProjectName)
                        Exit Sub
                    End If

                    If lnPwdSno = gnMaxPwdSno Then
                        lnPwdSno = 1
                    Else
                        lnPwdSno += 1
                    End If

                    ' Check new password serial no in password history table
                    lsSql = ""
                    lsSql &= " select password_gid from soft_mst_tpassword "
                    lsSql &= " where user_gid = '" & lnUserId & "' "
                    lsSql &= " and pwd_sno = '" & lnPwdSno & "' "
                    lsSql &= " and delete_flag = 'N' "

                    gpDataSet(lsSql, "sno", gOdbcConn, ds)

                    If ds.Tables("sno").Rows.Count > 0 Then
                        lsSql = ""
                        lsSql &= " update soft_mst_tpassword set "
                        lsSql &= " pwd = '" & lsNewPwd & "',"
                        lsSql &= " entry_date = sysdate() "
                        lsSql &= " where password_gid = '" & ds.Tables("sno").Rows(0).Item("password_gid") & "' "
                        lsSql &= " and delete_flag = 'N' "

                        lnResult = gfInsertQry(lsSql, gOdbcConn)
                    Else
                        lsSql = ""
                        lsSql &= " insert into soft_mst_tpassword (user_gid,entry_date,pwd,pwd_sno) values ("
                        lsSql &= " '" & lnUserId & "',"
                        lsSql &= " sysdate(),"
                        lsSql &= " '" & lsNewPwd & "',"
                        lsSql &= " '" & lnPwdSno & "')"

                        lnResult = gfInsertQry(lsSql, gOdbcConn)
                    End If

                    ds.Tables("sno").Rows.Clear()

                    lsPwdExpDate = Format(DateAdd(DateInterval.Month, 1, Now), "yyyy-MM-dd")

                    ' Update New Password
                    lsSql = ""
                    lsSql &= " update soft_mst_tuser set "
                    lsSql &= " pwd = '" & lsNewPwd & "',"
                    lsSql &= " pwd_sno = '" & lnPwdSno & "',"
                    lsSql &= " pwd_exp_date = '" & lsPwdExpDate & "' "
                    lsSql &= " where user_gid = '" & lnUserId & "' "
                    lsSql &= " and delete_flag = 'N' "

                    lnResult = gfInsertQry(lsSql, gOdbcConn)

                    MsgBox("Password changed successfully !", MsgBoxStyle.Information, gsProjectName)

                    Me.Close()
                Else
                    MsgBox("Password mismatch !", MsgBoxStyle.Critical, gsProjectName)
                    txtRetypePwd.Focus()
                End If
            End If
        Else
            MsgBox("Invalid user !", MsgBoxStyle.Critical, gsProjectName)
            txtUserCode.Focus()
        End If

        ds.Tables("user").Rows.Clear()
    End Sub

    Private Sub frmChngPwd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")
    End Sub

    Private Sub frmChngPwd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUserCode.Text = gsLoginUserCode
        KeyPreview = True
    End Sub
End Class