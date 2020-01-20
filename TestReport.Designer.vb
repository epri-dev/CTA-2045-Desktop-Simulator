<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestReport
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
        Me.TestProgressBar = New System.Windows.Forms.ProgressBar()
        Me.ResultsRTB = New System.Windows.Forms.RichTextBox()
        Me.ChooseFileBtn = New System.Windows.Forms.Button()
        Me.ResultFileTB = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SearchBox = New System.Windows.Forms.TextBox()
        Me.CancelSearchBtn = New System.Windows.Forms.Button()
        Me.RunSearchBtn = New System.Windows.Forms.Button()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.ResetBtn = New System.Windows.Forms.Button()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.SearchKeywordRB = New System.Windows.Forms.RadioButton()
        Me.SearchTestCaseRB = New System.Windows.Forms.RadioButton()
        Me.SaveReportBtn = New System.Windows.Forms.Button()
        Me.TestsGB = New System.Windows.Forms.GroupBox()
        Me.AllTestCB = New System.Windows.Forms.CheckBox()
        Me.EnergyTestCB = New System.Windows.Forms.CheckBox()
        Me.FunctionalTestCB = New System.Windows.Forms.CheckBox()
        Me.EventTestCB = New System.Windows.Forms.CheckBox()
        Me.CommandTestCB = New System.Windows.Forms.CheckBox()
        Me.SearchGB = New System.Windows.Forms.GroupBox()
        Me.DateRangeGB = New System.Windows.Forms.GroupBox()
        Me.TestCaseLbl = New System.Windows.Forms.Label()
        Me.TestCaseCBB = New System.Windows.Forms.ComboBox()
        Me.StartDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.EndDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.EndDateLbl = New System.Windows.Forms.Label()
        Me.StartDateLbl = New System.Windows.Forms.Label()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.ButtonsGB = New System.Windows.Forms.GroupBox()
        Me.TestsGB.SuspendLayout()
        Me.SearchGB.SuspendLayout()
        Me.DateRangeGB.SuspendLayout()
        Me.ButtonsGB.SuspendLayout()
        Me.SuspendLayout()
        '
        'TestProgressBar
        '
        Me.TestProgressBar.Location = New System.Drawing.Point(371, 15)
        Me.TestProgressBar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TestProgressBar.Name = "TestProgressBar"
        Me.TestProgressBar.Size = New System.Drawing.Size(972, 14)
        Me.TestProgressBar.TabIndex = 0
        '
        'ResultsRTB
        '
        Me.ResultsRTB.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ResultsRTB.Location = New System.Drawing.Point(371, 42)
        Me.ResultsRTB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ResultsRTB.Name = "ResultsRTB"
        Me.ResultsRTB.ReadOnly = True
        Me.ResultsRTB.Size = New System.Drawing.Size(971, 501)
        Me.ResultsRTB.TabIndex = 1
        Me.ResultsRTB.Text = ""
        Me.ResultsRTB.WordWrap = False
        '
        'ChooseFileBtn
        '
        Me.ChooseFileBtn.Location = New System.Drawing.Point(461, 561)
        Me.ChooseFileBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ChooseFileBtn.Name = "ChooseFileBtn"
        Me.ChooseFileBtn.Size = New System.Drawing.Size(109, 31)
        Me.ChooseFileBtn.TabIndex = 2
        Me.ChooseFileBtn.Text = "Choose..."
        Me.ChooseFileBtn.UseVisualStyleBackColor = True
        '
        'ResultFileTB
        '
        Me.ResultFileTB.BackColor = System.Drawing.SystemColors.Control
        Me.ResultFileTB.Location = New System.Drawing.Point(92, 565)
        Me.ResultFileTB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ResultFileTB.Name = "ResultFileTB"
        Me.ResultFileTB.ReadOnly = True
        Me.ResultFileTB.Size = New System.Drawing.Size(363, 22)
        Me.ResultFileTB.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 570)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Result File:"
        '
        'SearchBox
        '
        Me.SearchBox.Location = New System.Drawing.Point(17, 27)
        Me.SearchBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SearchBox.Name = "SearchBox"
        Me.SearchBox.Size = New System.Drawing.Size(324, 22)
        Me.SearchBox.TabIndex = 5
        Me.SearchBox.Text = "Enter Keyword here"
        '
        'CancelSearchBtn
        '
        Me.CancelSearchBtn.Location = New System.Drawing.Point(228, 15)
        Me.CancelSearchBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CancelSearchBtn.Name = "CancelSearchBtn"
        Me.CancelSearchBtn.Size = New System.Drawing.Size(119, 44)
        Me.CancelSearchBtn.TabIndex = 7
        Me.CancelSearchBtn.Text = "Reset Search"
        Me.CancelSearchBtn.UseVisualStyleBackColor = True
        '
        'RunSearchBtn
        '
        Me.RunSearchBtn.Location = New System.Drawing.Point(13, 17)
        Me.RunSearchBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RunSearchBtn.Name = "RunSearchBtn"
        Me.RunSearchBtn.Size = New System.Drawing.Size(112, 41)
        Me.RunSearchBtn.TabIndex = 8
        Me.RunSearchBtn.Text = "Run Search"
        Me.RunSearchBtn.UseVisualStyleBackColor = True
        '
        'CloseBtn
        '
        Me.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseBtn.Location = New System.Drawing.Point(1260, 560)
        Me.CloseBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(77, 32)
        Me.CloseBtn.TabIndex = 11
        Me.CloseBtn.Text = "Close"
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'ResetBtn
        '
        Me.ResetBtn.Location = New System.Drawing.Point(1155, 561)
        Me.ResetBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ResetBtn.Name = "ResetBtn"
        Me.ResetBtn.Size = New System.Drawing.Size(77, 31)
        Me.ResetBtn.TabIndex = 15
        Me.ResetBtn.Text = "Reset"
        Me.ResetBtn.UseVisualStyleBackColor = True
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(1044, 561)
        Me.SaveBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(79, 31)
        Me.SaveBtn.TabIndex = 16
        Me.SaveBtn.Text = "Save"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'SearchKeywordRB
        '
        Me.SearchKeywordRB.AutoSize = True
        Me.SearchKeywordRB.Checked = True
        Me.SearchKeywordRB.Location = New System.Drawing.Point(12, 15)
        Me.SearchKeywordRB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SearchKeywordRB.Name = "SearchKeywordRB"
        Me.SearchKeywordRB.Size = New System.Drawing.Size(152, 21)
        Me.SearchKeywordRB.TabIndex = 17
        Me.SearchKeywordRB.TabStop = True
        Me.SearchKeywordRB.Text = "Search By Keyword"
        Me.SearchKeywordRB.UseVisualStyleBackColor = True
        '
        'SearchTestCaseRB
        '
        Me.SearchTestCaseRB.AutoSize = True
        Me.SearchTestCaseRB.BackColor = System.Drawing.SystemColors.Control
        Me.SearchTestCaseRB.Location = New System.Drawing.Point(13, 118)
        Me.SearchTestCaseRB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SearchTestCaseRB.Name = "SearchTestCaseRB"
        Me.SearchTestCaseRB.Size = New System.Drawing.Size(155, 21)
        Me.SearchTestCaseRB.TabIndex = 18
        Me.SearchTestCaseRB.Text = "Search By Category"
        Me.SearchTestCaseRB.UseVisualStyleBackColor = False
        '
        'SaveReportBtn
        '
        Me.SaveReportBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SaveReportBtn.Location = New System.Drawing.Point(13, 69)
        Me.SaveReportBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SaveReportBtn.Name = "SaveReportBtn"
        Me.SaveReportBtn.Size = New System.Drawing.Size(333, 37)
        Me.SaveReportBtn.TabIndex = 19
        Me.SaveReportBtn.Text = "Export Results"
        Me.SaveReportBtn.UseVisualStyleBackColor = True
        '
        'TestsGB
        '
        Me.TestsGB.Controls.Add(Me.AllTestCB)
        Me.TestsGB.Controls.Add(Me.EnergyTestCB)
        Me.TestsGB.Controls.Add(Me.FunctionalTestCB)
        Me.TestsGB.Controls.Add(Me.EventTestCB)
        Me.TestsGB.Controls.Add(Me.CommandTestCB)
        Me.TestsGB.Location = New System.Drawing.Point(12, 140)
        Me.TestsGB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TestsGB.Name = "TestsGB"
        Me.TestsGB.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TestsGB.Size = New System.Drawing.Size(353, 156)
        Me.TestsGB.TabIndex = 20
        Me.TestsGB.TabStop = False
        '
        'AllTestCB
        '
        Me.AllTestCB.AutoSize = True
        Me.AllTestCB.Location = New System.Drawing.Point(29, 129)
        Me.AllTestCB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AllTestCB.Name = "AllTestCB"
        Me.AllTestCB.Size = New System.Drawing.Size(88, 21)
        Me.AllTestCB.TabIndex = 4
        Me.AllTestCB.Text = "Select All"
        Me.AllTestCB.UseVisualStyleBackColor = True
        '
        'EnergyTestCB
        '
        Me.EnergyTestCB.AutoSize = True
        Me.EnergyTestCB.Location = New System.Drawing.Point(29, 103)
        Me.EnergyTestCB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EnergyTestCB.Name = "EnergyTestCB"
        Me.EnergyTestCB.Size = New System.Drawing.Size(99, 21)
        Me.EnergyTestCB.TabIndex = 3
        Me.EnergyTestCB.Text = "Commodity"
        Me.EnergyTestCB.UseVisualStyleBackColor = True
        '
        'FunctionalTestCB
        '
        Me.FunctionalTestCB.AutoSize = True
        Me.FunctionalTestCB.Location = New System.Drawing.Point(29, 76)
        Me.FunctionalTestCB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.FunctionalTestCB.Name = "FunctionalTestCB"
        Me.FunctionalTestCB.Size = New System.Drawing.Size(127, 21)
        Me.FunctionalTestCB.TabIndex = 2
        Me.FunctionalTestCB.Text = "Functional Test"
        Me.FunctionalTestCB.UseVisualStyleBackColor = True
        '
        'EventTestCB
        '
        Me.EventTestCB.AutoSize = True
        Me.EventTestCB.Location = New System.Drawing.Point(29, 49)
        Me.EventTestCB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EventTestCB.Name = "EventTestCB"
        Me.EventTestCB.Size = New System.Drawing.Size(97, 21)
        Me.EventTestCB.TabIndex = 1
        Me.EventTestCB.Text = "DR Events"
        Me.EventTestCB.UseVisualStyleBackColor = True
        '
        'CommandTestCB
        '
        Me.CommandTestCB.AutoSize = True
        Me.CommandTestCB.Location = New System.Drawing.Point(28, 22)
        Me.CommandTestCB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CommandTestCB.Name = "CommandTestCB"
        Me.CommandTestCB.Size = New System.Drawing.Size(100, 21)
        Me.CommandTestCB.TabIndex = 0
        Me.CommandTestCB.Text = "Commands"
        Me.CommandTestCB.UseVisualStyleBackColor = True
        '
        'SearchGB
        '
        Me.SearchGB.Controls.Add(Me.SearchBox)
        Me.SearchGB.Location = New System.Drawing.Point(12, 37)
        Me.SearchGB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SearchGB.Name = "SearchGB"
        Me.SearchGB.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SearchGB.Size = New System.Drawing.Size(353, 69)
        Me.SearchGB.TabIndex = 21
        Me.SearchGB.TabStop = False
        '
        'DateRangeGB
        '
        Me.DateRangeGB.Controls.Add(Me.TestCaseLbl)
        Me.DateRangeGB.Controls.Add(Me.TestCaseCBB)
        Me.DateRangeGB.Controls.Add(Me.StartDateTimePicker)
        Me.DateRangeGB.Controls.Add(Me.EndDateTimePicker)
        Me.DateRangeGB.Controls.Add(Me.EndDateLbl)
        Me.DateRangeGB.Controls.Add(Me.StartDateLbl)
        Me.DateRangeGB.Location = New System.Drawing.Point(13, 299)
        Me.DateRangeGB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateRangeGB.Name = "DateRangeGB"
        Me.DateRangeGB.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateRangeGB.Size = New System.Drawing.Size(352, 124)
        Me.DateRangeGB.TabIndex = 22
        Me.DateRangeGB.TabStop = False
        '
        'TestCaseLbl
        '
        Me.TestCaseLbl.AutoSize = True
        Me.TestCaseLbl.Location = New System.Drawing.Point(12, 25)
        Me.TestCaseLbl.Name = "TestCaseLbl"
        Me.TestCaseLbl.Size = New System.Drawing.Size(69, 17)
        Me.TestCaseLbl.TabIndex = 16
        Me.TestCaseLbl.Text = "Category:"
        '
        'TestCaseCBB
        '
        Me.TestCaseCBB.FormattingEnabled = True
        Me.TestCaseCBB.Location = New System.Drawing.Point(92, 22)
        Me.TestCaseCBB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TestCaseCBB.Name = "TestCaseCBB"
        Me.TestCaseCBB.Size = New System.Drawing.Size(244, 24)
        Me.TestCaseCBB.TabIndex = 15
        '
        'StartDateTimePicker
        '
        Me.StartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.StartDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss"
        Me.StartDateTimePicker.Location = New System.Drawing.Point(93, 58)
        Me.StartDateTimePicker.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.StartDateTimePicker.Name = "StartDateTimePicker"
        Me.StartDateTimePicker.Size = New System.Drawing.Size(244, 22)
        Me.StartDateTimePicker.TabIndex = 9
        Me.StartDateTimePicker.Value = Today
        '
        'EndDateTimePicker
        '
        Me.EndDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.EndDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss"
        Me.EndDateTimePicker.Location = New System.Drawing.Point(93, 92)
        Me.EndDateTimePicker.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EndDateTimePicker.Name = "EndDateTimePicker"
        Me.EndDateTimePicker.Size = New System.Drawing.Size(244, 22)
        Me.EndDateTimePicker.TabIndex = 12
        Me.EndDateTimePicker.Value = Today.Add(New TimeSpan(23, 59, 59))
        '
        'EndDateLbl
        '
        Me.EndDateLbl.AutoSize = True
        Me.EndDateLbl.Location = New System.Drawing.Point(11, 92)
        Me.EndDateLbl.Name = "EndDateLbl"
        Me.EndDateLbl.Size = New System.Drawing.Size(75, 17)
        Me.EndDateLbl.TabIndex = 14
        Me.EndDateLbl.Text = "End Date :"
        '
        'StartDateLbl
        '
        Me.StartDateLbl.AutoSize = True
        Me.StartDateLbl.Location = New System.Drawing.Point(11, 63)
        Me.StartDateLbl.Name = "StartDateLbl"
        Me.StartDateLbl.Size = New System.Drawing.Size(84, 17)
        Me.StartDateLbl.TabIndex = 13
        Me.StartDateLbl.Text = "Start Date : "
        '
        'ButtonsGB
        '
        Me.ButtonsGB.Controls.Add(Me.SaveReportBtn)
        Me.ButtonsGB.Controls.Add(Me.RunSearchBtn)
        Me.ButtonsGB.Controls.Add(Me.CancelSearchBtn)
        Me.ButtonsGB.Location = New System.Drawing.Point(12, 427)
        Me.ButtonsGB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonsGB.Name = "ButtonsGB"
        Me.ButtonsGB.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonsGB.Size = New System.Drawing.Size(353, 116)
        Me.ButtonsGB.TabIndex = 23
        Me.ButtonsGB.TabStop = False
        '
        'TestReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.CloseBtn
        Me.ClientSize = New System.Drawing.Size(1357, 604)
        Me.Controls.Add(Me.ButtonsGB)
        Me.Controls.Add(Me.DateRangeGB)
        Me.Controls.Add(Me.SearchGB)
        Me.Controls.Add(Me.TestsGB)
        Me.Controls.Add(Me.SearchTestCaseRB)
        Me.Controls.Add(Me.SearchKeywordRB)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.ResetBtn)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ResultFileTB)
        Me.Controls.Add(Me.ChooseFileBtn)
        Me.Controls.Add(Me.ResultsRTB)
        Me.Controls.Add(Me.TestProgressBar)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "TestReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CTA-2045 Log File Explorer"
        Me.TestsGB.ResumeLayout(False)
        Me.TestsGB.PerformLayout()
        Me.SearchGB.ResumeLayout(False)
        Me.SearchGB.PerformLayout()
        Me.DateRangeGB.ResumeLayout(False)
        Me.DateRangeGB.PerformLayout()
        Me.ButtonsGB.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TestProgressBar As ProgressBar
    Friend WithEvents ResultsRTB As RichTextBox
    Friend WithEvents ChooseFileBtn As Button
    Friend WithEvents ResultFileTB As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SearchBox As TextBox
    Friend WithEvents CancelSearchBtn As Button
    Friend WithEvents RunSearchBtn As Button
    Friend WithEvents CloseBtn As Button
    Friend WithEvents ResetBtn As Button
    Friend WithEvents SaveBtn As Button
    Friend WithEvents SearchKeywordRB As RadioButton
    Friend WithEvents SearchTestCaseRB As RadioButton
    Friend WithEvents SaveReportBtn As Button
    Friend WithEvents TestsGB As GroupBox
    Friend WithEvents AllTestCB As CheckBox
    Friend WithEvents EnergyTestCB As CheckBox
    Friend WithEvents FunctionalTestCB As CheckBox
    Friend WithEvents EventTestCB As CheckBox
    Friend WithEvents CommandTestCB As CheckBox
    Friend WithEvents SearchGB As GroupBox
    Friend WithEvents DateRangeGB As GroupBox
    Friend WithEvents StartDateTimePicker As DateTimePicker
    Friend WithEvents EndDateTimePicker As DateTimePicker
    Friend WithEvents EndDateLbl As Label
    Friend WithEvents ButtonsGB As GroupBox
    Friend WithEvents StartDateLbl As Label
    Friend WithEvents TestCaseLbl As Label
    Friend WithEvents TestCaseCBB As ComboBox
    Friend WithEvents OpenFile As OpenFileDialog
End Class
