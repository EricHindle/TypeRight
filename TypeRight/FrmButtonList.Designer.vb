<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmButtonList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmButtonList))
        Me.GrpTop = New System.Windows.Forms.GroupBox()
        Me.ImgTack = New System.Windows.Forms.PictureBox()
        Me.cbNames = New System.Windows.Forms.ComboBox()
        Me.BtnReDraw = New System.Windows.Forms.Button()
        Me.mnuPopup = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuButtons = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransferToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOptions1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrpBottom = New System.Windows.Forms.GroupBox()
        Me.WhiteClock = New System.Windows.Forms.PictureBox()
        Me.GreenClock = New System.Windows.Forms.PictureBox()
        Me.imgExit = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.imgOptions = New System.Windows.Forms.PictureBox()
        Me.ImgLock = New System.Windows.Forms.PictureBox()
        Me.RedClock = New System.Windows.Forms.PictureBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.GroupButtonPanel = New System.Windows.Forms.Panel()
        Me.DelayTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TypeRightDataSet = New TypeRight.TypeRightDataSet()
        Me.SenderButtonPanel = New System.Windows.Forms.Panel()
        Me.BtnRmvCol = New System.Windows.Forms.Button()
        Me.BtnAddCol = New System.Windows.Forms.Button()
        Me.GrpTop.SuspendLayout()
        CType(Me.ImgTack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuPopup.SuspendLayout()
        Me.mnuButtons.SuspendLayout()
        Me.GrpBottom.SuspendLayout()
        CType(Me.WhiteClock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GreenClock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RedClock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeRightDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTop
        '
        Me.GrpTop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTop.Controls.Add(Me.BtnAddCol)
        Me.GrpTop.Controls.Add(Me.BtnRmvCol)
        Me.GrpTop.Controls.Add(Me.ImgTack)
        Me.GrpTop.Controls.Add(Me.cbNames)
        Me.GrpTop.Controls.Add(Me.BtnReDraw)
        Me.GrpTop.Location = New System.Drawing.Point(0, 0)
        Me.GrpTop.Margin = New System.Windows.Forms.Padding(0)
        Me.GrpTop.Name = "GrpTop"
        Me.GrpTop.Padding = New System.Windows.Forms.Padding(0)
        Me.GrpTop.Size = New System.Drawing.Size(120, 62)
        Me.GrpTop.TabIndex = 0
        Me.GrpTop.TabStop = False
        '
        'ImgTack
        '
        Me.ImgTack.Image = Global.TypeRight.My.Resources.Resources.tackup
        Me.ImgTack.Location = New System.Drawing.Point(7, 15)
        Me.ImgTack.Name = "ImgTack"
        Me.ImgTack.Size = New System.Drawing.Size(16, 16)
        Me.ImgTack.TabIndex = 2
        Me.ImgTack.TabStop = False
        '
        'cbNames
        '
        Me.cbNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbNames.FormattingEnabled = True
        Me.cbNames.Location = New System.Drawing.Point(7, 37)
        Me.cbNames.Name = "cbNames"
        Me.cbNames.Size = New System.Drawing.Size(106, 21)
        Me.cbNames.TabIndex = 1
        '
        'BtnReDraw
        '
        Me.BtnReDraw.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReDraw.Location = New System.Drawing.Point(86, 13)
        Me.BtnReDraw.Name = "BtnReDraw"
        Me.BtnReDraw.Size = New System.Drawing.Size(31, 20)
        Me.BtnReDraw.TabIndex = 0
        Me.BtnReDraw.Text = "Go"
        Me.BtnReDraw.UseVisualStyleBackColor = True
        '
        'mnuPopup
        '
        Me.mnuPopup.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOptions, Me.ShowToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.mnuPopup.Name = "mnuPopup"
        Me.mnuPopup.Size = New System.Drawing.Size(117, 70)
        '
        'mnuOptions
        '
        Me.mnuOptions.Name = "mnuOptions"
        Me.mnuOptions.Size = New System.Drawing.Size(116, 22)
        Me.mnuOptions.Text = "&Options"
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ShowToolStripMenuItem.Text = "&Show"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'mnuButtons
        '
        Me.mnuButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToClipboardToolStripMenuItem, Me.ToolStripSeparator1, Me.mnuNew, Me.mnuEdit, Me.mnuDelete, Me.ToolStripSeparator2, Me.mnuGroups, Me.mnuSep3, Me.mnuOptions1})
        Me.mnuButtons.Name = "mnuButtons"
        Me.mnuButtons.Size = New System.Drawing.Size(172, 154)
        '
        'CopyToClipboardToolStripMenuItem
        '
        Me.CopyToClipboardToolStripMenuItem.Name = "CopyToClipboardToolStripMenuItem"
        Me.CopyToClipboardToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.CopyToClipboardToolStripMenuItem.Text = "Copy to Clipboard"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(168, 6)
        '
        'mnuNew
        '
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(171, 22)
        Me.mnuNew.Text = "&New Button"
        '
        'mnuEdit
        '
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(171, 22)
        Me.mnuEdit.Text = "&Edit Button"
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(171, 22)
        Me.mnuDelete.Text = "&Delete Button"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(168, 6)
        '
        'mnuGroups
        '
        Me.mnuGroups.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.ChangeNameToolStripMenuItem, Me.TransferToolStripMenuItem})
        Me.mnuGroups.Name = "mnuGroups"
        Me.mnuGroups.Size = New System.Drawing.Size(171, 22)
        Me.mnuGroups.Text = "&Groups"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.AddToolStripMenuItem.Text = "&Add"
        '
        'ChangeNameToolStripMenuItem
        '
        Me.ChangeNameToolStripMenuItem.Name = "ChangeNameToolStripMenuItem"
        Me.ChangeNameToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ChangeNameToolStripMenuItem.Text = "&Change Name"
        '
        'TransferToolStripMenuItem
        '
        Me.TransferToolStripMenuItem.Name = "TransferToolStripMenuItem"
        Me.TransferToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.TransferToolStripMenuItem.Text = "&Transfer"
        '
        'mnuSep3
        '
        Me.mnuSep3.Name = "mnuSep3"
        Me.mnuSep3.Size = New System.Drawing.Size(168, 6)
        '
        'mnuOptions1
        '
        Me.mnuOptions1.Name = "mnuOptions1"
        Me.mnuOptions1.Size = New System.Drawing.Size(171, 22)
        Me.mnuOptions1.Text = "&Options"
        '
        'GrpBottom
        '
        Me.GrpBottom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBottom.Controls.Add(Me.WhiteClock)
        Me.GrpBottom.Controls.Add(Me.GreenClock)
        Me.GrpBottom.Controls.Add(Me.imgExit)
        Me.GrpBottom.Controls.Add(Me.PictureBox4)
        Me.GrpBottom.Controls.Add(Me.imgOptions)
        Me.GrpBottom.Controls.Add(Me.ImgLock)
        Me.GrpBottom.Controls.Add(Me.RedClock)
        Me.GrpBottom.Controls.Add(Me.ProgressBar1)
        Me.GrpBottom.Location = New System.Drawing.Point(0, 387)
        Me.GrpBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.GrpBottom.Name = "GrpBottom"
        Me.GrpBottom.Padding = New System.Windows.Forms.Padding(0)
        Me.GrpBottom.Size = New System.Drawing.Size(120, 32)
        Me.GrpBottom.TabIndex = 3
        Me.GrpBottom.TabStop = False
        '
        'WhiteClock
        '
        Me.WhiteClock.Image = Global.TypeRight.My.Resources.Resources.whiteclock
        Me.WhiteClock.Location = New System.Drawing.Point(7, 11)
        Me.WhiteClock.Name = "WhiteClock"
        Me.WhiteClock.Size = New System.Drawing.Size(16, 16)
        Me.WhiteClock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.WhiteClock.TabIndex = 6
        Me.WhiteClock.TabStop = False
        '
        'GreenClock
        '
        Me.GreenClock.Image = Global.TypeRight.My.Resources.Resources.greenclock
        Me.GreenClock.Location = New System.Drawing.Point(7, 11)
        Me.GreenClock.Name = "GreenClock"
        Me.GreenClock.Size = New System.Drawing.Size(16, 16)
        Me.GreenClock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GreenClock.TabIndex = 5
        Me.GreenClock.TabStop = False
        '
        'imgExit
        '
        Me.imgExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgExit.Image = Global.TypeRight.My.Resources.Resources.cancel
        Me.imgExit.Location = New System.Drawing.Point(97, 11)
        Me.imgExit.Name = "imgExit"
        Me.imgExit.Size = New System.Drawing.Size(16, 16)
        Me.imgExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgExit.TabIndex = 4
        Me.imgExit.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.TypeRight.My.Resources.Resources.check
        Me.PictureBox4.Location = New System.Drawing.Point(73, 11)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(15, 16)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 3
        Me.PictureBox4.TabStop = False
        '
        'imgOptions
        '
        Me.imgOptions.Image = Global.TypeRight.My.Resources.Resources.options
        Me.imgOptions.Location = New System.Drawing.Point(51, 11)
        Me.imgOptions.Name = "imgOptions"
        Me.imgOptions.Size = New System.Drawing.Size(16, 16)
        Me.imgOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgOptions.TabIndex = 2
        Me.imgOptions.TabStop = False
        '
        'ImgLock
        '
        Me.ImgLock.Image = Global.TypeRight.My.Resources.Resources.lock
        Me.ImgLock.Location = New System.Drawing.Point(29, 11)
        Me.ImgLock.Name = "ImgLock"
        Me.ImgLock.Size = New System.Drawing.Size(16, 16)
        Me.ImgLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImgLock.TabIndex = 1
        Me.ImgLock.TabStop = False
        '
        'RedClock
        '
        Me.RedClock.Image = Global.TypeRight.My.Resources.Resources.redclock
        Me.RedClock.Location = New System.Drawing.Point(7, 11)
        Me.RedClock.Name = "RedClock"
        Me.RedClock.Size = New System.Drawing.Size(16, 16)
        Me.RedClock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.RedClock.TabIndex = 0
        Me.RedClock.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 8)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(82, 21)
        Me.ProgressBar1.TabIndex = 7
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipText = "TypeRight from NetWYrks"
        Me.NotifyIcon1.ContextMenuStrip = Me.mnuPopup
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "TypeRight"
        Me.NotifyIcon1.Visible = True
        '
        'GroupButtonPanel
        '
        Me.GroupButtonPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupButtonPanel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupButtonPanel.Location = New System.Drawing.Point(0, 65)
        Me.GroupButtonPanel.Name = "GroupButtonPanel"
        Me.GroupButtonPanel.Size = New System.Drawing.Size(120, 161)
        Me.GroupButtonPanel.TabIndex = 4
        '
        'DelayTimer
        '
        '
        'TypeRightDataSet
        '
        Me.TypeRightDataSet.DataSetName = "TypeRightDataSet"
        Me.TypeRightDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SenderButtonPanel
        '
        Me.SenderButtonPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SenderButtonPanel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SenderButtonPanel.Location = New System.Drawing.Point(0, 228)
        Me.SenderButtonPanel.Name = "SenderButtonPanel"
        Me.SenderButtonPanel.Size = New System.Drawing.Size(120, 161)
        Me.SenderButtonPanel.TabIndex = 5
        '
        'BtnRmvCol
        '
        Me.BtnRmvCol.BackgroundImage = Global.TypeRight.My.Resources.Resources.menu_left
        Me.BtnRmvCol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnRmvCol.Location = New System.Drawing.Point(36, 13)
        Me.BtnRmvCol.Name = "BtnRmvCol"
        Me.BtnRmvCol.Size = New System.Drawing.Size(20, 20)
        Me.BtnRmvCol.TabIndex = 3
        Me.BtnRmvCol.UseVisualStyleBackColor = True
        '
        'BtnAddCol
        '
        Me.BtnAddCol.BackgroundImage = Global.TypeRight.My.Resources.Resources.menu_right
        Me.BtnAddCol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnAddCol.Location = New System.Drawing.Point(60, 13)
        Me.BtnAddCol.Name = "BtnAddCol"
        Me.BtnAddCol.Size = New System.Drawing.Size(20, 20)
        Me.BtnAddCol.TabIndex = 4
        Me.BtnAddCol.UseVisualStyleBackColor = True
        '
        'FrmButtonList
        '
        Me.ClientSize = New System.Drawing.Size(122, 421)
        Me.ControlBox = False
        Me.Controls.Add(Me.SenderButtonPanel)
        Me.Controls.Add(Me.GroupButtonPanel)
        Me.Controls.Add(Me.GrpBottom)
        Me.Controls.Add(Me.GrpTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmButtonList"
        Me.ShowInTaskbar = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.GrpTop.ResumeLayout(False)
        CType(Me.ImgTack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuPopup.ResumeLayout(False)
        Me.mnuButtons.ResumeLayout(False)
        Me.GrpBottom.ResumeLayout(False)
        CType(Me.WhiteClock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GreenClock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RedClock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeRightDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


    Friend WithEvents GrpTop As Windows.Forms.GroupBox
    Friend WithEvents BtnReDraw As Windows.Forms.Button
    Friend WithEvents cbNames As Windows.Forms.ComboBox
    Friend WithEvents ImgTack As Windows.Forms.PictureBox
    Friend WithEvents mnuPopup As Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuOptions As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuButtons As Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToClipboardToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuNew As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDelete As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuGroups As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeNameToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransferToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSep3 As Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuOptions1 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrpBottom As Windows.Forms.GroupBox
    Friend WithEvents NotifyIcon1 As Windows.Forms.NotifyIcon
    Friend WithEvents GroupButtonPanel As Windows.Forms.Panel
    Friend WithEvents RedClock As Windows.Forms.PictureBox
    Friend WithEvents imgExit As Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As Windows.Forms.PictureBox
    Friend WithEvents imgOptions As Windows.Forms.PictureBox
    Friend WithEvents ImgLock As Windows.Forms.PictureBox
    Friend WithEvents WhiteClock As Windows.Forms.PictureBox
    Friend WithEvents GreenClock As Windows.Forms.PictureBox
    Friend WithEvents TypeRightDataSet As TypeRightDataSet
    Friend WithEvents ProgressBar1 As Windows.Forms.ProgressBar
    Friend WithEvents DelayTimer As Windows.Forms.Timer
    Friend WithEvents SenderButtonPanel As Windows.Forms.Panel
    Friend WithEvents BtnAddCol As Windows.Forms.Button
    Friend WithEvents BtnRmvCol As Windows.Forms.Button
End Class
