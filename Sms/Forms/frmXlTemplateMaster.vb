Imports MySql.Data.MySqlClient

Public Class frmXlTemplateMaster
    'Dim mobjDtFld As New DataTable
    Dim mobjDgvCol As DataGridViewColumn
    Dim mobjDgvButtonCol As DataGridViewButtonColumn
    Dim mobjRow As DataRow

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub EnableSave(ByVal Status As Boolean)
        pnlButtons.Visible = Not Status
        pnlSave.Visible = Status
        pnlMain.Enabled = Status
        pnlDetail.Enabled = Status
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

                Call ClearFieldMapping()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim SearchDialog As frmSearch

        Try
            SearchDialog = New frmSearch(gOdbcConn, "select a.xltemplate_gid as 'XL Template Id'," & _
            "a.xltemplate_name as 'XL Template Name',a.active_status as 'Active Flag'" & _
            "FROM sms_mst_txltemplate as a ", _
            "a.xltemplate_gid,a.xltemplate_name,a.active_status", " 1 = 1 and a.delete_flag = 'N'")
            SearchDialog.ShowDialog()

            If gnSearchId <> 0 Then
                Call ListAll("select * from sms_mst_txltemplate " _
                    & "where xltemplate_gid = " & gnSearchId & " " _
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

            txtId.Text = ""

            If lobjDataReader.HasRows Then
                If lobjDataReader.Read Then
                    txtId.Text = lobjDataReader.Item("xltemplate_gid").ToString
                    txtName.Text = lobjDataReader.Item("xltemplate_name").ToString

                    Select Case lobjDataReader.Item("field_property").ToString.ToUpper
                        Case "S"
                            optSms.Checked = True
                        Case "V"
                            optVariable.Checked = True
                        Case "C"
                    End Select

                    Select Case lobjDataReader.Item("active_status").ToString.ToUpper
                        Case "Y"
                            optTemplateActive.Checked = True
                        Case Else
                            optTemplateInactive.Checked = True
                    End Select
                End If
            End If

            lobjDataReader.Close()

            Call ListXlTemplateField(Val(txtId.Text))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub ListXlTemplateField(xltemplate_gid As Integer)
        Dim cmd As MySqlCommand
        Dim ds As New DataSet
        Dim i As Integer

        cmd = New MySqlCommand("pr_get_xltemplatefield", gOdbcConn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("?in_xltemplate_gid", Val(txtId.Text))

        cmd.CommandTimeout = 0

        cmd.ExecuteNonQuery()

        Call gpDataSet(cmd, "fld", ds)

        dgvFldMap.Rows.Clear()

        For i = 0 To ds.Tables("fld").Rows.Count - 1
            dgvFldMap.Rows.Add()

            With dgvFldMap.Rows(i)
                .Cells("Select").Value = "Select"
                .Cells("sno").Value = i + 1
                .Cells("xlcolumn_name").Value = ds.Tables("fld").Rows(i).Item("xlcolumn_name").ToString
                .Cells("field_name").Value = ds.Tables("fld").Rows(i).Item("field_name").ToString
                .Cells("field_display_desc").Value = ds.Tables("fld").Rows(i).Item("field_display_desc").ToString
                .Cells("field_format").Value = ds.Tables("fld").Rows(i).Item("field_format").ToString
                .Cells("field_length").Value = ds.Tables("fld").Rows(i).Item("field_length").ToString
                .Cells("field_default_value").Value = ds.Tables("fld").Rows(i).Item("field_default_value").ToString
                .Cells("mandatory_flag").Value = ds.Tables("fld").Rows(i).Item("mandatory_flag").ToString
                .Cells("active_status").Value = ds.Tables("fld").Rows(i).Item("active_status").ToString
            End With
        Next i

        ds.Tables("fld").Rows.Clear()
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
                    Using cmd As New MySqlCommand("pr_del_xltemplate", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?in_xltemplate_gid", Val(txtId.Text))
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

        lsSql = ""
        lsSql &= " select field_name,field_display_desc from sms_mst_tfield "
        lsSql &= " where 1 = 2 "

        Call gpBindCombo(lsSql, "field_display_desc", "field_name", cboFldName, gOdbcConn)

        With dgvFldMap
            mobjDgvButtonCol = New DataGridViewButtonColumn
            mobjDgvButtonCol.Name = "Select"
            mobjDgvButtonCol.Text = "Select"
            mobjDgvButtonCol.UseColumnTextForButtonValue = True
            .Columns.Add(mobjDgvButtonCol)

            mobjDgvCol = New DataGridViewColumn()
            mobjDgvCol.HeaderText = "SNo"
            mobjDgvCol.Name = "sno"
            mobjDgvCol.CellTemplate = New DataGridViewTextBoxCell()
            .Columns.Add(mobjDgvCol)

            mobjDgvCol = New DataGridViewColumn()
            mobjDgvCol.HeaderText = "XL Column Name"
            mobjDgvCol.Name = "xlcolumn_name"
            mobjDgvCol.CellTemplate = New DataGridViewTextBoxCell()
            .Columns.Add(mobjDgvCol)

            mobjDgvCol = New DataGridViewColumn()
            mobjDgvCol.HeaderText = "field_name"
            mobjDgvCol.Name = "field_name"
            mobjDgvCol.CellTemplate = New DataGridViewTextBoxCell()
            mobjDgvCol.Visible = False
            .Columns.Add(mobjDgvCol)

            mobjDgvCol = New DataGridViewColumn()
            mobjDgvCol.HeaderText = "Field Name"
            mobjDgvCol.Name = "field_display_desc"
            mobjDgvCol.CellTemplate = New DataGridViewTextBoxCell()
            .Columns.Add(mobjDgvCol)

            mobjDgvCol = New DataGridViewColumn()
            mobjDgvCol.HeaderText = "Field Format"
            mobjDgvCol.Name = "field_format"
            mobjDgvCol.CellTemplate = New DataGridViewTextBoxCell()
            .Columns.Add(mobjDgvCol)

            mobjDgvCol = New DataGridViewColumn()
            mobjDgvCol.HeaderText = "Field Length"
            mobjDgvCol.Name = "field_length"
            mobjDgvCol.CellTemplate = New DataGridViewTextBoxCell()
            .Columns.Add(mobjDgvCol)

            mobjDgvCol = New DataGridViewColumn()
            mobjDgvCol.HeaderText = "Default Value"
            mobjDgvCol.Name = "field_default_value"
            mobjDgvCol.CellTemplate = New DataGridViewTextBoxCell()
            .Columns.Add(mobjDgvCol)

            mobjDgvCol = New DataGridViewColumn()
            mobjDgvCol.HeaderText = "Mandatory Flag"
            mobjDgvCol.Name = "mandatory_flag"
            mobjDgvCol.CellTemplate = New DataGridViewTextBoxCell()
            .Columns.Add(mobjDgvCol)

            mobjDgvCol = New DataGridViewColumn()
            mobjDgvCol.HeaderText = "Active Status"
            mobjDgvCol.Name = "active_status"
            mobjDgvCol.CellTemplate = New DataGridViewTextBoxCell()
            .Columns.Add(mobjDgvCol)
        End With

        Call EnableSave(False)
        Call ClearControl()

        optVariable.Checked = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lnResult As Integer
        Dim lsTxt As String
        Dim lnXlTemplateId As Long
        Dim lsXlTemplateName As String
        Dim lsFldProperty As String = "C"
        Dim lsActiveStatus As String
        Dim i As Integer
        Dim cmd As MySqlCommand

        Try
            lsXlTemplateName = QuoteFilter(txtName.Text)
            lnXlTemplateId = Val(txtId.Text)

            Select Case True
                Case optSms.Checked
                    lsFldProperty = "S"
                Case optVariable.Checked
                    lsFldProperty = "V"
            End Select

            Select Case True
                Case optTemplateActive.Checked
                    lsActiveStatus = "Y"
                Case optTemplateInactive.Checked
                    lsActiveStatus = "N"
                Case Else
                    MsgBox("Please select active status !", MsgBoxStyle.Information, gsProjectName)
                    Exit Sub
            End Select

            If lnXlTemplateId = 0 Then
                cmd = New MySqlCommand("pr_ins_xltemplate", gOdbcConn)
            Else
                cmd = New MySqlCommand("pr_upd_xltemplate", gOdbcConn)
            End If

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?in_xltemplate_name", lsXlTemplateName)
            cmd.Parameters.AddWithValue("?in_field_property", lsFldProperty)
            cmd.Parameters.AddWithValue("?in_active_status", lsActiveStatus)
            cmd.Parameters.AddWithValue("?in_action_by", gsLoginUserCode)

            If lnXlTemplateId > 0 Then
                cmd.Parameters.AddWithValue("?in_xltemplate_gid", lnXlTemplateId)
            Else
                cmd.Parameters.Add("?out_xltemplate_gid", MySqlDbType.Int32)
                cmd.Parameters("?out_xltemplate_gid").Direction = ParameterDirection.Output
            End If

            'Out put Para
            cmd.Parameters.Add("?out_msg", MySqlDbType.VarChar)
            cmd.Parameters("?out_msg").Direction = ParameterDirection.Output
            cmd.Parameters.Add("?out_result", MySqlDbType.Int32)
            cmd.Parameters("?out_result").Direction = ParameterDirection.Output

            cmd.CommandTimeout = 0

            cmd.ExecuteNonQuery()

            If lnXlTemplateId = 0 Then lnXlTemplateId = Val(cmd.Parameters("?out_xltemplate_gid").Value.ToString())

            lnResult = Val(cmd.Parameters("?out_result").Value.ToString())
            lsTxt = cmd.Parameters("?out_msg").Value.ToString()

            If lnResult = 1 Then
                With dgvFldMap
                    For i = 0 To .Rows.Count - 1
                        cmd = New MySqlCommand("pr_ins_xltemplatefield", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?in_xltemplate_gid", lnXlTemplateId)
                        cmd.Parameters.AddWithValue("?in_xlcolumn_name", .Rows(i).Cells("xlcolumn_name").Value)
                        cmd.Parameters.AddWithValue("?in_field_name", .Rows(i).Cells("field_name").Value)
                        cmd.Parameters.AddWithValue("?in_mandatory_flag", .Rows(i).Cells("mandatory_flag").Value)
                        cmd.Parameters.AddWithValue("?in_field_format", .Rows(i).Cells("field_format").Value)
                        cmd.Parameters.AddWithValue("?in_field_length", Val(.Rows(i).Cells("field_length").Value))
                        cmd.Parameters.AddWithValue("?in_field_default_value", .Rows(i).Cells("field_default_value").Value)
                        cmd.Parameters.AddWithValue("?in_active_status", .Rows(i).Cells("active_status").Value)
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
                    Next i
                End With
            End If

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
        dgvFldMap.Rows.Clear()
        Call ClearFieldMapping()
        txtName.Focus()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Call ClearControl()
        Call EnableSave(False)
    End Sub

    Private Sub btnClr_Click(sender As Object, e As EventArgs) Handles btnClr.Click
        If MsgBox("Are you sure to clear ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then
            ClearFieldMapping()
        End If
    End Sub

    Private Sub ClearHeader()
        txtName.Text = ""

        optVariable.Checked = True
        optTemplateActive.Checked = True
    End Sub

    Private Sub ClearFieldMapping()
        txtSNo.Text = dgvFldMap.Rows.Count + 1
        txtXlColName.Text = ""
        txtDefaultValue.Text = ""

        cboFldName.Text = ""
        cboFldName.SelectedIndex = -1
        txtFldFormat.Text = ""
        txtDefaultValue.Text = ""
        txtFldLength.Text = ""

        optMandatoryYes.Checked = True
        optFldActive.Checked = True
    End Sub

    Private Sub optVariable_CheckedChanged(sender As Object, e As EventArgs) Handles optVariable.CheckedChanged
        Dim lsSql As String

        lsSql = ""
        lsSql &= " select field_name,field_display_desc from sms_mst_tfield "
        lsSql &= " where field_property in ('V','C') "
        lsSql &= " and active_status = 'Y' "
        lsSql &= " and delete_flag = 'N' "
        lsSql &= " order by field_gid"

        Call gpBindCombo(lsSql, "field_display_desc", "field_name", cboFldName, gOdbcConn)
    End Sub

    Private Sub optSms_CheckedChanged(sender As Object, e As EventArgs) Handles optSms.CheckedChanged
        Dim lsSql As String

        lsSql = ""
        lsSql &= " select field_name,field_display_desc from sms_mst_tfield "
        lsSql &= " where field_property in ('S','C') "
        lsSql &= " and active_status = 'Y' "
        lsSql &= " and delete_flag = 'N' "
        lsSql &= " order by field_gid"

        Call gpBindCombo(lsSql, "field_display_desc", "field_name", cboFldName, gOdbcConn)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim i As Integer

        With dgvFldMap
            If .Rows.Count > 0 And Val(txtSNo.Text) <= .Rows.Count And Val(txtSNo.Text) > 0 Then
                If MsgBox("Are you sure to remove ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then
                    .Rows.RemoveAt(Val(txtSNo.Text) - 1)

                    For i = 0 To .Rows.Count - 1
                        .Rows(i).Cells("sno").Value = i + 1
                    Next i
                End If
            End If
        End With
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim i As Integer
        Dim n As Integer
        Dim lsFldName As String
        Dim lsFldType As String

        txtXlColName.Text = txtXlColName.Text.Trim
        txtDefaultValue.Text = txtDefaultValue.Text.Trim
        txtFldFormat.Text = txtFldFormat.Text.Trim
        txtFldLength.Text = txtFldLength.Text.Trim

        If txtXlColName.Text = "" Then
            MsgBox("XL column name cannot be blank !", MsgBoxStyle.Information, gsProjectName)
            txtXlColName.Focus()
            Exit Sub
        End If

        If cboFldName.Text = "" Or cboFldName.SelectedIndex = -1 Then
            MsgBox("Please select the field name !", MsgBoxStyle.Information, gsProjectName)
            cboFldName.Focus()
            Exit Sub
        End If

        lsFldName = cboFldName.SelectedValue
        n = Val(txtSNo.Text)

        If txtDefaultValue.Text <> "" Then
            lsFldType = gfExecuteScalar("select fn_get_fieldtype('" & lsFldName & "')", gOdbcConn)

            Select Case lsFldType
                Case "NUMBER"
                    If Not IsNumeric(txtDefaultValue.Text) Then
                        MsgBox("Default value must be numeric !", MsgBoxStyle.Critical, gsProjectName)
                        txtDefaultValue.Focus()
                        Exit Sub
                    End If
                Case "DATE"
                    If IsDate(txtDefaultValue.Text) = False _
                        And txtDefaultValue.Text <> "NOW" _
                        And txtDefaultValue.Text <> "SYSDATE" _
                        And txtDefaultValue.Text <> "CURDATE" Then
                        MsgBox("Default value must be date/NOW !", MsgBoxStyle.Critical, gsProjectName)
                        Exit Sub
                    End If
            End Select

            MsgBox("XL column name cannot be blank !", MsgBoxStyle.Information, gsProjectName)
            txtXlColName.Focus()
            Exit Sub
        End If

        If txtFldLength.Text <> "" And IsNumeric(txtFldLength.Text) = False Then
            MsgBox("Invalid field length !", MsgBoxStyle.Information, gsProjectName)
            txtFldLength.Focus()
            Exit Sub
        End If

        With dgvFldMap
            For i = 0 To .Rows.Count - 1
                If i <> (n - 1) Then
                    If .Rows(i).Cells("field_name").Value = lsFldName Then
                        MsgBox("Field already mapped !", MsgBoxStyle.Information, gsProjectName)
                        cboFldName.Focus()
                        Exit Sub
                    End If
                End If
            Next i

            If .Rows.Count = n - 1 Then dgvFldMap.Rows.Add()
        End With

        With dgvFldMap.Rows(Val(txtSNo.Text) - 1)
            .Cells("Select").Value = "Select"
            .Cells("sno").Value = Val(txtSNo.Text)
            .Cells("xlcolumn_name").Value = txtXlColName.Text
            .Cells("field_name").Value = cboFldName.SelectedValue
            .Cells("field_display_desc").Value = cboFldName.Text
            .Cells("field_format").Value = txtFldFormat.Text
            .Cells("field_length").Value = txtFldLength.Text
            .Cells("field_default_value").Value = txtDefaultValue.Text

            If optMandatoryYes.Checked = True Then
                .Cells("mandatory_flag").Value = "Y"
            Else
                .Cells("mandatory_flag").Value = "N"
            End If

            If optFldActive.Checked = True Then
                .Cells("active_status").Value = "Y"
            Else
                .Cells("active_status").Value = "N"
            End If
        End With

        Call ClearFieldMapping()
    End Sub

    Private Sub dgvFldMap_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFldMap.CellContentClick
        Select Case e.ColumnIndex
            Case 0
                If MsgBox("Are you sure to select ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
                    With dgvFldMap.Rows(e.RowIndex)
                        txtSNo.Text = .Cells("sno").Value
                        txtXlColName.Text = .Cells("xlcolumn_name").Value
                        cboFldName.Text = .Cells("field_display_desc").Value
                        txtFldFormat.Text = .Cells("field_format").Value
                        txtFldLength.Text = .Cells("field_length").Value

                        If .Cells("mandatory_flag").Value = "Y" Then
                            optMandatoryYes.Checked = True
                        Else
                            optMandatoryNo.Checked = True
                        End If

                        If .Cells("active_status").Value = "Y" Then
                            optFldActive.Checked = True
                        Else
                            optFldInactive.Checked = True
                        End If
                    End With
                End If
        End Select
    End Sub

    Private Sub frmXlTemplateMaster_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        With pnlGrid
            dgvFldMap.Left = 0
            dgvFldMap.Top = 0
            dgvFldMap.Width = .Width
            dgvFldMap.Height = .Height
        End With

        pnlButtons.Left = (Me.Width \ 2) - (pnlButtons.Width \ 2)
        pnlSave.Left = (Me.Width \ 2) - (pnlSave.Width \ 2)
    End Sub

    Private Sub pnlGrid_Paint(sender As Object, e As PaintEventArgs) Handles pnlGrid.Paint

    End Sub

    Private Sub txtFldFormat_TextChanged(sender As Object, e As EventArgs) Handles txtFldFormat.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub txtSNo_TextChanged(sender As Object, e As EventArgs) Handles txtSNo.TextChanged

    End Sub
End Class