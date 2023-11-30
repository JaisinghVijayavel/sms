Option Strict On
Option Explicit On

Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmSearch
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cnstring As String, ByVal sqlstr As String, ByVal rawfld As String, ByVal cond As String)
        MyBase.New()

        cnstr = cnstring
        sql = sqlstr
        rawFldName = rawfld
        condition = cond

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        FillCombo()
        gnSearchId = 0
        RefreshGrid(sql & " where " & cond)
    End Sub

    Public Sub New(ByVal cn As MySqlConnection, ByVal sqlstr As String, ByVal rawfld As String, ByVal cond As String)
        MyBase.New()

        con = cn
        sql = sqlstr
        rawFldName = rawfld
        condition = cond

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        FillCombo()
        gnSearchId = 0
        RefreshGrid(sql & " where " & cond)
    End Sub

#End Region
    Dim cnstr As String
    Dim sql As String
    Dim rawFldName As String
    Dim condition As String
    Dim con As MySqlConnection

    Private Sub FillCombo()
        ' Fill Condition
        With cboCondition
            .Items.Clear()
            .Items.Add("Like")
            .Items.Add("Not Like")
            .Items.Add("=")
            .Items.Add(">")
            .Items.Add(">=")
            .Items.Add("<")
            .Items.Add("<=")
            .Items.Add("<>")
            .SelectedIndex = 0
        End With
    End Sub

    'Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
    '    With dgvReport
    '        pnlInput.Top = 12
    '        pnlInput.Left = 12

    '        .Left = 12

    '        .Top = Math.Abs(pnlInput.Top + pnlInput.Height + 14)
    '        .Height = Math.Abs(Me.Height - .Top - 65)
    '        .Width = Math.Abs(Me.Width - 24)
    '    End With
    'End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim cond As String = " where " & condition
        Dim fld() As String = Split(rawFldName, ",")

        txtSearch.Text = txtSearch.Text.Trim()

        If cboFld.Text <> "" And txtSearch.Text <> "" And cboCondition.Text <> "" Then
            If condition = "" Then
                cond = " where " & fld(cboFld.Items.IndexOf(cboFld.Text)) & " "
            Else
                cond &= " and " & fld(cboFld.Items.IndexOf(cboFld.Text)) & " "
            End If

            Select Case UCase(cboCondition.Text)
                Case "LIKE", "NOT LIKE"
                    cond = cond & " " & cboCondition.Text & " '" & txtSearch.Text & "%' "
                Case ""
                    cond = ""
                Case Else
                    cond = cond & " " & cboCondition.Text & " '" & txtSearch.Text & "' "
            End Select
        End If

        Call RefreshGrid(sql & cond)
    End Sub

    Private Sub RefreshGrid(ByVal sqlstr As String)
        Dim cn As MySqlConnection
        Dim cmd As New MySqlCommand
        Dim adp As New MySqlDataAdapter
        Dim ds As New DataSet
        Dim i As Integer

        If con.State = ConnectionState.Open Then
            cn = con
        ElseIf cnstr <> "" Then
            cn = New MySqlConnection(cnstr)
            cn.Open()
        Else
            Exit Sub
        End If

        gpDataSet(sqlstr, "search", cn, ds)
        dgvReport.DataSource = ds.Tables("search")

        txtTotRec.Text = "Total Records : " & dgvReport.Rows.Count

        ' Add column name
        If cboFld.Items.Count = 0 Then
            For i = 0 To ds.Tables("search").Columns.Count - 1
                cboFld.Items.Add(ds.Tables("search").Columns(i).ColumnName)
                dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            cboFld.SelectedIndex = 0
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        btnSearch.PerformClick()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim i As Integer

        If dgvReport.RowCount > 0 Then
            i = dgvReport.CurrentRow.Index
            gnSearchId = CLng(Val(dgvReport.Item(0, i).Value.ToString()))
        Else
            gnSearchId = 0
        End If

        MyBase.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        MyBase.Close()
    End Sub

    Private Sub dgvReport_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvReport.DoubleClick
        btnOk.PerformClick()
    End Sub

    Private Sub dgvReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvReport.KeyDown
        If e.KeyCode = 13 Then
            btnOk.PerformClick()
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If dgvReport.Rows.Count > 0 Then
            PrintDGridXML(dgvReport, gsReportPath & "\report.xls", "Report")
        End If
    End Sub

    Private Sub Search_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        pnlInput.Top = 6
        pnlInput.Left = 6

        dgvReport.Top = pnlInput.Top + pnlInput.Height + 6
        dgvReport.Left = 6
        dgvReport.Height = Math.Abs(Me.Height - dgvReport.Top - pnlDecision.Height - 36)
        dgvReport.Width = Me.Width - 18

        pnlDecision.Top = dgvReport.Top + dgvReport.Height + 6
        pnlDecision.Left = Math.Abs(dgvReport.Left + dgvReport.Width \ 2 - pnlDecision.Width \ 2)

        txtTotRec.Top = Math.Abs(pnlDecision.Top + pnlDecision.Height \ 2 - txtTotRec.Height \ 2)
        txtTotRec.Left = 6
    End Sub

    Private Sub Search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
