Public Class frmServerConfiguration
    Private Sub btnConfigure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfigure.Click
        Try
            'If mskServerIP.Text = "___.___.___.___" Then
            '    MsgBox("Invalid IP Address !", MsgBoxStyle.Critical, gsProjectName)
            '    mskServerIP.Focus()
            '    Exit Sub
            'End If
            If txtServerIP.Text = "___.___.___.___" Then
                MsgBox("Invalid IP Address !", MsgBoxStyle.Critical, gsProjectName)
                txtServerIP.Focus()
                Exit Sub
            End If

            If txtPort.Text = "" Then
                MsgBox("Invalid Port !", MsgBoxStyle.Critical, gsProjectName)
                txtPort.Focus()
                Exit Sub
            End If

            If txtUserId.Text = "" Then
                MsgBox("Invalid User ID !", MsgBoxStyle.Critical, gsProjectName)
                txtUserId.Focus()
                Exit Sub
            End If

            If txtPassword.Text = "" Then
                MsgBox("Invalid Password !", MsgBoxStyle.Critical, gsProjectName)
                txtPassword.Focus()
                Exit Sub
            End If

            If txtDatabase.Text = "" Then
                MsgBox("Invalid Database !", MsgBoxStyle.Critical, gsProjectName)
                txtDatabase.Focus()
                Exit Sub
            End If

            If txtReportPath.Text.Trim = "" Then
                MsgBox("Invalid Ascii Path !", MsgBoxStyle.Information, gsProjectName)
                txtReportPath.Focus()
                Exit Sub
            End If

            If FileIO.FileSystem.DirectoryExists(txtReportPath.Text) = False Then
                MsgBox("Invalid Ascii Path !", MsgBoxStyle.Information, gsProjectName)
                txtReportPath.Focus()
                Exit Sub
            End If

            FileOpen(1, Application.StartupPath & "\appconfig.ini", OpenMode.Output)

            PrintLine(1, EncryptTripleDES(Trim(txtServerIP.Text)))
            PrintLine(1, EncryptTripleDES(Trim(txtPort.Text)))
            PrintLine(1, EncryptTripleDES(Trim(txtUserId.Text)))
            PrintLine(1, EncryptTripleDES(Trim(txtPassword.Text)))
            PrintLine(1, EncryptTripleDES(Trim(txtDatabase.Text)))
            PrintLine(1, EncryptTripleDES(Trim(txtReportPath.Text)))

            FileClose(1)

            'SaveSetting("FICCCOLLRECON", "GNSA", "ip", Trim(mskServerIP.Text))
            'SaveSetting("FICCCOLLRECON", "GNSA", "uid", txtUserId.Text)
            'SaveSetting("FICCCOLLRECON", "GNSA", "pwd", txtPassword.Text)
            'SaveSetting("FICCCOLLRECON", "GNSA", "path", txtAsciiPath.Text)

            MsgBox("Close And Open the Package", MsgBoxStyle.Information, gsProjectName)
            End
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmServerConfiguration_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'mskServerIP.Text = IPAddresses("")
        txtServerIP.Text = IPAddresses("")
        txtPort.Text = "3306"
        txtUserId.Text = "root"
        txtPassword.Text = ""
        txtReportPath.Text = gsAsciiPath
    End Sub

    Private Sub mskServerIP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        SendKeys.Send("{HOME}+{END}")
    End Sub

    Private Sub txtPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus, txtReportPath.GotFocus
        SendKeys.Send("{HOME}+{END}")
    End Sub

    Private Sub txtUserId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserId.GotFocus
        SendKeys.Send("{HOME}+{END}")
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If MsgBox("Are you sure to Close ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then
            End
        End If
    End Sub

    Private Sub btnClearConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearConfig.Click
        Try
            'SaveSetting("FICCCOLLRECON", "GNSA", "ip", "")
            'SaveSetting("FICCCOLLRECON", "GNSA", "uid", "")
            'SaveSetting("FICCCOLLRECON", "GNSA", "pwd", "")
            'SaveSetting("FICCCOLLRECON", "GNSA", "path", "")

            'mskServerIP.Text = "___.___.___.___"
            txtServerIP.Text = ""

            Call frmCtrClear(Me)

            MsgBox("Successfully Configuration Cleared", MsgBoxStyle.Information, gsProjectName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmServerConfiguration_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmServerConfiguration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtServerIP.Focus()
        'mskServerIP.Focus()
        SendKeys.Send("{HOME}+{END}")
    End Sub
End Class