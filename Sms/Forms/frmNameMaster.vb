Option Explicit On 
Imports MySql.Data.MySqlClient

Public Class frmNameMaster
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal TbName As String, ByVal PkFldName As String, ByVal PkFldDesc As String, ByVal FldName As String, _
                   ByVal FldDesc As String, ByVal FldLen As Integer, ByVal IsRemovedFldName As String, ByVal LblCaption As String, ByVal FrmCaption As String, _
                   ByVal FkTbName As String, ByVal FkFldName As String, ByVal FkPkFlag As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Me.Text = FrmCaption
        lblName.Text = LblCaption
        msTbName = TbName
        msPkFldName = PkFldName
        msFldName = FldName
        msPkFldDesc = PkFldDesc
        msFldDesc = FldDesc

        msIsRemovedFldName = IsRemovedFldName

        msFkTbName = FkTbName
        msFkFldName = FkFldName
        mbFkPkFlag = FkPkFlag

        txtName.MaxLength = FldLen
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlSave As System.Windows.Forms.Panel
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNameMaster))
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlSave = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.pnlSave.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.SystemColors.Control
        Me.btnNew.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNew.Location = New System.Drawing.Point(1, 1)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(72, 24)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(2, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pnlSave
        '
        Me.pnlSave.Controls.Add(Me.btnCancel)
        Me.pnlSave.Controls.Add(Me.btnSave)
        Me.pnlSave.Location = New System.Drawing.Point(133, 65)
        Me.pnlSave.Name = "pnlSave"
        Me.pnlSave.Size = New System.Drawing.Size(152, 28)
        Me.pnlSave.TabIndex = 33
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(80, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnFind)
        Me.pnlButtons.Controls.Add(Me.btnDelete)
        Me.pnlButtons.Controls.Add(Me.btnEdit)
        Me.pnlButtons.Controls.Add(Me.btnNew)
        Me.pnlButtons.Location = New System.Drawing.Point(15, 65)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(389, 28)
        Me.pnlButtons.TabIndex = 34
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(313, 1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "C&lose"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.SystemColors.Control
        Me.btnFind.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFind.Location = New System.Drawing.Point(157, 1)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(72, 24)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "&Find"
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelete.Location = New System.Drawing.Point(235, 1)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(79, 1)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(72, 24)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.txtName)
        Me.pnlMain.Controls.Add(Me.lblName)
        Me.pnlMain.Location = New System.Drawing.Point(8, 8)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(406, 50)
        Me.pnlMain.TabIndex = 35
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(127, 12)
        Me.txtName.MaxLength = 64
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(263, 21)
        Me.txtName.TabIndex = 3
        '
        'lblName
        '
        Me.lblName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblName.Location = New System.Drawing.Point(10, 14)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(111, 13)
        Me.lblName.TabIndex = 55
        Me.lblName.Text = "A/C Type Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(8, 64)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(11, 21)
        Me.txtId.TabIndex = 60
        Me.txtId.Visible = False
        '
        'frmNameMaster
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(418, 100)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlSave)
        Me.Controls.Add(Me.pnlButtons)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNameMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "A/C Type Master"
        Me.pnlSave.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim msSQL As String
    Dim mnResult As Integer

    Dim msFrmCaption As String
    Dim msLblCaption As String
    Dim msTbName As String
    Dim msPkFldName As String
    Dim msFldName As String
    Dim msPkFldDesc As String
    Dim msFldDesc As String
    Dim mnFldLen As String
    Dim msIsRemovedFldName As String
    Dim msFkTbName As String
    Dim msFkFldName As String
    Dim mbFkPkFlag As Boolean

    Private Sub EnableSave(ByVal Status As Boolean)
        pnlButtons.Visible = Not Status
        pnlSave.Visible = Status
        pnlMain.Enabled = Status
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        EnableSave(True)
        txtName.Text = ""
        txtId.Text = ""
        txtName.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lsSQL As String = ""
        Dim lsAccTypeName As String = ""

        Try
            If txtName.Text = "" Then
                MsgBox("Enter " & msFldDesc, MsgBoxStyle.Information)
                txtName.Focus()
                Exit Sub
            End If

            msSQL = ""
            lsAccTypeName = QuoteFilter(txtName.Text).ToUpper

            If txtId.Text = "" Then
                msSQL &= " insert into " & msTbName & " ( " & msFldName & " ) "
                msSQL &= " values ('" & lsAccTypeName & "')"

                lsSQL &= " select " & msPkFldName & " from " & msTbName & " "
                lsSQL &= " where " & msFldName & " = '" & lsAccTypeName & "' "
                lsSQL &= " and " & msIsRemovedFldName & "='N'"
            Else
                msSQL &= " update " & msTbName & " set "
                msSQL &= " " & msFldName & " = '" & QuoteFilter(txtName.Text).ToUpper & "' "
                msSQL &= " where " & msPkFldName & " = " & txtId.Text & " "
                msSQL &= " and " & msIsRemovedFldName & "='N' "

                lsSQL &= " select " & msPkFldName & " from " & msTbName & " "
                lsSQL &= " where " & msFldName & " = '" & lsAccTypeName & "' "
                lsSQL &= " and " & msPkFldName & " <> '" & txtId.Text & "' "
                lsSQL &= " and " & msIsRemovedFldName & "='N'"
            End If

            ' Duplicate Check
            If gfExecuteQryBln(lsSQL, gOdbcConn) = False Then
                mnResult = gfInsertQry(msSQL, gOdbcConn)

                If mnResult > 0 Then
                    MsgBox("Record saved successfully !", MsgBoxStyle.Information, gsProjectName)
                End If

                If MsgBox("Do you want to insert new record ?", MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                    Call btnNew_Click(sender, e)
                Else
                    txtName.Text = ""
                    txtId.Text = ""
                    EnableSave(False)
                    btnNew.Focus()
                End If
            Else
                MsgBox("Duplicate A/C Type Name !", MsgBoxStyle.Critical, gsProjectName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtBankName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            If txtId.Text = "" Then
                If MsgBox("Do you want to select the record ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
                    'Calling Find Button to select record
                    Call btnFind_Click(sender, e)
                    EnableSave(False)
                End If
            Else
                EnableSave(True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim SearchDialog As frmSearch
        Try
            SearchDialog = New frmSearch(gOdbcConn, _
                             " SELECT " & msPkFldName & " as '" & msPkFldDesc & "'," & _
                             " " & msFldName & " as '" & msFldDesc & "' FROM " & msTbName & " ", _
                             " " & msPkFldName & "," & msFldName & "", _
                             " 1 = 1 and " & msIsRemovedFldName & "='N'")

            SearchDialog.ShowDialog()

            If gnSearchId <> 0 Then
                Call ListAll("select * from " & msTbName & " " _
                    & "where " & msPkFldName & " = " & gnSearchId & " " _
                    & "and " & msIsRemovedFldName & "='N'", gOdbcConn)
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListAll(ByVal gsQry As String, ByVal odbcConn As MySqlConnection)
        Dim ds As New DataSet

        Try
            ds = gfDataSet(gsQry, msTbName, gOdbcConn)

            txtId.Text = Val(ds.Tables(msTbName).Rows(0).Item(msPkFldName)).ToString
            txtName.Text = ds.Tables(msTbName).Rows(0).Item(msFldName).ToString
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If txtId.Text = "" Then
                If MsgBox("Do you want to select the record ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
                    'Calling Find Button to select record
                    btnFind.PerformClick()
                End If
            Else
                EnableSave(True)
                If MsgBox("Are you sure to delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
                    gsQry = ""
                    gsQry &= " update " & msTbName & " set " & msIsRemovedFldName & " = 'Y' "
                    gsQry &= " where " & msPkFldName & " = " & txtId.Text

                    mnResult = gfInsertQry(gsQry, gOdbcConn)

                    If mnResult > 0 Then
                        MsgBox("Record Deleted Successfully !!", MsgBoxStyle.Information, gsProjectName)
                    End If

                    txtName.Text = ""
                    txtId.Text = ""
                    EnableSave(False)
                Else
                    txtName.Text = ""
                    txtId.Text = ""
                    EnableSave(False)
                End If
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        EnableSave(False)
        txtName.Text = ""
        txtId.Text = ""
        btnNew.Focus()
    End Sub

    Private Sub frmNameMaster_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub frmAcTypeMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnableSave(False)
        btnNew.Focus()
    End Sub
End Class
