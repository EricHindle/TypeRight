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
        Me.DelayTimer = New System.Windows.Forms.Timer(Me.components)
        Me.secondTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.imgClock = New System.Windows.Forms.PictureBox()
        Me.imgExit = New System.Windows.Forms.PictureBox()
        Me.imgOptions = New System.Windows.Forms.PictureBox()
        Me.imgLock = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnReDraw = New System.Windows.Forms.Button()
        Me.cbNames = New System.Windows.Forms.ComboBox()
        Me.imgUpTack = New System.Windows.Forms.PictureBox()
        Me.imgDnTack = New System.Windows.Forms.PictureBox()
        Me.Nbutton1 = New NbuttonControlLibrary.Nbutton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.imgClock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.imgUpTack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgDnTack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.imgClock)
        Me.GroupBox1.Controls.Add(Me.imgExit)
        Me.GroupBox1.Controls.Add(Me.imgOptions)
        Me.GroupBox1.Controls.Add(Me.imgLock)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 303)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(246, 124)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'imgClock
        '
        Me.imgClock.Image = Global.TypeRight.My.Resources.Resources.check
        Me.imgClock.Location = New System.Drawing.Point(138, 65)
        Me.imgClock.Name = "imgClock"
        Me.imgClock.Size = New System.Drawing.Size(17, 17)
        Me.imgClock.TabIndex = 5
        Me.imgClock.TabStop = False
        '
        'imgExit
        '
        Me.imgExit.Image = Global.TypeRight.My.Resources.Resources.cancel
        Me.imgExit.Location = New System.Drawing.Point(101, 53)
        Me.imgExit.Name = "imgExit"
        Me.imgExit.Size = New System.Drawing.Size(17, 18)
        Me.imgExit.TabIndex = 4
        Me.imgExit.TabStop = False
        Me.ToolTip1.SetToolTip(Me.imgExit, "Close TypeRight")
        '
        'imgOptions
        '
        Me.imgOptions.Image = Global.TypeRight.My.Resources.Resources.options
        Me.imgOptions.Location = New System.Drawing.Point(60, 53)
        Me.imgOptions.Name = "imgOptions"
        Me.imgOptions.Size = New System.Drawing.Size(17, 18)
        Me.imgOptions.TabIndex = 3
        Me.imgOptions.TabStop = False
        '
        'imgLock
        '
        Me.imgLock.Image = Global.TypeRight.My.Resources.Resources.tackdown
        Me.imgLock.Location = New System.Drawing.Point(37, 53)
        Me.imgLock.Name = "imgLock"
        Me.imgLock.Size = New System.Drawing.Size(17, 16)
        Me.imgLock.TabIndex = 2
        Me.imgLock.TabStop = False
        Me.ToolTip1.SetToolTip(Me.imgLock, "Click to unlock")
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.TypeRight.My.Resources.Resources.check
        Me.PictureBox1.Location = New System.Drawing.Point(14, 53)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(17, 16)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "Database")
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 14)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(164, 23)
        Me.ProgressBar1.TabIndex = 0
        Me.ProgressBar1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.imgDnTack)
        Me.GroupBox2.Controls.Add(Me.imgUpTack)
        Me.GroupBox2.Controls.Add(Me.cbNames)
        Me.GroupBox2.Controls.Add(Me.BtnReDraw)
        Me.GroupBox2.Location = New System.Drawing.Point(30, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'BtnReDraw
        '
        Me.BtnReDraw.Location = New System.Drawing.Point(6, 71)
        Me.BtnReDraw.Name = "BtnReDraw"
        Me.BtnReDraw.Size = New System.Drawing.Size(37, 23)
        Me.BtnReDraw.TabIndex = 0
        Me.BtnReDraw.Text = "Go"
        Me.ToolTip1.SetToolTip(Me.BtnReDraw, "Load values for selected name/group")
        Me.BtnReDraw.UseVisualStyleBackColor = True
        '
        'cbNames
        '
        Me.cbNames.FormattingEnabled = True
        Me.cbNames.Location = New System.Drawing.Point(12, 21)
        Me.cbNames.Name = "cbNames"
        Me.cbNames.Size = New System.Drawing.Size(121, 24)
        Me.cbNames.TabIndex = 1
        '
        'imgUpTack
        '
        Me.imgUpTack.Image = Global.TypeRight.My.Resources.Resources.tackup
        Me.imgUpTack.Location = New System.Drawing.Point(83, 71)
        Me.imgUpTack.Name = "imgUpTack"
        Me.imgUpTack.Size = New System.Drawing.Size(17, 23)
        Me.imgUpTack.TabIndex = 2
        Me.imgUpTack.TabStop = False
        Me.ToolTip1.SetToolTip(Me.imgUpTack, "Lock on top")
        '
        'imgDnTack
        '
        Me.imgDnTack.Image = Global.TypeRight.My.Resources.Resources.tackdown
        Me.imgDnTack.Location = New System.Drawing.Point(116, 71)
        Me.imgDnTack.Name = "imgDnTack"
        Me.imgDnTack.Size = New System.Drawing.Size(17, 23)
        Me.imgDnTack.TabIndex = 3
        Me.imgDnTack.TabStop = False
        Me.ToolTip1.SetToolTip(Me.imgDnTack, "Lock on top")
        '
        'Nbutton1
        '
        Me.Nbutton1.Bold = False
        Me.Nbutton1.Caption = "Undo"
        Me.Nbutton1.Group = 0
        Me.Nbutton1.Hint = ""
        Me.Nbutton1.Location = New System.Drawing.Point(30, 43)
        Me.Nbutton1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nbutton1.Name = "Nbutton1"
        Me.Nbutton1.Sequence = 0
        Me.Nbutton1.Size = New System.Drawing.Size(69, 35)
        Me.Nbutton1.TabIndex = 2
        Me.Nbutton1.FontName = "Tahoma"
        Me.Nbutton1.Value = "?"
        '
        'FrmButtonList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 464)
        Me.Controls.Add(Me.Nbutton1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmButtonList"
        Me.ShowInTaskbar = False
        Me.Text = "TypeRight"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.imgClock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.imgUpTack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgDnTack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DelayTimer As Windows.Forms.Timer
    Friend WithEvents secondTimer As Windows.Forms.Timer
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents ProgressBar1 As Windows.Forms.ProgressBar
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents imgOptions As Windows.Forms.PictureBox
    Friend WithEvents imgLock As Windows.Forms.PictureBox
    Friend WithEvents imgClock As Windows.Forms.PictureBox
    Friend WithEvents imgExit As Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents imgDnTack As Windows.Forms.PictureBox
    Friend WithEvents imgUpTack As Windows.Forms.PictureBox
    Friend WithEvents cbNames As Windows.Forms.ComboBox
    Friend WithEvents BtnReDraw As Windows.Forms.Button
    Friend WithEvents Nbutton1 As NbuttonControlLibrary.Nbutton
End Class
