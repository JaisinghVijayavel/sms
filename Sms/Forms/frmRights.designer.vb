<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRights
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
        Me.tvwRights = New System.Windows.Forms.TreeView
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboUserGrp = New System.Windows.Forms.ComboBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.chkSelectAll = New System.Windows.Forms.CheckBox
        Me.lblInfo = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'tvwRights
        '
        Me.tvwRights.CheckBoxes = True
        Me.tvwRights.Location = New System.Drawing.Point(6, 39)
        Me.tvwRights.Name = "tvwRights"
        Me.tvwRights.Size = New System.Drawing.Size(443, 404)
        Me.tvwRights.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "User Group"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboUserGrp
        '
        Me.cboUserGrp.FormattingEnabled = True
        Me.cboUserGrp.Location = New System.Drawing.Point(86, 9)
        Me.cboUserGrp.Name = "cboUserGrp"
        Me.cboUserGrp.Size = New System.Drawing.Size(180, 21)
        Me.cboUserGrp.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(371, 7)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 24)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(286, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(78, 24)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkSelectAll.Location = New System.Drawing.Point(6, 447)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(78, 17)
        Me.chkSelectAll.TabIndex = 12
        Me.chkSelectAll.Text = "Selec&t All"
        Me.chkSelectAll.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.ForeColor = System.Drawing.Color.Blue
        Me.lblInfo.Location = New System.Drawing.Point(94, 449)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(353, 13)
        Me.lblInfo.TabIndex = 13
        Me.lblInfo.Text = "* When Double Click the Main Menu,Sub Menu will be selected"
        '
        'frmRights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 469)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.chkSelectAll)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cboUserGrp)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tvwRights)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRights"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rights"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents tvwRights As System.Windows.Forms.TreeView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboUserGrp As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents lblInfo As System.Windows.Forms.Label
End Class
