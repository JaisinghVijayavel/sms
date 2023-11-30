Public Class frmTranReport
    Dim fsSql As String = ""
    Dim fsDisplayFld As String = ""
    Dim fnSenderId As Long = 0
    Dim fnUploadId As Long = 0
    Dim fbUploadable As Boolean = False
    Dim fbRefreshFlag As Boolean = False

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    Public Sub New(SenderId As Long, UploadId As Long)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        fnSenderId = SenderId
        fnUploadId = UploadId
        fbRefreshFlag = True
    End Sub


    Public Sub New(SenderId As Long, UploadableFlag As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        fnSenderId = SenderId
        fbUploadable = UploadableFlag
        fbRefreshFlag = True
    End Sub


    Private Sub frmNotepadAsciiReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        Dim i As Integer

        ' bind sender
        fsSql = ""
        fsSql &= " select sender_gid,sender_name from sms_mst_tsender "
        fsSql &= " where 1 = 1"
        fsSql &= " and delete_flag = 'N' order by sender_name asc"

        Call gpBindCombo(fsSql, "sender_name", "sender_gid", cboSender, gOdbcConn)

        fsSql = ""
        fsSql &= " select smstemplate_gid,smstemplate_name from sms_mst_tsmstemplate "
        fsSql &= " where 1 = 1"
        fsSql &= " and delete_flag = 'N' order by smstemplate_name asc"

        Call gpBindCombo(fsSql, "smstemplate_name", "smstemplate_gid", cboSmsTemplate, gOdbcConn)

        With cboStatus
            .Items.Clear()
            .Items.Add("All")
            .Items.Add("Delivered")
            .Items.Add("Failed")
            .Items.Add("Sms To Be Send")
        End With

        dtpImportFrom.Value = Now
        dtpImportTo.Value = Now

        dtpImportFrom.Checked = False
        dtpImportTo.Checked = False

        dtpUploadFrom.Value = Now
        dtpUploadTo.Value = Now

        dtpUploadFrom.Checked = False
        dtpUploadTo.Checked = False

        ' get display columns
        fsSql = ""
        fsSql &= " select field_name,field_display_desc from sms_mst_tfield "
        fsSql &= " where active_status = 'Y' "
        fsSql &= " and field_display_flag = 'Y' "
        fsSql &= " and delete_flag = 'N' "
        fsSql &= " order by field_display_order"

        Call gpDataSet(fsSql, "field", gOdbcConn, ds)

        With ds.Tables("field")
            For i = 0 To .Rows.Count - 1
                fsDisplayFld = fsDisplayFld & "a." & .Rows(i).Item("field_name").ToString & " as '" & .Rows(i).Item("field_display_desc").ToString & "',"
            Next i

            .Rows.Clear()
        End With

        If fbRefreshFlag = True Then btnRefresh.PerformClick()
    End Sub

    Private Sub frmNotepadAsciiReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        pnlMain.Top = 6
        pnlMain.Left = 6

        With dgvReport
            .Top = pnlMain.Top + pnlMain.Height + 6
            .Left = 6
            .Width = Me.Width - 24
            .Height = Math.Abs(Me.Height - (pnlMain.Top + pnlMain.Height) - pnlExport.Height - 42)
        End With

        pnlExport.Top = dgvReport.Top + dgvReport.Height + 6
        pnlExport.Left = dgvReport.Left
        pnlExport.Width = dgvReport.Width
        btnExport.Left = Math.Abs(pnlExport.Width - btnExport.Width)
    End Sub

    Private Sub LoadData()
        Dim i As Integer
        Dim lsSql As String = ""
        Dim lsCond As String

        Try
            lsCond = ""

            If cboFileName.SelectedIndex <> -1 And cboFileName.Text <> "" Then lsCond &= " and b.file_gid = " & cboFileName.SelectedValue.ToString & " "

            If dtpUploadFrom.Checked = True Then lsCond &= " and e.upload_date >= '" & Format(CDate(dtpUploadFrom.Value), "yyyy-MM-dd") & "' "
            If dtpUploadTo.Checked = True Then lsCond &= " and e.upload_date < '" & Format(DateAdd("d", 1, CDate(dtpUploadTo.Value)), "yyyy-MM-dd") & "' "

            If txtMobileNo.Text <> "" Then lsCond &= " and a.mobile_no like '" & txtMobileNo.Text.Trim & "%' "
            If txtTranId.Text <> "" Then lsCond &= " and a.tran_gid = " & Val(txtTranId.Text) & " "
            If txtUploadId.Text <> "" Then lsCond &= " and a.upload_gid = " & Val(txtUploadId.Text) & " "

            If cboSender.SelectedIndex <> -1 And cboSender.Text <> "" Then lsCond &= " and a.sender_gid = '" & cboSender.SelectedValue.ToString & "' "
            If cboSmsTemplate.SelectedIndex <> -1 And cboSmsTemplate.Text <> "" Then lsCond &= " and a.smstemplate_gid = '" & cboSmsTemplate.SelectedValue.ToString & "' "

            Select Case cboStatus.Text.ToUpper
                Case "DELIVERED"
                    lsCond &= " and a.sms_status & " & gnSmsDelivered & " > 0 "
                Case "FAILED"
                    lsCond &= " and a.sms_status & " & gnSmsFailed & " > 0 "
                Case "SMS TO BE SEND"
                    lsCond &= " and a.sms_status & " & (gnSmsDelivered Or gnSmsFailed) & " = 0 "
            End Select

            If dtpImportFrom.Checked = True Then lsCond &= " and b.insert_date >= '" & Format(CDate(dtpImportFrom.Value), "yyyy-MM-dd") & "' "
            If dtpImportTo.Checked = True Then lsCond &= " and b.insert_date < '" & Format(DateAdd("d", 1, CDate(dtpImportTo.Value)), "yyyy-MM-dd") & "' "

            If fnSenderId > 0 Then lsCond &= " and a.sender_gid = " & fnSenderId & " "
            If fnUploadId > 0 Then lsCond &= " and a.upload_gid = " & fnUploadId & " "
            If fbUploadable = True Then lsCond &= " and a.upload_gid = 0 "

            If lsCond = "" Then lsCond &= " and 1 = 2 "

            lsSql = ""
            lsSql &= " select "

            If chkReportFormat.Checked Then
                Call gfInsertQry("set @sno:=0", gOdbcConn)

                lsSql &= " @sno:=@sno+1 as 'Sl No',"
                lsSql &= " c.sender_name as 'Sender Name',"
                lsSql &= " b.file_name as 'File Name',"
                lsSql &= " a.mobile_no as 'Mobile No',"
                lsSql &= " a.sms_txt as 'Sms Text',"
                lsSql &= " a.send_date as 'Send Date',"
                lsSql &= " if(a.sms_status & " & gnSmsDelivered & " > 0,'Delivered','Not Delivered') as 'Sms Status' "
            Else
                lsSql &= " b.insert_date as 'Import Date',c.sender_name as 'Sender Name',"
                lsSql &= " d.smstemplate_name as 'Sms Template Name',"
                lsSql &= " a.sms_txt as 'Sms Text',"
                lsSql &= " make_set(a.sms_status,'Upload','Delivered','Failed') as 'Sms Status',"
                lsSql &= fsDisplayFld
                lsSql &= " a.err_code as 'Error Code',"
                lsSql &= " a.job_id as 'Job Id',"
                lsSql &= " a.send_date as 'Send Date',"
                lsSql &= " a.sms_count as 'Sms Count',"
                lsSql &= " a.tran_gid as 'Tran Id',"
                lsSql &= " b.file_name as 'File Name',b.sheet_name as 'Sheet Name',b.file_gid as 'File Id',"
                lsSql &= " e.insert_date as 'Upload Date',e.upload_code as 'Upload Code',e.insert_by as 'Upload By',"
                lsSql &= " a.smstemplate_gid as 'Sms Template Id',a.upload_gid as 'Upload Id' "
            End If

            lsSql &= " from sms_trn_ttran a"
            lsSql &= " left join sms_trn_tfile as b on a.file_gid = b.file_gid and b.delete_flag = 'N' "
            lsSql &= " left join sms_mst_tsender as c on a.sender_gid = c.sender_gid and c.delete_flag = 'N' "
            lsSql &= " left join sms_mst_tsmstemplate as d on a.smstemplate_gid = d.smstemplate_gid and d.delete_flag = 'N' "
            lsSql &= " left join sms_trn_tupload as e on a.upload_gid = e.upload_gid and e.delete_flag = 'N' "
            lsSql &= " where 1 = 1 "
            lsSql &= lsCond
            lsSql &= " and a.delete_flag = 'N' order by a.tran_gid"

            gpPopGridView(dgvReport, lsSql, gOdbcConn)

            txtTotRec.Text = "Total Records : " & dgvReport.RowCount

            For i = 0 To dgvReport.ColumnCount - 1
                dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        btnRefresh.Enabled = False

        Call LoadData()

        btnRefresh.Enabled = True
        Me.Cursor = System.Windows.Forms.Cursors.Default

        btnRefresh.Focus()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        frmCtrClear(Me)

        dtpImportFrom.Checked = False
        dtpImportTo.Checked = False

        dtpUploadFrom.Checked = False
        dtpUploadTo.Checked = False

        cboFileName.SelectedIndex = -1
        cboSender.SelectedIndex = -1
        cboSmsTemplate.SelectedIndex = -1

        txtMobileNo.Focus()
        dgvReport.DataSource = Nothing
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            PrintDGridXML(dgvReport, gsReportPath & "\Report.xls", "Report")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboFileName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileName.GotFocus
        fsSql = ""
        fsSql &= " select file_gid,concat(file_name,' ',ifnull(sheet_name,'')) as file_name from sms_trn_tfile "
        fsSql &= " where 1 = 1"

        If dtpImportFrom.Checked = True Then
            fsSql &= " and import_date >= '" & Format(dtpImportFrom.Value, "yyyy-MM-dd") & "'"
        End If

        If dtpImportTo.Checked = True Then
            fsSql &= " and import_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpImportTo.Value), "yyyy-MM-dd") & "'"
        End If

        fsSql &= " and delete_flag = 'N' order by file_gid desc"

        gpBindCombo(fsSql, "file_name", "file_gid", cboFileName, gOdbcConn)
    End Sub

    Private Sub cboFileName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFileName.SelectedIndexChanged

    End Sub

    Private Sub pnlMain_Paint(sender As Object, e As PaintEventArgs) Handles pnlMain.Paint

    End Sub
End Class