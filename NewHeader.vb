Public Class NewHeader

    Private DefaultCommentText = "Device Sticker Info" & vbLf & "Model: mismatched ..."
    Private DefaultDevInfoText = "Ask Device Info"

    Private Sub NewHeader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CommentRTB.Text = DefaultCommentText
        loadDeviceInfoBTN.Text = DefaultDevInfoText
        DateTB.Text = Today.ToShortDateString()
    End Sub

    Private Sub CreateHeaderFileBtn_Click(sender As Object, e As EventArgs) Handles CreateHeaderFileBtn.Click
        'Lambda Expression to write Test Header
        Dim saveHeader = Sub(filename)
                             Using file As New System.IO.StreamWriter(filename, True)
                                 file.WriteLine(DateLbl.Text & ", " & DateTB.Text)
                                 ' Group1 Testing Entity Information
                                 file.WriteLine("Testing Lab, ")
                                 file.WriteLine(TestNameLbl.Text & ", " & TestNameTB.Text)
                                 file.WriteLine(labNameLbl.Text & ", " & labNameTB.Text)
                                 file.WriteLine(LocationLbl.Text & ", " & LocationTB.Text)
                                 ' Group2 Tester Information
                                 file.WriteLine("Test Engineer , ")
                                 file.WriteLine(EngineerNameLbl.Text & ", " & EngineerNameTB.Text)
                                 file.WriteLine(EngineerEmailLbl.Text & ", " & EngineerEmailTB.Text)
                                 file.WriteLine(EngineerPhoneLbl.Text & ", " & EngineerPhoneTB.Text)
                                 ' Group3 Device Information
                                 file.WriteLine("Device Information, ")
                                 file.WriteLine(ManufacturerLbl.Text & ", " & ManufacturerTB.Text)
                                 file.WriteLine(VendorIDLbl.Text & ", " & VendorIDTB.Text)
                                 file.WriteLine(DeviceNameLbl.Text & ", " & DeviceNameTB.Text)
                                 file.WriteLine(ModelNumLbl.Text & ", " & ModelNumTB.Text)
                                 file.WriteLine(SerialNumberLbl.Text & ", " & SerialNumberTB.Text)
                                 file.WriteLine(CTAVersionLbl.Text & ", " & CTAVersionTB.Text)
                                 file.WriteLine(FirmwareLbl.Text & ", " & FirmwareTB.Text)
                                 file.WriteLine(FirmwareDateLbl.Text & ", " & FirmwareDateTB.Text)
                                 ' Group4 Additional Device Information
                                 file.WriteLine("Additonal Information, ")
                                 file.WriteLine(MaxPayploadLbl.Text & ", " & MaxPayloadTB.Text)
                                 file.WriteLine(FormFactorLbl.Text & ", " & FormFactorTB.Text)
                                 file.WriteLine(NetworkTechLbl.Text & ", " & NetworkTechTB.Text)
                                 'Group5 User Comments
                                 If CommentRTB.Text <> DefaultCommentText Then
                                     Dim lineContent As String()
                                     file.WriteLine("User Comments, ")
                                     For Each line In CommentRTB.Lines
                                         lineContent = line.Split(":"c)
                                         For Each word In lineContent
                                             file.Write(word & ", ")
                                         Next
                                         file.Write(Environment.NewLine)
                                     Next
                                 End If
                             End Using
                         End Sub

        ' Writting Header to new file
        saveHeader(FrmMain.testHeaderSaveFile)

        ' Adding header to current log file
        If Not FrmMain.disableLogFile.Checked Then saveHeader(FrmMain.tbLogFile.Text)
        Me.Close()
    End Sub

    Private Sub getDeviceInfoBTN_Click(sender As Object, e As EventArgs) Handles loadDeviceInfoBTN.Click
        Me.SendToBack()
        Static Dim clicked = False
        If Not clicked Then
            FrmMain.AdditonalInfo(sender, e)
            loadDeviceInfoBTN.Text = "Add Device Info"
        Else
            FrmMain.WaistProcessorTime(500)

            If FrmMain.otherDeviceCTA2045Version.Text <> "" Or FrmMain.otherDeviceVendorID.Text <> "" Then
                CTAVersionTB.Text = FrmMain.otherDeviceCTA2045Version.Text
                VendorIDTB.Text = FrmMain.otherDeviceVendorID.Text
                DeviceNameTB.Text = FrmMain.otherDeviceDeviceType.Text
                ModelNumTB.Text = FrmMain.otherDeviceModelNumber.Text
                SerialNumberTB.Text = FrmMain.otherDeviceSerialNumber.Text
                FirmwareTB.Text = FrmMain.otherDeviceFirmwareMajor.Text & "." & FrmMain.otherDeviceFirmwareMinor.Text
                FirmwareDateTB.Text = FrmMain.otherDeviceFirmwareDate.Text
                MaxPayloadTB.Text = FrmMain.cdMaxPayloadSize.Text
                If FrmMain.CmbBaud.Text = "115200" Then
                    FormFactorTB.Text = "DC Form Factor"
                ElseIf FrmMain.CmbBaud.Text <> "" Then
                    FormFactorTB.Text = "AC Form Factor"
                End If
            End If
            loadDeviceInfoBTN.Text = DefaultDevInfoText
        End If
        clicked = Not clicked
        Me.BringToFront()
    End Sub

    Private Sub CommentRTB_GotFocus(sender As Object, e As EventArgs) Handles CommentRTB.GotFocus
        If CommentRTB.Text = DefaultCommentText Then CommentRTB.Clear()
    End Sub
End Class