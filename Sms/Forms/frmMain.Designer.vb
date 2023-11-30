<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.mnuAdmin = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUserCreation = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUserGrp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUserGrpRights = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUserAuth = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUserAuthRpt = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUserLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem28 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuServerConfiguration = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSenderMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuXlTemplate = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMSTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFldConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTran = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImpFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuImpDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUpload = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGenUpload = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDelSmsUpload = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSendSms = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRptImported = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSmsTranReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRptFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRptImpErrLine = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUploadReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMis = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSmsReceived = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAdmin, Me.mnuMaintenance, Me.mnuTran, Me.mnuReport, Me.WindowsMenu, Me.mnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(1140, 24)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip"
        '
        'mnuAdmin
        '
        Me.mnuAdmin.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUserCreation, Me.SetPasswordToolStripMenuItem, Me.ToolStripMenuItem9, Me.mnuUserGrp, Me.mnuUserGrpRights, Me.ToolStripMenuItem10, Me.mnuUserAuth, Me.mnuUserAuthRpt, Me.mnuUserLog, Me.ToolStripMenuItem28, Me.mnuServerConfiguration})
        Me.mnuAdmin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuAdmin.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.mnuAdmin.Name = "mnuAdmin"
        Me.mnuAdmin.Size = New System.Drawing.Size(55, 20)
        Me.mnuAdmin.Text = "Admin"
        '
        'mnuUserCreation
        '
        Me.mnuUserCreation.Name = "mnuUserCreation"
        Me.mnuUserCreation.Size = New System.Drawing.Size(191, 22)
        Me.mnuUserCreation.Text = "User Creation"
        '
        'SetPasswordToolStripMenuItem
        '
        Me.SetPasswordToolStripMenuItem.Name = "SetPasswordToolStripMenuItem"
        Me.SetPasswordToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.SetPasswordToolStripMenuItem.Text = "Set Password"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(188, 6)
        '
        'mnuUserGrp
        '
        Me.mnuUserGrp.Name = "mnuUserGrp"
        Me.mnuUserGrp.Size = New System.Drawing.Size(191, 22)
        Me.mnuUserGrp.Text = "User Group"
        '
        'mnuUserGrpRights
        '
        Me.mnuUserGrpRights.Name = "mnuUserGrpRights"
        Me.mnuUserGrpRights.Size = New System.Drawing.Size(191, 22)
        Me.mnuUserGrpRights.Text = "User Group Rights"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(188, 6)
        '
        'mnuUserAuth
        '
        Me.mnuUserAuth.Name = "mnuUserAuth"
        Me.mnuUserAuth.Size = New System.Drawing.Size(191, 22)
        Me.mnuUserAuth.Text = "User Auth"
        '
        'mnuUserAuthRpt
        '
        Me.mnuUserAuthRpt.Name = "mnuUserAuthRpt"
        Me.mnuUserAuthRpt.Size = New System.Drawing.Size(191, 22)
        Me.mnuUserAuthRpt.Text = "User Auth Report"
        '
        'mnuUserLog
        '
        Me.mnuUserLog.Name = "mnuUserLog"
        Me.mnuUserLog.Size = New System.Drawing.Size(191, 22)
        Me.mnuUserLog.Text = "User Log"
        '
        'ToolStripMenuItem28
        '
        Me.ToolStripMenuItem28.Name = "ToolStripMenuItem28"
        Me.ToolStripMenuItem28.Size = New System.Drawing.Size(188, 6)
        '
        'mnuServerConfiguration
        '
        Me.mnuServerConfiguration.Name = "mnuServerConfiguration"
        Me.mnuServerConfiguration.Size = New System.Drawing.Size(191, 22)
        Me.mnuServerConfiguration.Text = "Server Configuration"
        '
        'mnuMaintenance
        '
        Me.mnuMaintenance.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSenderMaster, Me.mnuXlTemplate, Me.SMSTemplateToolStripMenuItem, Me.mnuFldConfig})
        Me.mnuMaintenance.Name = "mnuMaintenance"
        Me.mnuMaintenance.Size = New System.Drawing.Size(92, 20)
        Me.mnuMaintenance.Text = "Maintenance"
        '
        'mnuSenderMaster
        '
        Me.mnuSenderMaster.Name = "mnuSenderMaster"
        Me.mnuSenderMaster.Size = New System.Drawing.Size(155, 22)
        Me.mnuSenderMaster.Text = "Sender"
        '
        'mnuXlTemplate
        '
        Me.mnuXlTemplate.Name = "mnuXlTemplate"
        Me.mnuXlTemplate.Size = New System.Drawing.Size(155, 22)
        Me.mnuXlTemplate.Text = "XL Template"
        '
        'SMSTemplateToolStripMenuItem
        '
        Me.SMSTemplateToolStripMenuItem.Name = "SMSTemplateToolStripMenuItem"
        Me.SMSTemplateToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.SMSTemplateToolStripMenuItem.Text = "Sms Template"
        '
        'mnuFldConfig
        '
        Me.mnuFldConfig.Name = "mnuFldConfig"
        Me.mnuFldConfig.Size = New System.Drawing.Size(155, 22)
        Me.mnuFldConfig.Text = "Field Mapping"
        '
        'mnuTran
        '
        Me.mnuTran.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuImport, Me.ToolStripMenuItem3, Me.mnuUpload, Me.mnuSendSms})
        Me.mnuTran.Name = "mnuTran"
        Me.mnuTran.Size = New System.Drawing.Size(86, 20)
        Me.mnuTran.Text = "Transaction"
        '
        'mnuImport
        '
        Me.mnuImport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuImpFile, Me.ToolStripMenuItem1, Me.mnuImpDelete})
        Me.mnuImport.Name = "mnuImport"
        Me.mnuImport.Size = New System.Drawing.Size(152, 22)
        Me.mnuImport.Text = "Import"
        '
        'mnuImpFile
        '
        Me.mnuImpFile.Name = "mnuImpFile"
        Me.mnuImpFile.Size = New System.Drawing.Size(152, 22)
        Me.mnuImpFile.Text = "File"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
        '
        'mnuImpDelete
        '
        Me.mnuImpDelete.Name = "mnuImpDelete"
        Me.mnuImpDelete.Size = New System.Drawing.Size(152, 22)
        Me.mnuImpDelete.Text = "Delete"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(149, 6)
        '
        'mnuUpload
        '
        Me.mnuUpload.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGenUpload, Me.ToolStripMenuItem5, Me.mnuDelSmsUpload})
        Me.mnuUpload.Name = "mnuUpload"
        Me.mnuUpload.Size = New System.Drawing.Size(152, 22)
        Me.mnuUpload.Text = "Upload"
        '
        'mnuGenUpload
        '
        Me.mnuGenUpload.Name = "mnuGenUpload"
        Me.mnuGenUpload.Size = New System.Drawing.Size(196, 22)
        Me.mnuGenUpload.Text = "Generate Sms Upload"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(193, 6)
        '
        'mnuDelSmsUpload
        '
        Me.mnuDelSmsUpload.Name = "mnuDelSmsUpload"
        Me.mnuDelSmsUpload.Size = New System.Drawing.Size(196, 22)
        Me.mnuDelSmsUpload.Text = "Delete Sms Upload"
        '
        'mnuSendSms
        '
        Me.mnuSendSms.Name = "mnuSendSms"
        Me.mnuSendSms.Size = New System.Drawing.Size(152, 22)
        Me.mnuSendSms.Text = "Send Sms"
        '
        'mnuReport
        '
        Me.mnuReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRptImported, Me.ToolStripMenuItem2, Me.mnuUploadReport, Me.mnuMis})
        Me.mnuReport.Name = "mnuReport"
        Me.mnuReport.Size = New System.Drawing.Size(58, 20)
        Me.mnuReport.Text = "Report"
        '
        'mnuRptImported
        '
        Me.mnuRptImported.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSmsTranReport, Me.ToolStripMenuItem11, Me.mnuRptFile, Me.mnuRptImpErrLine})
        Me.mnuRptImported.Name = "mnuRptImported"
        Me.mnuRptImported.Size = New System.Drawing.Size(152, 22)
        Me.mnuRptImported.Text = "Imported"
        '
        'mnuSmsTranReport
        '
        Me.mnuSmsTranReport.Name = "mnuSmsTranReport"
        Me.mnuSmsTranReport.Size = New System.Drawing.Size(152, 22)
        Me.mnuSmsTranReport.Text = "Sms"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(149, 6)
        '
        'mnuRptFile
        '
        Me.mnuRptFile.Name = "mnuRptFile"
        Me.mnuRptFile.Size = New System.Drawing.Size(152, 22)
        Me.mnuRptFile.Text = "File"
        '
        'mnuRptImpErrLine
        '
        Me.mnuRptImpErrLine.Name = "mnuRptImpErrLine"
        Me.mnuRptImpErrLine.Size = New System.Drawing.Size(152, 22)
        Me.mnuRptImpErrLine.Text = "Error Line"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(149, 6)
        '
        'mnuUploadReport
        '
        Me.mnuUploadReport.Name = "mnuUploadReport"
        Me.mnuUploadReport.Size = New System.Drawing.Size(152, 22)
        Me.mnuUploadReport.Text = "Upload"
        '
        'mnuMis
        '
        Me.mnuMis.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSmsReceived})
        Me.mnuMis.Name = "mnuMis"
        Me.mnuMis.Size = New System.Drawing.Size(152, 22)
        Me.mnuMis.Text = "Mis"
        '
        'mnuSmsReceived
        '
        Me.mnuSmsReceived.Name = "mnuSmsReceived"
        Me.mnuSmsReceived.Size = New System.Drawing.Size(153, 22)
        Me.mnuSmsReceived.Text = "Sms Received"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(69, 20)
        Me.WindowsMenu.Text = "&Windows"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.CascadeToolStripMenuItem.Text = "&Cascade"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.TileVerticalToolStripMenuItem.Text = "Tile &Vertical"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.CloseAllToolStripMenuItem.Text = "C&lose All"
        '
        'ArrangeIconsToolStripMenuItem
        '
        Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
        Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ArrangeIconsToolStripMenuItem.Text = "&Arrange Icons"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(40, 20)
        Me.mnuExit.Text = "Exit"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1140, 22)
        Me.StatusStrip.TabIndex = 2
        Me.StatusStrip.Text = "StatusStrip"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 17)
        Me.lblStatus.Text = "Status"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1140, 453)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "SMS Management System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdmin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRptImported As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRptFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRptImpErrLine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUploadReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSmsTranReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUserCreation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetPasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuUserGrp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUserGrpRights As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuUserAuth As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUserAuthRpt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUserLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuServerConfiguration As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaintenance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSenderMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuXlTemplate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SMSTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFldConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTran As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuImpFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuImpDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuUpload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGenUpload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDelSmsUpload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSendSms As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuMis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSmsReceived As System.Windows.Forms.ToolStripMenuItem

End Class
