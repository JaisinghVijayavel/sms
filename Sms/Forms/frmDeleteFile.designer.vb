<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeleteFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeleteFile))
        Me.dtpImportDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.cboFileName = New System.Windows.Forms.ComboBox()
        Me.cboSender = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dtpImportDate
        '
        Me.dtpImportDate.CustomFormat = "dd-MM-yyyy"
        Me.dtpImportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpImportDate.Location = New System.Drawing.Point(86, 8)
        Me.dtpImportDate.Name = "dtpImportDate"
        Me.dtpImportDate.Size = New System.Drawing.Size(107, 21)
        Me.dtpImportDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "File Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(408, 62)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "&Close"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(330, 62)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "Delete"
        '
        'cboFileName
        '
        Me.cboFileName.FormattingEnabled = True
        Me.cboFileName.Location = New System.Drawing.Point(86, 35)
        Me.cboFileName.Name = "cboFileName"
        Me.cboFileName.Size = New System.Drawing.Size(394, 21)
        Me.cboFileName.TabIndex = 5
        '
        'cboSender
        '
        Me.cboSender.FormattingEnabled = True
        Me.cboSender.Location = New System.Drawing.Point(295, 8)
        Me.cboSender.Name = "cboSender"
        Me.cboSender.Size = New System.Drawing.Size(185, 21)
        Me.cboSender.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(212, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sender"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmDeleteFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 98)
        Me.Controls.Add(Me.cboSender)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboFileName)
        Me.Controls.Add(Me.dtpImportDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeleteFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delete File"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpImportDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents cboFileName As System.Windows.Forms.ComboBox
    Friend WithEvents cboSender As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
