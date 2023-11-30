Public Class frmUploadReport
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtUploadCode As System.Windows.Forms.TextBox
    Friend WithEvents txtRecCount As System.Windows.Forms.TextBox
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents cboUploadBy As System.Windows.Forms.ComboBox
    Friend WithEvents txtUploadId As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.txtUploadId = New System.Windows.Forms.TextBox()
        Me.cboUploadBy = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtUploadCode = New System.Windows.Forms.TextBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlExport = New System.Windows.Forms.Panel()
        Me.txtRecCount = New System.Windows.Forms.TextBox()
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
        Me.pnlMain.Controls.Add(Me.txtUploadId)
        Me.pnlMain.Controls.Add(Me.cboUploadBy)
        Me.pnlMain.Controls.Add(Me.Label21)
        Me.pnlMain.Controls.Add(Me.txtUploadCode)
        Me.pnlMain.Controls.Add(Me.dtpTo)
        Me.pnlMain.Controls.Add(Me.Label11)
        Me.pnlMain.Controls.Add(Me.dtpFrom)
        Me.pnlMain.Controls.Add(Me.Label10)
        Me.pnlMain.Controls.Add(Me.btnClose)
        Me.pnlMain.Controls.Add(Me.btnClear)
        Me.pnlMain.Controls.Add(Me.btnRefresh)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.Label12)
        Me.pnlMain.Location = New System.Drawing.Point(6, 7)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(768, 70)
        Me.pnlMain.TabIndex = 0
        '
        'txtUploadId
        '
        Me.txtUploadId.Location = New System.Drawing.Point(274, 39)
        Me.txtUploadId.MaxLength = 0
        Me.txtUploadId.Name = "txtUploadId"
        Me.txtUploadId.Size = New System.Drawing.Size(105, 21)
        Me.txtUploadId.TabIndex = 4
        '
        'cboUploadBy
        '
        Me.cboUploadBy.FormattingEnabled = True
        Me.cboUploadBy.Items.AddRange(New Object() {"Ledger", "Bank Statement"})
        Me.cboUploadBy.Location = New System.Drawing.Point(87, 39)
        Me.cboUploadBy.Name = "cboUploadBy"
        Me.cboUploadBy.Size = New System.Drawing.Size(105, 21)
        Me.cboUploadBy.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(2, 42)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 129
        Me.Label21.Text = "Upload By"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUploadCode
        '
        Me.txtUploadCode.Location = New System.Drawing.Point(470, 12)
        Me.txtUploadCode.MaxLength = 0
        Me.txtUploadCode.Name = "txtUploadCode"
        Me.txtUploadCode.Size = New System.Drawing.Size(283, 21)
        Me.txtUploadCode.TabIndex = 2
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(274, 12)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.ShowCheckBox = True
        Me.dtpTo.Size = New System.Drawing.Size(105, 21)
        Me.dtpTo.TabIndex = 1
        Me.dtpTo.Value = New Date(2008, 1, 12, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(218, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 17)
        Me.Label11.TabIndex = 115
        Me.Label11.Text = "To"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(87, 12)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.ShowCheckBox = True
        Me.dtpFrom.Size = New System.Drawing.Size(105, 21)
        Me.dtpFrom.TabIndex = 0
        Me.dtpFrom.Value = New Date(2008, 1, 12, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(-4, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 17)
        Me.Label10.TabIndex = 115
        Me.Label10.Text = "Upload From"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(681, 39)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "&Close"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(603, 39)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "C&lear"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(525, 39)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 6
        Me.btnRefresh.Text = "&Refresh"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(191, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Upload Id"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(385, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 17)
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "Upload Code"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlExport
        '
        Me.pnlExport.Controls.Add(Me.txtRecCount)
        Me.pnlExport.Controls.Add(Me.btnExport)
        Me.pnlExport.Location = New System.Drawing.Point(6, 316)
        Me.pnlExport.Name = "pnlExport"
        Me.pnlExport.Size = New System.Drawing.Size(634, 33)
        Me.pnlExport.TabIndex = 2
        '
        'txtRecCount
        '
        Me.txtRecCount.BackColor = System.Drawing.SystemColors.Control
        Me.txtRecCount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRecCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRecCount.Location = New System.Drawing.Point(6, 8)
        Me.txtRecCount.MaxLength = 100
        Me.txtRecCount.Name = "txtRecCount"
        Me.txtRecCount.ReadOnly = True
        Me.txtRecCount.Size = New System.Drawing.Size(433, 14)
        Me.txtRecCount.TabIndex = 0
        Me.txtRecCount.TabStop = False
        Me.txtRecCount.Text = "Record Count : "
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(558, 5)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "&Export"
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(6, 246)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.Size = New System.Drawing.Size(754, 57)
        Me.dgvReport.TabIndex = 1
        '
        'frmUploadReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(783, 354)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlExport)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmUploadReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Upload Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlExport.ResumeLayout(False)
        Me.pnlExport.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "Local Declaration"
#End Region
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            dtpFrom.Checked = False
            dtpTo.Checked = False

            Call frmCtrClear(Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            btnRefresh.Enabled = False

            Call LoadData()

            btnRefresh.Enabled = True
            Me.Cursor = System.Windows.Forms.Cursors.Default

            btnRefresh.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Private Sub LoadData()
        Dim lsSql As String
        Dim lsFld As String
        Dim lsCond As String
        Dim i As Integer

        Try
            lsCond = ""
            If dtpFrom.Checked = True Then
                lsCond &= " and a.upload_date > '" & Format(DateAdd(DateInterval.Day, -1, dtpFrom.Value), "yyyy-MM-dd") & "' "
            End If

            If dtpTo.Checked = True Then
                lsCond &= " and a.upload_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpTo.Value), "yyyy-MM-dd") & "' "
            End If

            If txtUploadCode.Text <> "" Then
                lsCond &= " and a.upload_code like '" & txtUploadCode.Text.Trim & "%' "
            End If

            If txtUploadId.Text <> "" Then
                lsCond &= " and a.upload_gid  = " & Val(txtUploadId.Text).ToString & " "
            End If

            If cboUploadBy.Text <> "" And cboUploadBy.SelectedIndex <> -1 Then
                lsCond &= " and a.upload_by = '" & cboUploadBy.SelectedValue.ToString() & "' "
            End If

            If lsCond = "" Then lsCond &= " and 1 = 2 "

            lsFld = ""
            lsFld &= " a.upload_date as 'Upload Date',"
            lsFld &= " a.upload_code as 'Upload Code',a.upload_sno as 'Upload SNo',"
            lsFld &= " make_set(a.upload_status,'Upload','Delete') as 'Upload Status',"
            lsFld &= " a.insert_date as 'Insert Date',"
            lsFld &= " a.insert_by as 'Insert By',"
            lsFld &= " a.update_date as 'Update Date',"
            lsFld &= " a.update_by as 'Update By',"
            lsFld &= " a.upload_gid as 'Upload Id' "

            lsSql = ""
            lsSql &= " select "
            lsSql &= lsFld

            lsSql &= " from sms_trn_tupload as a "
            lsSql &= " where true "
            lsSql &= lsCond
            lsSql &= " and a.delete_flag = 'N' "
            lsSql &= " order by a.upload_gid desc"

            Call gpPopGridView(dgvReport, lsSql, gOdbcConn)

            For i = 0 To dgvReport.Columns.Count - 1
                dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            txtRecCount.Text = "Total Records : " & dgvReport.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Private Sub frmPrfReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call gpBindCombo("select * from soft_mst_tuser where delete_flag = 'N' order by user_name", _
                "user_name", "user_code", cboUploadBy, gOdbcConn)

            dtpFrom.Value = CDate(Format(Now, "yyyy-MM-dd"))
            dtpTo.Value = CDate(Format(Now, "yyyy-MM-dd"))

            dtpFrom.Checked = False
            dtpTo.Checked = False

            btnClear.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Private Sub frmPrfReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Try
            pnlMain.Top = 6
            pnlMain.Left = 6

            With dgvReport
                .Top = pnlMain.Top + pnlMain.Height + 6
                .Left = 6
                .Width = Me.Width - 24
                .Height = Math.Abs(Me.Height - (pnlMain.Top + pnlMain.Height) - pnlExport.Height - 42)
            End With

            pnlExport.Top = dgvReport.Top + dgvReport.Height + 6
            pnlExport.Width = Me.Width
            btnExport.Left = pnlExport.Width - btnExport.Width - 24
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            PrintDGridXML(dgvReport, gsReportPath & "\Report.xls", "Report")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Private Sub pnlMain_Paint(sender As Object, e As PaintEventArgs) Handles pnlMain.Paint

    End Sub
End Class
