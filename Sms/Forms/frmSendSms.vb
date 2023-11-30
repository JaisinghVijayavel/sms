Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class frmSendSms
    Dim msSmsUrl As String
    Dim msSmsApiKey As String
    Dim msSmsRouteId As String

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Dim lnUploadId As Long = 0
        Dim lnSenderId As Long = 0
        Dim lsSenderName As String = ""
        Dim lsSenderCode As String = ""
        Dim lnTranId As Long = 0
        Dim i As Integer
        Dim j As Integer
        Dim lsSql As String
        Dim lsMobileNo As String
        Dim lsSmsTxt As String
        Dim lsSmsTemplateId As String
        Dim ds As New DataSet

        Dim lnTotCount As Long = 0
        Dim lnTotDelivered As Long = 0
        Dim lnTotFailed As Long = 0
        Dim lnResult As Integer

        Try
            If cboUpload.SelectedIndex = -1 Or cboUpload.Text = "" Then
                MsgBox("Please select the upload !", MsgBoxStyle.Information, gsProjectName)
                cboUpload.Focus()
                Exit Sub
            End If

            If MsgBox("Are you sure to send sms ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.No Then
                Exit Sub
            End If

            msSmsUrl = ""
            msSmsApiKey = ""
            msSmsRouteId = ""

            ' get url, api key and route id
            lsSql = ""
            lsSql &= " select * from sms_mst_tconfig "
            lsSql &= " where config_name in ('SMS API URL','SMS API KEY','SMS ROUTE ID') "
            lsSql &= " and active_status = 'Y' "
            lsSql &= " and delete_flag = 'N' "

            Call gpDataSet(lsSql, "config", gOdbcConn, ds)

            For i = 0 To ds.Tables("config").Rows.Count - 1
                Select Case ds.Tables("config").Rows(i).Item("config_name").ToString().ToUpper()
                    Case "SMS API URL"
                        msSmsUrl = ds.Tables("config").Rows(i).Item("config_value").ToString
                    Case "SMS API KEY"
                        msSmsApiKey = ds.Tables("config").Rows(i).Item("config_value").ToString
                    Case "SMS ROUTE ID"
                        msSmsRouteId = ds.Tables("config").Rows(i).Item("config_value").ToString
                End Select
            Next i

            ds.Tables("config").Rows.Clear()

            btnSend.Enabled = False
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            frmMain.lblStatus.Text = "Sending sms ..."

            lnUploadId = Val(cboUpload.SelectedValue.ToString())

            With dgvList
                For i = 0 To .Rows.Count - 1
                    lnSenderId = .Rows(i).Cells("sender_gid").Value
                    lsSenderCode = .Rows(i).Cells("sender_code").Value.ToString
                    lsSenderName = .Rows(i).Cells("Sender Name").Value.ToString

                    ' select the sms list by sender
                    lsSql = ""
                    lsSql &= " select tran_gid,mobile_no,sms_txt,sms_template_id from sms_trn_ttran "
                    lsSql &= " where upload_gid = " & lnUploadId & " "
                    lsSql &= " and sender_gid = " & lnSenderId & " "
                    lsSql &= " and (sms_status = " & gnSmsUpload & " "
                    lsSql &= " or sms_status & " & gnSmsFailed & " > 0) "
                    lsSql &= " and sms_status & " & gnSmsDelivered & " = 0 "
                    lsSql &= " and delete_flag = 'N' "

                    Call gpDataSet(lsSql, "sms", gOdbcConn, ds)

                    For j = 0 To ds.Tables("sms").Rows.Count - 1
                        lnTranId = ds.Tables("sms").Rows(j).Item("tran_gid")

                        lsMobileNo = ds.Tables("sms").Rows(j).Item("mobile_no").ToString
                        lsSmsTxt = ds.Tables("sms").Rows(j).Item("sms_txt").ToString()
                        lsSmsTemplateId = ds.Tables("sms").Rows(j).Item("sms_template_id").ToString()

                        If lsMobileNo.Length = 10 Then lsMobileNo = "91" & lsMobileNo

                        Application.DoEvents()
                        frmMain.lblStatus.Text = "Sending sms Sender : " & lsSenderName & " out of " & ds.Tables("sms").Rows.Count & " record(s) sending " & (j + 1) & " record..."

                        lnTotCount += 1
                        lnResult = SendSms(lnTranId, lsMobileNo, lsSmsTxt, lsSenderCode, lsSmsTemplateId)

                        lnTotDelivered += lnResult
                        lnTotFailed += CInt(Not CBool(lnResult))
                    Next j

                    ds.Tables("sms").Rows.Clear()
                Next i
            End With

            frmMain.lblStatus.Text = ""
            Me.Cursor = System.Windows.Forms.Cursors.Default
            btnSend.Enabled = True

            btnRefresh.PerformClick()

            MsgBox("Out of " & lnTotCount & " Sms " & lnTotDelivered & " delivered, " & Math.Abs(lnTotFailed) & " failed !", MsgBoxStyle.Information, gsProjectName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Private Sub frmUpload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboUpload.SelectedIndex = -1
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Private Sub LoadUploadedList(UploadId As Long)
        Dim lsSql As String
        Dim lobjDgvChk As DataGridViewCheckBoxColumn
        Dim lobjDgvBtn As DataGridViewButtonColumn

        lsSql = "set @sno := 0"
        Call gfInsertQry(lsSql, gOdbcConn)

        lsSql = ""
        lsSql &= " select "
        lsSql &= " a.upload_gid,"
        lsSql &= " b.sender_gid,"
        lsSql &= " @sno := @sno+1 as 'SNo',"
        lsSql &= " b.sender_code,"
        lsSql &= " b.sender_name as 'Sender Name',"
        lsSql &= " count(*) as 'Sms Count',"
        lsSql &= " sum(if(a.sms_status = " & gnSmsUpload & ",1,0)) as 'Sms To Be Send',"
        lsSql &= " round(sum((a.sms_status & " & gnSmsDelivered & ")/" & gnSmsDelivered & " ),0) as 'Sms Delivered',"
        lsSql &= " round(sum((a.sms_status & " & gnSmsFailed & ")/" & gnSmsFailed & " ),0) as 'Sms Failed' "
        lsSql &= " from sms_trn_ttran as a "
        lsSql &= " inner join sms_mst_tsender as b on a.sender_gid = b.sender_gid "
        lsSql &= " and b.delete_flag = 'N' "
        lsSql &= " where a.upload_gid = " & UploadId & " "
        lsSql &= " and a.delete_flag = 'N' "
        lsSql &= " group by b.sender_gid,b.sender_name "

        dgvList.Columns.Clear()

        Call gpPopGridView(dgvList, lsSql, gOdbcConn)

        lobjDgvChk = New DataGridViewCheckBoxColumn
        lobjDgvChk.Name = "Select"
        lobjDgvChk.Selected = False
        dgvList.Columns.Insert(0, lobjDgvChk)

        lobjDgvBtn = New DataGridViewButtonColumn
        lobjDgvBtn.Name = "View"
        lobjDgvBtn.Text = "View"
        lobjDgvBtn.UseColumnTextForButtonValue = True
        dgvList.Columns.Add(lobjDgvBtn)

        dgvList.Columns("upload_gid").Visible = False
        dgvList.Columns("sender_gid").Visible = False
        dgvList.Columns("sender_code").Visible = False

        For i = 1 To dgvList.Columns.Count - 1
            dgvList.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvList.Columns(i).ReadOnly = True
        Next

        dgvList.Columns("Select").Width = 50
        dgvList.Columns("SNo").Width = 40
        dgvList.Columns("Sender Name").Width = 150
        dgvList.Columns("Sms Count").Width = 75
        dgvList.Columns("Sms To Be Send").Width = 75
        dgvList.Columns("Sms Delivered").Width = 75
        dgvList.Columns("Sms Failed").Width = 75
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call LoadUpload()
    End Sub

    Private Sub LoadUpload()
        If cboUpload.SelectedIndex <> -1 Then
            Call LoadUploadedList(Val(cboUpload.SelectedValue.ToString()))
        Else
            If dgvList.Rows.Count > 0 Then dgvList.Columns.Clear()
        End If
    End Sub

    Private Sub cboUpload_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUpload.SelectedIndexChanged
        Call LoadUpload()
    End Sub

    Private Function SendSms(ByVal TranId As Long, ByVal MobileNo As String, ByVal SmsTxt As String, ByVal SenderCode As String, ByVal SmsTemplateId As String) As Integer
        Dim wb As New WebClient
        'Dim url = "https://www.smsgatewayhub.com/api/mt/SendSMS?APIKey=heYy2TmZoEmWpIGRbusETw&senderid=GNSAIN&channel=2&DCS=0&flashsms=0&number=919600016921&text=Test SMS&route=1"
        'Dim url = msSmsUrl & "APIKey=" & msSmsApiKey & "&senderid=" & SenderCode & "&channel=2&DCS=0&flashsms=0&number=" & MobileNo & "&text=" & SmsTxt & "&route=" & msSmsRouteId

        'Dim url = "http://push.smsc.co.in/api/mt/SendSMS?APIkey=PJA3OFO9pkqgQx8s44AqsA&senderid=GNSAIN&channel=Trans&DCS=0&flashsms=0&number=919940140410&text=smstxt&route=47&dlttemplateid=GNSAIN"
        Dim url = msSmsUrl & "APIKey=" & msSmsApiKey & "&senderid=" & SenderCode & "&channel=Trans&DCS=0&flashsms=0&number=" & MobileNo & "&text=" & SmsTxt & "&route=" & msSmsRouteId & "&DLTTemplateId=" & SmsTemplateId

        Dim ss As Stream
        Dim sr As StreamReader
        Dim s As String

        Dim lnResult As Integer
        Dim lsTxt As String
        Dim lsErrCode As String
        Dim lsJobId As String
        Dim lnSmsStatus As Integer
        Dim lnDeliveredStatus As Integer

        ss = wb.OpenRead(url)
        sr = New StreamReader(ss)
        s = sr.ReadToEnd()
        sr.Close()

        lsErrCode = JObject.Parse(s)("ErrorCode")

        If lsErrCode = "000" Then
            lnSmsStatus = gnSmsDelivered
            lnDeliveredStatus = 1
        Else
            lnSmsStatus = gnSmsFailed
            lnDeliveredStatus = 0
        End If

        lsJobId = JObject.Parse(s)("JobId")

        ' delete upload
        Using cmd As New MySqlCommand("pr_upd_smssend", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?in_tran_gid", TranId)
            cmd.Parameters.AddWithValue("?in_sms_status", lnSmsStatus)
            cmd.Parameters.AddWithValue("?in_err_code", lsErrCode)
            cmd.Parameters.AddWithValue("?in_job_id", lsJobId)

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
                Return 0
            End If
        End Using

        Return lnDeliveredStatus
    End Function

    Private Sub dgvList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        Dim lnSenderId As Long = 0
        Dim lnUploadId As Long = 0
        Dim frm As frmTranReport

        If e.RowIndex >= 0 Then
            If dgvList.Columns(e.ColumnIndex).Name = "View" Then
                lnUploadId = dgvList.Rows(e.RowIndex).Cells("upload_gid").Value
                lnSenderId = dgvList.Rows(e.RowIndex).Cells("sender_gid").Value

                frm = New frmTranReport(lnSenderId, lnUploadId)
                frm.ShowDialog()
            End If
        End If
    End Sub
End Class