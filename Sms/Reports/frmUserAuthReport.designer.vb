<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserAuthReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserAuthReport))
        Me.lblRequestFromdate = New System.Windows.Forms.Label()
        Me.dtpRequestfrom = New System.Windows.Forms.DateTimePicker()
        Me.lblRequestDateTo = New System.Windows.Forms.Label()
        Me.dtpRequestTo = New System.Windows.Forms.DateTimePicker()
        Me.btnexport = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dtpAuthTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpAuthFrom = New System.Windows.Forms.DateTimePicker()
        Me.dgvRpt = New System.Windows.Forms.DataGridView()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.cboAuthStatus = New System.Windows.Forms.ComboBox()
        Me.lblAuthStatus = New System.Windows.Forms.Label()
        CType(Me.dgvRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRequestFromdate
        '
        Me.lblRequestFromdate.AutoSize = True
        Me.lblRequestFromdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequestFromdate.Location = New System.Drawing.Point(8, 14)
        Me.lblRequestFromdate.Name = "lblRequestFromdate"
        Me.lblRequestFromdate.Size = New System.Drawing.Size(89, 13)
        Me.lblRequestFromdate.TabIndex = 21
        Me.lblRequestFromdate.Text = "Request  From"
        '
        'dtpRequestfrom
        '
        Me.dtpRequestfrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpRequestfrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpRequestfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRequestfrom.Location = New System.Drawing.Point(103, 10)
        Me.dtpRequestfrom.Name = "dtpRequestfrom"
        Me.dtpRequestfrom.ShowCheckBox = True
        Me.dtpRequestfrom.Size = New System.Drawing.Size(112, 21)
        Me.dtpRequestfrom.TabIndex = 0
        '
        'lblRequestDateTo
        '
        Me.lblRequestDateTo.AutoSize = True
        Me.lblRequestDateTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequestDateTo.Location = New System.Drawing.Point(241, 14)
        Me.lblRequestDateTo.Name = "lblRequestDateTo"
        Me.lblRequestDateTo.Size = New System.Drawing.Size(24, 13)
        Me.lblRequestDateTo.TabIndex = 23
        Me.lblRequestDateTo.Text = " To"
        Me.lblRequestDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpRequestTo
        '
        Me.dtpRequestTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpRequestTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpRequestTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRequestTo.Location = New System.Drawing.Point(271, 10)
        Me.dtpRequestTo.Name = "dtpRequestTo"
        Me.dtpRequestTo.ShowCheckBox = True
        Me.dtpRequestTo.Size = New System.Drawing.Size(112, 21)
        Me.dtpRequestTo.TabIndex = 1
        '
        'btnexport
        '
        Me.btnexport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexport.Location = New System.Drawing.Point(512, 37)
        Me.btnexport.Name = "btnexport"
        Me.btnexport.Size = New System.Drawing.Size(72, 24)
        Me.btnexport.TabIndex = 6
        Me.btnexport.Text = "&Export"
        Me.btnexport.UseVisualStyleBackColor = True
        '
        'btnclose
        '
        Me.btnclose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Location = New System.Drawing.Point(590, 37)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(72, 24)
        Me.btnclose.TabIndex = 8
        Me.btnclose.Text = "&Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(434, 37)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'dtpAuthTo
        '
        Me.dtpAuthTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpAuthTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAuthTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAuthTo.Location = New System.Drawing.Point(271, 37)
        Me.dtpAuthTo.Name = "dtpAuthTo"
        Me.dtpAuthTo.ShowCheckBox = True
        Me.dtpAuthTo.Size = New System.Drawing.Size(112, 21)
        Me.dtpAuthTo.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Auth From"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(241, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = " To"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpAuthFrom
        '
        Me.dtpAuthFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpAuthFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAuthFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAuthFrom.Location = New System.Drawing.Point(103, 37)
        Me.dtpAuthFrom.Name = "dtpAuthFrom"
        Me.dtpAuthFrom.ShowCheckBox = True
        Me.dtpAuthFrom.Size = New System.Drawing.Size(112, 21)
        Me.dtpAuthFrom.TabIndex = 3
        '
        'dgvRpt
        '
        Me.dgvRpt.AllowUserToAddRows = False
        Me.dgvRpt.AllowUserToDeleteRows = False
        Me.dgvRpt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvRpt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRpt.Location = New System.Drawing.Point(7, 85)
        Me.dgvRpt.Name = "dgvRpt"
        Me.dgvRpt.ReadOnly = True
        Me.dgvRpt.Size = New System.Drawing.Size(673, 243)
        Me.dgvRpt.TabIndex = 70
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.cboAuthStatus)
        Me.pnlMain.Controls.Add(Me.lblAuthStatus)
        Me.pnlMain.Controls.Add(Me.btnexport)
        Me.pnlMain.Controls.Add(Me.lblRequestFromdate)
        Me.pnlMain.Controls.Add(Me.btnclose)
        Me.pnlMain.Controls.Add(Me.dtpRequestfrom)
        Me.pnlMain.Controls.Add(Me.btnRefresh)
        Me.pnlMain.Controls.Add(Me.lblRequestDateTo)
        Me.pnlMain.Controls.Add(Me.dtpAuthTo)
        Me.pnlMain.Controls.Add(Me.dtpAuthFrom)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.dtpRequestTo)
        Me.pnlMain.Location = New System.Drawing.Point(7, 9)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(673, 70)
        Me.pnlMain.TabIndex = 0
        '
        'cboAuthStatus
        '
        Me.cboAuthStatus.FormattingEnabled = True
        Me.cboAuthStatus.Location = New System.Drawing.Point(550, 10)
        Me.cboAuthStatus.Name = "cboAuthStatus"
        Me.cboAuthStatus.Size = New System.Drawing.Size(112, 21)
        Me.cboAuthStatus.TabIndex = 2
        '
        'lblAuthStatus
        '
        Me.lblAuthStatus.AutoSize = True
        Me.lblAuthStatus.Location = New System.Drawing.Point(470, 14)
        Me.lblAuthStatus.Name = "lblAuthStatus"
        Me.lblAuthStatus.Size = New System.Drawing.Size(74, 13)
        Me.lblAuthStatus.TabIndex = 28
        Me.lblAuthStatus.Text = "Auth Status"
        '
        'frmUserAuthReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 336)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.dgvRpt)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUserAuthReport"
        Me.Text = "User Management Auth Report"
        CType(Me.dgvRpt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblRequestFromdate As System.Windows.Forms.Label
    Friend WithEvents dtpRequestfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRequestDateTo As System.Windows.Forms.Label
    Friend WithEvents dtpRequestTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnexport As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents dtpAuthTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpAuthFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvRpt As System.Windows.Forms.DataGridView
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents cboAuthStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblAuthStatus As System.Windows.Forms.Label
End Class
