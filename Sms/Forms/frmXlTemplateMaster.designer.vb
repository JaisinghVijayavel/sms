<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXlTemplateMaster
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.optVariable = New System.Windows.Forms.RadioButton()
        Me.optSms = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.optTemplateActive = New System.Windows.Forms.RadioButton()
        Me.optTemplateInactive = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblClientName = New System.Windows.Forms.Label()
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
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.optMandatoryYes = New System.Windows.Forms.RadioButton()
        Me.optMandatoryNo = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnClr = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.optFldActive = New System.Windows.Forms.RadioButton()
        Me.optFldInactive = New System.Windows.Forms.RadioButton()
        Me.txtFldFormat = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFldLength = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboFldName = New System.Windows.Forms.ComboBox()
        Me.txtDefaultValue = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtXlColName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvFldMap = New System.Windows.Forms.DataGridView()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.pnlMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlSave.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.pnlDetail.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvFldMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.Panel2)
        Me.pnlMain.Controls.Add(Me.Panel1)
        Me.pnlMain.Controls.Add(Me.Label5)
        Me.pnlMain.Controls.Add(Me.txtName)
        Me.pnlMain.Controls.Add(Me.lblClientName)
        Me.pnlMain.Controls.Add(Me.txtId)
        Me.pnlMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlMain.Location = New System.Drawing.Point(6, 6)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(615, 70)
        Me.pnlMain.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(5, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Field Property"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.optVariable)
        Me.Panel2.Controls.Add(Me.optSms)
        Me.Panel2.Location = New System.Drawing.Point(116, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(207, 25)
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
        Me.optSms.Location = New System.Drawing.Point(80, 3)
        Me.optSms.Name = "optSms"
        Me.optSms.Size = New System.Drawing.Size(49, 17)
        Me.optSms.TabIndex = 1
        Me.optSms.Text = "Sms"
        Me.optSms.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optTemplateActive)
        Me.Panel1.Controls.Add(Me.optTemplateInactive)
        Me.Panel1.Location = New System.Drawing.Point(487, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(105, 25)
        Me.Panel1.TabIndex = 5
        '
        'optTemplateActive
        '
        Me.optTemplateActive.AutoSize = True
        Me.optTemplateActive.Checked = True
        Me.optTemplateActive.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optTemplateActive.Location = New System.Drawing.Point(3, 3)
        Me.optTemplateActive.Name = "optTemplateActive"
        Me.optTemplateActive.Size = New System.Drawing.Size(45, 17)
        Me.optTemplateActive.TabIndex = 0
        Me.optTemplateActive.TabStop = True
        Me.optTemplateActive.Text = "Yes"
        Me.optTemplateActive.UseVisualStyleBackColor = True
        '
        'optTemplateInactive
        '
        Me.optTemplateInactive.AutoSize = True
        Me.optTemplateInactive.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optTemplateInactive.Location = New System.Drawing.Point(53, 3)
        Me.optTemplateInactive.Name = "optTemplateInactive"
        Me.optTemplateInactive.Size = New System.Drawing.Size(39, 17)
        Me.optTemplateInactive.TabIndex = 1
        Me.optTemplateInactive.Text = "No"
        Me.optTemplateInactive.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(377, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Active Status"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(116, 9)
        Me.txtName.MaxLength = 128
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(484, 21)
        Me.txtName.TabIndex = 1
        '
        'lblClientName
        '
        Me.lblClientName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblClientName.Location = New System.Drawing.Point(5, 14)
        Me.lblClientName.Name = "lblClientName"
        Me.lblClientName.Size = New System.Drawing.Size(105, 16)
        Me.lblClientName.TabIndex = 0
        Me.lblClientName.Text = "XL Template Name"
        Me.lblClientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(3, 4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(26, 21)
        Me.txtId.TabIndex = 0
        Me.txtId.Visible = False
        '
        'pnlSave
        '
        Me.pnlSave.CausesValidation = False
        Me.pnlSave.Controls.Add(Me.btnCancel)
        Me.pnlSave.Controls.Add(Me.btnSave)
        Me.pnlSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSave.Location = New System.Drawing.Point(121, 491)
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
        Me.pnlButtons.Location = New System.Drawing.Point(4, 491)
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
        'pnlDetail
        '
        Me.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetail.Controls.Add(Me.Panel5)
        Me.pnlDetail.Controls.Add(Me.Label8)
        Me.pnlDetail.Controls.Add(Me.btnClr)
        Me.pnlDetail.Controls.Add(Me.btnRemove)
        Me.pnlDetail.Controls.Add(Me.btnAdd)
        Me.pnlDetail.Controls.Add(Me.Panel4)
        Me.pnlDetail.Controls.Add(Me.txtFldFormat)
        Me.pnlDetail.Controls.Add(Me.Label10)
        Me.pnlDetail.Controls.Add(Me.txtFldLength)
        Me.pnlDetail.Controls.Add(Me.Label9)
        Me.pnlDetail.Controls.Add(Me.cboFldName)
        Me.pnlDetail.Controls.Add(Me.txtDefaultValue)
        Me.pnlDetail.Controls.Add(Me.Label6)
        Me.pnlDetail.Controls.Add(Me.txtXlColName)
        Me.pnlDetail.Controls.Add(Me.txtSNo)
        Me.pnlDetail.Controls.Add(Me.Label3)
        Me.pnlDetail.Controls.Add(Me.Label11)
        Me.pnlDetail.Controls.Add(Me.Label7)
        Me.pnlDetail.Controls.Add(Me.Label4)
        Me.pnlDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlDetail.Location = New System.Drawing.Point(6, 100)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(615, 102)
        Me.pnlDetail.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.optMandatoryYes)
        Me.Panel5.Controls.Add(Me.optMandatoryNo)
        Me.Panel5.Location = New System.Drawing.Point(80, 61)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(105, 25)
        Me.Panel5.TabIndex = 13
        '
        'optMandatoryYes
        '
        Me.optMandatoryYes.AutoSize = True
        Me.optMandatoryYes.Checked = True
        Me.optMandatoryYes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optMandatoryYes.Location = New System.Drawing.Point(3, 3)
        Me.optMandatoryYes.Name = "optMandatoryYes"
        Me.optMandatoryYes.Size = New System.Drawing.Size(45, 17)
        Me.optMandatoryYes.TabIndex = 1
        Me.optMandatoryYes.TabStop = True
        Me.optMandatoryYes.Text = "Yes"
        Me.optMandatoryYes.UseVisualStyleBackColor = True
        '
        'optMandatoryNo
        '
        Me.optMandatoryNo.AutoSize = True
        Me.optMandatoryNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.optMandatoryNo.Location = New System.Drawing.Point(53, 3)
        Me.optMandatoryNo.Name = "optMandatoryNo"
        Me.optMandatoryNo.Size = New System.Drawing.Size(39, 17)
        Me.optMandatoryNo.TabIndex = 0
        Me.optMandatoryNo.Text = "No"
        Me.optMandatoryNo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(-30, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 15)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Mandatory"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClr
        '
        Me.btnClr.BackColor = System.Drawing.SystemColors.Control
        Me.btnClr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClr.Location = New System.Drawing.Point(537, 63)
        Me.btnClr.Name = "btnClr"
        Me.btnClr.Size = New System.Drawing.Size(62, 24)
        Me.btnClr.TabIndex = 18
        Me.btnClr.Text = "Clear"
        Me.btnClr.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.SystemColors.Control
        Me.btnRemove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRemove.Location = New System.Drawing.Point(471, 63)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(62, 24)
        Me.btnRemove.TabIndex = 17
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(404, 62)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(62, 24)
        Me.btnAdd.TabIndex = 16
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.optFldActive)
        Me.Panel4.Controls.Add(Me.optFldInactive)
        Me.Panel4.Location = New System.Drawing.Point(281, 62)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(105, 25)
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
        Me.optFldInactive.Location = New System.Drawing.Point(53, 3)
        Me.optFldInactive.Name = "optFldInactive"
        Me.optFldInactive.Size = New System.Drawing.Size(39, 17)
        Me.optFldInactive.TabIndex = 1
        Me.optFldInactive.Text = "No"
        Me.optFldInactive.UseVisualStyleBackColor = True
        '
        'txtFldFormat
        '
        Me.txtFldFormat.Location = New System.Drawing.Point(80, 35)
        Me.txtFldFormat.MaxLength = 32
        Me.txtFldFormat.Name = "txtFldFormat"
        Me.txtFldFormat.Size = New System.Drawing.Size(113, 21)
        Me.txtFldFormat.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(-3, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 16)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Field Format"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFldLength
        '
        Me.txtFldLength.Location = New System.Drawing.Point(281, 35)
        Me.txtFldLength.MaxLength = 6
        Me.txtFldLength.Name = "txtFldLength"
        Me.txtFldLength.Size = New System.Drawing.Size(113, 21)
        Me.txtFldLength.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(171, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Field Length"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFldName
        '
        Me.cboFldName.FormattingEnabled = True
        Me.cboFldName.Location = New System.Drawing.Point(487, 9)
        Me.cboFldName.Name = "cboFldName"
        Me.cboFldName.Size = New System.Drawing.Size(113, 21)
        Me.cboFldName.TabIndex = 5
        '
        'txtDefaultValue
        '
        Me.txtDefaultValue.Location = New System.Drawing.Point(487, 35)
        Me.txtDefaultValue.MaxLength = 255
        Me.txtDefaultValue.Name = "txtDefaultValue"
        Me.txtDefaultValue.Size = New System.Drawing.Size(113, 21)
        Me.txtDefaultValue.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(392, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Default Value"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXlColName
        '
        Me.txtXlColName.Location = New System.Drawing.Point(281, 9)
        Me.txtXlColName.MaxLength = 128
        Me.txtXlColName.Name = "txtXlColName"
        Me.txtXlColName.Size = New System.Drawing.Size(113, 21)
        Me.txtXlColName.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(183, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "XL Column Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSNo
        '
        Me.txtSNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtSNo.Location = New System.Drawing.Point(80, 9)
        Me.txtSNo.MaxLength = 128
        Me.txtSNo.Name = "txtSNo"
        Me.txtSNo.ReadOnly = True
        Me.txtSNo.Size = New System.Drawing.Size(113, 21)
        Me.txtSNo.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "SNo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(171, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 15)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Active Status"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(377, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Field Name"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(3, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "XL Field Mapping"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvFldMap
        '
        Me.dgvFldMap.AllowUserToAddRows = False
        Me.dgvFldMap.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvFldMap.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvFldMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFldMap.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvFldMap.Location = New System.Drawing.Point(37, 10)
        Me.dgvFldMap.Name = "dgvFldMap"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvFldMap.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvFldMap.Size = New System.Drawing.Size(285, 106)
        Me.dgvFldMap.TabIndex = 3
        '
        'pnlGrid
        '
        Me.pnlGrid.Controls.Add(Me.dgvFldMap)
        Me.pnlGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlGrid.Location = New System.Drawing.Point(6, 208)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(613, 277)
        Me.pnlGrid.TabIndex = 12
        '
        'frmXlTemplateMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 527)
        Me.Controls.Add(Me.pnlGrid)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pnlDetail)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlSave)
        Me.Controls.Add(Me.pnlButtons)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmXlTemplateMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "XL Template Master"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlSave.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dgvFldMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGrid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblClientName As System.Windows.Forms.Label
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
    Friend WithEvents optTemplateInactive As System.Windows.Forms.RadioButton
    Friend WithEvents optTemplateActive As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents optVariable As System.Windows.Forms.RadioButton
    Friend WithEvents optSms As System.Windows.Forms.RadioButton
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDefaultValue As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtXlColName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFldLength As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboFldName As System.Windows.Forms.ComboBox
    Friend WithEvents txtFldFormat As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents optFldActive As System.Windows.Forms.RadioButton
    Friend WithEvents optFldInactive As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClr As System.Windows.Forms.Button
    Friend WithEvents dgvFldMap As System.Windows.Forms.DataGridView
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents optMandatoryYes As System.Windows.Forms.RadioButton
    Friend WithEvents optMandatoryNo As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
End Class
