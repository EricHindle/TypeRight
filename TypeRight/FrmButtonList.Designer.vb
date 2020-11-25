<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmButtonList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmButtonList))
        Me.grpTop = New System.Windows.Forms.GroupBox()
        Me.ImgTack = New System.Windows.Forms.PictureBox()
        Me.cbNames = New System.Windows.Forms.ComboBox()
        Me.BtnReDraw = New System.Windows.Forms.Button()
        Me.mnuPopup = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuButtons = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewButtonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditButtonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteButtonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransferToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.OptionsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrpBottom = New System.Windows.Forms.GroupBox()
        Me.whiteclock = New System.Windows.Forms.PictureBox()
        Me.greenclock = New System.Windows.Forms.PictureBox()
        Me.imgExit = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.imgOptions = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.redclock = New System.Windows.Forms.PictureBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ButtonPanel = New System.Windows.Forms.Panel()
        Me.BtnModel = New NbuttonControlLibrary.Nbutton()
        Me.TypeRightDataSet = New TypeRight.TypeRightDataSet()
        Me.SendersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SendersTableAdapter = New TypeRight.TypeRightDataSetTableAdapters.sendersTableAdapter()
        Me.grpTop.SuspendLayout()
        CType(Me.ImgTack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuPopup.SuspendLayout()
        Me.mnuButtons.SuspendLayout()
        Me.GrpBottom.SuspendLayout()
        CType(Me.whiteclock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.greenclock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.redclock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ButtonPanel.SuspendLayout()
        CType(Me.TypeRightDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SendersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpTop
        '
        Me.grpTop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTop.Controls.Add(Me.ImgTack)
        Me.grpTop.Controls.Add(Me.cbNames)
        Me.grpTop.Controls.Add(Me.BtnReDraw)
        Me.grpTop.Location = New System.Drawing.Point(0, 0)
        Me.grpTop.Margin = New System.Windows.Forms.Padding(0)
        Me.grpTop.Name = "grpTop"
        Me.grpTop.Padding = New System.Windows.Forms.Padding(0)
        Me.grpTop.Size = New System.Drawing.Size(128, 41)
        Me.grpTop.TabIndex = 0
        Me.grpTop.TabStop = False
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
        Me.cbNames.DataSource = Me.SendersBindingSource
        Me.cbNames.DisplayMember = "firstname"
        Me.cbNames.FormattingEnabled = True
        Me.cbNames.Location = New System.Drawing.Point(29, 13)
        Me.cbNames.Name = "cbNames"
        Me.cbNames.Size = New System.Drawing.Size(59, 21)
        Me.cbNames.TabIndex = 1
        Me.cbNames.ValueMember = "senderid"
        '
        'BtnReDraw
        '
        Me.BtnReDraw.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReDraw.Location = New System.Drawing.Point(94, 12)
        Me.BtnReDraw.Name = "BtnReDraw"
        Me.BtnReDraw.Size = New System.Drawing.Size(29, 23)
        Me.BtnReDraw.TabIndex = 0
        Me.BtnReDraw.Text = "Go"
        Me.BtnReDraw.UseVisualStyleBackColor = True
        '
        'mnuPopup
        '
        Me.mnuPopup.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ShowToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.mnuPopup.Name = "mnuPopup"
        Me.mnuPopup.Size = New System.Drawing.Size(117, 70)
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.OptionsToolStripMenuItem.Text = "&Options"
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
        Me.mnuButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToClipboardToolStripMenuItem, Me.ToolStripSeparator1, Me.NewButtonToolStripMenuItem, Me.EditButtonToolStripMenuItem, Me.DeleteButtonToolStripMenuItem, Me.ToolStripSeparator2, Me.mnuGroups, Me.mnuSep3, Me.OptionsToolStripMenuItem1})
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
        'NewButtonToolStripMenuItem
        '
        Me.NewButtonToolStripMenuItem.Name = "NewButtonToolStripMenuItem"
        Me.NewButtonToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.NewButtonToolStripMenuItem.Text = "&New Button"
        '
        'EditButtonToolStripMenuItem
        '
        Me.EditButtonToolStripMenuItem.Name = "EditButtonToolStripMenuItem"
        Me.EditButtonToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.EditButtonToolStripMenuItem.Text = "&Edit Button"
        '
        'DeleteButtonToolStripMenuItem
        '
        Me.DeleteButtonToolStripMenuItem.Name = "DeleteButtonToolStripMenuItem"
        Me.DeleteButtonToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.DeleteButtonToolStripMenuItem.Text = "&Delete Button"
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
        'OptionsToolStripMenuItem1
        '
        Me.OptionsToolStripMenuItem1.Name = "OptionsToolStripMenuItem1"
        Me.OptionsToolStripMenuItem1.Size = New System.Drawing.Size(171, 22)
        Me.OptionsToolStripMenuItem1.Text = "&Options"
        '
        'GrpBottom
        '
        Me.GrpBottom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBottom.Controls.Add(Me.whiteclock)
        Me.GrpBottom.Controls.Add(Me.greenclock)
        Me.GrpBottom.Controls.Add(Me.imgExit)
        Me.GrpBottom.Controls.Add(Me.PictureBox4)
        Me.GrpBottom.Controls.Add(Me.imgOptions)
        Me.GrpBottom.Controls.Add(Me.PictureBox2)
        Me.GrpBottom.Controls.Add(Me.redclock)
        Me.GrpBottom.Location = New System.Drawing.Point(0, 387)
        Me.GrpBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.GrpBottom.Name = "GrpBottom"
        Me.GrpBottom.Padding = New System.Windows.Forms.Padding(0)
        Me.GrpBottom.Size = New System.Drawing.Size(128, 32)
        Me.GrpBottom.TabIndex = 3
        Me.GrpBottom.TabStop = False
        '
        'whiteclock
        '
        Me.whiteclock.Image = Global.TypeRight.My.Resources.Resources.whiteclock
        Me.whiteclock.Location = New System.Drawing.Point(7, 11)
        Me.whiteclock.Name = "whiteclock"
        Me.whiteclock.Size = New System.Drawing.Size(16, 16)
        Me.whiteclock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.whiteclock.TabIndex = 6
        Me.whiteclock.TabStop = False
        '
        'greenclock
        '
        Me.greenclock.Image = Global.TypeRight.My.Resources.Resources.greenclock
        Me.greenclock.Location = New System.Drawing.Point(7, 11)
        Me.greenclock.Name = "greenclock"
        Me.greenclock.Size = New System.Drawing.Size(16, 16)
        Me.greenclock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.greenclock.TabIndex = 5
        Me.greenclock.TabStop = False
        '
        'imgExit
        '
        Me.imgExit.Image = Global.TypeRight.My.Resources.Resources.cancel
        Me.imgExit.Location = New System.Drawing.Point(105, 11)
        Me.imgExit.Name = "imgExit"
        Me.imgExit.Size = New System.Drawing.Size(16, 16)
        Me.imgExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgExit.TabIndex = 4
        Me.imgExit.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.TypeRight.My.Resources.Resources.check
        Me.PictureBox4.Location = New System.Drawing.Point(83, 11)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 3
        Me.PictureBox4.TabStop = False
        '
        'imgOptions
        '
        Me.imgOptions.Image = Global.TypeRight.My.Resources.Resources.options
        Me.imgOptions.Location = New System.Drawing.Point(61, 11)
        Me.imgOptions.Name = "imgOptions"
        Me.imgOptions.Size = New System.Drawing.Size(16, 16)
        Me.imgOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgOptions.TabIndex = 2
        Me.imgOptions.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.TypeRight.My.Resources.Resources.lock
        Me.PictureBox2.Location = New System.Drawing.Point(39, 11)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'redclock
        '
        Me.redclock.Image = Global.TypeRight.My.Resources.Resources.redclock
        Me.redclock.Location = New System.Drawing.Point(7, 11)
        Me.redclock.Name = "redclock"
        Me.redclock.Size = New System.Drawing.Size(16, 16)
        Me.redclock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.redclock.TabIndex = 0
        Me.redclock.TabStop = False
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipText = "TypeRight from NetWYrks"
        Me.NotifyIcon1.ContextMenuStrip = Me.mnuPopup
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "TypeRight"
        Me.NotifyIcon1.Visible = True
        '
        'ButtonPanel
        '
        Me.ButtonPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPanel.Controls.Add(Me.BtnModel)
        Me.ButtonPanel.Location = New System.Drawing.Point(0, 44)
        Me.ButtonPanel.Name = "ButtonPanel"
        Me.ButtonPanel.Size = New System.Drawing.Size(128, 345)
        Me.ButtonPanel.TabIndex = 4
        '
        'BtnModel
        '
        Me.BtnModel.Caption = Nothing
        Me.BtnModel.Encrypt = False
        Me.BtnModel.FontBold = False
        Me.BtnModel.FontItalic = False
        Me.BtnModel.FontName = "Tahoma"
        Me.BtnModel.FontSize = 8.0!
        Me.BtnModel.Group = 1
        Me.BtnModel.Hint = ""
        Me.BtnModel.Id = -1
        Me.BtnModel.Location = New System.Drawing.Point(7, 3)
        Me.BtnModel.Name = "BtnModel"
        Me.BtnModel.Sequence = 999
        Me.BtnModel.Size = New System.Drawing.Size(83, 27)
        Me.BtnModel.TabIndex = 0
        Me.BtnModel.Value = "?"
        '
        'TypeRightDataSet
        '
        Me.TypeRightDataSet.DataSetName = "TypeRightDataSet"
        Me.TypeRightDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SendersBindingSource
        '
        Me.SendersBindingSource.DataMember = "senders"
        Me.SendersBindingSource.DataSource = Me.TypeRightDataSet
        '
        'SendersTableAdapter
        '
        Me.SendersTableAdapter.ClearBeforeFill = True
        '
        'FrmButtonList
        '
        Me.ClientSize = New System.Drawing.Size(128, 421)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonPanel)
        Me.Controls.Add(Me.GrpBottom)
        Me.Controls.Add(Me.grpTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmButtonList"
        Me.ShowInTaskbar = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.grpTop.ResumeLayout(False)
        CType(Me.ImgTack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuPopup.ResumeLayout(False)
        Me.mnuButtons.ResumeLayout(False)
        Me.GrpBottom.ResumeLayout(False)
        CType(Me.whiteclock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.greenclock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.redclock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ButtonPanel.ResumeLayout(False)
        CType(Me.TypeRightDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SendersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


    Friend WithEvents grpTop As Windows.Forms.GroupBox
    Friend WithEvents BtnReDraw As Windows.Forms.Button
    Friend WithEvents cbNames As Windows.Forms.ComboBox
    Friend WithEvents ImgTack As Windows.Forms.PictureBox
    Friend WithEvents mnuPopup As Windows.Forms.ContextMenuStrip
    Friend WithEvents OptionsToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuButtons As Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToClipboardToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents NewButtonToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditButtonToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteButtonToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuGroups As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeNameToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransferToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSep3 As Windows.Forms.ToolStripSeparator
    Friend WithEvents OptionsToolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrpBottom As Windows.Forms.GroupBox
    Friend WithEvents NotifyIcon1 As Windows.Forms.NotifyIcon
    Friend WithEvents ButtonPanel As Windows.Forms.Panel
    Friend WithEvents BtnModel As NbuttonControlLibrary.Nbutton
    Friend WithEvents redclock As Windows.Forms.PictureBox
    Friend WithEvents imgExit As Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As Windows.Forms.PictureBox
    Friend WithEvents imgOptions As Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents whiteclock As Windows.Forms.PictureBox
    Friend WithEvents greenclock As Windows.Forms.PictureBox
    Friend WithEvents TypeRightDataSet As TypeRightDataSet
    Friend WithEvents SendersBindingSource As Windows.Forms.BindingSource
    Friend WithEvents SendersTableAdapter As TypeRightDataSetTableAdapters.sendersTableAdapter
End Class
