Public Class CommodityChart
    Dim COMMODITIES As New List(Of String) From {"Electricity Consumed", "Electricity Produced", "Natural Gas (cubic ft/hr)", "Water (gal/hr)", "Natural Gas (cubic meters/hr)", "Water (liters/hr)", "Total Energy Storage", "Present Energy Storage"}
    Dim CumChrtLocation As Drawing.Point
    Dim InstChrtSize As Drawing.Size
    Dim CumChrtSize As Drawing.Size
    Dim ThisSize As Drawing.Size
    Dim Loaded As Boolean = False

    Private Sub CommodityChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ChrtChk = Me.EnableCodeGPBX.Controls.OfType(Of CheckBox)

        For I = 0 To 7
            ' disables all commodity series on load so only selected will load when graph clicked
            InstAmChrt.Series(I).Enabled = False
            CumAmChrt.Series(I).Enabled = False
            ' applies text property of checkboxes
            ChrtChk(I).Text = COMMODITIES(I)
        Next

    End Sub

    Private Sub CommodityChart_Closing(sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'shows message to warn against closing graph window, cancels close if cancel is selected
        If MessageBox.Show("Closing this window will get rid of graphed data.", "WARNING", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then
            e.Cancel = True
        End If
    End Sub

    Private Sub StartGraph_Click(sender As Object, e As EventArgs) Handles GraphAll.Click
        'activates (graphs) the series for each checked commodity
        Dim ChrtChk = EnableCodeGPBX.Controls.OfType(Of CheckBox)
        If GraphAll.Text = "Check All" Then
            GraphAll.Text = "Uncheck All"
            For Each chk In ChrtChk
                chk.Checked = True
            Next
        Else
            GraphAll.Text = "Check All"
            For Each chk In ChrtChk
                chk.Checked = False
            Next
        End If

        'force update checkboxes' events
        For Each chk In ChrtChk
            chk.Update()
        Next

    End Sub

    Private Sub SaveCommDatabtn_Click(sender As Object, e As EventArgs) Handles SaveCommDatabtn.Click
        Dim SaveData = New SaveFileDialog With {
            .DefaultExt = "csv",
            .InitialDirectory = IO.Directory.GetCurrentDirectory(),
            .Filter = "comma delimited (*.csv)|*.csv|All files (*.*)|*.*"
        }
        Try
            If SaveData.ShowDialog() = DialogResult.OK Then
                'creates and writes commodity data to save file specified
                Dim Charts = Me.Controls.OfType(Of DataVisualization.Charting.Chart)
                Dim ChrtChk = Me.EnableCodeGPBX.Controls.OfType(Of CheckBox)

                'save commodity data into csv files
                Using file2 As New IO.StreamWriter(SaveData.FileName, True)
                    For Each chart In Charts
                        If chart.Name = "InstAmChrt" Then
                            file2.WriteLine(" , , Instantaneous Amount,  Time")
                        Else
                            file2.WriteLine(" , , Cumulative Amount,  Time")
                        End If
                        For Each chk In ChrtChk
                            If Not chk.Checked Then Continue For
                            Dim I = Convert.ToInt32(COMMODITIES.IndexOf(chk.Text))
                            For Each Point In chart.Series(I).Points
                                file2.WriteLine("Commodity Code: ," & I & ", " & (Point.YValues(0)).ToString & ", " & (Point.XValue).ToString())
                            Next
                            file2.WriteLine(Environment.NewLine)
                        Next
                        file2.WriteLine(Environment.NewLine)
                    Next
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub " & sender.ToString() & " : " & ex.Message)
        End Try
    End Sub

    Private Sub ChrtChk_CheckedChanged(sender As Object, e As EventArgs) Handles ChrtChk0.CheckedChanged, ChrtChk1.CheckedChanged, ChrtChk2.CheckedChanged, ChrtChk3.CheckedChanged, ChrtChk4.CheckedChanged, ChrtChk5.CheckedChanged, ChrtChk6.CheckedChanged, ChrtChk7.CheckedChanged
        Dim I = COMMODITIES.IndexOf(sender.Text)
        If sender.Checked = True Then
            InstAmChrt.Series(I).Enabled = True
            CumAmChrt.Series(I).Enabled = True
        Else
            InstAmChrt.Series(I).Enabled = False
            CumAmChrt.Series(I).Enabled = False
        End If
    End Sub

    Private Sub PauseCommodityGrphBTN_Click(sender As Object, e As EventArgs) Handles PauseCommodityGrphBTN.Click
        If PauseCommodityGrphBTN.Text = "Pause" Then
            PauseCommodityGrphBTN.Text = "Resume"
        Else
            PauseCommodityGrphBTN.Text = "Pause"
        End If
    End Sub

    Private Sub ResetBTN_Click(sender As Object, e As EventArgs) Handles ResetBTN.Click
        ' Reset Buttons Text
        If GraphAll.Text = "Uncheck All" Then GraphAll.Text = "Check All"
        If PauseCommodityGrphBTN.Text = "Resume" Then PauseCommodityGrphBTN.Text = "Pause"

        ' Uncheck all Commodities
        For Each chk In EnableCodeGPBX.Controls.OfType(Of CheckBox)
            If chk.Checked Then chk.Checked = False
            chk.Update()
        Next

        ' Clear Data in Series
        For Each chart In Me.Controls.OfType(Of DataVisualization.Charting.Chart)
            For Each serie In chart.Series
                serie.Points.Clear()
            Next
        Next
    End Sub

    Private Sub SaveCommGraphbtn_Click(sender As Object, e As EventArgs) Handles SaveCommGraphbtn.Click
        Dim SaveGraph = New SaveFileDialog With {
            .DefaultExt = "png",
            .InitialDirectory = IO.Directory.GetCurrentDirectory(),
            .Filter = "PNG (*.png)|*.png|All files (*.*)|*.*"
        }
        Try
            If SaveGraph.ShowDialog() = DialogResult.OK Then
                Dim pos = SaveGraph.FileName.LastIndexOf("."c)
                'creates and writes commodity graph to save file specified
                Dim Charts = Me.Controls.OfType(Of DataVisualization.Charting.Chart)
                For Each chart In Charts
                    If chart.Name = "InstAmChrt" Then
                        chart.SaveImage(SaveGraph.FileName.Insert(pos, "_watts"), Imaging.ImageFormat.Png)
                    Else
                        chart.SaveImage(SaveGraph.FileName.Insert(pos, "_watts_hour"), Imaging.ImageFormat.Png)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub " & sender.ToString() & " : " & ex.Message)
        End Try
    End Sub

    Private Sub CommodityChart_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Loaded Then
            If Me.WindowState = FormWindowState.Maximized Then
                Dim szOffset = New Drawing.Size(Me.Size.Width - ThisSize.Width, (Me.Size.Height - ThisSize.Height) / 2)
                InstAmChrt.Size += szOffset
                CumAmChrt.Size += szOffset
                CumAmChrt.Location = New Drawing.Point(CumChrtLocation.X, CumChrtLocation.Y + szOffset.Height)
            ElseIf Me.WindowState = FormWindowState.Normal Then
                Dim szOffset = New Drawing.Size(Me.Size.Width - ThisSize.Width, (Me.Size.Height - ThisSize.Height) / 2)
                InstAmChrt.Size = InstChrtSize + szOffset
                CumAmChrt.Size = CumChrtSize + szOffset
                CumAmChrt.Location = New Drawing.Point(CumChrtLocation.X, CumChrtLocation.Y + szOffset.Height)
            Else 'ElseIF  WindowState = FormWindowState.Minimized Then
                InstAmChrt.Size = InstChrtSize
                CumAmChrt.Size = CumChrtSize
                CumAmChrt.Location = CumChrtLocation
            End If

        Else
            Loaded = True
            ThisSize = Me.Size
            InstChrtSize = InstAmChrt.Size
            CumChrtSize = CumAmChrt.Size
            CumChrtLocation = CumAmChrt.Location
        End If
    End Sub
End Class