<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSmsTemplateMaster
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.cboSender = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optNo = New System.Windows.Forms.RadioButton()
        Me.optYes = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSmsTemplate = New System.Windows.Forms.TextBox()
        Me.lblClientName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblClientCode = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.pnlSave = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.dgvField = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.pnlSave.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        CType(Me.dgvField, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.cboSender)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.optNo)
        Me.pnlMain.Controls.Add(Me.optYes)
        Me.pnlMain.Controls.Add(Me.Label5)
        Me.pnlMain.Controls.Add(Me.txtSmsTemplate)
        Me.pnlMain.Controls.Add(Me.lblClientName)
        Me.pnlMain.Controls.Add(Me.txtName)
        Me.pnlMain.Controls.Add(Me.lblClientCode)
        Me.pnlMain.Controls.Add(Me.txtId)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Controls.Add(Me.Label4)
        Me.pnlMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlMain.Location = New System.Drawing.Point(6, 6)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(559, 235)
        Me.pnlMain.TabIndex = 0
        '
        'cboSender
        '
        Me.cboSender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSender.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSender.ItemHeight = 13
        Me.cboSender.Location = New System.Drawing.Point(139, 177)
        Me.cboSender.Name = "cboSender"
        Me.cboSender.Size = New System.Drawing.Size(406, 21)
        Me.cboSender.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 180)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sender"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'optNo
        '
        Me.optNo.AutoSize = True
        Me.optNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optNo.Location = New System.Drawing.Point(189, 204)
        Me.optNo.Name = "optNo"
        Me.optNo.Size = New System.Drawing.Size(39, 17)
        Me.optNo.TabIndex = 8
        Me.optNo.Text = "No"
        Me.optNo.UseVisualStyleBackColor = True
        '
        'optYes
        '
        Me.optYes.AutoSize = True
        Me.optYes.Checked = True
        Me.optYes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optYes.Location = New System.Drawing.Point(139, 204)
        Me.optYes.Name = "optYes"
        Me.optYes.Size = New System.Drawing.Size(45, 17)
        Me.optYes.TabIndex = 7
        Me.optYes.TabStop = True
        Me.optYes.Text = "Yes"
        Me.optYes.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(27, 205)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 15)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Active Status"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSmsTemplate
        '
        Me.txtSmsTemplate.Location = New System.Drawing.Point(139, 35)
        Me.txtSmsTemplate.MaxLength = 0
        Me.txtSmsTemplate.Multiline = True
        Me.txtSmsTemplate.Name = "txtSmsTemplate"
        Me.txtSmsTemplate.Size = New System.Drawing.Size(406, 136)
        Me.txtSmsTemplate.TabIndex = 3
        '
        'lblClientName
        '
        Me.lblClientName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblClientName.Location = New System.Drawing.Point(42, 38)
        Me.lblClientName.Name = "lblClientName"
        Me.lblClientName.Size = New System.Drawing.Size(91, 13)
        Me.lblClientName.TabIndex = 2
        Me.lblClientName.Text = "Sms Template"
        Me.lblClientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(139, 8)
        Me.txtName.MaxLength = 16
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(406, 21)
        Me.txtName.TabIndex = 1
        '
        'lblClientCode
        '
        Me.lblClientCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblClientCode.Location = New System.Drawing.Point(5, 12)
        Me.lblClientCode.Name = "lblClientCode"
        Me.lblClientCode.Size = New System.Drawing.Size(128, 13)
        Me.lblClientCode.TabIndex = 0
        Me.lblClientCode.Text = "Sms Template Name"
        Me.lblClientCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(3, 4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(26, 21)
        Me.txtId.TabIndex = 64
        Me.txtId.Visible = False
        '
        'pnlSave
        '
        Me.pnlSave.CausesValidation = False
        Me.pnlSave.Controls.Add(Me.btnCancel)
        Me.pnlSave.Controls.Add(Me.btnSave)
        Me.pnlSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSave.Location = New System.Drawing.Point(122, 470)
        Me.pnlSave.Name = "pnlSave"
        Me.pnlSave.Size = New System.Drawing.Size(152, 30)
        Me.pnlSave.TabIndex = 11
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(80, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(2, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnFind)
        Me.pnlButtons.Controls.Add(Me.btnDelete)
        Me.pnlButtons.Controls.Add(Me.btnEdit)
        Me.pnlButtons.Controls.Add(Me.btnNew)
        Me.pnlButtons.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlButtons.Location = New System.Drawing.Point(5, 470)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(386, 30)
        Me.pnlButtons.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(313, 1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "C&lose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.SystemColors.Control
        Me.btnFind.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFind.Location = New System.Drawing.Point(157, 1)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(72, 24)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "&Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelete.Location = New System.Drawing.Point(235, 1)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(79, 1)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(72, 24)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.SystemColors.Control
        Me.btnNew.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNew.Location = New System.Drawing.Point(1, 1)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(72, 24)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'dgvField
        '
        Me.dgvField.AllowUserToAddRows = False
        Me.dgvField.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvField.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvField.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvField.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvField.Location = New System.Drawing.Point(6, 247)
        Me.dgvField.Name = "dgvField"
        Me.dgvField.ReadOnly = True
        Me.dgvField.Size = New System.Drawing.Size(559, 215)
        Me.dgvField.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(5, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Note:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(5, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Template Code Format"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(5, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 13)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "<<template_code>>"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmSmsTemplateMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 503)
        Me.Controls.Add(Me.dgvField)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlSave)
        Me.Controls.Add(Me.pnlButtons)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSmsTemplateMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sms Template Master"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlSave.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        CType(Me.dgvField, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents txtSmsTemplate As System.Windows.Forms.TextBox
    Friend WithEvents lblClientName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblClientCode As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents pnlSave As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents optNo As System.Windows.Forms.RadioButton
    Friend WithEvents optYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboSender As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvField As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
