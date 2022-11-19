<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSenderButtonFormat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSenderButtonFormat))
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.CbDbValue = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnFont = New System.Windows.Forms.Button()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.chkEncrypted = New System.Windows.Forms.CheckBox()
        Me.ToolTip7 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(292, 121)
        Me.BtnOK.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(70, 39)
        Me.BtnOK.TabIndex = 8
        Me.BtnOK.Text = "Update"
        Me.ToolTip7.SetToolTip(Me.BtnOK, "Update format details")
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnCancel.Location = New System.Drawing.Point(77, 168)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(141, 39)
        Me.BtnCancel.TabIndex = 9
        Me.BtnCancel.Text = "Done"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'CbDbValue
        '
        Me.CbDbValue.DisplayMember = "sendername"
        Me.CbDbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDbValue.FormattingEnabled = True
        Me.CbDbValue.Location = New System.Drawing.Point(135, 13)
        Me.CbDbValue.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.CbDbValue.Name = "CbDbValue"
        Me.CbDbValue.Size = New System.Drawing.Size(141, 24)
        Me.CbDbValue.TabIndex = 10
        Me.CbDbValue.ValueMember = "senderid"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 17)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Database Field"
        '
        'BtnFont
        '
        Me.BtnFont.Location = New System.Drawing.Point(24, 66)
        Me.BtnFont.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnFont.Name = "BtnFont"
        Me.BtnFont.Size = New System.Drawing.Size(252, 39)
        Me.BtnFont.TabIndex = 27
        Me.BtnFont.Text = "Caption Font"
        Me.ToolTip7.SetToolTip(Me.BtnFont, "Set caption font for the field")
        Me.BtnFont.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.TypeRight.My.Resources.Resources.statusstrip
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 222)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(373, 22)
        Me.StatusStrip1.TabIndex = 28
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
        'chkEncrypted
        '
        Me.chkEncrypted.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.chkEncrypted.AutoSize = True
        Me.chkEncrypted.Location = New System.Drawing.Point(77, 124)
        Me.chkEncrypted.Name = "chkEncrypted"
        Me.chkEncrypted.Size = New System.Drawing.Size(138, 21)
        Me.chkEncrypted.TabIndex = 29
        Me.chkEncrypted.Text = "Value is encrypted"
        Me.chkEncrypted.UseVisualStyleBackColor = True
        '
        'FrmSenderButtonFormat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 244)
        Me.Controls.Add(Me.chkEncrypted)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnFont)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbDbValue)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Name = "FrmSenderButtonFormat"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sender Button Format"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnOK As Windows.Forms.Button
    Friend WithEvents BtnCancel As Windows.Forms.Button
    Friend WithEvents CbDbValue As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents BtnFont As Windows.Forms.Button
    Friend WithEvents FontDialog1 As Windows.Forms.FontDialog
    Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
    Friend WithEvents LblStatus As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chkEncrypted As Windows.Forms.CheckBox
    Friend WithEvents ToolTip7 As Windows.Forms.ToolTip
End Class
