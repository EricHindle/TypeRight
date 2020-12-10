<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGroupMaint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGroupMaint))
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.cmbGroups = New System.Windows.Forms.ComboBox()
        Me.ButtongroupsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TypeRightDataSet = New TypeRight.TypeRightDataSet()
        Me.LblNewGroup = New System.Windows.Forms.Label()
        Me.TxtNewGroup = New System.Windows.Forms.TextBox()
        Me.LblTrans = New System.Windows.Forms.Label()
        Me.LblThisBtn = New System.Windows.Forms.Label()
        Me.TxtGrpName = New System.Windows.Forms.TextBox()
        Me.TxtGrpNumber = New System.Windows.Forms.TextBox()
        Me.ButtongroupsTableAdapter = New TypeRight.TypeRightDataSetTableAdapters.buttongroupsTableAdapter()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Nbutton1 = New NbuttonControlLibrary.Nbutton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.ButtongroupsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeRightDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(532, 156)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(85, 37)
        Me.BtnCancel.TabIndex = 0
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(532, 111)
        Me.BtnUpdate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(85, 37)
        Me.BtnUpdate.TabIndex = 1
        Me.BtnUpdate.Text = "Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'cmbGroups
        '
        Me.cmbGroups.DataSource = Me.ButtongroupsBindingSource
        Me.cmbGroups.DisplayMember = "groupname"
        Me.cmbGroups.FormattingEnabled = True
        Me.cmbGroups.Location = New System.Drawing.Point(180, 165)
        Me.cmbGroups.Name = "cmbGroups"
        Me.cmbGroups.Size = New System.Drawing.Size(301, 24)
        Me.cmbGroups.TabIndex = 2
        Me.cmbGroups.ValueMember = "buttongroupid"
        '
        'ButtongroupsBindingSource
        '
        Me.ButtongroupsBindingSource.DataMember = "buttongroups"
        Me.ButtongroupsBindingSource.DataSource = Me.TypeRightDataSet
        '
        'TypeRightDataSet
        '
        Me.TypeRightDataSet.DataSetName = "TypeRightDataSet"
        Me.TypeRightDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LblNewGroup
        '
        Me.LblNewGroup.AutoSize = True
        Me.LblNewGroup.Location = New System.Drawing.Point(24, 168)
        Me.LblNewGroup.Name = "LblNewGroup"
        Me.LblNewGroup.Size = New System.Drawing.Size(115, 17)
        Me.LblNewGroup.TabIndex = 3
        Me.LblNewGroup.Text = "New Group Name"
        '
        'TxtNewGroup
        '
        Me.TxtNewGroup.Location = New System.Drawing.Point(180, 165)
        Me.TxtNewGroup.Name = "TxtNewGroup"
        Me.TxtNewGroup.Size = New System.Drawing.Size(313, 24)
        Me.TxtNewGroup.TabIndex = 4
        Me.TxtNewGroup.Visible = False
        '
        'LblTrans
        '
        Me.LblTrans.AutoSize = True
        Me.LblTrans.Location = New System.Drawing.Point(24, 168)
        Me.LblTrans.Name = "LblTrans"
        Me.LblTrans.Size = New System.Drawing.Size(145, 17)
        Me.LblTrans.TabIndex = 5
        Me.LblTrans.Text = "Move button to group"
        Me.LblTrans.Visible = False
        '
        'LblThisBtn
        '
        Me.LblThisBtn.AutoSize = True
        Me.LblThisBtn.Location = New System.Drawing.Point(286, 30)
        Me.LblThisBtn.Name = "LblThisBtn"
        Me.LblThisBtn.Size = New System.Drawing.Size(161, 17)
        Me.LblThisBtn.TabIndex = 7
        Me.LblThisBtn.Text = "Transferring this Button :"
        '
        'TxtGrpName
        '
        Me.TxtGrpName.Location = New System.Drawing.Point(180, 96)
        Me.TxtGrpName.Name = "TxtGrpName"
        Me.TxtGrpName.Size = New System.Drawing.Size(313, 24)
        Me.TxtGrpName.TabIndex = 9
        '
        'TxtGrpNumber
        '
        Me.TxtGrpNumber.Location = New System.Drawing.Point(180, 24)
        Me.TxtGrpNumber.Name = "TxtGrpNumber"
        Me.TxtGrpNumber.Size = New System.Drawing.Size(61, 24)
        Me.TxtGrpNumber.TabIndex = 10
        '
        'ButtongroupsTableAdapter
        '
        Me.ButtongroupsTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Group Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Group name"
        '
        'Nbutton1
        '
        Me.Nbutton1.Caption = Nothing
        Me.Nbutton1.DataType = NbuttonControlLibrary.Nbutton.DataSource.Undefined
        Me.Nbutton1.Encrypt = False
        Me.Nbutton1.FontBold = False
        Me.Nbutton1.FontItalic = False
        Me.Nbutton1.FontName = "Tahoma"
        Me.Nbutton1.FontSize = 10.0!
        Me.Nbutton1.Group = 1
        Me.Nbutton1.Hint = ""
        Me.Nbutton1.Id = -1
        Me.Nbutton1.Location = New System.Drawing.Point(467, 24)
        Me.Nbutton1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nbutton1.Name = "Nbutton1"
        Me.Nbutton1.Sequence = 999
        Me.Nbutton1.Size = New System.Drawing.Size(118, 52)
        Me.Nbutton1.TabIndex = 14
        Me.Nbutton1.Value = "?"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.TypeRight.My.Resources.Resources.statusstrip
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 225)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(629, 22)
        Me.StatusStrip1.TabIndex = 15
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
        'FrmGroupMaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 247)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Nbutton1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtGrpNumber)
        Me.Controls.Add(Me.TxtGrpName)
        Me.Controls.Add(Me.LblThisBtn)
        Me.Controls.Add(Me.LblTrans)
        Me.Controls.Add(Me.TxtNewGroup)
        Me.Controls.Add(Me.LblNewGroup)
        Me.Controls.Add(Me.cmbGroups)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.BtnCancel)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmGroupMaint"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Group Maintenance"
        CType(Me.ButtongroupsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeRightDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnCancel As Windows.Forms.Button
    Friend WithEvents BtnUpdate As Windows.Forms.Button
    Friend WithEvents cmbGroups As Windows.Forms.ComboBox
    Friend WithEvents LblNewGroup As Windows.Forms.Label
    Friend WithEvents TxtNewGroup As Windows.Forms.TextBox
    Friend WithEvents LblTrans As Windows.Forms.Label
    Friend WithEvents LblThisBtn As Windows.Forms.Label
    Friend WithEvents TxtGrpName As Windows.Forms.TextBox
    Friend WithEvents TxtGrpNumber As Windows.Forms.TextBox
    Friend WithEvents TypeRightDataSet As TypeRightDataSet
    Friend WithEvents ButtongroupsBindingSource As Windows.Forms.BindingSource
    Friend WithEvents ButtongroupsTableAdapter As TypeRightDataSetTableAdapters.buttongroupsTableAdapter
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Nbutton1 As NbuttonControlLibrary.Nbutton
    Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
    Friend WithEvents LblStatus As Windows.Forms.ToolStripStatusLabel
End Class
