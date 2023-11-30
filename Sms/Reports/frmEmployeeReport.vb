Public Class frmEmployeeReport
    Inherits System.Windows.Forms.Form
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Call frmCtrClear(Me)
        Call LoadData()
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
        Dim lsSql As String = ""
        Dim i As Integer
        Dim lsCond As String

        Try
            lsCond = ""

            If txtEmployeeCode.Text <> "" Then lsCond &= " and employee_code like '" & QuoteFilter(txtEmployeeCode.Text) & "%' "
            If txtEmployeeName.Text <> "" Then lsCond &= " and employee_name like '" & QuoteFilter(txtEmployeeName.Text) & "%' "

            Select Case cboActive.Text
                Case "Yes"
                    lsCond &= " and employee_isactive='Y' "
                Case "No"
                    lsCond &= " and employee_isactive='N' "
            End Select

            If lsCond = "" Then lsCond &= " and 1 = 2 "

            lsSql = ""
            lsSql &= " select employee_code as 'Employee Code',employee_name as 'Employee Name', "
            lsSql &= " employee_isactive as 'Active Flag',employee_remark as 'Remark' from cru_mst_temployee "
            lsSql &= " where employee_isremoved='N' " & lsCond

            Call gpPopGridView(dgvReport, lsSql, gOdbcConn)

            For i = 0 To dgvReport.Columns.Count - 1
                dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            txtRecCount.Text = "Total Records : " & dgvReport.RowCount
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmPrfReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With cboActive
                .Items.Clear()
                .Items.Add("Yes")
                .Items.Add("No")
            End With

            btnClear.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmPrfReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
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
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            PrintDGridXML(dgvReport, gsReportPath & "Report.xls", "Report")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvReport_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles dgvReport.CellValueNeeded
        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
            e.Value = e.RowIndex + 1
        End If
    End Sub
End Class