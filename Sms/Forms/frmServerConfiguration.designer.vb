<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServerConfiguration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServerConfiguration))
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.txtServerIP = New System.Windows.Forms.TextBox()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReportPath = New System.Windows.Forms.TextBox()
        Me.lblAsciiPath = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.lblServerIP = New System.Windows.Forms.Label()
        Me.lblUserId = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConfigure = New System.Windows.Forms.Button()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnClearConfig = New System.Windows.Forms.Button()
        Me.pnlMain.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.txtServerIP)
        Me.pnlMain.Controls.Add(Me.txtDatabase)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.txtPort)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.txtReportPath)
        Me.pnlMain.Controls.Add(Me.lblAsciiPath)
        Me.pnlMain.Controls.Add(Me.txtPassword)
        Me.pnlMain.Controls.Add(Me.lblPassword)
        Me.pnlMain.Controls.Add(Me.txtUserId)
        Me.pnlMain.Controls.Add(Me.lblServerIP)
        Me.pnlMain.Controls.Add(Me.lblUserId)
        Me.pnlMain.Location = New System.Drawing.Point(7, 8)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(276, 179)
        Me.pnlMain.TabIndex = 0
        '
        'txtServerIP
        '
        Me.txtServerIP.Location = New System.Drawing.Point(92, 10)
        Me.txtServerIP.MaxLength = 0
        Me.txtServerIP.Name = "txtServerIP"
        Me.txtServerIP.Size = New System.Drawing.Size(169, 21)
        Me.txtServerIP.TabIndex = 0
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(92, 119)
        Me.txtDatabase.MaxLength = 0
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(169, 21)
        Me.txtDatabase.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Database"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(92, 38)
        Me.txtPort.MaxLength = 4
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(169, 21)
        Me.txtPort.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Port"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReportPath
        '
        Me.txtReportPath.Location = New System.Drawing.Point(92, 146)
        Me.txtReportPath.MaxLength = 512
        Me.txtReportPath.Name = "txtReportPath"
        Me.txtReportPath.Size = New System.Drawing.Size(169, 21)
        Me.txtReportPath.TabIndex = 5
        '
        'lblAsciiPath
        '
        Me.lblAsciiPath.AutoSize = True
        Me.lblAsciiPath.Location = New System.Drawing.Point(8, 149)
        Me.lblAsciiPath.Name = "lblAsciiPath"
        Me.lblAsciiPath.Size = New System.Drawing.Size(75, 13)
        Me.lblAsciiPath.TabIndex = 6
        Me.lblAsciiPath.Text = "Report Path"
        Me.lblAsciiPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(92, 92)
        Me.txtPassword.MaxLength = 32
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(169, 21)
        Me.txtPassword.TabIndex = 3
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(22, 95)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(61, 13)
        Me.lblPassword.TabIndex = 6
        Me.lblPassword.Text = "&Password"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUserId
        '
        Me.txtUserId.Location = New System.Drawing.Point(92, 65)
        Me.txtUserId.MaxLength = 32
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(169, 21)
        Me.txtUserId.TabIndex = 2
        '
        'lblServerIP
        '
        Me.lblServerIP.AutoSize = True
        Me.lblServerIP.Location = New System.Drawing.Point(23, 13)
        Me.lblServerIP.Name = "lblServerIP"
        Me.lblServerIP.Size = New System.Drawing.Size(60, 13)
        Me.lblServerIP.TabIndex = 4
        Me.lblServerIP.Text = "Server &IP"
        Me.lblServerIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUserId
        '
        Me.lblUserId.AutoSize = True
        Me.lblUserId.Location = New System.Drawing.Point(34, 68)
        Me.lblUserId.Name = "lblUserId"
        Me.lblUserId.Size = New System.Drawing.Size(49, 13)
        Me.lblUserId.TabIndex = 4
        Me.lblUserId.Text = "&User ID"
        Me.lblUserId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(159, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cance&l"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnConfigure
        '
        Me.btnConfigure.Location = New System.Drawing.Point(3, 3)
        Me.btnConfigure.Name = "btnConfigure"
        Me.btnConfigure.Size = New System.Drawing.Size(72, 24)
        Me.btnConfigure.TabIndex = 0
        Me.btnConfigure.Text = "&Configure"
        Me.btnConfigure.UseVisualStyleBackColor = True
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.btnClearConfig)
        Me.pnlButtons.Controls.Add(Me.btnConfigure)
        Me.pnlButtons.Controls.Add(Me.btnCancel)
        Me.pnlButtons.Location = New System.Drawing.Point(29, 193)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(232, 30)
        Me.pnlButtons.TabIndex = 1
        '
        'btnClearConfig
        '
        Me.btnClearConfig.Location = New System.Drawing.Point(81, 3)
        Me.btnClearConfig.Name = "btnClearConfig"
        Me.btnClearConfig.Size = New System.Drawing.Size(72, 24)
        Me.btnClearConfig.TabIndex = 1
        Me.btnClearConfig.Tag = "Clear Configuration Settings"
        Me.btnClearConfig.Text = "&Clear"
        Me.btnClearConfig.UseVisualStyleBackColor = True
        '
        'frmServerConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 232)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServerConfiguration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Server Configuration Settings"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
    Friend WithEvents lblUserId As System.Windows.Forms.Label
    Friend WithEvents lblServerIP As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnConfigure As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnClearConfig As System.Windows.Forms.Button
    Friend WithEvents txtReportPath As System.Windows.Forms.TextBox
    Friend WithEvents lblAsciiPath As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtServerIP As System.Windows.Forms.TextBox
End Class
