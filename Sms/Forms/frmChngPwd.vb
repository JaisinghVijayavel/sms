Imports MySql.Data.MySqlClient

Public Class frmChngPwd
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If txtOldPwd.Enabled = False Then
            End
        Else
            MyBase.Close()
        End If
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
        Dim lsPwd As String
        Dim lsNewPwd As String
        Dim lsMsg As String
        Dim lnResult As Integer

        lsPwd = EncryptTripleDES(txtOldPwd.Text)
        lsPwd = lsPwd.Replace("'", "''")
        lsPwd = lsPwd.Replace("\", "\\")

        lsNewPwd = EncryptTripleDES(txtNewPwd.Text)
        lsNewPwd = lsNewPwd.Replace("'", "''")
        lsNewPwd = lsNewPwd.Replace("\", "\\")

        Using cmd As New MySqlCommand("pr_set_password", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?in_user_gid", gnLoginUserId)
            cmd.Parameters("?in_user_gid").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?in_old_pwd", lsPwd)
            cmd.Parameters("?in_old_pwd").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?in_new_pwd", lsNewPwd)
            cmd.Parameters("?in_new_pwd").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?in_max_pwd_sno", gnMaxPwdSno)
            cmd.Parameters("?in_max_pwd_sno").Direction = ParameterDirection.Input

            'Out put Para
            cmd.Parameters.Add("?out_msg", MySqlDbType.VarChar)
            cmd.Parameters("?out_msg").Direction = ParameterDirection.Output
            cmd.Parameters.Add("?out_result", MySqlDbType.Int32)
            cmd.Parameters("?out_result").Direction = ParameterDirection.Output

            cmd.ExecuteNonQuery()

            lnResult = Val(cmd.Parameters("?out_result").Value.ToString())
            lsMsg = cmd.Parameters("?out_msg").Value.ToString()

            If (lnResult = 1) Then
                MessageBox.Show(lsMsg, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show(lsMsg, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub frmChngPwd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")
    End Sub

    Private Sub frmChngPwd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        txtUserCode.Text = gsLoginUserCode
    End Sub
End Class