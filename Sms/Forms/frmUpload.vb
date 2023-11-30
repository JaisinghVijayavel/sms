Imports MySql.Data.MySqlClient

Public Class frmUpload
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Try
            If MsgBox("Are you sure to upload ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.No Then
                Exit Sub
            End If

            btnUpload.Enabled = False
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            frmMain.lblStatus.Text = "Generating upload ..."

            Call GenerateUpload()

            frmMain.lblStatus.Text = ""
            Me.Cursor = System.Windows.Forms.Cursors.Default
            btnUpload.Enabled = True

            btnRefresh.PerformClick()
        Catch ex As Exception
            MsgBox("Runtime error !", MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Private Sub frmUpload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call GenerateUploadNo()
            Call LoadUploadableList()
        Catch ex As Exception
            MsgBox("Runtime error !", MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Private Sub GenerateUploadNo()
        Dim cmd As MySqlCommand
        Dim ds As New DataSet

        Try
            cmd = New MySqlCommand("pr_get_uploadsno", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

            Call gpDataSet(cmd, "upload", ds)

            If ds.Tables("upload").Rows.Count > 0 Then
                txtUploadNo.Text = ds.Tables("upload").Rows(0).Item("upload_code").ToString
                txtUploadNo.Tag = ds.Tables("upload").Rows(0).Item("upload_sno").ToString
            End If

            ds.Tables("upload").Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Private Sub LoadUploadableList()
        Dim lsSql As String
        Dim lobjDgvBtn As DataGridViewButtonColumn
        Dim lobjDgvChk As DataGridViewCheckBoxColumn

        lsSql = "set @sno := 0"
        Call gfInsertQry(lsSql, gOdbcConn)

        lsSql = ""
        lsSql &= " select "
        lsSql &= " b.sender_gid,"
        lsSql &= " @sno := @sno+1 as 'SNo',"
        lsSql &= " b.sender_name as 'Sender Name',"
        lsSql &= " count(*) as 'Sms Count' "
        lsSql &= " from sms_trn_ttran as a "
        lsSql &= " inner join sms_mst_tsender as b on a.sender_gid = b.sender_gid "
        lsSql &= " and b.active_status = 'Y' "
        lsSql &= " and b.delete_flag = 'N' "
        lsSql &= " where a.upload_gid = 0 "
        lsSql &= " and a.delete_flag = 'N' "
        lsSql &= " group by b.sender_gid,b.sender_name "

        dgvList.Columns.Clear()

        Call gpPopGridView(dgvList, lsSql, gOdbcConn)

        lobjDgvBtn = New DataGridViewButtonColumn
        lobjDgvBtn.Name = "View"
        lobjDgvBtn.Text = "View"
        lobjDgvBtn.UseColumnTextForButtonValue = True
        dgvList.Columns.Add(lobjDgvBtn)

        lobjDgvChk = New DataGridViewCheckBoxColumn
        lobjDgvChk.Name = "Select"
        lobjDgvChk.Selected = False
        dgvList.Columns.Insert(0, lobjDgvChk)

        dgvList.Columns("sender_gid").Visible = False

        For i = 1 To dgvList.Columns.Count - 1
            dgvList.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvList.Columns(i).ReadOnly = True
        Next

        dgvList.Columns("Select").Width = 50
        dgvList.Columns("SNo").Width = 50
        dgvList.Columns("Sender Name").Width = 200
        dgvList.Columns("Sms Count").Width = 50
    End Sub

    Private Sub GenerateUpload()
        Dim i As Integer
        Dim lnSenderId As Long = 0
        Dim lnUploadId As Long = 0
        Dim lnResult As Integer
        Dim lsTxt As String

        Dim lsSenderId As String = ""

        With dgvList
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells("Select").Value = True Then
                    lsSenderId = .Rows(i).Cells("sender_gid").Value.ToString & ","
                End If
            Next i
        End With

        If lsSenderId = "" Then
            MsgBox("Please select the sender !", MsgBoxStyle.Information, gsProjectName)
            Exit Sub
        End If

        ' insert the record in upload table
        Using cmd As New MySqlCommand("pr_ins_upload", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?in_upload_code", txtUploadNo.Text)
            cmd.Parameters.AddWithValue("?in_upload_sno", Val(txtUploadNo.Tag))
            cmd.Parameters.AddWithValue("?in_action_by", gsLoginUserCode)

            'Out put Para
            cmd.Parameters.Add("?out_result", MySqlDbType.Int32)
            cmd.Parameters("?out_result").Direction = ParameterDirection.Output
            cmd.Parameters.Add("?out_msg", MySqlDbType.VarChar)
            cmd.Parameters("?out_msg").Direction = ParameterDirection.Output
            cmd.Parameters.Add("?out_upload_gid", MySqlDbType.Int64)
            cmd.Parameters("?out_upload_gid").Direction = ParameterDirection.Output

            cmd.ExecuteNonQuery()

            lnResult = Val(cmd.Parameters("?out_result").Value.ToString())

            If (lnResult = 0) Then
                lsTxt = cmd.Parameters("?out_msg").Value.ToString()
                MsgBox(lsTxt, MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If

            lnUploadId = Val(cmd.Parameters("?out_upload_gid").Value.ToString())
        End Using

        With dgvList
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells("Select").Value = True Then
                    lnSenderId = Val(.Rows(i).Cells("sender_gid").Value.ToString)

                    ' update upload_gid in sms_trn_ttran table
                    Using cmd As New MySqlCommand("pr_set_uploadtran", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?in_upload_gid", lnUploadId)
                        cmd.Parameters.AddWithValue("?in_sender_gid", lnSenderId)
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
                        End If
                    End Using
                End If
            Next i
        End With

        MsgBox("Upload generated successfully !", MsgBoxStyle.Information, gsProjectName)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call GenerateUploadNo()
        Call LoadUploadableList()
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        Dim i As Integer

        If MsgBox("Are you sue to select all ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            With dgvList
                For i = 0 To .Rows.Count - 1
                    .Rows(i).Cells("Select").Value = True
                Next i
            End With
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim i As Integer

        If MsgBox("Are you sue to clear all ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            With dgvList
                For i = 0 To .Rows.Count - 1
                    .Rows(i).Cells("Select").Value = False
                Next i
            End With
        End If
    End Sub

    Private Sub dgvList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        Dim frm As frmTranReport
        If e.RowIndex >= 0 Then
            If dgvList.Columns(e.ColumnIndex).Name = "View" Then
                frm = New frmTranReport(dgvList.Rows(e.RowIndex).Cells("sender_gid").Value, True)
                frm.ShowDialog()
            End If
        End If
    End Sub
End Class