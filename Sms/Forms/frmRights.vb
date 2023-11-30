Public Class frmRights
#Region "Local Declaration"
#End Region
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub frmRights_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        Dim lsSql As String

        KeyPreview = True
        CancelButton = btnCancel

        lsSql = ""
        lsSql &= " select usergroup_name,usergroup_gid from soft_mst_tusergroup "
        lsSql &= " where delete_flag = 'N' "
        lsSql &= " order by usergroup_gid"

        Call gpBindCombo(lsSql, "usergroup_name", "usergroup_gid", cboUserGrp, gOdbcConn)

        Call LoadTreeView()
    End Sub

    Private Sub cboUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUserGrp.Click
        If cboUserGrp.SelectedIndex <> -1 Then
            Call LoadUserGrp(Val(cboUserGrp.SelectedValue.ToString))
        End If
    End Sub

    Private Sub cboUser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUserGrp.TextChanged
        If cboUserGrp.Text <> "" And cboUserGrp.SelectedIndex = -1 Then gpAutoFillCombo(cboUserGrp)

        Call cboUser_Click(sender, e)
    End Sub

    Private Sub LoadUserGrp(ByVal UserGrpId As Long)
        Dim i As Integer

        With tvwRights
            For i = 0 To .Nodes.Count - 1
                LoadSubNode(.Nodes(i), UserGrpId)
            Next i
        End With
    End Sub

    'To Clear control in a form
    Private Sub LoadTreeView()
        Dim i As Integer
        Dim ms As New MenuStrip

        tvwRights.Nodes.Clear()
        ms = frmMain.MenuStrip

        For i = 0 To ms.Items.Count - 1
            Application.DoEvents()

            tvwRights.Nodes.Add(ms.Items(i).Name, ms.Items(i).Text.Replace("&", ""), 1)
            tvwRights.ExpandAll()

            LoadSubMenuItems(ms.Items(i))
        Next i
    End Sub
    Private Sub LoadSubMenuItems(ByVal mnu As ToolStripMenuItem)
        Dim i As Integer

        If mnu.DropDownItems.Count > 0 Then
            For i = 0 To mnu.DropDownItems.Count - 1
                If mnu.DropDownItems.Item(i).Text <> "" Then
                    Application.DoEvents()
                    'Threading.Thread.Sleep(100)

                    tvwRights.Nodes.Find(mnu.Name, True)(0).Nodes.Add(mnu.DropDownItems(i).Name, mnu.DropDownItems(i).Text.Replace("&", ""), 2)
                    tvwRights.ExpandAll()

                    LoadSubMenuItems(mnu.DropDownItems.Item(i))
                End If
            Next i
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lsSql As String
        Dim lnUserGrpId As Long
        Dim i As Integer
        Dim lnResult As Long

        Try
            Call gpAutoFillCombo(cboUserGrp)

            If cboUserGrp.Text = "" Or cboUserGrp.SelectedIndex = -1 Then
                MsgBox("Please select user group !", MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If

            lnUserGrpId = Val(cboUserGrp.SelectedValue.ToString)

            If lnUserGrpId > 0 Then
                lsSql = ""
                lsSql &= " delete from soft_mst_trights "
                lsSql &= " where usergroup_gid = '" & lnUserGrpId & "' "
                lsSql &= " and delete_flag = 'N' "

                lnResult = gfInsertQry(lsSql, gOdbcConn)

                With tvwRights
                    For i = 0 To .Nodes.Count - 1
                        Call InsertSubNode(.Nodes(i), lnUserGrpId)
                    Next i
                End With

                MsgBox("Saved successfully !", MsgBoxStyle.Information, gsProjectName)

                cboUserGrp.Text = ""
                Call LoadTreeView()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub InsertSubNode(ByVal e As TreeNode, ByVal UserGrpId As Long)
        Dim i As Integer
        Dim lsSql As String
        Dim lsMnuName As String
        Dim lnRights As Integer
        Dim lnResult As Long

        lsMnuName = e.Name

        If e.Checked = True Then
            lnRights = 1
        Else
            lnRights = 0
        End If

        lsSql = ""
        lsSql &= " insert into soft_mst_trights (menu_name,rights_flag,usergroup_gid) values ("
        lsSql &= " '" & lsMnuName & "',"
        lsSql &= " '" & lnRights & "',"
        lsSql &= " '" & UserGrpId & "')"

        lnResult = gfInsertQry(lsSql, gOdbcConn)

        For i = 0 To e.Nodes.Count - 1
            If e.Nodes(i).Nodes.Count > 0 Then
                Call InsertSubNode(e.Nodes(i), UserGrpId)
            Else
                lsMnuName = e.Nodes(i).Name

                If e.Nodes(i).Checked = True Then
                    lnRights = 1
                Else
                    lnRights = 0
                End If

                lsSql = ""
                lsSql &= " insert into soft_mst_trights (menu_name,rights_flag,usergroup_gid) values ("
                lsSql &= " '" & lsMnuName & "',"
                lsSql &= " '" & lnRights & "',"
                lsSql &= " '" & UserGrpId & "')"

                lnResult = gfInsertQry(lsSql, gOdbcConn)
            End If
        Next i
    End Sub

    Private Sub LoadSubNode(ByVal e As TreeNode, ByVal UserGrpId As Long)
        Dim i As Integer
        Dim lsSql As String
        Dim lsMnuName As String
        Dim lnRights As Integer

        lsMnuName = e.Name

        lsSql = ""
        lsSql &= " select rights_flag from soft_mst_trights "
        lsSql &= " where usergroup_gid = '" & UserGrpId & "' "
        lsSql &= " and menu_name = '" & lsMnuName & "' "
        lsSql &= " and delete_flag = 'N' "

        lnRights = Val(gfExecuteScalar(lsSql, gOdbcConn))

        If lnRights = 1 Then
            e.Checked = True
        Else
            e.Checked = False
        End If

        For i = 0 To e.Nodes.Count - 1
            If e.Nodes(i).Nodes.Count > 0 Then
                LoadSubNode(e.Nodes(i), UserGrpId)
            Else
                lsMnuName = e.Nodes(i).Name

                lsSql = ""
                lsSql &= " select rights_flag from soft_mst_trights "
                lsSql &= " where usergroup_gid = '" & UserGrpId & "' "
                lsSql &= " and menu_name = '" & lsMnuName & "' "
                lsSql &= " and delete_flag = 'N' "

                lnRights = Val(gfExecuteScalar(lsSql, gOdbcConn))

                If lnRights = 1 Then
                    e.Nodes(i).Checked = True
                Else
                    e.Nodes(i).Checked = False
                End If
            End If
        Next i
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        Dim i As Integer
        Try
            With tvwRights
                For i = 0 To .Nodes.Count - 1
                    .Nodes(i).Checked = chkSelectAll.Checked
                    lf_CheckSubNodes(.Nodes(i), chkSelectAll.Checked)
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Select All Sub Procedure
    Private Sub lf_CheckSubNodes(ByVal e As TreeNode, ByVal lb_Checked As Boolean)
        Dim k As Integer
        Try
            For k = 0 To e.Nodes.Count - 1
                e.Nodes(k).Checked = chkSelectAll.Checked
                lf_CheckSubNodes(e.Nodes(k), chkSelectAll.Checked)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Single Select Sub Procedure
    Private Sub lf_SingleCheckSubNodes(ByVal e As TreeNode, ByVal lb_Checked As Boolean)
        Dim k As Integer
        Try
            For k = 0 To e.Nodes.Count - 1
                e.Nodes(k).Checked = lb_Checked
                lf_SingleCheckSubNodes(e.Nodes(k), lb_Checked)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tvwRights_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvwRights.DoubleClick
        Dim i As Integer
        Try
            With tvwRights
                If .SelectedNode.Nodes.Count <> 0 Then
                    If .SelectedNode.Checked = True Then
                        .SelectedNode.Checked = False
                        For i = 0 To .SelectedNode.Nodes.Count - 1
                            If .SelectedNode.Checked = False Then
                                .SelectedNode.Nodes(i).Checked = False                                              ' Sub Menu in Main Menu 
                                lf_SingleCheckSubNodes(.SelectedNode.Nodes(i), .SelectedNode.Nodes(i).Checked)      ' Sub Menu in Sub Menu
                            End If
                        Next
                    Else
                        If .SelectedNode.Checked = False Then
                            .SelectedNode.Checked = True
                            For i = 0 To .SelectedNode.Nodes.Count - 1
                                If .SelectedNode.Checked = True Then
                                    .SelectedNode.Nodes(i).Checked = True
                                    lf_SingleCheckSubNodes(.SelectedNode.Nodes(i), .SelectedNode.Nodes(i).Checked)
                                End If
                            Next
                        End If
                    End If
                Else
                    If .SelectedNode.Checked = True Then
                        .SelectedNode.Checked = False
                    Else
                        .SelectedNode.Checked = True
                    End If
                End If
            End With
            tvwRights.ExpandAll()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tvwRights_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwRights.AfterSelect

    End Sub
End Class