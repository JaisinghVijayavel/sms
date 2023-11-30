<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmView))
        Me.rtxtView = New System.Windows.Forms.RichTextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rtxtView
        '
        Me.rtxtView.Location = New System.Drawing.Point(8, 9)
        Me.rtxtView.Name = "rtxtView"
        Me.rtxtView.ReadOnly = True
        Me.rtxtView.Size = New System.Drawing.Size(326, 257)
        Me.rtxtView.TabIndex = 0
        Me.rtxtView.Text = ""
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(262, 276)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "&Close"
        '
        'frmView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(341, 307)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.rtxtView)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rtxtView As System.Windows.Forms.RichTextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
