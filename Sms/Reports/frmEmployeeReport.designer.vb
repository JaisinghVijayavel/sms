<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeeReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeReport))
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.SNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlExport = New System.Windows.Forms.Panel()
        Me.txtRecCount = New System.Windows.Forms.TextBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.cboActive = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmployeeCode = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExport.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SNo})
        Me.dgvReport.Location = New System.Drawing.Point(14, 87)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.Size = New System.Drawing.Size(754, 222)
        Me.dgvReport.TabIndex = 4
        Me.dgvReport.VirtualMode = True
        '
        'SNo
        '
        Me.SNo.HeaderText = "SNo"
        Me.SNo.Name = "SNo"
        Me.SNo.ReadOnly = True
        Me.SNo.Width = 50
        '
        'pnlExport
        '
        Me.pnlExport.Controls.Add(Me.txtRecCount)
        Me.pnlExport.Controls.Add(Me.btnExport)
        Me.pnlExport.Location = New System.Drawing.Point(14, 315)
        Me.pnlExport.Name = "pnlExport"
        Me.pnlExport.Size = New System.Drawing.Size(634, 33)
        Me.pnlExport.TabIndex = 5
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
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.cboActive)
        Me.pnlMain.Controls.Add(Me.Label5)
        Me.pnlMain.Controls.Add(Me.txtEmployeeName)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.txtEmployeeCode)
        Me.pnlMain.Controls.Add(Me.Label21)
        Me.pnlMain.Controls.Add(Me.btnClose)
        Me.pnlMain.Controls.Add(Me.btnClear)
        Me.pnlMain.Controls.Add(Me.btnRefresh)
        Me.pnlMain.Location = New System.Drawing.Point(14, 6)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(754, 75)
        Me.pnlMain.TabIndex = 7
        '
        'cboActive
        '
        Me.cboActive.FormattingEnabled = True
        Me.cboActive.Location = New System.Drawing.Point(103, 42)
        Me.cboActive.Name = "cboActive"
        Me.cboActive.Size = New System.Drawing.Size(270, 21)
        Me.cboActive.TabIndex = 136
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(21, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Active"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Location = New System.Drawing.Point(478, 10)
        Me.txtEmployeeName.MaxLength = 0
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.Size = New System.Drawing.Size(270, 21)
        Me.txtEmployeeName.TabIndex = 132
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(371, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 15)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Employee Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmployeeCode
        '
        Me.txtEmployeeCode.Location = New System.Drawing.Point(103, 9)
        Me.txtEmployeeCode.MaxLength = 0
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.Size = New System.Drawing.Size(270, 21)
        Me.txtEmployeeCode.TabIndex = 130
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(6, 12)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(101, 13)
        Me.Label21.TabIndex = 131
        Me.Label21.Text = "Employee Code"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(656, 41)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "&Close"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(578, 41)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "C&lear"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(500, 41)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "&Refresh"
        '
        'frmEmployeeReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(783, 354)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlExport)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEmployeeReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExport.ResumeLayout(False)
        Me.pnlExport.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents pnlExport As System.Windows.Forms.Panel
    Friend WithEvents txtRecCount As System.Windows.Forms.TextBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeCode As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents cboActive As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SNo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
