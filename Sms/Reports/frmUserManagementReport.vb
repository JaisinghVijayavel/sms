Public Class frmUserManagementReport
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
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents pnlExport As System.Windows.Forms.Panel
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboRptType As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotRec As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserManagementReport))
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboRptType = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlExport = New System.Windows.Forms.Panel()
        Me.txtTotRec = New System.Windows.Forms.TextBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.pnlMain.SuspendLayout()
        Me.pnlExport.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.dtpTo)
        Me.pnlMain.Controls.Add(Me.Label8)
        Me.pnlMain.Controls.Add(Me.dtpFrom)
        Me.pnlMain.Controls.Add(Me.Label7)
        Me.pnlMain.Controls.Add(Me.cboRptType)
        Me.pnlMain.Controls.Add(Me.Label9)
        Me.pnlMain.Controls.Add(Me.btnClose)
        Me.pnlMain.Controls.Add(Me.btnClear)
        Me.pnlMain.Controls.Add(Me.btnRefresh)
        Me.pnlMain.Location = New System.Drawing.Point(6, 7)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(630, 75)
        Me.pnlMain.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(231, 12)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.ShowCheckBox = True
        Me.dtpTo.Size = New System.Drawing.Size(105, 21)
        Me.dtpTo.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(174, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 17)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "To"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(59, 12)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.ShowCheckBox = True
        Me.dtpFrom.Size = New System.Drawing.Size(105, 21)
        Me.dtpFrom.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(10, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 17)
        Me.Label7.TabIndex = 115
        Me.Label7.Text = "From"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRptType
        '
        Me.cboRptType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboRptType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRptType.FormattingEnabled = True
        Me.cboRptType.Location = New System.Drawing.Point(433, 12)
        Me.cboRptType.Name = "cboRptType"
        Me.cboRptType.Size = New System.Drawing.Size(184, 21)
        Me.cboRptType.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(348, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 17)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = "Report Type"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(545, 39)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 19
        Me.btnClose.Text = "&Close"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(467, 39)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 18
        Me.btnClear.Text = "C&lear"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(389, 39)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 17
        Me.btnRefresh.Text = "&Refresh"
        '
        'pnlExport
        '
        Me.pnlExport.Controls.Add(Me.txtTotRec)
        Me.pnlExport.Controls.Add(Me.btnExport)
        Me.pnlExport.Location = New System.Drawing.Point(6, 316)
        Me.pnlExport.Name = "pnlExport"
        Me.pnlExport.Size = New System.Drawing.Size(634, 33)
        Me.pnlExport.TabIndex = 21
        '
        'txtTotRec
        '
        Me.txtTotRec.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotRec.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotRec.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotRec.Location = New System.Drawing.Point(6, 8)
        Me.txtTotRec.MaxLength = 100
        Me.txtTotRec.Name = "txtTotRec"
        Me.txtTotRec.ReadOnly = True
        Me.txtTotRec.Size = New System.Drawing.Size(433, 14)
        Me.txtTotRec.TabIndex = 15
        Me.txtTotRec.TabStop = False
        Me.txtTotRec.Text = "Total Records : "
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(558, 5)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 22
        Me.btnExport.Text = "&Export"
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(6, 88)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.Size = New System.Drawing.Size(630, 212)
        Me.dgvReport.TabIndex = 20
        '
        'frmUserManagementReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(783, 354)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlExport)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUserManagementReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Management Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlMain.ResumeLayout(False)
        Me.pnlExport.ResumeLayout(False)
        Me.pnlExport.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "Local Declaration"
#End Region

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        dtpFrom.Checked = False
        dtpTo.Checked = False
        cboRptType.SelectedIndex = -1
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        btnRefresh.Enabled = False

        Call LoadData()

        btnRefresh.Enabled = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
        btnRefresh.Focus()
    End Sub

    Private Sub LoadData()
        Dim lsSql As String
        Dim lsCond As String

        Try
            lsCond = ""

            If dtpFrom.Checked = True Then lsCond &= " and a.login_date >= '" & Format(CDate(dtpFrom.Value), "yyyy-MM-dd") & "' "
            If dtpTo.Checked = True Then lsCond &= " and a.login_date < '" & Format(DateAdd("d", 1, CDate(dtpTo.Value)), "yyyy-MM-dd") & "' "

            lsSql = ""

            Select Case cboRptType.Text.ToUpper
                Case "LOGIN HISTORY"
                    lsSql &= " select a.login_date as 'Login Date',b.user_code as 'User Code',a.system_ip as 'System IP' "
                    lsSql &= " from soft_trn_tloginhistory as a,soft_mst_tuser as b "
                    lsSql &= " where 1 = 1 "
                    lsSql &= " and b.user_gid = a.user_gid"
                    lsSql &= lsCond
                    lsSql &= " and a.delete_flag = 'N' "
                    lsSql &= " and b.delete_flag = 'N' "
                Case "LOGIN ATTEMPT"
                    lsSql &= " select a.login_date as 'Login Date',a.user_code as 'User Code',a.system_ip as 'System IP' "
                    lsSql &= " from soft_trn_tloginattempt as a "
                    lsSql &= " where 1 = 1 "
                    lsSql &= lsCond
                    lsSql &= " and a.delete_flag = 'N' "
                Case Else
                    Exit Sub
            End Select

            Call gpPopGridView(dgvReport, lsSql, gOdbcConn)
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            dgvReport.ColumnHeadersHeight = 25

            txtTotRec.Text = "Total Records : " & dgvReport.RowCount
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmErrLineReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtpFrom.Value = Now
            dtpTo.Value = Now

            With cboRptType
                .Items.Clear()
                .Items.Add("Login History")
                .Items.Add("Login Attempt")
            End With

            CancelButton = btnClose
            btnClear.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmErrLine_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        pnlMain.Top = 6
        pnlMain.Left = 6

        With dgvReport
            .Top = pnlMain.Top + pnlMain.Height + 6
            .Left = pnlMain.Left
            .Width = Me.Width - 24
            .Height = Math.Abs(Me.Height - (pnlMain.Top + pnlMain.Height) - pnlExport.Height - 42)
        End With

        pnlExport.Left = dgvReport.Left
        pnlExport.Top = Me.Height - (pnlExport.Height * 2)
        pnlExport.Width = dgvReport.Width
        btnExport.Left = Math.Abs(pnlExport.Width - btnExport.Width)
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            PrintDGridXML(dgvReport, gsReportPath & "Report.xls", "Report")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
