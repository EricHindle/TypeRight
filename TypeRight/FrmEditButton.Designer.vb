﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.TxtValue = New System.Windows.Forms.RichTextBox()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblErrs = New System.Windows.Forms.Label()
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
        Me.grpOpts.Location = New System.Drawing.Point(495, 74)
        Me.grpOpts.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.grpOpts.Name = "grpOpts"
        Me.grpOpts.Padding = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.grpOpts.Size = New System.Drawing.Size(369, 60)
        Me.grpOpts.TabIndex = 3
        Me.grpOpts.TabStop = False
        Me.grpOpts.Text = "Options"
        '
        'chkEncrypt
        '
        Me.chkEncrypt.AutoSize = True
        Me.chkEncrypt.Location = New System.Drawing.Point(33, 23)
        Me.chkEncrypt.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.chkEncrypt.Name = "chkEncrypt"
        Me.chkEncrypt.Size = New System.Drawing.Size(76, 21)
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
        Me.GroupBox1.Location = New System.Drawing.Point(495, 142)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(369, 397)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'LblDbField
        '
        Me.LblDbField.AutoSize = True
        Me.LblDbField.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDbField.Location = New System.Drawing.Point(80, 22)
        Me.LblDbField.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblDbField.Name = "LblDbField"
        Me.LblDbField.Size = New System.Drawing.Size(103, 17)
        Me.LblDbField.TabIndex = 0
        Me.LblDbField.Text = "Database Field"
        '
        'BtnAlt
        '
        Me.BtnAlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAlt.Location = New System.Drawing.Point(298, 332)
        Me.BtnAlt.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnAlt.Name = "BtnAlt"
        Me.BtnAlt.Size = New System.Drawing.Size(55, 46)
        Me.BtnAlt.TabIndex = 18
        Me.BtnAlt.Text = "Alt"
        Me.BtnAlt.UseVisualStyleBackColor = True
        '
        'BtnCtrl
        '
        Me.BtnCtrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCtrl.Location = New System.Drawing.Point(15, 332)
        Me.BtnCtrl.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnCtrl.Name = "BtnCtrl"
        Me.BtnCtrl.Size = New System.Drawing.Size(55, 46)
        Me.BtnCtrl.TabIndex = 16
        Me.BtnCtrl.Text = "Ctrl"
        Me.BtnCtrl.UseVisualStyleBackColor = True
        '
        'BtnRightArrow
        '
        Me.BtnRightArrow.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnRightArrow.Location = New System.Drawing.Point(225, 282)
        Me.BtnRightArrow.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnRightArrow.Name = "BtnRightArrow"
        Me.BtnRightArrow.Size = New System.Drawing.Size(55, 46)
        Me.BtnRightArrow.TabIndex = 15
        Me.BtnRightArrow.Text = "g"
        Me.BtnRightArrow.UseVisualStyleBackColor = True
        '
        'BtnDownArrow
        '
        Me.BtnDownArrow.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnDownArrow.Location = New System.Drawing.Point(151, 332)
        Me.BtnDownArrow.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnDownArrow.Name = "BtnDownArrow"
        Me.BtnDownArrow.Size = New System.Drawing.Size(55, 46)
        Me.BtnDownArrow.TabIndex = 17
        Me.BtnDownArrow.Text = "i"
        Me.BtnDownArrow.UseVisualStyleBackColor = True
        '
        'BtnLeftArrow
        '
        Me.BtnLeftArrow.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnLeftArrow.Location = New System.Drawing.Point(83, 282)
        Me.BtnLeftArrow.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnLeftArrow.Name = "BtnLeftArrow"
        Me.BtnLeftArrow.Size = New System.Drawing.Size(55, 46)
        Me.BtnLeftArrow.TabIndex = 14
        Me.BtnLeftArrow.Text = "f"
        Me.BtnLeftArrow.UseVisualStyleBackColor = True
        '
        'BtnUpArrow
        '
        Me.BtnUpArrow.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnUpArrow.Location = New System.Drawing.Point(151, 237)
        Me.BtnUpArrow.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnUpArrow.Name = "BtnUpArrow"
        Me.BtnUpArrow.Size = New System.Drawing.Size(55, 46)
        Me.BtnUpArrow.TabIndex = 13
        Me.BtnUpArrow.Text = "h"
        Me.BtnUpArrow.UseVisualStyleBackColor = True
        '
        'BtnReturn
        '
        Me.BtnReturn.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnReturn.Location = New System.Drawing.Point(298, 183)
        Me.BtnReturn.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnReturn.Name = "BtnReturn"
        Me.BtnReturn.Size = New System.Drawing.Size(55, 46)
        Me.BtnReturn.TabIndex = 12
        Me.BtnReturn.Text = "8"
        Me.BtnReturn.UseVisualStyleBackColor = True
        '
        'BtnBackspace
        '
        Me.BtnBackspace.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnBackspace.Location = New System.Drawing.Point(225, 75)
        Me.BtnBackspace.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnBackspace.Name = "BtnBackspace"
        Me.BtnBackspace.Size = New System.Drawing.Size(55, 46)
        Me.BtnBackspace.TabIndex = 3
        Me.BtnBackspace.Text = "!"
        Me.BtnBackspace.UseVisualStyleBackColor = True
        '
        'BtnPageDown
        '
        Me.BtnPageDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPageDown.Location = New System.Drawing.Point(225, 183)
        Me.BtnPageDown.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnPageDown.Name = "BtnPageDown"
        Me.BtnPageDown.Size = New System.Drawing.Size(55, 46)
        Me.BtnPageDown.TabIndex = 11
        Me.BtnPageDown.Text = "Page Down"
        Me.BtnPageDown.UseVisualStyleBackColor = True
        '
        'BtnEnd
        '
        Me.BtnEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEnd.Location = New System.Drawing.Point(151, 183)
        Me.BtnEnd.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnEnd.Name = "BtnEnd"
        Me.BtnEnd.Size = New System.Drawing.Size(55, 46)
        Me.BtnEnd.TabIndex = 10
        Me.BtnEnd.Text = "End"
        Me.BtnEnd.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.Location = New System.Drawing.Point(83, 183)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(55, 46)
        Me.BtnDelete.TabIndex = 9
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnBacktab
        '
        Me.BtnBacktab.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnBacktab.Location = New System.Drawing.Point(15, 183)
        Me.BtnBacktab.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnBacktab.Name = "BtnBacktab"
        Me.BtnBacktab.Size = New System.Drawing.Size(55, 46)
        Me.BtnBacktab.TabIndex = 8
        Me.BtnBacktab.Text = ")"
        Me.BtnBacktab.UseVisualStyleBackColor = True
        '
        'BtnPageUp
        '
        Me.BtnPageUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPageUp.Location = New System.Drawing.Point(225, 129)
        Me.BtnPageUp.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnPageUp.Name = "BtnPageUp"
        Me.BtnPageUp.Size = New System.Drawing.Size(55, 46)
        Me.BtnPageUp.TabIndex = 7
        Me.BtnPageUp.Text = "Page Up"
        Me.BtnPageUp.UseVisualStyleBackColor = True
        '
        'BtnHome
        '
        Me.BtnHome.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHome.Location = New System.Drawing.Point(154, 129)
        Me.BtnHome.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnHome.Name = "BtnHome"
        Me.BtnHome.Size = New System.Drawing.Size(55, 46)
        Me.BtnHome.TabIndex = 6
        Me.BtnHome.Text = "Home"
        Me.BtnHome.UseVisualStyleBackColor = True
        '
        'BtnInsert
        '
        Me.BtnInsert.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInsert.Location = New System.Drawing.Point(83, 129)
        Me.BtnInsert.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnInsert.Name = "BtnInsert"
        Me.BtnInsert.Size = New System.Drawing.Size(55, 46)
        Me.BtnInsert.TabIndex = 5
        Me.BtnInsert.Text = "Insert"
        Me.BtnInsert.UseVisualStyleBackColor = True
        '
        'BtnTab
        '
        Me.BtnTab.Font = New System.Drawing.Font("Wingdings 3", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnTab.Location = New System.Drawing.Point(15, 129)
        Me.BtnTab.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnTab.Name = "BtnTab"
        Me.BtnTab.Size = New System.Drawing.Size(55, 46)
        Me.BtnTab.TabIndex = 4
        Me.BtnTab.Text = "*"
        Me.BtnTab.UseVisualStyleBackColor = True
        '
        'BtnCloseCurlyBracket
        '
        Me.BtnCloseCurlyBracket.Location = New System.Drawing.Point(154, 75)
        Me.BtnCloseCurlyBracket.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnCloseCurlyBracket.Name = "BtnCloseCurlyBracket"
        Me.BtnCloseCurlyBracket.Size = New System.Drawing.Size(55, 46)
        Me.BtnCloseCurlyBracket.TabIndex = 2
        Me.BtnCloseCurlyBracket.Text = "}"
        Me.BtnCloseCurlyBracket.UseVisualStyleBackColor = True
        '
        'BtnOpenCurlyBracket
        '
        Me.BtnOpenCurlyBracket.Location = New System.Drawing.Point(83, 75)
        Me.BtnOpenCurlyBracket.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnOpenCurlyBracket.Name = "BtnOpenCurlyBracket"
        Me.BtnOpenCurlyBracket.Size = New System.Drawing.Size(55, 46)
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
        Me.CbDbValue.Location = New System.Drawing.Point(83, 43)
        Me.CbDbValue.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.CbDbValue.Name = "CbDbValue"
        Me.CbDbValue.Size = New System.Drawing.Size(270, 24)
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
        Me.TxtPreview.Location = New System.Drawing.Point(14, 311)
        Me.TxtPreview.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.TxtPreview.Name = "TxtPreview"
        Me.TxtPreview.Size = New System.Drawing.Size(390, 136)
        Me.TxtPreview.TabIndex = 5
        Me.TxtPreview.Text = ""
        '
        'TxtValue
        '
        Me.TxtValue.ContextMenuStrip = Me.mnuEdit
        Me.TxtValue.Location = New System.Drawing.Point(14, 139)
        Me.TxtValue.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.TxtValue.Name = "TxtValue"
        Me.TxtValue.Size = New System.Drawing.Size(390, 136)
        Me.TxtValue.TabIndex = 4
        Me.TxtValue.Text = ""
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
        Me.BtnFont.Location = New System.Drawing.Point(310, 7)
        Me.BtnFont.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnFont.Name = "BtnFont"
        Me.BtnFont.Size = New System.Drawing.Size(323, 46)
        Me.BtnFont.TabIndex = 1
        Me.BtnFont.Text = "Caption Font"
        Me.BtnFont.UseVisualStyleBackColor = True
        '
        'TxtHint
        '
        Me.TxtHint.Location = New System.Drawing.Point(73, 71)
        Me.TxtHint.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.TxtHint.Name = "TxtHint"
        Me.TxtHint.Size = New System.Drawing.Size(391, 24)
        Me.TxtHint.TabIndex = 2
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(263, 500)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(141, 39)
        Me.BtnCancel.TabIndex = 7
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.BtnOK.Location = New System.Drawing.Point(14, 500)
        Me.BtnOK.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(141, 39)
        Me.BtnOK.TabIndex = 6
        Me.BtnOK.Text = "Update"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'LblBtnSeq
        '
        Me.LblBtnSeq.AutoSize = True
        Me.LblBtnSeq.Location = New System.Drawing.Point(792, 36)
        Me.LblBtnSeq.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblBtnSeq.Name = "LblBtnSeq"
        Me.LblBtnSeq.Size = New System.Drawing.Size(47, 17)
        Me.LblBtnSeq.TabIndex = 0
        Me.LblBtnSeq.Text = "Label2"
        '
        'LblBtnGrp
        '
        Me.LblBtnGrp.AutoSize = True
        Me.LblBtnGrp.Location = New System.Drawing.Point(792, 9)
        Me.LblBtnGrp.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblBtnGrp.Name = "LblBtnGrp"
        Me.LblBtnGrp.Size = New System.Drawing.Size(47, 17)
        Me.LblBtnGrp.TabIndex = 15
        Me.LblBtnGrp.Text = "Label2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(656, 9)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Button Group:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 290)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Preview"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 74)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Hint"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 22)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Caption"
        '
        'txtCaption
        '
        Me.txtCaption.Location = New System.Drawing.Point(73, 19)
        Me.txtCaption.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.Size = New System.Drawing.Size(209, 24)
        Me.txtCaption.TabIndex = 0
        '
        'SendersTableAdapter
        '
        Me.SendersTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 118)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Value"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(656, 36)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Button Sequence:"
        '
        'LblErrs
        '
        Me.LblErrs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblErrs.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblErrs.ForeColor = System.Drawing.Color.Crimson
        Me.LblErrs.Location = New System.Drawing.Point(17, 451)
        Me.LblErrs.Name = "LblErrs"
        Me.LblErrs.Size = New System.Drawing.Size(387, 32)
        Me.LblErrs.TabIndex = 17
        Me.LblErrs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmEditButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(880, 566)
        Me.Controls.Add(Me.LblErrs)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
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
        Me.Controls.Add(Me.TxtValue)
        Me.Controls.Add(Me.TxtPreview)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpOpts)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
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
    Friend WithEvents TxtValue As Windows.Forms.RichTextBox
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
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents LblErrs As Windows.Forms.Label
End Class
