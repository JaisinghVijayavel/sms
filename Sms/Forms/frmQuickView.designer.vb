<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuickView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuickView))
        Me.pnlReport = New System.Windows.Forms.Panel()
        Me.lblTotRec = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.dgvQuickView = New System.Windows.Forms.DataGridView()
        Me.pnlReport.SuspendLayout()
        CType(Me.dgvQuickView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlReport
        '
        Me.pnlReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlReport.Controls.Add(Me.lblTotRec)
        Me.pnlReport.Controls.Add(Me.btnClose)
        Me.pnlReport.Controls.Add(Me.btnExport)
        Me.pnlReport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlReport.Location = New System.Drawing.Point(12, 229)
        Me.pnlReport.Name = "pnlReport"
        Me.pnlReport.Size = New System.Drawing.Size(319, 41)
        Me.pnlReport.TabIndex = 3
        '
        'lblTotRec
        '
        Me.lblTotRec.AutoSize = True
        Me.lblTotRec.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTotRec.Location = New System.Drawing.Point(169, 15)
        Me.lblTotRec.Name = "lblTotRec"
        Me.lblTotRec.Size = New System.Drawing.Size(85, 13)
        Me.lblTotRec.TabIndex = 4
        Me.lblTotRec.Text = "Total Records"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(87, 7)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(9, 7)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 0
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'dgvQuickView
        '
        Me.dgvQuickView.AllowUserToAddRows = False
        Me.dgvQuickView.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQuickView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvQuickView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQuickView.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvQuickView.Location = New System.Drawing.Point(12, 12)
        Me.dgvQuickView.Name = "dgvQuickView"
        Me.dgvQuickView.ReadOnly = True
        Me.dgvQuickView.Size = New System.Drawing.Size(275, 196)
        Me.dgvQuickView.TabIndex = 2
        '
        'frmQuickView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 420)
        Me.Controls.Add(Me.pnlReport)
        Me.Controls.Add(Me.dgvQuickView)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmQuickView"
        Me.Text = "frmQuickView"
        Me.pnlReport.ResumeLayout(False)
        Me.pnlReport.PerformLayout()
        CType(Me.dgvQuickView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlReport As System.Windows.Forms.Panel
    Friend WithEvents lblTotRec As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents dgvQuickView As System.Windows.Forms.DataGridView
End Class
