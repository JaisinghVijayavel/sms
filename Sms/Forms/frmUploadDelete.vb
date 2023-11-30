Imports MySql.Data.MySqlClient

Public Class frmUploadDelete
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim lnUploadId As Long = 0

        Try
            If cboUpload.SelectedIndex = -1 Or cboUpload.Text = "" Then
                MsgBox("Please select the upload !", MsgBoxStyle.Information, gsProjectName)
                cboUpload.Focus()
                Exit Sub
            End If

            If MsgBox("Are you sure to delete upload ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.No Then
                Exit Sub
            End If

            btnDelete.Enabled = False
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            frmMain.lblStatus.Text = "Deleting upload ..."

            lnUploadId = Val(cboUpload.SelectedValue.ToString())

            Call DeleteUpload(lnUploadId)

            frmMain.lblStatus.Text = ""
            Me.Cursor = System.Windows.Forms.Cursors.Default
            btnDelete.Enabled = True

            Call RefreshUpload()
            btnRefresh.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Private Sub frmUpload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call RefreshUpload()
    End Sub

    Private Sub RefreshUpload()
        Dim lsSql As String

        Try
            lsSql = ""
            lsSql &= " select upload_gid,upload_code from sms_trn_tupload "
            lsSql &= " where upload_status = " & gnUploadTaken & " "
            lsSql &= " and delete_flag = 'N' "
            lsSql &= " order by upload_gid desc"

            Call gpBindCombo(lsSql, "upload_code", "upload_gid", cboUpload, gOdbcConn)
        Catch ex As Exception
            MsgBox("Runtime error !", MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Private Sub LoadUploadedList(UploadId As Long)
        Dim lsSql As String
        Dim lobjDgvBtn As DataGridViewButtonColumn

        lsSql = "set @sno := 0"
        Call gfInsertQry(lsSql, gOdbcConn)

        lsSql = ""
        lsSql &= " select "
        lsSql &= " a.upload_gid,"
        lsSql &= " b.sender_gid,"
        lsSql &= " @sno := @sno+1 as 'SNo',"
        lsSql &= " b.sender_name as 'Sender Name',"
        lsSql &= " count(*) as 'Sms Count' "
        lsSql &= " from sms_trn_ttran as a "
        lsSql &= " inner join sms_mst_tsender as b on a.sender_gid = b.sender_gid "
        lsSql &= " and b.delete_flag = 'N' "
        lsSql &= " where a.upload_gid = " & UploadId & " "
        lsSql &= " and a.sms_status = " & gnSmsUpload & " "
        lsSql &= " and a.delete_flag = 'N' "
        lsSql &= " group by a.upload_gid,b.sender_gid,b.sender_name "

        dgvList.Columns.Clear()

        Call gpPopGridView(dgvList, lsSql, gOdbcConn)

        lobjDgvBtn = New DataGridViewButtonColumn
        lobjDgvBtn.Name = "View"
        lobjDgvBtn.Text = "View"
        lobjDgvBtn.UseColumnTextForButtonValue = True
        dgvList.Columns.Add(lobjDgvBtn)

        lobjDgvBtn = New DataGridViewButtonColumn
        lobjDgvBtn.Name = "Delete"
        lobjDgvBtn.Text = "Delete"
        lobjDgvBtn.UseColumnTextForButtonValue = True
        dgvList.Columns.Add(lobjDgvBtn)

        dgvList.Columns("upload_gid").Visible = False
        dgvList.Columns("sender_gid").Visible = False

        For i = 1 To dgvList.Columns.Count - 1
            dgvList.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvList.Columns(i).ReadOnly = True
        Next

        dgvList.Columns("View").Width = 50
        dgvList.Columns("Delete").Width = 50
        dgvList.Columns("SNo").Width = 50
        dgvList.Columns("Sender Name").Width = 200
        dgvList.Columns("Sms Count").Width = 50
    End Sub

    Private Sub DeleteUpload(UploadId As Long)
        Dim lnResult As Integer
        Dim lsTxt As String

        ' delete upload
        Using cmd As New MySqlCommand("pr_del_upload", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?in_upload_gid", UploadId)
            cmd.Parameters.AddWithValue("?in_action_by", gsLoginUserCode)

            'Out put Para
            cmd.Parameters.Add("?out_result", MySqlDbType.Int32)
            cmd.Parameters("?out_result").Direction = ParameterDirection.Output
            cmd.Parameters.Add("?out_msg", MySqlDbType.VarChar)
            cmd.Parameters("?out_msg").Direction = ParameterDirection.Output

            cmd.ExecuteNonQuery()

            lnResult = Val(cmd.Parameters("?out_result").Value.ToString())

            If (lnResult = 0) Then
                lsTxt = cmd.Parameters("?out_msg").Value.ToString()
                MsgBox(lsTxt, MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If
        End Using

        MsgBox("Upload deleted successfully !", MsgBoxStyle.Information, gsProjectName)

        cboUpload.Text = ""

        btnRefresh.PerformClick()
    End Sub

    Private Sub DeleteUploadSender(UploadId As Long, SenderId As Long)
        Dim lnResult As Integer
        Dim lsTxt As String

        ' delete upload sender
        Using cmd As New MySqlCommand("pr_del_uploadsender", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?in_upload_gid", UploadId)
            cmd.Parameters.AddWithValue("?in_sender_gid", SenderId)
            cmd.Parameters.AddWithValue("?in_action_by", gsLoginUserCode)

            'Out put Para
            cmd.Parameters.Add("?out_result", MySqlDbType.Int32)
            cmd.Parameters("?out_result").Direction = ParameterDirection.Output
            cmd.Parameters.Add("?out_msg", MySqlDbType.VarChar)
            cmd.Parameters("?out_msg").Direction = ParameterDirection.Output

            cmd.ExecuteNonQuery()

            lnResult = Val(cmd.Parameters("?out_result").Value.ToString())

            If (lnResult = 0) Then
                lsTxt = cmd.Parameters("?out_msg").Value.ToString()
                MsgBox(lsTxt, MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If
        End Using

        MsgBox("Sender upload deleted successfully !", MsgBoxStyle.Information, gsProjectName)

        btnRefresh.PerformClick()
    End Sub


    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call LoadUpload()
    End Sub

    Private Sub LoadUpload()
        If cboUpload.SelectedIndex <> -1 Then
            Call LoadUploadedList(Val(cboUpload.SelectedValue.ToString()))
        Else
            Call LoadUploadedList(0)
        End If
    End Sub

    Private Sub cboUpload_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUpload.SelectedIndexChanged
        Call LoadUpload()
    End Sub

    Private Sub dgvList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        Dim lnSenderId As Long = 0
        Dim lnUploadId As Long = 0
        Dim frm As frmTranReport

        If e.RowIndex >= 0 Then
            Select Case dgvList.Columns(e.ColumnIndex).Name
                Case "Delete"
                    If MsgBox("Are you sure to delete sender upload ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton3, gsProjectName) = MsgBoxResult.Yes Then
                        If cboUpload.Text = "" Or cboUpload.SelectedIndex = -1 Then
                            MsgBox("Please select the upload !", MsgBoxStyle.Information, gsProjectName)
                            cboUpload.Focus()
                            Exit Sub
                        End If

                        lnUploadId = Val(cboUpload.SelectedValue.ToString())
                        lnSenderId = dgvList.Rows(e.RowIndex).Cells("sender_gid").Value

                        Call DeleteUploadSender(lnUploadId, lnSenderId)
                    End If
                Case "View"
                    lnUploadId = dgvList.Rows(e.RowIndex).Cells("upload_gid").Value
                    lnSenderId = dgvList.Rows(e.RowIndex).Cells("sender_gid").Value

                    frm = New frmTranReport(lnSenderId, lnUploadId)
                    frm.ShowDialog()
            End Select
        End If
    End Sub
End Class