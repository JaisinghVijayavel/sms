Imports MySql.Data.MySqlClient

Public Class frmSmsTemplateMaster
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
        txtName.Focus()
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
            SearchDialog = New frmSearch(gOdbcConn, "select a.smstemplate_gid as 'Sms Template Id'," & _
            "a.smstemplate_name as 'Sms Template Name',a.sender_name as 'Sender Name',a.active_status as 'Active Flag'" & _
            "FROM sms_mst_vsmstemplate as a ", _
            "a.smstemplate_gid,a.smstemplate_name,a.sender_name,a.active_status", " 1 = 1 and a.delete_flag = 'N'")
            SearchDialog.ShowDialog()

            If gnSearchId <> 0 Then
                Call ListAll("select * from sms_mst_tsmstemplate " _
                    & "where smstemplate_gid = " & gnSearchId & " " _
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
                    txtId.Text = lobjDataReader.Item("smstemplate_gid").ToString
                    txtName.Text = lobjDataReader.Item("smstemplate_name").ToString
                    cboSender.SelectedValue = lobjDataReader.Item("sender_gid").ToString
                    txtSmsTemplate.Text = lobjDataReader.Item("sms_template").ToString

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
                    Using cmd As New MySqlCommand("pr_del_smstemplate", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?in_smstemplate_gid", Val(txtId.Text))
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
        Dim lsSql As String
        Dim lobjDgvBtnCol As DataGridViewButtonColumn

        lsSql = ""
        lsSql &= " select sender_gid,sender_name from sms_mst_tsender "
        lsSql &= " where active_status = 'Y' "
        lsSql &= " and delete_flag = 'N' "
        lsSql &= " order by sender_name "

        Call gpBindCombo(lsSql, "sender_name", "sender_gid", cboSender, gOdbcConn)

        lsSql = ""
        lsSql &= " select "
        lsSql &= " field_display_desc as 'Field',"
        lsSql &= " field_type as 'Field Type',"
        lsSql &= " field_template_code as 'Template Code' "
        lsSql &= " from sms_mst_tfield "
        lsSql &= " where true "
        lsSql &= " and field_property = 'V' "
        lsSql &= " and field_template_code <> '' "
        lsSql &= " and active_status ='Y' "
        lsSql &= " and delete_flag = 'N' "
        lsSql &= " order by field_gid asc"

        Call gpPopGridView(dgvField, lsSql, gOdbcConn)

        For i = 0 To dgvField.Columns.Count - 1
            dgvField.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i

        lobjDgvBtnCol = New DataGridViewButtonColumn
        lobjDgvBtnCol.Name = "Copy Template Code"
        lobjDgvBtnCol.Text = "Copy Template Code"
        lobjDgvBtnCol.UseColumnTextForButtonValue = True
        dgvField.Columns.Insert(0, lobjDgvBtnCol)

        dgvField.Columns(0).Width = 150

        Call EnableSave(False)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lnResult As Integer
        Dim lsTxt As String
        Dim lnSmsTemplateId As Long
        Dim lsSmsTemplateName As String
        Dim lsSmsTemplate As String
        Dim lnSenderId As Long
        Dim lsActiveStatus As String
        Dim cmd As MySqlCommand

        Try
            txtName.Text = txtName.Text.Trim
            txtSmsTemplate.Text = txtSmsTemplate.Text.Trim

            If txtName.Text = "" Then
                MsgBox("Sms template name cannot be blank !", MsgBoxStyle.Information, gsProjectName)
                txtName.Focus()
                Exit Sub
            End If

            If txtSmsTemplate.Text = "" Then
                MsgBox("Sms template cannot be blank !", MsgBoxStyle.Information, gsProjectName)
                txtSmsTemplate.Focus()
                Exit Sub
            End If

            If cboSender.Text = "" Or cboSender.SelectedIndex = -1 Then
                MsgBox("Please select the sender !", MsgBoxStyle.Information, gsProjectName)
                cboSender.Focus()
                Exit Sub
            End If

            lsSmsTemplateName = QuoteFilter(txtName.Text)
            lsSmsTemplate = QuoteFilter(txtSmsTemplate.Text)
            lnSmsTemplateId = Val(txtId.Text)
            lnSenderId = cboSender.SelectedValue.ToString

            Select Case True
                Case optYes.Checked
                    lsActiveStatus = "Y"
                Case optNo.Checked
                    lsActiveStatus = "N"
                Case Else
                    MsgBox("Please select active status !", MsgBoxStyle.Information, gsProjectName)
                    Exit Sub
            End Select

            If lnSmsTemplateId = 0 Then
                cmd = New MySqlCommand("pr_ins_smstemplate", gOdbcConn)
            Else
                cmd = New MySqlCommand("pr_upd_smstemplate", gOdbcConn)
            End If

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?in_smstemplate_name", lsSmsTemplateName)
            cmd.Parameters.AddWithValue("?in_sms_template", lsSmsTemplate)
            cmd.Parameters.AddWithValue("?in_sender_gid", lnSenderId)
            cmd.Parameters.AddWithValue("?in_active_status", lsActiveStatus)
            cmd.Parameters.AddWithValue("?in_action_by", gsLoginUserCode)

            If lnSmsTemplateId > 0 Then
                cmd.Parameters.AddWithValue("?in_smstemplate_gid", lnSmsTemplateId)
            Else
                cmd.Parameters.Add("?out_smstemplate_gid", MySqlDbType.Int32)
                cmd.Parameters("?out_smstemplate_gid").Direction = ParameterDirection.Output
            End If

            'Out put Para
            cmd.Parameters.Add("?out_msg", MySqlDbType.VarChar)
            cmd.Parameters("?out_msg").Direction = ParameterDirection.Output
            cmd.Parameters.Add("?out_result", MySqlDbType.Int32)
            cmd.Parameters("?out_result").Direction = ParameterDirection.Output

            cmd.CommandTimeout = 0

            cmd.ExecuteNonQuery()

            If lnSmsTemplateId = 0 Then lnSmsTemplateId = Val(cmd.Parameters("?out_smstemplate_gid").Value.ToString())

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
        txtName.Focus()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Call ClearControl()
        Call EnableSave(False)
    End Sub

    Private Sub dgvField_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvField.CellContentClick
        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
            Clipboard.SetText("<<" & dgvField.Rows(e.RowIndex).Cells("Template Code").Value.ToString & ">>")
        End If
    End Sub

    Private Sub Label4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub frmSmsTemplateMaster_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        pnlButtons.Left = (Me.Width \ 2) - (pnlButtons.Width \ 2)
        pnlSave.Left = (Me.Width \ 2) - (pnlSave.Width \ 2)
    End Sub
End Class