<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDbUpdate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDbUpdate))
        Me.CbOcc = New System.Windows.Forms.ComboBox()
        Me.CbMarStat = New System.Windows.Forms.ComboBox()
        Me.CbGender = New System.Windows.Forms.ComboBox()
        Me.CbTitle = New System.Windows.Forms.ComboBox()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.TxtAge = New System.Windows.Forms.TextBox()
        Me.DtpDob = New System.Windows.Forms.DateTimePicker()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.TxtCountry = New System.Windows.Forms.TextBox()
        Me.TxtPhone = New System.Windows.Forms.TextBox()
        Me.TxtPostCode = New System.Windows.Forms.TextBox()
        Me.TxtCounty = New System.Windows.Forms.TextBox()
        Me.TxtTown = New System.Windows.Forms.TextBox()
        Me.TxtAdd2 = New System.Windows.Forms.TextBox()
        Me.TxtAdd1 = New System.Windows.Forms.TextBox()
        Me.TxtSurname = New System.Windows.Forms.TextBox()
        Me.TxtForename = New System.Windows.Forms.TextBox()
        Me.TxtId = New System.Windows.Forms.TextBox()
        Me.TxtMobile = New System.Windows.Forms.TextBox()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.BtnTop = New System.Windows.Forms.Button()
        Me.BtnPrev = New System.Windows.Forms.Button()
        Me.BtnNext = New System.Windows.Forms.Button()
        Me.BtnEnd = New System.Windows.Forms.Button()
        Me.BtnDel = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnUpd = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBkUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBkUpGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBkUpButtons = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBkUpSenders = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBkUpSenderButtons = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBkUpAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRest = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRestGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRestButtons = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRestSenders = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRestSenderButtons = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRestAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtSWord = New System.Windows.Forms.TextBox()
        Me.TxtUsername = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.LblId = New System.Windows.Forms.Label()
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'CbOcc
        '
        Me.CbOcc.FormattingEnabled = True
        Me.CbOcc.Items.AddRange(New Object() {"Retired", "Full-time", "Part-time", "Student", "Unemployed"})
        Me.CbOcc.Location = New System.Drawing.Point(116, 147)
        Me.CbOcc.Name = "CbOcc"
        Me.CbOcc.Size = New System.Drawing.Size(121, 24)
        Me.CbOcc.TabIndex = 4
        '
        'CbMarStat
        '
        Me.CbMarStat.FormattingEnabled = True
        Me.CbMarStat.Items.AddRange(New Object() {"Married", "Single", "Widowed", "Divorced", "Separated"})
        Me.CbMarStat.Location = New System.Drawing.Point(116, 117)
        Me.CbMarStat.Name = "CbMarStat"
        Me.CbMarStat.Size = New System.Drawing.Size(121, 24)
        Me.CbMarStat.TabIndex = 3
        '
        'CbGender
        '
        Me.CbGender.FormattingEnabled = True
        Me.CbGender.Items.AddRange(New Object() {"Male", "Female", "Other"})
        Me.CbGender.Location = New System.Drawing.Point(116, 87)
        Me.CbGender.Name = "CbGender"
        Me.CbGender.Size = New System.Drawing.Size(121, 24)
        Me.CbGender.TabIndex = 2
        '
        'CbTitle
        '
        Me.CbTitle.FormattingEnabled = True
        Me.CbTitle.Items.AddRange(New Object() {"Mr.", "Ms.", "Mrs.", "Miss"})
        Me.CbTitle.Location = New System.Drawing.Point(100, 53)
        Me.CbTitle.Name = "CbTitle"
        Me.CbTitle.Size = New System.Drawing.Size(101, 24)
        Me.CbTitle.TabIndex = 0
        '
        'BtnOk
        '
        Me.BtnOk.Location = New System.Drawing.Point(685, 512)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(91, 38)
        Me.BtnOk.TabIndex = 7
        Me.BtnOk.Text = "Done"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'TxtAge
        '
        Me.TxtAge.Location = New System.Drawing.Point(187, 27)
        Me.TxtAge.Name = "TxtAge"
        Me.TxtAge.Size = New System.Drawing.Size(50, 24)
        Me.TxtAge.TabIndex = 0
        '
        'DtpDob
        '
        Me.DtpDob.Location = New System.Drawing.Point(82, 57)
        Me.DtpDob.Name = "DtpDob"
        Me.DtpDob.Size = New System.Drawing.Size(155, 24)
        Me.DtpDob.TabIndex = 1
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(65, 35)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(170, 24)
        Me.TxtEmail.TabIndex = 0
        '
        'TxtCountry
        '
        Me.TxtCountry.Location = New System.Drawing.Point(100, 204)
        Me.TxtCountry.Name = "TxtCountry"
        Me.TxtCountry.Size = New System.Drawing.Size(218, 24)
        Me.TxtCountry.TabIndex = 7
        '
        'TxtPhone
        '
        Me.TxtPhone.Location = New System.Drawing.Point(65, 70)
        Me.TxtPhone.Name = "TxtPhone"
        Me.TxtPhone.Size = New System.Drawing.Size(170, 24)
        Me.TxtPhone.TabIndex = 1
        '
        'TxtPostCode
        '
        Me.TxtPostCode.Location = New System.Drawing.Point(100, 234)
        Me.TxtPostCode.Name = "TxtPostCode"
        Me.TxtPostCode.Size = New System.Drawing.Size(100, 24)
        Me.TxtPostCode.TabIndex = 8
        '
        'TxtCounty
        '
        Me.TxtCounty.Location = New System.Drawing.Point(100, 174)
        Me.TxtCounty.Name = "TxtCounty"
        Me.TxtCounty.Size = New System.Drawing.Size(345, 24)
        Me.TxtCounty.TabIndex = 6
        '
        'TxtTown
        '
        Me.TxtTown.Location = New System.Drawing.Point(100, 144)
        Me.TxtTown.Name = "TxtTown"
        Me.TxtTown.Size = New System.Drawing.Size(345, 24)
        Me.TxtTown.TabIndex = 5
        '
        'TxtAdd2
        '
        Me.TxtAdd2.Location = New System.Drawing.Point(100, 114)
        Me.TxtAdd2.Name = "TxtAdd2"
        Me.TxtAdd2.Size = New System.Drawing.Size(348, 24)
        Me.TxtAdd2.TabIndex = 4
        '
        'TxtAdd1
        '
        Me.TxtAdd1.Location = New System.Drawing.Point(100, 83)
        Me.TxtAdd1.Name = "TxtAdd1"
        Me.TxtAdd1.Size = New System.Drawing.Size(345, 24)
        Me.TxtAdd1.TabIndex = 3
        '
        'TxtSurname
        '
        Me.TxtSurname.Location = New System.Drawing.Point(359, 53)
        Me.TxtSurname.Name = "TxtSurname"
        Me.TxtSurname.Size = New System.Drawing.Size(150, 24)
        Me.TxtSurname.TabIndex = 2
        '
        'TxtForename
        '
        Me.TxtForename.Location = New System.Drawing.Point(207, 53)
        Me.TxtForename.Name = "TxtForename"
        Me.TxtForename.Size = New System.Drawing.Size(146, 24)
        Me.TxtForename.TabIndex = 1
        '
        'TxtId
        '
        Me.TxtId.Enabled = False
        Me.TxtId.Location = New System.Drawing.Point(90, 23)
        Me.TxtId.Name = "TxtId"
        Me.TxtId.Size = New System.Drawing.Size(100, 24)
        Me.TxtId.TabIndex = 0
        '
        'TxtMobile
        '
        Me.TxtMobile.Location = New System.Drawing.Point(65, 105)
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(170, 24)
        Me.TxtMobile.TabIndex = 2
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(136, 105)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Size = New System.Drawing.Size(152, 24)
        Me.TxtPassword.TabIndex = 2
        '
        'BtnTop
        '
        Me.BtnTop.Location = New System.Drawing.Point(207, 17)
        Me.BtnTop.Name = "BtnTop"
        Me.BtnTop.Size = New System.Drawing.Size(41, 34)
        Me.BtnTop.TabIndex = 1
        Me.BtnTop.Text = "Top"
        Me.ToolTip4.SetToolTip(Me.BtnTop, "Go to first database record")
        Me.BtnTop.UseVisualStyleBackColor = True
        '
        'BtnPrev
        '
        Me.BtnPrev.Location = New System.Drawing.Point(266, 17)
        Me.BtnPrev.Name = "BtnPrev"
        Me.BtnPrev.Size = New System.Drawing.Size(47, 34)
        Me.BtnPrev.TabIndex = 2
        Me.BtnPrev.Text = "Prev"
        Me.ToolTip4.SetToolTip(Me.BtnPrev, "Go to previous record")
        Me.BtnPrev.UseVisualStyleBackColor = True
        '
        'BtnNext
        '
        Me.BtnNext.Location = New System.Drawing.Point(331, 17)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(47, 34)
        Me.BtnNext.TabIndex = 3
        Me.BtnNext.Text = "Next"
        Me.ToolTip4.SetToolTip(Me.BtnNext, "Go to next record")
        Me.BtnNext.UseVisualStyleBackColor = True
        '
        'BtnEnd
        '
        Me.BtnEnd.Location = New System.Drawing.Point(396, 17)
        Me.BtnEnd.Name = "BtnEnd"
        Me.BtnEnd.Size = New System.Drawing.Size(41, 34)
        Me.BtnEnd.TabIndex = 4
        Me.BtnEnd.Text = "End"
        Me.ToolTip4.SetToolTip(Me.BtnEnd, "Go to last database record")
        Me.BtnEnd.UseVisualStyleBackColor = True
        '
        'BtnDel
        '
        Me.BtnDel.Location = New System.Drawing.Point(22, 129)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(41, 34)
        Me.BtnDel.TabIndex = 2
        Me.BtnDel.Text = "Del"
        Me.ToolTip4.SetToolTip(Me.BtnDel, "Delete current sender")
        Me.BtnDel.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(22, 30)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(41, 34)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "Add"
        Me.ToolTip4.SetToolTip(Me.BtnAdd, "Add a new sender")
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnUpd
        '
        Me.BtnUpd.Location = New System.Drawing.Point(22, 80)
        Me.BtnUpd.Name = "BtnUpd"
        Me.BtnUpd.Size = New System.Drawing.Size(41, 34)
        Me.BtnUpd.TabIndex = 1
        Me.BtnUpd.Text = "Upd"
        Me.ToolTip4.SetToolTip(Me.BtnUpd, "Update selected sender")
        Me.BtnUpd.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.TypeRight.My.Resources.Resources.statusstrip
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 563)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(809, 22)
        Me.StatusStrip1.TabIndex = 9
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(356, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Last Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(209, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "First Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Marital Status"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Occupation"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 17)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Gender"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(100, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 17)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Title"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 17)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Default username"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 17)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Secret word"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 109)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 17)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Password"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 17)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Age:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 17)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Birthdate:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 17)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Email"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 17)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Phone:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 237)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 17)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "PostCode:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 207)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 17)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Country:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 149)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 17)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Town:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 119)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 17)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Address2:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 86)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(69, 17)
        Me.Label18.TabIndex = 13
        Me.Label18.Text = "Address1:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 56)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 17)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "Name:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 26)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(75, 17)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "AddressID:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 109)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(50, 17)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Mobile:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackgroundImage = Global.TypeRight.My.Resources.Resources.menustrip
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFile})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(809, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuFile
        '
        Me.MnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuBkUp, Me.MnuRest, Me.ToolStripSeparator1, Me.MnuClose})
        Me.MnuFile.Name = "MnuFile"
        Me.MnuFile.Size = New System.Drawing.Size(37, 20)
        Me.MnuFile.Text = "File"
        '
        'MnuBkUp
        '
        Me.MnuBkUp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuBkUpGroups, Me.MnuBkUpButtons, Me.MnuBkUpSenders, Me.MnuBkUpSenderButtons, Me.MnuBkUpAll})
        Me.MnuBkUp.Name = "MnuBkUp"
        Me.MnuBkUp.Size = New System.Drawing.Size(113, 22)
        Me.MnuBkUp.Text = "Backup"
        '
        'MnuBkUpGroups
        '
        Me.MnuBkUpGroups.Name = "MnuBkUpGroups"
        Me.MnuBkUpGroups.Size = New System.Drawing.Size(154, 22)
        Me.MnuBkUpGroups.Text = "Groups"
        '
        'MnuBkUpButtons
        '
        Me.MnuBkUpButtons.Name = "MnuBkUpButtons"
        Me.MnuBkUpButtons.Size = New System.Drawing.Size(154, 22)
        Me.MnuBkUpButtons.Text = "Group Buttons"
        '
        'MnuBkUpSenders
        '
        Me.MnuBkUpSenders.Name = "MnuBkUpSenders"
        Me.MnuBkUpSenders.Size = New System.Drawing.Size(154, 22)
        Me.MnuBkUpSenders.Text = "Senders"
        '
        'MnuBkUpSenderButtons
        '
        Me.MnuBkUpSenderButtons.Name = "MnuBkUpSenderButtons"
        Me.MnuBkUpSenderButtons.Size = New System.Drawing.Size(154, 22)
        Me.MnuBkUpSenderButtons.Text = "Sender Buttons"
        '
        'MnuBkUpAll
        '
        Me.MnuBkUpAll.Name = "MnuBkUpAll"
        Me.MnuBkUpAll.Size = New System.Drawing.Size(154, 22)
        Me.MnuBkUpAll.Text = "All"
        '
        'MnuRest
        '
        Me.MnuRest.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuRestGroups, Me.MnuRestButtons, Me.MnuRestSenders, Me.MnuRestSenderButtons, Me.MnuRestAll})
        Me.MnuRest.Name = "MnuRest"
        Me.MnuRest.Size = New System.Drawing.Size(113, 22)
        Me.MnuRest.Text = "Restore"
        '
        'MnuRestGroups
        '
        Me.MnuRestGroups.Name = "MnuRestGroups"
        Me.MnuRestGroups.Size = New System.Drawing.Size(154, 22)
        Me.MnuRestGroups.Text = "Groups"
        '
        'MnuRestButtons
        '
        Me.MnuRestButtons.Name = "MnuRestButtons"
        Me.MnuRestButtons.Size = New System.Drawing.Size(154, 22)
        Me.MnuRestButtons.Text = "Group Buttons"
        '
        'MnuRestSenders
        '
        Me.MnuRestSenders.Name = "MnuRestSenders"
        Me.MnuRestSenders.Size = New System.Drawing.Size(154, 22)
        Me.MnuRestSenders.Text = "Senders"
        '
        'MnuRestSenderButtons
        '
        Me.MnuRestSenderButtons.Name = "MnuRestSenderButtons"
        Me.MnuRestSenderButtons.Size = New System.Drawing.Size(154, 22)
        Me.MnuRestSenderButtons.Text = "Sender Buttons"
        '
        'MnuRestAll
        '
        Me.MnuRestAll.Name = "MnuRestAll"
        Me.MnuRestAll.Size = New System.Drawing.Size(154, 22)
        Me.MnuRestAll.Text = "All"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(110, 6)
        '
        'MnuClose
        '
        Me.MnuClose.Name = "MnuClose"
        Me.MnuClose.Size = New System.Drawing.Size(113, 22)
        Me.MnuClose.Text = "Close"
        '
        'TxtSWord
        '
        Me.TxtSWord.Location = New System.Drawing.Point(136, 35)
        Me.TxtSWord.Name = "TxtSWord"
        Me.TxtSWord.Size = New System.Drawing.Size(152, 24)
        Me.TxtSWord.TabIndex = 0
        '
        'TxtUsername
        '
        Me.TxtUsername.Location = New System.Drawing.Point(136, 70)
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Size = New System.Drawing.Size(152, 24)
        Me.TxtUsername.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(12, 179)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(59, 17)
        Me.Label22.TabIndex = 16
        Me.Label22.Text = "County:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CbTitle)
        Me.GroupBox1.Controls.Add(Me.TxtSurname)
        Me.GroupBox1.Controls.Add(Me.TxtForename)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.TxtAdd2)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.TxtAdd1)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.TxtTown)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.TxtCountry)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.TxtPostCode)
        Me.GroupBox1.Controls.Add(Me.TxtCounty)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(515, 272)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Name and Address"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtAge)
        Me.GroupBox2.Controls.Add(Me.DtpDob)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.CbGender)
        Me.GroupBox2.Controls.Add(Me.CbOcc)
        Me.GroupBox2.Controls.Add(Me.CbMarStat)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(557, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 186)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Personal details"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtPassword)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.TxtUsername)
        Me.GroupBox3.Controls.Add(Me.TxtSWord)
        Me.GroupBox3.Location = New System.Drawing.Point(24, 376)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(298, 148)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Security"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TxtMobile)
        Me.GroupBox4.Controls.Add(Me.TxtEmail)
        Me.GroupBox4.Controls.Add(Me.TxtPhone)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Location = New System.Drawing.Point(328, 376)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(248, 148)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Contact"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.BtnClear)
        Me.GroupBox5.Controls.Add(Me.TxtId)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.BtnEnd)
        Me.GroupBox5.Controls.Add(Me.BtnTop)
        Me.GroupBox5.Controls.Add(Me.BtnPrev)
        Me.GroupBox5.Controls.Add(Me.BtnNext)
        Me.GroupBox5.Location = New System.Drawing.Point(24, 27)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(515, 56)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Record"
        '
        'BtnClear
        '
        Me.BtnClear.Location = New System.Drawing.Point(462, 17)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(47, 34)
        Me.BtnClear.TabIndex = 5
        Me.BtnClear.Text = "Clear"
        Me.ToolTip4.SetToolTip(Me.BtnClear, "No selected record")
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.BtnAdd)
        Me.GroupBox6.Controls.Add(Me.BtnDel)
        Me.GroupBox6.Controls.Add(Me.BtnUpd)
        Me.GroupBox6.Location = New System.Drawing.Point(663, 302)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(91, 184)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Action"
        '
        'LblId
        '
        Me.LblId.AutoSize = True
        Me.LblId.Location = New System.Drawing.Point(588, 53)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(21, 17)
        Me.LblId.TabIndex = 6
        Me.LblId.Text = "-1"
        Me.LblId.Visible = False
        '
        'FrmDbUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 585)
        Me.Controls.Add(Me.LblId)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.BtnOk)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Name = "FrmDbUpdate"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "dB Update"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CbOcc As Windows.Forms.ComboBox
    Friend WithEvents CbMarStat As Windows.Forms.ComboBox
    Friend WithEvents CbGender As Windows.Forms.ComboBox
    Friend WithEvents CbTitle As Windows.Forms.ComboBox
    Friend WithEvents BtnOk As Windows.Forms.Button
    Friend WithEvents TxtAge As Windows.Forms.TextBox
    Friend WithEvents DtpDob As Windows.Forms.DateTimePicker
    Friend WithEvents TxtEmail As Windows.Forms.TextBox
    Friend WithEvents TxtCountry As Windows.Forms.TextBox
    Friend WithEvents TxtPhone As Windows.Forms.TextBox
    Friend WithEvents TxtPostCode As Windows.Forms.TextBox
    Friend WithEvents TxtCounty As Windows.Forms.TextBox
    Friend WithEvents TxtTown As Windows.Forms.TextBox
    Friend WithEvents TxtAdd2 As Windows.Forms.TextBox
    Friend WithEvents TxtAdd1 As Windows.Forms.TextBox
    Friend WithEvents TxtSurname As Windows.Forms.TextBox
    Friend WithEvents TxtForename As Windows.Forms.TextBox
    Friend WithEvents TxtId As Windows.Forms.TextBox
    Friend WithEvents TxtMobile As Windows.Forms.TextBox
    Friend WithEvents TxtPassword As Windows.Forms.TextBox
    Friend WithEvents BtnTop As Windows.Forms.Button
    Friend WithEvents BtnPrev As Windows.Forms.Button
    Friend WithEvents BtnNext As Windows.Forms.Button
    Friend WithEvents BtnEnd As Windows.Forms.Button
    Friend WithEvents BtnDel As Windows.Forms.Button
    Friend WithEvents BtnAdd As Windows.Forms.Button
    Friend WithEvents BtnUpd As Windows.Forms.Button
    Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
    Friend WithEvents LblStatus As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents Label19 As Windows.Forms.Label
    Friend WithEvents Label20 As Windows.Forms.Label
    Friend WithEvents Label21 As Windows.Forms.Label
    Friend WithEvents MenuStrip1 As Windows.Forms.MenuStrip
    Friend WithEvents MnuFile As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuBkUp As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuBkUpSenders As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuBkUpButtons As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuBkUpGroups As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuBkUpAll As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRest As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRestSenders As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRestButtons As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRestGroups As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRestAll As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuClose As Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtSWord As Windows.Forms.TextBox
    Friend WithEvents TxtUsername As Windows.Forms.TextBox
    Friend WithEvents Label22 As Windows.Forms.Label
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As Windows.Forms.GroupBox
    Friend WithEvents BtnClear As Windows.Forms.Button
    Friend WithEvents MnuBkUpSenderButtons As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRestSenderButtons As Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblId As Windows.Forms.Label
    Friend WithEvents ToolTip4 As Windows.Forms.ToolTip
End Class
