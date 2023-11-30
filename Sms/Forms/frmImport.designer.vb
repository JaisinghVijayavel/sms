<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImport))
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.cboSmsTemplate = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboXlTemplate = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.optVariable = New System.Windows.Forms.RadioButton()
        Me.optSms = New System.Windows.Forms.RadioButton()
        Me.cboSender = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSheetName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlButton = New System.Windows.Forms.Panel()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.pnlMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.cboSmsTemplate)
        Me.pnlMain.Controls.Add(Me.Label5)
        Me.pnlMain.Controls.Add(Me.cboXlTemplate)
        Me.pnlMain.Controls.Add(Me.Label4)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Controls.Add(Me.Panel2)
        Me.pnlMain.Controls.Add(Me.cboSender)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.cboSheetName)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.pnlButton)
        Me.pnlMain.Controls.Add(Me.btnBrowse)
        Me.pnlMain.Controls.Add(Me.txtFileName)
        Me.pnlMain.Controls.Add(Me.lblFileName)
        Me.pnlMain.Location = New System.Drawing.Point(7, 7)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(465, 227)
        Me.pnlMain.TabIndex = 0
        '
        'cboSmsTemplate
        '
        Me.cboSmsTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSmsTemplate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSmsTemplate.ItemHeight = 13
        Me.cboSmsTemplate.Location = New System.Drawing.Point(96, 103)
        Me.cboSmsTemplate.Name = "cboSmsTemplate"
        Me.cboSmsTemplate.Size = New System.Drawing.Size(331, 21)
        Me.cboSmsTemplate.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Sms Template"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboXlTemplate
        '
        Me.cboXlTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXlTemplate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboXlTemplate.ItemHeight = 13
        Me.cboXlTemplate.Location = New System.Drawing.Point(96, 75)
        Me.cboXlTemplate.Name = "cboXlTemplate"
        Me.cboXlTemplate.Size = New System.Drawing.Size(331, 21)
        Me.cboXlTemplate.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "XL Template"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(-4, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Field Property"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.optVariable)
        Me.Panel2.Controls.Add(Me.optSms)
        Me.Panel2.Location = New System.Drawing.Point(96, 42)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(241, 25)
        Me.Panel2.TabIndex = 3
        '
        'optVariable
        '
        Me.optVariable.AutoSize = True
        Me.optVariable.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optVariable.Location = New System.Drawing.Point(3, 3)
        Me.optVariable.Name = "optVariable"
        Me.optVariable.Size = New System.Drawing.Size(71, 17)
        Me.optVariable.TabIndex = 0
        Me.optVariable.Text = "Variable"
        Me.optVariable.UseVisualStyleBackColor = True
        '
        'optSms
        '
        Me.optSms.AutoSize = True
        Me.optSms.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optSms.Location = New System.Drawing.Point(93, 3)
        Me.optSms.Name = "optSms"
        Me.optSms.Size = New System.Drawing.Size(49, 17)
        Me.optSms.TabIndex = 1
        Me.optSms.Text = "Sms"
        Me.optSms.UseVisualStyleBackColor = True
        '
        'cboSender
        '
        Me.cboSender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSender.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSender.ItemHeight = 13
        Me.cboSender.Location = New System.Drawing.Point(96, 13)
        Me.cboSender.Name = "cboSender"
        Me.cboSender.Size = New System.Drawing.Size(331, 21)
        Me.cboSender.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sender"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSheetName
        '
        Me.cboSheetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSheetName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSheetName.ItemHeight = 13
        Me.cboSheetName.Location = New System.Drawing.Point(96, 161)
        Me.cboSheetName.Name = "cboSheetName"
        Me.cboSheetName.Size = New System.Drawing.Size(331, 21)
        Me.cboSheetName.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Sheet Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.btnImport)
        Me.pnlButton.Controls.Add(Me.btnClose)
        Me.pnlButton.Location = New System.Drawing.Point(275, 188)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(152, 28)
        Me.pnlButton.TabIndex = 12
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(1, 1)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(72, 24)
        Me.btnImport.TabIndex = 1
        Me.btnImport.Text = "&Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(79, 1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(433, 130)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(25, 21)
        Me.btnBrowse.TabIndex = 9
        Me.btnBrowse.Text = "...."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(96, 130)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(331, 21)
        Me.txtFileName.TabIndex = 8
        '
        'lblFileName
        '
        Me.lblFileName.Location = New System.Drawing.Point(32, 134)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(61, 13)
        Me.lblFileName.TabIndex = 8
        Me.lblFileName.Text = "File Name"
        Me.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 243)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlButton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents cboSheetName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cboSender As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSmsTemplate As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboXlTemplate As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents optVariable As System.Windows.Forms.RadioButton
    Friend WithEvents optSms As System.Windows.Forms.RadioButton
End Class
