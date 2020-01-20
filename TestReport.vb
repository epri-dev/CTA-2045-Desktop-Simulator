Public Class TestReport
    Private CommodityTestCase As String() = {"Energy Produced", "Energy Consumed", "Natural Gas", "Water", "Total Energy Stored", "Present Engergy Stored", "Max Consumption Level", "Max Production Level"}
    Private FunctionalTestCase As String() = {"Shed Test", "Critical Peak Test", "Grid Emergency Test", "Load Up Test", "Cycling Test", "Power Cycle Test"}
    Private DREventTestCase As String() = {"Shed Event", "Critical Peak Event", "Grid Emergency Event", "Load Up Event", "Cycling Event"}
    Private DRCommandsTestCase As String() = {"Message Supported Query", "Shed Command", "Run Normal", "Device Information", "Outside Communication Status", "Application ACK", "Application NAK", "Commodity Read", "Operational State"}
    Private BasePath = IO.Path.GetDirectoryName(FrmMain.tbLogFile.Text)

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SearchKeywordRB_CheckedChanged(sender As Object, e As EventArgs) Handles SearchKeywordRB.CheckedChanged
        If SearchKeywordRB.Checked = True Then
            SearchGB.Enabled = True
            CommandTestCB.Checked = False
            EventTestCB.Checked = False
            FunctionalTestCB.Checked = False
            EnergyTestCB.Checked = False
            AllTestCB.Checked = False
            TestsGB.Enabled = False
            TestCaseCBB.Enabled = False
            TestCaseCBB.ResetText()
        Else
            SearchGB.Enabled = False
            TestsGB.Enabled = True
            TestCaseCBB.Enabled = True
        End If
        TestCaseCBB.Items.Clear()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SearchTestCaseRB_CheckedChanged(sender As Object, e As EventArgs) Handles SearchTestCaseRB.CheckedChanged
        If SearchTestCaseRB.Checked = True Then
            SearchGB.Enabled = False
            TestsGB.Enabled = True
        Else
            SearchGB.Enabled = True
            TestsGB.Enabled = False
        End If
        TestCaseCBB.Items.Clear()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AllTestCB_CheckedChanged(sender As Object, e As EventArgs) Handles AllTestCB.CheckedChanged
        If AllTestCB.Checked = False Then
            CommandTestCB.Checked = False
            EventTestCB.Checked = False
            FunctionalTestCB.Checked = False
            EnergyTestCB.Checked = False
            TestCaseCBB.Items.Clear()
        Else
            TestCaseCBB.Items.Add("All Test Case")
            CommandTestCB.Checked = True
            EventTestCB.Checked = True
            FunctionalTestCB.Checked = True
            EnergyTestCB.Checked = True
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CommandTestCB_CheckedChanged(sender As Object, e As EventArgs) Handles CommandTestCB.CheckedChanged
        If CommandTestCB.Checked = True Then
            TestCaseCBB.Items.AddRange(DRCommandsTestCase)
        Else
            TestCaseCBB_RemoveRange(DRCommandsTestCase)
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EventTestCB_CheckedChanged(sender As Object, e As EventArgs) Handles EventTestCB.CheckedChanged
        If EventTestCB.Checked = True Then
            TestCaseCBB.Items.AddRange(DREventTestCase)
        Else
            TestCaseCBB_RemoveRange(DREventTestCase)
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FunctionalTestCB_CheckedChanged(sender As Object, e As EventArgs) Handles FunctionalTestCB.CheckedChanged
        If FunctionalTestCB.Checked = True Then
            TestCaseCBB.Items.AddRange(FunctionalTestCase)
        Else
            TestCaseCBB_RemoveRange(FunctionalTestCase)
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EnergyTestCB_CheckedChanged(sender As Object, e As EventArgs) Handles EnergyTestCB.CheckedChanged
        If EnergyTestCB.Checked = True Then
            TestCaseCBB.Items.AddRange(CommodityTestCase)
        Else
            TestCaseCBB_RemoveRange(CommodityTestCase)
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RunSearchBtn_Click(sender As Object, e As EventArgs) Handles RunSearchBtn.Click
        ResultsRTB.Clear() ' Clear before processing
        Dim filePath = String.Empty
        Dim Content As List(Of String)
        Dim UserChoice = MessageBox.Show("Use the current log file ?", "Perform Search", MessageBoxButtons.YesNoCancel)
        If UserChoice = DialogResult.Yes Then
            filePath = FrmMain.tbLogFile.Text
        ElseIf UserChoice = DialogResult.No Then
            If OpenFile.ShowDialog() = DialogResult.OK Then
                filePath = OpenFile.FileName
                BasePath = IO.Path.GetDirectoryName(OpenFile.FileName)
            End If
        Else
            Exit Sub
        End If
        If SearchKeywordRB.Checked = True Then
            Dim lineCount = 0
            Dim linesFound = 0
            Dim formatedString = String.Empty
            Dim formatedResults = New List(Of String)

            If SearchBox.Text = String.Empty Or IsNothing(SearchBox.Text) Then
                MessageBox.Show(" !!! No Keyword(s) !!! ", "Search By Keyword")
                Exit Sub
            Else
                Content = FilterContentOnDate(filePath)
            End If

            Dim result = FindKeyword(SearchBox.Text, Content)

            ResultsRTB.ScrollToCaret()
            ResultsRTB.AppendText(Environment.NewLine & "Results For: " & SearchBox.Text & Environment.NewLine)

            For Each line As String In result
                formatedString = GetCurrentDate(line) & ", " & String.Join(", ", line.Split(",").Skip(2))
                formatedResults.Add(formatedString)
            Next
            linesFound = result.Count

            TestProgressBar.Value = 65
            For Each line In formatedResults
                ResultsRTB.AppendText(line & Environment.NewLine)
            Next

            TestProgressBar.Value = 100
            ResultsRTB.AppendText(Environment.NewLine & "End Results" & Environment.NewLine)
            MessageBox.Show("'" & SearchBox.Text & "' " & linesFound.ToString() & " Entrie(s) Found !", "Search By Keyword")
        Else
            Dim linesFound = 0
            Dim formatedString = String.Empty
            Dim formatedResults = New List(Of String)
            Dim result = New Dictionary(Of String, List(Of String))

            If TestCaseCBB.Text = String.Empty Or IsNothing(TestCaseCBB.Text) Then
                MessageBox.Show(" !!! No Category Selected  !!! ", "Search By Category")
                Exit Sub
            Else
                Content = FilterContentOnDate(filePath)
            End If

            ResultsRTB.ScrollToCaret()
            ResultsRTB.AppendText(Environment.NewLine & "Results For: " & TestCaseCBB.Text & Environment.NewLine)

            If AllTestCB.Checked Then
                If TestCaseCBB.Text = "All Test Case" Then
                    result = ProcessAllTets(Content)
                Else
                    result.Add(TestCaseCBB.Text, FindKeyword(TestCaseCBB.Text, Content))
                End If
            ElseIf EnergyTestCB.Checked Then
                result.Add(TestCaseCBB.Text, ProcessDRCommodity(Content))
            ElseIf FunctionalTestCB.Checked Then
                result.Add(TestCaseCBB.Text, ProcessFunctionalTests(Content))
            ElseIf EventTestCB.Checked Then
                result.Add(TestCaseCBB.Text, ProcessDREvents(Content))
            ElseIf CommandTestCB.Checked Then
                result.Add(TestCaseCBB.Text, ProcessDRCommands(Content))
            Else
                MessageBox.Show(" !!! No Selection  !!! ", "Search By Category")
                Exit Sub
            End If

            For Each value As List(Of String) In result.Values
                For Each line As String In value
                    formatedString = GetCurrentDate(line) & ", " & String.Join(", ", line.Split(",").Skip(2))
                    formatedResults.Add(formatedString)
                Next
                linesFound += value.Count
            Next

            TestProgressBar.Value = 60

            formatedResults.Sort(Function(strA As String, strB As String)
                                     Return DateTime.Compare(strA.Split(","c)(0), strB.Split(","c)(0))
                                 End Function)

            TestProgressBar.Value = 80
            For Each line In formatedResults
                ResultsRTB.AppendText(line & Environment.NewLine)
            Next

            TestProgressBar.Value = 95
            ResultsRTB.AppendText(Environment.NewLine & "End Results" & Environment.NewLine)
            TestProgressBar.Value = 100
            MessageBox.Show(" !!! Search Complete !!! " & linesFound.ToString() & " Entrie(s) Found !", "Search By Category")
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="line"></param>
    ''' <returns></returns>
    Function GetCurrentDate(line) As Date
        Dim curValue As Date
        Try
            curValue = DateAdd("s", Convert.ToDouble(line.Split(",")(0)), #1/1/2000#)
        Catch ex As Exception
            curValue = #1/1/2000#
            Console.WriteLine("Error Parsing LogFile " & ex.Message)
        End Try
        GetCurrentDate = curValue
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="targetArray"></param>
    ''' <returns></returns>
    Private Function TestCaseCBB_RemoveRange(targetArray As String()) As Boolean
        Dim done = False
        Try
            TestCaseCBB.ResetText()
            For Each item In targetArray
                TestCaseCBB.Items.Remove(item)
                done = True
            Next
        Catch ex As Exception
            Console.WriteLine("Error Removing item from TestCaseCBB: " & ex.Message)
            done = False
        End Try
        TestCaseCBB_RemoveRange = done
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="fileContent"></param>
    ''' <returns></returns>
    ''' TODO : Search Commands and Their ACK or NAK
    Private Function ProcessDRCommands(fileContent As List(Of String)) As List(Of String)
        Dim found As List(Of String) = New List(Of String)
        Select Case TestCaseCBB.Text
            Case DRCommandsTestCase(0)
                found = FindKeyword(DRCommandsTestCase(0).Replace("Message ", ""), fileContent)
            Case DRCommandsTestCase(1)
                found = FindKeyword(DRCommandsTestCase(1), fileContent)
            Case DRCommandsTestCase(2)
                found = FindKeyword(DRCommandsTestCase(2), fileContent)
            Case DRCommandsTestCase(3)
                found = FindKeyword(DRCommandsTestCase(3).Replace("Information", "Info"), fileContent)
            Case DRCommandsTestCase(4)
                found = FindKeyword(DRCommandsTestCase(4).Replace("Outside Communication", "Comm"), fileContent)
            Case DRCommandsTestCase(5)
                found = FindKeyword(DRCommandsTestCase(5), fileContent)
            Case DRCommandsTestCase(6)
                found = FindKeyword(DRCommandsTestCase(6), fileContent)
            Case DRCommandsTestCase(7)
                found = FindKeyword(DRCommandsTestCase(7), fileContent)
            Case DRCommandsTestCase(8)
                found = FindKeyword(DRCommandsTestCase(8).Replace("Operational", "Op"), fileContent)
            Case Else
                Console.WriteLine("Error, No Matching Event Found for : " & TestCaseCBB.SelectedText)
        End Select
        ProcessDRCommands = found
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="fileContent"></param>
    ''' <returns></returns>
    Private Function ProcessDREvents(fileContent As List(Of String)) As List(Of String)
        Dim found As List(Of String) = New List(Of String)
        Dim additional = {DRCommandsTestCase(5), DRCommandsTestCase(6)}
        Select Case TestCaseCBB.Text
            Case DREventTestCase(0)
                found = FindKeyword(DREventTestCase(0).Replace("Event", "Command"), fileContent, additional)
            Case DREventTestCase(1)
                found = FindKeyword(DREventTestCase(1).Replace("Event", "Command"), fileContent, additional)
            Case DREventTestCase(2)
                found = FindKeyword(DREventTestCase(2).Replace("Event", "Command"), fileContent, additional)
            Case DREventTestCase(3)
                found = FindKeyword(DREventTestCase(3).Replace("Event", "Command"), fileContent, additional)
            Case DREventTestCase(4)
                found = FindKeyword(DREventTestCase(4), fileContent, additional)
            Case Else
                Console.WriteLine("Error, No Matching Event Found for : " & TestCaseCBB.SelectedText)
        End Select
        ProcessDREvents = found
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="fileContent"></param>
    ''' <returns></returns>
    Private Function ProcessFunctionalTests(fileContent As List(Of String)) As List(Of String)
        Dim found As List(Of String) = New List(Of String)
        Dim additional = {DRCommandsTestCase(5), DRCommandsTestCase(6), "Op State", DRCommandsTestCase(2)}
        Select Case TestCaseCBB.Text
            Case FunctionalTestCase(0)
                found = FindKeyword(FunctionalTestCase(0), fileContent, additional)
            Case FunctionalTestCase(1)
                found = FindKeyword(FunctionalTestCase(1), fileContent, additional)
            Case FunctionalTestCase(2)
                found = FindKeyword(FunctionalTestCase(2), fileContent, additional)
            Case FunctionalTestCase(3)
                found = FindKeyword(FunctionalTestCase(3), fileContent, additional)
            Case FunctionalTestCase(4)
                found = FindKeyword(FunctionalTestCase(4), fileContent, additional)
            Case FunctionalTestCase(5)
                found = FindKeyword(FunctionalTestCase(5), fileContent, additional)
            Case Else
                Console.WriteLine("Error, No Matching Event Found for : " & TestCaseCBB.SelectedText)
        End Select
        ProcessFunctionalTests = found
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="fileContent"></param>
    ''' <returns></returns>
    ''' TODO : Find the Best Keyword to retreive specific commodity read
    Private Function ProcessDRCommodity(fileContent As List(Of String)) As List(Of String)
        Dim found As List(Of String) = New List(Of String)
        Dim additional = {"Commodity read"}
        Select Case TestCaseCBB.Text
            Case CommodityTestCase(0)
                found = FindKeyword(CommodityTestCase(0), fileContent, additional)
            Case CommodityTestCase(1)
                found = FindKeyword(CommodityTestCase(1), fileContent, additional)
            Case CommodityTestCase(2)
                found = FindKeyword(CommodityTestCase(2), fileContent, additional)
            Case CommodityTestCase(3)
                found = FindKeyword(CommodityTestCase(3), fileContent, additional)
            Case CommodityTestCase(4)
                found = FindKeyword(CommodityTestCase(4), fileContent, additional)
            Case CommodityTestCase(5)
                found = FindKeyword(CommodityTestCase(5), fileContent, additional)
            Case CommodityTestCase(6)
                found = FindKeyword(CommodityTestCase(6), fileContent, additional)
            Case CommodityTestCase(7)
                found = FindKeyword(CommodityTestCase(7), fileContent, additional)
            Case Else
                Console.WriteLine("Error, No Matching Event Found for : " & TestCaseCBB.SelectedText)
        End Select
        ProcessDRCommodity = found
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="fileContent"></param>
    ''' <returns></returns>
    Private Function ProcessAllTets(fileContent As List(Of String)) As Dictionary(Of String, List(Of String))
        Dim found = New Dictionary(Of String, List(Of String))
        For Each item In DRCommandsTestCase
            TestCaseCBB.Text = item
            found.Add(item, ProcessDRCommands(fileContent))
        Next
        For Each item In DREventTestCase
            TestCaseCBB.Text = item
            found.Add(item, ProcessDREvents(fileContent))
        Next
        For Each item In FunctionalTestCase
            TestCaseCBB.Text = item
            found.Add(item, ProcessFunctionalTests(fileContent))
        Next
        For Each item In CommodityTestCase
            TestCaseCBB.Text = item
            found.Add(item, ProcessDRCommodity(fileContent))
        Next
        TestCaseCBB.ResetText()
        ProcessAllTets = found
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="file"></param>
    ''' <returns></returns>
    Function FilterContentOnDate(file As String) As List(Of String)
        Dim isvalid = Function(value) As Boolean
                          If EndDateTimePicker.Value > StartDateTimePicker.Value Then
                              Return EndDateTimePicker.Value >= value And StartDateTimePicker.Value <= value
                          Else
                              Return EndDateTimePicker.Value <= value And StartDateTimePicker.Value >= value
                          End If
                      End Function

        TestProgressBar.Value = 0
        Dim content = New List(Of String)
        Dim sr = New IO.StreamReader(file)
        Dim lines = sr.ReadToEnd().Split(Environment.NewLine)
        sr.Close()
        TestProgressBar.Value = 10

        Dim Max_Progress = lines.Count
        Dim line As String = ""

        For I As Integer = 1 To Max_Progress
            ResultsRTB.AppendText(lines(I - 1))
            If lines(I - 1) <> "" Then
                If isvalid(GetCurrentDate(lines(I - 1))) Then
                    content.Add(lines(I - 1))
                End If
            End If
            TestProgressBar.Increment(I / Max_Progress)
        Next
        FilterContentOnDate = content
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="keyword"></param>
    ''' <param name="content"></param>
    ''' <param name="additional"></param>
    ''' <returns></returns>
    Function FindKeyword(keyword As String, content As List(Of String), Optional ByVal additional As String() = Nothing) As List(Of String)
        Dim ContainsAny = Function(target) As Boolean
                              If target.ToLower().Contains(keyword.ToLower()) Then
                                  Return True
                              ElseIf additional IsNot Nothing Then
                                  For Each word As String In additional
                                      If target.ToLower().Contains(word.ToLower()) Then
                                          Return True
                                      End If
                                  Next
                              End If
                              Return False
                          End Function

        Dim strList = New List(Of String)
        TestProgressBar.Value = 0
        For Each line As String In content
            If ContainsAny(line) Then
                strList.Add(line)
            End If
        Next
        TestProgressBar.Value = 30
        FindKeyword = strList
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SearchBox_Clicked(sender As Object, e As EventArgs) Handles SearchBox.MouseClick
        If SearchBox.Text = "Enter Keyword here" Then
            SearchBox.Clear()
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CancelSearchBtn_Click(sender As Object, e As EventArgs) Handles CancelSearchBtn.Click
        SearchBox.Text = "Enter Keyword here"
        SearchKeywordRB.Checked = False
        StartDateTimePicker.Value = Today
        EndDateTimePicker.Value = Today.Add(New TimeSpan(23, 59, 59))
        SearchKeywordRB.PerformClick()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveReportBtn_Click(sender As Object, e As EventArgs) Handles SaveReportBtn.Click
        Dim sr As IO.StreamWriter = Nothing
        Dim inResult As Boolean = False
        Dim fileName = String.Empty
        If ResultsRTB.Lines.Count < 3 Then
            MessageBox.Show(" !!! Nothing to Export !!! ")
            Exit Sub
        End If
        For Each line In ResultsRTB.Lines
            If line.StartsWith("Results For:") Then
                inResult = True
                fileName = line.Substring(13).Replace(" ", "_") & ".csv"
                If sr IsNot Nothing Then
                    sr.Close()
                End If
                sr = New IO.StreamWriter(IO.Path.Combine(BasePath, fileName))
            ElseIf line.StartsWith("End Results") Then
                inResult = False
                If sr IsNot Nothing Then
                    sr.Close()
                End If
            ElseIf sr IsNot Nothing And inResult Then
                sr.WriteLine(line)
            End If
        Next
        MessageBox.Show(" !!! Export Complete !!! ")
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ChooseFileBtn_Click(sender As Object, e As EventArgs) Handles ChooseFileBtn.Click
        Try
            Dim SaveFile = New SaveFileDialog With {
                .DefaultExt = "csv",
                .InitialDirectory = IO.Directory.GetCurrentDirectory(),
                .Filter = "Comma Delimited (*.csv)|*.csv|All Files (*.*)|*.*"
            }
            If SaveFile.ShowDialog() = DialogResult.OK Then
                ResultFileTB.Text = SaveFile.FileName
            End If
        Catch ex As Exception
            MessageBox.Show("Exception Occured in " & sender.ToString() & " " & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If ResultFileTB.Text <> "" Then
            TestProgressBar.Value = 0
            Dim Lines = ResultsRTB.Lines
            Dim Max_Progess = ResultsRTB.Lines.Count
            Using sw As New IO.StreamWriter(ResultFileTB.Text, True)
                For I As Integer = 1 To Max_Progess
                    sw.Write(Lines(I - 1))
                    TestProgressBar.Increment(I / Max_Progess)
                Next
            End Using
        Else
            MessageBox.Show("No File Path Specified : Please Select a File Path")
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CancelSearchBtn_Click(sender, e)
        ResultFileTB.Clear()
        TestProgressBar.Value = 0
        ResultsRTB.Clear()
    End Sub
End Class