<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTranReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTranReport))
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.chkReportFormat = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUploadId = New System.Windows.Forms.TextBox()
        Me.dtpUploadTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpUploadFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTranId = New System.Windows.Forms.TextBox()
        Me.cboSmsTemplate = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.cboSender = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMobileNo = New System.Windows.Forms.TextBox()
        Me.dtpImportTo = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpImportFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboFileName = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.txtTotRec = New System.Windows.Forms.TextBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.pnlExport = New System.Windows.Forms.Panel()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.pnlMain.SuspendLayout()
        Me.pnlExport.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.chkReportFormat)
        Me.pnlMain.Controls.Add(Me.Label5)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Controls.Add(Me.txtUploadId)
        Me.pnlMain.Controls.Add(Me.dtpUploadTo)
        Me.pnlMain.Controls.Add(Me.dtpUploadFrom)
        Me.pnlMain.Controls.Add(Me.Label20)
        Me.pnlMain.Controls.Add(Me.Label6)
        Me.pnlMain.Controls.Add(Me.txtTranId)
        Me.pnlMain.Controls.Add(Me.cboSmsTemplate)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.cboStatus)
        Me.pnlMain.Controls.Add(Me.cboSender)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.Label13)
        Me.pnlMain.Controls.Add(Me.Label4)
        Me.pnlMain.Controls.Add(Me.txtMobileNo)
        Me.pnlMain.Controls.Add(Me.dtpImportTo)
        Me.pnlMain.Controls.Add(Me.Label8)
        Me.pnlMain.Controls.Add(Me.dtpImportFrom)
        Me.pnlMain.Controls.Add(Me.Label7)
        Me.pnlMain.Controls.Add(Me.cboFileName)
        Me.pnlMain.Controls.Add(Me.Label9)
        Me.pnlMain.Controls.Add(Me.btnClose)
        Me.pnlMain.Controls.Add(Me.btnClear)
        Me.pnlMain.Controls.Add(Me.btnRefresh)
        Me.pnlMain.Location = New System.Drawing.Point(12, 12)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(794, 151)
        Me.pnlMain.TabIndex = 0
        '
        'chkReportFormat
        '
        Me.chkReportFormat.AutoSize = True
        Me.chkReportFormat.ForeColor = System.Drawing.Color.Blue
        Me.chkReportFormat.Location = New System.Drawing.Point(90, 117)
        Me.chkReportFormat.Name = "chkReportFormat"
        Me.chkReportFormat.Size = New System.Drawing.Size(109, 17)
        Me.chkReportFormat.TabIndex = 25
        Me.chkReportFormat.Text = "Report Format"
        Me.chkReportFormat.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(257, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "To"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Upload Id"
        '
        'txtUploadId
        '
        Me.txtUploadId.Location = New System.Drawing.Point(90, 90)
        Me.txtUploadId.MaxLength = 0
        Me.txtUploadId.Name = "txtUploadId"
        Me.txtUploadId.Size = New System.Drawing.Size(105, 21)
        Me.txtUploadId.TabIndex = 17
        '
        'dtpUploadTo
        '
        Me.dtpUploadTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpUploadTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpUploadTo.Location = New System.Drawing.Point(280, 36)
        Me.dtpUploadTo.Name = "dtpUploadTo"
        Me.dtpUploadTo.ShowCheckBox = True
        Me.dtpUploadTo.Size = New System.Drawing.Size(105, 21)
        Me.dtpUploadTo.TabIndex = 10
        '
        'dtpUploadFrom
        '
        Me.dtpUploadFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpUploadFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpUploadFrom.Location = New System.Drawing.Point(90, 36)
        Me.dtpUploadFrom.Name = "dtpUploadFrom"
        Me.dtpUploadFrom.ShowCheckBox = True
        Me.dtpUploadFrom.Size = New System.Drawing.Size(105, 21)
        Me.dtpUploadFrom.TabIndex = 7
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 39)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(78, 13)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "Upload From"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(201, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(77, 16)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Tran Id"
        '
        'txtTranId
        '
        Me.txtTranId.Location = New System.Drawing.Point(280, 90)
        Me.txtTranId.MaxLength = 0
        Me.txtTranId.Name = "txtTranId"
        Me.txtTranId.Size = New System.Drawing.Size(105, 21)
        Me.txtTranId.TabIndex = 19
        '
        'cboSmsTemplate
        '
        Me.cboSmsTemplate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSmsTemplate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSmsTemplate.FormattingEnabled = True
        Me.cboSmsTemplate.Location = New System.Drawing.Point(90, 63)
        Me.cboSmsTemplate.Name = "cboSmsTemplate"
        Me.cboSmsTemplate.Size = New System.Drawing.Size(295, 21)
        Me.cboSmsTemplate.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(-8, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Sms Template"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(486, 90)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(295, 21)
        Me.cboStatus.TabIndex = 21
        '
        'cboSender
        '
        Me.cboSender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSender.FormattingEnabled = True
        Me.cboSender.Location = New System.Drawing.Point(486, 36)
        Me.cboSender.Name = "cboSender"
        Me.cboSender.Size = New System.Drawing.Size(295, 21)
        Me.cboSender.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(391, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Sender Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(403, 93)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label13.Size = New System.Drawing.Size(77, 16)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Status"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(405, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(75, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Mobile No"
        '
        'txtMobileNo
        '
        Me.txtMobileNo.Location = New System.Drawing.Point(486, 63)
        Me.txtMobileNo.MaxLength = 0
        Me.txtMobileNo.Name = "txtMobileNo"
        Me.txtMobileNo.Size = New System.Drawing.Size(295, 21)
        Me.txtMobileNo.TabIndex = 15
        '
        'dtpImportTo
        '
        Me.dtpImportTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpImportTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpImportTo.Location = New System.Drawing.Point(280, 9)
        Me.dtpImportTo.Name = "dtpImportTo"
        Me.dtpImportTo.ShowCheckBox = True
        Me.dtpImportTo.Size = New System.Drawing.Size(105, 21)
        Me.dtpImportTo.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(257, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(21, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "To"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpImportFrom
        '
        Me.dtpImportFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpImportFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpImportFrom.Location = New System.Drawing.Point(90, 9)
        Me.dtpImportFrom.Name = "dtpImportFrom"
        Me.dtpImportFrom.ShowCheckBox = True
        Me.dtpImportFrom.Size = New System.Drawing.Size(105, 21)
        Me.dtpImportFrom.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Import From"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFileName
        '
        Me.cboFileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFileName.FormattingEnabled = True
        Me.cboFileName.Location = New System.Drawing.Point(486, 9)
        Me.cboFileName.Name = "cboFileName"
        Me.cboFileName.Size = New System.Drawing.Size(295, 21)
        Me.cboFileName.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(418, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "File Name"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(709, 117)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 24
        Me.btnClose.Text = "&Close"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(631, 117)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 23
        Me.btnClear.Text = "C&lear"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(553, 117)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 22
        Me.btnRefresh.Text = "&Refresh"
        '
        'txtTotRec
        '
        Me.txtTotRec.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotRec.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotRec.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotRec.Location = New System.Drawing.Point(3, 11)
        Me.txtTotRec.MaxLength = 100
        Me.txtTotRec.Name = "txtTotRec"
        Me.txtTotRec.ReadOnly = True
        Me.txtTotRec.Size = New System.Drawing.Size(433, 14)
        Me.txtTotRec.TabIndex = 0
        Me.txtTotRec.TabStop = False
        Me.txtTotRec.Text = "Total Records : "
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(562, 5)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "&Export"
        '
        'pnlExport
        '
        Me.pnlExport.Controls.Add(Me.txtTotRec)
        Me.pnlExport.Controls.Add(Me.btnExport)
        Me.pnlExport.Location = New System.Drawing.Point(20, 465)
        Me.pnlExport.Name = "pnlExport"
        Me.pnlExport.Size = New System.Drawing.Size(635, 33)
        Me.pnlExport.TabIndex = 2
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(12, 169)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.Size = New System.Drawing.Size(801, 278)
        Me.dgvReport.TabIndex = 1
        '
        'frmTranReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 574)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlExport)
        Me.Controls.Add(Me.dgvReport)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTranReport"
        Me.Text = "Finacle Statement Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlExport.ResumeLayout(False)
        Me.pnlExport.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub

    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents dtpImportTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpImportFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboFileName As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents txtTotRec As System.Windows.Forms.TextBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents pnlExport As System.Windows.Forms.Panel
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMobileNo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboSender As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTranId As System.Windows.Forms.TextBox
    Friend WithEvents dtpUploadTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpUploadFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboSmsTemplate As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUploadId As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkReportFormat As System.Windows.Forms.CheckBox
End Class
