Option Explicit On
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient

Public Class frmUserMaster
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
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlSave As System.Windows.Forms.Panel
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPincode As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddr4 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddr3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddr2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddr1 As System.Windows.Forms.TextBox
    Friend WithEvents cboSex As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDob As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpDoj As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents txtDesig As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpDor As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkActivate As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtContactNo As System.Windows.Forms.TextBox
    Friend WithEvents txtUserStatus As System.Windows.Forms.TextBox
    Friend WithEvents cboUserGrp As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserMaster))
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlSave = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.cboUserGrp = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtUserStatus = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtContactNo = New System.Windows.Forms.TextBox()
        Me.chkActivate = New System.Windows.Forms.CheckBox()
        Me.dtpDor = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDept = New System.Windows.Forms.TextBox()
        Me.txtDesig = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpDoj = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpDob = New System.Windows.Forms.DateTimePicker()
        Me.cboSex = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPincode = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtAddr4 = New System.Windows.Forms.TextBox()
        Me.txtAddr3 = New System.Windows.Forms.TextBox()
        Me.txtAddr2 = New System.Windows.Forms.TextBox()
        Me.txtAddr1 = New System.Windows.Forms.TextBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.pnlSave.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
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
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(2, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pnlSave
        '
        Me.pnlSave.Controls.Add(Me.btnCancel)
        Me.pnlSave.Controls.Add(Me.btnSave)
        Me.pnlSave.Location = New System.Drawing.Point(144, 355)
        Me.pnlSave.Name = "pnlSave"
        Me.pnlSave.Size = New System.Drawing.Size(152, 28)
        Me.pnlSave.TabIndex = 33
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(80, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnFind)
        Me.pnlButtons.Controls.Add(Me.btnDelete)
        Me.pnlButtons.Controls.Add(Me.btnEdit)
        Me.pnlButtons.Controls.Add(Me.btnNew)
        Me.pnlButtons.Location = New System.Drawing.Point(24, 355)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(392, 28)
        Me.pnlButtons.TabIndex = 34
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
        Me.btnClose.UseVisualStyleBackColor = False
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
        Me.btnFind.UseVisualStyleBackColor = False
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
        Me.btnDelete.UseVisualStyleBackColor = False
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
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.cboUserGrp)
        Me.pnlMain.Controls.Add(Me.Label15)
        Me.pnlMain.Controls.Add(Me.txtUserStatus)
        Me.pnlMain.Controls.Add(Me.Label14)
        Me.pnlMain.Controls.Add(Me.txtContactNo)
        Me.pnlMain.Controls.Add(Me.chkActivate)
        Me.pnlMain.Controls.Add(Me.dtpDor)
        Me.pnlMain.Controls.Add(Me.Label12)
        Me.pnlMain.Controls.Add(Me.txtDept)
        Me.pnlMain.Controls.Add(Me.txtDesig)
        Me.pnlMain.Controls.Add(Me.Label10)
        Me.pnlMain.Controls.Add(Me.dtpDoj)
        Me.pnlMain.Controls.Add(Me.Label7)
        Me.pnlMain.Controls.Add(Me.dtpDob)
        Me.pnlMain.Controls.Add(Me.cboSex)
        Me.pnlMain.Controls.Add(Me.Label9)
        Me.pnlMain.Controls.Add(Me.Label8)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Controls.Add(Me.Label6)
        Me.pnlMain.Controls.Add(Me.Label4)
        Me.pnlMain.Controls.Add(Me.Label5)
        Me.pnlMain.Controls.Add(Me.txtPincode)
        Me.pnlMain.Controls.Add(Me.txtCity)
        Me.pnlMain.Controls.Add(Me.txtAddr4)
        Me.pnlMain.Controls.Add(Me.txtAddr3)
        Me.pnlMain.Controls.Add(Me.txtAddr2)
        Me.pnlMain.Controls.Add(Me.txtAddr1)
        Me.pnlMain.Controls.Add(Me.txtCode)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.txtName)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.lblName)
        Me.pnlMain.Controls.Add(Me.Label11)
        Me.pnlMain.Controls.Add(Me.Label13)
        Me.pnlMain.Location = New System.Drawing.Point(8, 8)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(424, 341)
        Me.pnlMain.TabIndex = 1
        '
        'cboUserGrp
        '
        Me.cboUserGrp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboUserGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUserGrp.FormattingEnabled = True
        Me.cboUserGrp.Location = New System.Drawing.Point(81, 281)
        Me.cboUserGrp.Name = "cboUserGrp"
        Me.cboUserGrp.Size = New System.Drawing.Size(113, 21)
        Me.cboUserGrp.TabIndex = 27
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(-1, 285)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 13)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "User Group"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUserStatus
        '
        Me.txtUserStatus.Location = New System.Drawing.Point(9, 122)
        Me.txtUserStatus.Name = "txtUserStatus"
        Me.txtUserStatus.Size = New System.Drawing.Size(22, 21)
        Me.txtUserStatus.TabIndex = 31
        Me.txtUserStatus.Visible = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(2, 203)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label14.Size = New System.Drawing.Size(75, 16)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Contact No"
        '
        'txtContactNo
        '
        Me.txtContactNo.Location = New System.Drawing.Point(81, 200)
        Me.txtContactNo.MaxLength = 64
        Me.txtContactNo.Name = "txtContactNo"
        Me.txtContactNo.Size = New System.Drawing.Size(328, 21)
        Me.txtContactNo.TabIndex = 19
        '
        'chkActivate
        '
        Me.chkActivate.AutoSize = True
        Me.chkActivate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkActivate.Location = New System.Drawing.Point(81, 312)
        Me.chkActivate.Name = "chkActivate"
        Me.chkActivate.Size = New System.Drawing.Size(103, 17)
        Me.chkActivate.TabIndex = 30
        Me.chkActivate.Text = "Activate User"
        Me.chkActivate.UseVisualStyleBackColor = True
        '
        'dtpDor
        '
        Me.dtpDor.Checked = False
        Me.dtpDor.CustomFormat = "dd-MM-yyyy"
        Me.dtpDor.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDor.Location = New System.Drawing.Point(296, 281)
        Me.dtpDor.Name = "dtpDor"
        Me.dtpDor.ShowCheckBox = True
        Me.dtpDor.Size = New System.Drawing.Size(113, 21)
        Me.dtpDor.TabIndex = 29
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(2, 257)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label12.Size = New System.Drawing.Size(75, 16)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Designation"
        '
        'txtDept
        '
        Me.txtDept.Location = New System.Drawing.Point(296, 254)
        Me.txtDept.MaxLength = 6
        Me.txtDept.Name = "txtDept"
        Me.txtDept.Size = New System.Drawing.Size(113, 21)
        Me.txtDept.TabIndex = 26
        '
        'txtDesig
        '
        Me.txtDesig.Location = New System.Drawing.Point(81, 254)
        Me.txtDesig.MaxLength = 64
        Me.txtDesig.Name = "txtDesig"
        Me.txtDesig.Size = New System.Drawing.Size(113, 21)
        Me.txtDesig.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(215, 231)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label10.Size = New System.Drawing.Size(75, 16)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Date of Join"
        '
        'dtpDoj
        '
        Me.dtpDoj.CustomFormat = "dd-MM-yyyy"
        Me.dtpDoj.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDoj.Location = New System.Drawing.Point(296, 227)
        Me.dtpDoj.Name = "dtpDoj"
        Me.dtpDoj.Size = New System.Drawing.Size(113, 21)
        Me.dtpDoj.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(-7, 231)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label7.Size = New System.Drawing.Size(84, 16)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Date of Birth"
        '
        'dtpDob
        '
        Me.dtpDob.CustomFormat = "dd-MM-yyyy"
        Me.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDob.Location = New System.Drawing.Point(81, 227)
        Me.dtpDob.Name = "dtpDob"
        Me.dtpDob.Size = New System.Drawing.Size(113, 21)
        Me.dtpDob.TabIndex = 21
        '
        'cboSex
        '
        Me.cboSex.FormattingEnabled = True
        Me.cboSex.Location = New System.Drawing.Point(296, 11)
        Me.cboSex.Name = "cboSex"
        Me.cboSex.Size = New System.Drawing.Size(113, 21)
        Me.cboSex.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(227, 176)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label9.Size = New System.Drawing.Size(63, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Pincode"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(14, 176)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label8.Size = New System.Drawing.Size(63, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "City"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Address4"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(14, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(63, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Address3"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(2, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(75, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Address2"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(-10, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(87, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Address1"
        '
        'txtPincode
        '
        Me.txtPincode.Location = New System.Drawing.Point(296, 173)
        Me.txtPincode.MaxLength = 6
        Me.txtPincode.Name = "txtPincode"
        Me.txtPincode.Size = New System.Drawing.Size(113, 21)
        Me.txtPincode.TabIndex = 17
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(81, 173)
        Me.txtCity.MaxLength = 64
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(113, 21)
        Me.txtCity.TabIndex = 15
        '
        'txtAddr4
        '
        Me.txtAddr4.Location = New System.Drawing.Point(81, 146)
        Me.txtAddr4.MaxLength = 64
        Me.txtAddr4.Name = "txtAddr4"
        Me.txtAddr4.Size = New System.Drawing.Size(328, 21)
        Me.txtAddr4.TabIndex = 13
        '
        'txtAddr3
        '
        Me.txtAddr3.Location = New System.Drawing.Point(81, 119)
        Me.txtAddr3.MaxLength = 64
        Me.txtAddr3.Name = "txtAddr3"
        Me.txtAddr3.Size = New System.Drawing.Size(328, 21)
        Me.txtAddr3.TabIndex = 11
        '
        'txtAddr2
        '
        Me.txtAddr2.Location = New System.Drawing.Point(81, 92)
        Me.txtAddr2.MaxLength = 64
        Me.txtAddr2.Name = "txtAddr2"
        Me.txtAddr2.Size = New System.Drawing.Size(328, 21)
        Me.txtAddr2.TabIndex = 9
        '
        'txtAddr1
        '
        Me.txtAddr1.Location = New System.Drawing.Point(81, 65)
        Me.txtAddr1.MaxLength = 64
        Me.txtAddr1.Name = "txtAddr1"
        Me.txtAddr1.Size = New System.Drawing.Size(328, 21)
        Me.txtAddr1.TabIndex = 7
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(81, 11)
        Me.txtCode.MaxLength = 8
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(113, 21)
        Me.txtCode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(219, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Gender"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(81, 38)
        Me.txtName.MaxLength = 64
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(328, 21)
        Me.txtName.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(-10, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Emp Code"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblName
        '
        Me.lblName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblName.Location = New System.Drawing.Point(-7, 41)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(84, 13)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "User Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(208, 257)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label11.Size = New System.Drawing.Size(82, 16)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Department"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(187, 285)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label13.Size = New System.Drawing.Size(103, 16)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Date of Resign"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(-11, -3)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(24, 21)
        Me.txtId.TabIndex = 60
        Me.txtId.Visible = False
        '
        'frmUserMaster
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(440, 389)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlSave)
        Me.Controls.Add(Me.pnlButtons)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Master"
        Me.pnlSave.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
#Region "Local Declaration"
    Dim objDataReader As OdbcDataReader
    Dim msSql As String
    Dim mnResult As Integer
#End Region
    Private Sub EnableSave(ByVal Status As Boolean)
        pnlButtons.Visible = Not Status
        pnlSave.Visible = Status
        pnlMain.Enabled = Status
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        EnableSave(True)
        Call ClearAll()
        txtUserStatus.Text = "Y"
        txtCode.Focus()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lsSql As String = ""
        Dim ds As New DataSet
        Dim lsDor As String
        Dim lnUserId As Long = 0
        Dim lnUserGrpId As Long
        Dim lsUserStatus As String = "Y"
        Dim lbPwdRmvFlag As Boolean = False

        Dim lsAuthDesc As String = ""
        Dim lsAuthDtl As String = ""
        Dim lsAuthQry As String = ""
        Dim lsRejectQry As String = ""
        Dim lnResult As Long = 0
        Dim lsMsg As String = ""

        Try
            Call gpTrimAll(Me)

            Select Case ""
                Case txtCode.Text
                    MsgBox("User code cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                    txtCode.Focus()
                    Exit Sub
                Case cboSex.Text
                    MsgBox("Gender cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                    cboSex.Focus()
                    Exit Sub
                Case txtName.Text
                    MsgBox("user name cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                    txtName.Focus()
                    Exit Sub
                Case txtAddr1.Text
                    MsgBox("Address cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                    txtAddr1.Focus()
                    Exit Sub
                Case txtCity.Text
                    MsgBox("City name cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                    txtCity.Focus()
                    Exit Sub
                Case txtDesig.Text
                    MsgBox("Designation cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                    txtDesig.Focus()
                    Exit Sub
                Case txtDept.Text
                    MsgBox("Department name cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                    txtDept.Focus()
                    Exit Sub
            End Select

            Call gpAutoFindCombo(cboSex)

            If cboSex.SelectedIndex = -1 Then
                MsgBox("Please select valid gender !", MsgBoxStyle.Critical, gsProjectName)
                cboSex.Focus()
                Exit Sub
            End If

            If DateDiff(DateInterval.Day, CDate(dtpDob.Value), CDate(Format(Now, "yyyy-MM-dd"))) < 0 Then
                MsgBox("Invalid date of birth !", MsgBoxStyle.Critical, gsProjectName)
                dtpDob.Focus()
                Exit Sub
            End If

            If DateDiff(DateInterval.Day, CDate(dtpDoj.Value), CDate(Format(Now, "yyyy-MM-dd"))) < 0 Then
                MsgBox("Invalid date of join !", MsgBoxStyle.Critical, gsProjectName)
                dtpDob.Focus()
                Exit Sub
            End If

            If DateDiff(DateInterval.Day, CDate(dtpDob.Value), CDate(dtpDoj.Value)) < 0 Then
                MsgBox("Invalid date of join !", MsgBoxStyle.Critical, gsProjectName)
                dtpDob.Focus()
                Exit Sub
            End If

            If cboUserGrp.SelectedIndex = -1 Then
                MsgBox("Please select the user group !", MsgBoxStyle.Information, gsProjectName)
                cboUserGrp.Focus()
                Exit Sub
            Else
                lnUserGrpId = Val(cboUserGrp.SelectedValue)
            End If

            If dtpDor.Checked = True Then
                If DateDiff(DateInterval.Day, CDate(dtpDor.Value), CDate(Format(Now, "yyyy-MM-dd"))) < 0 Then
                    MsgBox("Invalid date of resign !", MsgBoxStyle.Critical, gsProjectName)
                    dtpDob.Focus()
                    Exit Sub
                End If

                If DateDiff(DateInterval.Day, CDate(dtpDoj.Value), CDate(dtpDor.Value)) < 0 Then
                    MsgBox("Invalid date of resign !", MsgBoxStyle.Critical, gsProjectName)
                    dtpDob.Focus()
                    Exit Sub
                End If

                lsDor = "'" & Format(CDate(dtpDor.Value), "yyyy-MM-dd") & "'"
                lsUserStatus = "D"
            Else
                lsDor = "null"

                If txtUserStatus.Text <> "Y" Then
                    If chkActivate.Checked = True Then
                        If Val(txtId.Text) > 0 Then
                            If MsgBox("Are you sure to remove old password !", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
                                lbPwdRmvFlag = True
                            End If

                            lsUserStatus = "Y"
                        End If
                    Else
                        lsUserStatus = "N"
                    End If
                Else
                    If chkActivate.Checked = True Then
                        lsUserStatus = txtUserStatus.Text
                    Else
                        lsUserStatus = "N"
                    End If
                End If
            End If

            lsAuthDtl = ""
            lsAuthDtl &= "User Code   : " & txtCode.Text & Chr(13) & Chr(10)
            lsAuthDtl &= "User Name   : " & txtName.Text & Chr(13) & Chr(10)
            lsAuthDtl &= "Address1    : " & txtAddr1.Text & Chr(13) & Chr(10)
            lsAuthDtl &= "Address2    : " & txtAddr2.Text & Chr(13) & Chr(10)
            lsAuthDtl &= "Address3    : " & txtAddr3.Text & Chr(13) & Chr(10)
            lsAuthDtl &= "Address4    : " & txtAddr4.Text & Chr(13) & Chr(10)
            lsAuthDtl &= "City        : " & txtCity.Text & Chr(13) & Chr(10)
            lsAuthDtl &= "Pincode     : " & txtPincode.Text & Chr(13) & Chr(10)
            lsAuthDtl &= "Contact No  : " & txtContactNo.Text & Chr(13) & Chr(10)
            lsAuthDtl &= "Gender      : " & cboSex.Text & Chr(13) & Chr(10)
            lsAuthDtl &= "DOB         : " & Format(dtpDob.Value, "dd-MM-yyyy") & Chr(13) & Chr(10)
            lsAuthDtl &= "DOJ         : " & Format(dtpDoj.Value, "dd-MM-yyyy") & Chr(13) & Chr(10)
            lsAuthDtl &= "Desig       : " & txtDesig.Text & Chr(13) & Chr(10)
            lsAuthDtl &= "Dept Name   : " & txtDept.Text & Chr(13) & Chr(10)
            lsAuthDtl &= "User Group  : " & cboUserGrp.Text & Chr(13) & Chr(10)
            lsAuthDtl &= "User Status : " & lsUserStatus & Chr(13) & Chr(10)
            lsAuthDtl &= "DOR         : " & IIf(lsDor = "null", "", Format(dtpDor.Value, "dd-MM-yyyy")) & Chr(13) & Chr(10)

            If Val(txtId.Text) = 0 Then
                lsAuthDesc = "New User"
            Else
                lsAuthDesc = "Edit User"
            End If

            Using cmd As New MySqlCommand("pr_ins_user", gOdbcConn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("?in_user_gid", Val(txtId.Text))
                cmd.Parameters.AddWithValue("?in_user_code", txtCode.Text.Trim)
                cmd.Parameters.AddWithValue("?in_user_name", txtName.Text.Trim)
                cmd.Parameters.AddWithValue("?in_addr1", txtAddr1.Text.Trim)
                cmd.Parameters.AddWithValue("?in_addr2", txtAddr2.Text.Trim)
                cmd.Parameters.AddWithValue("?in_addr3", txtAddr3.Text.Trim)
                cmd.Parameters.AddWithValue("?in_addr4", txtAddr4.Text.Trim)
                cmd.Parameters.AddWithValue("?in_city", txtCity.Text.Trim)
                cmd.Parameters.AddWithValue("?in_pincode", txtPincode.Text.Trim)
                cmd.Parameters.AddWithValue("?in_contact_no", txtContactNo.Text.Trim)
                cmd.Parameters.AddWithValue("?in_sex", cboSex.Text.Trim)
                cmd.Parameters.AddWithValue("?in_dob", dtpDob.Value)
                cmd.Parameters.AddWithValue("?in_doj", dtpDoj.Value)

                If dtpDor.Checked Then
                    cmd.Parameters.AddWithValue("?in_dor", dtpDor.Value)
                Else
                    cmd.Parameters.AddWithValue("?in_dor", "0000-00-00")
                End If

                cmd.Parameters.AddWithValue("?in_desig_name", txtDesig.Text.Trim)
                cmd.Parameters.AddWithValue("?in_dept_name", txtDept.Text.Trim)
                cmd.Parameters.AddWithValue("?in_user_status", lsUserStatus)
                cmd.Parameters.AddWithValue("?in_pwd_flag", lbPwdRmvFlag)
                cmd.Parameters.AddWithValue("?in_usergroup_gid", lnUserGrpId)
                cmd.Parameters.AddWithValue("?in_auth_desc", lsAuthDesc)
                cmd.Parameters.AddWithValue("?in_auth_dtl", lsAuthDtl)
                If Val(txtId.Text) = 0 Then
                    cmd.Parameters.AddWithValue("?in_action", "INSERT")
                Else
                    cmd.Parameters.AddWithValue("?in_action", "UPDATE")
                End If

                cmd.Parameters.AddWithValue("?in_action_by", gsLoginUserCode)

                'output Para
                cmd.Parameters.Add("?out_result", MySqlDbType.Int32)
                cmd.Parameters("?out_result").Direction = ParameterDirection.Output
                cmd.Parameters.Add("?out_msg", MySqlDbType.VarChar)
                cmd.Parameters("?out_msg").Direction = ParameterDirection.Output

                cmd.ExecuteNonQuery()

                lnResult = Val(cmd.Parameters("?out_result").Value.ToString())
                lsMsg = cmd.Parameters("?out_msg").Value.ToString()

                If lnResult = 1 Then
                    Call MsgBox(lsMsg, MsgBoxStyle.Information, gsProjectName)

                    Call ClearAll()
                    EnableSave(False)
                    btnNew.Focus()
                Else
                    Call MsgBox(lsMsg, MsgBoxStyle.Critical, gsProjectName)
                End If
            End Using

            'lsSql = ""
            'msSql = ""

            'If txtId.Text = "" Then
            '    lsSql = ""
            '    lsSql &= " select user_gid from soft_mst_tuser "
            '    lsSql &= " where user_code = '" & txtCode.Text & "' "
            '    lsSql &= " and delete_flag = 'N'"

            '    msSql = ""
            '    msSql &= " insert into soft_mst_tuser (user_code,user_name,addr1,addr2,addr3,addr4,"
            '    msSql &= " city,pincode,contact_no,sex,dob,doj,dor,desig_name,dept_name,user_status,pwd,usergroup_gid) values ("
            '    msSql &= " '" & QuoteFilter(txtCode.Text) & "',"
            '    msSql &= " '" & QuoteFilter(txtName.Text) & "',"
            '    msSql &= " '" & QuoteFilter(txtAddr1.Text) & "',"
            '    msSql &= " '" & QuoteFilter(txtAddr2.Text) & "',"
            '    msSql &= " '" & QuoteFilter(txtAddr3.Text) & "',"
            '    msSql &= " '" & QuoteFilter(txtAddr4.Text) & "',"
            '    msSql &= " '" & QuoteFilter(txtCity.Text) & "',"
            '    msSql &= " '" & QuoteFilter(txtPincode.Text) & "',"
            '    msSql &= " '" & QuoteFilter(txtContactNo.Text) & "',"
            '    msSql &= " '" & cboSex.Text & "',"
            '    msSql &= " '" & Format(CDate(dtpDob.Value), "yyyy-MM-dd") & "',"
            '    msSql &= " '" & Format(CDate(dtpDoj.Value), "yyyy-MM-dd") & "',"
            '    msSql &= " " & lsDor & ","
            '    msSql &= " '" & QuoteFilter(txtDesig.Text) & "',"
            '    msSql &= " '" & QuoteFilter(txtDept.Text) & "',"
            '    msSql &= " '" & lsUserStatus & "','',"
            '    msSql &= " " & lnUserGrpId & ")"

            '    lsAuthDesc = "New User"
            'Else
            '    lsSql = ""
            '    lsSql &= " select user_gid from soft_mst_tuser "
            '    lsSql &= " where user_code = '" & txtCode.Text & "' "
            '    lsSql &= " and user_gid <> '" & txtId.Text & "' "
            '    lsSql &= " and delete_flag = 'N'"

            '    msSql = ""
            '    msSql &= " update soft_mst_tuser set "
            '    msSql &= " user_code = '" & QuoteFilter(txtCode.Text) & "',"
            '    msSql &= " user_name = '" & QuoteFilter(txtName.Text) & "',"
            '    msSql &= " addr1 = '" & QuoteFilter(txtAddr1.Text) & "',"
            '    msSql &= " addr2 = '" & QuoteFilter(txtAddr2.Text) & "',"
            '    msSql &= " addr3 = '" & QuoteFilter(txtAddr3.Text) & "',"
            '    msSql &= " addr4 = '" & QuoteFilter(txtAddr4.Text) & "',"
            '    msSql &= " city = '" & QuoteFilter(txtCity.Text) & "',"
            '    msSql &= " pincode = '" & QuoteFilter(txtPincode.Text) & "',"
            '    msSql &= " contact_no = '" & QuoteFilter(txtContactNo.Text) & "',"
            '    msSql &= " login_date = sysdate(),"
            '    msSql &= " sex = '" & cboSex.Text & "',"
            '    msSql &= " dob = '" & Format(CDate(dtpDob.Value), "yyyy-MM-dd") & "',"
            '    msSql &= " doj = '" & Format(CDate(dtpDoj.Value), "yyyy-MM-dd") & "',"
            '    msSql &= " dor = " & lsDor & ","
            '    msSql &= " desig_name = '" & QuoteFilter(txtDesig.Text) & "',"
            '    msSql &= " dept_name = '" & QuoteFilter(txtDept.Text) & "',"

            '    If lbPwdRmvFlag = True Then msSql &= " pwd = '',"

            '    msSql &= " usergroup_gid = " & lnUserGrpId & ","
            '    msSql &= " user_status = '" & lsUserStatus & "' "
            '    msSql &= " where user_gid = '" & txtId.Text & "' "
            '    msSql &= " and delete_flag = 'N'"

            '    lsAuthQry = msSql

            '    lsAuthDesc = "Edit User"
            'End If

            'lsAuthDtl = ""
            'lsAuthDtl &= "User Code   : " & txtCode.Text & Chr(13) & Chr(10)
            'lsAuthDtl &= "User Name   : " & txtName.Text & Chr(13) & Chr(10)
            'lsAuthDtl &= "Address1    : " & txtAddr1.Text & Chr(13) & Chr(10)
            'lsAuthDtl &= "Address2    : " & txtAddr2.Text & Chr(13) & Chr(10)
            'lsAuthDtl &= "Address3    : " & txtAddr3.Text & Chr(13) & Chr(10)
            'lsAuthDtl &= "Address4    : " & txtAddr4.Text & Chr(13) & Chr(10)
            'lsAuthDtl &= "City        : " & txtCity.Text & Chr(13) & Chr(10)
            'lsAuthDtl &= "Pincode     : " & txtPincode.Text & Chr(13) & Chr(10)
            'lsAuthDtl &= "Contact No  : " & txtContactNo.Text & Chr(13) & Chr(10)
            'lsAuthDtl &= "Gender      : " & cboSex.Text & Chr(13) & Chr(10)
            'lsAuthDtl &= "DOB         : " & Format(dtpDob.Value, "dd-MM-yyyy") & Chr(13) & Chr(10)
            'lsAuthDtl &= "DOJ         : " & Format(dtpDoj.Value, "dd-MM-yyyy") & Chr(13) & Chr(10)
            'lsAuthDtl &= "Desig       : " & txtDesig.Text & Chr(13) & Chr(10)
            'lsAuthDtl &= "Dept Name   : " & txtDept.Text & Chr(13) & Chr(10)
            'lsAuthDtl &= "User Group  : " & cboUserGrp.Text & Chr(13) & Chr(10)
            'lsAuthDtl &= "User Status : " & lsUserStatus & Chr(13) & Chr(10)
            'lsAuthDtl &= "DOR         : " & IIf(lsDor = "null", "", Format(dtpDor.Value, "dd-MM-yyyy")) & Chr(13) & Chr(10)

            '' Duplicate Checking
            'ds = gfDataSet(lsSql, "duplicate", gOdbcConn)

            'If ds.Tables("duplicate").Rows.Count = 0 Then
            '    If txtId.Text = "" Then
            '        mnResult = gfInsertQry(msSql, gOdbcConn)

            '        lsSql = ""
            '        lsSql &= " select user_gid from soft_mst_tuser "
            '        lsSql &= " where user_code = '" & txtCode.Text & "' "
            '        lsSql &= " and delete_flag = 'N'"

            '        lnUserId = Val(gfExecuteScalar(lsSql, gOdbcConn))

            '        lsAuthQry = ""
            '        lsAuthQry &= " update soft_mst_tuser set auth_flag = 'Y' "
            '        lsAuthQry &= " where user_gid = '" & lnUserId & "' "
            '        lsAuthQry &= " and delete_flag = 'N' "

            '        lsRejectQry = ""
            '        lsRejectQry &= " update soft_mst_tuser set auth_flag = 'R',delete_flag = 'Y' "
            '        lsRejectQry &= " where user_gid = '" & lnUserId & "' "
            '        lsRejectQry &= " and delete_flag = 'N' "
            '    End If

            '    ' Auth Qry
            '    lsSql = ""
            '    lsSql &= " insert into soft_trn_tauth"
            '    lsSql &= " (entry_date,entry_by,qry_desc,"
            '    lsSql &= " qry_detail,auth_qry,reject_qry)"
            '    lsSql &= " values ("
            '    lsSql &= " sysdate(),"
            '    lsSql &= " '" & QuoteFilter(gsLoginUserCode) & "',"
            '    lsSql &= " '" & lsAuthDesc & "',"
            '    lsSql &= " '" & QuoteFilter(lsAuthDtl) & "',"
            '    lsSql &= " " & Chr(34) & lsAuthQry & Chr(34) & ","
            '    lsSql &= " " & Chr(34) & lsRejectQry & Chr(34) & ")"

            '    mnResult = gfInsertQry(lsSql, gOdbcConn)

            '    Call MsgBox("Updated User Information Send for Approval...", MsgBoxStyle.Information, gsProjectName)

            '    Call ClearAll()
            '    EnableSave(False)
            '    btnNew.Focus()
            'Else
            '    MsgBox("Duplicate record !", MsgBoxStyle.Critical, gsProjectName)
            '    txtName.Focus()
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            If txtId.Text = "" Then
                If MsgBox("Select Record to edit", MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                    'Calling Find Button to select record
                    Call btnFind_Click(sender, e)
                    EnableSave(False)
                End If
            Else
                EnableSave(True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim SearchDialog As frmSearch

        Try
            SearchDialog = New frmSearch(gOdbcConn, _
                             " SELECT user_gid as 'User Id'," & _
                             " user_code as 'User Code',user_name as 'User Name' FROM soft_mst_tuser ", _
                             " user_gid,user_code,user_name", _
                             " 1 = 1 and delete_flag = 'N'")

            SearchDialog.ShowDialog()

            If gnSearchId <> 0 Then
                Call ListAll("select * from soft_mst_tuser " _
                    & " where user_gid = " & gnSearchId & " " _
                    & " and delete_flag = 'N'", gOdbcConn)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListAll(ByVal SqlStr As String, ByVal odbcConn As MySql.Data.MySqlClient.MySqlConnection)
        Dim ds As New DataSet

        Try
            ds = gfDataSet(SqlStr, "list_all", gOdbcConn)

            With ds.Tables("list_all")
                If .Rows.Count > 0 Then
                    txtId.Text = .Rows(0).Item("user_gid").ToString
                    txtName.Text = .Rows(0).Item("user_name").ToString
                    txtCode.Text = .Rows(0).Item("user_code").ToString
                    cboSex.Text = .Rows(0).Item("sex").ToString
                    txtAddr1.Text = .Rows(0).Item("addr1").ToString
                    txtAddr2.Text = .Rows(0).Item("addr2").ToString
                    txtAddr3.Text = .Rows(0).Item("addr3").ToString
                    txtAddr4.Text = .Rows(0).Item("addr4").ToString
                    txtCity.Text = .Rows(0).Item("city").ToString
                    txtPincode.Text = .Rows(0).Item("pincode").ToString
                    txtContactNo.Text = .Rows(0).Item("contact_no").ToString
                    txtDept.Text = .Rows(0).Item("dept_name").ToString
                    txtDesig.Text = .Rows(0).Item("desig_name").ToString
                    txtUserStatus.Text = .Rows(0).Item("user_status").ToString
                    dtpDob.Value = .Rows(0).Item("dob")
                    dtpDoj.Value = .Rows(0).Item("doj")

                    cboUserGrp.SelectedValue = .Rows(0).Item("usergroup_gid")

                    If IsDBNull(.Rows(0).Item("dor")) = True Then
                        dtpDor.Checked = False
                    Else
                        dtpDor.Checked = True
                        dtpDor.Value = .Rows(0).Item("dor")
                    End If

                    Select Case txtUserStatus.Text
                        Case "Y"
                            chkActivate.Checked = True
                        Case Else
                            chkActivate.Checked = False
                    End Select
                Else
                    ClearAll()
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim lsSql As String
        Dim lsAuthDesc As String = "Delete User"
        Dim lsAuthDtl As String = ""
        Dim lsAuthQry As String = ""
        Dim lsRejectQry As String = ""

        Try
            If txtId.Text = "" Then
                If MsgBox("Select record to delete?", MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                    'Calling Find Button to select record
                    Call btnFind_Click(sender, e)
                End If
            Else
                If MsgBox("Are you sure to delete this record?", MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                    lsAuthQry = " update soft_mst_tuser set delete_flag='Y' " & _
                             " where user_gid = '" & txtId.Text & "' and delete_flag = 'N'"

                    lsAuthDtl = ""
                    lsAuthDtl &= "User Code   : " & txtCode.Text & Chr(13) & Chr(10)
                    lsAuthDtl &= "User Name   : " & txtName.Text & Chr(13) & Chr(10)
                    lsAuthDtl &= "Address1    : " & txtAddr1.Text & Chr(13) & Chr(10)
                    lsAuthDtl &= "Address2    : " & txtAddr2.Text & Chr(13) & Chr(10)
                    lsAuthDtl &= "Address3    : " & txtAddr3.Text & Chr(13) & Chr(10)
                    lsAuthDtl &= "Address4    : " & txtAddr4.Text & Chr(13) & Chr(10)
                    lsAuthDtl &= "City        : " & txtCity.Text & Chr(13) & Chr(10)
                    lsAuthDtl &= "Pincode     : " & txtPincode.Text & Chr(13) & Chr(10)
                    lsAuthDtl &= "Contact No  : " & txtContactNo.Text & Chr(13) & Chr(10)
                    lsAuthDtl &= "Gender      : " & cboSex.Text & Chr(13) & Chr(10)
                    lsAuthDtl &= "DOB         : " & Format(dtpDob.Value, "dd-MM-yyyy") & Chr(13) & Chr(10)
                    lsAuthDtl &= "DOJ         : " & Format(dtpDoj.Value, "dd-MM-yyyy") & Chr(13) & Chr(10)
                    lsAuthDtl &= "Desig       : " & txtDesig.Text & Chr(13) & Chr(10)
                    lsAuthDtl &= "Dept Name   : " & txtDept.Text & Chr(13) & Chr(10)
                    lsAuthDtl &= "User Group  : " & cboUserGrp.Text & Chr(13) & Chr(10)
                    lsAuthDtl &= "User Status : " & txtUserStatus.Text & Chr(13) & Chr(10)

                    ' Auth Qry
                    lsSql = ""
                    lsSql &= " insert into soft_trn_tauth"
                    lsSql &= " (entry_date,entry_by,qry_desc,"
                    lsSql &= " qry_detail,auth_qry,reject_qry)"
                    lsSql &= " values ("
                    lsSql &= " sysdate(),"
                    lsSql &= " '" & QuoteFilter(gsLoginUserCode) & "',"
                    lsSql &= " '" & lsAuthDesc & "',"
                    lsSql &= " '" & QuoteFilter(lsAuthDtl) & "',"
                    lsSql &= " " & Chr(34) & lsAuthQry & Chr(34) & ","
                    lsSql &= " " & Chr(34) & lsRejectQry & Chr(34) & ")"

                    mnResult = gfInsertQry(lsSql, gOdbcConn)

                    Call MsgBox("Record Deletion Send for Approval...", MsgBoxStyle.Information, gsProjectName)

                    ClearAll()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        EnableSave(False)
        ClearAll()
        btnNew.Focus()
    End Sub

    Private Sub frmAccMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{Tab}")
    End Sub

    Private Sub frmUserMaster_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub frmUserMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lsSql As String

        KeyPreview = True

        With cboSex
            .Items.Clear()
            .Items.Add("MALE")
            .Items.Add("FEMALE")
        End With

        lsSql = ""
        lsSql &= " select * from soft_mst_tusergroup "
        lsSql &= " where delete_flag = 'N' "
        lsSql &= " order by usergroup_name asc "

        Call gpBindCombo(lsSql, "usergroup_name", "usergroup_gid", cboUserGrp, gOdbcConn)


        Call EnableSave(False)
        btnNew.Focus()
    End Sub

    Private Sub ClearAll()
        Call frmCtrClear(Me)
    End Sub

    Private Sub cboSex_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSex.TextChanged
        If cboSex.Text <> "" And cboSex.SelectedIndex = -1 Then gpAutoFillCombo(cboSex)
    End Sub
End Class
