<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSenderMaster
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
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.optNo = New System.Windows.Forms.RadioButton()
        Me.optYes = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblClientName = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
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
        Me.pnlMain.SuspendLayout()
        Me.pnlSave.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.optNo)
        Me.pnlMain.Controls.Add(Me.optYes)
        Me.pnlMain.Controls.Add(Me.Label5)
        Me.pnlMain.Controls.Add(Me.txtName)
        Me.pnlMain.Controls.Add(Me.lblClientName)
        Me.pnlMain.Controls.Add(Me.txtCode)
        Me.pnlMain.Controls.Add(Me.lblClientCode)
        Me.pnlMain.Controls.Add(Me.txtId)
        Me.pnlMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlMain.Location = New System.Drawing.Point(6, 6)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(383, 90)
        Me.pnlMain.TabIndex = 0
        '
        'optNo
        '
        Me.optNo.AutoSize = True
        Me.optNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optNo.Location = New System.Drawing.Point(153, 61)
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
        Me.optYes.Location = New System.Drawing.Point(103, 61)
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
        Me.Label5.Location = New System.Drawing.Point(-9, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 15)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Active Status"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(102, 35)
        Me.txtName.MaxLength = 128
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(269, 21)
        Me.txtName.TabIndex = 1
        '
        'lblClientName
        '
        Me.lblClientName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblClientName.Location = New System.Drawing.Point(5, 38)
        Me.lblClientName.Name = "lblClientName"
        Me.lblClientName.Size = New System.Drawing.Size(91, 13)
        Me.lblClientName.TabIndex = 68
        Me.lblClientName.Text = "Sender Name"
        Me.lblClientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(102, 9)
        Me.txtCode.MaxLength = 16
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(269, 21)
        Me.txtCode.TabIndex = 0
        '
        'lblClientCode
        '
        Me.lblClientCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblClientCode.Location = New System.Drawing.Point(5, 12)
        Me.lblClientCode.Name = "lblClientCode"
        Me.lblClientCode.Size = New System.Drawing.Size(91, 13)
        Me.lblClientCode.TabIndex = 66
        Me.lblClientCode.Text = "Sender Code"
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
        Me.pnlSave.Location = New System.Drawing.Point(121, 103)
        Me.pnlSave.Name = "pnlSave"
        Me.pnlSave.Size = New System.Drawing.Size(152, 28)
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
        Me.pnlButtons.Location = New System.Drawing.Point(4, 103)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(386, 28)
        Me.pnlButtons.TabIndex = 10
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
        'frmSenderMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 138)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlSave)
        Me.Controls.Add(Me.pnlButtons)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSenderMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sender Master"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlSave.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblClientName As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
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
End Class
