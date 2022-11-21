<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOptions))
        Me.GrpLicence = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtLicName = New System.Windows.Forms.TextBox()
        Me.TxtLic4 = New System.Windows.Forms.TextBox()
        Me.TxtLic3 = New System.Windows.Forms.TextBox()
        Me.TxtLic2 = New System.Windows.Forms.TextBox()
        Me.TxtLic1 = New System.Windows.Forms.TextBox()
        Me.BtnDfltFont = New System.Windows.Forms.Button()
        Me.BtnSample = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.HScroll1 = New System.Windows.Forms.HScrollBar()
        Me.Slider1 = New System.Windows.Forms.TrackBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CbDebug = New System.Windows.Forms.CheckBox()
        Me.cbOnTop = New System.Windows.Forms.CheckBox()
        Me.CbToolBar = New System.Windows.Forms.CheckBox()
        Me.cbMinimise = New System.Windows.Forms.CheckBox()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.nudDelay = New System.Windows.Forms.NumericUpDown()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnPosReset = New System.Windows.Forms.Button()
        Me.TxtLogFolder = New System.Windows.Forms.TextBox()
        Me.TxtBkUpFolder = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblVersion = New System.Windows.Forms.Label()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.Image2 = New System.Windows.Forms.PictureBox()
        Me.BtnViewLog = New System.Windows.Forms.Button()
        Me.ToolTip6 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnRestore = New System.Windows.Forms.Button()
        Me.BtnBackup = New System.Windows.Forms.Button()
        Me.GrpLicence.SuspendLayout()
        CType(Me.Slider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpLicence
        '
        Me.GrpLicence.Controls.Add(Me.Label5)
        Me.GrpLicence.Controls.Add(Me.Label4)
        Me.GrpLicence.Controls.Add(Me.Label3)
        Me.GrpLicence.Controls.Add(Me.Label2)
        Me.GrpLicence.Controls.Add(Me.Label1)
        Me.GrpLicence.Controls.Add(Me.TxtLicName)
        Me.GrpLicence.Controls.Add(Me.TxtLic4)
        Me.GrpLicence.Controls.Add(Me.TxtLic3)
        Me.GrpLicence.Controls.Add(Me.TxtLic2)
        Me.GrpLicence.Controls.Add(Me.TxtLic1)
        Me.GrpLicence.Location = New System.Drawing.Point(12, 204)
        Me.GrpLicence.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpLicence.Name = "GrpLicence"
        Me.GrpLicence.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpLicence.Size = New System.Drawing.Size(389, 113)
        Me.GrpLicence.TabIndex = 7
        Me.GrpLicence.TabStop = False
        Me.GrpLicence.Text = "Licence"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(297, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(215, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(133, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Name"
        '
        'TxtLicName
        '
        Me.TxtLicName.Location = New System.Drawing.Point(70, 33)
        Me.TxtLicName.Name = "TxtLicName"
        Me.TxtLicName.Size = New System.Drawing.Size(303, 24)
        Me.TxtLicName.TabIndex = 0
        '
        'TxtLic4
        '
        Me.TxtLic4.Location = New System.Drawing.Point(316, 63)
        Me.TxtLic4.Name = "TxtLic4"
        Me.TxtLic4.Size = New System.Drawing.Size(57, 24)
        Me.TxtLic4.TabIndex = 4
        '
        'TxtLic3
        '
        Me.TxtLic3.Location = New System.Drawing.Point(234, 63)
        Me.TxtLic3.Name = "TxtLic3"
        Me.TxtLic3.Size = New System.Drawing.Size(57, 24)
        Me.TxtLic3.TabIndex = 3
        '
        'TxtLic2
        '
        Me.TxtLic2.Location = New System.Drawing.Point(152, 64)
        Me.TxtLic2.Name = "TxtLic2"
        Me.TxtLic2.Size = New System.Drawing.Size(57, 24)
        Me.TxtLic2.TabIndex = 2
        '
        'TxtLic1
        '
        Me.TxtLic1.Location = New System.Drawing.Point(70, 64)
        Me.TxtLic1.Name = "TxtLic1"
        Me.TxtLic1.Size = New System.Drawing.Size(57, 24)
        Me.TxtLic1.TabIndex = 1
        '
        'BtnDfltFont
        '
        Me.BtnDfltFont.Location = New System.Drawing.Point(249, 42)
        Me.BtnDfltFont.Name = "BtnDfltFont"
        Me.BtnDfltFont.Size = New System.Drawing.Size(193, 31)
        Me.BtnDfltFont.TabIndex = 1
        Me.BtnDfltFont.Text = "Default Font"
        Me.BtnDfltFont.UseVisualStyleBackColor = True
        '
        'BtnSample
        '
        Me.BtnSample.Location = New System.Drawing.Point(249, 98)
        Me.BtnSample.Name = "BtnSample"
        Me.BtnSample.Size = New System.Drawing.Size(80, 27)
        Me.BtnSample.TabIndex = 4
        Me.BtnSample.Text = "Sample"
        Me.BtnSample.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Location = New System.Drawing.Point(424, 420)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 31)
        Me.BtnCancel.TabIndex = 10
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Location = New System.Drawing.Point(544, 420)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(94, 31)
        Me.BtnOK.TabIndex = 11
        Me.BtnOK.Text = "OK"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'HScroll1
        '
        Me.HScroll1.Location = New System.Drawing.Point(12, 48)
        Me.HScroll1.Maximum = 450
        Me.HScroll1.Minimum = 120
        Me.HScroll1.Name = "HScroll1"
        Me.HScroll1.Size = New System.Drawing.Size(208, 17)
        Me.HScroll1.TabIndex = 0
        Me.HScroll1.Value = 120
        '
        'Slider1
        '
        Me.Slider1.LargeChange = 10
        Me.Slider1.Location = New System.Drawing.Point(15, 98)
        Me.Slider1.Maximum = 100
        Me.Slider1.Minimum = 10
        Me.Slider1.Name = "Slider1"
        Me.Slider1.Size = New System.Drawing.Size(208, 45)
        Me.Slider1.SmallChange = 5
        Me.Slider1.TabIndex = 3
        Me.Slider1.TickFrequency = 5
        Me.Slider1.Value = 100
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 17)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Button Width"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 17)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Transparency (XP)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(267, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 17)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Default Caption Font"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 161)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 17)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Delay (ms)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CbDebug)
        Me.GroupBox2.Controls.Add(Me.cbOnTop)
        Me.GroupBox2.Controls.Add(Me.CbToolBar)
        Me.GroupBox2.Controls.Add(Me.cbMinimise)
        Me.GroupBox2.Location = New System.Drawing.Point(469, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(121, 147)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'CbDebug
        '
        Me.CbDebug.AutoSize = True
        Me.CbDebug.Location = New System.Drawing.Point(13, 115)
        Me.CbDebug.Name = "CbDebug"
        Me.CbDebug.Size = New System.Drawing.Size(68, 21)
        Me.CbDebug.TabIndex = 3
        Me.CbDebug.Text = "Debug"
        Me.CbDebug.UseVisualStyleBackColor = True
        '
        'cbOnTop
        '
        Me.cbOnTop.AutoSize = True
        Me.cbOnTop.Location = New System.Drawing.Point(13, 24)
        Me.cbOnTop.Name = "cbOnTop"
        Me.cbOnTop.Size = New System.Drawing.Size(73, 21)
        Me.cbOnTop.TabIndex = 0
        Me.cbOnTop.Text = "On Top"
        Me.cbOnTop.UseVisualStyleBackColor = True
        '
        'CbToolBar
        '
        Me.CbToolBar.AutoSize = True
        Me.CbToolBar.Location = New System.Drawing.Point(13, 56)
        Me.CbToolBar.Name = "CbToolBar"
        Me.CbToolBar.Size = New System.Drawing.Size(77, 21)
        Me.CbToolBar.TabIndex = 1
        Me.CbToolBar.Text = "Tool Bar"
        Me.CbToolBar.UseVisualStyleBackColor = True
        '
        'cbMinimise
        '
        Me.cbMinimise.AutoSize = True
        Me.cbMinimise.Location = New System.Drawing.Point(13, 88)
        Me.cbMinimise.Name = "cbMinimise"
        Me.cbMinimise.Size = New System.Drawing.Size(76, 21)
        Me.cbMinimise.TabIndex = 2
        Me.cbMinimise.Text = "Minimise"
        Me.cbMinimise.UseVisualStyleBackColor = True
        '
        'nudDelay
        '
        Me.nudDelay.Increment = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nudDelay.Location = New System.Drawing.Point(92, 159)
        Me.nudDelay.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudDelay.Minimum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudDelay.Name = "nudDelay"
        Me.nudDelay.Size = New System.Drawing.Size(74, 24)
        Me.nudDelay.TabIndex = 5
        Me.nudDelay.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.TypeRight.My.Resources.Resources.statusstrip
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 457)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(650, 22)
        Me.StatusStrip1.TabIndex = 19
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackgroundImage = Global.TypeRight.My.Resources.Resources.statusstrip
        Me.lblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lblStatus.Size = New System.Drawing.Size(10, 17)
        '
        'BtnPosReset
        '
        Me.BtnPosReset.Location = New System.Drawing.Point(249, 151)
        Me.BtnPosReset.Name = "BtnPosReset"
        Me.BtnPosReset.Size = New System.Drawing.Size(145, 32)
        Me.BtnPosReset.TabIndex = 6
        Me.BtnPosReset.Text = "Reset form positions"
        Me.BtnPosReset.UseVisualStyleBackColor = True
        '
        'TxtLogFolder
        '
        Me.TxtLogFolder.Location = New System.Drawing.Point(426, 224)
        Me.TxtLogFolder.Name = "TxtLogFolder"
        Me.TxtLogFolder.Size = New System.Drawing.Size(214, 24)
        Me.TxtLogFolder.TabIndex = 8
        '
        'TxtBkUpFolder
        '
        Me.TxtBkUpFolder.Location = New System.Drawing.Point(426, 295)
        Me.TxtBkUpFolder.Name = "TxtBkUpFolder"
        Me.TxtBkUpFolder.Size = New System.Drawing.Size(214, 24)
        Me.TxtBkUpFolder.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(423, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Log Folder"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(423, 275)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 17)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Backup Folder"
        '
        'LblVersion
        '
        Me.LblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblVersion.AutoSize = True
        Me.LblVersion.Location = New System.Drawing.Point(15, 427)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(156, 17)
        Me.LblVersion.TabIndex = 18
        Me.LblVersion.Text = "Version {0}.{1}.{2}.{3}"
        '
        'Image1
        '
        Me.Image1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Image1.Image = Global.TypeRight.My.Resources.Resources.TypeRight1
        Me.Image1.Location = New System.Drawing.Point(15, 392)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(150, 32)
        Me.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Image1.TabIndex = 20
        Me.Image1.TabStop = False
        '
        'Image2
        '
        Me.Image2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Image2.Image = Global.TypeRight.My.Resources.Resources.TypeRight2
        Me.Image2.Location = New System.Drawing.Point(15, 392)
        Me.Image2.Name = "Image2"
        Me.Image2.Size = New System.Drawing.Size(200, 32)
        Me.Image2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Image2.TabIndex = 21
        Me.Image2.TabStop = False
        '
        'BtnViewLog
        '
        Me.BtnViewLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnViewLog.Location = New System.Drawing.Point(15, 338)
        Me.BtnViewLog.Name = "BtnViewLog"
        Me.BtnViewLog.Size = New System.Drawing.Size(94, 31)
        Me.BtnViewLog.TabIndex = 22
        Me.BtnViewLog.Text = "View Log"
        Me.BtnViewLog.UseVisualStyleBackColor = True
        '
        'BtnRestore
        '
        Me.BtnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnRestore.Location = New System.Drawing.Point(312, 338)
        Me.BtnRestore.Name = "BtnRestore"
        Me.BtnRestore.Size = New System.Drawing.Size(94, 31)
        Me.BtnRestore.TabIndex = 23
        Me.BtnRestore.Text = "Restore"
        Me.BtnRestore.UseVisualStyleBackColor = True
        '
        'BtnBackup
        '
        Me.BtnBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnBackup.Location = New System.Drawing.Point(209, 338)
        Me.BtnBackup.Name = "BtnBackup"
        Me.BtnBackup.Size = New System.Drawing.Size(94, 31)
        Me.BtnBackup.TabIndex = 24
        Me.BtnBackup.Text = "Backup"
        Me.BtnBackup.UseVisualStyleBackColor = True
        '
        'FrmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 479)
        Me.Controls.Add(Me.BtnBackup)
        Me.Controls.Add(Me.BtnRestore)
        Me.Controls.Add(Me.BtnViewLog)
        Me.Controls.Add(Me.Image2)
        Me.Controls.Add(Me.Image1)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtBkUpFolder)
        Me.Controls.Add(Me.TxtLogFolder)
        Me.Controls.Add(Me.BtnPosReset)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.nudDelay)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Slider1)
        Me.Controls.Add(Me.HScroll1)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSample)
        Me.Controls.Add(Me.BtnDfltFont)
        Me.Controls.Add(Me.GrpLicence)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmOptions"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Options"
        Me.GrpLicence.ResumeLayout(False)
        Me.GrpLicence.PerformLayout()
        CType(Me.Slider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GrpLicence As Windows.Forms.GroupBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents TxtLicName As Windows.Forms.TextBox
    Friend WithEvents TxtLic4 As Windows.Forms.TextBox
    Friend WithEvents TxtLic3 As Windows.Forms.TextBox
    Friend WithEvents TxtLic2 As Windows.Forms.TextBox
    Friend WithEvents TxtLic1 As Windows.Forms.TextBox
    Friend WithEvents BtnDfltFont As Windows.Forms.Button
    Friend WithEvents BtnSample As Windows.Forms.Button
    Friend WithEvents BtnCancel As Windows.Forms.Button
    Friend WithEvents BtnOK As Windows.Forms.Button
    Friend WithEvents HScroll1 As Windows.Forms.HScrollBar
    Friend WithEvents Slider1 As Windows.Forms.TrackBar
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents cbOnTop As Windows.Forms.CheckBox
    Friend WithEvents CbToolBar As Windows.Forms.CheckBox
    Friend WithEvents cbMinimise As Windows.Forms.CheckBox
    Friend WithEvents FontDialog1 As Windows.Forms.FontDialog
    Friend WithEvents nudDelay As Windows.Forms.NumericUpDown
    Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnPosReset As Windows.Forms.Button
    Friend WithEvents TxtLogFolder As Windows.Forms.TextBox
    Friend WithEvents TxtBkUpFolder As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents LblVersion As Windows.Forms.Label
    Friend WithEvents CbDebug As Windows.Forms.CheckBox
    Friend WithEvents Image1 As Windows.Forms.PictureBox
    Friend WithEvents Image2 As Windows.Forms.PictureBox
    Friend WithEvents BtnViewLog As Windows.Forms.Button
    Friend WithEvents ToolTip6 As Windows.Forms.ToolTip
    Friend WithEvents BtnRestore As Windows.Forms.Button
    Friend WithEvents BtnBackup As Windows.Forms.Button
End Class
