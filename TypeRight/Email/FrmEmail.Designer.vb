<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmail))
        Me.SenderButtonPanel = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip9 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtSubject = New System.Windows.Forms.TextBox()
        Me.TxtText = New System.Windows.Forms.TextBox()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSend = New System.Windows.Forms.Button()
        Me.BtnPasteTo = New System.Windows.Forms.Button()
        Me.BtnPasteSubject = New System.Windows.Forms.Button()
        Me.BtnPasteText = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cbSmtpAccounts = New System.Windows.Forms.ComboBox()
        Me.TxtFromName = New System.Windows.Forms.TextBox()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnSmtp = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SenderButtonPanel
        '
        Me.SenderButtonPanel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SenderButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SenderButtonPanel.Location = New System.Drawing.Point(0, 0)
        Me.SenderButtonPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.SenderButtonPanel.Name = "SenderButtonPanel"
        Me.SenderButtonPanel.Size = New System.Drawing.Size(154, 430)
        Me.SenderButtonPanel.TabIndex = 6
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
        Me.StatusStrip1.TabIndex = 19
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
        'TxtTo
        '
        Me.TxtTo.AllowDrop = True
        Me.TxtTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTo.Location = New System.Drawing.Point(95, 51)
        Me.TxtTo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTo.Name = "TxtTo"
        Me.TxtTo.Size = New System.Drawing.Size(622, 25)
        Me.TxtTo.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 18)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "To:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 18)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "From:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 18)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Subject:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 18)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Text:"
        '
        'TxtSubject
        '
        Me.TxtSubject.AllowDrop = True
        Me.TxtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSubject.Location = New System.Drawing.Point(95, 99)
        Me.TxtSubject.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(622, 25)
        Me.TxtSubject.TabIndex = 25
        '
        'TxtText
        '
        Me.TxtText.AllowDrop = True
        Me.TxtText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtText.Location = New System.Drawing.Point(4, 172)
        Me.TxtText.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtText.Multiline = True
        Me.TxtText.Name = "TxtText"
        Me.TxtText.Size = New System.Drawing.Size(759, 254)
        Me.TxtText.TabIndex = 26
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(847, 440)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 41)
        Me.BtnClose.TabIndex = 28
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
        Me.BtnSend.TabIndex = 29
        Me.BtnSend.Text = "Send"
        Me.BtnSend.UseVisualStyleBackColor = False
        '
        'BtnPasteTo
        '
        Me.BtnPasteTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPasteTo.BackgroundImage = Global.TypeRight.My.Resources.Resources.menu_left
        Me.BtnPasteTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPasteTo.Location = New System.Drawing.Point(724, 53)
        Me.BtnPasteTo.Name = "BtnPasteTo"
        Me.BtnPasteTo.Size = New System.Drawing.Size(26, 23)
        Me.BtnPasteTo.TabIndex = 30
        Me.BtnPasteTo.UseVisualStyleBackColor = True
        '
        'BtnPasteSubject
        '
        Me.BtnPasteSubject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPasteSubject.BackgroundImage = Global.TypeRight.My.Resources.Resources.menu_left
        Me.BtnPasteSubject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPasteSubject.Location = New System.Drawing.Point(724, 100)
        Me.BtnPasteSubject.Name = "BtnPasteSubject"
        Me.BtnPasteSubject.Size = New System.Drawing.Size(26, 23)
        Me.BtnPasteSubject.TabIndex = 31
        Me.BtnPasteSubject.UseVisualStyleBackColor = True
        '
        'BtnPasteText
        '
        Me.BtnPasteText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPasteText.BackgroundImage = Global.TypeRight.My.Resources.Resources.menu_left
        Me.BtnPasteText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPasteText.Location = New System.Drawing.Point(724, 145)
        Me.BtnPasteText.Name = "BtnPasteText"
        Me.BtnPasteText.Size = New System.Drawing.Size(26, 23)
        Me.BtnPasteText.TabIndex = 32
        Me.BtnPasteText.UseVisualStyleBackColor = True
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.SenderButtonPanel)
        Me.SplitContainer1.Size = New System.Drawing.Size(926, 430)
        Me.SplitContainer1.SplitterDistance = 768
        Me.SplitContainer1.TabIndex = 33
        '
        'cbEmailUsername
        '
        Me.cbSmtpAccounts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSmtpAccounts.FormattingEnabled = True
        Me.cbSmtpAccounts.Location = New System.Drawing.Point(95, 3)
        Me.cbSmtpAccounts.Name = "cbEmailUsername"
        Me.cbSmtpAccounts.Size = New System.Drawing.Size(341, 26)
        Me.cbSmtpAccounts.TabIndex = 35
        '
        'TxtFromName
        '
        Me.TxtFromName.AllowDrop = True
        Me.TxtFromName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFromName.Location = New System.Drawing.Point(452, 3)
        Me.TxtFromName.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFromName.Name = "TxtFromName"
        Me.TxtFromName.Size = New System.Drawing.Size(298, 25)
        Me.TxtFromName.TabIndex = 34
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.ForeColor = System.Drawing.Color.DimGray
        Me.BtnClear.Location = New System.Drawing.Point(700, 440)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(75, 41)
        Me.BtnClear.TabIndex = 34
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'BtnSmtp
        '
        Me.BtnSmtp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSmtp.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnSmtp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSmtp.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSmtp.ForeColor = System.Drawing.Color.Blue
        Me.BtnSmtp.Location = New System.Drawing.Point(566, 440)
        Me.BtnSmtp.Name = "BtnSmtp"
        Me.BtnSmtp.Size = New System.Drawing.Size(75, 41)
        Me.BtnSmtp.TabIndex = 35
        Me.BtnSmtp.Text = "SMTP accounts"
        Me.BtnSmtp.UseVisualStyleBackColor = False
        '
        'FrmEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 507)
        Me.Controls.Add(Me.BtnSmtp)
        Me.Controls.Add(Me.BtnClear)
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
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SenderButtonPanel As Windows.Forms.Panel
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
End Class
