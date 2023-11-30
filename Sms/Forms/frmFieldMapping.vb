Imports MySql.Data.MySqlClient

Public Class frmFieldMapping
    'Dim mobjDtFld As New DataTable
    Dim mobjDgvCol As DataGridViewColumn
    Dim mobjDgvButtonCol As DataGridViewButtonColumn
    Dim mobjRow As DataRow

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub frmFieldMapping_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lsSql As String

        lsSql = ""
        lsSql &= " select field_type from sms_mst_tfieldtype "
        lsSql &= " where active_status = 'Y' and delete_flag = 'N' order by field_type "

        Call gpBindCombo(lsSql, "field_type", "field_type", cboFldType, gOdbcConn)

        Call LoadField()
        Call ClearFieldMapping()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub ClearFieldMapping()
        txtSNo.Text = ""
        txtFldName.Text = ""
        txtDisplayDesc.Text = ""
        txtDisplayOrder.Text = ""
        txtTemplateCode.Text = ""

        cboFldType.Text = ""
        cboFldType.SelectedIndex = -1

        optDispYes.Checked = True
        optFldActive.Checked = True
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim lsActiveStatus As String
        Dim lsDisplayFlag As String

        If Val(txtId.Text) = 0 Then
            MsgBox("Please select the select !", MsgBoxStyle.Information, gsProjectName)
            Exit Sub
        End If

        If optDispYes.Checked Then
            lsDisplayFlag = "Y"
        Else
            lsDisplayFlag = "N"
        End If

        If optFldActive.Checked Then
            lsActiveStatus = "Y"
        Else
            lsActiveStatus = "N"
        End If

        If MsgBox("Are you sure to update ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then
            Dim lnResult As Integer
            Dim lsTxt As String

            ' delete upload
            Using cmd As New MySqlCommand("pr_upd_field", gOdbcConn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("?in_field_gid", Val(txtId.Text))
                cmd.Parameters.AddWithValue("?in_field_display_desc", txtDisplayDesc.Text.Trim)
                cmd.Parameters.AddWithValue("?in_field_type", cboFldType.Text.Trim)
                cmd.Parameters.AddWithValue("?in_field_template_code", txtTemplateCode.Text.Trim)
                cmd.Parameters.AddWithValue("?in_field_display_flag", lsDisplayFlag)
                cmd.Parameters.AddWithValue("?in_field_display_order", Val(txtDisplayOrder.Text))
                cmd.Parameters.AddWithValue("?in_active_status", lsActiveStatus)
                cmd.Parameters.AddWithValue("?in_action_by", gsLoginUserCode)

                'Out put Para
                cmd.Parameters.Add("?out_result", MySqlDbType.Int32)
                cmd.Parameters("?out_result").Direction = ParameterDirection.Output
                cmd.Parameters.Add("?out_msg", MySqlDbType.VarChar)
                cmd.Parameters("?out_msg").Direction = ParameterDirection.Output

                cmd.ExecuteNonQuery()

                lnResult = Val(cmd.Parameters("?out_result").Value.ToString())

                If (lnResult = 0) Then
                    lsTxt = cmd.Parameters("?out_msg").Value.ToString()
                    MsgBox(lsTxt, MsgBoxStyle.Critical, gsProjectName)
                    Exit Sub
                End If
            End Using

            MsgBox("Record updated successfully !", MsgBoxStyle.Information, gsProjectName)

            Call LoadField()
            Call ClearFieldMapping()
        End If
    End Sub

    Private Sub dgvFldMap_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFldMap.CellContentClick
        Select Case e.ColumnIndex
            Case 0
                If MsgBox("Are you sure to select ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
                    With dgvFldMap.Rows(e.RowIndex)
                        txtSNo.Text = .Cells("sno").Value
                        txtId.Text = .Cells("field_gid").Value
                        txtFldName.Text = .Cells("Field Name").Value
                        txtDisplayDesc.Text = .Cells("Display Name").Value
                        cboFldType.Text = .Cells("Field Type").Value.ToString()
                        txtTemplateCode.Text = .Cells("Template Code").Value.ToString
                        txtDisplayOrder.Text = .Cells("Display Order").Value

                        If .Cells("Display Flag").Value = "Y" Then
                            optDispYes.Checked = True
                        Else
                            optDispNo.Checked = True
                        End If

                        If .Cells("Active Status").Value = "Y" Then
                            optFldActive.Checked = True
                        Else
                            optFldInactive.Checked = True
                        End If
                    End With
                End If
        End Select
    End Sub

    Private Sub LoadField()
        Dim lsSql As String
        Dim lobjDgvBtn As DataGridViewButtonColumn

        lsSql = "set @sno := 0"
        Call gfInsertQry(lsSql, gOdbcConn)

        lsSql = ""
        lsSql &= " select "
        lsSql &= " field_gid,"
        lsSql &= " @sno := @sno+1 as 'SNo',"
        lsSql &= " field_name as 'Field Name',"
        lsSql &= " field_display_flag as 'Display Flag',"
        lsSql &= " field_display_order as 'Display Order',"
        lsSql &= " field_display_desc as 'Display Name',"
        lsSql &= " field_type as 'Field Type',"
        lsSql &= " field_template_code as 'Template Code',"
        lsSql &= " active_status as 'Active Status' "
        lsSql &= " from sms_mst_tfield "
        lsSql &= " where field_property = 'V' and delete_flag = 'N' "
        lsSql &= " order by field_gid "

        dgvFldMap.Columns.Clear()

        Call gpPopGridView(dgvFldMap, lsSql, gOdbcConn)

        lobjDgvBtn = New DataGridViewButtonColumn
        lobjDgvBtn.Name = "Select"
        lobjDgvBtn.Text = "Select"
        lobjDgvBtn.UseColumnTextForButtonValue = True
        dgvFldMap.Columns.Insert(0, lobjDgvBtn)

        dgvFldMap.Columns("field_gid").Visible = False

        For i = 1 To dgvFldMap.Columns.Count - 1
            dgvFldMap.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvFldMap.Columns(i).ReadOnly = True
        Next

        dgvFldMap.Columns("Select").Width = 50
        dgvFldMap.Columns("SNo").Width = 50
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtId.TextChanged

    End Sub

    Private Sub txtFldName_TextChanged(sender As Object, e As EventArgs) Handles txtFldName.TextChanged

    End Sub

    Private Sub txtDisplayOrder_TextChanged(sender As Object, e As EventArgs) Handles txtDisplayOrder.TextChanged

    End Sub

    Private Sub pnlDetail_Paint(sender As Object, e As PaintEventArgs) Handles pnlDetail.Paint

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBox("Are you sure to refresh ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Call LoadField()
        End If
    End Sub
End Class