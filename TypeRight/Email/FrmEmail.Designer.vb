﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmail))
        Me.PnlButtons = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip9 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnAttach = New System.Windows.Forms.Button()
        Me.BtnRmvAtt = New System.Windows.Forms.Button()
        Me.BtnPasteTo = New System.Windows.Forms.Button()
        Me.BtnPasteSubject = New System.Windows.Forms.Button()
        Me.BtnPasteText = New System.Windows.Forms.Button()
        Me.ChkNoText = New System.Windows.Forms.CheckBox()
        Me.BtnLastTo = New System.Windows.Forms.Button()
        Me.ImgTack = New System.Windows.Forms.PictureBox()
        Me.BtnReturn = New System.Windows.Forms.Button()
        Me.BtnPhone = New System.Windows.Forms.Button()
        Me.BtnMail = New System.Windows.Forms.Button()
        Me.TxtTo = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuToUpper = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToLower = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToTitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToggle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtSubject = New System.Windows.Forms.TextBox()
        Me.TxtText = New System.Windows.Forms.TextBox()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSend = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CbAttachList = New System.Windows.Forms.ComboBox()
        Me.BtnSmtp = New System.Windows.Forms.Button()
        Me.BtnClearText = New System.Windows.Forms.Button()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.cbSmtpAccounts = New System.Windows.Forms.ComboBox()
        Me.TxtFromName = New System.Windows.Forms.TextBox()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ImgTack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlButtons
        '
        Me.PnlButtons.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PnlButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlButtons.Location = New System.Drawing.Point(0, 0)
        Me.PnlButtons.Margin = New System.Windows.Forms.Padding(4)
        Me.PnlButtons.Name = "PnlButtons"
        Me.PnlButtons.Size = New System.Drawing.Size(154, 430)
        Me.PnlButtons.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.TypeRight.My.Resources.Resources.statusstrip
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 485)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(938, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BackgroundImage = Global.TypeRight.My.Resources.Resources.statusstrip
        Me.LblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(10, 17)
        '
        'BtnAttach
        '
        Me.BtnAttach.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAttach.BackgroundImage = Global.TypeRight.My.Resources.Resources.menu_left
        Me.BtnAttach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnAttach.Location = New System.Drawing.Point(669, 398)
        Me.BtnAttach.Name = "BtnAttach"
        Me.BtnAttach.Size = New System.Drawing.Size(26, 23)
        Me.BtnAttach.TabIndex = 17
        Me.ToolTip9.SetToolTip(Me.BtnAttach, "Select attachment")
        Me.BtnAttach.UseVisualStyleBackColor = True
        '
        'BtnRmvAtt
        '
        Me.BtnRmvAtt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRmvAtt.BackgroundImage = Global.TypeRight.My.Resources.Resources.cancel
        Me.BtnRmvAtt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnRmvAtt.Location = New System.Drawing.Point(701, 399)
        Me.BtnRmvAtt.Name = "BtnRmvAtt"
        Me.BtnRmvAtt.Size = New System.Drawing.Size(26, 23)
        Me.BtnRmvAtt.TabIndex = 18
        Me.ToolTip9.SetToolTip(Me.BtnRmvAtt, "Remove attachments")
        Me.BtnRmvAtt.UseVisualStyleBackColor = True
        '
        'BtnPasteTo
        '
        Me.BtnPasteTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPasteTo.BackgroundImage = Global.TypeRight.My.Resources.Resources.menu_left
        Me.BtnPasteTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPasteTo.Location = New System.Drawing.Point(700, 51)
        Me.BtnPasteTo.Name = "BtnPasteTo"
        Me.BtnPasteTo.Size = New System.Drawing.Size(26, 23)
        Me.BtnPasteTo.TabIndex = 5
        Me.ToolTip9.SetToolTip(Me.BtnPasteTo, "Paste from clipboard")
        Me.BtnPasteTo.UseVisualStyleBackColor = True
        '
        'BtnPasteSubject
        '
        Me.BtnPasteSubject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPasteSubject.BackgroundImage = Global.TypeRight.My.Resources.Resources.menu_left
        Me.BtnPasteSubject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPasteSubject.Location = New System.Drawing.Point(700, 100)
        Me.BtnPasteSubject.Name = "BtnPasteSubject"
        Me.BtnPasteSubject.Size = New System.Drawing.Size(26, 23)
        Me.BtnPasteSubject.TabIndex = 6
        Me.ToolTip9.SetToolTip(Me.BtnPasteSubject, "Paste from clipboard")
        Me.BtnPasteSubject.UseVisualStyleBackColor = True
        '
        'BtnPasteText
        '
        Me.BtnPasteText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPasteText.BackgroundImage = Global.TypeRight.My.Resources.Resources.menu_left
        Me.BtnPasteText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPasteText.Location = New System.Drawing.Point(670, 173)
        Me.BtnPasteText.Name = "BtnPasteText"
        Me.BtnPasteText.Size = New System.Drawing.Size(26, 23)
        Me.BtnPasteText.TabIndex = 7
        Me.ToolTip9.SetToolTip(Me.BtnPasteText, "Paste from clipboard")
        Me.BtnPasteText.UseVisualStyleBackColor = True
        '
        'ChkNoText
        '
        Me.ChkNoText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkNoText.AutoSize = True
        Me.ChkNoText.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkNoText.Location = New System.Drawing.Point(530, 151)
        Me.ChkNoText.Name = "ChkNoText"
        Me.ChkNoText.Size = New System.Drawing.Size(106, 21)
        Me.ChkNoText.TabIndex = 20
        Me.ChkNoText.Text = "Allow no text"
        Me.ToolTip9.SetToolTip(Me.ChkNoText, "Permit email to be sent with no text")
        Me.ChkNoText.UseVisualStyleBackColor = True
        '
        'BtnLastTo
        '
        Me.BtnLastTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLastTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnLastTo.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLastTo.ForeColor = System.Drawing.Color.Brown
        Me.BtnLastTo.Location = New System.Drawing.Point(731, 51)
        Me.BtnLastTo.Name = "BtnLastTo"
        Me.BtnLastTo.Size = New System.Drawing.Size(32, 23)
        Me.BtnLastTo.TabIndex = 19
        Me.BtnLastTo.Text = "Last"
        Me.ToolTip9.SetToolTip(Me.BtnLastTo, "Use last 'to' email")
        Me.BtnLastTo.UseVisualStyleBackColor = True
        '
        'ImgTack
        '
        Me.ImgTack.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImgTack.Image = Global.TypeRight.My.Resources.Resources.tackup
        Me.ImgTack.Location = New System.Drawing.Point(747, 6)
        Me.ImgTack.Name = "ImgTack"
        Me.ImgTack.Size = New System.Drawing.Size(16, 16)
        Me.ImgTack.TabIndex = 21
        Me.ImgTack.TabStop = False
        Me.ToolTip9.SetToolTip(Me.ImgTack, "Pin on top")
        '
        'BtnReturn
        '
        Me.BtnReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnReturn.Font = New System.Drawing.Font("Wingdings 3", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnReturn.Location = New System.Drawing.Point(619, 359)
        Me.BtnReturn.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnReturn.Name = "BtnReturn"
        Me.BtnReturn.Size = New System.Drawing.Size(26, 23)
        Me.BtnReturn.TabIndex = 22
        Me.BtnReturn.Text = "8"
        Me.ToolTip9.SetToolTip(Me.BtnReturn, "Return")
        Me.BtnReturn.UseVisualStyleBackColor = True
        '
        'BtnPhone
        '
        Me.BtnPhone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPhone.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnPhone.Location = New System.Drawing.Point(584, 359)
        Me.BtnPhone.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPhone.Name = "BtnPhone"
        Me.BtnPhone.Size = New System.Drawing.Size(26, 23)
        Me.BtnPhone.TabIndex = 23
        Me.BtnPhone.Text = "("
        Me.ToolTip9.SetToolTip(Me.BtnPhone, "Phone")
        Me.BtnPhone.UseVisualStyleBackColor = True
        '
        'BtnMail
        '
        Me.BtnMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnMail.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnMail.Location = New System.Drawing.Point(549, 359)
        Me.BtnMail.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnMail.Name = "BtnMail"
        Me.BtnMail.Size = New System.Drawing.Size(26, 23)
        Me.BtnMail.TabIndex = 24
        Me.BtnMail.Text = "*"
        Me.ToolTip9.SetToolTip(Me.BtnMail, "Email")
        Me.BtnMail.UseVisualStyleBackColor = True
        '
        'TxtTo
        '
        Me.TxtTo.AllowDrop = True
        Me.TxtTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTo.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TxtTo.Location = New System.Drawing.Point(95, 51)
        Me.TxtTo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTo.Name = "TxtTo"
        Me.TxtTo.Size = New System.Drawing.Size(600, 25)
        Me.TxtTo.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuPaste, Me.MnuClear, Me.ToolStripSeparator2, Me.MnuToUpper, Me.MnuToLower, Me.MnuToTitle, Me.MnuToggle, Me.ToolStripSeparator1, Me.CloseToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(138, 170)
        '
        'MnuPaste
        '
        Me.MnuPaste.Name = "MnuPaste"
        Me.MnuPaste.Size = New System.Drawing.Size(137, 22)
        Me.MnuPaste.Text = "Paste"
        '
        'MnuClear
        '
        Me.MnuClear.Name = "MnuClear"
        Me.MnuClear.Size = New System.Drawing.Size(137, 22)
        Me.MnuClear.Text = "Clear"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(134, 6)
        '
        'MnuToUpper
        '
        Me.MnuToUpper.Name = "MnuToUpper"
        Me.MnuToUpper.Size = New System.Drawing.Size(137, 22)
        Me.MnuToUpper.Text = "UPPERCASE"
        '
        'MnuToLower
        '
        Me.MnuToLower.Name = "MnuToLower"
        Me.MnuToLower.Size = New System.Drawing.Size(137, 22)
        Me.MnuToLower.Text = "lowercase"
        '
        'MnuToTitle
        '
        Me.MnuToTitle.Name = "MnuToTitle"
        Me.MnuToTitle.Size = New System.Drawing.Size(137, 22)
        Me.MnuToTitle.Text = "Title Case"
        '
        'MnuToggle
        '
        Me.MnuToggle.Name = "MnuToggle"
        Me.MnuToggle.Size = New System.Drawing.Size(137, 22)
        Me.MnuToggle.Text = "ToggleCase"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(134, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 18)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "To:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 18)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "From:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 18)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Subject:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 18)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Text:"
        '
        'TxtSubject
        '
        Me.TxtSubject.AllowDrop = True
        Me.TxtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSubject.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TxtSubject.Location = New System.Drawing.Point(95, 99)
        Me.TxtSubject.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(600, 25)
        Me.TxtSubject.TabIndex = 3
        '
        'TxtText
        '
        Me.TxtText.AcceptsReturn = True
        Me.TxtText.AcceptsTab = True
        Me.TxtText.AllowDrop = True
        Me.TxtText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtText.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TxtText.Location = New System.Drawing.Point(11, 172)
        Me.TxtText.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtText.Multiline = True
        Me.TxtText.Name = "TxtText"
        Me.TxtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtText.Size = New System.Drawing.Size(652, 183)
        Me.TxtText.TabIndex = 4
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(847, 439)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 41)
        Me.BtnClose.TabIndex = 3
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.BackColor = System.Drawing.Color.Honeydew
        Me.BtnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSend.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSend.ForeColor = System.Drawing.Color.DarkGreen
        Me.BtnSend.Location = New System.Drawing.Point(13, 439)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(75, 41)
        Me.BtnSend.TabIndex = 1
        Me.BtnSend.Text = "Send"
        Me.BtnSend.UseVisualStyleBackColor = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnMail)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnPhone)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnReturn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ImgTack)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChkNoText)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnLastTo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnRmvAtt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnAttach)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CbAttachList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSmtp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnClearText)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnClear)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbSmtpAccounts)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtFromName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtText)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnPasteText)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtTo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnPasteSubject)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnPasteTo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtSubject)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PnlButtons)
        Me.SplitContainer1.Size = New System.Drawing.Size(926, 430)
        Me.SplitContainer1.SplitterDistance = 768
        Me.SplitContainer1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 401)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 18)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Attachments"
        '
        'CbAttachList
        '
        Me.CbAttachList.AllowDrop = True
        Me.CbAttachList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbAttachList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbAttachList.FormattingEnabled = True
        Me.CbAttachList.Location = New System.Drawing.Point(105, 398)
        Me.CbAttachList.Name = "CbAttachList"
        Me.CbAttachList.Size = New System.Drawing.Size(558, 26)
        Me.CbAttachList.TabIndex = 15
        '
        'BtnSmtp
        '
        Me.BtnSmtp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSmtp.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnSmtp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSmtp.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSmtp.ForeColor = System.Drawing.Color.Blue
        Me.BtnSmtp.Location = New System.Drawing.Point(670, 314)
        Me.BtnSmtp.Name = "BtnSmtp"
        Me.BtnSmtp.Size = New System.Drawing.Size(86, 41)
        Me.BtnSmtp.TabIndex = 10
        Me.BtnSmtp.Text = "SMTP accounts"
        Me.BtnSmtp.UseVisualStyleBackColor = False
        '
        'BtnClearText
        '
        Me.BtnClearText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClearText.BackColor = System.Drawing.Color.Lavender
        Me.BtnClearText.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClearText.ForeColor = System.Drawing.Color.Indigo
        Me.BtnClearText.Location = New System.Drawing.Point(670, 202)
        Me.BtnClearText.Name = "BtnClearText"
        Me.BtnClearText.Size = New System.Drawing.Size(86, 41)
        Me.BtnClearText.TabIndex = 8
        Me.BtnClearText.Text = "Clear Text"
        Me.BtnClearText.UseVisualStyleBackColor = False
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.ForeColor = System.Drawing.Color.DimGray
        Me.BtnClear.Location = New System.Drawing.Point(670, 258)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(86, 41)
        Me.BtnClear.TabIndex = 9
        Me.BtnClear.Text = "ClearForm"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'cbSmtpAccounts
        '
        Me.cbSmtpAccounts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSmtpAccounts.FormattingEnabled = True
        Me.cbSmtpAccounts.Location = New System.Drawing.Point(95, 3)
        Me.cbSmtpAccounts.Name = "cbSmtpAccounts"
        Me.cbSmtpAccounts.Size = New System.Drawing.Size(341, 26)
        Me.cbSmtpAccounts.TabIndex = 0
        '
        'TxtFromName
        '
        Me.TxtFromName.AllowDrop = True
        Me.TxtFromName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFromName.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TxtFromName.Location = New System.Drawing.Point(452, 3)
        Me.TxtFromName.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFromName.Name = "TxtFromName"
        Me.TxtFromName.Size = New System.Drawing.Size(274, 25)
        Me.TxtFromName.TabIndex = 1
        '
        'BtnReset
        '
        Me.BtnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReset.BackColor = System.Drawing.Color.Linen
        Me.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnReset.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReset.ForeColor = System.Drawing.Color.Sienna
        Me.BtnReset.Location = New System.Drawing.Point(693, 441)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(75, 41)
        Me.BtnReset.TabIndex = 2
        Me.BtnReset.Text = "Reset"
        Me.BtnReset.UseVisualStyleBackColor = False
        '
        'FrmEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 507)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.BtnSend)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmEmail"
        Me.Text = "Email"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ImgTack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PnlButtons As Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
    Friend WithEvents LblStatus As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolTip9 As Windows.Forms.ToolTip
    Friend WithEvents TxtTo As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents TxtSubject As Windows.Forms.TextBox
    Friend WithEvents TxtText As Windows.Forms.TextBox
    Friend WithEvents BtnClose As Windows.Forms.Button
    Friend WithEvents BtnSend As Windows.Forms.Button
    Friend WithEvents BtnPasteTo As Windows.Forms.Button
    Friend WithEvents BtnPasteSubject As Windows.Forms.Button
    Friend WithEvents BtnPasteText As Windows.Forms.Button
    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
    Friend WithEvents TxtFromName As Windows.Forms.TextBox
    Friend WithEvents cbSmtpAccounts As Windows.Forms.ComboBox
    Friend WithEvents BtnClear As Windows.Forms.Button
    Friend WithEvents BtnSmtp As Windows.Forms.Button
    Friend WithEvents BtnClearText As Windows.Forms.Button
    Friend WithEvents BtnReset As Windows.Forms.Button
    Friend WithEvents BtnAttach As Windows.Forms.Button
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents CbAttachList As Windows.Forms.ComboBox
    Friend WithEvents FolderBrowserDialog1 As Windows.Forms.FolderBrowserDialog
    Friend WithEvents BtnRmvAtt As Windows.Forms.Button
    Friend WithEvents BtnLastTo As Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuToUpper As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuToLower As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuToggle As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPaste As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuClear As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuToTitle As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChkNoText As Windows.Forms.CheckBox
    Friend WithEvents ImgTack As Windows.Forms.PictureBox
    Friend WithEvents BtnReturn As Windows.Forms.Button
    Friend WithEvents BtnPhone As Windows.Forms.Button
    Friend WithEvents BtnMail As Windows.Forms.Button
End Class
