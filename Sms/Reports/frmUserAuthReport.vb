Public Class frmUserAuthReport

    Dim fsSql As String = ""

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        '******************************************
        btnRefresh.Enabled = Not btnRefresh.Enabled
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        LoadData()

        btnRefresh.Enabled = Not btnRefresh.Enabled
        Me.Cursor = Cursors.Default
        Application.DoEvents()
        '******************************************
    End Sub

    Private Sub LoadData()
        Dim objDataSet As New DataSet

        Dim lnChqStatus As Integer = 0
        Dim lnrecordcount As Integer = 0

        Dim lsCondn As String = ""
        Dim lsJoin As String = ""
        Dim lsFldName As String = ""

        Try
            lsCondn = " where 1=1"
            If dtpRequestfrom.Checked = True Then
                lsCondn &= " AND entry_date >= '" & Format(dtpRequestfrom.Value, "yyyy-MM-dd") & "'"
            End If
            If dtpRequestTo.Checked = True Then
                lsCondn &= " AND entry_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpRequestTo.Value), "yyyy-MM-dd") & "'"
            End If

            If dtpAuthFrom.Checked = True Then
                lsCondn &= " AND auth_date >= '" & Format(dtpRequestfrom.Value, "yyyy-MM-dd") & "'"
            End If
            If dtpAuthTo.Checked = True Then
                lsCondn &= " AND auth_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpRequestTo.Value), "yyyy-MM-dd") & "'"
            End If

            Select Case cboAuthStatus.Text
                Case "AUTHORIZED"
                    lsCondn &= " and auth_flag = 'Y' "
                Case "REJECTED"
                    lsCondn &= " and auth_flag = 'R' "
                Case "PENDING"
                    lsCondn &= " and auth_flag = 'N' "
            End Select

            lsCondn &= " AND delete_flag = 'N' "

            fsSql = ""
            fsSql &= " select entry_date as 'Request Date',"
            fsSql &= " entry_by as 'Request By',qry_desc as 'Query Desc',"
            fsSql &= " qry_detail as 'Query Detail',"
            fsSql &= " case auth_flag "
            fsSql &= " when 'N' then 'Sent for Approval' "
            fsSql &= " when 'Y' then 'Authorized' "
            fsSql &= " when 'R' then 'Rejected' "
            fsSql &= " end as 'Status',"
            fsSql &= " auth_date as 'Auth Date',auth_by as 'Auth By', auth_remark as 'Auth Reason' "
            fsSql &= " from soft_trn_tauth"
            fsSql &= lsCondn

            objDataSet = gfDataSet(fsSql, "soft_trn_tauth", gOdbcConn)

            dgvRpt.DataSource = objDataSet.Tables("soft_trn_tauth")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmAuthReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            pnlMain.Top = 6
            pnlMain.Left = 8

            With dgvRpt
                .Top = pnlMain.Top + pnlMain.Height + 6
                .Left = 8
                .Width = Me.Width - 24
                .Height = (Me.Height - pnlMain.Height) - pnlMain.Height / 2
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexport.Click
        Try
            If dgvRpt.RowCount = 0 Then
                MsgBox("No Records Found!", MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If

            '****************************************
            btnexport.Enabled = Not btnexport.Enabled
            Me.Cursor = Cursors.WaitCursor
            '****************************************

            Call PrintDGridXML(dgvRpt, gsReportPath & "Report.xls", "Auth Report")

            '****************************************
            btnexport.Enabled = Not btnexport.Enabled
            Me.Cursor = Cursors.Default
            '****************************************

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmAuthReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyBase.WindowState = FormWindowState.Maximized
        dtpAuthFrom.Value = Now
        dtpAuthTo.Value = Now
        dtpRequestfrom.Value = Now
        dtpRequestTo.Value = Now

        With cboAuthStatus
            .Items.Add("")
            .Items.Add("PENDING")
            .Items.Add("AUTHORIZED")
            .Items.Add("REJECTED")
        End With
    End Sub
End Class