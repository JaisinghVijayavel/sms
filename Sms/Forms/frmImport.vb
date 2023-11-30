Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class frmImport

    Inherits System.Windows.Forms.Form
#Region "Local Declaration"
    Dim fsSql As String
    Dim lnResult As Long

    Dim fsFilePath As String = ""
    Dim fsFileName As String
    Dim fExcelDatatable As New DataTable
    Dim lobjRow As DataRow
#End Region

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        'User Selected Browse file 
        With OpenFileDialog1

            .Filter = "Excel Files|*.xls;*.xlsx"
            .Title = "Select Files to Import"
            .RestoreDirectory = True
            .ShowDialog()
            If .FileName <> "" And .FileName <> "OpenFileDialog1" Then
                txtFileName.Text = .FileName
            End If
            .FileName = ""
        End With

        If (InStr(1, LCase(Trim(txtFileName.Text)), ".xls")) > 0 Then
            cboSheetName.Enabled = True

            Call LoadSheet()

            cboSheetName.Focus()
        Else
            cboSheetName.Enabled = False
        End If

        Exit Sub
    End Sub

    Private Sub LoadSheet()
        Dim objXls As New Excel.Application
        Dim objBook As Excel.Workbook

        If Trim(txtFileName.Text) <> "" Then
            If File.Exists(txtFileName.Text) Then
                objBook = objXls.Workbooks.Open(txtFileName.Text)
                cboSheetName.Items.Clear()
                For i As Integer = 1 To objXls.ActiveWorkbook.Worksheets.Count
                    cboSheetName.Items.Add(objXls.ActiveWorkbook.Worksheets(i).Name)
                Next i
                objXls.Workbooks.Close()

            End If
        End If

        objXls.Workbooks.Close()

        GC.Collect()
        GC.WaitForPendingFinalizers()

        objXls.Quit()

        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(objXls)
        objXls = Nothing
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            MyBase.Close()
        End If
    End Sub

    Private Sub frmImportP2P_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lsSql As String

        lsSql = ""
        lsSql &= " select sender_gid,sender_name from sms_mst_tsender "
        lsSql &= " where active_status = 'Y' "
        lsSql &= " and delete_flag = 'N' "
        lsSql &= " order by sender_name "

        Call gpBindCombo(lsSql, "sender_name", "sender_gid", cboSender, gOdbcConn)
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim lnSenderId As Integer
        Dim lsFldProperty As String
        Dim lnXlTemplateId As Integer
        Dim lnSmsTemplateId As Integer
        Dim lsFileName As String
        Dim lsSheetName As String


        Try
            If cboSender.Text = "" Or cboSender.SelectedIndex = -1 Then
                MsgBox("Please select the sender !", MsgBoxStyle.Information, gsProjectName)
                cboSender.Focus()
                Exit Sub
            End If

            Select Case True
                Case optVariable.Checked
                    lsFldProperty = "V"
                Case optSms.Checked
                    lsFldProperty = "S"
                Case Else
                    MsgBox("Please select field property !", MsgBoxStyle.Information, gsProjectName)
                    Exit Sub
            End Select

            If cboXlTemplate.Text = "" Or cboXlTemplate.SelectedIndex = -1 Then
                MsgBox("Please select xl template !", MsgBoxStyle.Information, gsProjectName)
                cboXlTemplate.Focus()
                Exit Sub
            End If

            If lsFldProperty = "V" Then
                If cboSmsTemplate.Text = "" Or cboSmsTemplate.SelectedIndex = -1 Then
                    MsgBox("Please select sms template !", MsgBoxStyle.Information, gsProjectName)
                    cboSmsTemplate.Focus()
                    Exit Sub
                End If
            End If

            If txtFileName.Text = "" Then
                MsgBox("Select File Name", MsgBoxStyle.Information, gsProjectName)
                txtFileName.Focus()
                Exit Sub
            End If

            If (cboSheetName.SelectedIndex = -1 Or cboSheetName.Text = "") Then
                MessageBox.Show("Please select the sheet !", gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboSheetName.Focus()
                Exit Sub
            End If

            lnSenderId = Val(cboSender.SelectedValue.ToString)
            lnXlTemplateId = Val(cboXlTemplate.SelectedValue.ToString)

            If cboSmsTemplate.SelectedIndex = -1 Or cboSmsTemplate.Text = "" Then
                lnSmsTemplateId = 0
            Else
                lnSmsTemplateId = Val(cboSmsTemplate.SelectedValue.ToString)
            End If

            lsFileName = txtFileName.Text
            lsSheetName = cboSheetName.Text

            pnlMain.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()

            fsFilePath = txtFileName.Text.Trim
            fsFileName = fsFilePath.Substring(fsFilePath.LastIndexOf("\") + 1)

            If txtFileName.Text <> "" Then
                If cboSheetName.Text <> "" Then
                    Call FormatSheet(txtFileName.Text, cboSheetName.Text)
                Else
                    MsgBox("Select Sheet Name!", MsgBoxStyle.Information, gsProjectName)
                    Exit Sub
                End If
            Else
                MsgBox("Select File to Import!", MsgBoxStyle.Information, gsProjectName)
                Exit Sub
            End If

            Call ImportFile(lnSenderId, lsFldProperty, lnXlTemplateId, lnSmsTemplateId, lsFileName, lsSheetName)

            pnlMain.Enabled = True
            btnImport.Enabled = True
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)

            btnImport.Enabled = True
            Me.Cursor = Cursors.Default
            Application.DoEvents()
        End Try
    End Sub

    Public Sub ImportFile(SenderId As Long, FieldProperty As String, XlTemplateId As Integer, SmsTemplateId As Integer, ByVal FileName As String, SheetName As String, Optional ShowFlag As Boolean = True)
        Dim lobjXlDt As New DataTable
        Dim lsXlColumnName As String
        Dim lsSmsTemplate As String

        Dim ds As New DataSet

        Dim lsSql As String = ""
        Dim lsFileName As String
        Dim lnResult As Long
        Dim lnFileId As Long = 0

        Dim lsTranDate As String = ""
        Dim lsAccNo As String = ""
        Dim lsTranDesc As String = ""
        Dim lnAmount As Double = 0
        Dim lnBalAmount As Double = 0
        Dim lsAccMode As String = ""
        Dim lnMult As Integer = 0
        Dim lsTranRefId As String = ""
        Dim lsTranPsrl As String = ""
        Dim lsTranIsid As String = ""
        Dim lsTranRemark As String = ""
        Dim lsMsg As String = ""
        Dim lsTxt As String = ""

        Dim lbInsertFlag As Boolean = False
        Dim lbFindFlag As Boolean = False

        Dim n As Integer
        Dim c As Long = 0, d As Long = 0
        Dim i As Long
        Dim j As Long

        Dim lstXlTemplateFld As New List(Of clsXlTemplateField)
        Dim lobjXlTemplateFld As clsXlTemplateField
        Dim lobjSmsDataStru As New clsSmsDataStru

        Try
            ' get sms_template
            lsSql = ""
            lsSql &= " select sms_template from sms_mst_tsmstemplate "
            lsSql &= " where smstemplate_gid = " & SmsTemplateId & " "
            lsSql &= " and sender_gid = " & SenderId & " "
            lsSql &= " and active_status = 'Y' "
            lsSql &= " and delete_flag = 'N' "

            lsSmsTemplate = gfExecuteScalar(lsSql, gOdbcConn)

            ' get xltemplate field
            lsSql = ""
            lsSql &= " select a.*,b.field_type,b.field_template_code,b.field_property from sms_mst_txltemplatefield as a "
            lsSql &= " left join sms_mst_tfield as b on a.field_name = b.field_name and b.delete_flag = 'N' "
            lsSql &= " where a.xltemplate_gid = " & XlTemplateId & " "
            lsSql &= " and a.active_status = 'Y' "
            lsSql &= " and a.delete_flag = 'N' "

            Call gpDataSet(lsSql, "fld", gOdbcConn, ds)

            With ds.Tables("fld")
                For i = 0 To .Rows.Count - 1
                    lobjXlTemplateFld = New clsXlTemplateField()

                    lobjXlTemplateFld.xlcolumn_name = .Rows(i).Item("xlcolumn_name").ToString
                    lobjXlTemplateFld.field_name = .Rows(i).Item("field_name").ToString
                    lobjXlTemplateFld.field_type = .Rows(i).Item("field_type").ToString
                    lobjXlTemplateFld.field_property = .Rows(i).Item("field_property").ToString
                    lobjXlTemplateFld.mandatory_flag = .Rows(i).Item("mandatory_flag").ToString
                    lobjXlTemplateFld.field_format = .Rows(i).Item("field_format").ToString
                    lobjXlTemplateFld.field_length = Val(.Rows(i).Item("field_length").ToString)
                    lobjXlTemplateFld.field_default_value = .Rows(i).Item("field_default_value").ToString
                    lobjXlTemplateFld.field_template_code = .Rows(i).Item("field_template_code").ToString

                    lstXlTemplateFld.Add(lobjXlTemplateFld)
                Next i

                .Rows.Clear()
            End With

            ' open xl sheet
            lobjXlDt = gpExcelDataset("select * from [" & SheetName & "$]", FileName)

            ' verity all xl column with xl template column table
            With lobjXlDt
                For i = 0 To lstXlTemplateFld.Count - 1
                    lobjXlTemplateFld = lstXlTemplateFld(i)
                    lbFindFlag = False

                    For j = 0 To .Columns.Count - 1
                        lsXlColumnName = .Columns(CInt(j)).ColumnName

                        If lsXlColumnName.ToUpper = lobjXlTemplateFld.xlcolumn_name.ToUpper Then
                            lbFindFlag = True
                            Exit For
                        End If
                    Next j

                    If lbFindFlag = False Then
                        MsgBox("XL Template column name [" & lsXlColumnName & "] not available in the selected sheet !", MsgBoxStyle.Critical, gsProjectName)
                        lobjXlDt.Dispose()
                        Exit Sub
                    End If
                Next i
            End With

            If FileIO.FileSystem.FileExists(FileName) = True Then
                n = FileName.Split("\").GetUpperBound(0)
                lsFileName = FileName.Split("\")(n)

                Using cmd As New MySqlCommand("pr_ins_file", gOdbcConn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("?in_file_name", lsFileName)
                    cmd.Parameters.AddWithValue("?in_sheet_name", SheetName)
                    cmd.Parameters.AddWithValue("?in_sender_gid", SenderId)
                    cmd.Parameters.AddWithValue("?in_field_property", FieldProperty)
                    cmd.Parameters.AddWithValue("?in_xltemplate_gid", XlTemplateId)
                    cmd.Parameters.AddWithValue("?in_smstemplate_gid", SmsTemplateId)
                    cmd.Parameters.AddWithValue("?in_action_by", gsLoginUserCode)

                    'Out put Para
                    cmd.Parameters.Add("?out_result", MySqlDbType.Int32)
                    cmd.Parameters("?out_result").Direction = ParameterDirection.Output
                    cmd.Parameters.Add("?out_msg", MySqlDbType.VarChar)
                    cmd.Parameters("?out_msg").Direction = ParameterDirection.Output
                    cmd.Parameters.Add("?out_file_gid", MySqlDbType.Int64)
                    cmd.Parameters("?out_file_gid").Direction = ParameterDirection.Output

                    cmd.ExecuteNonQuery()

                    lnResult = Val(cmd.Parameters("?out_result").Value.ToString())

                    If (lnResult = 0) Then
                        lsTxt = cmd.Parameters("?out_msg").Value.ToString()
                        MsgBox(lsTxt, MsgBoxStyle.Critical, gsProjectName)
                        Exit Sub
                    End If

                    lnFileId = Val(cmd.Parameters("?out_file_gid").Value.ToString())
                End Using

                With lobjXlDt
                    For i = 0 To .Rows.Count - 1
                        Application.DoEvents()

                        lobjSmsDataStru = New clsSmsDataStru
                        lobjSmsDataStru.sms_template = lsSmsTemplate

                        If FieldProperty = "V" Then
                            lobjSmsDataStru.sms_txt = lsSmsTemplate
                        End If

                        lobjSmsDataStru.line_no = i + 1
                        lobjSmsDataStru.insert_flag = True

                        For j = 0 To lstXlTemplateFld.Count - 1
                            lobjXlTemplateFld = lstXlTemplateFld(j)

                            lsTxt = .Rows(i).Item(lobjXlTemplateFld.xlcolumn_name).ToString

                            ' check default value
                            If lsTxt = "" Then
                                If lobjXlTemplateFld.mandatory_flag = "Y" Then
                                    If lobjXlTemplateFld.field_default_value <> "" Then
                                        lsTxt = lobjXlTemplateFld.field_default_value

                                        If lobjXlTemplateFld.field_type = "DATE" Then
                                            Select Case lobjXlTemplateFld.field_default_value.ToUpper
                                                Case "DATE", "NOW", "SYSDATE", "CURDATE"
                                                    lsTxt = Format(Now, "dd-MMM-yyyy")
                                            End Select
                                        End If

                                        If lobjXlTemplateFld.field_format <> "" Then
                                            lsTxt = Format(lsTxt, lobjXlTemplateFld.field_format)
                                        End If
                                    Else
                                        lobjSmsDataStru.err_text += lobjXlTemplateFld.xlcolumn_name & " should be mandatory,"
                                        lobjSmsDataStru.insert_flag = False
                                    End If
                                End If
                            Else
                                If lobjXlTemplateFld.field_format <> "" Then
                                    Select Case lobjXlTemplateFld.field_type
                                        Case "DATE"
                                            If IsDate(lsTxt) Then lsTxt = Format(CDate(lsTxt), lobjXlTemplateFld.field_format)
                                        Case "NUMBER"
                                            If IsNumeric(lsTxt) Then lsTxt = Format(Val(lsTxt), lobjXlTemplateFld.field_format)
                                    End Select
                                End If
                            End If

                            If lobjXlTemplateFld.field_length > 0 Then
                                lsTxt = Mid(lsTxt, 1, lobjXlTemplateFld.field_length)
                            End If

                            If FieldProperty = "V" And lobjXlTemplateFld.field_template_code <> "" Then
                                lobjSmsDataStru.sms_txt = lobjSmsDataStru.sms_txt.Replace("<<" & lobjXlTemplateFld.field_template_code & ">>", lsTxt)
                            End If

                            Select Case lobjXlTemplateFld.field_name
                                Case "mobile_no"
                                    lobjSmsDataStru.mobile_no = lsTxt
                                Case "sms_txt"
                                    lobjSmsDataStru.sms_txt = lsTxt
                                Case "sms_template_id"
                                    lobjSmsDataStru.sms_template_id = lsTxt
                                Case "ref_col1"
                                    lobjSmsDataStru.ref_col1 = lsTxt
                                Case "ref_col2"
                                    lobjSmsDataStru.ref_col2 = lsTxt
                                Case "ref_col3"
                                    lobjSmsDataStru.ref_col3 = lsTxt
                                Case "ref_col4"
                                    lobjSmsDataStru.ref_col4 = lsTxt
                                Case "ref_col5"
                                    lobjSmsDataStru.ref_col5 = lsTxt
                                Case "ref_col6"
                                    lobjSmsDataStru.ref_col6 = lsTxt
                                Case "ref_col7"
                                    lobjSmsDataStru.ref_col7 = lsTxt
                                Case "ref_col8"
                                    lobjSmsDataStru.ref_col8 = lsTxt
                                Case "ref_col9"
                                    lobjSmsDataStru.ref_col9 = lsTxt
                                Case "ref_col10"
                                    lobjSmsDataStru.ref_col10 = lsTxt
                                Case "ref_col11"
                                    lobjSmsDataStru.ref_col11 = lsTxt
                                Case "ref_col12"
                                    lobjSmsDataStru.ref_col12 = lsTxt
                                Case "ref_col13"
                                    lobjSmsDataStru.ref_col13 = lsTxt
                                Case "ref_col14"
                                    lobjSmsDataStru.ref_col14 = lsTxt
                                Case "ref_col15"
                                    lobjSmsDataStru.ref_col15 = lsTxt
                                Case "ref_col16"
                                    lobjSmsDataStru.ref_col16 = lsTxt
                                Case "ref_col17"
                                    lobjSmsDataStru.ref_col17 = lsTxt
                                Case "ref_col18"
                                    lobjSmsDataStru.ref_col18 = lsTxt
                                Case "ref_col19"
                                    lobjSmsDataStru.ref_col19 = lsTxt
                                Case "ref_col20"
                                    lobjSmsDataStru.ref_col20 = lsTxt
                                Case "ref_col21"
                                    lobjSmsDataStru.ref_col21 = lsTxt
                                Case "ref_col22"
                                    lobjSmsDataStru.ref_col22 = lsTxt
                                Case "ref_col23"
                                    lobjSmsDataStru.ref_col23 = lsTxt
                                Case "ref_col24"
                                    lobjSmsDataStru.ref_col24 = lsTxt
                                Case "ref_col25"
                                    lobjSmsDataStru.ref_col25 = lsTxt
                                Case "ref_col26"
                                    lobjSmsDataStru.ref_col26 = lsTxt
                                Case "ref_col27"
                                    lobjSmsDataStru.ref_col27 = lsTxt
                                Case "ref_col28"
                                    lobjSmsDataStru.ref_col28 = lsTxt
                                Case "ref_col29"
                                    lobjSmsDataStru.ref_col29 = lsTxt
                                Case "ref_col30"
                                    lobjSmsDataStru.ref_col30 = lsTxt
                                Case "ref_col31"
                                    lobjSmsDataStru.ref_col31 = lsTxt
                                Case "ref_col32"
                                    lobjSmsDataStru.ref_col32 = lsTxt
                            End Select
                        Next j

                        If lobjSmsDataStru.insert_flag = True Then
                            Using cmd As New MySqlCommand("pr_ins_tran", gOdbcConn)
                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.CommandTimeout = 0

                                cmd.Parameters.AddWithValue("?in_file_gid", lnFileId)
                                cmd.Parameters.AddWithValue("?in_sender_gid", SenderId)
                                cmd.Parameters.AddWithValue("?in_smstemplate_gid", SmsTemplateId)
                                cmd.Parameters.AddWithValue("?in_sms_template_id", lobjSmsDataStru.sms_template_id)
                                cmd.Parameters.AddWithValue("?in_mobile_no", lobjSmsDataStru.mobile_no)
                                cmd.Parameters.AddWithValue("?in_sms_txt", lobjSmsDataStru.sms_txt)
                                cmd.Parameters.AddWithValue("?in_ref_col1", lobjSmsDataStru.ref_col1)
                                cmd.Parameters.AddWithValue("?in_ref_col2", lobjSmsDataStru.ref_col2)
                                cmd.Parameters.AddWithValue("?in_ref_col3", lobjSmsDataStru.ref_col3)
                                cmd.Parameters.AddWithValue("?in_ref_col4", lobjSmsDataStru.ref_col4)
                                cmd.Parameters.AddWithValue("?in_ref_col5", lobjSmsDataStru.ref_col5)
                                cmd.Parameters.AddWithValue("?in_ref_col6", lobjSmsDataStru.ref_col6)
                                cmd.Parameters.AddWithValue("?in_ref_col7", lobjSmsDataStru.ref_col7)
                                cmd.Parameters.AddWithValue("?in_ref_col8", lobjSmsDataStru.ref_col8)
                                cmd.Parameters.AddWithValue("?in_ref_col9", lobjSmsDataStru.ref_col9)
                                cmd.Parameters.AddWithValue("?in_ref_col10", lobjSmsDataStru.ref_col10)
                                cmd.Parameters.AddWithValue("?in_ref_col11", lobjSmsDataStru.ref_col11)
                                cmd.Parameters.AddWithValue("?in_ref_col12", lobjSmsDataStru.ref_col12)
                                cmd.Parameters.AddWithValue("?in_ref_col13", lobjSmsDataStru.ref_col13)
                                cmd.Parameters.AddWithValue("?in_ref_col14", lobjSmsDataStru.ref_col14)
                                cmd.Parameters.AddWithValue("?in_ref_col15", lobjSmsDataStru.ref_col15)
                                cmd.Parameters.AddWithValue("?in_ref_col16", lobjSmsDataStru.ref_col16)
                                cmd.Parameters.AddWithValue("?in_ref_col17", lobjSmsDataStru.ref_col17)
                                cmd.Parameters.AddWithValue("?in_ref_col18", lobjSmsDataStru.ref_col18)
                                cmd.Parameters.AddWithValue("?in_ref_col19", lobjSmsDataStru.ref_col19)
                                cmd.Parameters.AddWithValue("?in_ref_col20", lobjSmsDataStru.ref_col20)
                                cmd.Parameters.AddWithValue("?in_ref_col21", lobjSmsDataStru.ref_col21)
                                cmd.Parameters.AddWithValue("?in_ref_col22", lobjSmsDataStru.ref_col22)
                                cmd.Parameters.AddWithValue("?in_ref_col23", lobjSmsDataStru.ref_col23)
                                cmd.Parameters.AddWithValue("?in_ref_col24", lobjSmsDataStru.ref_col24)
                                cmd.Parameters.AddWithValue("?in_ref_col25", lobjSmsDataStru.ref_col25)
                                cmd.Parameters.AddWithValue("?in_ref_col26", lobjSmsDataStru.ref_col26)
                                cmd.Parameters.AddWithValue("?in_ref_col27", lobjSmsDataStru.ref_col27)
                                cmd.Parameters.AddWithValue("?in_ref_col28", lobjSmsDataStru.ref_col28)
                                cmd.Parameters.AddWithValue("?in_ref_col29", lobjSmsDataStru.ref_col29)
                                cmd.Parameters.AddWithValue("?in_ref_col30", lobjSmsDataStru.ref_col30)
                                cmd.Parameters.AddWithValue("?in_ref_col31", lobjSmsDataStru.ref_col31)
                                cmd.Parameters.AddWithValue("?in_ref_col32", lobjSmsDataStru.ref_col32)

                                'Out put Para
                                cmd.Parameters.Add("?out_result", MySqlDbType.Int32)
                                cmd.Parameters("?out_result").Direction = ParameterDirection.Output
                                cmd.Parameters.Add("?out_msg", MySqlDbType.VarChar)
                                cmd.Parameters("?out_msg").Direction = ParameterDirection.Output

                                cmd.ExecuteNonQuery()

                                lnResult = Val(cmd.Parameters("?out_result").Value.ToString())
                                lsTxt = cmd.Parameters("?out_msg").Value.ToString()
                            End Using

                            If (lnResult = 0) Then
                                Using cmd As New MySqlCommand("pr_ins_errline", gOdbcConn)
                                    cmd.CommandType = CommandType.StoredProcedure
                                    cmd.CommandTimeout = 0

                                    cmd.Parameters.AddWithValue("?in_file_gid", lnFileId)
                                    cmd.Parameters.AddWithValue("?in_errline_no", lobjSmsDataStru.line_no)
                                    cmd.Parameters.AddWithValue("?in_errline_desc", lsTxt)

                                    cmd.ExecuteNonQuery()
                                End Using
                            End If

                            Application.DoEvents()
                            frmMain.lblStatus.Text = "Out of " & .Rows.Count & " record(s) reading " & (i + 1) & " record ..."
                        Else
                            Using cmd As New MySqlCommand("pr_ins_errline", gOdbcConn)
                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.CommandTimeout = 0

                                cmd.Parameters.AddWithValue("?in_file_gid", lnFileId)
                                cmd.Parameters.AddWithValue("?in_errline_no", lobjSmsDataStru.line_no)
                                cmd.Parameters.AddWithValue("?in_errline_desc", lobjSmsDataStru.err_text)

                                cmd.ExecuteNonQuery()
                            End Using
                        End If
                    Next i
                End With

                If ShowFlag Then
                    MsgBox("File imported successfully !", MsgBoxStyle.Information, gsProjectName)

                    ShowQuery("select * from sms_trn_ttran " & _
                              "where file_gid = '" & lnFileId & "' " & _
                              "and delete_flag = 'N'", gOdbcConn)
                End If
            End If

            frmMain.lblStatus.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Private Sub optVariable_CheckedChanged(sender As Object, e As EventArgs) Handles optVariable.CheckedChanged
        Dim lsSql As String

        If optVariable.Checked Then
            lsSql = ""
            lsSql &= " select xltemplate_gid,xltemplate_name from sms_mst_txltemplate "
            lsSql &= " where field_property = 'V' "
            lsSql &= " and active_status = 'Y' "
            lsSql &= " and delete_flag = 'N' "
            lsSql &= " order by xltemplate_name "

            Call gpBindCombo(lsSql, "xltemplate_name", "xltemplate_gid", cboXlTemplate, gOdbcConn)

            cboSmsTemplate.Enabled = True
            cboSmsTemplate.Text = ""
            cboSmsTemplate.SelectedIndex = -1
        End If
    End Sub

    Private Sub optSms_CheckedChanged(sender As Object, e As EventArgs) Handles optSms.CheckedChanged
        Dim lsSql As String

        If optSms.Checked Then
            lsSql = ""
            lsSql &= " select xltemplate_gid,xltemplate_name from sms_mst_txltemplate "
            lsSql &= " where field_property = 'S' "
            lsSql &= " and active_status = 'Y' "
            lsSql &= " and delete_flag = 'N' "
            lsSql &= " order by xltemplate_name "

            Call gpBindCombo(lsSql, "xltemplate_name", "xltemplate_gid", cboXlTemplate, gOdbcConn)

            cboSmsTemplate.Enabled = False
            cboSmsTemplate.Text = ""
            cboSmsTemplate.SelectedIndex = -1
        End If
    End Sub

    Private Sub cboSmsTemplate_GotFocus(sender As Object, e As EventArgs) Handles cboSmsTemplate.GotFocus
        Dim lsSql As String
        Dim lnSenderId As Integer = 0
        Dim lnSmsTemplateId As Integer = 0

        If cboSender.Text <> "" And cboSender.SelectedIndex <> -1 Then
            lnSenderId = Val(cboSender.SelectedValue.ToString)
        End If

        If cboSmsTemplate.Text <> "" And cboSmsTemplate.SelectedIndex <> -1 Then
            lnSmsTemplateId = Val(cboSmsTemplate.SelectedValue.ToString)
        End If

        lsSql = ""
        lsSql &= " select smstemplate_gid,smstemplate_name from sms_mst_tsmstemplate "
        lsSql &= " where sender_gid = " & lnSenderId & " "
        lsSql &= " and active_status = 'Y' "
        lsSql &= " and delete_flag = 'N' "
        lsSql &= " order by smstemplate_name "

        Call gpBindCombo(lsSql, "smstemplate_name", "smstemplate_gid", cboSmsTemplate, gOdbcConn)

        cboSmsTemplate.SelectedValue = lnSmsTemplateId
    End Sub

    Private Sub cboSmsTemplate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSmsTemplate.SelectedIndexChanged

    End Sub
End Class