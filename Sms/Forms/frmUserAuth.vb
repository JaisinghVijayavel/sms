Imports MySql.Data.MySqlClient

Public Class frmUserAuth
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserAuth))
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlExport = New System.Windows.Forms.Panel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.lblRecordCount = New System.Windows.Forms.Label()
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
        Me.pnlMain.Controls.Add(Me.Label11)
        Me.pnlMain.Controls.Add(Me.dtpFrom)
        Me.pnlMain.Controls.Add(Me.Label10)
        Me.pnlMain.Controls.Add(Me.btnClose)
        Me.pnlMain.Controls.Add(Me.btnClear)
        Me.pnlMain.Controls.Add(Me.btnRefresh)
        Me.pnlMain.Location = New System.Drawing.Point(6, 7)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(575, 40)
        Me.pnlMain.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(223, 8)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.ShowCheckBox = True
        Me.dtpTo.Size = New System.Drawing.Size(105, 21)
        Me.dtpTo.TabIndex = 117
        Me.dtpTo.Value = New Date(2008, 1, 12, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(167, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 17)
        Me.Label11.TabIndex = 119
        Me.Label11.Text = "To"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(56, 8)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.ShowCheckBox = True
        Me.dtpFrom.Size = New System.Drawing.Size(105, 21)
        Me.dtpFrom.TabIndex = 116
        Me.dtpFrom.Value = New Date(2008, 1, 12, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(7, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 17)
        Me.Label10.TabIndex = 118
        Me.Label10.Text = "From"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(494, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "&Close"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(416, 6)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "C&lear"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(338, 6)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "&Refresh"
        '
        'pnlExport
        '
        Me.pnlExport.Controls.Add(Me.btnExport)
        Me.pnlExport.Controls.Add(Me.lblRecordCount)
        Me.pnlExport.Location = New System.Drawing.Point(6, 316)
        Me.pnlExport.Name = "pnlExport"
        Me.pnlExport.Size = New System.Drawing.Size(635, 33)
        Me.pnlExport.TabIndex = 13
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(562, 5)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 14
        Me.btnExport.Text = "&Export"
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblRecordCount.Location = New System.Drawing.Point(3, 10)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(94, 13)
        Me.lblRecordCount.TabIndex = 0
        Me.lblRecordCount.Text = "Total Records : "
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(6, 53)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.Size = New System.Drawing.Size(634, 257)
        Me.dgvReport.TabIndex = 12
        '
        'frmUserAuth
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(825, 354)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlExport)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUserAuth"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Management Auth Screen"
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
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Call frmCtrClear(Me)
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
        Dim i As Integer
        Dim n As Integer

        Dim lsSQL As String
        Dim lsCond As String

        Dim lobjTxtRemark As New DataGridViewTextBoxColumn
        Dim lobjBtnView As New DataGridViewButtonColumn
        Dim lobjBtnAuth As New DataGridViewButtonColumn
        Dim lobjBtnReject As New DataGridViewButtonColumn

        Try
            lsCond = ""

            If dtpFrom.Checked = True Then
                lsCond &= " and a.entry_date >= '" & Format(CDate(dtpFrom.Value), "yyyy-MM-dd") & "' "
            End If

            If dtpTo.Checked = True Then
                lsCond &= " and a.entry_date < '" & Format(DateAdd(DateInterval.Day, 1, CDate(dtpTo.Value)), "yyyy-MM-dd") & "' "
            End If

            lsSQL = ""
            lsSQL &= " SELECT a.auth_gid,a.qry_detail,a.auth_qry,a.reject_qry,"
            lsSQL &= " a.entry_date as 'Date',a.qry_desc as 'Particulars',a.entry_by as 'Request By',"
            lsSQL &= " auth_qry,reject_qry from soft_trn_tauth as a "
            lsSQL &= " where 1 = 1 "
            lsSQL &= lsCond
            lsSQL &= " and (a.entry_by <> '" & QuoteFilter(gsLoginUserCode) & "' or a.entry_by = '') "
            lsSQL &= " and a.auth_flag = 'N' "
            lsSQL &= " and a.delete_flag = 'N'"

            dgvReport.Columns.Clear()

            gpPopGridView(dgvReport, lsSQL, gOdbcConn)

            For i = 0 To dgvReport.Columns.Count - 1
                dgvReport.Columns(i).ReadOnly = True
                dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            n = dgvReport.ColumnCount

            dgvReport.Columns(0).Visible = False
            dgvReport.Columns(1).Visible = False
            dgvReport.Columns(2).Visible = False
            dgvReport.Columns(3).Visible = False

            dgvReport.Columns(n - 2).Visible = False
            dgvReport.Columns(n - 1).Visible = False

            lobjTxtRemark.HeaderText = "Remark"
            dgvReport.Columns.Add(lobjTxtRemark)

            lobjBtnView.HeaderText = "View"
            dgvReport.Columns.Add(lobjBtnView)

            lobjBtnAuth.HeaderText = "Auth"
            dgvReport.Columns.Add(lobjBtnAuth)

            lobjBtnReject.HeaderText = "Reject"
            dgvReport.Columns.Add(lobjBtnReject)

            For i = 0 To dgvReport.RowCount - 1
                dgvReport.Rows(i).Cells(n).Value = ""
                dgvReport.Rows(i).Cells(n + 1).Value = "View"
                dgvReport.Rows(i).Cells(n + 2).Value = "Auth"
                dgvReport.Rows(i).Cells(n + 3).Value = "Reject"
            Next i

            dgvReport.AutoResizeColumns()
            lblRecordCount.Text = "Total Records : " & dgvReport.RowCount
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmQryAuth_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        btnRefresh.PerformClick()
    End Sub

    Private Sub frmMe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtpFrom.Value = Now
            dtpTo.Value = Now

            dtpFrom.Checked = False
            dtpTo.Checked = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmLoanReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        pnlMain.Top = 6
        pnlMain.Left = 6

        With dgvReport
            .Top = pnlMain.Top + pnlMain.Height + 6
            .Left = 6
            .Width = Math.Abs(Me.Width - 24)
            .Height = Math.Abs(Me.Height - (pnlMain.Top + pnlMain.Height) - pnlExport.Height - 42)
        End With

        pnlExport.Top = dgvReport.Top + dgvReport.Height + 6
        pnlExport.Left = dgvReport.Left
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

    Private Sub dgvReport_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReport.CellContentClick
        Dim frm As frmView
        Dim lnAuthId As Long
        Dim lsRemark As String
        Dim lnResult As Long

        Dim lbUpdateFlag As Boolean = False
        Dim lsAuthFlag As String = ""
        Dim lsMsg As String = ""

        With dgvReport
            If e.RowIndex >= 0 Then
                lnAuthId = .Rows(e.RowIndex).Cells(0).Value
                lsRemark = QuoteFilter(Mid(.Rows(e.RowIndex).Cells(.Columns.Count - 4).Value.ToString, 1, 255))

                Select Case e.ColumnIndex
                    Case .Columns.Count - 3     ' View
                        frm = New frmView(.Rows(e.RowIndex).Cells(1).Value.ToString)
                        frm.ShowDialog()
                    Case .Columns.Count - 2     ' Auth
                        If MsgBox("Are you sure to auth ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                            lbUpdateFlag = True
                            lsAuthFlag = "A"
                        End If
                    Case .Columns.Count - 1     ' Reject
                        If MsgBox("Are you sure to reject ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                            If lsRemark = "" Then
                                MsgBox("Remark cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                            Else
                                lbUpdateFlag = True
                                lsAuthFlag = "R"
                            End If
                        End If
                End Select

                If lbUpdateFlag Then
                    Using cmd As New MySqlCommand("pr_set_auth", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?in_auth_gid", lnAuthId)
                        cmd.Parameters("?in_auth_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?in_auth_flag", lsAuthFlag)
                        cmd.Parameters("?in_auth_flag").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?in_auth_remark", lsRemark)
                        cmd.Parameters("?in_auth_remark").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?in_action_by", gsLoginUserCode)
                        cmd.Parameters("?in_action_by").Direction = ParameterDirection.Input
                        'Out put Para
                        cmd.Parameters.Add("?out_result", MySqlDbType.Int32)
                        cmd.Parameters("?out_result").Direction = ParameterDirection.Output
                        cmd.Parameters.Add("?out_msg", MySqlDbType.VarChar)
                        cmd.Parameters("?out_msg").Direction = ParameterDirection.Output

                        cmd.ExecuteNonQuery()

                        lnResult = Val(cmd.Parameters("?out_result").Value.ToString())
                        lsMsg = cmd.Parameters("?out_msg").Value.ToString()

                        If lnResult Then
                            MessageBox.Show(lsMsg, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            btnRefresh.PerformClick()
                        Else
                            MessageBox.Show(lsMsg, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End If
            End If
        End With
    End Sub
End Class
