<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserSetPwd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserSetPwd))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.txtNewPwd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRetypePwd = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUserCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(206, 93)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 24)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(121, 93)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(78, 24)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'txtNewPwd
        '
        Me.txtNewPwd.Location = New System.Drawing.Point(119, 39)
        Me.txtNewPwd.MaxLength = 8
        Me.txtNewPwd.Name = "txtNewPwd"
        Me.txtNewPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPwd.Size = New System.Drawing.Size(165, 21)
        Me.txtNewPwd.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "New Password"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRetypePwd
        '
        Me.txtRetypePwd.Location = New System.Drawing.Point(119, 66)
        Me.txtRetypePwd.MaxLength = 8
        Me.txtRetypePwd.Name = "txtRetypePwd"
        Me.txtRetypePwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRetypePwd.Size = New System.Drawing.Size(165, 21)
        Me.txtRetypePwd.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Retype Password"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUserCode
        '
        Me.txtUserCode.Location = New System.Drawing.Point(119, 12)
        Me.txtUserCode.MaxLength = 8
        Me.txtUserCode.Name = "txtUserCode"
        Me.txtUserCode.ReadOnly = True
        Me.txtUserCode.Size = New System.Drawing.Size(165, 21)
        Me.txtUserCode.TabIndex = 1
        Me.txtUserCode.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Emp Code"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmUserSetPwd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(299, 124)
        Me.Controls.Add(Me.txtUserCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRetypePwd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNewPwd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserSetPwd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents txtNewPwd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRetypePwd As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUserCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
