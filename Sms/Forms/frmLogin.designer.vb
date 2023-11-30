<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.lblName = New System.Windows.Forms.Label
        Me.txtUserCode = New System.Windows.Forms.TextBox
        Me.txtPwd = New System.Windows.Forms.TextBox
        Me.lblPwd = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(15, 15)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(62, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Emp Code"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUserCode
        '
        Me.txtUserCode.Location = New System.Drawing.Point(84, 12)
        Me.txtUserCode.MaxLength = 8
        Me.txtUserCode.Name = "txtUserCode"
        Me.txtUserCode.Size = New System.Drawing.Size(165, 21)
        Me.txtUserCode.TabIndex = 1
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(84, 39)
        Me.txtPwd.MaxLength = 8
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(165, 21)
        Me.txtPwd.TabIndex = 3
        '
        'lblPwd
        '
        Me.lblPwd.AutoSize = True
        Me.lblPwd.Location = New System.Drawing.Point(16, 42)
        Me.lblPwd.Name = "lblPwd"
        Me.lblPwd.Size = New System.Drawing.Size(61, 13)
        Me.lblPwd.TabIndex = 2
        Me.lblPwd.Text = "Password"
        Me.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(84, 66)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(78, 24)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(169, 66)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(264, 100)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.lblPwd)
        Me.Controls.Add(Me.txtUserCode)
        Me.Controls.Add(Me.lblName)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtUserCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents lblPwd As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
