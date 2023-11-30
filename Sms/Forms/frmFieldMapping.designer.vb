<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFieldMapping
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
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.optDispYes = New System.Windows.Forms.RadioButton()
        Me.optDispNo = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.optFldActive = New System.Windows.Forms.RadioButton()
        Me.optFldInactive = New System.Windows.Forms.RadioButton()
        Me.txtTemplateCode = New System.Windows.Forms.TextBox()
        Me.txtDisplayOrder = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboFldType = New System.Windows.Forms.ComboBox()
        Me.txtDisplayDesc = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFldName = New System.Windows.Forms.TextBox()
        Me.txtSNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgvFldMap = New System.Windows.Forms.DataGridView()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlDetail.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvFldMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDetail
        '
        Me.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetail.Controls.Add(Me.btnRefresh)
        Me.pnlDetail.Controls.Add(Me.txtId)
        Me.pnlDetail.Controls.Add(Me.Panel5)
        Me.pnlDetail.Controls.Add(Me.Label8)
        Me.pnlDetail.Controls.Add(Me.btnClose)
        Me.pnlDetail.Controls.Add(Me.btnUpdate)
        Me.pnlDetail.Controls.Add(Me.Panel4)
        Me.pnlDetail.Controls.Add(Me.txtTemplateCode)
        Me.pnlDetail.Controls.Add(Me.txtDisplayOrder)
        Me.pnlDetail.Controls.Add(Me.Label9)
        Me.pnlDetail.Controls.Add(Me.cboFldType)
        Me.pnlDetail.Controls.Add(Me.txtDisplayDesc)
        Me.pnlDetail.Controls.Add(Me.Label6)
        Me.pnlDetail.Controls.Add(Me.txtFldName)
        Me.pnlDetail.Controls.Add(Me.txtSNo)
        Me.pnlDetail.Controls.Add(Me.Label3)
        Me.pnlDetail.Controls.Add(Me.Label11)
        Me.pnlDetail.Controls.Add(Me.Label7)
        Me.pnlDetail.Controls.Add(Me.Label4)
        Me.pnlDetail.Controls.Add(Me.Label10)
        Me.pnlDetail.Location = New System.Drawing.Point(7, 12)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(717, 102)
        Me.pnlDetail.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.optDispYes)
        Me.Panel5.Controls.Add(Me.optDispNo)
        Me.Panel5.Location = New System.Drawing.Point(108, 61)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(122, 25)
        Me.Panel5.TabIndex = 13
        '
        'optDispYes
        '
        Me.optDispYes.AutoSize = True
        Me.optDispYes.Checked = True
        Me.optDispYes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optDispYes.Location = New System.Drawing.Point(3, 3)
        Me.optDispYes.Name = "optDispYes"
        Me.optDispYes.Size = New System.Drawing.Size(45, 17)
        Me.optDispYes.TabIndex = 0
        Me.optDispYes.TabStop = True
        Me.optDispYes.Text = "Yes"
        Me.optDispYes.UseVisualStyleBackColor = True
        '
        'optDispNo
        '
        Me.optDispNo.AutoSize = True
        Me.optDispNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optDispNo.Location = New System.Drawing.Point(62, 3)
        Me.optDispNo.Name = "optDispNo"
        Me.optDispNo.Size = New System.Drawing.Size(39, 17)
        Me.optDispNo.TabIndex = 1
        Me.optDispNo.Text = "No"
        Me.optDispNo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(-20, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 15)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Display Flag"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(627, 63)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnUpdate.Location = New System.Drawing.Point(471, 63)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(72, 24)
        Me.btnUpdate.TabIndex = 16
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.optFldActive)
        Me.Panel4.Controls.Add(Me.optFldInactive)
        Me.Panel4.Location = New System.Drawing.Point(337, 62)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(122, 25)
        Me.Panel4.TabIndex = 15
        '
        'optFldActive
        '
        Me.optFldActive.AutoSize = True
        Me.optFldActive.Checked = True
        Me.optFldActive.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optFldActive.Location = New System.Drawing.Point(3, 3)
        Me.optFldActive.Name = "optFldActive"
        Me.optFldActive.Size = New System.Drawing.Size(45, 17)
        Me.optFldActive.TabIndex = 0
        Me.optFldActive.TabStop = True
        Me.optFldActive.Text = "Yes"
        Me.optFldActive.UseVisualStyleBackColor = True
        '
        'optFldInactive
        '
        Me.optFldInactive.AutoSize = True
        Me.optFldInactive.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optFldInactive.Location = New System.Drawing.Point(62, 3)
        Me.optFldInactive.Name = "optFldInactive"
        Me.optFldInactive.Size = New System.Drawing.Size(39, 17)
        Me.optFldInactive.TabIndex = 1
        Me.optFldInactive.Text = "No"
        Me.optFldInactive.UseVisualStyleBackColor = True
        '
        'txtTemplateCode
        '
        Me.txtTemplateCode.Location = New System.Drawing.Point(337, 35)
        Me.txtTemplateCode.MaxLength = 32
        Me.txtTemplateCode.Name = "txtTemplateCode"
        Me.txtTemplateCode.Size = New System.Drawing.Size(131, 21)
        Me.txtTemplateCode.TabIndex = 9
        '
        'txtDisplayOrder
        '
        Me.txtDisplayOrder.Location = New System.Drawing.Point(108, 35)
        Me.txtDisplayOrder.MaxLength = 6
        Me.txtDisplayOrder.Name = "txtDisplayOrder"
        Me.txtDisplayOrder.Size = New System.Drawing.Size(131, 21)
        Me.txtDisplayOrder.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(-20, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 16)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Display Order"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFldType
        '
        Me.cboFldType.FormattingEnabled = True
        Me.cboFldType.Location = New System.Drawing.Point(568, 35)
        Me.cboFldType.Name = "cboFldType"
        Me.cboFldType.Size = New System.Drawing.Size(131, 21)
        Me.cboFldType.TabIndex = 11
        '
        'txtDisplayDesc
        '
        Me.txtDisplayDesc.Location = New System.Drawing.Point(568, 9)
        Me.txtDisplayDesc.MaxLength = 255
        Me.txtDisplayDesc.Name = "txtDisplayDesc"
        Me.txtDisplayDesc.Size = New System.Drawing.Size(131, 21)
        Me.txtDisplayDesc.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(474, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Display Name"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFldName
        '
        Me.txtFldName.BackColor = System.Drawing.SystemColors.Window
        Me.txtFldName.Location = New System.Drawing.Point(337, 9)
        Me.txtFldName.MaxLength = 128
        Me.txtFldName.Name = "txtFldName"
        Me.txtFldName.ReadOnly = True
        Me.txtFldName.Size = New System.Drawing.Size(131, 21)
        Me.txtFldName.TabIndex = 3
        Me.txtFldName.TabStop = False
        '
        'txtSNo
        '
        Me.txtSNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtSNo.Location = New System.Drawing.Point(108, 9)
        Me.txtSNo.MaxLength = 128
        Me.txtSNo.Name = "txtSNo"
        Me.txtSNo.ReadOnly = True
        Me.txtSNo.Size = New System.Drawing.Size(131, 21)
        Me.txtSNo.TabIndex = 1
        Me.txtSNo.TabStop = False
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(29, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "SNo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(209, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(122, 15)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Active Status"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(440, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 16)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Field Type"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(223, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Field Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(233, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 16)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Template Code"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvFldMap
        '
        Me.dgvFldMap.AllowUserToAddRows = False
        Me.dgvFldMap.AllowUserToDeleteRows = False
        Me.dgvFldMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFldMap.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvFldMap.Location = New System.Drawing.Point(7, 120)
        Me.dgvFldMap.Name = "dgvFldMap"
        Me.dgvFldMap.Size = New System.Drawing.Size(717, 364)
        Me.dgvFldMap.TabIndex = 1
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.SystemColors.Window
        Me.txtId.Location = New System.Drawing.Point(-1, 9)
        Me.txtId.MaxLength = 128
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(39, 21)
        Me.txtId.TabIndex = 19
        Me.txtId.Visible = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.SystemColors.Control
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRefresh.Location = New System.Drawing.Point(549, 63)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 18
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'frmFieldMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 492)
        Me.Controls.Add(Me.dgvFldMap)
        Me.Controls.Add(Me.pnlDetail)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFieldMapping"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Field Mapping"
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dgvFldMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents txtDisplayDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFldName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDisplayOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboFldType As System.Windows.Forms.ComboBox
    Friend WithEvents txtTemplateCode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents optFldActive As System.Windows.Forms.RadioButton
    Friend WithEvents optFldInactive As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgvFldMap As System.Windows.Forms.DataGridView
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents optDispYes As System.Windows.Forms.RadioButton
    Friend WithEvents optDispNo As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
End Class
