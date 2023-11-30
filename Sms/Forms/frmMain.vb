Imports System.Windows.Forms
Imports MySql.Data
Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient

Public Class frmMain
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ms As New MenuStrip

        Try
            Call Main()

            If gnLoginUserId > 0 Then
                ms = Me.MenuStrip

                For i = 0 To ms.Items.Count - 1
                    Application.DoEvents()
                    Call LoadSubMenuItems(ms.Items(i))
                Next i
            End If

            Me.WindowState = FormWindowState.Maximized

            Me.Visible = True
            lblStatus.Text = ""

            Me.Text = Me.Text & " " & Application.ProductVersion
        Catch ex As Exception
            MessageBox.Show(ex.Message, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSubMenuItems(ByVal mnu As ToolStripMenuItem)
        Dim i As Integer
        Dim dt As New DataTable()
        Dim lnResult As Long = 0

        Try
            Using cmd As New MySqlCommand("pr_get_menuaccess", gOdbcConn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("?in_menu_name", mnu.Name)
                cmd.Parameters("?in_menu_name").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?in_user_gid", gnLoginUserId)
                cmd.Parameters("?in_user_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?in_usergroup_gid", gnLoginUserGrpId)
                cmd.Parameters("?in_usergroup_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?in_user_code", gsLoginUserCode)
                cmd.Parameters("?in_user_code").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?in_pwd", gsLoginUserPwd)
                cmd.Parameters("?in_pwd").Direction = ParameterDirection.Input

                Using sda As New MySqlDataAdapter(cmd)
                    sda.Fill(dt)
                End Using

                With dt
                    lnResult = 0

                    If .Rows.Count > 0 Then
                        lnResult = Val(.Rows(0).Item(0).ToString())
                    End If
                End With
            End Using

            'lsSql = ""
            'lsSql &= " select count(*) from soft_mst_trights "
            'lsSql &= " where usergroup_gid = '" & gnLoginUserGrpId & "' "
            'lsSql &= " and menu_name = '" & mnu.Name & "' "
            'lsSql &= " and rights_flag = 1 "
            'lsSql &= " and delete_flag = 'N' "

            'lsSql = ""
            'lsSql &= " select count(*) from soft_mst_trights as a "
            'lsSql &= " inner join soft_mst_tuser as b on a.usergroup_gid = b.usergroup_gid "
            'lsSql &= " and a.user_code = '" & gsLoginUserCode & "' "
            'lsSql &= " and a.delete_flag = 'N' "
            'lsSql &= " where a.usergroup_gid = '" & gnLoginUserGrpId & "' "
            'lsSql &= " and a.menu_name = '" & mnu.Name & "' "
            'lsSql &= " and a.rights_flag = 1 "
            'lsSql &= " and a.delete_flag = 'N' "

            'lnCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

            If lnResult > 0 Then
                If mnu.DropDownItems.Count > 0 Then
                    For i = 0 To mnu.DropDownItems.Count - 1
                        If mnu.DropDownItems.Item(i).Text <> "" Then
                            Application.DoEvents()
                            LoadSubMenuItems(mnu.DropDownItems.Item(i))
                        End If
                    Next i
                End If
            Else
                mnu.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisableSubMenuItems(ByVal mnu As ToolStripMenuItem)
        Dim i As Integer

        Try
            mnu.Enabled = False

            If mnu.DropDownItems.Count > 0 Then
                For i = 0 To mnu.DropDownItems.Count - 1
                    If mnu.DropDownItems.Item(i).Text <> "" Then
                        Application.DoEvents()
                        LoadSubMenuItems(mnu.DropDownItems.Item(i))
                    End If
                Next i
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        If MessageBox.Show("Are you sure to exit ?", gsProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            End
        End If
    End Sub

    Private Sub mnuImpDelete_Click(sender As Object, e As EventArgs) Handles mnuImpDelete.Click
        Dim frm As New frmDeleteFile
        frm.ShowDialog()
    End Sub

    Private Sub mnuRptFile_Click(sender As Object, e As EventArgs) Handles mnuRptFile.Click
        Dim frm As New frmFileReport
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuRptImpErrLine_Click(sender As Object, e As EventArgs) Handles mnuRptImpErrLine.Click
        Dim frm As New frmErrLineReport
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuUserCreation_Click(sender As Object, e As EventArgs) Handles mnuUserCreation.Click
        Dim objfrm As New frmUserMaster
        objfrm.ShowDialog()
    End Sub

    Private Sub SetPasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetPasswordToolStripMenuItem.Click
        Dim objfrm As New frmChngPwd
        objfrm.ShowDialog()
    End Sub

    Private Sub mnuUserGrp_Click(sender As Object, e As EventArgs) Handles mnuUserGrp.Click
        Dim objFrm As New frmNameMaster("soft_mst_tusergroup", "usergroup_gid", "User Group Id", "usergroup_name", "Region Name", "32", "delete_flag", "User Group Name", "User Group Master", "", "", False)
        objFrm.ShowDialog()
    End Sub

    Private Sub mnuUserGrpRights_Click(sender As Object, e As EventArgs) Handles mnuUserGrpRights.Click
        Dim objfrm As New frmRights
        objfrm.ShowDialog()
    End Sub

    Private Sub mnuUserAuth_Click(sender As Object, e As EventArgs) Handles mnuUserAuth.Click
        Dim frm As New frmUserAuth
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuUserAuthRpt_Click(sender As Object, e As EventArgs) Handles mnuUserAuthRpt.Click
        Dim frm As New frmUserAuthReport
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuUserLog_Click(sender As Object, e As EventArgs) Handles mnuUserLog.Click
        Dim frm As New frmUserManagementReport
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuServerConfiguration_Click(sender As Object, e As EventArgs) Handles mnuServerConfiguration.Click
        Dim objfrm As New frmServerConfiguration
        objfrm.ShowDialog()
    End Sub

    Private Sub mnuImpFile_Click(sender As Object, e As EventArgs) Handles mnuImpFile.Click
        Dim objfrm As New frmImport
        objfrm.ShowDialog()
    End Sub

    Private Sub mnuSenderMaster_Click(sender As Object, e As EventArgs) Handles mnuSenderMaster.Click
        Dim frm As New frmSenderMaster
        frm.ShowDialog()
    End Sub

    Private Sub mnuXlTemplate_Click(sender As Object, e As EventArgs) Handles mnuXlTemplate.Click
        Dim frm As New frmXlTemplateMaster
        frm.ShowDialog()
    End Sub

    Private Sub SMSTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SMSTemplateToolStripMenuItem.Click
        Dim frm As New frmSmsTemplateMaster
        frm.ShowDialog()
    End Sub

    Private Sub mnuGenUpload_Click(sender As Object, e As EventArgs) Handles mnuGenUpload.Click
        Dim frm As New frmUpload
        frm.ShowDialog()
    End Sub

    Private Sub mnuDelSmsUpload_Click(sender As Object, e As EventArgs) Handles mnuDelSmsUpload.Click
        Dim frm As New frmUploadDelete
        frm.ShowDialog()
    End Sub

    Private Sub mnuUploadReport_Click(sender As Object, e As EventArgs) Handles mnuUploadReport.Click
        Dim frm As New frmUploadReport
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuSmsTranReport_Click(sender As Object, e As EventArgs) Handles mnuSmsTranReport.Click
        Dim frm As New frmTranReport
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuFldConfig_Click(sender As Object, e As EventArgs) Handles mnuFldConfig.Click
        Dim frm As New frmFieldMapping
        frm.ShowDialog()
    End Sub

    Private Sub mnuSendSms_Click(sender As Object, e As EventArgs) Handles mnuSendSms.Click
        Dim frm As New frmSendSms
        frm.ShowDialog()
    End Sub

    Private Sub mnuSmsReceived_Click(sender As Object, e As EventArgs) Handles mnuSmsReceived.Click
        Dim frm As New frmSmsMis
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuReport_Click(sender As Object, e As EventArgs) Handles mnuReport.Click

    End Sub

    Private Sub mnuRptImported_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptImported.Click

    End Sub
End Class