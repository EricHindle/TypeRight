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
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.cmbGroups = New System.Windows.Forms.ComboBox()
        Me.LblNewGroup = New System.Windows.Forms.Label()
        Me.TxtNewGroup = New System.Windows.Forms.TextBox()
        Me.LblTrans = New System.Windows.Forms.Label()
        Me.LblConfirm = New System.Windows.Forms.Label()
        Me.LblThisBtn = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(723, 486)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(87, 28)
        Me.BtnCancel.TabIndex = 0
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(552, 486)
        Me.BtnUpdate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(87, 28)
        Me.BtnUpdate.TabIndex = 1
        Me.BtnUpdate.Text = "Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'cmbGroups
        '
        Me.cmbGroups.FormattingEnabled = True
        Me.cmbGroups.Location = New System.Drawing.Point(46, 35)
        Me.cmbGroups.Name = "cmbGroups"
        Me.cmbGroups.Size = New System.Drawing.Size(121, 24)
        Me.cmbGroups.TabIndex = 2
        '
        'LblNewGroup
        '
        Me.LblNewGroup.AutoSize = True
        Me.LblNewGroup.Location = New System.Drawing.Point(44, 93)
        Me.LblNewGroup.Name = "LblNewGroup"
        Me.LblNewGroup.Size = New System.Drawing.Size(76, 17)
        Me.LblNewGroup.TabIndex = 3
        Me.LblNewGroup.Text = "New Group"
        '
        'TxtNewGroup
        '
        Me.TxtNewGroup.Location = New System.Drawing.Point(158, 90)
        Me.TxtNewGroup.Name = "TxtNewGroup"
        Me.TxtNewGroup.Size = New System.Drawing.Size(100, 24)
        Me.TxtNewGroup.TabIndex = 4
        '
        'LblTrans
        '
        Me.LblTrans.AutoSize = True
        Me.LblTrans.Location = New System.Drawing.Point(59, 154)
        Me.LblTrans.Name = "LblTrans"
        Me.LblTrans.Size = New System.Drawing.Size(42, 17)
        Me.LblTrans.TabIndex = 5
        Me.LblTrans.Text = "Trans"
        '
        'LblConfirm
        '
        Me.LblConfirm.AutoSize = True
        Me.LblConfirm.Location = New System.Drawing.Point(63, 216)
        Me.LblConfirm.Name = "LblConfirm"
        Me.LblConfirm.Size = New System.Drawing.Size(56, 17)
        Me.LblConfirm.TabIndex = 6
        Me.LblConfirm.Text = "Confirm"
        '
        'LblThisBtn
        '
        Me.LblThisBtn.AutoSize = True
        Me.LblThisBtn.Location = New System.Drawing.Point(63, 288)
        Me.LblThisBtn.Name = "LblThisBtn"
        Me.LblThisBtn.Size = New System.Drawing.Size(78, 17)
        Me.LblThisBtn.TabIndex = 7
        Me.LblThisBtn.Text = "This Button"
        '
        'FrmGroupMaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 554)
        Me.Controls.Add(Me.LblThisBtn)
        Me.Controls.Add(Me.LblConfirm)
        Me.Controls.Add(Me.LblTrans)
        Me.Controls.Add(Me.TxtNewGroup)
        Me.Controls.Add(Me.LblNewGroup)
        Me.Controls.Add(Me.cmbGroups)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.BtnCancel)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmGroupMaint"
        Me.Text = "FrmGroupMaint"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnCancel As Windows.Forms.Button
    Friend WithEvents BtnUpdate As Windows.Forms.Button
    Friend WithEvents cmbGroups As Windows.Forms.ComboBox
    Friend WithEvents LblNewGroup As Windows.Forms.Label
    Friend WithEvents TxtNewGroup As Windows.Forms.TextBox
    Friend WithEvents LblTrans As Windows.Forms.Label
    Friend WithEvents LblConfirm As Windows.Forms.Label
    Friend WithEvents LblThisBtn As Windows.Forms.Label
End Class
