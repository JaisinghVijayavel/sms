Public Class frmSmsMis
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents pnlExport As System.Windows.Forms.Panel
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSender As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFileId As System.Windows.Forms.TextBox
    Friend WithEvents txtRecCount As System.Windows.Forms.TextBox
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents txtSheetName As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents cboFileName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkFileName As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSmsMis))
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.cboFileName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtSheetName = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtFileId = New System.Windows.Forms.TextBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboSender = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlExport = New System.Windows.Forms.Panel()
        Me.txtRecCount = New System.Windows.Forms.TextBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.chkFileName = New System.Windows.Forms.CheckBox()
        Me.pnlMain.SuspendLayout()
        Me.pnlExport.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.chkFileName)
        Me.pnlMain.Controls.Add(Me.cboFileName)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.txtUserName)
        Me.pnlMain.Controls.Add(Me.txtSheetName)
        Me.pnlMain.Controls.Add(Me.Label21)
        Me.pnlMain.Controls.Add(Me.txtFileId)
        Me.pnlMain.Controls.Add(Me.dtpTo)
        Me.pnlMain.Controls.Add(Me.Label11)
        Me.pnlMain.Controls.Add(Me.dtpFrom)
        Me.pnlMain.Controls.Add(Me.Label10)
        Me.pnlMain.Controls.Add(Me.cboSender)
        Me.pnlMain.Controls.Add(Me.Label5)
        Me.pnlMain.Controls.Add(Me.btnClose)
        Me.pnlMain.Controls.Add(Me.btnClear)
        Me.pnlMain.Controls.Add(Me.btnRefresh)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.Label12)
        Me.pnlMain.Location = New System.Drawing.Point(6, 7)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(768, 100)
        Me.pnlMain.TabIndex = 0
        '
        'cboFileName
        '
        Me.cboFileName.FormattingEnabled = True
        Me.cboFileName.Location = New System.Drawing.Point(470, 39)
        Me.cboFileName.Name = "cboFileName"
        Me.cboFileName.Size = New System.Drawing.Size(283, 21)
        Me.cboFileName.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(385, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "File Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(87, 39)
        Me.txtUserName.MaxLength = 0
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(105, 21)
        Me.txtUserName.TabIndex = 3
        '
        'txtSheetName
        '
        Me.txtSheetName.Location = New System.Drawing.Point(280, 39)
        Me.txtSheetName.MaxLength = 0
        Me.txtSheetName.Name = "txtSheetName"
        Me.txtSheetName.Size = New System.Drawing.Size(105, 21)
        Me.txtSheetName.TabIndex = 4
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(2, 42)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 129
        Me.Label21.Text = "User Name"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFileId
        '
        Me.txtFileId.Location = New System.Drawing.Point(87, 66)
        Me.txtFileId.MaxLength = 0
        Me.txtFileId.Name = "txtFileId"
        Me.txtFileId.Size = New System.Drawing.Size(105, 21)
        Me.txtFileId.TabIndex = 7
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(280, 12)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(105, 21)
        Me.dtpTo.TabIndex = 1
        Me.dtpTo.Value = New Date(2008, 1, 12, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(225, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 17)
        Me.Label11.TabIndex = 115
        Me.Label11.Text = "To"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFrom
        '
        Me.dtpFrom.Checked = False
        Me.dtpFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(87, 12)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(105, 21)
        Me.dtpFrom.TabIndex = 0
        Me.dtpFrom.Value = New Date(2008, 1, 12, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(-4, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 17)
        Me.Label10.TabIndex = 115
        Me.Label10.Text = "Import From"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSender
        '
        Me.cboSender.FormattingEnabled = True
        Me.cboSender.Location = New System.Drawing.Point(470, 12)
        Me.cboSender.Name = "cboSender"
        Me.cboSender.Size = New System.Drawing.Size(283, 21)
        Me.cboSender.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(385, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "Sender"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(681, 66)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "&Close"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(603, 66)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "C&lear"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(525, 66)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 9
        Me.btnRefresh.Text = "&Refresh"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(198, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Sheet Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(18, 68)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 17)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "File Id"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlExport
        '
        Me.pnlExport.Controls.Add(Me.txtRecCount)
        Me.pnlExport.Controls.Add(Me.btnExport)
        Me.pnlExport.Location = New System.Drawing.Point(6, 316)
        Me.pnlExport.Name = "pnlExport"
        Me.pnlExport.Size = New System.Drawing.Size(634, 33)
        Me.pnlExport.TabIndex = 2
        '
        'txtRecCount
        '
        Me.txtRecCount.BackColor = System.Drawing.SystemColors.Control
        Me.txtRecCount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRecCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRecCount.Location = New System.Drawing.Point(6, 8)
        Me.txtRecCount.MaxLength = 100
        Me.txtRecCount.Name = "txtRecCount"
        Me.txtRecCount.ReadOnly = True
        Me.txtRecCount.Size = New System.Drawing.Size(433, 14)
        Me.txtRecCount.TabIndex = 0
        Me.txtRecCount.TabStop = False
        Me.txtRecCount.Text = "Record Count : "
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(558, 5)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "&Export"
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(6, 113)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.Size = New System.Drawing.Size(768, 190)
        Me.dgvReport.TabIndex = 1
        '
        'chkFileName
        '
        Me.chkFileName.AutoSize = True
        Me.chkFileName.ForeColor = System.Drawing.Color.Blue
        Me.chkFileName.Location = New System.Drawing.Point(280, 68)
        Me.chkFileName.Name = "chkFileName"
        Me.chkFileName.Size = New System.Drawing.Size(125, 17)
        Me.chkFileName.TabIndex = 8
        Me.chkFileName.Text = "Include File Name"
        Me.chkFileName.UseVisualStyleBackColor = True
        '
        'frmSmsMis
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(783, 354)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlExport)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSmsMis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sms Mis"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlExport.ResumeLayout(False)
        Me.pnlExport.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "Local Declaration"
#End Region
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        dtpFrom.Checked = False
        dtpTo.Checked = False

        Call frmCtrClear(Me)
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        btnRefresh.Enabled = False

        Call LoadData()

        btnRefresh.Enabled = True
        Me.Cursor = System.Windows.Forms.Cursors.Default

        btnRefresh.Focus()
    End Sub

    Private Sub LoadData()
        Dim lsSql As String
        Dim lsFld As String
        Dim lsCond As String
        Dim i As Integer

        Try
            lsCond = ""

            lsCond &= " and a.insert_date >= '" & Format(CDate(dtpFrom.Value), "yyyy-MM-dd") & "' "
            lsCond &= " and a.insert_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpTo.Value), "yyyy-MM-dd") & "' "

            If cboSender.Text <> "" And cboSender.SelectedIndex >= 0 Then lsCond &= " and a.sender_gid = " & Val(cboSender.SelectedValue.ToString) & " "
            If cboFileName.Text <> "" And cboFileName.SelectedIndex >= 0 Then lsCond &= " and t.file_gid = '" & Val(cboFileName.SelectedValue.ToString) & "' "
            If txtFileId.Text <> "" Then lsCond &= " and a.file_gid = '" & Val(txtFileId.Text) & "' "
            If txtSheetName.Text <> "" Then lsCond &= " and a.sheet_name like '" & QuoteFilter(txtSheetName.Text) & "%' "
            If txtUserName.Text <> "" Then lsCond &= " and a.import_by = '" & QuoteFilter(txtUserName.Text) & "' "

            If lsCond = "" Then lsCond &= " and 1 = 2 "

            lsFld = ""
            lsFld &= " a.import_date as 'Import Date',"

            If chkFileName.Checked Then
                lsFld &= " a.file_name as 'File Name',"
            End If

            lsFld &= " b.sender_name as 'Sender',"
            lsFld &= " count(*) as 'Total Received',"
            lsFld &= " sum(!(t.sms_status)) as 'Uploadable',"
            lsFld &= " sum(if(t.sms_status = " & gnSmsUpload & ",1,0)) as 'Sms To be Send',"
            lsFld &= " sum(if(t.sms_status & " & gnSmsDelivered & " > 0,1,0)) as 'Sms Delivered',"
            lsFld &= " sum(if(t.sms_status & " & gnSmsFailed & " > 0 and t.sms_status & " & gnSmsDelivered & " = 0,1,0)) as 'Sms Delivery Failed',"
            lsFld &= " sum(t.sms_count) as 'Total Sms Count',"
            lsFld &= " sum(!(t.sms_status)*t.sms_count) as 'Uploadable Sms Count',"
            lsFld &= " sum(if(t.sms_status = " & gnSmsUpload & ",t.sms_count,0)) as 'Sms Count To be Send',"
            lsFld &= " sum(if(t.sms_status & " & gnSmsDelivered & " > 0,t.sms_count,0)) as 'Sms Count Delivered',"
            lsFld &= " sum(if(t.sms_status & " & gnSmsFailed & " > 0 and t.sms_status & " & gnSmsDelivered & " = 0,t.sms_count,0)) as 'Sms Count Delivery Failed' "

            lsSql = ""
            lsSql &= " select "
            lsSql &= lsFld

            lsSql &= " from sms_trn_ttran as t "
            lsSql &= " inner join sms_trn_tfile as a on t.file_gid = a.file_gid and a.delete_flag = 'N' "
            lsSql &= " left join sms_mst_tsender as b on a.sender_gid = b.sender_gid and b.delete_flag = 'N' "
            lsSql &= " left join sms_mst_txltemplate as c on a.xltemplate_gid = c.xltemplate_gid and c.delete_flag = 'N' "
            lsSql &= " left join sms_mst_tsmstemplate as d on a.smstemplate_gid = d.smstemplate_gid and d.delete_flag = 'N' "
            lsSql &= " where true "
            lsSql &= lsCond
            lsSql &= " and t.delete_flag = 'N' "
            lsSql &= " group by a.import_date,"

            If chkFileName.Checked Then
                lsSql &= " a.file_name,"
            End If

            lsSql &= " b.sender_name "


            dgvReport.Columns.Clear()

            Call gpPopGridView(dgvReport, lsSql, gOdbcConn)

            For i = 0 To dgvReport.Columns.Count - 1
                dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            txtRecCount.Text = "Total Records : " & dgvReport.RowCount
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmPrfReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call gpBindCombo("select * from sms_mst_tsender where delete_flag = 'N' order by sender_name", _
                             "sender_name", "sender_gid", cboSender, gOdbcConn)

            dtpFrom.Value = Now
            dtpTo.Value = Now

            btnClear.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmPrfReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        pnlMain.Top = 6
        pnlMain.Left = 6

        With dgvReport
            .Top = pnlMain.Top + pnlMain.Height + 6
            .Left = 6
            .Width = Me.Width - 24
            .Height = Math.Abs(Me.Height - (pnlMain.Top + pnlMain.Height) - pnlExport.Height - 42)
        End With

        pnlExport.Top = dgvReport.Top + dgvReport.Height + 6
        pnlExport.Width = Me.Width
        btnExport.Left = pnlExport.Width - btnExport.Width - 24
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            PrintDGridXML(dgvReport, gsReportPath & "Report.xls", "Report")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboFileName_GotFocus(sender As Object, e As EventArgs) Handles cboFileName.GotFocus
        Dim lsSql As String = ""

        lsSql = ""
        lsSql &= " select file_gid,concat(file_name,' ',ifnull(sheet_name,'')) as file_name from sms_trn_tfile "
        lsSql &= " where 1 = 1"

        If dtpFrom.Checked = True Then
            lsSql &= " and insert_date >= '" & Format(dtpFrom.Value, "yyyy-MM-dd") & "'"
        End If

        If dtpTo.Checked = True Then
            lsSql &= " AND insert_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpTo.Value), "yyyy-MM-dd") & "'"
        End If

        If cboSender.Text <> "" And cboSender.SelectedIndex <> -1 Then
            lsSql &= " and file_type = " & Val(cboSender.SelectedValue.ToString)
        End If

        lsSql &= " and delete_flag = 'N' order by file_gid desc"

        gpBindCombo(lsSql, "file_name", "file_gid", cboFileName, gOdbcConn)
    End Sub
End Class
