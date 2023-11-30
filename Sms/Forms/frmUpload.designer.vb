<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpload
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.txtUploadNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.pnlMain.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(498, 426)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "&Close"
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(382, 426)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(110, 24)
        Me.btnUpload.TabIndex = 3
        Me.btnUpload.Text = "Generate &Upload"
        '
        'txtUploadNo
        '
        Me.txtUploadNo.Location = New System.Drawing.Point(86, 12)
        Me.txtUploadNo.Name = "txtUploadNo"
        Me.txtUploadNo.Size = New System.Drawing.Size(118, 21)
        Me.txtUploadNo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 18)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Upload No"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.btnClear)
        Me.pnlMain.Controls.Add(Me.btnSelectAll)
        Me.pnlMain.Controls.Add(Me.btnRefresh)
        Me.pnlMain.Controls.Add(Me.Label4)
        Me.pnlMain.Controls.Add(Me.dgvList)
        Me.pnlMain.Controls.Add(Me.txtUploadNo)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Location = New System.Drawing.Point(12, 12)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(557, 408)
        Me.pnlMain.TabIndex = 24
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(468, 365)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 28
        Me.btnClear.Text = "Clear"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(390, 365)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(72, 24)
        Me.btnSelectAll.TabIndex = 27
        Me.btnSelectAll.Text = "&Select All"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(210, 12)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 26
        Me.btnRefresh.Text = "&Refresh"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 17)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Sender Sms Details"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Location = New System.Drawing.Point(15, 69)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.Size = New System.Drawing.Size(523, 290)
        Me.dgvList.TabIndex = 24
        '
        'frmUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 453)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnUpload)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpload"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generate Sms Upload"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents txtUploadNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
End Class
