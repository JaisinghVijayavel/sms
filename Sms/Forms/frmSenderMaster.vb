Imports MySql.Data.MySqlClient

Public Class frmSenderMaster
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub EnableSave(ByVal Status As Boolean)
        pnlButtons.Visible = Not Status
        pnlSave.Visible = Status
        pnlMain.Enabled = Status
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call ClearControl()
        Call EnableSave(True)
        txtCode.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            If txtId.Text = "" Then
                If MsgBox("Select Record to edit", MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                    'Calling Find Button to select record
                    Call btnFind_Click(sender, e)
                    EnableSave(False)
                End If
            Else
                EnableSave(True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim SearchDialog As frmSearch

        Try
            SearchDialog = New frmSearch(gOdbcConn, "select a.sender_gid as 'Sender Id'," & _
            "a.sender_code as 'Sender Code',a.sender_name as 'Sender Name',a.active_status as 'Active Flag'" & _
            "FROM sms_mst_tsender as a ", _
            "a.sender_gid,a.sender_code,a.sender_name,a.active_status", " 1 = 1 and a.delete_flag = 'N'")
            SearchDialog.ShowDialog()

            If gnSearchId <> 0 Then
                Call ListAll("select * from sms_mst_tsender " _
                    & "where sender_gid = " & gnSearchId & " " _
                    & "and delete_flag = 'N' ", gOdbcConn)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub ListAll(ByVal SqlStr As String, ByVal odbcConn As MySqlConnection)
        Dim lobjDataReader As MySqlDataReader

        Try
            lobjDataReader = gfExecuteQry(SqlStr, gOdbcConn)

            If lobjDataReader.HasRows Then
                If lobjDataReader.Read Then
                    txtId.Text = lobjDataReader.Item("sender_gid").ToString
                    txtCode.Text = lobjDataReader.Item("sender_code").ToString
                    txtName.Text = lobjDataReader.Item("sender_name").ToString

                    Select Case lobjDataReader.Item("active_status").ToString.ToUpper
                        Case "Y"
                            optYes.Checked = True
                        Case Else
                            optNo.Checked = True
                    End Select
                End If
            End If

            lobjDataReader.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim lnResult As Long
        Dim lsTxt As String

        Try
            If txtId.Text.Trim = "" Then
                MsgBox("Select the Record", MsgBoxStyle.Information, gsProjectName)
                'Calling Find Button to select record
                Call btnFind_Click(sender, e)
            Else
                If MsgBox("Are you sure want to delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then
                    Using cmd As New MySqlCommand("pr_del_sender", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?in_sender_gid", Val(txtId.Text))
                        cmd.Parameters.AddWithValue("?in_action_by", gsLoginUserCode)

                        'Out put Para
                        cmd.Parameters.Add("?out_result", MySqlDbType.Int32)
                        cmd.Parameters("?out_result").Direction = ParameterDirection.Output
                        cmd.Parameters.Add("?out_msg", MySqlDbType.VarChar)
                        cmd.Parameters("?out_msg").Direction = ParameterDirection.Output

                        cmd.CommandTimeout = 0

                        cmd.ExecuteNonQuery()

                        lnResult = Val(cmd.Parameters("?out_result").Value.ToString())
                        lsTxt = cmd.Parameters("?out_msg").Value.ToString()

                        If lnResult = 1 Then
                            MessageBox.Show(lsTxt, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show(lsTxt, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End Using

                    Call EnableSave(False)
                    Call ClearControl()
                Else
                    btnNew.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub frmBankMater_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub frmBankMaster_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call EnableSave(False)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lnResult As Integer
        Dim lsTxt As String
        Dim lnSenderId As Long
        Dim lsSenderCode As String
        Dim lsSenderName As String
        Dim lsActiveStatus As String
        Dim cmd As MySqlCommand

        Try
            lsSenderCode = QuoteFilter(txtCode.Text)
            lsSenderName = QuoteFilter(txtName.Text)
            lnSenderId = Val(txtId.Text)

            Select Case True
                Case optYes.Checked
                    lsActiveStatus = "Y"
                Case optNo.Checked
                    lsActiveStatus = "N"
                Case Else
                    MsgBox("Please select active status !", MsgBoxStyle.Information, gsProjectName)
                    Exit Sub
            End Select

            If lnSenderId = 0 Then
                cmd = New MySqlCommand("pr_ins_sender", gOdbcConn)
            Else
                cmd = New MySqlCommand("pr_upd_sender", gOdbcConn)
            End If

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?in_sender_code", lsSenderCode)
            cmd.Parameters.AddWithValue("?in_sender_name", lsSenderName)
            cmd.Parameters.AddWithValue("?in_active_status", lsActiveStatus)
            cmd.Parameters.AddWithValue("?in_action_by", gsLoginUserCode)

            If lnSenderId > 0 Then
                cmd.Parameters.AddWithValue("?in_sender_gid", lnSenderId)
            Else
                cmd.Parameters.Add("?out_sender_gid", MySqlDbType.Int32)
                cmd.Parameters("?out_sender_gid").Direction = ParameterDirection.Output
            End If

            'Out put Para
            cmd.Parameters.Add("?out_msg", MySqlDbType.VarChar)
            cmd.Parameters("?out_msg").Direction = ParameterDirection.Output
            cmd.Parameters.Add("?out_result", MySqlDbType.Int32)
            cmd.Parameters("?out_result").Direction = ParameterDirection.Output

            cmd.CommandTimeout = 0

            cmd.ExecuteNonQuery()

            If lnSenderId = 0 Then lnSenderId = Val(cmd.Parameters("?out_sender_gid").Value.ToString())

            lnResult = Val(cmd.Parameters("?out_result").Value.ToString())
            lsTxt = cmd.Parameters("?out_msg").Value.ToString()

            If lnResult = 1 Then
                MessageBox.Show(lsTxt, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(lsTxt, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Call ClearControl()

            If MsgBox("Do you want to add another record ?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1 + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
                btnNew.PerformClick()
            Else
                Call EnableSave(False)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub ClearControl()
        Call frmCtrClear(Me)
        txtCode.Focus()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Call ClearControl()
        Call EnableSave(False)
    End Sub

    Private Sub pnlMain_Paint(sender As Object, e As PaintEventArgs) Handles pnlMain.Paint

    End Sub
End Class