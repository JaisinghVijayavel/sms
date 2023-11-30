<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearch))
        Me.pnlInput = New System.Windows.Forms.Panel()
        Me.lblFld = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cboCondition = New System.Windows.Forms.ComboBox()
        Me.cboFld = New System.Windows.Forms.ComboBox()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.pnlDecision = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.txtTotRec = New System.Windows.Forms.TextBox()
        Me.pnlInput.SuspendLayout()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDecision.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlInput
        '
        Me.pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInput.Controls.Add(Me.lblFld)
        Me.pnlInput.Controls.Add(Me.btnExport)
        Me.pnlInput.Controls.Add(Me.btnSearch)
        Me.pnlInput.Controls.Add(Me.txtSearch)
        Me.pnlInput.Controls.Add(Me.cboCondition)
        Me.pnlInput.Controls.Add(Me.cboFld)
        Me.pnlInput.Location = New System.Drawing.Point(10, 5)
        Me.pnlInput.Name = "pnlInput"
        Me.pnlInput.Size = New System.Drawing.Size(715, 51)
        Me.pnlInput.TabIndex = 0
        '
        'lblFld
        '
        Me.lblFld.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblFld.AutoSize = True
        Me.lblFld.Location = New System.Drawing.Point(16, 16)
        Me.lblFld.Name = "lblFld"
        Me.lblFld.Size = New System.Drawing.Size(63, 13)
        Me.lblFld.TabIndex = 17
        Me.lblFld.Text = "Search by"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(630, 13)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 5
        Me.btnExport.Text = "Export"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(552, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(72, 24)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "&Search"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(326, 13)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(210, 21)
        Me.txtSearch.TabIndex = 3
        '
        'cboCondition
        '
        Me.cboCondition.Location = New System.Drawing.Point(232, 13)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(85, 21)
        Me.cboCondition.TabIndex = 2
        '
        'cboFld
        '
        Me.cboFld.Location = New System.Drawing.Point(80, 13)
        Me.cboFld.Name = "cboFld"
        Me.cboFld.Size = New System.Drawing.Size(144, 21)
        Me.cboFld.TabIndex = 1
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Text = "StatusBarPanel1"
        '
        'pnlDecision
        '
        Me.pnlDecision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDecision.Controls.Add(Me.btnCancel)
        Me.pnlDecision.Controls.Add(Me.btnOk)
        Me.pnlDecision.Location = New System.Drawing.Point(462, 392)
        Me.pnlDecision.Name = "pnlDecision"
        Me.pnlDecision.Size = New System.Drawing.Size(173, 40)
        Me.pnlDecision.TabIndex = 7
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(90, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "&Cancel"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(12, 8)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(72, 24)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "&Ok"
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.Location = New System.Drawing.Point(54, 106)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.Size = New System.Drawing.Size(634, 119)
        Me.dgvReport.TabIndex = 6
        '
        'txtTotRec
        '
        Me.txtTotRec.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtTotRec.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotRec.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotRec.Location = New System.Drawing.Point(55, 341)
        Me.txtTotRec.Name = "txtTotRec"
        Me.txtTotRec.ReadOnly = True
        Me.txtTotRec.Size = New System.Drawing.Size(222, 14)
        Me.txtTotRec.TabIndex = 17
        Me.txtTotRec.TabStop = False
        Me.txtTotRec.Text = "Total Records : "
        '
        'frmSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlDecision)
        Me.Controls.Add(Me.pnlInput)
        Me.Controls.Add(Me.txtTotRec)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search"
        Me.pnlInput.ResumeLayout(False)
        Me.pnlInput.PerformLayout()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDecision.ResumeLayout(False)
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlInput As System.Windows.Forms.Panel
    Friend WithEvents lblFld As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboCondition As System.Windows.Forms.ComboBox
    Friend WithEvents cboFld As System.Windows.Forms.ComboBox
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents pnlDecision As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotRec As System.Windows.Forms.TextBox
End Class
