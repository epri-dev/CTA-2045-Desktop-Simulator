<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestHeader
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
        Me.PrevHeaderTB = New System.Windows.Forms.TextBox()
        Me.PrevHeaderGrpBox = New System.Windows.Forms.GroupBox()
        Me.DoneSavebtn = New System.Windows.Forms.Button()
        Me.BrowsePrevBtn = New System.Windows.Forms.Button()
        Me.NewHeaderTB = New System.Windows.Forms.TextBox()
        Me.NewHeaderGrpBox = New System.Windows.Forms.GroupBox()
        Me.CreateHeaderBtn = New System.Windows.Forms.Button()
        Me.BrowseNewBtn = New System.Windows.Forms.Button()
        Me.PrevHeaderCB = New System.Windows.Forms.CheckBox()
        Me.NewHeaderCB = New System.Windows.Forms.CheckBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PrevHeaderGrpBox.SuspendLayout()
        Me.NewHeaderGrpBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrevHeaderTB
        '
        Me.PrevHeaderTB.Location = New System.Drawing.Point(9, 29)
        Me.PrevHeaderTB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PrevHeaderTB.Name = "PrevHeaderTB"
        Me.PrevHeaderTB.Size = New System.Drawing.Size(480, 26)
        Me.PrevHeaderTB.TabIndex = 0
        '
        'PrevHeaderGrpBox
        '
        Me.PrevHeaderGrpBox.Controls.Add(Me.DoneSavebtn)
        Me.PrevHeaderGrpBox.Controls.Add(Me.BrowsePrevBtn)
        Me.PrevHeaderGrpBox.Controls.Add(Me.PrevHeaderTB)
        Me.PrevHeaderGrpBox.Enabled = False
        Me.PrevHeaderGrpBox.Location = New System.Drawing.Point(27, 63)
        Me.PrevHeaderGrpBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PrevHeaderGrpBox.Name = "PrevHeaderGrpBox"
        Me.PrevHeaderGrpBox.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PrevHeaderGrpBox.Size = New System.Drawing.Size(500, 138)
        Me.PrevHeaderGrpBox.TabIndex = 2
        Me.PrevHeaderGrpBox.TabStop = False
        Me.PrevHeaderGrpBox.Text = "Previous Header File"
        '
        'DoneSavebtn
        '
        Me.DoneSavebtn.Location = New System.Drawing.Point(378, 83)
        Me.DoneSavebtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DoneSavebtn.Name = "DoneSavebtn"
        Me.DoneSavebtn.Size = New System.Drawing.Size(112, 35)
        Me.DoneSavebtn.TabIndex = 3
        Me.DoneSavebtn.Text = "Done"
        Me.DoneSavebtn.UseVisualStyleBackColor = True
        '
        'BrowsePrevBtn
        '
        Me.BrowsePrevBtn.Location = New System.Drawing.Point(9, 83)
        Me.BrowsePrevBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BrowsePrevBtn.Name = "BrowsePrevBtn"
        Me.BrowsePrevBtn.Size = New System.Drawing.Size(112, 35)
        Me.BrowsePrevBtn.TabIndex = 4
        Me.BrowsePrevBtn.Text = "Browse"
        Me.BrowsePrevBtn.UseVisualStyleBackColor = True
        '
        'NewHeaderTB
        '
        Me.NewHeaderTB.Location = New System.Drawing.Point(9, 29)
        Me.NewHeaderTB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NewHeaderTB.Name = "NewHeaderTB"
        Me.NewHeaderTB.Size = New System.Drawing.Size(480, 26)
        Me.NewHeaderTB.TabIndex = 0
        '
        'NewHeaderGrpBox
        '
        Me.NewHeaderGrpBox.Controls.Add(Me.CreateHeaderBtn)
        Me.NewHeaderGrpBox.Controls.Add(Me.BrowseNewBtn)
        Me.NewHeaderGrpBox.Controls.Add(Me.NewHeaderTB)
        Me.NewHeaderGrpBox.Enabled = False
        Me.NewHeaderGrpBox.Location = New System.Drawing.Point(27, 275)
        Me.NewHeaderGrpBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NewHeaderGrpBox.Name = "NewHeaderGrpBox"
        Me.NewHeaderGrpBox.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NewHeaderGrpBox.Size = New System.Drawing.Size(500, 138)
        Me.NewHeaderGrpBox.TabIndex = 3
        Me.NewHeaderGrpBox.TabStop = False
        Me.NewHeaderGrpBox.Text = "New Header File"
        '
        'CreateHeaderBtn
        '
        Me.CreateHeaderBtn.Location = New System.Drawing.Point(378, 83)
        Me.CreateHeaderBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CreateHeaderBtn.Name = "CreateHeaderBtn"
        Me.CreateHeaderBtn.Size = New System.Drawing.Size(112, 35)
        Me.CreateHeaderBtn.TabIndex = 3
        Me.CreateHeaderBtn.Text = "Create"
        Me.CreateHeaderBtn.UseVisualStyleBackColor = True
        '
        'BrowseNewBtn
        '
        Me.BrowseNewBtn.Location = New System.Drawing.Point(9, 83)
        Me.BrowseNewBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BrowseNewBtn.Name = "BrowseNewBtn"
        Me.BrowseNewBtn.Size = New System.Drawing.Size(112, 35)
        Me.BrowseNewBtn.TabIndex = 4
        Me.BrowseNewBtn.Text = "Browse"
        Me.BrowseNewBtn.UseVisualStyleBackColor = True
        '
        'PrevHeaderCB
        '
        Me.PrevHeaderCB.AutoSize = True
        Me.PrevHeaderCB.Location = New System.Drawing.Point(36, 28)
        Me.PrevHeaderCB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PrevHeaderCB.Name = "PrevHeaderCB"
        Me.PrevHeaderCB.Size = New System.Drawing.Size(185, 24)
        Me.PrevHeaderCB.TabIndex = 4
        Me.PrevHeaderCB.Text = "Use Previous Header"
        Me.PrevHeaderCB.UseVisualStyleBackColor = True
        '
        'NewHeaderCB
        '
        Me.NewHeaderCB.AutoSize = True
        Me.NewHeaderCB.Location = New System.Drawing.Point(36, 240)
        Me.NewHeaderCB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NewHeaderCB.Name = "NewHeaderCB"
        Me.NewHeaderCB.Size = New System.Drawing.Size(175, 24)
        Me.NewHeaderCB.TabIndex = 5
        Me.NewHeaderCB.Text = "Create New Header"
        Me.NewHeaderCB.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TestHeader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 437)
        Me.Controls.Add(Me.NewHeaderCB)
        Me.Controls.Add(Me.PrevHeaderCB)
        Me.Controls.Add(Me.NewHeaderGrpBox)
        Me.Controls.Add(Me.PrevHeaderGrpBox)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "TestHeader"
        Me.Text = "Test Header"
        Me.PrevHeaderGrpBox.ResumeLayout(False)
        Me.PrevHeaderGrpBox.PerformLayout()
        Me.NewHeaderGrpBox.ResumeLayout(False)
        Me.NewHeaderGrpBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PrevHeaderTB As TextBox
    Friend WithEvents PrevHeaderGrpBox As GroupBox
    Friend WithEvents DoneSavebtn As Button
    Friend WithEvents BrowsePrevBtn As Button
    Friend WithEvents NewHeaderTB As TextBox
    Friend WithEvents NewHeaderGrpBox As GroupBox
    Friend WithEvents CreateHeaderBtn As Button
    Friend WithEvents BrowseNewBtn As Button
    Friend WithEvents PrevHeaderCB As CheckBox
    Friend WithEvents NewHeaderCB As CheckBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
