<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class License
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
        Me.OKButton = New System.Windows.Forms.Button()
        Me.ProductNameLabel = New System.Windows.Forms.Label()
        Me.ProductVersionLabel = New System.Windows.Forms.Label()
        Me.BusinessNameLabel = New System.Windows.Forms.Label()
        Me.BusinessAddrLabel = New System.Windows.Forms.Label()
        Me.LiabilityNoticeLabel = New System.Windows.Forms.Label()
        Me.CopyrightLabel = New System.Windows.Forms.Label()
        Me.PermissionLabel = New System.Windows.Forms.Label()
        Me.LicenseTextLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(673, 758)
        Me.OKButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(120, 40)
        Me.OKButton.TabIndex = 1
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'ProductNameLabel
        '
        Me.ProductNameLabel.AutoSize = True
        Me.ProductNameLabel.Location = New System.Drawing.Point(42, 24)
        Me.ProductNameLabel.Name = "ProductNameLabel"
        Me.ProductNameLabel.Size = New System.Drawing.Size(110, 20)
        Me.ProductNameLabel.TabIndex = 2
        Me.ProductNameLabel.Text = "Product Name"
        '
        'ProductVersionLabel
        '
        Me.ProductVersionLabel.AutoSize = True
        Me.ProductVersionLabel.Location = New System.Drawing.Point(42, 64)
        Me.ProductVersionLabel.Name = "ProductVersionLabel"
        Me.ProductVersionLabel.Size = New System.Drawing.Size(122, 20)
        Me.ProductVersionLabel.TabIndex = 3
        Me.ProductVersionLabel.Text = "Product Version"
        '
        'BusinessNameLabel
        '
        Me.BusinessNameLabel.AutoSize = True
        Me.BusinessNameLabel.Location = New System.Drawing.Point(42, 106)
        Me.BusinessNameLabel.Name = "BusinessNameLabel"
        Me.BusinessNameLabel.Size = New System.Drawing.Size(120, 20)
        Me.BusinessNameLabel.TabIndex = 4
        Me.BusinessNameLabel.Text = "Business Name"
        '
        'BusinessAddrLabel
        '
        Me.BusinessAddrLabel.AutoSize = True
        Me.BusinessAddrLabel.Location = New System.Drawing.Point(42, 149)
        Me.BusinessAddrLabel.Name = "BusinessAddrLabel"
        Me.BusinessAddrLabel.Size = New System.Drawing.Size(137, 20)
        Me.BusinessAddrLabel.TabIndex = 5
        Me.BusinessAddrLabel.Text = "Business Address"
        '
        'LiabilityNoticeLabel
        '
        Me.LiabilityNoticeLabel.Location = New System.Drawing.Point(42, 192)
        Me.LiabilityNoticeLabel.Name = "LiabilityNoticeLabel"
        Me.LiabilityNoticeLabel.Size = New System.Drawing.Size(751, 73)
        Me.LiabilityNoticeLabel.TabIndex = 6
        Me.LiabilityNoticeLabel.Text = "Liability Notice"
        '
        'CopyrightLabel
        '
        Me.CopyrightLabel.AutoSize = True
        Me.CopyrightLabel.Location = New System.Drawing.Point(42, 276)
        Me.CopyrightLabel.Name = "CopyrightLabel"
        Me.CopyrightLabel.Size = New System.Drawing.Size(76, 20)
        Me.CopyrightLabel.TabIndex = 7
        Me.CopyrightLabel.Text = "Copyright"
        '
        'PermissionLabel
        '
        Me.PermissionLabel.Location = New System.Drawing.Point(42, 312)
        Me.PermissionLabel.Name = "PermissionLabel"
        Me.PermissionLabel.Size = New System.Drawing.Size(751, 76)
        Me.PermissionLabel.TabIndex = 8
        Me.PermissionLabel.Text = "Usage Notice"
        '
        'LicenseTextLabel
        '
        Me.LicenseTextLabel.Location = New System.Drawing.Point(42, 402)
        Me.LicenseTextLabel.Name = "LicenseTextLabel"
        Me.LicenseTextLabel.Size = New System.Drawing.Size(747, 331)
        Me.LicenseTextLabel.TabIndex = 9
        Me.LicenseTextLabel.Text = "License Text"
        '
        'License
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 812)
        Me.Controls.Add(Me.LicenseTextLabel)
        Me.Controls.Add(Me.PermissionLabel)
        Me.Controls.Add(Me.CopyrightLabel)
        Me.Controls.Add(Me.LiabilityNoticeLabel)
        Me.Controls.Add(Me.BusinessAddrLabel)
        Me.Controls.Add(Me.BusinessNameLabel)
        Me.Controls.Add(Me.ProductVersionLabel)
        Me.Controls.Add(Me.ProductNameLabel)
        Me.Controls.Add(Me.OKButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "License"
        Me.Text = "License CTA-2045 Simulator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents ProductNameLabel As Label
    Friend WithEvents ProductVersionLabel As Label
    Friend WithEvents BusinessNameLabel As Label
    Friend WithEvents BusinessAddrLabel As Label
    Friend WithEvents LiabilityNoticeLabel As Label
    Friend WithEvents CopyrightLabel As Label
    Friend WithEvents PermissionLabel As Label
    Friend WithEvents LicenseTextLabel As Label
End Class
