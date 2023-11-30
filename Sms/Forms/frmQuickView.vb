Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmQuickView

    Dim mDbCon As MysqlConnection
    Dim msHeaderTxt As String
    Dim msSql As String
    Dim mnWindowState As Integer
    Dim msExportFileName As String

    Private Sub frmQuickView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As DataSet

        If msSql <> "" Then
            ds = gfDataSet(msSql, "quickview", mDbCon)

            With dgvQuickView
                .DataSource = ds.Tables("quickview")
                lblTotRec.Text = "Total Records : " & .RowCount.ToString
            End With

            Me.WindowState = mnWindowState
        End If
    End Sub

    Private Sub frmQuickView_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        With dgvQuickView
            .Left = 6
            .Width = Me.Width - 18
            .Height = Math.Abs(Me.Height - 36 - pnlReport.Height)

            pnlReport.Left = 6
            pnlReport.Width = .Width
            pnlReport.Top = dgvQuickView.Height + 6

            lblTotRec.Left = 6

            btnClose.Left = Math.Abs(pnlReport.Width - btnClose.Width - 8)
            btnExport.Left = Math.Abs(btnClose.Left - btnClose.Width - 6)
        End With
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub New(ByVal dbCon As MySqlConnection, ByVal sqlstr As String, Optional ByVal HeaderTxt As String = "", Optional ByVal WindowState As Integer = FormWindowState.Maximized, Optional ByVal ExportFileName As String = "report.xls")
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mDbCon = dbCon
        msSql = sqlstr
        msHeaderTxt = HeaderTxt
        mnWindowState = WindowState
        msExportFileName = ExportFileName
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Call PrintDGridXML(dgvQuickView, gsReportPath & "\" & msExportFileName, "Report", "", msHeaderTxt)
    End Sub

End Class