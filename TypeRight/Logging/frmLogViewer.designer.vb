<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogViewer))
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.rtbLog = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.WrapTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ZoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.BtnNoZoom = New System.Windows.Forms.Button()
        Me.BtnClearLog = New System.Windows.Forms.Button()
        Me.BtnPrevFile = New System.Windows.Forms.Button()
        Me.BtnNextFile = New System.Windows.Forms.Button()
        Me.BtnToday = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.OK_Button.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OK_Button.Location = New System.Drawing.Point(725, 505)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(109, 31)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'rtbLog
        '
        Me.rtbLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbLog.BackColor = System.Drawing.SystemColors.ControlLight
        Me.rtbLog.ContextMenuStrip = Me.ContextMenuStrip1
        Me.rtbLog.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbLog.ForeColor = System.Drawing.Color.Black
        Me.rtbLog.Location = New System.Drawing.Point(18, 31)
        Me.rtbLog.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rtbLog.Name = "rtbLog"
        Me.rtbLog.Size = New System.Drawing.Size(815, 446)
        Me.rtbLog.TabIndex = 5
        Me.rtbLog.Text = ""
        Me.rtbLog.WordWrap = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WrapTextToolStripMenuItem, Me.ToolStripSeparator2, Me.ZoomToolStripMenuItem, Me.ToolStripSeparator1, Me.CopyToolStripMenuItem, Me.CopyAllToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(150, 104)
        '
        'WrapTextToolStripMenuItem
        '
        Me.WrapTextToolStripMenuItem.CheckOnClick = True
        Me.WrapTextToolStripMenuItem.Name = "WrapTextToolStripMenuItem"
        Me.WrapTextToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.WrapTextToolStripMenuItem.Text = "Wrap Text"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(146, 6)
        '
        'ZoomToolStripMenuItem
        '
        Me.ZoomToolStripMenuItem.CheckOnClick = True
        Me.ZoomToolStripMenuItem.Name = "ZoomToolStripMenuItem"
        Me.ZoomToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ZoomToolStripMenuItem.Text = "Zoom On"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(146, 6)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.CopyToolStripMenuItem.Text = "Copy Selected"
        '
        'CopyAllToolStripMenuItem
        '
        Me.CopyAllToolStripMenuItem.Name = "CopyAllToolStripMenuItem"
        Me.CopyAllToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.CopyAllToolStripMenuItem.Text = "Copy All"
        '
        'TrackBar1
        '
        Me.TrackBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TrackBar1.AutoSize = False
        Me.TrackBar1.Location = New System.Drawing.Point(132, 508)
        Me.TrackBar1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TrackBar1.Maximum = 30
        Me.TrackBar1.Minimum = 5
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(243, 31)
        Me.TrackBar1.TabIndex = 2
        Me.TrackBar1.TickFrequency = 5
        Me.TrackBar1.Value = 10
        Me.TrackBar1.Visible = False
        '
        'btnNoZoom
        '
        Me.BtnNoZoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnNoZoom.AutoSize = True
        Me.BtnNoZoom.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNoZoom.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNoZoom.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnNoZoom.Location = New System.Drawing.Point(381, 505)
        Me.BtnNoZoom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnNoZoom.Name = "btnNoZoom"
        Me.BtnNoZoom.Size = New System.Drawing.Size(47, 31)
        Me.BtnNoZoom.TabIndex = 3
        Me.BtnNoZoom.Text = "1"
        Me.BtnNoZoom.UseVisualStyleBackColor = True
        Me.BtnNoZoom.Visible = False
        '
        'BtnClearLog
        '
        Me.BtnClearLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClearLog.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnClearLog.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClearLog.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnClearLog.Location = New System.Drawing.Point(18, 505)
        Me.BtnClearLog.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnClearLog.Name = "BtnClearLog"
        Me.BtnClearLog.Size = New System.Drawing.Size(99, 31)
        Me.BtnClearLog.TabIndex = 6
        Me.BtnClearLog.Text = "Clear Log"
        Me.BtnClearLog.UseVisualStyleBackColor = True
        '
        'BtnPrevFile
        '
        Me.BtnPrevFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPrevFile.AutoSize = True
        Me.BtnPrevFile.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnPrevFile.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrevFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnPrevFile.Location = New System.Drawing.Point(483, 505)
        Me.BtnPrevFile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnPrevFile.Name = "BtnPrevFile"
        Me.BtnPrevFile.Size = New System.Drawing.Size(56, 31)
        Me.BtnPrevFile.TabIndex = 7
        Me.BtnPrevFile.Text = "<<"
        Me.BtnPrevFile.UseVisualStyleBackColor = True
        '
        'BtnNextFile
        '
        Me.BtnNextFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnNextFile.AutoSize = True
        Me.BtnNextFile.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNextFile.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNextFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnNextFile.Location = New System.Drawing.Point(653, 505)
        Me.BtnNextFile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnNextFile.Name = "BtnNextFile"
        Me.BtnNextFile.Size = New System.Drawing.Size(51, 31)
        Me.BtnNextFile.TabIndex = 8
        Me.BtnNextFile.Text = ">>"
        Me.BtnNextFile.UseVisualStyleBackColor = True
        '
        'BtnToday
        '
        Me.BtnToday.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnToday.AutoSize = True
        Me.BtnToday.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnToday.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnToday.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnToday.Location = New System.Drawing.Point(545, 505)
        Me.BtnToday.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnToday.Name = "BtnToday"
        Me.BtnToday.Size = New System.Drawing.Size(102, 31)
        Me.BtnToday.TabIndex = 9
        Me.BtnToday.Text = "Today"
        Me.BtnToday.UseVisualStyleBackColor = True
        '
        'frmLogViewer
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(860, 550)
        Me.Controls.Add(Me.BtnToday)
        Me.Controls.Add(Me.BtnNextFile)
        Me.Controls.Add(Me.BtnPrevFile)
        Me.Controls.Add(Me.BtnClearLog)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.BtnNoZoom)
        Me.Controls.Add(Me.rtbLog)
        Me.Controls.Add(Me.OK_Button)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogViewer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Log Viewer"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents rtbLog As System.Windows.Forms.RichTextBox
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents BtnNoZoom As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents WrapTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ZoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnClearLog As System.Windows.Forms.Button
    Friend WithEvents BtnPrevFile As System.Windows.Forms.Button
    Friend WithEvents BtnNextFile As System.Windows.Forms.Button
    Friend WithEvents BtnToday As System.Windows.Forms.Button
End Class
