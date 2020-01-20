<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommodityChart
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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series17 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series18 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series19 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series20 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series21 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series22 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series23 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series24 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title3 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series25 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series26 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series27 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series28 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series29 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series30 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series31 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series32 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title4 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.InstAmChrt = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ChrtChk1 = New System.Windows.Forms.CheckBox()
        Me.ChrtChk2 = New System.Windows.Forms.CheckBox()
        Me.ChrtChk3 = New System.Windows.Forms.CheckBox()
        Me.ChrtChk4 = New System.Windows.Forms.CheckBox()
        Me.ChrtChk5 = New System.Windows.Forms.CheckBox()
        Me.ChrtChk6 = New System.Windows.Forms.CheckBox()
        Me.ChrtChk7 = New System.Windows.Forms.CheckBox()
        Me.ChrtChk0 = New System.Windows.Forms.CheckBox()
        Me.PauseCommodityGrphBTN = New System.Windows.Forms.Button()
        Me.GraphAll = New System.Windows.Forms.Button()
        Me.CumAmChrt = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SaveCommDatabtn = New System.Windows.Forms.Button()
        Me.EnableCodeGPBX = New System.Windows.Forms.GroupBox()
        Me.GraphCtrlGPBX = New System.Windows.Forms.GroupBox()
        Me.SaveCommGraphbtn = New System.Windows.Forms.Button()
        Me.ResetBTN = New System.Windows.Forms.Button()
        CType(Me.InstAmChrt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CumAmChrt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EnableCodeGPBX.SuspendLayout()
        Me.GraphCtrlGPBX.SuspendLayout()
        Me.SuspendLayout()
        '
        'InstAmChrt
        '
        Me.InstAmChrt.BorderlineColor = System.Drawing.Color.WhiteSmoke
        Me.InstAmChrt.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        Me.InstAmChrt.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea3.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot
        ChartArea3.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea3.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot
        ChartArea3.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea3.Name = "ChartArea1"
        Me.InstAmChrt.ChartAreas.Add(ChartArea3)
        Me.InstAmChrt.Cursor = System.Windows.Forms.Cursors.Cross
        Legend3.Name = "Legend1"
        Me.InstAmChrt.Legends.Add(Legend3)
        Me.InstAmChrt.Location = New System.Drawing.Point(193, 8)
        Me.InstAmChrt.Name = "InstAmChrt"
        Series17.ChartArea = "ChartArea1"
        Series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series17.Legend = "Legend1"
        Series17.Name = "Electricity Consumed (W)"
        Series17.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series18.ChartArea = "ChartArea1"
        Series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series18.Legend = "Legend1"
        Series18.Name = "Electricity Produced (W)"
        Series18.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series19.ChartArea = "ChartArea1"
        Series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series19.Legend = "Legend1"
        Series19.Name = "Natural Gas (cubic ft/hr)"
        Series19.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series20.ChartArea = "ChartArea1"
        Series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series20.Legend = "Legend1"
        Series20.Name = "Water (gal/hr)"
        Series20.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series21.ChartArea = "ChartArea1"
        Series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series21.Legend = "Legend1"
        Series21.Name = "Natural Gas (cubic meters/hr)"
        Series21.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series22.ChartArea = "ChartArea1"
        Series22.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series22.Legend = "Legend1"
        Series22.Name = "Water (liters/hr)"
        Series22.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series23.ChartArea = "ChartArea1"
        Series23.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series23.Legend = "Legend1"
        Series23.Name = "TES (no instant rate)"
        Series23.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series24.ChartArea = "ChartArea1"
        Series24.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series24.Legend = "Legend1"
        Series24.Name = "PES (no instant rate)"
        Series24.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Me.InstAmChrt.Series.Add(Series17)
        Me.InstAmChrt.Series.Add(Series18)
        Me.InstAmChrt.Series.Add(Series19)
        Me.InstAmChrt.Series.Add(Series20)
        Me.InstAmChrt.Series.Add(Series21)
        Me.InstAmChrt.Series.Add(Series22)
        Me.InstAmChrt.Series.Add(Series23)
        Me.InstAmChrt.Series.Add(Series24)
        Me.InstAmChrt.Size = New System.Drawing.Size(970, 285)
        Me.InstAmChrt.TabIndex = 0
        Title3.BorderColor = System.Drawing.Color.Transparent
        Title3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title3.Name = "Instantaneous Rate"
        Title3.Text = "Instantaneous Rate"
        Me.InstAmChrt.Titles.Add(Title3)
        '
        'ChrtChk1
        '
        Me.ChrtChk1.Location = New System.Drawing.Point(17, 53)
        Me.ChrtChk1.Name = "ChrtChk1"
        Me.ChrtChk1.Size = New System.Drawing.Size(138, 17)
        Me.ChrtChk1.TabIndex = 50
        Me.ChrtChk1.UseVisualStyleBackColor = True
        '
        'ChrtChk2
        '
        Me.ChrtChk2.Location = New System.Drawing.Point(17, 77)
        Me.ChrtChk2.Name = "ChrtChk2"
        Me.ChrtChk2.Size = New System.Drawing.Size(138, 17)
        Me.ChrtChk2.TabIndex = 49
        Me.ChrtChk2.UseVisualStyleBackColor = True
        '
        'ChrtChk3
        '
        Me.ChrtChk3.Location = New System.Drawing.Point(17, 99)
        Me.ChrtChk3.Name = "ChrtChk3"
        Me.ChrtChk3.Size = New System.Drawing.Size(138, 17)
        Me.ChrtChk3.TabIndex = 48
        Me.ChrtChk3.UseVisualStyleBackColor = True
        '
        'ChrtChk4
        '
        Me.ChrtChk4.Location = New System.Drawing.Point(17, 122)
        Me.ChrtChk4.Name = "ChrtChk4"
        Me.ChrtChk4.Size = New System.Drawing.Size(138, 17)
        Me.ChrtChk4.TabIndex = 47
        Me.ChrtChk4.UseVisualStyleBackColor = True
        '
        'ChrtChk5
        '
        Me.ChrtChk5.Location = New System.Drawing.Point(17, 146)
        Me.ChrtChk5.Name = "ChrtChk5"
        Me.ChrtChk5.Size = New System.Drawing.Size(138, 17)
        Me.ChrtChk5.TabIndex = 46
        Me.ChrtChk5.UseVisualStyleBackColor = True
        '
        'ChrtChk6
        '
        Me.ChrtChk6.Location = New System.Drawing.Point(17, 168)
        Me.ChrtChk6.Name = "ChrtChk6"
        Me.ChrtChk6.Size = New System.Drawing.Size(138, 17)
        Me.ChrtChk6.TabIndex = 45
        Me.ChrtChk6.UseVisualStyleBackColor = True
        '
        'ChrtChk7
        '
        Me.ChrtChk7.Location = New System.Drawing.Point(17, 191)
        Me.ChrtChk7.Name = "ChrtChk7"
        Me.ChrtChk7.Size = New System.Drawing.Size(138, 17)
        Me.ChrtChk7.TabIndex = 44
        Me.ChrtChk7.UseVisualStyleBackColor = True
        '
        'ChrtChk0
        '
        Me.ChrtChk0.Location = New System.Drawing.Point(17, 30)
        Me.ChrtChk0.Name = "ChrtChk0"
        Me.ChrtChk0.Size = New System.Drawing.Size(138, 17)
        Me.ChrtChk0.TabIndex = 43
        Me.ChrtChk0.UseVisualStyleBackColor = True
        '
        'PauseCommodityGrphBTN
        '
        Me.PauseCommodityGrphBTN.AutoSize = True
        Me.PauseCommodityGrphBTN.Location = New System.Drawing.Point(7, 51)
        Me.PauseCommodityGrphBTN.Name = "PauseCommodityGrphBTN"
        Me.PauseCommodityGrphBTN.Size = New System.Drawing.Size(152, 28)
        Me.PauseCommodityGrphBTN.TabIndex = 42
        Me.PauseCommodityGrphBTN.Text = "Pause"
        Me.PauseCommodityGrphBTN.UseVisualStyleBackColor = True
        '
        'GraphAll
        '
        Me.GraphAll.Location = New System.Drawing.Point(7, 18)
        Me.GraphAll.Name = "GraphAll"
        Me.GraphAll.Size = New System.Drawing.Size(152, 27)
        Me.GraphAll.TabIndex = 52
        Me.GraphAll.Text = "Check All"
        Me.GraphAll.UseVisualStyleBackColor = True
        '
        'CumAmChrt
        '
        Me.CumAmChrt.BorderlineColor = System.Drawing.Color.WhiteSmoke
        Me.CumAmChrt.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        Me.CumAmChrt.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea4.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot
        ChartArea4.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea4.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot
        ChartArea4.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea4.Name = "ChartArea2"
        Me.CumAmChrt.ChartAreas.Add(ChartArea4)
        Me.CumAmChrt.Cursor = System.Windows.Forms.Cursors.Cross
        Legend4.Name = "Legend1"
        Me.CumAmChrt.Legends.Add(Legend4)
        Me.CumAmChrt.Location = New System.Drawing.Point(193, 298)
        Me.CumAmChrt.Name = "CumAmChrt"
        Series25.ChartArea = "ChartArea2"
        Series25.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series25.Legend = "Legend1"
        Series25.Name = "Electricity Consumed (W-hr)"
        Series25.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series26.ChartArea = "ChartArea2"
        Series26.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series26.Legend = "Legend1"
        Series26.Name = "Electricity Produced (W-hr)"
        Series26.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series27.ChartArea = "ChartArea2"
        Series27.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series27.Legend = "Legend1"
        Series27.Name = "Natural Gas (cubic ft)"
        Series27.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series28.ChartArea = "ChartArea2"
        Series28.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series28.Legend = "Legend1"
        Series28.Name = "Water (gal)"
        Series28.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series29.ChartArea = "ChartArea2"
        Series29.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series29.Legend = "Legend1"
        Series29.Name = "Natural Gas (cubic meters)"
        Series29.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series30.ChartArea = "ChartArea2"
        Series30.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series30.Legend = "Legend1"
        Series30.Name = "Water (liters)"
        Series30.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series31.ChartArea = "ChartArea2"
        Series31.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series31.Legend = "Legend1"
        Series31.Name = "Total Energy Storage (W-hr) "
        Series31.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Series32.ChartArea = "ChartArea2"
        Series32.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series32.Legend = "Legend1"
        Series32.Name = "Present Energy Storage (W-hr)"
        Series32.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time
        Me.CumAmChrt.Series.Add(Series25)
        Me.CumAmChrt.Series.Add(Series26)
        Me.CumAmChrt.Series.Add(Series27)
        Me.CumAmChrt.Series.Add(Series28)
        Me.CumAmChrt.Series.Add(Series29)
        Me.CumAmChrt.Series.Add(Series30)
        Me.CumAmChrt.Series.Add(Series31)
        Me.CumAmChrt.Series.Add(Series32)
        Me.CumAmChrt.Size = New System.Drawing.Size(971, 253)
        Me.CumAmChrt.TabIndex = 53
        Title4.BorderColor = System.Drawing.Color.Transparent
        Title4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title4.Name = "Cumulative Amount"
        Title4.Text = "Cumulative Amount"
        Me.CumAmChrt.Titles.Add(Title4)
        '
        'SaveCommDatabtn
        '
        Me.SaveCommDatabtn.Location = New System.Drawing.Point(7, 118)
        Me.SaveCommDatabtn.Name = "SaveCommDatabtn"
        Me.SaveCommDatabtn.Size = New System.Drawing.Size(152, 28)
        Me.SaveCommDatabtn.TabIndex = 54
        Me.SaveCommDatabtn.Text = "Save Data"
        Me.SaveCommDatabtn.UseVisualStyleBackColor = True
        '
        'EnableCodeGPBX
        '
        Me.EnableCodeGPBX.Controls.Add(Me.ChrtChk0)
        Me.EnableCodeGPBX.Controls.Add(Me.ChrtChk1)
        Me.EnableCodeGPBX.Controls.Add(Me.ChrtChk2)
        Me.EnableCodeGPBX.Controls.Add(Me.ChrtChk3)
        Me.EnableCodeGPBX.Controls.Add(Me.ChrtChk4)
        Me.EnableCodeGPBX.Controls.Add(Me.ChrtChk5)
        Me.EnableCodeGPBX.Controls.Add(Me.ChrtChk6)
        Me.EnableCodeGPBX.Controls.Add(Me.ChrtChk7)
        Me.EnableCodeGPBX.Location = New System.Drawing.Point(11, 52)
        Me.EnableCodeGPBX.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.EnableCodeGPBX.Name = "EnableCodeGPBX"
        Me.EnableCodeGPBX.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.EnableCodeGPBX.Size = New System.Drawing.Size(165, 222)
        Me.EnableCodeGPBX.TabIndex = 56
        Me.EnableCodeGPBX.TabStop = False
        Me.EnableCodeGPBX.Text = "Enable Code"
        '
        'GraphCtrlGPBX
        '
        Me.GraphCtrlGPBX.Controls.Add(Me.SaveCommGraphbtn)
        Me.GraphCtrlGPBX.Controls.Add(Me.ResetBTN)
        Me.GraphCtrlGPBX.Controls.Add(Me.SaveCommDatabtn)
        Me.GraphCtrlGPBX.Controls.Add(Me.GraphAll)
        Me.GraphCtrlGPBX.Controls.Add(Me.PauseCommodityGrphBTN)
        Me.GraphCtrlGPBX.Location = New System.Drawing.Point(9, 329)
        Me.GraphCtrlGPBX.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GraphCtrlGPBX.Name = "GraphCtrlGPBX"
        Me.GraphCtrlGPBX.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GraphCtrlGPBX.Size = New System.Drawing.Size(167, 187)
        Me.GraphCtrlGPBX.TabIndex = 57
        Me.GraphCtrlGPBX.TabStop = False
        Me.GraphCtrlGPBX.Text = "Controls"
        '
        'SaveCommGraphbtn
        '
        Me.SaveCommGraphbtn.Location = New System.Drawing.Point(7, 151)
        Me.SaveCommGraphbtn.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.SaveCommGraphbtn.Name = "SaveCommGraphbtn"
        Me.SaveCommGraphbtn.Size = New System.Drawing.Size(152, 28)
        Me.SaveCommGraphbtn.TabIndex = 56
        Me.SaveCommGraphbtn.Text = "Save Graph"
        Me.SaveCommGraphbtn.UseVisualStyleBackColor = True
        '
        'ResetBTN
        '
        Me.ResetBTN.Location = New System.Drawing.Point(7, 85)
        Me.ResetBTN.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ResetBTN.Name = "ResetBTN"
        Me.ResetBTN.Size = New System.Drawing.Size(152, 27)
        Me.ResetBTN.TabIndex = 55
        Me.ResetBTN.Text = "Reset"
        Me.ResetBTN.UseVisualStyleBackColor = True
        '
        'CommodityChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1171, 559)
        Me.Controls.Add(Me.GraphCtrlGPBX)
        Me.Controls.Add(Me.EnableCodeGPBX)
        Me.Controls.Add(Me.CumAmChrt)
        Me.Controls.Add(Me.InstAmChrt)
        Me.Name = "CommodityChart"
        Me.Text = "CTA-2045 Commodity Charts : Instantaneous Rate - Cumulative Amount"
        CType(Me.InstAmChrt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CumAmChrt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EnableCodeGPBX.ResumeLayout(False)
        Me.GraphCtrlGPBX.ResumeLayout(False)
        Me.GraphCtrlGPBX.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents InstAmChrt As DataVisualization.Charting.Chart
    Friend WithEvents ChrtChk1 As CheckBox
    Friend WithEvents ChrtChk2 As CheckBox
    Friend WithEvents ChrtChk3 As CheckBox
    Friend WithEvents ChrtChk4 As CheckBox
    Friend WithEvents ChrtChk5 As CheckBox
    Friend WithEvents ChrtChk6 As CheckBox
    Friend WithEvents ChrtChk7 As CheckBox
    Friend WithEvents ChrtChk0 As CheckBox
    Friend WithEvents PauseCommodityGrphBTN As Button
    Friend WithEvents GraphAll As Button
    Friend WithEvents CumAmChrt As DataVisualization.Charting.Chart
    Friend WithEvents SaveCommDatabtn As Button
    Friend WithEvents EnableCodeGPBX As GroupBox
    Friend WithEvents GraphCtrlGPBX As GroupBox
    Friend WithEvents ResetBTN As Button
    Friend WithEvents SaveCommGraphbtn As Button
End Class
