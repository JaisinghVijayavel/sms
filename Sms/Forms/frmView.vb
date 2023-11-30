Public Class frmView
    Private Sub frmView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CancelButton = btnClose
    End Sub

    Public Sub New(ByVal txt As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        rtxtView.Text = txt
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class