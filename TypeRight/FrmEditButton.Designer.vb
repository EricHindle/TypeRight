<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditButton
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEditButton))
        Me.grpOpts = New System.Windows.Forms.GroupBox()
        Me.chkEncrypt = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblDbField = New System.Windows.Forms.Label()
        Me.BtnAlt = New System.Windows.Forms.Button()
        Me.BtnCtrl = New System.Windows.Forms.Button()
        Me.BtnRightArrow = New System.Windows.Forms.Button()
        Me.BtnDownArrow = New System.Windows.Forms.Button()
        Me.BtnLeftArrow = New System.Windows.Forms.Button()
        Me.BtnUpArrow = New System.Windows.Forms.Button()
        Me.BtnReturn = New System.Windows.Forms.Button()
        Me.BtnBackspace = New System.Windows.Forms.Button()
        Me.BtnPageDown = New System.Windows.Forms.Button()
        Me.BtnEnd = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnBacktab = New System.Windows.Forms.Button()
        Me.BtnPageUp = New System.Windows.Forms.Button()
        Me.BtnHome = New System.Windows.Forms.Button()
        Me.BtnInsert = New System.Windows.Forms.Button()
        Me.BtnTab = New System.Windows.Forms.Button()
        Me.BtnCloseCurlyBracket = New System.Windows.Forms.Button()
        Me.BtnOpenCurlyBracket = New System.Windows.Forms.Button()
        Me.CbDbValue = New System.Windows.Forms.ComboBox()
        Me.SendersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TypeRightDataSet = New TypeRight.TypeRightDataSet()
        Me.TxtPreview = New System.Windows.Forms.RichTextBox()
        Me.TxtString = New System.Windows.Forms.RichTextBox()
        Me.mnuEdit = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangeCaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LowercaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UPPERCASEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TitleCaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TOGGLECASEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.BtnFont = New System.Windows.Forms.Button()
        Me.TxtHint = New System.Windows.Forms.TextBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.LblBtnSeq = New System.Windows.Forms.Label()
        Me.LblBtnGrp = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCaption = New System.Windows.Forms.TextBox()
        Me.SendersTableAdapter = New TypeRight.TypeRightDataSetTableAdapters.sendersTableAdapter()
        Me.grpOpts.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SendersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeRightDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuEdit.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpOpts
        '
        Me.grpOpts.Controls.Add(Me.chkEncrypt)
        Me.grpOpts.Location = New System.Drawing.Point(492, 96)
        Me.grpOpts.Name = "grpOpts"
        Me.grpOpts.Size = New System.Drawing.Size(373, 49)
        Me.grpOpts.TabIndex = 0
        Me.grpOpts.TabStop = False
        Me.grpOpts.Text = "Options"
        '
        'chkEncrypt
        '
        Me.chkEncrypt.AutoSize = True
        Me.chkEncrypt.Location = New System.Drawing.Point(28, 19)
        Me.chkEncrypt.Name = "chkEncrypt"
        Me.chkEncrypt.Size = New System.Drawing.Size(62, 17)
        Me.chkEncrypt.TabIndex = 0
        Me.chkEncrypt.Text = "Encrypt"
        Me.chkEncrypt.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblDbField)
        Me.GroupBox1.Controls.Add(Me.BtnAlt)
        Me.GroupBox1.Controls.Add(Me.BtnCtrl)
        Me.GroupBox1.Controls.Add(Me.BtnRightArrow)
        Me.GroupBox1.Controls.Add(Me.BtnDownArrow)
        Me.GroupBox1.Controls.Add(Me.BtnLeftArrow)
        Me.GroupBox1.Controls.Add(Me.BtnUpArrow)
        Me.GroupBox1.Controls.Add(Me.BtnReturn)
        Me.GroupBox1.Controls.Add(Me.BtnBackspace)
        Me.GroupBox1.Controls.Add(Me.BtnPageDown)
        Me.GroupBox1.Controls.Add(Me.BtnEnd)
        Me.GroupBox1.Controls.Add(Me.BtnDelete)
        Me.GroupBox1.Controls.Add(Me.BtnBacktab)
        Me.GroupBox1.Controls.Add(Me.BtnPageUp)
        Me.GroupBox1.Controls.Add(Me.BtnHome)
        Me.GroupBox1.Controls.Add(Me.BtnInsert)
        Me.GroupBox1.Controls.Add(Me.BtnTab)
        Me.GroupBox1.Controls.Add(Me.BtnCloseCurlyBracket)
        Me.GroupBox1.Controls.Add(Me.BtnOpenCurlyBracket)
        Me.GroupBox1.Controls.Add(Me.CbDbValue)
        Me.GroupBox1.Location = New System.Drawing.Point(492, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(373, 451)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'LblDbField
        '
        Me.LblDbField.AutoSize = True
        Me.LblDbField.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDbField.Location = New System.Drawing.Point(81, 30)
        Me.LblDbField.Name = "LblDbField"
        Me.LblDbField.Size = New System.Drawing.Size(103, 17)
        Me.LblDbField.TabIndex = 19
        Me.LblDbField.Text = "Database Field"
        '
        'BtnAlt
        '
        Me.BtnAlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAlt.Location = New System.Drawing.Point(300, 384)
        Me.BtnAlt.Name = "BtnAlt"
        Me.BtnAlt.Size = New System.Drawing.Size(61, 49)
        Me.BtnAlt.TabIndex = 18
        Me.BtnAlt.Text = "Alt"
        Me.BtnAlt.UseVisualStyleBackColor = True
        '
        'BtnCtrl
        '
        Me.BtnCtrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCtrl.Location = New System.Drawing.Point(12, 384)
        Me.BtnCtrl.Name = "BtnCtrl"
        Me.BtnCtrl.Size = New System.Drawing.Size(61, 49)
        Me.BtnCtrl.TabIndex = 17
        Me.BtnCtrl.Text = "Ctrl"
        Me.BtnCtrl.UseVisualStyleBackColor = True
        '
        'BtnRightArrow
        '
        Me.BtnRightArrow.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnRightArrow.Location = New System.Drawing.Point(228, 384)
        Me.BtnRightArrow.Name = "BtnRightArrow"
        Me.BtnRightArrow.Size = New System.Drawing.Size(61, 49)
        Me.BtnRightArrow.TabIndex = 16
        Me.BtnRightArrow.Text = "g"
        Me.BtnRightArrow.UseVisualStyleBackColor = True
        '
        'BtnDownArrow
        '
        Me.BtnDownArrow.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnDownArrow.Location = New System.Drawing.Point(156, 384)
        Me.BtnDownArrow.Name = "BtnDownArrow"
        Me.BtnDownArrow.Size = New System.Drawing.Size(61, 49)
        Me.BtnDownArrow.TabIndex = 15
        Me.BtnDownArrow.Text = "i"
        Me.BtnDownArrow.UseVisualStyleBackColor = True
        '
        'BtnLeftArrow
        '
        Me.BtnLeftArrow.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnLeftArrow.Location = New System.Drawing.Point(84, 384)
        Me.BtnLeftArrow.Name = "BtnLeftArrow"
        Me.BtnLeftArrow.Size = New System.Drawing.Size(61, 49)
        Me.BtnLeftArrow.TabIndex = 14
        Me.BtnLeftArrow.Text = "f"
        Me.BtnLeftArrow.UseVisualStyleBackColor = True
        '
        'BtnUpArrow
        '
        Me.BtnUpArrow.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnUpArrow.Location = New System.Drawing.Point(156, 324)
        Me.BtnUpArrow.Name = "BtnUpArrow"
        Me.BtnUpArrow.Size = New System.Drawing.Size(61, 49)
        Me.BtnUpArrow.TabIndex = 13
        Me.BtnUpArrow.Text = "h"
        Me.BtnUpArrow.UseVisualStyleBackColor = True
        '
        'BtnReturn
        '
        Me.BtnReturn.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnReturn.Location = New System.Drawing.Point(300, 180)
        Me.BtnReturn.Name = "BtnReturn"
        Me.BtnReturn.Size = New System.Drawing.Size(61, 49)
        Me.BtnReturn.TabIndex = 12
        Me.BtnReturn.Text = "8"
        Me.BtnReturn.UseVisualStyleBackColor = True
        '
        'BtnBackspace
        '
        Me.BtnBackspace.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnBackspace.Location = New System.Drawing.Point(264, 120)
        Me.BtnBackspace.Name = "BtnBackspace"
        Me.BtnBackspace.Size = New System.Drawing.Size(61, 49)
        Me.BtnBackspace.TabIndex = 11
        Me.BtnBackspace.Text = "!"
        Me.BtnBackspace.UseVisualStyleBackColor = True
        '
        'BtnPageDown
        '
        Me.BtnPageDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPageDown.Location = New System.Drawing.Point(228, 240)
        Me.BtnPageDown.Name = "BtnPageDown"
        Me.BtnPageDown.Size = New System.Drawing.Size(61, 49)
        Me.BtnPageDown.TabIndex = 10
        Me.BtnPageDown.Text = "Page Down"
        Me.BtnPageDown.UseVisualStyleBackColor = True
        '
        'BtnEnd
        '
        Me.BtnEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEnd.Location = New System.Drawing.Point(156, 240)
        Me.BtnEnd.Name = "BtnEnd"
        Me.BtnEnd.Size = New System.Drawing.Size(61, 49)
        Me.BtnEnd.TabIndex = 9
        Me.BtnEnd.Text = "End"
        Me.BtnEnd.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.Location = New System.Drawing.Point(84, 240)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(61, 49)
        Me.BtnDelete.TabIndex = 8
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnBacktab
        '
        Me.BtnBacktab.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnBacktab.Location = New System.Drawing.Point(12, 240)
        Me.BtnBacktab.Name = "BtnBacktab"
        Me.BtnBacktab.Size = New System.Drawing.Size(61, 49)
        Me.BtnBacktab.TabIndex = 7
        Me.BtnBacktab.Text = ")"
        Me.BtnBacktab.UseVisualStyleBackColor = True
        '
        'BtnPageUp
        '
        Me.BtnPageUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPageUp.Location = New System.Drawing.Point(228, 180)
        Me.BtnPageUp.Name = "BtnPageUp"
        Me.BtnPageUp.Size = New System.Drawing.Size(61, 49)
        Me.BtnPageUp.TabIndex = 6
        Me.BtnPageUp.Text = "Page Up"
        Me.BtnPageUp.UseVisualStyleBackColor = True
        '
        'BtnHome
        '
        Me.BtnHome.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHome.Location = New System.Drawing.Point(156, 180)
        Me.BtnHome.Name = "BtnHome"
        Me.BtnHome.Size = New System.Drawing.Size(61, 49)
        Me.BtnHome.TabIndex = 5
        Me.BtnHome.Text = "Home"
        Me.BtnHome.UseVisualStyleBackColor = True
        '
        'BtnInsert
        '
        Me.BtnInsert.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInsert.Location = New System.Drawing.Point(84, 180)
        Me.BtnInsert.Name = "BtnInsert"
        Me.BtnInsert.Size = New System.Drawing.Size(61, 49)
        Me.BtnInsert.TabIndex = 4
        Me.BtnInsert.Text = "Insert"
        Me.BtnInsert.UseVisualStyleBackColor = True
        '
        'BtnTab
        '
        Me.BtnTab.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnTab.Location = New System.Drawing.Point(12, 180)
        Me.BtnTab.Name = "BtnTab"
        Me.BtnTab.Size = New System.Drawing.Size(61, 49)
        Me.BtnTab.TabIndex = 3
        Me.BtnTab.Text = "*"
        Me.BtnTab.UseVisualStyleBackColor = True
        '
        'BtnCloseCurlyBracket
        '
        Me.BtnCloseCurlyBracket.Location = New System.Drawing.Point(156, 120)
        Me.BtnCloseCurlyBracket.Name = "BtnCloseCurlyBracket"
        Me.BtnCloseCurlyBracket.Size = New System.Drawing.Size(61, 49)
        Me.BtnCloseCurlyBracket.TabIndex = 2
        Me.BtnCloseCurlyBracket.Text = "}"
        Me.BtnCloseCurlyBracket.UseVisualStyleBackColor = True
        '
        'BtnOpenCurlyBracket
        '
        Me.BtnOpenCurlyBracket.Location = New System.Drawing.Point(84, 120)
        Me.BtnOpenCurlyBracket.Name = "BtnOpenCurlyBracket"
        Me.BtnOpenCurlyBracket.Size = New System.Drawing.Size(61, 49)
        Me.BtnOpenCurlyBracket.TabIndex = 1
        Me.BtnOpenCurlyBracket.Text = "{"
        Me.BtnOpenCurlyBracket.UseVisualStyleBackColor = True
        '
        'CbDbValue
        '
        Me.CbDbValue.DataSource = Me.SendersBindingSource
        Me.CbDbValue.DisplayMember = "sendername"
        Me.CbDbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDbValue.FormattingEnabled = True
        Me.CbDbValue.Location = New System.Drawing.Point(84, 60)
        Me.CbDbValue.Name = "CbDbValue"
        Me.CbDbValue.Size = New System.Drawing.Size(277, 21)
        Me.CbDbValue.TabIndex = 0
        Me.CbDbValue.ValueMember = "senderid"
        '
        'SendersBindingSource
        '
        Me.SendersBindingSource.DataMember = "senders"
        Me.SendersBindingSource.DataSource = Me.TypeRightDataSet
        '
        'TypeRightDataSet
        '
        Me.TypeRightDataSet.DataSetName = "TypeRightDataSet"
        Me.TypeRightDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TxtPreview
        '
        Me.TxtPreview.Location = New System.Drawing.Point(12, 372)
        Me.TxtPreview.Name = "TxtPreview"
        Me.TxtPreview.Size = New System.Drawing.Size(457, 169)
        Me.TxtPreview.TabIndex = 2
        Me.TxtPreview.Text = ""
        '
        'TxtString
        '
        Me.TxtString.ContextMenuStrip = Me.mnuEdit
        Me.TxtString.Location = New System.Drawing.Point(12, 144)
        Me.TxtString.Name = "TxtString"
        Me.TxtString.Size = New System.Drawing.Size(457, 181)
        Me.TxtString.TabIndex = 3
        Me.TxtString.Text = ""
        '
        'mnuEdit
        '
        Me.mnuEdit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator1, Me.SelectAllToolStripMenuItem, Me.ToolStripSeparator2, Me.ChangeCaseToolStripMenuItem})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(144, 148)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(140, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(140, 6)
        '
        'ChangeCaseToolStripMenuItem
        '
        Me.ChangeCaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LowercaseToolStripMenuItem, Me.UPPERCASEToolStripMenuItem, Me.TitleCaseToolStripMenuItem, Me.TOGGLECASEToolStripMenuItem})
        Me.ChangeCaseToolStripMenuItem.Name = "ChangeCaseToolStripMenuItem"
        Me.ChangeCaseToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.ChangeCaseToolStripMenuItem.Text = "Change Case"
        '
        'LowercaseToolStripMenuItem
        '
        Me.LowercaseToolStripMenuItem.Name = "LowercaseToolStripMenuItem"
        Me.LowercaseToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.LowercaseToolStripMenuItem.Text = "lowercase"
        '
        'UPPERCASEToolStripMenuItem
        '
        Me.UPPERCASEToolStripMenuItem.Name = "UPPERCASEToolStripMenuItem"
        Me.UPPERCASEToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.UPPERCASEToolStripMenuItem.Text = "UPPERCASE"
        '
        'TitleCaseToolStripMenuItem
        '
        Me.TitleCaseToolStripMenuItem.Name = "TitleCaseToolStripMenuItem"
        Me.TitleCaseToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.TitleCaseToolStripMenuItem.Text = "Title Case"
        '
        'TOGGLECASEToolStripMenuItem
        '
        Me.TOGGLECASEToolStripMenuItem.Name = "TOGGLECASEToolStripMenuItem"
        Me.TOGGLECASEToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.TOGGLECASEToolStripMenuItem.Text = "tOGGLE cASE"
        '
        'FontDialog1
        '
        Me.FontDialog1.FontMustExist = True
        '
        'BtnFont
        '
        Me.BtnFont.Location = New System.Drawing.Point(336, 12)
        Me.BtnFont.Name = "BtnFont"
        Me.BtnFont.Size = New System.Drawing.Size(193, 37)
        Me.BtnFont.TabIndex = 4
        Me.BtnFont.Text = "Caption Font"
        Me.BtnFont.UseVisualStyleBackColor = True
        '
        'TxtHint
        '
        Me.TxtHint.Location = New System.Drawing.Point(108, 60)
        Me.TxtHint.Name = "TxtHint"
        Me.TxtHint.Size = New System.Drawing.Size(337, 20)
        Me.TxtHint.TabIndex = 6
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(312, 564)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(121, 23)
        Me.BtnCancel.TabIndex = 7
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.BtnOK.Location = New System.Drawing.Point(12, 564)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(121, 23)
        Me.BtnOK.TabIndex = 8
        Me.BtnOK.Text = "Update"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'LblBtnSeq
        '
        Me.LblBtnSeq.AutoSize = True
        Me.LblBtnSeq.Location = New System.Drawing.Point(672, 60)
        Me.LblBtnSeq.Name = "LblBtnSeq"
        Me.LblBtnSeq.Size = New System.Drawing.Size(39, 13)
        Me.LblBtnSeq.TabIndex = 9
        Me.LblBtnSeq.Text = "Label2"
        '
        'LblBtnGrp
        '
        Me.LblBtnGrp.AutoSize = True
        Me.LblBtnGrp.Location = New System.Drawing.Point(672, 24)
        Me.LblBtnGrp.Name = "LblBtnGrp"
        Me.LblBtnGrp.Size = New System.Drawing.Size(39, 13)
        Me.LblBtnGrp.TabIndex = 10
        Me.LblBtnGrp.Text = "Label2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(552, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Button Group:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 336)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Preview"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Hint"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Caption"
        '
        'txtCaption
        '
        Me.txtCaption.Location = New System.Drawing.Point(108, 12)
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.Size = New System.Drawing.Size(181, 20)
        Me.txtCaption.TabIndex = 15
        '
        'SendersTableAdapter
        '
        Me.SendersTableAdapter.ClearBeforeFill = True
        '
        'FrmEditButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(890, 640)
        Me.Controls.Add(Me.txtCaption)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblBtnGrp)
        Me.Controls.Add(Me.LblBtnSeq)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.TxtHint)
        Me.Controls.Add(Me.BtnFont)
        Me.Controls.Add(Me.TxtString)
        Me.Controls.Add(Me.TxtPreview)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpOpts)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmEditButton"
        Me.Text = "Edit Button"
        Me.grpOpts.ResumeLayout(False)
        Me.grpOpts.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SendersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeRightDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuEdit.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpOpts As Windows.Forms.GroupBox
    Friend WithEvents chkEncrypt As Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents LblDbField As Windows.Forms.Label
    Friend WithEvents BtnAlt As Windows.Forms.Button
    Friend WithEvents BtnCtrl As Windows.Forms.Button
    Friend WithEvents BtnRightArrow As Windows.Forms.Button
    Friend WithEvents BtnDownArrow As Windows.Forms.Button
    Friend WithEvents BtnLeftArrow As Windows.Forms.Button
    Friend WithEvents BtnUpArrow As Windows.Forms.Button
    Friend WithEvents BtnReturn As Windows.Forms.Button
    Friend WithEvents BtnBackspace As Windows.Forms.Button
    Friend WithEvents BtnPageDown As Windows.Forms.Button
    Friend WithEvents BtnEnd As Windows.Forms.Button
    Friend WithEvents BtnDelete As Windows.Forms.Button
    Friend WithEvents BtnBacktab As Windows.Forms.Button
    Friend WithEvents BtnPageUp As Windows.Forms.Button
    Friend WithEvents BtnHome As Windows.Forms.Button
    Friend WithEvents BtnInsert As Windows.Forms.Button
    Friend WithEvents BtnTab As Windows.Forms.Button
    Friend WithEvents BtnCloseCurlyBracket As Windows.Forms.Button
    Friend WithEvents BtnOpenCurlyBracket As Windows.Forms.Button
    Friend WithEvents CbDbValue As Windows.Forms.ComboBox
    Friend WithEvents TxtPreview As Windows.Forms.RichTextBox
    Friend WithEvents TxtString As Windows.Forms.RichTextBox
    Friend WithEvents FontDialog1 As Windows.Forms.FontDialog
    Friend WithEvents BtnFont As Windows.Forms.Button
    Friend WithEvents TxtHint As Windows.Forms.TextBox
    Friend WithEvents BtnCancel As Windows.Forms.Button
    Friend WithEvents BtnOK As Windows.Forms.Button
    Friend WithEvents LblBtnSeq As Windows.Forms.Label
    Friend WithEvents LblBtnGrp As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents mnuEdit As Windows.Forms.ContextMenuStrip
    Friend WithEvents CutToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ChangeCaseToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents LowercaseToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents UPPERCASEToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents TitleCaseToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents TOGGLECASEToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCaption As Windows.Forms.TextBox
    Friend WithEvents TypeRightDataSet As TypeRightDataSet
    Friend WithEvents SendersBindingSource As Windows.Forms.BindingSource
    Friend WithEvents SendersTableAdapter As TypeRightDataSetTableAdapters.sendersTableAdapter
End Class
