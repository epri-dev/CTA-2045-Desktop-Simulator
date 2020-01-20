'EPRI CTA-2045 Appliance Plug Simulator
' ***************************************************************************
'  @brief Main code for CTA-2045 Simulator application.
'  @note Main code for Consumer Technology Association CTA-2045 simulator 
' 
'  Copyright © 2016 Electric Power Research Institute, Inc. All rights reserved.
'  
'  Redistribution And use In source And binary forms, with Or without 
'  modification, are permitted provided that the following conditions are met
'  · Redistributions of source code must retain the above copyright notice, this
'    list of conditions And the following disclaimer.
'  · Redistributions in binary form must reproduce the above copyright notice, 
'    this list Of conditions And the following disclaimer In the documentation 
'    And/Or other materials provided With the distribution.
'  · Neither the name of the EPRI nor the names of its contributors may be used 
'    to endorse Or promote products derived from this software without specific 
'    prior written permission.
' 
'  THIS SOFTWARE Is PROVIDED BY THE COPYRIGHT HOLDERS And CONTRIBUTORS "AS IS" 
'  And ANY EXPRESS Or IMPLIED WARRANTIES, INCLUDING, BUT Not LIMITED To, THE 
'  IMPLIED WARRANTIES Of MERCHANTABILITY And FITNESS For A PARTICULAR PURPOSE 
'  ARE DISCLAIMED. In NO Event SHALL EPRI BE LIABLE For ANY DIRECT, INDIRECT, 
'  INCIDENTAL, SPECIAL, EXEMPLARY, Or CONSEQUENTIAL DAMAGES (INCLUDING, BUT Not 
'  LIMITED To, PROCUREMENT Of SUBSTITUTE GOODS Or SERVICES; LOSS Of USE, DATA, 
'  Or PROFITS; Or BUSINESS INTERRUPTION) HOWEVER CAUSED And On ANY THEORY Of 
'  LIABILITY, WHETHER In CONTRACT, STRICT LIABILITY, Or TORT (INCLUDING 
'  NEGLIGENCE Or OTHERWISE) ARISING In ANY WAY OUT Of THE USE Of THIS SOFTWARE, 
'  EVEN If ADVISED Of THE POSSIBILITY Of SUCH DAMAGE.
'
'  Contact Information:
' 
'  Gary Aumaugher
'  Electric Power Research Institute
'  942 Corridor Park Blvd.
'  Knoxville, TN 37932
'  gaumaugher@epri.com
'
'  www.epri.com
' 
'  @author Gary Aumaugher, Electric Power Research Institute, gaumaugher@epri.com
'  @date 12/7/2016
'
'  @modified by Simon Boka, Electric Power Research Institute, sboka@epri.com
'  @date 10/8/2019
' ***************************************************************************

' ***************************************************************************
' Key routines:
' Serial Port receive               Private Sub SerialPort1_DataReceived()
' Serial Port transmit              Public Sub SendComData()
' 1 millisecond timer routine       Private Sub tmrProcessComm_Tick()
' Basic message processing          Private Sub processBasicDRAppMsg()
' Intermediate message processing   Private Sub ProcessIntDRAppMsg()
' Type Supported Query processing   Private Sub processTypeSupportedQuery()
' Processes Data Link Message       Private Sub processDataLinkMsg()
' Reset Communications              Private Sub reset_state()
' Scripting                         Private Function ReadScriptFile()
' ***************************************************************************

Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports
Imports System.IO

<Assembly: CLSCompliant(False)>

Public Class FrmMain
    Public Structure CommodityDef
        'Public responseCode As Byte
        Public supported As Boolean
        Public estimated As Boolean
        'Public subscriptReq As Boolean
        Public instRate As Long
        Public cumAmount As Long
        Public updateFreq As Integer
    End Structure

    Dim commodityArray(10) As CommodityDef       'This contains commodity data from this device
    Dim commodityArray2(10) As CommodityDef      'This contains received commodity data from other device
    Dim myPort As Array  'COM Ports detected on the system will be stored here
    Dim connectStatus As Boolean 'True if serial port is connected
    Dim receiveData As String
    Dim receiveBuffer(4102) As Byte
    Dim pendingLinkAck As Boolean        'false = no link ack/nak pending    true = link ack/nak pending
    Dim pendingAck As Byte = 0
    Dim CommStatus As Byte
    Dim TimeSyncEnable As Boolean
    Dim serialData As String
    Dim receiveIndex As Integer
    Dim MaxPayload As Byte
    Dim CustomerOverride As Boolean
    Dim priceID As Integer
    Dim commStatusText(3) As String
    Dim syncWarning As Boolean = False
    Dim commWarning As Boolean = False
    Dim overRideSet As Boolean = False
    Dim sendOverridePend As Boolean = False
    Dim wantBadSum As Boolean = False
    Dim useLongMsg As Boolean = False
    Dim useShortMsg As Boolean = False
    Dim forceNak As Boolean = False
    Dim gridGuideFirstPass As Boolean = True
    Dim changeBaudSecondPass As Boolean = True
    Dim NewBaud As Long
    Dim AwaitingBaudChange As Boolean = False
    Dim CurrentBaudIndex As Integer
    Dim NextBaudText As String
    Dim file As System.IO.StreamWriter
    Dim tempByte As Byte
    Dim cea2045version(2) As Byte
    Dim vendorID(2) As Byte
    Dim deviceType(2) As Byte
    Dim supportedMsgTypeOD(6, 2) As Byte
    Dim deviceRevision(2) As Byte
    Dim modelNumber(16) As Byte
    Dim serialNumber(16) As Byte
    Dim firmwareYear As Byte
    Dim firmwareMonth As Byte
    Dim firmwareDay As Byte
    Dim cea2045VersionOK As Boolean
    Dim deviceTypeOK As Boolean
    Dim modelNumberOK As Boolean
    Dim serialNumberOK As Boolean
    Dim firmwareDateOK As Boolean
    Dim passedReceivedBufferLength As Integer
    Dim startCycleEventID As UInt32
    Dim startCycleDuration As UInt32
    Dim startCycleDuty As UInt32
    Dim startCycleStartRandom As UInt32
    Dim startCycleEndRandom As UInt32
    Dim stopCycleEventID As UInt32
    Dim stopCycleEndRandom As UInt32
    Dim pendingStartAutoCyclingAck As Boolean = False
    Dim pendingStopAutoCyclingAck As Boolean = False
    Dim currentTempOffset As UInt32
    Dim tempRxPtr As Integer
    Dim pendingAppAckTime As Long
    Dim tempRxBuff(4102) As Byte
    Dim scriptFileReader As System.IO.StreamReader
    Dim Ex_sender As Object
    Dim Ex_e As EventArgs
    Dim nextScriptTime As Date
    Dim nextScriptTestTime As Date
    Dim testScriptLine As Integer
    Dim logFileBuffer As String
    Dim logBusy As Boolean
    Dim lastReceivedMsg(1024) As Byte
    Dim lastReceivedMsgSize As Integer
    Dim logBuffer As String
    Dim haltOnFail As Boolean
    Dim expectingResponse As Boolean        'expecting a full >=8 byte message response, as opposed to just a link ack
    Dim ucmCustomerOverride As Boolean      'True if the ucm knows sgd is in customer override
    Dim scriptPassed As Integer
    Dim preGuidanceOpState As Integer       'Stores previous opstate for when neutral guidance is recieved
    Dim commStatusTimeoutTime As Integer    'Represents number of seconds until timer times out
    Dim shedEventTime As Long
    Dim preShedOpState As Integer
    Dim previousCommand(1024) As Byte       'Holds previous command in case of comm failure
    Dim previousCommandSize As Integer
    Dim previousCommandComment As String
    Dim numCommandsResent As Integer        'used to count how many times a single command is resent
    Dim bitrate As Single
    Dim msgReceiveTime As System.DateTime
    Dim rxMsgStartTime As System.DateTime
    Dim pendingAckTime As System.DateTime
    Dim MaxPayloadSize As Integer           'This device max payload size
    Dim MaxPayloadSizeCd As Integer         'Connected device max payload size
    Dim rxMsgOverflow As Boolean            'Set to true if message received is larger than receive buffer
    Dim rxMsgOversize As Boolean            'Set to true if message received is larger than connected device max message size
    Dim messageCounter As Integer           'Debugging for lockup up after hours of operation
    Dim realDeviceData(1440) As Integer     'Data values from file for real device SGD simulation
    Dim gridMode As String
    Dim preference(256) As Byte             'Preference value by type
    Dim actStatus(256) As Byte              'Activation status by index
    Public testHeaderSaveFile As String
    Dim ignoreOverrideChange As Boolean

    Delegate Sub SetTextCallback(ByVal [text] As String)
    Delegate Sub SetTextCallback2(ByVal byteString As String, ByVal engString As String) 'Added to prevent threading errors during receiveing of data
    Delegate Sub SetTextCallback3(ByRef text As String) 'Added to prevent threading errors during receiveing of data

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim tempstr As String

        Try
            'When our form loads, auto detect all serial ports in the system and populate the cmbPort Combo box.
            myPort = IO.Ports.SerialPort.GetPortNames() 'Get all com ports available
            i = 0
            For Each tempstr In myPort
                i += 1
            Next
            If i = 0 Then ' TODO : Evaluate this section  
                MsgBox("No serial ports were found. Please connect a CTA 2045 Simulator cable before executing the application.")
                Me.Close()
            End If
            CmbBaud.Items.Add(9600)      'Populate the cmbBaud Combo box to common baud rates used
            CmbBaud.Items.Add(19200)
            CmbBaud.Items.Add(38400)
            CmbBaud.Items.Add(57600)
            CmbBaud.Items.Add(115200)
            CmbBaud.Items.Add(230400)
            CmbBaud.Items.Add(460800)
            CmbBaud.Items.Add(921600)
            CmbBaud.Items.Add(1843200)
            CmbBaud.Items.Add(3686400)
            'CmbBaud.SelectedIndex = 1

            For i = 0 To UBound(myPort)
                CmbPort.Items.Add(myPort(i))
            Next
            CmbPort.Text = CmbPort.Items.Item(0)    'Set cmbPort text to the first COM port detected
            changeBaudSecondPass = True
            CmbBaud.Text = CmbBaud.Items.Item(1)    'Set cmbBaud text to the second Baud rate on the list

            btnDisconnect.Enabled = False           'Initially Disconnect Button is Disabled
            connectStatus = False                   'Set connect status to false
            pendingLinkAck = False                          'Set the expected Ack to none
            pendingAck = 0                          'Set the expected Ack to none
            serialData = ""                         'Set the serialData to an empty string
            disableLogFile.Checked = False          'Set the simulator to write to log file by default
            receiveIndex = 0
            CommStatus = 0
            cmbCommStatus.SelectedIndex = 1
            cmbGridGuide.SelectedIndex = 1
            cbActResponse.SelectedIndex = 0
            commStatusText(0) = "Lost Connection"
            commStatusText(1) = "Good Connection"
            commStatusText(2) = "Poor Connection"
            TimeSyncEnable = False
            btnTimeSyncOff.Enabled = False
            btnTimeSyncOn.Enabled = True
            ucmTabControl.Visible = False
            sgdTabControl.Visible = False
            gbErrors.Visible = True
            grpChangeBaud.Visible = True
            gbReqPowerLevel.Visible = True
            gbQuery.Visible = True
            presentPriceGroup.Visible = True
            nextPeriodPriceGroup.Visible = True
            timeRemainingGroup.Visible = True
            grpGridGuide.Visible = True
            gbCommStatus.Visible = True
            gbTimeSync.Visible = True
            grpOpState.Visible = True
            grpSGDConfig.Visible = True
            commonCommandsTabControl.Visible = True
            firmwareMajorMinorSupportedCheckbox.Checked = True
            modelNumberTextBox.Enabled = True
            modelNumberSupportedCheckbox.Checked = True
            serialNumberSupportedCheckbox.Checked = True
            serialNumberTextBox.Enabled = True
            firmwareDayComboBox.Enabled = True
            firmwareMonthComboBox.Enabled = True
            firmwareYearComboBox.Enabled = True
            MaxPayload = 0
            startCycleEventID = 0
            startCycleDuration = 0
            startCycleDuty = 0
            startCycleStartRandom = 0
            startCycleEndRandom = 0
            stopCycleEventID = 0
            stopCycleEndRandom = 0
            currentTempOffset = 0
            tempRxPtr = 0
            rxMsgStartTime = Nothing
            nextScriptTime = New DateTime(1970, 1, 1)
            nextScriptTestTime = New DateTime(1970, 1, 1)
            logFileBuffer = ""
            pbManCont.Enabled = False
            pbManCont.Visible = False
            pbManualPass.Visible = False
            pbManualFail.Visible = False
            scriptFeedBox.Text = ""
            OpStateBox.SelectedIndex = 0
            logBuffer = ""
            tmrProcessComm.Enabled = True
            tMAValBox.Value = 40
            tARValBox.Value = 100
            tRAValBox.Value = 40
            tIMValBox.Value = 100
            tMLValBox.Value = 500
            TimingTab.Visible = True
            expectingResponse = False
            lbCommodityCode.SelectedIndex = 0
            ucmCustomerOverride = False
            currentStategb.Visible = True
            scriptPassed = 0
            realSGDCritPeakResponse.SelectedIndex = 0
            realSGDShedResponse.SelectedIndex = 0
            internalClockSupportedcb.Checked = True
            realUCMTrasmissionIntervalBox.Value = 300
            realUCMCommStatusBox.SelectedIndex = 0
            realDeviceIgnoreMaxPayloadCheckBox.Checked = True
            realUCMFunctionsGroup.Visible = False
            realSGDFunctionsGroup.Visible = False
            realDeviceIgnoreMaxPayloadCheckBox.Checked = True
            realDeviceCommandRetrycb.Checked = False
            realUCMTrasmissionIntervalBox.Value = 60
            realUCMCommStatusBox.SelectedIndex = 0
            internalClockSupportedcb.Checked = False
            realSGDShedResponse.SelectedIndex = 0
            realSGDEndShedResponse.SelectedIndex = 0
            realSGDCritPeakResponse.SelectedIndex = 0
            realSGDLoadUpResponse.SelectedIndex = 0
            realSGDEmergencyResponse.SelectedIndex = 0
            realSGDGoodTimeResponse.SelectedIndex = 0
            realSGDBadTimeResponse.SelectedIndex = 0
            realSGDNeutralResponse.SelectedIndex = 0
            realSGDNoCommTimeoutValBox.Value = 300
            preGuidanceOpState = 0
            autoCommStatusTimer.Interval = 10000         'set interval to 10 second
            commStatusTimoutTmr.Interval = 1000
            preShedOpState = 0
            commStatusTimeoutTime = realSGDNoCommTimeoutValBox.Value
            cbVerboseLog.Checked = True
            cbAutoStartup.Checked = True
            badOpcode1valbox.Value = &H89
            badOpcode2valbox.Value = &H89
            badOpcode1valbox.Enabled = False
            badOpcode2valbox.Enabled = False
            customLength1ValBox.Enabled = False
            customLength2ValBox.Enabled = False
            customMsgType1ValBox.Enabled = False
            customMsgType2ValBox.Enabled = False
            bitrate = CmbBaud.Text
            cbProtocolPT.SelectedIndex = 8
            rbMaxPayload14.Checked = True
            MaxPayloadSize = 4096
            MaxPayloadSizeCd = 2
            rxMsgOverflow = False
            rxMsgOversize = False
            gridMode = "Normal"
            lbCommodityCode1.SelectedItem() = lbCommodityCode1.Items.Item(0)
            testHeaderSaveFile = ""
            pendEventTypeCb.SelectedIndex = 1
            tbPendEventTime.Text = "0"
            tbPendEventType.Text = "End Shed/Run Normal"
            cbRebootType.SelectedIndex = 0
            tbCEA2045Version.Text = "0"
            pbGetEnergyPrice.Visible = False
            dtpExpTime.Value.ToFileTimeUtc()
            For i = 0 To 255
                preference(i) = 0
            Next
            For i = 0 To 255
                actStatus(i) = 0
            Next
            ignoreOverrideChange = False
            cbInterRespCode.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub frmMain_Load: " & ex.Message)
        End Try

    End Sub

    Private Sub BtnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Dim tmpstr As String

        Try
            cdMaxPayloadSize.Text = MaxPayloadSizeCd
            SerialPort1.PortName = CmbPort.Text         'Set SerialPort1 to the selected COM port at startup
            SerialPort1.BaudRate = CmbBaud.Text         'Set Baud rate to the selected value on

            'Other Serial Port Property
            SerialPort1.Parity = IO.Ports.Parity.None
            SerialPort1.StopBits = IO.Ports.StopBits.One
            SerialPort1.DataBits = 8            'Open our serial port
            SerialPort1.Open()

            btnConnect.Enabled = False          'Disable Connect button
            btnDisconnect.Enabled = True        'and Enable Disconnect button
            connectStatus = True                'Set connect status to true
            CmbPort.Enabled = False
            CmbBaud.Enabled = False
            If rbMode1.Checked = True Then
                ucmTabControl.Visible = True     'We are in UCM - controller mode
                realSGDFunctionsGroup.Visible = False
                realUCMFunctionsGroup.Visible = True
                sgdTabControl.Visible = False
                commonCommandsTabControl.Visible = True
                If tbLogFile.Text = "" Then
                    'Names the default log file
                    tbLogFile.Text = Directory.GetCurrentDirectory() & "\ucmlog.csv"
                End If
                PopulateDeviceInfo(0)
                pbGetEnergyPrice.Visible = False
                pbSetEnergyPrice.Visible = True
            Else
                ucmTabControl.Visible = False    'We are in SGD - Appliance mode
                sgdTabControl.Visible = True
                realUCMFunctionsGroup.Visible = False
                realSGDFunctionsGroup.Visible = True
                commonCommandsTabControl.Visible = True
                'remove extra commodity features in sgd mode
                cdCommodityGb.Visible = False
                If tbLogFile.Text = "" Then
                    'Names the default log file
                    tbLogFile.Text = Directory.GetCurrentDirectory() & "\sgdlog.csv"
                End If
                PopulateDeviceInfo(1)
                pbGetEnergyPrice.Visible = True
                pbSetEnergyPrice.Visible = False
            End If

            'Disables UCM/SGD radio buttons
            rbMode1.Enabled = False
            rbMode2.Enabled = False
            pbCommRefresh.Enabled = False
            'logFile.Enabled = False
            pbExecuteScript.Enabled = True
            testScriptbtn.Enabled = True
            AddHeaderBtn.Enabled = True
            GenReportBtn.Enabled = True

            'Assumes no entries have been made to device data, and they must be re-entered
            cea2045VersionOK = False
            deviceTypeOK = False

            'Copies selected header file to log if selected
            If testHeaderSaveFile <> "" Then
                My.Computer.FileSystem.CopyFile(testHeaderSaveFile, tbLogFile.Text, True)
            End If

            'Adds blank lines, time, and header to log file to signify the starting of the simulator
            tmpstr = ControlChars.CrLf
            tmpstr &= DateDiff("s", #1/1/2000#, DateTime.Now) & DateTime.Now.ToString(".fff") & ", "
            tmpstr &= (((Convert.ToDecimal(DateDiff("s", #1/1/2000#, DateTime.Now))) / 86400) + 36526).ToString & ","
            tmpstr &= "Simulator v18.12.24 is starting as "
            If rbMode1.Checked = True Then
                tmpstr &= "UCM"
            Else
                tmpstr &= "SGD"
            End If
            tmpstr &= ",UCM Sent:,SGD Sent:"
            SendToLog("", tmpstr)
            bitrate = CmbBaud.Text

            CbAutoStartup_CheckedChanged(sender, e)

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub btnConnect_Click: " & ex.Message)
        End Try

    End Sub

    Private Sub BtnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        Try
            SerialPort1.Close()             'Close our Serial Port
            btnConnect.Enabled = True
            btnDisconnect.Enabled = False
            CmbPort.Enabled = True
            CmbBaud.Enabled = True
            connectStatus = False           'Set connect status to false
            ucmTabControl.Visible = False
            sgdTabControl.Visible = False
            realSGDFunctionsGroup.Visible = False
            realUCMFunctionsGroup.Visible = False
            commonCommandsTabControl.Visible = False

            'Disables UCM/SGD radio buttons
            rbMode1.Enabled = True
            rbMode2.Enabled = True
            pbCommRefresh.Enabled = True
            pbExecuteScript.Enabled = False
            testScriptbtn.Enabled = False
            cbResponseSim.Checked = False
            AddHeaderBtn.Enabled = False
            GenReportBtn.Enabled = False

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub btnDisconnect_Click: " & ex.Message)
        End Try

    End Sub

    Private Function CheckSupported(ByVal msgType1 As Byte, ByVal msgType2 As Byte)
        Dim msgTypeAsString As String

        Try
            'Creates a string out of the bytes
            msgTypeAsString = "0x" & Conversion.Hex(msgType1) & " 0x" & Conversion.Hex(msgType2)

            'Checks to see if the message type is on the list of supported mesage types
            'At the current time, buffer limit size is not really a limit for this simulator, however, according to the CTA2045 spec sheet, real devices responding positively
            'to this type of query also acknowledge that the message size associated with the queried message type is also supported
            If supportedMsgTypeList.Items.Contains(msgTypeAsString) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Function CheckSupported: " & ex.Message)
            Return False
        End Try

    End Function

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        'Buffer received data until a complete message is received
        Dim bytes As Integer
        Dim i As Integer
        Dim msgComplete As Boolean

        msgComplete = False
        If tempRxPtr = 0 Then
            rxMsgStartTime = DateTime.Now
            rxMsgOverflow = False
            rxMsgOversize = False
        End If

        bytes = SerialPort1.BytesToRead
        'create a byte array to hold the awaiting data
        Dim comBuffer As Byte() = New Byte(bytes - 1) {}
        SerialPort1.Read(comBuffer, 0, bytes)       'Read the data and store it in comBuffer

        'Set overflow flag if received message is larger than connected device message size
        If tempRxPtr + bytes > (MaxPayloadSizeCd + 6) Then
            rxMsgOversize = True
        End If
        'Display message up to maximum buffer size
        If tempRxPtr + bytes < 4102 Then
            For i = 0 To bytes - 1          'Add the new data received to the end of the receiveBuffer
                tempRxBuff(i + tempRxPtr) = comBuffer(i)
            Next
            tempRxPtr += bytes
        Else
            'Message will overrun the buffer so it is probably inavlid junk
            For i = 0 To (4101 - tempRxPtr)          'Add the new data received to the end of the receiveBuffer
                tempRxBuff(i + tempRxPtr) = comBuffer(i)
            Next
            tempRxPtr = 4102
            msgComplete = True
            rxMsgOverflow = True
        End If

        'Check to see if message is complete
        Select Case tempRxBuff(0)
            Case &H6
                If tempRxPtr > 1 Then
                    msgComplete = True
                End If
            Case &H15
                If tempRxPtr > 1 Then
                    msgComplete = True
                End If
            Case &H8
                If (tempRxPtr > 3) And (tempRxPtr >= ((tempRxBuff(2) * 256) + tempRxBuff(3) + 6)) Then
                    msgComplete = True
                End If
            Case &H9
                If (tempRxPtr > 3) And (tempRxPtr >= ((tempRxBuff(2) * 256) + tempRxBuff(3) + 6)) Then
                    msgComplete = True
                End If
            Case Else
                'This is not valid data so pass it on for display
                If tempRxPtr > 0 Then
                    msgComplete = True
                End If
        End Select

        'Transfer message to recieve buffer if complete
        If msgComplete = True Then
            msgReceiveTime = DateTime.Now
            For i = 0 To (tempRxPtr - 1)          'Add the new data received to the end of the receiveBuffer
                receiveBuffer(i) = tempRxBuff(i)
                lastReceivedMsg(i) = tempRxBuff(i)
            Next
            lastReceivedMsgSize = i
            receiveIndex = tempRxPtr
            tempRxPtr = 0
            rxMsgStartTime = Nothing
            'messageComplete = True
        End If
    End Sub

    Private Sub ReceivedText(ByVal byteString As String, ByVal engString As String)
        Try
            'compares the ID of the creating Thread to the ID of the calling Thread
            If Me.rtbReceived.InvokeRequired Then
                Dim x As New SetTextCallback2(AddressOf ReceivedText)
                Me.Invoke(x, New Object() {(Text)})
            Else
                If byteString <> "" Then
                    Me.rtbReceived.Text &= byteString & ControlChars.CrLf
                    If cbVerboseLog.Checked = True And engString <> "" Then
                        Me.rtbReceived.Text &= engString & ControlChars.CrLf
                    End If
                Else
                    Me.rtbReceived.Text &= engString & ControlChars.CrLf
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub ReceivedText: " & ex.Message)
        End Try
    End Sub

    Private Sub CmbBaudText(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        Try

            If Me.CmbBaud.InvokeRequired Then
                Dim x As New SetTextCallback(AddressOf CmbBaudText)
                Me.Invoke(x, New Object() {(text)})
            Else
                Me.CmbBaud.Text = [text]
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub cmbBaudText: " & ex.Message)
        End Try
    End Sub

    Private Sub CmbPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPort.SelectedIndexChanged
        'Dim i As Integer

        Try
            If SerialPort1.IsOpen = False Then
                SerialPort1.PortName = CmbPort.Text
            Else                                        'pop a message box to user if he is changing ports without disconnecting first.
                MsgBox("Please disconnect before attempting to change comm port", vbCritical)
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub cmbPort_SelectedIndexChanged: " & ex.Message)
        End Try
    End Sub

    'Sends writes array of bytes dataout() to the comm port
    'comment should be the humman readable translation of what the message is/means
    Public Sub SendComData(dataout() As Byte, c As Integer, ByVal comment As String, ByVal pendLinkAck As Boolean)
        Dim count As Integer
        Dim dispString As String
        Dim supported As Boolean
        Dim exempt As Boolean

        count = c

        Try
            receiveData = ""        'Empty the receive buffer
            dispString = ""

            If connectStatus = False Then
                MsgBox("Please Open COM Port before attempting to send")
                Exit Sub
            End If

            If comment = "Raw Message" Then
                'This is a Pass Through that does not need a check sum added
                SerialPort1.Write(dataout, 0, count) 'Write the string to the serial port as bytes
                dispString &= ByteToHexString(dataout, "Sent", count)    'Display the received data in the text box
                SendToLog(dispString, "Sent Raw Pass Through message")
                ReceivedText(dispString, "Sent Raw Pass Through message")
            ElseIf count > 2 Then
                'This is a normal message rather than link ack or nak
                exempt = False
                If (dataout(2) = 0 And dataout(3) = 0) Then
                    'This is a message type supported request
                    exempt = True
                Else
                    If ((dataout(0) = 8) And (dataout(1) = 1)) Then
                        'This is a basic message
                        exempt = True
                    End If
                End If
                If exempt = False Then
                    'Check to see if this message type is supported
                    supported = False
                    For i = 0 To 5
                        If supportedMsgTypeOD(i, 0) = dataout(0) And supportedMsgTypeOD(i, 1) = dataout(1) Then
                            'This message type is in the list
                            supported = True
                            i = 5
                        Else
                            If i = 5 Then
                                'This message type is not in the list
                                If cbResponseSim.Checked = True Then
                                    MsgBox("Do not send a message type that has not been confirmed to be supported")
                                    Reset_state()
                                    Exit Sub
                                Else
                                    SendToLog(dispString, "Do not send a message type that has not been confirmed to be supported")
                                    ReceivedText(dispString, "Do not send a message type that has not been confirmed to be supported")
                                End If
                            End If
                        End If
                    Next i
                End If

                If badOpcode1cb.Checked = True Then
                    dataout(4) = badOpcode1valbox.Value     'Put a custom/invalid opcode in the 5th byte of the message
                End If
                If badOpcode2cb.Checked = True Then
                    dataout(5) = badOpcode2valbox.Value     'Put a custom/invalid opcode in the 6th byte of the message
                End If
                If customLength1cb.Checked = True Then
                    dataout(2) = customLength1ValBox.Value
                End If
                If customLength2cb.Checked = True Then
                    dataout(3) = customLength2ValBox.Value
                End If
                If customMsgType1cb.Checked = True Then
                    dataout(0) = customMsgType1ValBox.Value
                End If
                If customMsgType2cb.Checked = True Then
                    dataout(1) = customMsgType2ValBox.Value
                End If
                CalcChksum(dataout, (count))    'attach Checksum
                If wantBadSum = True Then
                    dataout(count) = dataout(count) + 3     'Put an error in the check sum
                End If

                'Check if message is too large to transmit in 500ms at the current baud rate
                If (count * 8000) / bitrate > tMLValBox.Value Then
                    MsgBox("Message too long to trasmit in " & tMLValBox.Value & "ms at the current baud rate!")
                    Reset_state()
                    Exit Sub
                End If

                'Check if message is larger than the connected device max message size, abort
                If MaxPayloadSizeCd < (count - 4) Then
                    If cbResponseSim.Checked = True Then
                        ReceivedText("", "Simulator tried to send message bigger than connected device max payload")
                        Reset_state()
                        Exit Sub
                    Else
                        ReceivedText("", "Simulator sending message bigger than connected device max payload")
                    End If
                End If

                If useLongMsg = True Then
                    dataout(count + 2) = &H19
                    count += 1
                    SerialPort1.Write(dataout, 0, (count + 2)) 'Write the string plus 1 byte to the serial port as bytes
                ElseIf useShortMsg = True Then
                    count -= 1
                    SerialPort1.Write(dataout, 0, (count + 2)) 'Write the string minus 1 byte to the serial port as bytes
                Else
                    SerialPort1.Write(dataout, 0, (count + 2)) 'Write the string to the serial port as bytes
                    previousCommand = dataout                  'Stores command in case it must be resent
                    previousCommandSize = count
                    previousCommandComment = comment

                End If

                dispString &= ByteToHexString(dataout, "Sent", (count + 2))    'Display the sent data in the text box

                SendToLog(dispString, comment)
                ReceivedText(dispString, comment)
                If pendLinkAck = True Then
                    pendingAckTime = DateTime.Now
                End If

            Else
                'This is a Link Ack or Nack
                SerialPort1.Write(dataout, 0, count) 'Write the string to the serial port as bytes
                dispString &= ByteToHexString(dataout, "Sent", count)    'Display the received data in the text box
                If dataout(0) = &H6 Then
                    SendToLog(dispString, "Sent Link Ack")
                    ReceivedText(dispString, "Sent Link Ack")
                Else
                    SendToLog(dispString, "Sent Link Nak")
                    ReceivedText(dispString, "Sent Link Nak")
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub SendComData: " & ex.Message)
        End Try
    End Sub

    'Processes information going to the log file
    'bytestring is in format datestamp recieve/send bytes
    'engString is a comment that should describe what the bytes mean
    Private Sub SendToLog(ByVal byteString As String, ByVal engString As String)
        Dim tmp() As String
        Dim tempstring As String

        tempstring = ""

        If disableLogFile.Checked = False Then
            Try

                'If bytestring is included
                If byteString <> "" Then
                    'Split the bytestring for parsing
                    tmp = Split(byteString)

                    'Adds time to logfile buffer
                    tempstring &= tmp(0) & ","

                    'Adds human readable time to logfile buffer
                    tempstring &= (((Convert.ToDecimal(tmp(0))) / 86400) + 36526).ToString & ","

                    'Adds send/recieve to logfile buffer
                    tempstring &= tmp(1) & ","

                    'Adds Sender to logfile buffer
                    'UCM is first column, SGD second
                    If rbMode1.Checked = True Then
                        If tmp(1) = "Sent" Then
                            tempstring &= tmp(3) & ",,"
                        Else
                            tempstring &= "," & tmp(3) & ","
                        End If
                    Else
                        If tmp(1) = "Recv" Then
                            tempstring &= tmp(3) & ",,"
                        Else
                            tempstring &= "," & tmp(3) & ","
                        End If
                    End If

                    'If an English string is included
                    If cbVerboseLog.Checked = True And engString <> "" Then
                        tempstring &= engString
                    End If
                Else
                    tempstring &= engString
                End If

                'Adds new line to the end of buffer
                tempstring &= ControlChars.CrLf

                'Add complete line to the global buffer
                logFileBuffer &= tempstring

            Catch ex As Exception

            End Try
        End If

    End Sub


    Public Function PrintToLog(ByVal textstr As String) As Integer
        'Currently useless, replaced by sendToLog()
        Try
            If tbLogFile.Text <> "" And disableLogFile.Checked = False Then
                file = My.Computer.FileSystem.OpenTextFileWriter(tbLogFile.Text, True)
                If logBuffer.Length > 0 Then
                    file.Write(logBuffer)
                    logBuffer = ""
                End If
                file.Write(textstr)
                file.Close()
            End If
            PrintToLog = 0
        Catch ex As Exception
            PrintToLog = -1
        End Try
    End Function

    Public Function ByteToHexString(ByVal dataout() As Byte, ByVal direction As String, ByVal count As Integer) As String
        'Converts the Byte array sent or received to a Hex string for display or debugging
        'Timestamp and direction are appended to the return string
        Dim Now As DateTime = DateTime.Now
        Dim rtnString As String = ""
        Dim I As Integer
        Dim tempInt As Integer

        Try
            rtnString &= DateDiff("s", #1/1/2000#, Now) & Now.ToString(".fff") & " "
            rtnString &= (direction & "  ")
            For I = 0 To count - 1 Step 1
                tempInt = dataout(I)
                rtnString &= ("/0x" & tempInt.ToString("X"))
            Next I
            ByteToHexString = rtnString
        Catch ex As Exception
            MessageBox.Show("Error occured in Function ByteToHexString: " & ex.Message)
            ByteToHexString = rtnString
        End Try

    End Function

    Public Function HexToString(ByVal HexToStr As String) As String
        'Converts Hex values to String
        Dim strTemp As String
        Dim strReturn As String
        Dim I As Long

        Try
            strReturn = ""
            For I = 1 To Len(HexToStr) Step 3 'get two characters and skip the "/"
                strTemp = System.Convert.ToChar(Val("&H" & Mid$(HexToStr, I, 2)))
                strReturn = strReturn & strTemp
            Next I
            HexToString = strReturn
        Catch ex As Exception
            MessageBox.Show("Error occured in Function HexToString: " & ex.Message)
            HexToString = -1
        End Try
    End Function

    Public Sub CalcChksum(ByRef senddata() As Byte, ByVal chrCount As Integer)
        'Calculates the Fletcher Checksum (16-bit 1's complement) on chrCount number of bytes in the 
        'senddata array then modifies the array, appending the checksum to the consecutive 2 indexes.
        'Be sure array is dimensioned at least 2 larger than message.
        'Arguments: 
        'senddata() byte array, ByRef, contains message 
        'chrCount is number of bytes in the message not including the checksum
        Dim checksum1 As Int16 = 170     '0xaa
        Dim checksum2 As Int16 = 0
        Dim tempchar As Int16

        'Add more room for checksum if needed
        If senddata.Length Mod chrCount < 2 Then
            Array.Resize(senddata, chrCount + 2)
        End If

        Try
            For I = 0 To (chrCount - 1) Step 1
                checksum1 += senddata(I)
                checksum1 = checksum1 Mod 255
                checksum2 += checksum1
                checksum2 = checksum2 Mod 255
            Next I
            tempchar = 255 - ((checksum1 + checksum2) Mod 255)

            senddata(chrCount) = tempchar       'add 16 bit checksum
            senddata(chrCount + 1) = 255 - ((checksum1 + tempchar) Mod 255)
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub CalcChksum: " & ex.Message)
        End Try
    End Sub

    Public Function VerifyChecksum(ByVal receivedData() As Byte, ByVal chrCount As Integer) As Boolean
        'Calculates the Fletcher Checksum (16-bit 1's complement) on chrCount number of bytes in the 
        'receivedData array then compares that to the checksum stored in the following 2 indexes.
        'Arguments: 
        'receivedData() byte array contains message and 2-byte checksum
        'chrCount is number of bytes in the message not including the checksum
        'Returns True if checksum is correct else returns False
        Dim checksum1 As Int16 = 170     '0xaa
        Dim checksum2 As Int16 = 0
        Dim tempchar, tempchar2 As Int16

        Try
            If (receivedData(0) = 8 And (receivedData(1) > 0 And receivedData(1) < 5)) Or (receivedData(0) = 9) Then
                For I = 0 To (chrCount - 1) Step 1
                    checksum1 += receivedData(I)
                    checksum1 = checksum1 Mod 255
                    checksum2 += checksum1
                    checksum2 = checksum2 Mod 255
                Next I
                tempchar = 255 - ((checksum1 + checksum2) Mod 255)
                tempchar2 = 255 - ((checksum1 + tempchar) Mod 255)

                VerifyChecksum = False
                If (tempchar = receivedData(chrCount) And tempchar2 = receivedData(chrCount + 1)) Then
                    VerifyChecksum = True
                End If
            Else
                'Message is not valid
                VerifyChecksum = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Function verifyChecksum: " & ex.Message)
            VerifyChecksum = False
        End Try
    End Function

    Private Sub TbarPower_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarPower.Scroll
        Dim powerLevel As Single

        Try
            powerLevel = tbarPower.Value * 100.0 / 127.0
            tbPowerAP.Text = powerLevel.ToString("0.00")
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub tbarPower_Scroll: " & ex.Message)
        End Try
    End Sub

    Private Sub RbProduced_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbProduced.CheckedChanged
        Try
            If rbProduced.Checked = True Then
                rbAbsorbed.Checked = False
            Else
                rbAbsorbed.Checked = True
            End If

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub rbProduced_CheckedChanged: " & ex.Message)
        End Try
    End Sub

    Private Sub RbAbsorbed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAbsorbed.CheckedChanged
        Try
            If rbAbsorbed.Checked = True Then
                rbProduced.Checked = False
            Else
                rbProduced.Checked = True
            End If

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub rbAbsorbed_CheckedChanged: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnTimeSyncOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimeSyncOn.Click
        Dim tempTime As Long

        Try
            TimeSyncEnable = True
            syncWarning = True
            tempTime = (Minute(Now) * 60 + Second(Now)) * 1000
            tempTime = 3600000 - tempTime - 2000
            If tempTime > 1 Then
                tmrTimeSync.Interval = tempTime
            Else
                tmrTimeSync.Interval = 1
            End If
            tmrTimeSync.Enabled = True
            btnTimeSyncOff.Enabled = True
            btnTimeSyncOn.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub btnTimeSyncOn_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnTimeSyncOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimeSyncOff.Click
        Try
            TimeSyncEnable = False
            btnTimeSyncOff.Enabled = False
            btnTimeSyncOn.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub btnTimeSyncOff_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnClearDebug_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDebug.Click
        Try
            rtbReceived.Text = ""
            scriptFeedBox.Text = ""
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub btnClearDebug_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub TrkShedDur_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkShedDur.Scroll
        Dim duration As Long
        Dim durHours As Byte
        Dim durMin As Byte
        Dim durSec As Byte

        If trkShedDur.Value = 0 Then
            txtShedDur.Text = "Unknown"
        ElseIf trkShedDur.Value = &HFF Then
            txtShedDur.Text = ("> Maximum")
        Else
            duration = (trkShedDur.Value * trkShedDur.Value) * 2
            durHours = duration \ 3600
            durMin = (duration Mod 3600) \ 60
            durSec = duration Mod 60
            txtShedDur.Text = durHours.ToString("00") & ":" & durMin.ToString("00") & ":" & durSec.ToString("00")
        End If
    End Sub

    Public Function ByteToDurationStr(ByVal byteDur As Byte)
        Dim duration As Long
        Dim durHours As Byte
        Dim durMin As Byte
        Dim durSec As Byte
        Dim tempInt As UInteger

        If byteDur = 0 Then
            ByteToDurationStr = "Unknown"
        ElseIf byteDur = &HFF Then
            ByteToDurationStr = ("> Maximum")
        Else
            tempInt = byteDur
            duration = (tempInt * tempInt) * 2
            durHours = duration \ 3600
            durMin = (duration Mod 3600) \ 60
            durSec = duration Mod 60
            ByteToDurationStr = durHours.ToString("00") & ":" & durMin.ToString("00") & ":" & durSec.ToString("00")
        End If
    End Function

    Public Function ByteToRelativePrice(ByVal bytePrice As Byte)
        Dim tempSingle As Single

        Try
            tempSingle = ((bytePrice - 1.0) * (bytePrice + 63.0)) / 8192
            ByteToRelativePrice = tempSingle.ToString("0.00")
        Catch ex As Exception
            MessageBox.Show("Error occured in Function byteToRelativePrice: " & ex.Message)
            ByteToRelativePrice = 0
        End Try
    End Function

    '=================================================================================================
    ' The following sections handle the UCM and SGD Basic commands initiated by button presses
    '=================================================================================================

    Private Sub BtnShedSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShedSend.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 1
        xmitBuffer(5) = trkShedDur.Value
        SendComData(xmitBuffer, 6, "Sent Shed Command", pendingLinkAck)
        expectingResponse = True
        If cbResponseSim.Checked = True And trkShedDur.Value <> 0 And trkShedDur.Value <> &HFF Then
            shedEventTimer.Enabled = True
            shedEventTime = (trkShedDur.Value * trkShedDur.Value) * 2
        End If

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(1)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True
    End Sub

    Private Sub BtnEndShed_Click(sender As System.Object, e As System.EventArgs) Handles btnEndShed.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 2
        xmitBuffer(5) = 0
        SendComData(xmitBuffer, 6, "Sent an End Shed/Run Normal Command", pendingLinkAck)
        shedEventTimer.Enabled = False

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(2)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True
    End Sub

    Private Sub BtnRPLAccept_Click(sender As System.Object, e As System.EventArgs) Handles btnRPLAccept.Click
        Dim xmitBuffer(8) As Byte
        Dim powerValue As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        powerValue = tbarPower.Value
        If rbProduced.Checked = True Then
            powerValue = powerValue + &H80
        End If
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 6
        xmitBuffer(5) = powerValue
        SendComData(xmitBuffer, 6, "Sent request for Power Level", pendingLinkAck)
        expectingResponse = True

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(6)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True
    End Sub

    Private Sub PresentPriceButton_Click(sender As Object, e As EventArgs) Handles presentPriceButton.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 7
        xmitBuffer(5) = presentPriceTrackBar.Value
        SendComData(xmitBuffer, 6, "Sent Present Price", pendingLinkAck)
        expectingResponse = True

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(7)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True
    End Sub

    Private Sub NextPeriodPriceButton_Click(sender As Object, e As EventArgs) Handles nextPeriodPriceButton.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        'Set Time Remaining in Present Price period
        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 8
        xmitBuffer(5) = nextPeriodTrackBar.Value
        SendComData(xmitBuffer, 6, "Sent Next Period Price", pendingLinkAck)
        expectingResponse = True

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(8)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True
    End Sub

    Private Sub TimeRemainingButton_Click(sender As Object, e As EventArgs) Handles timeRemainingButton.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        'Set Time Remaining in Present Price period
        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 9
        xmitBuffer(5) = timeRemainingTrackBar.Value
        SendComData(xmitBuffer, 6, "Sent Time Remaining", pendingLinkAck)
        expectingResponse = True

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(9)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True
    End Sub

    Private Sub CriticalPeakButton_Click(sender As Object, e As EventArgs) Handles criticalPeakButton.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = &HA
        xmitBuffer(5) = trkShedDur.Value
        SendComData(xmitBuffer, 6, "Sent Critical Peak Event", pendingLinkAck)
        expectingResponse = True
        If cbResponseSim.Checked = True And trkShedDur.Value <> 0 And trkShedDur.Value <> &HFF Then
            shedEventTimer.Enabled = True
            shedEventTime = (trkShedDur.Value * trkShedDur.Value) * 2
            loadUpEventTimer.Enabled = False
        End If

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(&HA)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True
    End Sub

    Private Sub GridEmergencyButton_Click(sender As Object, e As EventArgs) Handles gridEmergencyButton.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = &HB
        xmitBuffer(5) = trkShedDur.Value
        SendComData(xmitBuffer, 6, "Sent Grid Emergency Event Start", pendingLinkAck)
        expectingResponse = True
        If cbResponseSim.Checked = True And trkShedDur.Value <> 0 And trkShedDur.Value <> &HFF Then
            shedEventTimer.Enabled = True
            shedEventTime = (trkShedDur.Value * trkShedDur.Value) * 2
            loadUpEventTimer.Enabled = False
        End If

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(&HB)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True
    End Sub

    Private Sub SendGuidenceButton_Click(sender As Object, e As EventArgs) Handles sendGuidenceButton.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = &HC
        xmitBuffer(5) = cmbGridGuide.SelectedIndex
        SendComData(xmitBuffer, 6, "Sent Grid Guidance: " & cmbGridGuide.SelectedIndex, pendingLinkAck)
        expectingResponse = True

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(&HC)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True
    End Sub

    Private Sub SendCommStatus(ByVal status As Byte)
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = &HE
        xmitBuffer(5) = status
        SendComData(xmitBuffer, 6, "Sent Comm Status", pendingLinkAck)
        expectingResponse = True

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(&HE)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True
    End Sub

    Private Sub PbOpState_Click(sender As System.Object, e As System.EventArgs) Handles pbOpState.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = &H12
        xmitBuffer(5) = 0
        pendingLinkAck = True
        pendingAck = &H12  'Set the pendingAck
        SendComData(xmitBuffer, 6, "Sent Op State Query", pendingLinkAck)
        expectingResponse = True

        If GetLinkAck() = 0 Then
            'Wait for State Query Response
            rtnval = GetStateQueryResp()
        End If
        Reset_state()
        tmrProcessComm.Enabled = True
    End Sub

    Private Sub PbLoadUp_Click(sender As Object, e As EventArgs) Handles pbLoadUp.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = &H17
        xmitBuffer(5) = trkShedDur.Value
        SendComData(xmitBuffer, 6, "Sent Loadup Command", pendingLinkAck)
        expectingResponse = True
        If cbResponseSim.Checked = True And trkShedDur.Value <> 0 And trkShedDur.Value <> &HFF Then
            shedEventTimer.Enabled = True
            shedEventTime = (trkShedDur.Value * trkShedDur.Value) * 2
        End If

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(&H17)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True
    End Sub

    '=================================================================================================
    ' The following sections handle the Link commands initiated by button presses
    '=================================================================================================

    Private Sub MsgTypeQuery_Click(sender As Object, e As EventArgs) Handles msgTypeQuery.Click
        Dim xmitBuffer(6) As Byte
        Dim rtnval As Integer
        Dim dispString As String
        Dim msgType(2) As Byte
        Dim i As Integer
        Dim msgTypeAsString As String

        tmrProcessComm.Enabled = False
        'Makes sure queries are valid hex/1 byte values
        receiveIndex = 0
        xmitBuffer(0) = nudSupMsgQueryMSB.Value
        xmitBuffer(1) = nudSupMsgQueryLSB.Value
        xmitBuffer(2) = 0
        xmitBuffer(3) = 0
        msgType(0) = nudSupMsgQueryMSB.Value
        msgType(1) = nudSupMsgQueryLSB.Value
        SendComData(xmitBuffer, 4, "Sent Message Supported Query", pendingLinkAck)      'Append checksum and send message
        expectingResponse = True

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Message type is supported
            'Assume if the other device is asking then it supports this message type
            For i = 0 To 5
                If supportedMsgTypeOD(i, 0) = 0 Then
                    'This item is not in the list so add it
                    supportedMsgTypeOD(i, 0) = msgType(0)
                    supportedMsgTypeOD(i, 1) = msgType(1)
                    msgTypeAsString = "0x" & Convert.ToInt32(supportedMsgTypeOD(i, 0)).ToString("X") & " 0x" & Convert.ToInt32(supportedMsgTypeOD(i, 1)).ToString("X")
                    ODMsgTypeSup.Items.Insert(i, msgTypeAsString)
                    i = 5
                ElseIf (supportedMsgTypeOD(i, 0) = msgType(0) And supportedMsgTypeOD(i, 1) = msgType(1)) Then
                    'This message type is already in the list
                    i = 5
                End If
            Next i

            'Enable features dependant on what msg type the other device supports
            '____Nothing currently here, create functions to enable features as they are needed

            'Build msg to display
            dispString = "The other device supports messages of type: "
            dispString &= "0x" & Conversion.Hex(msgType(0)) & " 0x" & Conversion.Hex(msgType(1))
            ReceivedText("", dispString)
        ElseIf rtnval = -2 Then
            'Messagew type is NOT supported
            'Build msg to display
            dispString = "The other device does not support messages of type: "
            dispString &= "0x" & Conversion.Hex(msgType(0)) & " 0x" & Conversion.Hex(msgType(1))
            ReceivedText("", dispString)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True

    End Sub

    '=================================================================================================
    ' The following sections handle are the support subs for the basic, link and intermediate commands
    '=================================================================================================

    Public Function GetLinkAck() As Integer
        ' Returns 0 = Link Ack, -1 = timeout, -2 Link Nak
        Dim pendingTime As System.DateTime
        Dim rightNowTime As System.DateTime
        Dim deltaTime As System.TimeSpan
        Dim deltaMS As Integer
        Dim failedCommand As Boolean
        Dim dispString As String

        pendingTime = DateTime.Now
        failedCommand = False
        Do      'Wait for link Ack/Nak
            'If messageComplete = False Then
            If receiveIndex = 0 Then
                rightNowTime = DateTime.Now
                deltaTime = rightNowTime.Subtract(pendingTime)
                deltaMS = deltaTime.Seconds * 1000 + deltaTime.Milliseconds
                If deltaMS > 200 Then   '200ms is default - tie to box on screen
                    'Timed out waiting for link Ack/Nak
                    dispString = ByteToHexString(tempRxBuff, "Recv", tempRxPtr)    'Display the received data in the text box and log file
                    SendToLog(dispString, "Error - Timed out waiting for Link Ack/Nak-2")
                    ReceivedText(dispString, "Error - Timed out waiting for Link Ack/Nak-2")
                    Reset_state()
                    GetLinkAck = -1
                    Exit Do
                End If
            Else
                'Message has been received
                dispString = ""
                dispString = ByteToHexString(receiveBuffer, "Recv", receiveIndex)       'Display the received data in the text box and log file
                If receiveBuffer(0) = 6 And receiveBuffer(1) = 0 Then 'This is a link Ack
                    SendToLog(dispString, "Link Ack Received")
                    ReceivedText(dispString, "Link Ack Received")
                    GetLinkAck = 0
                ElseIf receiveBuffer(0) = &H15 And receiveIndex >= 2 Then 'This is a link Nack
                    GetLinkAck = -2
                    Select Case receiveBuffer(1)
                        Case 0
                            SendToLog(dispString, "Link Nak Received: 0x0 No Reason Given")
                            ReceivedText(dispString, "Link Nak Received: 0x0 No Reason Given")
                        Case 1  'This case should never occur. Simulator has no way of catching this error
                            SendToLog(dispString, "Link Nak Received: 0x1 Invalid Byte")
                            ReceivedText(dispString, "Link Nak Received: 0x1 Invalid Byte")
                        Case 2
                            SendToLog(dispString, "Link Nak Received: 0x2 Invalid Length")
                            ReceivedText(dispString, "Link Nak Received: 0x2 Invalid Length")
                        Case 3
                            SendToLog(dispString, "Link Nak Received: 0x3 Checksum Error")
                            ReceivedText(dispString, "Link Nak Received: 0x3 Checksum Error")
                        Case 4
                            SendToLog(dispString, "Link Nak Received: 0x4 Reserved")
                            ReceivedText(dispString, "Link Nak Received: 0x4 Reserved")
                        Case 5
                            SendToLog(dispString, "Link Nak Received: 0x5 Message Timeout")
                            ReceivedText(dispString, "Link Nak Received: 0x5 Message Timeout")
                        Case 6
                            SendToLog(dispString, "Link Nak Received: 0x6 Unsupported Message Type")
                            ReceivedText(dispString, "Link Nak Received: 0x6 Unsupported Message Type")
                        Case 7
                            SendToLog(dispString, "Link Nak Received: 0x7 Request Not Supported")
                            ReceivedText(dispString, "Link Nak Received: 0x7 Request Not Supported")
                        Case Else
                            SendToLog(dispString, "Unknown Link Nak Received: " & Conversion.Hex(receiveBuffer(1)))
                            ReceivedText(dispString, "Unknown Link Nak Received :" & Conversion.Hex(receiveBuffer(1)))
                    End Select
                Else
                    SendToLog(dispString, "Invalid response received")
                    ReceivedText(dispString, "Invalid response received")
                    GetLinkAck = 0
                End If
                Exit Do
            End If
        Loop
        receiveIndex = 0 'Remove linkAck from buffer

    End Function

    Public Function GetApplicationAck(ByVal AppAckID As Byte) As Integer
        ' Returns 0 = App Ack received, -1 = timeout, -2 Application Nak, -3 = Invalid message, -4 = wrong AppAckID
        Dim xmitBuffer(8) As Byte
        Dim pendingTime As System.DateTime
        Dim rightNowTime As System.DateTime
        Dim deltaTime As System.TimeSpan
        Dim deltaMS As Integer
        Dim failedCommand As Boolean
        Dim dispString As String

        pendingTime = DateTime.Now
        failedCommand = False
        Do      'Wait for application Ack/Nak
            If receiveIndex = 0 Then
                rightNowTime = DateTime.Now
                deltaTime = rightNowTime.Subtract(pendingTime)
                deltaMS = deltaTime.Seconds * 1000 + deltaTime.Milliseconds
                If deltaMS > 3000 Then   '3sec is default - tie to box on screen
                    'Timed out waiting for Application Ack/Nak
                    dispString = ByteToHexString(tempRxBuff, "Recv", tempRxPtr)    'Display the received data in the text box and log file
                    SendToLog(dispString, "Error - Timed out waiting for Application Ack/Nak - 1")
                    ReceivedText(dispString, "Error - Timed out waiting for Application Ack/Nak - 1")
                    Reset_state()
                    GetApplicationAck = -1
                    Exit Do
                End If
            Else
                'Message has been received
                dispString = ByteToHexString(receiveBuffer, "Recv", receiveIndex)       'Display the received data in the text box and log file
                If receiveIndex = 8 Then
                    If receiveBuffer(0) = 8 And receiveBuffer(1) = 1 And receiveBuffer(2) = 0 And receiveBuffer(3) = 2 And receiveBuffer(4) = 3 Then 'This is an application Ack
                        If receiveBuffer(5) = AppAckID Then
                            'This is the correct AppAckID
                            ReceivedText(dispString, "Recieved an Application Ack with code: " & Hex(receiveBuffer(5)))
                            SendToLog(dispString, "Recieved an Application Ack with code: " & Hex(receiveBuffer(5)))
                            GetApplicationAck = 0
                            SendLinkAck()
                        Else
                            ReceivedText(dispString, "Recieved an Application Ack with wrong code: " & Hex(receiveBuffer(5)))
                            SendToLog(dispString, "Recieved an Application Ack with wrong code: " & Hex(receiveBuffer(5)))
                            GetApplicationAck = -4
                            SendLinkNak(2)
                        End If
                    ElseIf receiveBuffer(0) = 8 And receiveBuffer(1) = 1 And receiveBuffer(2) = 0 And receiveBuffer(3) = 2 And receiveBuffer(4) = 4 Then 'This is an application Nak
                        Select Case receiveBuffer(5)
                            Case 0
                                ReceivedText(dispString, "Application NAK returned with reason: 0 -No Reason Specified")
                                SendToLog(dispString, "Application NAK returned with reason: 0 -No Reason Specified")
                            Case 1
                                ReceivedText(dispString, "Application NAK returned with reason: 1 -Opcode 1 not supported")
                                SendToLog(dispString, "Application NAK returned with reason: 1 -Opcode 1 not supported")
                            Case 2
                                ReceivedText(dispString, "Application NAK returned with reason: 2 -Opcode 2 invalid")
                                SendToLog(dispString, "Application NAK returned with reason: 2 -Opcode 2 invalid")
                            Case 3
                                ReceivedText(dispString, "Application NAK returned with reason: 3 -Busy")
                                SendToLog(dispString, "Application NAK returned with reason: 3 -Busy")
                            Case 4
                                ReceivedText(dispString, "Application NAK returned with reason: 4 -Length Invalid")
                                SendToLog(dispString, "Application NAK returned with reason: 4 -Length Invalid")
                            Case 5
                                ReceivedText(dispString, "Application NAK returned with reason: 5 -Customer Override is in effect")
                                SendToLog(dispString, "Application NAK returned with reason: 5 -Customer Override is in effect")
                        End Select
                        GetApplicationAck = -2
                        SendLinkAck()
                    Else 'Invalid message received
                        ReceivedText(dispString, "Invalid message returned")
                        SendToLog(dispString, "Invalid message returned")
                        GetApplicationAck = -3
                        SendLinkNak(0)
                    End If
                Else
                    SendToLog(dispString, "Wrong size message received for application Ack")
                    ReceivedText(dispString, "Wrong size message received for application Ack")
                    GetApplicationAck = -3
                    SendLinkNak(4)
                End If
                Exit Do
            End If
        Loop
        receiveIndex = 0 'Remove AppAck from buffer
        'Debug section to identify error
        messageCounter += 1
        If messageCounter > 60 Then
            btnClearDebug.PerformClick()
            messageCounter = 0
        End If
        'End debug section

        Return GetApplicationAck
    End Function

    Public Function GetStateQueryResp() As Integer
        ' Returns state value or -1 for timeout or -2 for invalid message
        Dim xmitBuffer(8) As Byte
        Dim pendingTime As System.DateTime
        Dim rightNowTime As System.DateTime
        Dim deltaTime As System.TimeSpan
        Dim deltaMS As Integer
        Dim failedCommand As Boolean
        Dim dispString As String

        pendingTime = DateTime.Now
        failedCommand = False
        Do      'Wait for state response
            If receiveIndex = 0 Then
                rightNowTime = DateTime.Now
                deltaTime = rightNowTime.Subtract(pendingTime)
                deltaMS = deltaTime.Seconds * 1000 + deltaTime.Milliseconds
                If deltaMS > 3000 Then   '3sec is default - tie to box on screen
                    'Timed out waiting for State Query Response
                    dispString = ByteToHexString(tempRxBuff, "Recv", tempRxPtr)    'Display the received data in the text box and log file
                    SendToLog(dispString, "Error - Timed out waiting for State Query Response")
                    ReceivedText(dispString, "Error - Timed out waiting for State Query Response")
                    Reset_state()
                    GetStateQueryResp = -1
                    Exit Do
                End If
            Else
                'Message has been received
                dispString = ByteToHexString(receiveBuffer, "Recv", receiveIndex)       'Display the received data in the text box and log file
                If receiveIndex = 8 Then
                    If receiveBuffer(0) = 8 And receiveBuffer(1) = 1 And receiveBuffer(2) = 0 And receiveBuffer(3) = 2 And receiveBuffer(4) = &H13 Then 'This is a State Query Response
                        GetStateQueryResp = receiveBuffer(5)
                        DetermineOpState(dispString)
                        SendLinkAck()
                    Else 'Invalid message received
                        ReceivedText(dispString, "Invalid message returned")
                        SendToLog(dispString, "Invalid message returned")
                        GetStateQueryResp = -2
                        SendLinkNak(2)
                    End If
                Else
                    SendToLog(dispString, "Wrong size message received for state query")
                    ReceivedText(dispString, "Wrong size message received for state query")
                    SendLinkNak(4)
                End If
                Exit Do
            End If
        Loop
        receiveIndex = 0 'Remove AppAck from buffer
        Return GetStateQueryResp

    End Function

    Private Sub DetermineOpState(dispString)

        If receiveBuffer(5) = 0 Then
            ReceivedText(dispString, "SGD Operating State is Idle Normal")
            SendToLog(dispString, "SGD Operating State is Idle Normal, Op State")
            currentStatetb.Text = "Idle Normal"
        ElseIf receiveBuffer(5) = 1 Then
            ReceivedText(dispString, "SGD Operating State is Running Normal")
            SendToLog(dispString, "SGD Operating State is Running Normal, Op State")
            currentStatetb.Text = "Running Normal"
        ElseIf receiveBuffer(5) = 2 Then
            ReceivedText(dispString, "SGD Operating State is Running Curtailed Grid")
            SendToLog(dispString, "SGD Operating State is Running Curtailed Grid, Op State")
            currentStatetb.Text = "Running Curtailed Grid"
        ElseIf receiveBuffer(5) = 3 Then
            ReceivedText(dispString, "SGD Operating State is Running Heightened Grid")
            SendToLog(dispString, "SGD Operating State is Running Heightened Grid, Op State")
            currentStatetb.Text = "Running Heightened Grid"
        ElseIf receiveBuffer(5) = 4 Then
            ReceivedText(dispString, "SGD Operating State is Idle Grid")
            SendToLog(dispString, "SGD Operating State is Idle Grid, Op State")
            currentStatetb.Text = "Idle Grid"
        ElseIf receiveBuffer(5) = 5 Then
            ReceivedText(dispString, "SGD Operating State is SGD Error Condition")
            SendToLog(dispString, "SGD Operating State is SGD Error Condition, Op State")
            currentStatetb.Text = "SGD Error Condition"
        ElseIf receiveBuffer(5) = 6 Then
            ReceivedText(dispString, "SGD Operating State is SGD Idle Heightened")
            SendToLog(dispString, "SGD Operating State is SGD Idle Heightened, Op State")
            currentStatetb.Text = "SGD Idle Heightened"
        ElseIf receiveBuffer(5) = 7 Then
            ReceivedText(dispString, "SGD Operating State is SGD Cycling On")
            SendToLog(dispString, "SGD Operating State is SGD Cycling On, Op State")
            currentStatetb.Text = "SGD Cycling On"
        ElseIf receiveBuffer(5) = 8 Then
            ReceivedText(dispString, "SGD Operating State is SGD Cycling Off")
            SendToLog(dispString, "SGD Operating State is SGD Cycling Off, Op State")
            currentStatetb.Text = "SGD Cycling Off"
        ElseIf receiveBuffer(5) = 9 Then
            ReceivedText(dispString, "SGD Operating State is SGD Variable Following")
            SendToLog(dispString, "SGD Operating State is SGD Variable Following, Op State")
            currentStatetb.Text = "SGD Variable Following"
        ElseIf receiveBuffer(5) = 10 Then
            ReceivedText(dispString, "SGD Operating State is SGD Variable Not Following")
            SendToLog(dispString, "SGD Operating State is SGD Variable Not Following, Op State")
            currentStatetb.Text = "SGD Variable Not Following"
        ElseIf receiveBuffer(5) = 11 Then
            ReceivedText(dispString, "SGD Operating State is SGD Idle Opted Out")
            SendToLog(dispString, "SGD Operating State is SGD Idle Opted Out, Op State")
            currentStatetb.Text = "SGD Idle Opted Out"
        ElseIf receiveBuffer(5) = 12 Then
            ReceivedText(dispString, "SGD Operating State is SGD Running Opted Out")
            SendToLog(dispString, "SGD Operating State is SGD Running Opted Out, Op State")
            currentStatetb.Text = "SGD Running Opted Out"
        End If

    End Sub

    'Sends an Ack signal after delay
    Private Sub SendLinkAck()
        Dim xmitBuffer(2) As Byte
        Dim targetMS As Integer

        If expectingResponse = True Then        'This is ack'ing a reply prompted by an earlier message
            targetMS = tRAValBox.Value - 10
        Else
            targetMS = tMAValBox.Value - 10
        End If
        PauseMS(targetMS)       'Wait before sending Ack
        expectingResponse = False
        If forceNak = True Then
            xmitBuffer(0) = &H15
            xmitBuffer(1) = nudNakRtn.Value
        Else
            xmitBuffer(0) = 6
            xmitBuffer(1) = 0
        End If
        pendingLinkAck = False  'Set the pendingLinkAck to nothing
        SendComData(xmitBuffer, 2, "", pendingLinkAck)

    End Sub

    'Sends an Nak signal after delay
    Private Sub SendLinkNak(errVal As Byte)
        Dim xmitBuffer(2) As Byte
        Dim targetMS As Integer

        If expectingResponse = True Then        'If this is ack'ing a reply prompted by an earlier message
            targetMS = tRAValBox.Value - 10
        Else
            targetMS = tMAValBox.Value - 10
        End If
        PauseMS(targetMS)       'Wait before sending Nak
        expectingResponse = False
        xmitBuffer(0) = &H15
        If forceNak = True Then
            xmitBuffer(1) = nudNakRtn.Value
        Else
            xmitBuffer(1) = errVal
        End If
        pendingLinkAck = False  'Set the pendingLinkAck to nothing
        SendComData(xmitBuffer, 2, "", pendingLinkAck)
        Reset_state()

    End Sub

    Private Sub TmrTimeSync_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimeSync.Tick
        Dim xmitBuffer(8) As Byte
        Dim tempHour As Integer
        Dim tempDay As Integer
        Dim tempTime As Long

        Try
            If rbMode1.Checked = True Then  'Only send time sync if you are the UCM device
                If syncWarning = True Then
                    tmrTimeSync.Interval = 2000
                    syncWarning = False
                Else
                    tempHour = Hour(Now)
                    tempDay = Weekday(Now)

                    receiveIndex = 0
                    xmitBuffer(0) = 8
                    xmitBuffer(1) = 1
                    xmitBuffer(2) = 0
                    xmitBuffer(3) = 2
                    xmitBuffer(4) = &H16
                    xmitBuffer(5) = ((tempDay - 1) * 32) + tempHour
                    pendingLinkAck = True
                    pendingAck = &H16  'Set the pendingAck
                    SendComData(xmitBuffer, 6, "Sent Time Sync", pendingLinkAck)
                    syncWarning = True
                    tempTime = (Minute(Now) * 60 + Second(Now)) * 1000    'Set time for 1 hour minus 2 seconds
                    tempTime = 3600000 - tempTime - 2000
                    tmrTimeSync.Interval = tempTime
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub tmrTimeSync_Tick: " & ex.Message)
        End Try
    End Sub

    Private Sub HideUCMbroupBoxes()
        Try
            ucmTabControl.Enabled = False

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub hideUCMbroupBoxes: " & ex.Message)
        End Try
    End Sub

    Private Sub ChkBadCheckSum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBadCheckSum.CheckedChanged
        Try
            If chkBadCheckSum.Checked = True Then
                wantBadSum = True
            Else
                wantBadSum = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub chkBadCheckSum_CheckedChanged: " & ex.Message)
        End Try
    End Sub

    Private Sub ChkLongMsg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLongMsg.CheckedChanged

        If chkLongMsg.Checked = True Then
            useLongMsg = True
        Else
            useLongMsg = False
        End If
    End Sub

    Private Sub ChangeBaud(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        Try
            If Me.CmbBaud.InvokeRequired Then
                Dim x As New SetTextCallback(AddressOf ChangeBaud)
                Me.Invoke(x, New Object() {(text)})
            Else
                Me.CmbBaud.Text = [text]
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub ChangeBaud: " & ex.Message)
        End Try
    End Sub

    Private Sub TmrBaudDefault_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBaudDefault.Tick
        Try
            CmbBaud.SelectedIndex = 0
            SerialPort1.Close()             'Close our Serial Port
            'Now change the baud rate selected in the CmbBaud comboBox
            ChangeBaud("19200")
            'Last perform same function as connect button
            SerialPort1.BaudRate = "19200"         'Reset baud rate to default
            SerialPort1.Open()            'Open the serial port

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub tmrBaudDefault_Tick: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnAcceptChangeBaud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceptChangeBaud.Click
        Dim xmitBuffer(8) As Byte

        Try
            If cmbChangeBaud.SelectedIndex < 0 Then Exit Sub

            receiveIndex = 0
            xmitBuffer(0) = 8
            xmitBuffer(1) = 3
            xmitBuffer(2) = 0
            xmitBuffer(3) = 2
            xmitBuffer(4) = &H17
            xmitBuffer(5) = cmbChangeBaud.SelectedIndex
            pendingLinkAck = True
            pendingAck = 0 'Set the pendingAck to nothing
            SendComData(xmitBuffer, 6, "Sent Change Baud Command", pendingLinkAck)
            expectingResponse = True
            AwaitingBaudChange = True
            Select Case cmbChangeBaud.SelectedIndex 'get text to use after change baud is acked
                Case 0
                    NextBaudText = "19200"
                Case 1
                    NextBaudText = "38400"
                Case 2
                    NextBaudText = "57600"
                Case 3
                    NextBaudText = "115200"
                Case 4
                    NextBaudText = "230400"
                Case 5
                    NextBaudText = "460800"
                Case 6
                    NextBaudText = "921600"
                Case 7
                    NextBaudText = "1843200"
                Case 8
                    NextBaudText = "3686400"
            End Select
            tmrBaudDefault.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub btnAcceptChangeBaud_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse.Click
        Try
            Dim LogFile = New SaveFileDialog With {
                .DefaultExt = "csv",
                .Filter = "comma delimited (*.csv)|*.csv|All files (*.*)|*.*",
                .InitialDirectory = IO.Directory.GetCurrentDirectory()
            }
            If LogFile.ShowDialog() = DialogResult.OK Then
                tbLogFile.Text = LogFile.FileName
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub Browse_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub AddSupportedType_Click(sender As Object, e As EventArgs) Handles addSupportedType.Click
        Dim msgTypeAsString As String

        Try
            msgTypeAsString = "0x" & Convert.ToInt32(nudMsgSuppMSB.Value).ToString("X") & " 0x" & Convert.ToInt32(nudMsgSuppLSB.Value).ToString("X")

            'keeps from adding an empty string
            If msgTypeAsString <> "" Then
                'Adds message type to listif it is not already there
                If supportedMsgTypeList.Items.Contains(msgTypeAsString) Then
                    MsgBox("Supported Message Type List already contains " & msgTypeAsString)
                Else
                    supportedMsgTypeList.Items.Add(msgTypeAsString)
                End If
            Else
                MsgBox("Error: Input must be a valid msg type in hex format.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub addSupportedType_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub RemoveSupportedType_Click(sender As Object, e As EventArgs) Handles removeSupportedType.Click
        Try
            supportedMsgTypeList.Items.Remove(supportedMsgTypeList.SelectedItem)
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub removeSupportedType_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub TypeSupportedQueryCodeLookup_Click(sender As Object, e As EventArgs) Handles typeSupportedQueryCodeLookup.Click
        Try
            MsgBox("Below are listed several predefined message types:" & Environment.NewLine &
                           "" & Environment.NewLine &
                           "08 02: Intermediate DR Application" & Environment.NewLine &
                           "08 03: Data-Link Messages" & Environment.NewLine &
                           "08 04: Commissioning and Network Support Messages" & Environment.NewLine &
                           "09 01: USNAP 1.0 Pass Through" & Environment.NewLine &
                           "09 02: ClimateTalk Pass Through" & Environment.NewLine &
                           "09 03: Smart Energy Profile 1.0 Pass Through" & Environment.NewLine &
                           "09 04: Smart Energy Profile 2.0 over IP Pass Through" & Environment.NewLine &
                           "09 05: OpenADR 1.0 over IP Pass Through" & Environment.NewLine &
                           "09 06: OpenADR 2.0 over IP Pass Through" & Environment.NewLine &
                           "09 07: Generic IP Pass Through" & Environment.NewLine &
                           "09 08: ECHONET Lite Pass Through" & Environment.NewLine &
                           "09 09: KNX Through" & Environment.NewLine &
                           "09 0A: Lon Talk Pass Through" & Environment.NewLine &
                           "09 0B: SunSpec Pass Through" & Environment.NewLine &
                           "09 0C: BACnet Pass Through")
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub typeSupportedQueryCodeLookup_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub DisableLogFile_CheckedChanged(sender As Object, e As EventArgs) Handles disableLogFile.CheckedChanged
        Try
            If disableLogFile.Checked = True Then
                ' TODO : Add a flag to enable writing memory for Generating report
                tbLogFile.Enabled = False
                Browse.Enabled = False
                cbVerboseLog.Enabled = False
            Else
                tbLogFile.Enabled = True
                Browse.Enabled = True
                cbVerboseLog.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub disableLogFile_CheckedChanged: " & ex.Message)
        End Try
    End Sub

    Private Sub PresentPriceTrackBar_Scroll(sender As Object, e As EventArgs) Handles presentPriceTrackBar.Scroll
        Try
            If presentPriceTrackBar.Value = 0 Then
                presentPriceTextBox.Text = "Unknown"
            ElseIf presentPriceTrackBar.Value = &HFF Then
                presentPriceTextBox.Text = ("Maximum")
            Else
                presentPriceTextBox.Text = ByteToRelativePrice(presentPriceTrackBar.Value)
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub presentPriceTrackBar_Scroll: " & ex.Message)
        End Try
    End Sub

    Private Sub NextPeriodTrackBar_Scroll(sender As Object, e As EventArgs) Handles nextPeriodTrackBar.Scroll
        Try
            If nextPeriodTrackBar.Value = 0 Then
                nextPeriodPriceTextBox.Text = "Unknown"
            ElseIf nextPeriodTrackBar.Value = &HFF Then
                nextPeriodPriceTextBox.Text = ("Maximum")
            Else
                nextPeriodPriceTextBox.Text = ByteToRelativePrice(nextPeriodTrackBar.Value)
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub nextPeriodTrackBar_Scroll: " & ex.Message)
        End Try
    End Sub

    Private Sub TimeRemainingTrackBar_Scroll(sender As Object, e As EventArgs) Handles timeRemainingTrackBar.Scroll
        Dim duration As Long
        Dim durHours As Byte
        Dim durMin As Byte
        Dim durSec As Byte

        If timeRemainingTrackBar.Value = 0 Then
            timeRemainingTextBox.Text = "Unknown"
        ElseIf timeRemainingTrackBar.Value = &HFF Then
            timeRemainingTextBox.Text = ("> Maximum")
        Else
            duration = (timeRemainingTrackBar.Value * timeRemainingTrackBar.Value) * 2
            durHours = duration \ 3600
            durMin = (duration Mod 3600) \ 60
            durSec = duration Mod 60
            timeRemainingTextBox.Text = durHours.ToString("00") & ":" & durMin.ToString("00") & ":" & durSec.ToString("00")
        End If
    End Sub

    Private Sub QueryDeviceInfoButton_Click(sender As Object, e As EventArgs) Handles queryDeviceInfoButton.Click
        Dim xmitBuffer(8) As Byte

        Try
            otherDeviceVendorID.Text = ""
            otherDeviceDeviceType.Text = ""
            otherDeviceDeviceRevision.Text = ""
            otherDeviceCapabilityBitmap.Text = ""
            otherDeviceSerialNumber.Text = ""
            otherDeviceCTA2045Version.Text = ""
            otherDeviceModelNumber.Text = ""
            otherDeviceFirmwareDate.Text = ""
            otherDeviceFirmwareMajor.Text = ""
            otherDeviceFirmwareMinor.Text = ""

            'Sends the request info query
            xmitBuffer(0) = 8
            xmitBuffer(1) = 2
            xmitBuffer(2) = 0
            xmitBuffer(3) = 2
            xmitBuffer(4) = 1
            xmitBuffer(5) = 1
            pendingLinkAck = True
            SendComData(xmitBuffer, 6, "Sent Device Info Query", pendingLinkAck)
            expectingResponse = True
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub frmMain_Load: " & ex.Message)
        End Try
    End Sub

    Private Sub PopulateDeviceInfo(mode As Integer)
        'Populates the Device Type drop down box with appropriate values
        Try
            If mode = 0 Then    'This device is a UCM
                deviceTypeComboBox.Items.Clear()
                deviceTypeComboBox.Items.Add("Wireless Router (other, non-standard)")
                deviceTypeComboBox.Items.Add("PLC (other, non-standard)")
                deviceTypeComboBox.Items.Add("Wired (other, non-standard)")
                deviceTypeComboBox.Items.Add("IEEE 802.15.4 (eg ZigBee)")
                deviceTypeComboBox.Items.Add("IEEE 802.11 (eg WiFi)")
                deviceTypeComboBox.Items.Add("IEEE 802.16 (eg WiMAX)")
                deviceTypeComboBox.Items.Add("VHF/UHF Pager")
                deviceTypeComboBox.Items.Add("FM (RDS/RBDS)")
                deviceTypeComboBox.Items.Add("Wired Ethernet")
                deviceTypeComboBox.Items.Add("Coaxial Networking")
                deviceTypeComboBox.Items.Add("Telephone Line")
                deviceTypeComboBox.Items.Add("IEEE 1901 (BPL)")
                deviceTypeComboBox.Items.Add("IEEE 1901.2 (Narrowband-PLC)")
                deviceTypeComboBox.Items.Add("ITU-T G.hn")
                deviceTypeComboBox.Items.Add("ITU-T G.hnem (Narrowband-PLC)")
                deviceTypeComboBox.Items.Add("Cellular (3g, 4gLTE, Mobile, any)")
                deviceTypeComboBox.Items.Add("Utility AMI, Wireless")
                deviceTypeComboBox.Items.Add("Utility AMI, PLC")
                deviceTypeComboBox.Items.Add("Other")
            Else                'This device is an SGD
                deviceTypeComboBox.Items.Clear()
                deviceTypeComboBox.Items.Add("Unspecified Type")
                deviceTypeComboBox.Items.Add("Water Heater - Gas")
                deviceTypeComboBox.Items.Add("Water Heater - Electric")
                deviceTypeComboBox.Items.Add("Water Heater - Heat Pump")
                deviceTypeComboBox.Items.Add("Central AC - Heat Pump")
                deviceTypeComboBox.Items.Add("Central AC - Fossil Fuel Heat")
                deviceTypeComboBox.Items.Add("Central AC - Resistance Heat")
                deviceTypeComboBox.Items.Add("Central AC (only)")
                deviceTypeComboBox.Items.Add("Evaporative Cooler")
                deviceTypeComboBox.Items.Add("Baseboard Electric Heat")
                deviceTypeComboBox.Items.Add("Window AC")
                deviceTypeComboBox.Items.Add("Portable Electric Heater")
                deviceTypeComboBox.Items.Add("Clothes Washer")
                deviceTypeComboBox.Items.Add("Clothes Dryer - Gas")
                deviceTypeComboBox.Items.Add("Clothes Dryer - Electric")
                deviceTypeComboBox.Items.Add("Refrigerator/Freezer")
                deviceTypeComboBox.Items.Add("Freezer")
                deviceTypeComboBox.Items.Add("Dishwasher")
                deviceTypeComboBox.Items.Add("Microwave Oven")
                deviceTypeComboBox.Items.Add("Oven - Electric")
                deviceTypeComboBox.Items.Add("Oven - Gas")
                deviceTypeComboBox.Items.Add("Cook Top - Electric")
                deviceTypeComboBox.Items.Add("Cook Top - Gas")
                deviceTypeComboBox.Items.Add("Stove - Electric")
                deviceTypeComboBox.Items.Add("Stove - Gas")
                deviceTypeComboBox.Items.Add("Dehumidifier")
                deviceTypeComboBox.Items.Add("Fan")
                deviceTypeComboBox.Items.Add("Pool Pump - Single Speed")
                deviceTypeComboBox.Items.Add("Pool Pump - Variable Speed")
                deviceTypeComboBox.Items.Add("Electric Hot Tub")
                deviceTypeComboBox.Items.Add("Irrigation Pump")
                deviceTypeComboBox.Items.Add("Electric Vehicle")
                deviceTypeComboBox.Items.Add("Hybrid Vehicle")
                deviceTypeComboBox.Items.Add("EV Supply Equipment - General")
                deviceTypeComboBox.Items.Add("EV Supply Equipment - Level 1")
                deviceTypeComboBox.Items.Add("EV Supply Equipment - Level 2")
                deviceTypeComboBox.Items.Add("EV Supply Equipment - Level 3")
                deviceTypeComboBox.Items.Add("In Premises Display")
                deviceTypeComboBox.Items.Add("Energy Manager")
                deviceTypeComboBox.Items.Add("Gateway Device")
                deviceTypeComboBox.Items.Add("Distributed Energy Resources")
                deviceTypeComboBox.Items.Add("Solar Inverter")
                deviceTypeComboBox.Items.Add("Battery Storage")
                deviceTypeComboBox.Items.Add("Other")
            End If

            'Add Generic Values to Form for ease of debugging
            PopulateGenericDeviceInfo()

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub populateDeviceInfo: " & ex.Message)
        End Try
    End Sub

    'Populates Device Info fields with generic values for testing/debugging
    Private Sub PopulateGenericDeviceInfo()

        nudVendorIDLSB.Value = &H55
        nudVendorIDMSB.Value = &H44
        nudDevRevLSB.Value = &H66
        nudDevRevMSB.Value = &H55
        deviceTypeComboBox.SelectedIndex = 0
        nudCapBitMap0.Value = &H20
        nudCapBitMap1.Value = &H21
        nudCapBitMap2.Value = &H22
        nudCapBitMap3.Value = &H23
        modelNumberSupportedCheckbox.Checked = False
        serialNumberSupportedCheckbox.Checked = False
        firmwareMonthComboBox.SelectedIndex = 1
        firmwareYearComboBox.SelectedIndex = 1
        firmwareDayComboBox.Text = 1

    End Sub

    Private Sub DeviceTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles deviceTypeComboBox.SelectedIndexChanged
        Try
            deviceTypeLSBTextBox.Enabled = False
            deviceTypeMSBTextBox.Enabled = False
            If rbMode1.Checked = True Then  'This is a UCM
                Select Case deviceTypeComboBox.SelectedItem
                    Case "Wireless Router (other, non-standard)"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "0"
                    Case "PLC (other, non-standard)"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "1"
                    Case "Wired (other, non-standard)"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "2"
                    Case "IEEE 802.15.4 (eg ZigBee)"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "3"
                    Case "IEEE 802.11 (eg WiFi)"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "4"
                    Case "IEEE 802.16 (eg WiMAX)"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "5"
                    Case "VHF/UHF Pager"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "6"
                    Case "FM (RDS/RBDS)"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "7"
                    Case "Wired Ethernet"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "8"
                    Case "Coaxial Networking"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "9"
                    Case "Telephone Line"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "A"
                    Case "IEEE 1901 (BPL)"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "B"
                    Case "IEEE 1901.2 (Narrowband-PLC)"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "C"
                    Case "ITU-T G.hn"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "D"
                    Case "ITU-T G.hnem (Narrowband-PLC)"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "E"
                    Case "Cellular (3g, 4gLTE, Mobile, any)"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "F"
                    Case "Utility AMI, Wireless"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "11"
                    Case "Utility AMI, PLC"
                        deviceTypeMSBTextBox.Text = "40"
                        deviceTypeLSBTextBox.Text = "12"
                    Case "Other"
                        deviceTypeMSBTextBox.Text = ""
                        deviceTypeLSBTextBox.Text = ""
                        deviceTypeLSBTextBox.Enabled = True
                        deviceTypeMSBTextBox.Enabled = True
                End Select
            Else                'This is an SGD
                Select Case deviceTypeComboBox.SelectedItem
                    Case "Unspecified Type"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "0"
                    Case "Water Heater - Gas"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "1"
                    Case "Water Heater - Electric"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "2"
                    Case "Water Heater - Heat Pump"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "3"
                    Case "Central AC - Heat Pump"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "4"
                    Case "Central AC - Fossil Fuel Heat"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "5"
                    Case "Central AC - Resistance Heat"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "6"
                    Case "Central AC (only)"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "7"
                    Case "Evaporative Cooler"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "8"
                    Case "Baseboard Electric Heat"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "9"
                    Case "Window AC"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "A"
                    Case "Portable Electric Heater"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "B"
                    Case "Clothes Washer"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "C"
                    Case "Clothes Dryer - Gas"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "1D"
                    Case "Clothes Dryer - Electric"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "E"
                    Case "Refrigerator/Freezer"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "F"
                    Case "Freezer"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "10"
                    Case "Dishwasher"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "11"
                    Case "Microwave Oven"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "12"
                    Case "Oven - Electric"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "13"
                    Case "Oven - Gas"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "14"
                    Case "Cook Top - Electric"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "15"
                    Case "Cook Top - Gas"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "16"
                    Case "Stove - Electric"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "17"
                    Case "Stove - Gas"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "18"
                    Case "Dehumidifier"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "19"
                    Case "Fan"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "20"
                    Case "Pool Pump - Single Speed"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "30"
                    Case "Pool Pump - Variable Speed"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "31"
                    Case "Electric Hot Tub"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "32"
                    Case "Irrigation Pump"
                        deviceTypeMSBTextBox.Text = "0"
                        deviceTypeLSBTextBox.Text = "40"
                    Case "Electric Vehicle"
                        deviceTypeMSBTextBox.Text = "10"
                        deviceTypeLSBTextBox.Text = "0"
                    Case "Hybrid Vehicle"
                        deviceTypeMSBTextBox.Text = "10"
                        deviceTypeLSBTextBox.Text = "1"
                    Case "EV Supply Equipment - General"
                        deviceTypeMSBTextBox.Text = "11"
                        deviceTypeLSBTextBox.Text = "0"
                    Case "EV Supply Equipment - Level 1"
                        deviceTypeMSBTextBox.Text = "11"
                        deviceTypeLSBTextBox.Text = "1"
                    Case "EV Supply Equipment - Level 2"
                        deviceTypeMSBTextBox.Text = "11"
                        deviceTypeLSBTextBox.Text = "2"
                    Case "EV Supply Equipment - Level 3"
                        deviceTypeMSBTextBox.Text = "11"
                        deviceTypeLSBTextBox.Text = "3"
                    Case "In Premises Display"
                        deviceTypeMSBTextBox.Text = "20"
                        deviceTypeLSBTextBox.Text = "0"
                    Case "Energy Manager"
                        deviceTypeMSBTextBox.Text = "50"
                        deviceTypeLSBTextBox.Text = "0"
                    Case "Gateway Device"
                        deviceTypeMSBTextBox.Text = "60"
                        deviceTypeLSBTextBox.Text = "0"
                    Case "Distributed Energy Resources"
                        deviceTypeMSBTextBox.Text = "70"
                        deviceTypeLSBTextBox.Text = "0"
                    Case "Solar Inverter"
                        deviceTypeMSBTextBox.Text = "70"
                        deviceTypeLSBTextBox.Text = "1"
                    Case "Battery Storage"
                        deviceTypeMSBTextBox.Text = "70"
                        deviceTypeLSBTextBox.Text = "2"
                    Case "Other"
                        deviceTypeMSBTextBox.Text = ""
                        deviceTypeLSBTextBox.Text = ""
                        deviceTypeLSBTextBox.Enabled = True
                        deviceTypeMSBTextBox.Enabled = True
                End Select

            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub deviceTypeComboBox_SelectedIndexChanged: " & ex.Message)
        End Try
    End Sub

    'Allows access to dates depending on the month and year
    Private Sub FirmwareMonthComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles firmwareMonthComboBox.SelectedIndexChanged
        Try
            If firmwareMonthComboBox.SelectedItem = "September" Or firmwareMonthComboBox.SelectedItem = "April" Or firmwareMonthComboBox.SelectedItem = "June" Or firmwareMonthComboBox.SelectedItem = "November" Then
                firmwareDayComboBox.Items.Remove("31")
            ElseIf firmwareMonthComboBox.SelectedItem = "February" Then
                firmwareDayComboBox.Items.Remove("31")
                firmwareDayComboBox.Items.Remove("30")
            Else
                If firmwareDayComboBox.Items.Contains("31") Then
                Else
                    firmwareDayComboBox.Items.Add("31")
                End If
                If firmwareDayComboBox.Items.Contains("30") Then
                Else
                    firmwareDayComboBox.Items.Add("30")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub firmwareMonthComboBox_SelectedIndexChanged: " & ex.Message)
        End Try
    End Sub

    'Provides an easy marker for determing if the device supports the feature
    Private Sub ModelNumberSupportedCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles modelNumberSupportedCheckbox.CheckedChanged
        Try
            If modelNumberSupportedCheckbox.Checked = True Then
                modelNumberTextBox.Enabled = True
            Else
                modelNumberTextBox.Enabled = False
                modelNumberTextBox.Text = "0000000000000000"
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub modelNumberSupportedCheckbox_CheckedChanged: " & ex.Message)
        End Try
    End Sub

    'Provides an easy marker for determing if the device supports the feature
    Private Sub SerialNumberSupportedCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles serialNumberSupportedCheckbox.CheckedChanged
        Try
            If serialNumberSupportedCheckbox.Checked = True Then
                serialNumberTextBox.Enabled = True
            Else
                serialNumberTextBox.Enabled = False
                serialNumberTextBox.Text = "0000000000000000"
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub serialNumberSupportedCheckbox_CheckedChanged: " & ex.Message)
        End Try
    End Sub

    'Compiles and then sends a GetInfo Reply
    Private Sub SendDeviceData()
        Dim xmitBuffer(59) As Byte
        Dim problem As Byte
        Dim tmpstring As String
        Dim i As Integer
        Dim StringLen As Integer

        Try
            problem = &H0 '0x0 for no problems yet

            'Reply Header
            xmitBuffer(0) = &H8
            xmitBuffer(1) = &H2
            xmitBuffer(2) = &H0
            xmitBuffer(4) = &H1
            xmitBuffer(5) = &H81
            xmitBuffer(6) = &H0         'response code

            'CTA2045 Version
            Dim array1() As Byte = System.Text.Encoding.ASCII.GetBytes(tbCEA2045Version.Text)
            StringLen = Len(tbCEA2045Version.Text)
            If StringLen > 0 Then
                xmitBuffer(7) = array1(0)
            Else
                xmitBuffer(7) = &H20       'Set value to space
            End If
            xmitBuffer(8) = &H0            'Set value null

            'VendorID
            xmitBuffer(9) = nudVendorIDMSB.Value
            xmitBuffer(10) = nudVendorIDLSB.Value

            'Device Type
            xmitBuffer(11) = Convert.ToInt32(deviceTypeMSBTextBox.Text, 16)
            xmitBuffer(12) = Convert.ToInt32(deviceTypeLSBTextBox.Text, 16)

            'Device Revision
            xmitBuffer(13) = nudDevRevMSB.Value
            xmitBuffer(14) = nudDevRevLSB.Value

            'Capability Bitmap
            xmitBuffer(15) = nudCapBitMap0.Value
            xmitBuffer(16) = nudCapBitMap1.Value
            xmitBuffer(17) = nudCapBitMap2.Value
            xmitBuffer(18) = nudCapBitMap3.Value

            'Assign reserved bit as 0
            xmitBuffer(19) = 0

            'Model Number, if supported
            If modelNumberSupportedCheckbox.Checked = True Or serialNumberSupportedCheckbox.Checked = True Or firmwareMajorMinorSupportedCheckbox.Checked = True Then
                Dim array2() As Byte = System.Text.Encoding.ASCII.GetBytes(modelNumberTextBox.Text)
                StringLen = Len(modelNumberTextBox.Text)
                For i = 0 To StringLen - 1
                    xmitBuffer(i + 20) = array2(i)
                Next i
                For i = 0 To 15 - StringLen
                    xmitBuffer(i + StringLen + 20) = 0
                Next i

                'Serial Number, if supported
                tmpstring = ""
                If serialNumberSupportedCheckbox.Checked = True Or firmwareMajorMinorSupportedCheckbox.Checked = True Then
                    Dim array3() As Byte = System.Text.Encoding.ASCII.GetBytes(serialNumberTextBox.Text)
                    StringLen = Len(serialNumberTextBox.Text)
                    For i = 0 To StringLen - 1
                        xmitBuffer(i + 36) = array3(i)
                    Next i
                    For i = 0 To 15 - StringLen
                        xmitBuffer(i + StringLen + 36) = 0
                    Next i

                    If firmwareMajorMinorSupportedCheckbox.Checked = True Then
                        'Firmware Year
                        xmitBuffer(52) = firmwareYearComboBox.SelectedIndex

                        'Firmware Month
                        xmitBuffer(53) = firmwareMonthComboBox.SelectedIndex

                        'Firmware Day
                        xmitBuffer(54) = firmwareDayComboBox.SelectedIndex + 1

                        'Firmware Major
                        xmitBuffer(55) = nudFirmwareMajor.Value

                        'Firmware Minor
                        xmitBuffer(56) = nudFirmwareMinor.Value
                        xmitBuffer(3) = 53
                    Else
                        xmitBuffer(3) = 48
                    End If
                Else
                    xmitBuffer(3) = 32
                End If
            Else
                xmitBuffer(3) = 16
            End If

            'Send message
            pendingLinkAck = True  'Set the pendingLinkAck to true
            SendComData(xmitBuffer, xmitBuffer(3) + 4, "Sent Device Info", pendingLinkAck)

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub sendDeviceData: " & ex.Message)
        End Try

    End Sub

    Private Sub InterpreteDeviceInfoReply(ByRef buffer() As Byte, length As Integer)
        Dim tmpstring As String
        Dim tmpArray(16) As Byte
        Dim i As Integer

        Try
            'First check to see if there was a mistake
            If buffer(6) <> 0 Then
                ReceivedText("", "There was an error with the other device - " & buffer(6))
            Else
                'Gets CTA-2045 Version
                If buffer(8) = 0 Then
                    otherDeviceCTA2045Version.Text = Chr(buffer(7))
                    'otherDeviceCTA2045Version.Text = Chr(buffer(7)) & Chr(buffer(8))
                Else
                    otherDeviceCTA2045Version.Text = "Invalid"
                End If

                'Gets VendorID
                otherDeviceVendorID.Text = buffer(9).ToString("X") & " " & buffer(10).ToString("X")

                'Gets Device Type
                If buffer(11) = &H0 And buffer(12) = &H1 Then
                    otherDeviceDeviceType.Text = "Water Heater - Gas"
                ElseIf buffer(11) = &H0 And buffer(12) = &H2 Then
                    otherDeviceDeviceType.Text = "Water Heater - Electric"
                ElseIf buffer(11) = &H0 And buffer(12) = &H3 Then
                    otherDeviceDeviceType.Text = "Water Heater - Heat Pump"
                ElseIf buffer(11) = &H0 And buffer(12) = &H4 Then
                    otherDeviceDeviceType.Text = "Central AC - Heat Pump"
                ElseIf buffer(11) = &H0 And buffer(12) = &H5 Then
                    otherDeviceDeviceType.Text = "Central AC - Fossil Fuel Heat"
                ElseIf buffer(11) = &H0 And buffer(12) = &H6 Then
                    otherDeviceDeviceType.Text = "Central AC - Resistance Heat"
                ElseIf buffer(11) = &H0 And buffer(12) = &H7 Then
                    otherDeviceDeviceType.Text = "Central AC (only)"
                ElseIf buffer(11) = &H0 And buffer(12) = &H8 Then
                    otherDeviceDeviceType.Text = "Evaporative Cooler"
                ElseIf buffer(11) = &H0 And buffer(12) = &H9 Then
                    otherDeviceDeviceType.Text = "Baseboard Electric Heat"
                ElseIf buffer(11) = &H0 And buffer(12) = &HA Then
                    otherDeviceDeviceType.Text = "Window AC"
                ElseIf buffer(11) = &H0 And buffer(12) = &HB Then
                    otherDeviceDeviceType.Text = "Portable Electric Heater"
                ElseIf buffer(11) = &H0 And buffer(12) = &HC Then
                    otherDeviceDeviceType.Text = "Clothes Washer"
                ElseIf buffer(11) = &H0 And buffer(12) = &HD Then
                    otherDeviceDeviceType.Text = "Clothes Dryer - Gas"
                ElseIf buffer(11) = &H0 And buffer(12) = &HE Then
                    otherDeviceDeviceType.Text = "Clothes Dryer - Electric"
                ElseIf buffer(11) = &H0 And buffer(12) = &HF Then
                    otherDeviceDeviceType.Text = "Refrigerator/Freezer"
                ElseIf buffer(11) = &H0 And buffer(12) = &H10 Then
                    otherDeviceDeviceType.Text = "Freezer"
                ElseIf buffer(11) = &H0 And buffer(12) = &H11 Then
                    otherDeviceDeviceType.Text = "Dishwasher"
                ElseIf buffer(11) = &H0 And buffer(12) = &H12 Then
                    otherDeviceDeviceType.Text = "Microwave Oven"
                ElseIf buffer(11) = &H0 And buffer(12) = &H13 Then
                    otherDeviceDeviceType.Text = "Oven - Electric"
                ElseIf buffer(11) = &H0 And buffer(12) = &H14 Then
                    otherDeviceDeviceType.Text = "Oven - Gas"
                ElseIf buffer(11) = &H0 And buffer(12) = &H15 Then
                    otherDeviceDeviceType.Text = "Cook Top - Electric"
                ElseIf buffer(11) = &H0 And buffer(12) = &H16 Then
                    otherDeviceDeviceType.Text = "Cook Top - Gas"
                ElseIf buffer(11) = &H0 And buffer(12) = &H17 Then
                    otherDeviceDeviceType.Text = "Stove - Electric"
                ElseIf buffer(11) = &H0 And buffer(12) = &H18 Then
                    otherDeviceDeviceType.Text = "Stove - Gas"
                ElseIf buffer(11) = &H0 And buffer(12) = &H19 Then
                    otherDeviceDeviceType.Text = "Dehumidifier"
                ElseIf buffer(11) = &H0 And buffer(12) = &H20 Then
                    otherDeviceDeviceType.Text = "Fan"
                ElseIf buffer(11) = &H0 And buffer(12) = &H30 Then
                    otherDeviceDeviceType.Text = "Pool Pump - Single Speed"
                ElseIf buffer(11) = &H0 And buffer(12) = &H31 Then
                    otherDeviceDeviceType.Text = "Pool Pump - Variable Speed"
                ElseIf buffer(11) = &H0 And buffer(12) = &H32 Then
                    otherDeviceDeviceType.Text = "Electric Hot Tub"
                ElseIf buffer(11) = &H0 And buffer(12) = &H40 Then
                    otherDeviceDeviceType.Text = "Irrigation Pump"
                ElseIf buffer(11) = &H10 And buffer(12) = &H0 Then
                    otherDeviceDeviceType.Text = "Electric Vehicle"
                ElseIf buffer(11) = &H10 And buffer(12) = &H1 Then
                    otherDeviceDeviceType.Text = "Hybrid Vehicle"
                ElseIf buffer(11) = &H11 And buffer(12) = &H0 Then
                    otherDeviceDeviceType.Text = "EV Supply Equipment - General"
                ElseIf buffer(11) = &H11 And buffer(12) = &H1 Then
                    otherDeviceDeviceType.Text = "EV Supply Equipment - Level 1"
                ElseIf buffer(11) = &H11 And buffer(12) = &H2 Then
                    otherDeviceDeviceType.Text = "EV Supply Equipment - Level 2"
                ElseIf buffer(11) = &H11 And buffer(12) = &H3 Then
                    otherDeviceDeviceType.Text = "EV Supply Equipment - Level 3"
                ElseIf buffer(11) = &H20 And buffer(12) = &H0 Then
                    otherDeviceDeviceType.Text = "In Premises Display"
                ElseIf buffer(11) = &H50 And buffer(12) = &H0 Then
                    otherDeviceDeviceType.Text = "Energy Manager"
                ElseIf buffer(11) = &H60 And buffer(12) = &H0 Then
                    otherDeviceDeviceType.Text = "Gateway Device"
                ElseIf buffer(11) = &H40 And buffer(12) = &H0 Then
                    otherDeviceDeviceType.Text = "Wireless (other, non-standard)"
                ElseIf buffer(11) = &H40 And buffer(12) = &H1 Then
                    otherDeviceDeviceType.Text = "PLC (other, non-standard)"
                ElseIf buffer(11) = &H40 And buffer(12) = &H2 Then
                    otherDeviceDeviceType.Text = "Wired (other, non-standard)"
                ElseIf buffer(11) = &H40 And buffer(12) = &H3 Then
                    otherDeviceDeviceType.Text = "IEEE 802.15.4 (eg ZigBee)"
                ElseIf buffer(11) = &H40 And buffer(12) = &H4 Then
                    otherDeviceDeviceType.Text = "IEEE 802.11 (eg WiFi)"
                ElseIf buffer(11) = &H40 And buffer(12) = &H5 Then
                    otherDeviceDeviceType.Text = "IEEE 802.16 (eg WiMax)"
                ElseIf buffer(11) = &H40 And buffer(12) = &H6 Then
                    otherDeviceDeviceType.Text = "VHF/UHF Pager"
                ElseIf buffer(11) = &H40 And buffer(12) = &H7 Then
                    otherDeviceDeviceType.Text = "FM (RDS/RBDS)"
                ElseIf buffer(11) = &H40 And buffer(12) = &H8 Then
                    otherDeviceDeviceType.Text = "Wired Ethernet"
                ElseIf buffer(11) = &H40 And buffer(12) = &H9 Then
                    otherDeviceDeviceType.Text = "Coaxial Networking"
                ElseIf buffer(11) = &H40 And buffer(12) = &HA Then
                    otherDeviceDeviceType.Text = "Telephone Line"
                ElseIf buffer(11) = &H40 And buffer(12) = &HB Then
                    otherDeviceDeviceType.Text = "IEEE 1901 (BPL)"
                ElseIf buffer(11) = &H40 And buffer(12) = &HC Then
                    otherDeviceDeviceType.Text = "IEEE 1901.2 (Narrowband-PLC)"
                ElseIf buffer(11) = &H40 And buffer(12) = &HD Then
                    otherDeviceDeviceType.Text = "ITU-T G.hn"
                ElseIf buffer(11) = &H40 And buffer(12) = &HE Then
                    otherDeviceDeviceType.Text = "ITU-T Ghnem (Narrowband-PLC)"
                ElseIf buffer(11) = &H40 And buffer(12) = &HF Then
                    otherDeviceDeviceType.Text = "Cellular (3g, 4g(LTE), Mobile, any)"
                ElseIf buffer(11) = &H40 And buffer(12) = &H10 Then
                    otherDeviceDeviceType.Text = "Utility AMI, Wireless"
                ElseIf buffer(11) = &H40 And buffer(12) = &H11 Then
                    otherDeviceDeviceType.Text = "Utility AMI, PLC"
                Else
                    otherDeviceDeviceType.Text = "Other: 0x" & Conversion.Hex(buffer(11)) & " 0x" & Conversion.Hex(buffer(12))
                End If

                'Get Device Revision
                tmpstring = buffer(13).ToString("X") & " " & buffer(14).ToString("X")
                otherDeviceDeviceRevision.Text = tmpstring

                'Get Device Capability Bitmap
                tmpstring = buffer(15).ToString("X") & " " & buffer(16).ToString("X") & " "
                tmpstring &= buffer(17).ToString("X") & " " & buffer(18).ToString("X")
                otherDeviceCapabilityBitmap.Text = tmpstring

                'Get Model Number, if supported
                If buffer(3) > 16 Then
                    For i = 0 To 15
                        tmpArray(i) = buffer(20 + i)
                    Next
                    otherDeviceModelNumber.Text = System.Text.Encoding.Default.GetString(tmpArray)
                Else
                    otherDeviceModelNumber.Text = "Not supported"
                End If


                'Get Serial Number if supported
                If buffer(3) > 32 Then
                    For i = 0 To 15
                        tmpArray(i) = buffer(36 + i)
                    Next
                    otherDeviceSerialNumber.Text = System.Text.Encoding.Default.GetString(tmpArray)
                Else
                    otherDeviceSerialNumber.Text = "Not supported"
                End If

                'Get firmware Date
                If buffer(3) > 48 Then
                    'Month
                    Select Case buffer(53)
                        Case &H0
                            otherDeviceFirmwareDate.Text = "January "
                        Case &H1
                            otherDeviceFirmwareDate.Text = "February "
                        Case &H2
                            otherDeviceFirmwareDate.Text = "March "
                        Case &H3
                            otherDeviceFirmwareDate.Text = "April "
                        Case &H4
                            otherDeviceFirmwareDate.Text = "May "
                        Case &H5
                            otherDeviceFirmwareDate.Text = "June "
                        Case &H6
                            otherDeviceFirmwareDate.Text = "July "
                        Case &H7
                            otherDeviceFirmwareDate.Text = "August "
                        Case &H8
                            otherDeviceFirmwareDate.Text = "September "
                        Case &H9
                            otherDeviceFirmwareDate.Text = "October "
                        Case &HA
                            otherDeviceFirmwareDate.Text = "November "
                        Case &HB
                            otherDeviceFirmwareDate.Text = "December "
                    End Select
                    'Day
                    tmpstring = buffer(54) & ", "
                    'Year
                    tmpstring &= (Convert.ToInt32(buffer(52), 10) + 2000).ToString
                    otherDeviceFirmwareDate.Text &= tmpstring

                    'Get Firmware Major
                    otherDeviceFirmwareMajor.Text = buffer(55)

                    'Get Firmware Minor
                    otherDeviceFirmwareMinor.Text = buffer(56)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub interpreteDeviceInfoReply: " & ex.Message)
        End Try
    End Sub

    Private Sub RbMaxPayload1_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload1.CheckedChanged
        If rbMaxPayload1.Checked Then
            MaxPayloadSize = 2
            MaxPayload = 0
        End If
    End Sub

    Private Sub RbMaxPayload2_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload2.CheckedChanged
        If rbMaxPayload2.Checked Then
            MaxPayloadSize = 4
            MaxPayload = 1
        End If
    End Sub

    Private Sub RbMaxPayload3_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload3.CheckedChanged
        If rbMaxPayload3.Checked Then
            MaxPayloadSize = 8
            MaxPayload = 2
        End If
    End Sub


    Private Sub RbMaxPayload4_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload4.CheckedChanged
        If rbMaxPayload4.Checked Then
            MaxPayloadSize = 16
            MaxPayload = 3
        End If
    End Sub

    Private Sub RbMaxPayload5_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload5.CheckedChanged
        If rbMaxPayload5.Checked Then
            MaxPayloadSize = 32
            MaxPayload = 4
        End If
    End Sub

    Private Sub RbMaxPayload6_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload6.CheckedChanged
        If rbMaxPayload6.Checked Then
            MaxPayloadSize = 64
            MaxPayload = 5
        End If
    End Sub

    Private Sub RbMaxPayload7_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload7.CheckedChanged
        If rbMaxPayload7.Checked Then
            MaxPayloadSize = 128
            MaxPayload = 6
        End If
    End Sub

    Private Sub RbMaxPayload8_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload8.CheckedChanged
        If rbMaxPayload8.Checked Then
            MaxPayloadSize = 256
            MaxPayload = 7
        End If
    End Sub

    Private Sub RbMaxPayload9_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload9.CheckedChanged
        If rbMaxPayload9.Checked Then
            MaxPayloadSize = 512
            MaxPayload = 8
        End If
    End Sub

    Private Sub RbMaxPayload10_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload10.CheckedChanged
        If rbMaxPayload10.Checked Then
            MaxPayloadSize = 1024
            MaxPayload = 9
        End If
    End Sub

    Private Sub RbMaxPayload11_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload11.CheckedChanged
        If rbMaxPayload11.Checked Then
            MaxPayloadSize = 1280
            MaxPayload = 10
        End If
    End Sub

    Private Sub RbMaxPayload12_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload12.CheckedChanged
        If rbMaxPayload12.Checked Then
            MaxPayloadSize = 1500
            MaxPayload = 11
        End If
    End Sub

    Private Sub RbMaxPayload13_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload13.CheckedChanged
        If rbMaxPayload13.Checked Then
            MaxPayloadSize = 2048
            MaxPayload = 12
        End If
    End Sub

    Private Sub RbMaxPayload14_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaxPayload14.CheckedChanged
        If rbMaxPayload14.Checked Then
            MaxPayloadSize = 4096
            MaxPayload = 13
        End If
    End Sub

    Public Function DateTimeToEpoch(ByVal DateTimeValue As Date) As Integer
        '
        Try
            Return CInt(DateTimeValue.Subtract(CDate("1.1.1970 00:00:00")).TotalSeconds)
        Catch ex As System.OverflowException
            Return -1
        End Try

    End Function


    Private Sub BtnGetUTC_Click(sender As Object, e As EventArgs) Handles btnGetUTC.Click
        Dim xmitBuffer(8) As Byte

        Try
            receiveIndex = 0
            xmitBuffer(0) = &H8
            xmitBuffer(1) = &H2
            xmitBuffer(2) = 0
            xmitBuffer(3) = 2
            xmitBuffer(4) = 2
            xmitBuffer(5) = 0
            pendingLinkAck = True
            SendComData(xmitBuffer, 6, "Sent Get UTC Time Request", pendingLinkAck)
            expectingResponse = True
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub btnGetUTC_Click: " & ex.Message)
        End Try

    End Sub

    Private Sub Reset_state()
        receiveIndex = 0
        pendingAck = 0
        tempRxPtr = 0
        pendingLinkAck = False  'Clear the pendingLinkAck flag
        AwaitingBaudChange = False
        rxMsgOverflow = False
        rxMsgOversize = False
        expectingResponse = False
        rxMsgStartTime = Nothing
        pendingAckTime = Nothing
        msgReceiveTime = Nothing

    End Sub

    Private Sub TmrProcessComm_Tick(sender As Object, e As EventArgs) Handles tmrProcessComm.Tick
        Dim dispString As String
        Dim xmitBuffer(8) As Byte
        Dim LinkNackError As Byte
        Dim rightNowTime As System.DateTime
        Dim deltaTime As System.TimeSpan
        Dim deltaMS As Integer

        'Make sure routine is not being reentered before completition
        tmrProcessComm.Enabled = False

        ' This section of code triggers the next script step when it is due
        If DateTime.Now >= nextScriptTime And nextScriptTime > New DateTime(1970, 1, 1) Then
            ReadScriptFile(scriptFileReader)        'Process next script command
        End If

        'Triggers the next script checking section
        If DateTime.Now >= nextScriptTestTime And nextScriptTestTime > New DateTime(1970, 1, 1) Then
            TestScriptFile(scriptFileReader)        'Evaluate next script command
        End If

        'Check to see if a message being received has timed out
        'If messageComplete = False And rxMsgStartTime.Year > 2013 Then
        If receiveIndex = 0 And rxMsgStartTime.Year > 2013 Then
            rightNowTime = DateTime.Now
            deltaTime = rightNowTime.Subtract(rxMsgStartTime)
            deltaMS = deltaTime.Seconds * 1000 + deltaTime.Milliseconds
            If deltaMS > tMLValBox.Value Then
                'Message has timed out
                'It has been over 500ms (default) since the start of the message so ignore existing data
                dispString = ByteToHexString(tempRxBuff, "Recv", tempRxPtr)    'Display the received data in the text box and log file
                SendToLog(dispString, "Error - Timed out waiting for data")
                ReceivedText(dispString, "Error - Timed out waiting for data")
                Reset_state()
            End If
        End If

        '=============================================================================================
        ' This block to be deleted
        '=============================================================================================
        If pendingAckTime.Year > 2013 Then
            rightNowTime = DateTime.Now
            deltaTime = rightNowTime.Subtract(pendingAckTime)
            deltaMS = deltaTime.Seconds * 1000 + deltaTime.Milliseconds
            If pendingLinkAck = True Then
                If deltaMS > 200 Then       'tMA
                    'Timed out waiting for a link ack/nak - 200ms is max time to wait
                    dispString = ByteToHexString(tempRxBuff, "Recv", tempRxPtr)    'Display the received data in the text box
                    SendToLog(dispString, "Error - timed out waiting for Link Ack/Nak-1")
                    ReceivedText(dispString, "Error - timed out waiting for Link Ack/Nak-1")
                    Reset_state()
                End If
            ElseIf pendingAck <> 0 Then
                If deltaMS > 3000 Then      'tAR
                    'Timed out waiting for an application ack/nak - application defined max time to wait - Use 3 seconds
                    dispString = ByteToHexString(tempRxBuff, "Recv", tempRxPtr)    'Display the received data in the text box
                    SendToLog(dispString, "Error - timed out waiting for Application Ack/Nak-2")
                    ReceivedText(dispString, "Error - timed out waiting for Application Ack/Nak-2")
                    Reset_state()
                End If
            ElseIf expectingResponse = True Then
                If deltaMS > 3000 Then      'tAR
                    'Timed out waiting for a response to a query
                    dispString = ByteToHexString(tempRxBuff, "Recv", tempRxPtr)    'Display the received data in the text box
                    SendToLog(dispString, "Error - timed out waiting for query response")
                    ReceivedText(dispString, "Error - timed out waiting for query response")
                    Reset_state()
                End If
            End If

        End If
        '=============================================================================================
        ' End block to be deleted
        '=============================================================================================
        If rxMsgOverflow = True Then
            'More data than can fit in the receive buffer has arrived - probably junk so print and ignore
            dispString = ByteToHexString(tempRxBuff, "Recieved Message Larger than receive buffer", tempRxPtr)    'Display the received data in the text box
            SendToLog(dispString, " Ignoring message.")
            ReceivedText(dispString, " Ignoring message.")
            Reset_state()
        End If

        If receiveIndex > 0 Then
            If (rxMsgOversize = True) And (cbResponseSim.Checked = True) Then
                dispString = ByteToHexString(receiveBuffer, "Recieved Message Larger than max payload:", receiveIndex)    'Display the received data in the text box
                SendToLog(dispString, "Nak message as too large")
                ReceivedText(dispString, "Nak message as too large")
                rxMsgOversize = False
                SendLinkNak(2)
                Reset_state()
            Else
                If rxMsgOversize = True Then
                    dispString = "Recieved Message Larger than max payload"    'Warn operator that the message was too big but process anyway
                    SendToLog(dispString, "Ignoring limit and processing message.")
                    ReceivedText(dispString, "Ignoring limit and processing message.")
                End If
                dispString = ByteToHexString(receiveBuffer, "Recv", receiveIndex)
                If pendingLinkAck = True And receiveIndex >= 2 Then
                    If receiveBuffer(0) = 6 And receiveBuffer(1) = 0 Then 'This is a link Ack
                        SendToLog(dispString, "Link Ack Received")
                        ReceivedText(dispString, "Link Ack Received")
                        numCommandsResent = 0
                        pendingLinkAck = False  'Clear the pendingLinkAck flag
                        pendingAckTime = Nothing
                        If pendingAck <> 0 Then
                            pendingAckTime = DateTime.Now
                        End If
                        If AwaitingBaudChange = True Then
                            ChangeBaud(NextBaudText)
                            SerialPort1.Close()             'Close our Serial Port
                            'Now change the baud rate selected in the CmbBaud comboBox
                            ChangeBaud(NextBaudText)
                            'Last perform same function as connect button
                            SerialPort1.BaudRate = NextBaudText         'Set Baud rate to the selected value on
                            SerialPort1.Open()            'Open the serial port
                            ReceivedText("", "Change baud rate")
                            AwaitingBaudChange = False
                        End If
                        receiveIndex = 0 'Remove LinkAck from buffer
                        If overRideSet = True And sendOverridePend = True And rbMode1.Checked = False Then
                            'The customer override is set and a message is required in response last transmission
                            sendOverridePend = False
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            receiveIndex = 0
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 1
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 2
                            xmitBuffer(4) = &H11
                            xmitBuffer(5) = 1
                            pendingLinkAck = True
                            expectingResponse = True
                            pendingAck = &H11  'Set the pendingAck
                            SendComData(xmitBuffer, 6, "Sent Customer Override in Effect", pendingLinkAck)
                        End If
                    ElseIf receiveBuffer(0) = &H15 And receiveIndex >= 2 Then 'This is a link Nack
                        Select Case receiveBuffer(1)
                            Case 0
                                SendToLog(dispString, "Link Nak Received: 0x0 No Reason Given")
                                ReceivedText(dispString, "Link Nak Received: 0x0 No Reason Given")
                            Case 1  'This case should never occur. Simulator has no way of catching this error
                                SendToLog(dispString, "Link Nak Received: 0x1 Invalid Byte")
                                ReceivedText(dispString, "Link Nak Received: 0x1 Invalid Byte")
                            Case 2
                                SendToLog(dispString, "Link Nak Received: 0x2 Invalid Length")
                                ReceivedText(dispString, "Link Nak Received: 0x2 Invalid Length")
                            Case 3
                                SendToLog(dispString, "Link Nak Received: 0x3 Checksum Error")
                                ReceivedText(dispString, "Link Nak Received: 0x3 Checksum Error")
                            Case 4
                                SendToLog(dispString, "Link Nak Received: 0x4 Reserved")
                                ReceivedText(dispString, "Link Nak Received: 0x4 Reserved")
                            Case 5
                                SendToLog(dispString, "Link Nak Received: 0x5 Message Timeout")
                                ReceivedText(dispString, "Link Nak Received: 0x5 Message Timeout")
                            Case 6
                                SendToLog(dispString, "Link Nak Received: 0x6 Unsupported Message Type")
                                ReceivedText(dispString, "Link Nak Received: 0x6 Unsupported Message Type")
                            Case 7
                                SendToLog(dispString, "Link Nak Received: 0x7 Request Not Supported")
                                ReceivedText(dispString, "Link Nak Received: 0x7 Request Not Supported")
                            Case Else
                                SendToLog(dispString, "Unknown Link Nak Received: " & Conversion.Hex(receiveBuffer(1)))
                                ReceivedText(dispString, "Unknown Link Nak Received :" & Conversion.Hex(receiveBuffer(1)))
                        End Select
                        pendingLinkAck = False  'Clear the pendingLinkAck flag
                        numCommandsResent = 0
                        pendingAckTime = Nothing
                        AwaitingBaudChange = False
                        LinkNackError = receiveBuffer(1)
                        receiveIndex = 0 'Remove linkAck from buffer
                        pendingAck = &H0  'No ack will be coming since the message received a Link Nack

                    Else
                        'We are expecting a link Ack or Nak but this is neither
                        'Remove the pendingLinkAck flag and write error to log file
                        Reset_state()
                        SendToLog("", "Error - Expected link Ack/Nak not received")
                        ReceivedText("", "Error - Expected link Ack/Nak not received")
                    End If

                ElseIf receiveIndex >= 6 And receiveBuffer(2) = 0 And receiveBuffer(3) = 0 Then     'Then this is a msg type supported query
                    'Assume if the other device is asking then it supports this message type
                    For i = 0 To 5
                        If supportedMsgTypeOD(i, 0) = 0 Then
                            'This item is not in the list so add it
                            supportedMsgTypeOD(i, 0) = receiveBuffer(0)
                            supportedMsgTypeOD(i, 1) = receiveBuffer(1)
                            i = 5
                        ElseIf (supportedMsgTypeOD(i, 0) = receiveBuffer(0) And supportedMsgTypeOD(i, 1) = receiveBuffer(1)) Then
                            'This message type is already in the list
                            i = 5
                        End If
                    Next i
                    'Display the received data in the text box
                    SendToLog(dispString, "Received message type supported query")
                    ReceivedText(dispString, "Received message type supported query")
                    ProcessTypeSupportedQuery()
                    RefreshODMsgList()

                ElseIf receiveBuffer(0) = 8 And (receiveBuffer(1) = 1 Or receiveBuffer(1) = 2 Or receiveBuffer(1) = 3) Then
                    'dispString = ByteToHexString(receiveBuffer, "Recv", receiveIndex)
                    If receiveBuffer(1) = 1 Then
                        'Basic message - Check that the message is the correct length
                        If receiveIndex = 8 Then
                            ProcessBasicDRAppMsg(dispString)
                        Else
                            'Wrong length for 0x8 0x1 message
                            dispString = ByteToHexString(receiveBuffer, "Recv", receiveIndex)
                            SendToLog(dispString, "Error - Message was the wrong length")
                            ReceivedText(dispString, "Error - Message was the wrong length")
                            SendLinkNak(2)
                        End If

                    Else
                        'if length of 2 and 3
                        If receiveIndex = (6 + receiveBuffer(3)) Then
                            If receiveBuffer(1) = 2 Then
                                ProcessIntDRAppMsg(dispString)
                            Else
                                ProcessDataLinkMsg(dispString)
                            End If
                        Else
                            'Wrong length for 0x8 0x1 message
                            dispString = ByteToHexString(receiveBuffer, "Recv", receiveIndex)
                            SendToLog(dispString, "Error - Message was the wrong length")
                            ReceivedText(dispString, "Error - Message was the wrong length")
                            SendLinkNak(2)
                        End If
                    End If

                ElseIf receiveBuffer(0) = 9 Then
                    'This is a pass through message
                    dispString = ByteToHexString(receiveBuffer, "Recv", receiveIndex)   'Display the received data in the text box
                    If VerifyChecksum(receiveBuffer, (receiveIndex - 2)) = False Then
                        SendToLog(dispString, "Received Invalid Checksum")
                        ReceivedText(dispString, "Received Invalid Checksum")
                        SendLinkNak(3)
                    Else        'Checksum is valid so see what the message is
                        SendToLog(dispString, "Pass through message received")
                        ReceivedText(dispString, "Pass through message received")
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            pendingAck = 0  'Set the pendingAck to nothing
                            pendingLinkAck = False  'Set the pendingLinkAck to true
                        End If
                    End If
                Else
                    If receiveBuffer(0) = &H15 Or receiveBuffer(0) = &H6 Then 'This is a link Ack
                        'Received unexpected link ack or nak. Do not respond.
                        SendToLog(dispString, "Received unexpected link ack or nak")
                        ReceivedText(dispString, "Received unexpected link ack or nak")
                    Else
                        'This message did not match any of the above types
                        SendToLog(dispString, "Error - Message did not match any known type")
                        ReceivedText(dispString, "Error - Message did not match any known type")
                        SendLinkNak(6)
                    End If
                    Reset_state()
                End If
                receiveIndex = 0
            End If

        End If

        'This section of code prints messages to the log file
        If logFileBuffer.Length > 0 Then
            If PrintToLog(logFileBuffer) = 0 Then
                logFileBuffer = ""
            End If
        End If

        tmrProcessComm.Enabled = True
    End Sub

    Private Sub SendMsgNotSupportedNak()
        Dim xmitBuffer(8) As Byte

        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 4
        xmitBuffer(5) = 1
        pendingLinkAck = True
        SendComData(xmitBuffer, 6, "Sent Message Not Supported Application Nak", pendingLinkAck)

    End Sub

    Public Shared Function UnixTimeStampToDateTime(unixTimeStamp As Integer) As DateTime
        'Public Shared Function UnixTimeStampToDateTime(unixTimeStamp As Double) As DateTime

        ' Unix timestamp is seconds past epoch
        Dim dtDateTime As System.DateTime = New DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime()
        Return dtDateTime
    End Function

    Private Sub ProcessIntDRAppMsg(ByVal dispString As String)

        Dim UTCseconds As Integer
        Dim uTime As Integer
        Dim xmitBuffer(121) As Byte
        Dim tmparr(8) As Byte
        Dim i, j As Integer
        Dim indexVal As Integer
        Dim tempLong As ULong
        Dim tempLong2 As ULong
        Dim tempLong3 As ULong
        Dim tempint As Integer
        Dim startDate As New DateTime(1970, 1, 1, 0, 0, 0)
        Dim tempDate As New DateTime(1970, 1, 1, 0, 0, 0)

        If VerifyChecksum(receiveBuffer, (receiveIndex - 2)) = False Then
            SendToLog(dispString, "Invalid Checksum Received")
            ReceivedText(dispString, "Invalid Checksum Received")
            SendLinkNak(3)
        Else

            Select Case receiveBuffer(4)
                Case 1      'device info
                    If receiveBuffer(5) = 1 Then        'receiveBuffer(2) = 0 And receiveBuffer(3) = 2
                        'This is a device info request
                        SendToLog(dispString, "Received a Device Info Request")
                        ReceivedText(dispString, "Received a Device Info Request")
                        'Delete last message from buffer
                        receiveIndex = 0

                        'Send Link Ack
                        receiveIndex = 0
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response

                            If MaxPayloadSize >= 59 Then
                                SendDeviceData()
                            Else
                                SendMsgNotSupportedNak() 'Reply would be larger than max payload
                                ReceivedText("", "Tried to send a message longer than max payload")
                            End If
                        End If

                    ElseIf receiveBuffer(5) = &H81 Then         'receiveBuffer(2) = 0 And receiveBuffer(3) = &H33
                        'This is a device info request reply
                        SendToLog(dispString, "Received Device Info")
                        ReceivedText(dispString, "Received Device Info")
                        SendLinkAck()
                        If receiveBuffer(6) < 8 Then
                            cbInterRespCodeRecv.SelectedIndex = receiveBuffer(6)
                        Else
                            cbInterRespCodeRecv.SelectedIndex = 8
                        End If
                        If forceNak = True Then
                            Reset_state()
                        Else
                            If receiveBuffer(6) = 0 Then
                                InterpreteDeviceInfoReply(receiveBuffer, receiveBuffer(3) + 6)
                            Else
                                ReceivedText("", "There was an error with the device info request - " & receiveBuffer(6))
                            End If

                            'Remove last message from buffer
                            receiveIndex = 0
                        End If
                    End If

                Case 2      'UTC time
                    If receiveBuffer(5) = 0 Then
                        If receiveBuffer(2) = 0 And receiveBuffer(3) = 2 Then
                            'SGD has requested UTC time
                            uTime = (DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds
                            uTime -= 946684800      'Conver Unix time to seconds since 1/1/2000
                            SendToLog(dispString, "Received a UTC time request. Time = " & uTime)
                            ReceivedText(dispString, "Received a UTC time request. Time = " & uTime)
                            SendLinkAck()
                            If forceNak = True Then
                                Reset_state()
                            Else
                                PauseMS(tARValBox.Value)      'Wait before sending response
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 2
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 9
                                xmitBuffer(4) = 2
                                xmitBuffer(5) = &H80
                                If rbMode1.Checked = True Then
                                    'This is a UCM
                                    If cbInterRespCode.SelectedIndex = 7 Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                Else
                                    'This is an SGD
                                    If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                End If
                                xmitBuffer(10) = uTime And &HFF
                                xmitBuffer(9) = (uTime >> 8) And &HFF
                                xmitBuffer(8) = (uTime >> 16) And &HFF
                                xmitBuffer(7) = (uTime >> 24) And &HFF
                                xmitBuffer(11) = nudUTCOffset.Value And &HFF        'Time zone offset in 15 minute units
                                xmitBuffer(12) = nudDSTOffset.Value                 'DST offset
                                pendingAck = 0  'Set the pendingAck to nothing
                                pendingLinkAck = True  'Set the pendingLinkAck to true
                                SendComData(xmitBuffer, 13, "Sent Response to a UTC time request", pendingLinkAck)
                                'Delete last message from buffer
                                receiveIndex = 0
                            End If
                        ElseIf receiveBuffer(2) = 0 And receiveBuffer(3) = 8 Then
                            'This is an Set UTC Time request
                            UTCseconds = receiveBuffer(6) * 16777216 + receiveBuffer(7) * 65536 + receiveBuffer(8) * 256 + receiveBuffer(9)
                            SendToLog(dispString, "Received a set UTC Time Request. Time = " & UTCseconds)
                            ReceivedText(dispString, "Received a set UTC Time Request. Time = " & UTCseconds)
                            SendLinkAck()
                            If forceNak = True Then
                                Reset_state()
                            Else
                                PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 2
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 3
                                xmitBuffer(4) = 2
                                xmitBuffer(5) = &H80
                                If rbMode1.Checked = True Then
                                    'This is a UCM
                                    If cbInterRespCode.SelectedIndex = 7 Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                Else
                                    'This is an SGD
                                    If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                End If
                                pendingAck = 0  'Set the pendingAck to nothing
                                pendingLinkAck = True  'Set the pendingLinkAck to true
                                SendComData(xmitBuffer, 7, "Sent Set UTC Time Response", pendingLinkAck)
                                'Delete last message from buffer
                                receiveIndex = 0
                            End If
                        End If

                    ElseIf receiveBuffer(5) = &H80 Then
                        If receiveBuffer(6) < 8 Then
                            cbInterRespCodeRecv.SelectedIndex = receiveBuffer(6)
                        Else
                            cbInterRespCodeRecv.SelectedIndex = 8
                        End If
                        If receiveBuffer(2) = 0 And receiveBuffer(3) = 3 Then
                            'This is an Set UTC Time response from the SGD
                            SendToLog(dispString, "Received a Set UTC Time response")
                            ReceivedText(dispString, "Received a Set UTC Time Response")
                            SendLinkAck()
                            'Delete last message from buffer
                            receiveIndex = 0

                        ElseIf receiveBuffer(2) = 0 And receiveBuffer(3) = 9 Then
                            'This is a Get UTC Time response from the UCM
                            UTCseconds = receiveBuffer(7) * 16777216
                            UTCseconds = UTCseconds + (receiveBuffer(8) * 65536)
                            UTCseconds = UTCseconds + (receiveBuffer(9) * 256)
                            UTCseconds = UTCseconds + receiveBuffer(10)
                            SendToLog(dispString, "Received Get UTC Time response. Time = " & UTCseconds)
                            ReceivedText(dispString, "Received Get UTC Time Resonse. Time = " & UTCseconds)
                            SendLinkAck()
                            'Delete Last message from buffer
                            receiveIndex = 0

                        End If
                    End If

                Case 3      'Get/Set
                    If receiveBuffer(5) = 0 Then        'Get/Set Energy Price request
                        If receiveBuffer(2) = 0 And receiveBuffer(3) = 2 Then       'Get Energy Price request
                            'This is a Get Energy Price Request
                            SendToLog(dispString, "Received a Get Energy Price Request")
                            ReceivedText(dispString, "Received a Get Energy Price Request")
                            PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                            SendLinkAck()
                            If forceNak = True Then
                                Reset_state()
                            Else
                                PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 2
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 18
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = &H80
                                If rbMode1.Checked = True Then
                                    'This is a UCM
                                    If cbInterRespCode.SelectedIndex = 7 Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                Else
                                    'This is an SGD
                                    If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                End If
                                xmitBuffer(7) = (nudCurrentPrice.Value >> 24) And &HFF     'Current price
                                xmitBuffer(8) = (nudCurrentPrice.Value >> 16) And &HFF
                                xmitBuffer(9) = (nudCurrentPrice.Value >> 8) And &HFF
                                xmitBuffer(10) = nudCurrentPrice.Value And &HFF
                                xmitBuffer(11) = (nudCurrencyCode.Value >> 8) And &HFF     'Currency code
                                xmitBuffer(12) = nudCurrencyCode.Value And &HFF
                                xmitBuffer(13) = nudDigitsAfterDecimal.Value      'Digits after decimal
                                'Build expiration time
                                uTime = (dtpExpTime.Value - startDate).TotalSeconds
                                If uTime < 946684800 Then
                                    uTime = 946684800
                                End If
                                uTime -= 946684800      'Conver Unix time to seconds since 1/1/2000
                                xmitBuffer(17) = uTime And &HFF
                                xmitBuffer(16) = (uTime >> 8) And &HFF
                                xmitBuffer(15) = (uTime >> 16) And &HFF
                                xmitBuffer(14) = (uTime >> 24) And &HFF
                                xmitBuffer(18) = (nudNextPrice.Value >> 24) And &HFF   'Next price
                                xmitBuffer(19) = (nudNextPrice.Value >> 16) And &HFF
                                xmitBuffer(20) = (nudNextPrice.Value >> 8) And &HFF
                                xmitBuffer(21) = nudNextPrice.Value And &HFF
                                'Send responce
                                expectingResponse = False
                                pendingLinkAck = True
                                SendComData(xmitBuffer, 22, "Sent Get Energy Price Request Reply", pendingLinkAck)

                                'Clear Buffer
                                receiveIndex = 0
                            End If

                        ElseIf receiveBuffer(2) = 0 And receiveBuffer(3) > 2 Then   'Set Energy Price request
                            'This is a Set Energy Price Request
                            nudNextPrice.Value = 0
                            SendToLog(dispString, "Received a Set Energy Price Request")
                            ReceivedText(dispString, "Received a Set Energy Price Request")
                            PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                            SendLinkAck()
                            nudCurrentPrice.Value = (receiveBuffer(6) * 16777216) + (receiveBuffer(7) * 65536) + (receiveBuffer(8) * 256) + receiveBuffer(9)     'Current price
                            nudCurrencyCode.Value = (receiveBuffer(10) * 256) + receiveBuffer(11)     'Currency code
                            nudDigitsAfterDecimal.Value = receiveBuffer(12)        'Digits after decimal
                            If receiveBuffer(3) > 9 Then
                                UTCseconds = (receiveBuffer(13) * 16777216) + (receiveBuffer(14) * 65536) + (receiveBuffer(15) * 256) + receiveBuffer(16)    'Expire time/date 1/1/2000
                                UTCseconds += 946684800
                                dtpExpTime.Value = TimeZoneInfo.ConvertTimeToUtc(UnixTimeStampToDateTime(UTCseconds))
                            End If
                            If receiveBuffer(3) > 13 Then
                                nudNextPrice.Value = (receiveBuffer(17) * 16777216) + (receiveBuffer(18) * 65536) + (receiveBuffer(19) * 256) + receiveBuffer(20)    'Next price
                            End If
                            If forceNak = True Then
                                Reset_state()
                            Else
                                PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 2
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 3
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = &H80
                                If rbMode1.Checked = True Then
                                    'This is a UCM
                                    If cbInterRespCode.SelectedIndex = 7 Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                Else
                                    'This is an SGD
                                    If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                End If
                                'Send responce
                                expectingResponse = False
                                pendingLinkAck = True
                                SendComData(xmitBuffer, 7, "Sent Set Energy Price Request Reply", pendingLinkAck)

                                'Clear Buffer
                                receiveIndex = 0
                            End If
                        End If
                    ElseIf receiveBuffer(5) = &H80 Then        'Get/Set Energy Price request reaponse
                        If receiveBuffer(6) < 8 Then
                            cbInterRespCodeRecv.SelectedIndex = receiveBuffer(6)
                        Else
                            cbInterRespCodeRecv.SelectedIndex = 8
                        End If
                        If receiveBuffer(2) = 0 And receiveBuffer(3) = 3 Then       'Set Energy Price request response
                            SendToLog(dispString, "Received a Set Energy Price request response")
                            ReceivedText(dispString, "Received a Set Energy Price request response")
                            PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                            SendLinkAck()
                            If forceNak = True Then
                                Reset_state()
                            Else
                                expectingResponse = False
                                'Clear Buffer
                                receiveIndex = 0
                            End If

                        ElseIf receiveBuffer(2) = 0 And receiveBuffer(3) > 3 Then   'Get Energy Price request response
                            SendToLog(dispString, "Received a Get Energy Price request response")
                            ReceivedText(dispString, "Received a Get Energy Price request response")
                            PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                            SendLinkAck()
                            nudCurrentPrice.Value = (receiveBuffer(7) * 16777216) + (receiveBuffer(8) * 65536) + (receiveBuffer(9) * 256) + receiveBuffer(10)     'Current price
                            nudCurrencyCode.Value = (receiveBuffer(11) * 256) + receiveBuffer(12)     'Currency code
                            nudDigitsAfterDecimal.Value = receiveBuffer(13)        'Digits after decimal
                            If receiveBuffer(3) > 10 Then
                                UTCseconds = (receiveBuffer(14) * 16777216) + (receiveBuffer(15) * 65536) + (receiveBuffer(16) * 256) + receiveBuffer(17)    'Expire time/date 1/1/2000
                                UTCseconds += 946684800
                                dtpExpTime.Value = TimeZoneInfo.ConvertTimeToUtc(UnixTimeStampToDateTime(UTCseconds))
                            End If
                            If receiveBuffer(3) > 14 Then
                                nudNextPrice.Value = (receiveBuffer(18) * 16777216) + (receiveBuffer(19) * 65536) + (receiveBuffer(20) * 256) + receiveBuffer(21)    'Next price
                            End If
                            If forceNak = True Then
                                Reset_state()
                            Else
                                expectingResponse = False
                                'Clear Buffer
                                receiveIndex = 0
                            End If

                        End If
                    ElseIf receiveBuffer(5) = 1 Then        'Get/Set Tier request
                        If receiveBuffer(2) = 0 And receiveBuffer(3) = 2 Then       'Get Energy Price request
                            'This is a Get Tier Request
                            SendToLog(dispString, "Received a Get Tier Request")
                            ReceivedText(dispString, "Received a Get Tier Request")
                            PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                            SendLinkAck()
                            If forceNak = True Then
                                Reset_state()
                            Else
                                'Build a dummy responce header
                                'This function is not yet supported but this code will return fixed data
                                PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 2
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 9
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = &H81
                                If rbMode1.Checked = True Then
                                    'This is a UCM
                                    If cbInterRespCode.SelectedIndex = 7 Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                Else
                                    'This is an SGD
                                    If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                End If
                                xmitBuffer(7) = &H2     'Current tier - 2
                                xmitBuffer(8) = &H1B   'Expire time/date 1/1/2000
                                xmitBuffer(9) = &HCE
                                xmitBuffer(10) = &H96
                                xmitBuffer(11) = &H5C
                                xmitBuffer(12) = &H4   'Next tier - 4
                                'Send responce
                                expectingResponse = False
                                pendingLinkAck = True
                                SendComData(xmitBuffer, 13, "Sent Get Tier Request Reply", pendingLinkAck)

                                'Clear Buffer
                                receiveIndex = 0
                            End If

                        ElseIf receiveBuffer(2) = 0 And receiveBuffer(3) > 2 Then   'Set Tier request
                            'This is a Set Energy Price Request
                            SendToLog(dispString, "Received a Set Tier Request")
                            ReceivedText(dispString, "Received a Set Tier Request")
                            PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                            SendLinkAck()
                            If forceNak = True Then
                                Reset_state()
                            Else
                                'Build a dummy responce header
                                'This function is not yet supported but this code will return fixed data
                                PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 2
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 3
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = &H81
                                If rbMode1.Checked = True Then
                                    'This is a UCM
                                    If cbInterRespCode.SelectedIndex = 7 Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                Else
                                    'This is an SGD
                                    If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                End If
                                'Send responce
                                expectingResponse = False
                                pendingLinkAck = True
                                SendComData(xmitBuffer, 7, "Sent Set Tier Request Reply", pendingLinkAck)

                                'Clear Buffer
                                receiveIndex = 0
                            End If
                        End If
                    ElseIf receiveBuffer(5) = &H81 Then        'Get/Set Tier request response
                        If receiveBuffer(6) < 8 Then
                            cbInterRespCodeRecv.SelectedIndex = receiveBuffer(6)
                        Else
                            cbInterRespCodeRecv.SelectedIndex = 8
                        End If
                        If receiveBuffer(2) = 0 And receiveBuffer(3) = 3 Then       'Set Tier request response
                            SendToLog(dispString, "Received a Set Tier request response")
                            ReceivedText(dispString, "Received a Set Tier request response")
                            PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                            SendLinkAck()
                            If forceNak = True Then
                                Reset_state()
                            Else
                                expectingResponse = False
                                'Clear Buffer
                                receiveIndex = 0
                            End If

                        ElseIf receiveBuffer(2) = 0 And receiveBuffer(3) > 3 Then   'Get Tier request response
                            SendToLog(dispString, "Received a Get Tier request response")
                            ReceivedText(dispString, "Received a Get Tier request response")
                            PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                            SendLinkAck()
                            If forceNak = True Then
                                Reset_state()
                            Else
                                expectingResponse = False
                                'Clear Buffer
                                receiveIndex = 0
                            End If

                        End If

                    End If

                    If receiveBuffer(5) = 2 And receiveBuffer(2) = 0 And receiveBuffer(3) = 2 Then        'Get Temperature Offset
                        'This is a Get Temperature Offset Request
                        SendToLog(dispString, "Received a Get Temperature Offset request")
                        ReceivedText(dispString, "Received a Get Temperature Offset Request")
                        PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            'Build a responce header
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 2
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 5
                            xmitBuffer(4) = 3
                            xmitBuffer(5) = &H82
                            If rbMode1.Checked = True Then
                                'This is a UCM
                                If cbInterRespCode.SelectedIndex = 7 Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            Else
                                'This is an SGD
                                If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            End If
                            'Get current offset
                            xmitBuffer(7) = nudTempOffset.Value And &HFF

                            'Get Units
                            If tempUnitC.Checked = True Then
                                xmitBuffer(8) = 1
                            Else
                                xmitBuffer(8) = 0
                            End If

                            'Send responce
                            expectingResponse = False
                            pendingLinkAck = True
                            SendComData(xmitBuffer, 9, "Sent Get Temperature Offset Reply", pendingLinkAck)

                            'Clear Buffer
                            receiveIndex = 0
                        End If

                    ElseIf receiveBuffer(5) = 2 And receiveBuffer(2) = 0 And receiveBuffer(3) = 4 Then        'Set Temperature Offset
                        'This is a Set Temperature Offset Request
                        SendToLog(dispString, "Received a Set Temperature Offset Request")
                        ReceivedText(dispString, "Received a Set Temperature Offset Request")
                        PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            'Interpret the data
                            'Get offset
                            tempint = receiveBuffer(6)
                            If tempint > &H7F Then tempint = -1 * (256 - tempint)
                            sgdCurrentTempOffset.Text = tempint

                            'Get Units
                            If receiveBuffer(7) = 1 Then
                                sgdTempUnits.Text = "Celsius"
                            Else
                                sgdTempUnits.Text = "Fahrenheit"
                            End If

                            'Build a responce header
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 2
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 3
                            xmitBuffer(4) = 3
                            xmitBuffer(5) = &H82
                            If rbMode1.Checked = True Then
                                'This is a UCM
                                If cbInterRespCode.SelectedIndex = 7 Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            Else
                                'This is an SGD
                                If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            End If
                            'Send responce
                            expectingResponse = False
                            pendingLinkAck = True
                            SendComData(xmitBuffer, 7, "Sent Set Temperature Offset Reply", pendingLinkAck)

                            'Clear Buffer
                            receiveIndex = 0
                        End If

                    ElseIf receiveBuffer(5) = &H82 And receiveBuffer(2) = 0 And receiveBuffer(3) = 5 Then        'Get Temperature Offset Reply
                        'This is a Get Temperature Offset Reply
                        If receiveBuffer(6) < 8 Then
                            cbInterRespCodeRecv.SelectedIndex = receiveBuffer(6)
                        Else
                            cbInterRespCodeRecv.SelectedIndex = 8
                        End If
                        SendToLog(dispString, "Received a Get Temperature Offset Reply")
                        ReceivedText(dispString, "Received a Get Temperature Offset Reply")
                        PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            'Interpret the data
                            'Get response code
                            tempint = receiveBuffer(6)
                            sgdTempRespCode.Text = receiveBuffer(6)

                            'Get offset
                            tempint = receiveBuffer(7)
                            If tempint > &H7F Then tempint = -1 * (256 - tempint)
                            sgdCurrentTempOffset.Text = tempint

                            'Get Units
                            If receiveBuffer(8) = 1 Then
                                sgdTempUnits.Text = "Celsius"
                            ElseIf receiveBuffer(8) = 0 Then
                                sgdTempUnits.Text = "Fahrenheit"
                            Else
                                sgdTempUnits.Text = "Invalid"
                            End If

                            'Clear Buffer
                            receiveIndex = 0
                        End If

                    ElseIf receiveBuffer(5) = &H82 And receiveBuffer(2) = 0 And receiveBuffer(3) = 3 Then        'Set Temperature Offset Reply
                        'This is a Set Temperature Offset Reply
                        If receiveBuffer(6) < 8 Then
                            cbInterRespCodeRecv.SelectedIndex = receiveBuffer(6)
                        Else
                            cbInterRespCodeRecv.SelectedIndex = 8
                        End If
                        SendToLog(dispString, "Received a Set Temperature Offset Reply")
                        ReceivedText(dispString, "Received a Set Temperature Offset Reply")
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            'Interpret the data
                            'Get response code
                            tempint = receiveBuffer(6)
                            sgdTempRespCode.Text = receiveBuffer(6)

                            'Clear Buffer
                            receiveIndex = 0
                        End If

                    ElseIf receiveBuffer(5) = 3 And receiveBuffer(2) = 0 And receiveBuffer(3) = 2 Then        'Get Setpoint Request
                        'This is a Get Setpoint Request
                        SendToLog(dispString, "Received a Get Setpoint Request")
                        ReceivedText(dispString, "Received a Get Setpoint Request")
                        PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            'Build a responce header
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 2
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 8
                            xmitBuffer(4) = 3
                            xmitBuffer(5) = &H83
                            If rbMode1.Checked = True Then
                                'This is a UCM
                                If cbInterRespCode.SelectedIndex = 7 Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            Else
                                'This is an SGD
                                If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            End If
                            'Device Type
                            xmitBuffer(7) = (nudSetpointDeviceType.Value >> 8) And &HFF
                            xmitBuffer(8) = nudSetpointDeviceType.Value And &HFF

                            'Get Units
                            If tempUnitC.Checked = True Then
                                xmitBuffer(9) = 1
                            Else
                                xmitBuffer(9) = 0
                            End If

                            'Get setpoint1
                            xmitBuffer(10) = (nudSetPoint1.Value >> 8) And &HFF
                            xmitBuffer(11) = nudSetPoint1.Value And &HFF

                            If cbSetpoint2Support.Checked = True Then
                                'Get setpoint2
                                xmitBuffer(12) = (nudSetPoint2.Value >> 8) And &HFF
                                xmitBuffer(13) = nudSetPoint2.Value And &HFF
                                xmitBuffer(3) = 10

                                'Send responce
                                SendComData(xmitBuffer, 14, "Sent Get Setpoint Reply", pendingLinkAck)
                            Else
                                'Send responce
                                SendComData(xmitBuffer, 12, "Sent Get Setpoint Reply", pendingLinkAck)
                            End If

                            'Send responce
                            expectingResponse = False
                            pendingLinkAck = True
                            'Clear Buffer
                            receiveIndex = 0
                        End If

                    ElseIf receiveBuffer(5) = 3 And receiveBuffer(2) = 0 And (receiveBuffer(3) = 7 Or receiveBuffer(3) = 9) Then        'Set Setpoint Request
                        'This is a Set Setpoint Request
                        SendToLog(dispString, "Received a Set Setpoint Request")
                        ReceivedText(dispString, "Received a Set Setpoint Request")
                        PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            'Display Device Type
                            tbSgdDeviceType.Text = Convert.ToString(((receiveBuffer(6) * 256) + receiveBuffer(7)), 16).PadLeft(4, "0"c).ToUpper

                            'Display Units
                            If receiveBuffer(8) = 1 Then
                                sgdTempUnits.Text = "Celsius"
                            ElseIf receiveBuffer(8) = 0 Then
                                sgdTempUnits.Text = "Fahrenheit"
                            Else
                                sgdTempUnits.Text = "Invalid"
                            End If

                            'Display Setpoint1
                            If receiveBuffer(9) > &H7F Then
                                'Setpoint is negative
                                tempint = 0
                                tempint = (255 - receiveBuffer(9)) * 256
                                tempint = tempint + (256 - receiveBuffer(10))
                                tempint = tempint * (-1)
                            Else
                                'Setpoint is positive
                                tempint = (receiveBuffer(9) * 256) + receiveBuffer(10)
                            End If
                            If tempint = -32768 Then
                                sgdSetPoint1.Text = "Don't Change"
                            Else
                                sgdSetPoint1.Text = tempint
                            End If

                            'Display Setpoint2
                            If receiveBuffer(3) = 9 Then
                                'Display received setpoint2
                                If receiveBuffer(11) > &H7F Then
                                    'Setpoint is negative
                                    tempint = 0
                                    tempint = (255 - receiveBuffer(11)) * 256
                                    tempint = tempint + (256 - receiveBuffer(12))
                                    tempint = tempint * (-1)
                                Else
                                    'Setpoint is positive
                                    tempint = (receiveBuffer(11) * 256) + receiveBuffer(12)
                                End If
                                If tempint = -32768 Then
                                    sgdSetPoint2.Text = "Don't Change"
                                Else
                                    sgdSetPoint2.Text = tempint
                                End If
                            End If

                            'Build a responce header
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 2
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 3
                            xmitBuffer(4) = 3
                            xmitBuffer(5) = &H83
                            If rbMode1.Checked = True Then
                                'This is a UCM
                                If cbInterRespCode.SelectedIndex = 7 Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            Else
                                'This is an SGD
                                If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            End If
                            'Send responce
                            expectingResponse = False
                            pendingLinkAck = True
                            SendComData(xmitBuffer, 7, "Sent Set Setpoint Reply", pendingLinkAck)

                            'Clear Buffer
                            receiveIndex = 0
                        End If

                    ElseIf receiveBuffer(5) = &H83 And receiveBuffer(2) = 0 And (receiveBuffer(3) = 8 Or receiveBuffer(3) = 10) Then        'Get Setpoint Reply
                        'This is a Set Setpoint Reply
                        If receiveBuffer(6) < 8 Then
                            cbInterRespCodeRecv.SelectedIndex = receiveBuffer(6)
                        Else
                            cbInterRespCodeRecv.SelectedIndex = 8
                        End If
                        SendToLog(dispString, "Received a Get Setpoint Reply")
                        ReceivedText(dispString, "Received a Get Setpoint Reply")
                        PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            'Display Response Code
                            tbSetpointResponseCode.Text = receiveBuffer(6)

                            'Display Device Type
                            tbSgdDeviceType.Text = Convert.ToString(((receiveBuffer(7) * 256) + receiveBuffer(8)), 16).PadLeft(4, "0"c).ToUpper

                            'Display Units
                            If receiveBuffer(9) = 1 Then
                                sgdTempUnits.Text = "Celsius"
                            ElseIf receiveBuffer(9) = 0 Then
                                sgdTempUnits.Text = "Fahrenheit"
                            Else
                                sgdTempUnits.Text = "Invalid"
                            End If

                            'Display Setpoint1
                            If receiveBuffer(10) > &H7F Then
                                'Setpoint is negative
                                tempint = 0
                                tempint = (255 - receiveBuffer(10)) * 256
                                tempint = tempint + (256 - receiveBuffer(11))
                                tempint = tempint * (-1)
                            Else
                                'Setpoint is positive
                                tempint = (receiveBuffer(10) * 256) + receiveBuffer(11)
                            End If
                            If tempint <= -32768 Then
                                sgdSetPoint1.Text = "Don't Change"
                            Else
                                sgdSetPoint1.Text = tempint
                            End If

                            'Display Setpoint2
                            If receiveBuffer(3) = 10 Then
                                'Display received setpoint2
                                If receiveBuffer(12) > &H7F Then
                                    'Setpoint is negative
                                    tempint = 0
                                    tempint = (255 - receiveBuffer(12)) * 256
                                    tempint = tempint + (256 - receiveBuffer(13))
                                    tempint = tempint * (-1)
                                Else
                                    'Setpoint is positive
                                    tempint = (receiveBuffer(12) * 256) + receiveBuffer(13)
                                End If
                                If tempint = -32768 Then
                                    sgdSetPoint2.Text = "Don't Change"
                                Else
                                    sgdSetPoint2.Text = tempint
                                End If
                            End If

                            expectingResponse = False
                            pendingLinkAck = False
                            'Clear Buffer
                            receiveIndex = 0
                        End If

                    ElseIf receiveBuffer(5) = &H83 And receiveBuffer(2) = 0 And receiveBuffer(3) = 3 Then        'Set Setpoint Reply
                        'This is a Set Setpoint Reply
                        If receiveBuffer(6) < 8 Then
                            cbInterRespCodeRecv.SelectedIndex = receiveBuffer(6)
                        Else
                            cbInterRespCodeRecv.SelectedIndex = 8
                        End If
                        SendToLog(dispString, "Received a Set Setpoint Reply")
                        ReceivedText(dispString, "Received a Set Setpoint Reply")
                        PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            tbSetpointResponseCode.Text = receiveBuffer(6)
                            expectingResponse = False
                            pendingLinkAck = False
                        End If

                    ElseIf receiveBuffer(5) = 4 And receiveBuffer(2) = 0 And receiveBuffer(3) = 2 Then        'Get Present Temperature Request
                        'This is a Get Present Temperature Request
                        SendToLog(dispString, "Received a Get Present Temperature Request")
                        ReceivedText(dispString, "Received a Get Present Temperature Request")
                        PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            'Build a responce header
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 2
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 8
                            xmitBuffer(4) = 3
                            xmitBuffer(5) = &H84
                            If rbMode1.Checked = True Then
                                'This is a UCM
                                If cbInterRespCode.SelectedIndex = 7 Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            Else
                                'This is an SGD
                                If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            End If
                            'Device Type
                            xmitBuffer(7) = (nudSetpointDeviceType.Value >> 8) And &HFF
                            xmitBuffer(8) = nudSetpointDeviceType.Value And &HFF

                            'Get Units
                            If tempUnitC.Checked = True Then
                                xmitBuffer(9) = 1
                            Else
                                xmitBuffer(9) = 0
                            End If

                            'Get present temperature
                            xmitBuffer(10) = (nudPresentTemp.Value >> 8) And &HFF
                            xmitBuffer(11) = nudPresentTemp.Value And &HFF

                            SendComData(xmitBuffer, 12, "Sent Get Present Temperature Reply", pendingLinkAck)

                            'Send responce
                            expectingResponse = False
                            pendingLinkAck = True
                            'Clear Buffer
                            receiveIndex = 0
                        End If

                    ElseIf receiveBuffer(5) = &H84 And receiveBuffer(2) = 0 And receiveBuffer(3) = 8 Then        'Get Present Temperature Reply
                        'This is a Get Present Temperature Reply
                        If receiveBuffer(6) < 8 Then
                            cbInterRespCodeRecv.SelectedIndex = receiveBuffer(6)
                        Else
                            cbInterRespCodeRecv.SelectedIndex = 8
                        End If
                        SendToLog(dispString, "Received a Get Present Temperature Reply")
                        ReceivedText(dispString, "Received a Get Present Temperature Reply")
                        PauseMS(tMAValBox.Value)      'Wait 40ms before sending Link Ack
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            tbResponseCode2.Text = receiveBuffer(6)
                            tbSgdDeviceType.Text = Convert.ToString(((receiveBuffer(7) * 256) + receiveBuffer(8)), 16).PadLeft(4, "0"c).ToUpper
                            If receiveBuffer(9) = 0 Then
                                sgdTempUnits.Text = "Fahrenheit"
                            Else
                                sgdTempUnits.Text = "Celsius"
                            End If
                            tbPresentTemp.Text = receiveBuffer(10) * 256 + receiveBuffer(11)
                            expectingResponse = False
                            pendingLinkAck = False
                        End If
                    End If

                Case 4
                    If receiveBuffer(5) = 0 Then    'receiveBuffer(2) = 0
                        'This is a request to start Autonomous Cycling
                        SendToLog(dispString, "Received a request to start Autonomous Cycling")
                        ReceivedText(dispString, "Received a request to start Autonomous Cycling")
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            receiveIndex = 0

                            'Send reply
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 2
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 3
                            xmitBuffer(4) = &H4
                            xmitBuffer(5) = &H80
                            If rbMode1.Checked = True Then
                                'This is a UCM
                                If cbInterRespCode.SelectedIndex = 7 Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            Else
                                'This is an SGD
                                If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            End If
                            pendingLinkAck = True
                            SendComData(xmitBuffer, 7, "Sent Autonomous Cycling Response", pendingLinkAck)
                        End If

                    ElseIf receiveBuffer(5) = 1 Then    'receiveBuffer(2) = 0
                        'This is a request to end Autonomous Cycling 
                        SendToLog(dispString, "Received a request to end Autonomous Cycling")
                        ReceivedText(dispString, "Received a request to end Autonomous Cycling")
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            receiveIndex = 0

                            'Send reply
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 2
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 3
                            xmitBuffer(4) = &H4
                            xmitBuffer(5) = &H81
                            If rbMode1.Checked = True Then
                                'This is a UCM
                                If cbInterRespCode.SelectedIndex = 7 Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            Else
                                'This is an SGD
                                If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            End If
                            pendingLinkAck = True
                            SendComData(xmitBuffer, 7, "Sent Response to End Autonomous Cycling Command", pendingLinkAck)
                        End If

                    ElseIf receiveBuffer(5) = &H80 Then     'receiveBuffer(2) = 0 And receiveBuffer(3) = 3 
                        'This is a reply to a start Autonomous Cycling Request
                        If receiveBuffer(6) < 8 Then
                            cbInterRespCodeRecv.SelectedIndex = receiveBuffer(6)
                        Else
                            cbInterRespCodeRecv.SelectedIndex = 8
                        End If
                        SendToLog(dispString, "Received a reply to a Start Autonomous Cycling Request")
                        ReceivedText(dispString, "Received a reply to a Start Autonomous Cycling Request")
                        SendLinkAck()

                        receiveIndex = 0

                    ElseIf receiveBuffer(5) = &H81 Then     'receiveBuffer(2) = 0 And receiveBuffer(3) = 3
                        'This is a reply to a stop Autonomous Cycling Request
                        If receiveBuffer(6) < 8 Then
                            cbInterRespCodeRecv.SelectedIndex = receiveBuffer(6)
                        Else
                            cbInterRespCodeRecv.SelectedIndex = 8
                        End If
                        SendToLog(dispString, "Received a Stop Autonomous Cycling Request Reply")
                        ReceivedText(dispString, "Received a Stop Autonomous Cycling Request Reply")
                        SendLinkAck()

                        receiveIndex = 0
                    End If

                Case 5

                Case 6
                    If receiveBuffer(5) = 0 Then
                        If receiveBuffer(2) = 0 And receiveBuffer(3) < 4 Then
                            'This is a get commodity read request
                            SendToLog(dispString, "Received a Get Commodity Read Request")
                            ReceivedText(dispString, "Received a Get Commodity Read Request")
                            SendLinkAck()
                            If forceNak = True Then
                                Reset_state()
                            Else
                                receiveIndex = 0

                                'Send reply
                                PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 2
                                xmitBuffer(4) = &H6
                                xmitBuffer(5) = &H80
                                If rbMode1.Checked = True Then
                                    'This is a UCM
                                    If cbInterRespCode.SelectedIndex = 7 Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                Else
                                    'This is an SGD
                                    If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                End If
                                j = 0
                                If receiveBuffer(3) = 2 Then
                                    For i = 0 To 9
                                        If commodityArray(i).supported = True Then
                                            If commodityArray(i).estimated = True Then
                                                xmitBuffer(j * 13 + 7) = i
                                            Else
                                                xmitBuffer(j * 13 + 7) = i + &H80
                                            End If
                                            xmitBuffer(j * 13 + 13) = commodityArray(i).instRate And &HFF
                                            xmitBuffer(j * 13 + 12) = (commodityArray(i).instRate >> 8) And &HFF
                                            xmitBuffer(j * 13 + 11) = (commodityArray(i).instRate >> 16) And &HFF
                                            xmitBuffer(j * 13 + 10) = (commodityArray(i).instRate >> 24) And &HFF
                                            xmitBuffer(j * 13 + 9) = (commodityArray(i).instRate >> 32) And &HFF
                                            xmitBuffer(j * 13 + 8) = (commodityArray(i).instRate >> 40) And &HFF
                                            xmitBuffer(j * 13 + 19) = commodityArray(i).cumAmount And &HFF
                                            xmitBuffer(j * 13 + 18) = (commodityArray(i).cumAmount >> 8) And &HFF
                                            xmitBuffer(j * 13 + 17) = (commodityArray(i).cumAmount >> 16) And &HFF
                                            xmitBuffer(j * 13 + 16) = (commodityArray(i).cumAmount >> 24) And &HFF
                                            xmitBuffer(j * 13 + 15) = (commodityArray(i).cumAmount >> 32) And &HFF
                                            xmitBuffer(j * 13 + 14) = (commodityArray(i).cumAmount >> 40) And &HFF
                                            j += 1
                                        End If
                                    Next i
                                Else
                                    If commodityArray(receiveBuffer(6)).supported = True Then
                                        i = receiveBuffer(6)
                                        If commodityArray(i).estimated = True Then
                                            xmitBuffer(j * 13 + 7) = i
                                        Else
                                            xmitBuffer(j * 13 + 7) = i + &H80
                                        End If
                                        xmitBuffer(j * 13 + 13) = commodityArray(i).instRate And &HFF
                                        xmitBuffer(j * 13 + 12) = (commodityArray(i).instRate >> 8) And &HFF
                                        xmitBuffer(j * 13 + 11) = (commodityArray(i).instRate >> 16) And &HFF
                                        xmitBuffer(j * 13 + 10) = (commodityArray(i).instRate >> 24) And &HFF
                                        xmitBuffer(j * 13 + 9) = (commodityArray(i).instRate >> 32) And &HFF
                                        xmitBuffer(j * 13 + 8) = (commodityArray(i).instRate >> 40) And &HFF
                                        xmitBuffer(j * 13 + 19) = commodityArray(i).cumAmount And &HFF
                                        xmitBuffer(j * 13 + 18) = (commodityArray(i).cumAmount >> 8) And &HFF
                                        xmitBuffer(j * 13 + 17) = (commodityArray(i).cumAmount >> 16) And &HFF
                                        xmitBuffer(j * 13 + 16) = (commodityArray(i).cumAmount >> 24) And &HFF
                                        xmitBuffer(j * 13 + 15) = (commodityArray(i).cumAmount >> 32) And &HFF
                                        xmitBuffer(j * 13 + 14) = (commodityArray(i).cumAmount >> 40) And &HFF
                                        j = 1
                                    End If
                                End If
                                If j = 0 Then
                                    xmitBuffer(6) = 2           'Response Code data error
                                End If
                                i = j * 13 + 3      'Calculate payload size
                                xmitBuffer(2) = (i >> 8) And &HFF
                                xmitBuffer(3) = i And &HFF
                                pendingLinkAck = True
                                SendComData(xmitBuffer, i + 4, "Sent Commodity Read Response", pendingLinkAck)
                            End If

                        Else
                            'This is a set commodity read request
                            SendToLog(dispString, "Received a Set Commodity Request")
                            ReceivedText(dispString, "Received a Set Commodity Request")
                            SendLinkAck()
                            If forceNak = True Then
                                Reset_state()
                            Else
                                j = receiveBuffer(3) - 2        'Calculate the number of records
                                j = j / 13
                                For i = 0 To (j - 1)
                                    indexVal = receiveBuffer((i * 13) + 6) And &H7F
                                    commodityArray(indexVal).estimated = True
                                    If receiveBuffer((i * 13) + 6) > &H7F Then commodityArray(indexVal).estimated = False
                                    commodityArray(indexVal).supported = True
                                    tempLong = receiveBuffer((i * 13) + 12)
                                    tempLong2 = receiveBuffer((i * 13) + 11)
                                    tempLong3 = 256
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 10)
                                    tempLong3 = 65536
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 9)
                                    tempLong3 = 16777216
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 8)
                                    tempLong3 = 4294967296
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 7)
                                    tempLong3 = 1099511627776
                                    tempLong += tempLong2 * tempLong3
                                    commodityArray(indexVal).instRate = tempLong
                                    tempLong = receiveBuffer((i * 13) + 18)
                                    tempLong2 = receiveBuffer((i * 13) + 17)
                                    tempLong3 = 256
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 16)
                                    tempLong3 = 65536
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 15)
                                    tempLong3 = 16777216
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 14)
                                    tempLong3 = 4294967296
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 13)
                                    tempLong3 = 1099511627776
                                    tempLong += tempLong2 * tempLong3
                                    commodityArray(indexVal).cumAmount = tempLong
                                Next
                                receiveIndex = 0
                                'Send reply
                                PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 2
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 3
                                xmitBuffer(4) = &H6
                                xmitBuffer(5) = &H80
                                If rbMode1.Checked = True Then
                                    'This is a UCM
                                    If cbInterRespCode.SelectedIndex = 7 Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                Else
                                    'This is an SGD
                                    If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                        xmitBuffer(6) = 0           'Response code
                                    Else
                                        xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                    End If
                                End If
                                pendingLinkAck = True
                                SendComData(xmitBuffer, 7, "Sent Set Commodity Response", pendingLinkAck)
                                ReceivedText("", "Received a Set Commodity Read Request.")
                                LbCommodityCode_SelectedIndexChanged(Ex_sender, Ex_e)
                            End If
                        End If

                    ElseIf receiveBuffer(5) = &H1 And receiveBuffer(2) = 0 And receiveBuffer(3) = 2 Then
                        'This is a get commodity subscription request
                        SendToLog(dispString, "Received a Get Commodity Subscription Request")
                        ReceivedText(dispString, "Received a Get Commodity Subscription Request")
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            receiveIndex = 0

                            'Send reply
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 2
                            xmitBuffer(4) = &H6
                            xmitBuffer(5) = &H81
                            j = 0
                            xmitBuffer(6) = 0       'Response Code
                            For i = 0 To 9
                                If commodityArray(i).supported = True Then
                                    xmitBuffer(j * 3 + 7) = i       'Commodity type supported
                                    xmitBuffer(j * 3 + 9) = commodityArray(i).updateFreq And &HFF
                                    xmitBuffer(j * 3 + 8) = (commodityArray(i).updateFreq >> 8) And &HFF
                                    j += 1
                                End If
                            Next i
                            i = j * 3 + 3      'Calculate payload size
                            xmitBuffer(2) = (i >> 8) And &HFF
                            xmitBuffer(3) = i And &HFF
                            If j > 0 Then
                                xmitBuffer(6) = 0       'Response Code success
                            Else
                                xmitBuffer(6) = 2       'Response Code bad data
                            End If
                            pendingLinkAck = True
                            SendComData(xmitBuffer, i + 4, "Sent Response to Get Commodity Subscription Request", pendingLinkAck)
                        End If

                    ElseIf receiveBuffer(5) = &H1 And receiveBuffer(2) = 0 And receiveBuffer(3) >= 5 Then
                        'This is a set commodity subscription request
                        SendToLog(dispString, "Received a Set Commodity Subscription Request")
                        ReceivedText(dispString, "Received a Set Commodity Subscription Request")
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            j = receiveBuffer(2) * 256 + receiveBuffer(3)     'Calculate payload size
                            j = (j - 2) / 3                                   'Calculate number of entries
                            'xmitBuffer(6) = 0       'Set the response code to success
                            For i = 0 To 9       'Clear the subscription frequency and the subscriptReq for all entries
                                commodityArray(i).updateFreq = 0
                                'commodityArray(i).subscriptReq = False
                            Next i

                            For i = 0 To (j - 1)
                                commodityArray(receiveBuffer((i * 3) + 6)).updateFreq = (receiveBuffer((i * 3) + 7) * 256) + receiveBuffer((i * 3) + 8)
                                'commodityArray(receiveBuffer((i * 3) + 6)).subscriptReq = True
                                commodityArray(receiveBuffer((i * 3) + 6)).supported = True
                            Next i
                            receiveIndex = 0
                            'Send reply
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 2
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 3
                            xmitBuffer(4) = &H6
                            xmitBuffer(5) = &H81
                            If rbMode1.Checked = True Then
                                'This is a UCM
                                If cbInterRespCode.SelectedIndex = 7 Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            Else
                                'This is an SGD
                                If cbInterRespCode.SelectedIndex = 7 And chkCustOverride.Checked = False Then
                                    xmitBuffer(6) = 0           'Response code
                                Else
                                    xmitBuffer(6) = cbInterRespCode.SelectedIndex           'Response code
                                End If
                            End If
                            pendingLinkAck = True
                            SendComData(xmitBuffer, 7, "Sent Response to Set Commodity Subsciption Request", pendingLinkAck)
                        End If

                    ElseIf receiveBuffer(5) = &H80 Then
                        If receiveBuffer(2) = 0 And receiveBuffer(3) = 2 Then
                            'This is a set commodity read reply with an empty result set
                            SendToLog(dispString, "Received a Set Commodity Read Reply with an empty result set")
                            ReceivedText(dispString, "Received a Set Commodity Read Reply with an empty result set")
                            SendLinkAck()
                            receiveIndex = 0
                        ElseIf receiveBuffer(2) = 0 And receiveBuffer(3) = 3 Then
                            'This is a set commodity read reply
                            SendToLog(dispString, "Received a Set Commodity Read Reply")
                            ReceivedText(dispString, "Received a Set Commodity Read Reply")
                            SendLinkAck()
                            receiveIndex = 0
                        ElseIf (receiveBuffer(2) * 256 + receiveBuffer(3)) > 3 Then
                            'This is a get commodity read reply
                            SendToLog(dispString, "Received a Get Commodity Read Reply")
                            ReceivedText(dispString, "Received a Get Commodity Read Reply")
                            SendLinkAck()
                            If forceNak = True Then
                                Reset_state()
                            Else
                                j = receiveBuffer(3) - 3        'Calculate the number of records
                                j = j / 13
                                For i = 0 To (j - 1)
                                    indexVal = receiveBuffer((i * 13) + 7) And &H7F
                                    commodityArray2(indexVal).estimated = True
                                    If receiveBuffer((i * 13) + 7) > &H7F Then commodityArray2(indexVal).estimated = False
                                    commodityArray2(indexVal).supported = True
                                    tempLong = receiveBuffer((i * 13) + 13)
                                    tempLong2 = receiveBuffer((i * 13) + 12)
                                    tempLong3 = 256
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 11)
                                    tempLong3 = 65536
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 10)
                                    tempLong3 = 16777216
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 9)
                                    tempLong3 = 4294967296
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 8)
                                    tempLong3 = 1099511627776
                                    tempLong += tempLong2 * tempLong3
                                    commodityArray2(indexVal).instRate = tempLong
                                    tempLong = receiveBuffer((i * 13) + 19)
                                    tempLong2 = receiveBuffer((i * 13) + 18)
                                    tempLong3 = 256
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 17)
                                    tempLong3 = 65536
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 16)
                                    tempLong3 = 16777216
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 15)
                                    tempLong3 = 4294967296
                                    tempLong += tempLong2 * tempLong3
                                    tempLong2 = receiveBuffer((i * 13) + 14)
                                    tempLong3 = 1099511627776
                                    tempLong += tempLong2 * tempLong3
                                    commodityArray2(indexVal).cumAmount = tempLong
                                Next

                                'updates fields when values are received
                                tbCommodityRate.Text = commodityArray2(lbCommodityCode1.SelectedIndex).instRate
                                tbCommodityAmount.Text = commodityArray2(lbCommodityCode1.SelectedIndex).cumAmount
                                cbCommoditySupported1.Checked = commodityArray2(lbCommodityCode1.SelectedIndex).supported
                                cbEstimated1.Checked = commodityArray2(lbCommodityCode1.SelectedIndex).estimated
                                tbCommodityFreq.Text = commodityArray2(lbCommodityCode1.SelectedIndex).updateFreq
                                'logs commodity if checked
                                If CommodityLogChkBox.Checked = True Then
                                    LogCommodity()
                                End If

                                'add commodities to graph data
                                If CommodityChart.PauseCommodityGrphBTN.Text.ToLower() = "pause" Then
                                    GraphCommodityUpdate()
                                End If

                                ReceivedText("", "Get Commodity Read Reply received")
                                LbCommodityCode_SelectedIndexChanged(Ex_sender, Ex_e)   'simulate an index change to refresh values
                                receiveIndex = 0
                            End If
                        End If

                    ElseIf receiveBuffer(5) = &H81 And receiveBuffer(2) = 0 And receiveBuffer(3) = 3 Then
                        'This is a set commodity subscription request reply
                        If receiveBuffer(6) < 8 Then
                            cbInterRespCodeRecv.SelectedIndex = receiveBuffer(6)
                        Else
                            cbInterRespCodeRecv.SelectedIndex = 8
                        End If
                        SendToLog(dispString, "Received Set Commodity Subscription Request Reply")
                        ReceivedText(dispString, "Received Set Commodity Subscription Request Reply")
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            If receiveBuffer(6) = 0 Or receiveBuffer(6) = 7 Then
                                ReceivedText("", "Set Commodity Subscription Reply received")
                            Else
                                ReceivedText("", "Get Commodity Subscription Reply Error received: " & receiveBuffer(6))
                            End If
                            receiveIndex = 0
                        End If

                    ElseIf receiveBuffer(5) = &H81 And receiveBuffer(2) = 0 And receiveBuffer(3) >= 6 Then
                        'This is a get commodity subscription request reply
                        SendToLog(dispString, "Received a Get Commodity Subscription Request Reply")
                        ReceivedText(dispString, "Received a Get Commodity Subscription Request Reply")
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            If receiveBuffer(6) = 0 Then
                                ReceivedText("", "Get Commodity Subscription Reply received")
                            Else
                                ReceivedText("", "Get Commodity Subscription Reply Error received: " & receiveBuffer(6))
                            End If
                            j = receiveBuffer(3) - 3        'Calculate the number of records
                            j = j / 3
                            For i = 0 To (j - 1)
                                indexVal = receiveBuffer((i * 3) + 7)
                                commodityArray2(indexVal).supported = True
                                commodityArray2(indexVal).updateFreq = receiveBuffer((i * 3) + 9) + (receiveBuffer((i * 3) + 8) * 256)
                            Next
                            receiveIndex = 0
                        End If
                    End If

                Case &HA    'Get/Set Activation Status
                    If receiveBuffer(5) = 0 Then        'Get Activation Status
                        SendToLog(dispString, "Received a Get Activation Status")
                        ReceivedText(dispString, "Received a Get Activation Status")
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            receiveIndex = 0
                            'Send reply
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 2
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 4
                            xmitBuffer(4) = &HA
                            xmitBuffer(5) = &H80
                            xmitBuffer(6) = receiveBuffer(6)
                            xmitBuffer(7) = actStatus(receiveBuffer(6))
                            pendingLinkAck = True
                            SendComData(xmitBuffer, 8, "Sent Get Activation Status Response", pendingLinkAck)
                        End If

                    ElseIf receiveBuffer(5) = 1 Then        'Set Activation Status
                        'This is a request to Set Activation Status 
                        SendToLog(dispString, "Received a request to Set Activation Status")
                        ReceivedText(dispString, "Received a request to Set Activation Status")
                        SendLinkAck()
                        actStatus(receiveBuffer(6)) = receiveBuffer(7)
                        nudActIndex.Value = receiveBuffer(6)
                        nudActStatus.Value = receiveBuffer(7)
                        tbActivateKey.Text = ""
                        If receiveBuffer(3) > 4 Then
                            For i = 0 To (receiveBuffer(3) - 5)
                                tbActivateKey.Text = tbActivateKey.Text & Chr(receiveBuffer(8 + i))
                            Next
                        End If
                        If forceNak = True Then
                            Reset_state()
                        Else
                            receiveIndex = 0

                            'Send reply
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 2
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 4
                            xmitBuffer(4) = &HA
                            xmitBuffer(5) = &H81
                            xmitBuffer(6) = receiveBuffer(6)
                            xmitBuffer(7) = cbActResponse.SelectedIndex
                            pendingLinkAck = True
                            SendComData(xmitBuffer, 8, "Sent Response to End Autonomous Cycling Command", pendingLinkAck)
                        End If

                    ElseIf receiveBuffer(5) = &H80 Then
                        'This is a reply to a Get Activation Status Request
                        SendToLog(dispString, "Received a Get User Preference Level reply")
                        ReceivedText(dispString, "Received a Get User Preference Level reply")
                        preference(receiveBuffer(6)) = receiveBuffer(7)
                        nudActIndex.Value = receiveBuffer(6)
                        nudActStatus.Value = receiveBuffer(7)
                        SendLinkAck()
                        receiveIndex = 0

                    ElseIf receiveBuffer(5) = &H81 Then
                        'This is a reply to a Set Activation Status Request
                        SendToLog(dispString, "Received a Set Activation Status Request reply")
                        ReceivedText(dispString, "Received a Set Activation Status Request reply")
                        nudActIndex.Value = receiveBuffer(6)
                        If receiveBuffer(7) < 8 Then
                            cbActResponse.SelectedIndex = receiveBuffer(7)
                        Else
                            cbActResponse.SelectedIndex = 8
                        End If
                        SendLinkAck()
                        receiveIndex = 0
                    End If

                Case &HB    'Get/Set User Preference Level
                    If receiveBuffer(5) = 0 Then        'Get User Preference Level
                        SendToLog(dispString, "Received a Get User Preference Level")
                        ReceivedText(dispString, "Received a Get User Preference Level")
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            receiveIndex = 0
                            'Send reply
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 2
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 4
                            xmitBuffer(4) = &HB
                            xmitBuffer(5) = &H80
                            xmitBuffer(6) = receiveBuffer(6)
                            xmitBuffer(7) = preference(receiveBuffer(6))
                            pendingLinkAck = True
                            SendComData(xmitBuffer, 8, "Sent Get User Preference Level Response", pendingLinkAck)
                        End If

                    ElseIf receiveBuffer(5) = 1 Then        'Set User Preference Level
                        'This is a request to Set User Preference Level 
                        SendToLog(dispString, "Received a request to Set User Preference Level")
                        ReceivedText(dispString, "Received a request to Set User Preference Level")
                        SendLinkAck()
                        preference(receiveBuffer(6)) = receiveBuffer(7)
                        nudPrefType.Value = receiveBuffer(6)
                        nudPrefLevel.Value = receiveBuffer(7)
                        If forceNak = True Then
                            Reset_state()
                        Else
                            receiveIndex = 0

                            'Send reply
                            PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 2
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 4
                            xmitBuffer(4) = &HB
                            xmitBuffer(5) = &H81
                            xmitBuffer(6) = nudPrefType.Value
                            xmitBuffer(7) = nudPrefLevel.Value
                            pendingLinkAck = True
                            SendComData(xmitBuffer, 8, "Sent Response to End Autonomous Cycling Command", pendingLinkAck)
                        End If

                    ElseIf receiveBuffer(5) = &H80 Then
                        'This is a reply to a Get User Preference Level Request
                        SendToLog(dispString, "Received a Get User Preference Level reply")
                        ReceivedText(dispString, "Received a Get User Preference Level reply")
                        preference(receiveBuffer(6)) = receiveBuffer(7)
                        nudPrefType.Value = receiveBuffer(6)
                        nudPrefLevel.Value = receiveBuffer(7)
                        SendLinkAck()
                        receiveIndex = 0

                    ElseIf receiveBuffer(5) = &H81 Then
                        'This is a reply to a Set User Preference Level Request
                        SendToLog(dispString, "Received a Set User Preference Level reply")
                        ReceivedText(dispString, "Received a Set User Preference Level reply")
                        nudPrefType.Value = receiveBuffer(6)
                        nudPrefLevel.Value = receiveBuffer(7)
                        SendLinkAck()
                        receiveIndex = 0
                    End If

                Case Else       'Invalid opcode 2
                    'Future create error handler
            End Select
        End If
    End Sub

    'Processes Data Link Message
    Private Sub ProcessDataLinkMsg(ByVal dispString As String)

        Dim xmitBuffer(8) As Byte

        Select Case receiveBuffer(4)
            Case &H16               'This is a request different power mode
                ReceivedText(dispString, "Request different power mode received")
                SendToLog(dispString, "Request different power mode received")
                If cbPowerLimit.Checked = True Then
                    If receiveBuffer(5) < 6 Then
                        nudPowerLimit.Value = receiveBuffer(5)
                        SendLinkAck()
                    Else
                        SendLinkNak(1)      'Invalid byte
                    End If
                Else
                    SendLinkNak(7)      'Request not supported
                End If
                Reset_state()
            Case &H17
                ReceivedText(dispString, "Received Change Baud request")
                SendToLog(dispString, "Received change baud request")
                pendingLinkAck = True  'Set the pendingLinkAck to true
                SendLinkAck()
                If forceNak = True Then
                    Reset_state()
                Else
                    SerialPort1.Close()             'Close our Serial Port
                    Select Case receiveBuffer(5)
                        Case 0
                            'Now change the baud rate selected in the CmbBaud comboBox
                            ChangeBaud("19200")
                            'Last perform same function as connect button
                            SerialPort1.BaudRate = "19200"         'Set Baud rate to the selected value on
                        Case 1
                            'Now change the baud rate selected in the CmbBaud comboBox
                            ChangeBaud("38400")
                            'Last perform same function as connect button
                            SerialPort1.BaudRate = "38400"         'Set Baud rate to the selected value on
                        Case 2
                            'Now change the baud rate selected in the CmbBaud comboBox
                            ChangeBaud("57600")
                            'Last perform same function as connect button
                            SerialPort1.BaudRate = "57600"         'Set Baud rate to the selected value on
                        Case 3
                            'Now change the baud rate selected in the CmbBaud comboBox
                            ChangeBaud("115200")
                            'Last perform same function as connect button
                            SerialPort1.BaudRate = "115200"         'Set Baud rate to the selected value on
                        Case 4
                            'Now change the baud rate selected in the CmbBaud comboBox
                            ChangeBaud("230400")
                            'SerialPort1.PortName = CmbPort.Text         'Set SerialPort1 to the selected COM port at startup
                            SerialPort1.BaudRate = "230400"         'Set Baud rate to the selected value on
                        Case 5
                            'Now change the baud rate selected in the CmbBaud comboBox
                            ChangeBaud("460800")
                            'SerialPort1.PortName = CmbPort.Text         'Set SerialPort1 to the selected COM port at startup
                            SerialPort1.BaudRate = "460800"         'Set Baud rate to the selected value on
                        Case 6
                            'Now change the baud rate selected in the CmbBaud comboBox
                            ChangeBaud("921600")
                            'Last perform same function as connect button
                            SerialPort1.BaudRate = "921600"         'Set Baud rate to the selected value on
                        Case 7
                            'Now change the baud rate selected in the CmbBaud comboBox
                            ChangeBaud("1843200")
                            'Last perform same function as connect button
                            SerialPort1.BaudRate = "1843200"         'Set Baud rate to the selected value on
                        Case 8
                            'Now change the baud rate selected in the CmbBaud comboBox
                            ChangeBaud("3686400")
                            'Last perform same function as connect button
                            SerialPort1.BaudRate = "3686400"         'Set Baud rate to the selected value on
                    End Select
                    'Other Serial Port Property
                    SerialPort1.Parity = IO.Ports.Parity.None
                    SerialPort1.StopBits = IO.Ports.StopBits.One
                    SerialPort1.DataBits = 8            'Open our serial port
                    SerialPort1.Open()
                    ReceivedText("", "Change baud rate")
                    Me.Invoke(New MethodInvoker(AddressOf Me.tmrBaudDefault.Start))
                End If
            Case &H18               'This is a request for maximunm payload size
                ReceivedText(dispString, "Query Max Payload Size received")
                SendToLog(dispString, "Query Max Payload Size received")
                SendLinkAck()
                If forceNak = True Then
                    Reset_state()
                Else
                    PauseMS(tARValBox.Value)      'Wait 100ms before sending response
                    xmitBuffer(0) = 8
                    xmitBuffer(1) = 3
                    xmitBuffer(2) = 0
                    xmitBuffer(3) = 2
                    xmitBuffer(4) = &H19
                    xmitBuffer(5) = MaxPayload
                    pendingAck = 0  'Set the pendingAck to nothing
                    pendingLinkAck = True  'Set the pendingLinkAck to true
                    SendComData(xmitBuffer, 6, "Sent Max Payload", pendingLinkAck)
                End If
            Case &H19               'This is a response for maximunm payload size request
                ReceivedText(dispString, "Max Payload Size response received: 0x" & Conversion.Hex(receiveBuffer(5)))
                SendToLog(dispString, "Max Payload Size response received: 0x" & Conversion.Hex(receiveBuffer(5)))
                SendLinkAck()
                If forceNak = True Then
                    Reset_state()
                Else
                    'MaxPayloadCd = receiveBuffer(5)
                    Select Case receiveBuffer(5)
                        Case 0
                            MaxPayloadSizeCd = 2
                        Case 1
                            MaxPayloadSizeCd = 4
                        Case 2
                            MaxPayloadSizeCd = 8
                        Case 3
                            MaxPayloadSizeCd = 16
                        Case 4
                            MaxPayloadSizeCd = 32
                        Case 5
                            MaxPayloadSizeCd = 64
                        Case 6
                            MaxPayloadSizeCd = 128
                        Case 7
                            MaxPayloadSizeCd = 256
                        Case 8
                            MaxPayloadSizeCd = 512
                        Case 9
                            MaxPayloadSizeCd = 1024
                        Case 10
                            MaxPayloadSizeCd = 1280
                        Case 11
                            MaxPayloadSizeCd = 1500
                        Case 12
                            MaxPayloadSizeCd = 2048
                        Case 13
                            MaxPayloadSizeCd = 4096
                    End Select
                    cdMaxPayloadSize.Text = MaxPayloadSizeCd
                    If cbResponseSim.Checked = True Then
                        'Set this device's max payload to match that of its counterpart
                        If receiveBuffer(5) < MaxPayload Then
                            'Only lower max payload, do not raise it
                            SetMaxPayload(receiveBuffer(5))
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub SetMaxPayload(MaxPayloadValue As Integer)
        Select Case MaxPayloadValue
            Case 0
                MaxPayload = 0
                rbMaxPayload1.Checked = True
                MaxPayloadSize = 2
            Case 1
                MaxPayload = 1
                rbMaxPayload2.Checked = True
                MaxPayloadSize = 4
            Case 2
                MaxPayload = 2
                rbMaxPayload3.Checked = True
                MaxPayloadSize = 8
            Case 3
                MaxPayload = 3
                rbMaxPayload4.Checked = True
                MaxPayloadSize = 16
            Case 4
                MaxPayload = 4
                rbMaxPayload5.Checked = True
                MaxPayloadSize = 32
            Case 5
                MaxPayload = 5
                rbMaxPayload6.Checked = True
                MaxPayloadSize = 64
            Case 6
                MaxPayload = 6
                rbMaxPayload7.Checked = True
                MaxPayloadSize = 128
            Case 7
                MaxPayload = 7
                rbMaxPayload8.Checked = True
                MaxPayloadSize = 256
            Case 8
                MaxPayload = 8
                rbMaxPayload9.Checked = True
                MaxPayloadSize = 512
            Case 9
                MaxPayload = 9
                rbMaxPayload10.Checked = True
                MaxPayloadSize = 1024
            Case 10
                MaxPayload = 10
                rbMaxPayload11.Checked = True
                MaxPayloadSize = 1280
            Case 11
                MaxPayload = 11
                rbMaxPayload12.Checked = True
                MaxPayloadSize = 1500
            Case 12
                MaxPayload = 12
                rbMaxPayload13.Checked = True
                MaxPayloadSize = 2048
            Case 13
                MaxPayload = 13
                rbMaxPayload14.Checked = True
                MaxPayloadSize = 4096
        End Select

    End Sub

    Private Sub PauseMS(pauseTimeMS As Integer)
        Dim startTime As System.DateTime
        Dim rightNowTime As System.DateTime
        Dim deltaTime As System.TimeSpan
        Dim deltaMS As Integer

        startTime = DateTime.Now
        Do
            rightNowTime = DateTime.Now
            deltaTime = rightNowTime.Subtract(startTime)
            deltaMS = deltaTime.Seconds * 1000 + deltaTime.Milliseconds
            If deltaMS > pauseTimeMS Then Exit Do
            System.Threading.Thread.Sleep(1) 'Wait 1 millisecond
        Loop

    End Sub

    'Processes Type Supported Queries
    Private Sub ProcessTypeSupportedQuery()

        Dim xmitBuffer(6) As Byte
        Dim dispString As String

        If VerifyChecksum(receiveBuffer, (receiveIndex - 2)) = False Then
            dispString = ByteToHexString(receiveBuffer, "Recv", receiveIndex)    'Display the received data in the text box
            SendToLog(dispString, "Invalid Checksum Received")
            ReceivedText(dispString, "Invalid Checksum Received")
            SendLinkNak(3)
        Else
            If CheckSupported(receiveBuffer(0), receiveBuffer(1)) = True Then
                SendLinkAck()
            Else
                'Send NAK
                SendLinkNak(6)
            End If
        End If
        Reset_state()

    End Sub

    'Sends an Ack signal after delay
    Private Sub SendAppAck(ByVal basicID As Byte, ByVal textStr As String)
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        PauseMS(tARValBox.Value)      'Wait before sending response
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 3
        xmitBuffer(5) = basicID
        'pendingLinkAck = True  'Set the pendingLinkAck to true
        SendComData(xmitBuffer, 6, textStr, pendingLinkAck)
        rtnval = GetLinkAck()
    End Sub

    'Processes Incoming Basic DR Application Messages
    Private Sub ProcessBasicDRAppMsg(ByVal dispString As String)

        Dim xmitBuffer(8) As Byte
        Dim powerLevel As Single

        'Debug section to identify error
        messageCounter += 1
        If messageCounter > 60 Then
            btnClearDebug.PerformClick()
            messageCounter = 0
        End If
        'End debug section

        msgReceiveTime = DateTime.Now
        If receiveIndex > (MaxPayloadSizeCd + 6) Then
            ReceivedText("", "Message received larger than buffer Max Payload Size")
            Exit Sub
        End If

        If VerifyChecksum(receiveBuffer, (receiveIndex - 2)) = False Then
            dispString = ByteToHexString(receiveBuffer, "Recv", receiveIndex)    'Display the received data in the text box
            SendToLog(dispString, "Received Invalid Checksum")
            ReceivedText(dispString, "Received Invalid Checksum")
            SendLinkNak(3)
        Else        'Checksum is valid so see what the message is
            'reset Baud default timeout
            If tmrBaudDefault.Enabled = True Then   'Valid communication established--reset baud timer if it is already running
                Me.Invoke(New MethodInvoker(AddressOf Me.tmrBaudDefault.Stop))
                Me.Invoke(New MethodInvoker(AddressOf Me.tmrBaudDefault.Start))
            End If
            If rbMode1.Checked = True Then
                'This is a UCM - controller device
                Select Case receiveBuffer(4)
                    Case &H3        'Received Application ACK
                        If pendingAck <> receiveBuffer(5) Then
                            ReceivedText("", "Invalid Ack OpCode returned " & receiveBuffer(5))
                        End If
                        ReceivedText(dispString, "Recieved an Application Ack with code: " & Hex(receiveBuffer(5)))
                        SendToLog(dispString, "Recieved an Application Ack with code: " & Hex(receiveBuffer(5)))
                        SendLinkAck()
                        Reset_state()
                    Case &H4        'Received Application NAK
                        Select Case receiveBuffer(5)
                            Case 0
                                ReceivedText(dispString, "Application NAK returned with reason: 0 -No Reason Specified")
                                SendToLog(dispString, "Application NAK returned with reason: 0 -No Reason Specified")
                            Case 1
                                ReceivedText(dispString, "Application NAK returned with reason: 1 -Opcode 1 not supported")
                                SendToLog(dispString, "Application NAK returned with reason: 1 -Opcode 1 not supported")
                            Case 2
                                ReceivedText(dispString, "Application NAK returned with reason: 2 -Opcode 2 invalid")
                                SendToLog(dispString, "Application NAK returned with reason: 2 -Opcode 2 invalid")
                            Case 3
                                ReceivedText(dispString, "Application NAK returned with reason: 3 -Busy")
                                SendToLog(dispString, "Application NAK returned with reason: 3 -Busy")
                            Case 4
                                ReceivedText(dispString, "Application NAK returned with reason: 4 -Length Invalid")
                                SendToLog(dispString, "Application NAK returned with reason: 4 -Length Invalid")
                            Case 5
                                ReceivedText(dispString, "Application NAK returned with reason: 5 -Customer Override is in effect")
                                SendToLog(dispString, "Application NAK returned with reason: 5 -Customer Override is in effect")
                        End Select
                        SendLinkAck()
                    Case &H11       'Customer override received
                        If receiveBuffer(5) = 1 Then
                            ReceivedText(dispString, "Received from SGD: Customer Override in Effect")
                            SendToLog(dispString, "Received from SGD: Customer Override in Effect")
                            ucmCustomerOverride = True
                            If chkCustOverride.Checked <> True Then
                                ignoreOverrideChange = True
                                chkCustOverride.Checked = True
                            End If
                        Else
                            ReceivedText(dispString, "Received from SGD: Customer Override no longer in Effect")
                            SendToLog(dispString, "Received from SGD: Customer Override no longer in Effect")
                            ucmCustomerOverride = False
                            If chkCustOverride.Checked <> False Then
                                ignoreOverrideChange = True
                                chkCustOverride.Checked = False
                            End If
                        End If
                        receiveIndex = 0
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            SendAppAck(&H11, "Sent Application Ack of command type: 0x11")
                        End If
                    Case &H13       'Unsolicited state query response received
                        DetermineOpState(dispString)
                        ReceivedText(dispString, "Received operating state from SGD")
                        SendToLog(dispString, "Received operating state from SGD")
                        receiveIndex = 0
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            SendAppAck(&H13, "Sent Application Ack of command type: 0x13")
                        End If
                    Case &H14       'Sleep
                        ReceivedText(dispString, "SGD is Idle")
                        SendToLog(dispString, "SGD is Idle")
                        receiveIndex = 0
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            SendAppAck(&H14, "Sent Application Ack of command type: 0x14")
                        End If

                    Case &H15
                        ReceivedText(dispString, "SGD is Awake")
                        SendToLog(dispString, "SGD is Awake")
                        receiveIndex = 0
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            SendAppAck(&H15, "Sent Application Ack of command type: 0x15")
                        End If

                    Case &H1A        'Reboot command received
                        ReceivedText(dispString, "Reboot command received. Opcode2 = " & receiveBuffer(5))
                        SendToLog(dispString, "Reboot command received. Opcode2 = " & receiveBuffer(5))
                        receiveIndex = 0
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            SendAppAck(&H1A, "Sent Application Ack of command type: 0x1A")
                        End If

                    Case Else
                        ReceivedText(dispString, "Invalid Opcode Received: " & receiveBuffer(4))
                        SendToLog(dispString, "Invalid Opcode Received: " & receiveBuffer(4))
                        SendLinkNak(7)
                End Select
            Else
                'This is a SGD - Appliance
                Select Case receiveBuffer(4)
                    Case &H1        'Shed Load command received
                        ReceivedText(dispString, "Shed Load command received. Duration = " & ByteToDurationStr(receiveBuffer(5)))
                        SendToLog(dispString, "Shed Load command received. Duration = " & ByteToDurationStr(receiveBuffer(5)))
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            If chkSendNakOverride.Checked = True And overRideSet = True Then
                                tempByte = receiveBuffer(5)
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 1
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 2
                                xmitBuffer(4) = 4
                                xmitBuffer(5) = 5
                                pendingAck = 0  'Set the pendingAck to nothing
                                pendingLinkAck = True  'Set the pendingLinkAck to true
                                SendComData(xmitBuffer, 6, "Sent Application Nak with code: 0x5", pendingLinkAck)
                            Else
                                tempByte = receiveBuffer(5)
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 1
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 2
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = 1
                                pendingAck = 0  'Set the pendingAck to nothing
                                pendingLinkAck = True  'Set the pendingLinkAck to true
                                SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0x1", pendingLinkAck)
                                If overRideSet = True Then
                                    sendOverridePend = True
                                Else
                                    gridMode = "Shed"
                                    If cbResponseSim.Checked = True Then
                                        nudRunningPower.Value = nudRunShedPwr.Value
                                        preShedOpState = OpStateBox.SelectedIndex 'Remembers old opstate
                                        If bRealDeviceRun.Text = "Stop" Then
                                            If (cbHVAC.Checked = True Or cbHotWater.Checked = True) And nudPresentCapacity.Value >= nudShedStart.Value Then
                                                commodityArray(0).instRate = nudRunningPower.Value
                                                OpStateBox.SelectedIndex = 2
                                            Else
                                                commodityArray(0).instRate = 0
                                                OpStateBox.SelectedIndex = 4
                                            End If
                                        Else
                                            'Set new state
                                            Select Case realSGDShedResponse.SelectedIndex
                                                Case 0
                                                'Set to manual so do nothing
                                                'Set to manual so do nothing
                                                Case 1
                                                    If chkCustOverride.Checked = False Then
                                                        OpStateBox.SelectedIndex = 2
                                                    Else
                                                        OpStateBox.SelectedIndex = 1
                                                    End If
                                                Case 2
                                                    If chkCustOverride.Checked = False Then
                                                        OpStateBox.SelectedIndex = 4
                                                    Else
                                                        OpStateBox.SelectedIndex = 0
                                                    End If
                                                Case 3
                                                    OpStateBox.SelectedIndex = 5
                                            End Select
                                            'If a timer is supported, set timer to countdown
                                            If internalClockSupportedcb.Checked = True And receiveBuffer(5) <> 0 And receiveBuffer(5) <> &HFF Then
                                                shedEventTime = (receiveBuffer(5) * receiveBuffer(5)) * 2
                                                shedEventTimer.Enabled = True
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Case &H2        'End Shed/Run Normal
                        ReceivedText(dispString, "Received End Shed/Run Normal Command")
                        SendToLog(dispString, "Received End Shed/Run Normal Command")
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 1
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 2
                            pendingAck = 0  'Set the pendingAck to nothing
                            pendingLinkAck = True  'Set the pendingLinkAck to true
                            If cbAppNakMsg.Checked = True Then
                                xmitBuffer(4) = 4       'Send a Nak instead
                                xmitBuffer(5) = nudAppNakRtn.Value
                                SendComData(xmitBuffer, 6, "Sent Application Nak", pendingLinkAck)
                            Else
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = 2
                                SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0x2", pendingLinkAck)
                            End If
                            gridMode = "Normal"
                            If cbResponseSim.Checked = True Then
                                nudRunningPower.Value = nudRunNormPwr.Value
                                If bRealDeviceRun.Text = "Stop" Then
                                    If cbPoolPump.Checked = True Then
                                        If nudPPRunMin.Value > 0 Then
                                            If nudStartDelay.Value <= 0 Then
                                                commodityArray(0).instRate = nudRunningPower.Value
                                                OpStateBox.SelectedIndex = 1
                                            Else
                                                commodityArray(0).instRate = 0
                                                OpStateBox.SelectedIndex = 0
                                            End If
                                        Else
                                            commodityArray(0).instRate = 0
                                            OpStateBox.SelectedIndex = 0
                                        End If
                                    ElseIf cbHVAC.Checked = True Or cbHotWater.Checked = True Then
                                        If (commodityArray(0).instRate > 0 Or (nudPresentCapacity.Value > nudNormalStart.Value)) Then
                                            'Start running normal
                                            commodityArray(0).instRate = nudRunningPower.Value
                                            OpStateBox.SelectedIndex = 1
                                        Else
                                            'Set to idle normal
                                            commodityArray(0).instRate = 0
                                            OpStateBox.SelectedIndex = 0
                                        End If
                                    End If
                                Else
                                    'Set new state
                                    Select Case realSGDEndShedResponse.SelectedIndex
                                        Case 0
                                        'Set to manual so do nothing
                                        Case 1
                                            OpStateBox.SelectedIndex = 1
                                        Case 2
                                            OpStateBox.SelectedIndex = 0
                                        Case 3
                                            OpStateBox.SelectedIndex = preShedOpState
                                        Case 4
                                            OpStateBox.SelectedIndex = 5
                                    End Select
                                    'Shuts off timer
                                    shedEventTimer.Enabled = False
                                End If
                            End If
                        End If
                    Case &H3        'Received Application ACK
                        If pendingAck <> receiveBuffer(5) Then
                            ReceivedText("", "Invalid Ack OpCode returned " & receiveBuffer(5))
                        End If
                        ReceivedText(dispString, "Recieved an Application Ack with code: " & Hex(receiveBuffer(5)))
                        SendToLog(dispString, "Recieved an Application Ack with code: " & Hex(receiveBuffer(5)))
                        SendLinkAck()
                        Reset_state()
                    Case &H4        'Received Application NAK
                        Select Case receiveBuffer(5)
                            Case 0
                                ReceivedText(dispString, "Application NAK returned with reason: 0 -No Reason Specified")
                                SendToLog(dispString, "Application NAK returned with reason: 0 -No Reason Specified")
                            Case 1
                                ReceivedText(dispString, "Application NAK returned with reason: 1 -Opcode 1 not supported")
                                SendToLog(dispString, "Application NAK returned with reason: 1 -Opcode 1 not supported")
                            Case 2
                                ReceivedText(dispString, "Application NAK returned with reason: 2 -Opcode 2 invalid")
                                SendToLog(dispString, "Application NAK returned with reason: 2 -Opcode 2 invalid")
                            Case 3
                                ReceivedText(dispString, "Application NAK returned with reason: 3 -Busy")
                                SendToLog(dispString, "Application NAK returned with reason: 3 -Busy")
                            Case 4
                                ReceivedText(dispString, "Application NAK returned with reason: 4 -Length Invalid")
                                SendToLog(dispString, "Application NAK returned with reason: 4 -Length Invalid")
                            Case 5
                                ReceivedText(dispString, "Application NAK returned with reason: 5 -Customer Override is in effect")
                                SendToLog(dispString, "Application NAK returned with reason: 5 -Customer Override is in effect")
                        End Select
                        SendLinkAck()
                    Case &H6        'Request for power level
                        If receiveBuffer(5) < 128 Then
                            powerLevel = receiveBuffer(5) * 100.0 / 127.0
                            ReceivedText(dispString, "Recieved Power Level Request: Level Set - Absorbed = " & powerLevel.ToString("0.00"))
                            SendToLog(dispString, "Recieved Power Level Request: Level Set - Absorbed = " & powerLevel.ToString("0.00"))
                        Else
                            powerLevel = (receiveBuffer(5) - 128) * 100.0 / 127.0
                            ReceivedText(dispString, "Recieved Power Level Request: Level Set - Produced = " & powerLevel.ToString("0.00"))
                            SendToLog(dispString, "Recieved Power Level Request: Level Set - Produced = " & powerLevel.ToString("0.00"))
                        End If
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 1
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 2
                            pendingAck = 0  'Set the pendingAck to nothing
                            pendingLinkAck = True  'Set the pendingLinkAck to true
                            If cbAppNakMsg.Checked = True Then
                                xmitBuffer(4) = 4       'Send a Nak instead
                                xmitBuffer(5) = nudAppNakRtn.Value
                                SendComData(xmitBuffer, 6, "Sent Application Nak", pendingLinkAck)
                            Else
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = 6
                                SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0x6", pendingLinkAck)
                            End If
                        End If
                    Case &H7        'Present Relative Price received
                        If receiveBuffer(5) = 0 Then
                            ReceivedText(dispString, "Received Present Relative Price: unknown")
                            SendToLog(dispString, "Received Present Relative Price: unknown")
                        ElseIf receiveBuffer(5) = &HFF Then
                            ReceivedText(dispString, "Received Present Relative Price: too large to fit")
                            SendToLog(dispString, "Received Present Relative Price: too large to fit")
                        Else
                            ReceivedText(dispString, "Received Present Relative Price: " & ByteToRelativePrice(receiveBuffer(5)))
                            SendToLog(dispString, "Received Present Relative Price: " & ByteToRelativePrice(receiveBuffer(5)))
                        End If
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 1
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 2
                            pendingAck = 0  'Set the pendingAck to nothing
                            pendingLinkAck = True  'Set the pendingLinkAck to true
                            If cbAppNakMsg.Checked = True Then
                                xmitBuffer(4) = 4       'Send a Nak instead
                                xmitBuffer(5) = nudAppNakRtn.Value
                                SendComData(xmitBuffer, 6, "Sent Application Nak", pendingLinkAck)
                            Else
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = 7
                                SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0x7", pendingLinkAck)
                            End If
                        End If
                    Case &H8        'Next Period Relative Price received
                        If receiveBuffer(5) = 0 Then
                            ReceivedText(dispString, "Received Next Period Relative Price: unknown")
                            SendToLog(dispString, "Received Next Period Relative Price: unknown")
                        ElseIf receiveBuffer(5) = &HFF Then
                            ReceivedText(dispString, "Received Next Period Relative Price: too large to fit")
                            SendToLog(dispString, "Received Next Period Relative Price: too large to fit")
                        Else
                            ReceivedText(dispString, "Received Next Period Relative Price: " & ByteToRelativePrice(receiveBuffer(5)))
                            SendToLog(dispString, "Received Next Period Relative Price: " & ByteToRelativePrice(receiveBuffer(5)))
                        End If
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 1
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 2
                            pendingAck = 0  'Set the pendingAck to nothing
                            pendingLinkAck = True  'Set the pendingLinkAck to true
                            If cbAppNakMsg.Checked = True Then
                                xmitBuffer(4) = 4       'Send a Nak instead
                                xmitBuffer(5) = nudAppNakRtn.Value
                                SendComData(xmitBuffer, 6, "Sent Application Nak", pendingLinkAck)
                            Else
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = 8
                                SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0x8", pendingLinkAck)
                            End If
                        End If
                    Case &H9        'Time remaining in Present Price Period received
                        ReceivedText(dispString, "Received Time Remaining in Present Period: " & ByteToDurationStr(receiveBuffer(5)))
                        SendToLog(dispString, "Received Time Remaining in Present Period: " & ByteToDurationStr(receiveBuffer(5)))
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 1
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 2
                            pendingAck = 0  'Set the pendingAck to nothing
                            pendingLinkAck = True  'Set the pendingLinkAck to true
                            If cbAppNakMsg.Checked = True Then
                                xmitBuffer(4) = 4       'Send a Nak instead
                                xmitBuffer(5) = nudAppNakRtn.Value
                                SendComData(xmitBuffer, 6, "Sent Application Nak", pendingLinkAck)
                            Else
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = 9
                                SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0x9", pendingLinkAck)
                            End If
                        End If
                    Case &HA        'Critical Peak
                        ReceivedText(dispString, "Critical Peak Event received. Duration: " & ByteToDurationStr(receiveBuffer(5)))
                        SendToLog(dispString, "Critical Peak Event received. Duration: " & ByteToDurationStr(receiveBuffer(5)))
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            If chkSendNakOverride.Checked = True And overRideSet = True Then
                                tempByte = receiveBuffer(5)
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 1
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 2
                                xmitBuffer(4) = 4
                                xmitBuffer(5) = 5
                                pendingAck = 0  'Set the pendingAck to nothing
                                pendingLinkAck = True  'Set the pendingLinkAck to true
                                SendComData(xmitBuffer, 6, "Sent Application Nak with code: 0x5", pendingLinkAck)
                            Else
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 1
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 2
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = &HA
                                pendingAck = 0  'Set the pendingAck to nothing
                                pendingLinkAck = True  'Set the pendingLinkAck to true
                                SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0xA", pendingLinkAck)
                                If overRideSet = True Then
                                    sendOverridePend = True
                                Else
                                    gridMode = "CPP"
                                    If cbResponseSim.Checked = True Then
                                        nudRunningPower.Value = nudRunCppPwr.Value
                                        preShedOpState = OpStateBox.SelectedIndex 'Remembers old opstate
                                        If bRealDeviceRun.Text = "Stop" Then    'Simulation is running
                                            If cbPoolPump.Checked = True Then
                                                commodityArray(0).instRate = 0
                                                OpStateBox.SelectedIndex = 4
                                            ElseIf cbHVAC.Checked = True Or cbHotWater.Checked = True Then
                                                If nudPresentCapacity.Value < nudCPPStart.Value Then
                                                    commodityArray(0).instRate = 0
                                                    OpStateBox.SelectedIndex = 4
                                                ElseIf commodityArray(0).instRate <> 0 Then
                                                    commodityArray(0).instRate = nudRunningPower.Value
                                                End If
                                            End If
                                        Else
                                            'Set new state
                                            Select Case realSGDCritPeakResponse.SelectedIndex
                                                Case 0
                                            'Set to manual so do nothing
                                                Case 1
                                                    'Not supported, send application level Nak
                                                    SendMsgNotSupportedNak()
                                                Case 2
                                                    If chkCustOverride.Checked = False Then
                                                        OpStateBox.SelectedIndex = 2
                                                    Else
                                                        OpStateBox.SelectedIndex = 1
                                                    End If
                                                Case 3
                                                    If chkCustOverride.Checked = False Then
                                                        OpStateBox.SelectedIndex = 4
                                                    Else
                                                        OpStateBox.SelectedIndex = 0
                                                    End If
                                                Case 4
                                                    OpStateBox.SelectedIndex = 5
                                            End Select
                                            'If a timer is supported, set timer to countdown
                                            If internalClockSupportedcb.Checked = True And receiveBuffer(5) <> 0 And receiveBuffer(5) <> &HFF Then
                                                shedEventTime = (receiveBuffer(5) * receiveBuffer(5)) * 2
                                                shedEventTimer.Enabled = True
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    Case &HB        'Grid Emergency
                        ReceivedText(dispString, "Grid Emergency received. Duration: " & ByteToDurationStr(receiveBuffer(5)))
                        SendToLog(dispString, "Grid Emergency received. Duration: " & ByteToDurationStr(receiveBuffer(5)))
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            If chkSendNakOverride.Checked = True And overRideSet = True Then
                                tempByte = receiveBuffer(5)
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 1
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 2
                                xmitBuffer(4) = 4
                                xmitBuffer(5) = 5
                                pendingAck = 0  'Set the pendingAck to nothing
                                pendingLinkAck = True  'Set the pendingLinkAck to true
                                SendComData(xmitBuffer, 6, "Sent Application Nak with code: 0x5", pendingLinkAck)
                            Else
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 1
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 2
                                pendingAck = 0  'Set the pendingAck to nothing
                                pendingLinkAck = True  'Set the pendingLinkAck to true
                                If cbAppNakMsg.Checked = True Then
                                    xmitBuffer(4) = 4       'Send a Nak instead
                                    xmitBuffer(5) = nudAppNakRtn.Value
                                    SendComData(xmitBuffer, 6, "Sent Application Nak", pendingLinkAck)
                                Else
                                    xmitBuffer(4) = 3
                                    xmitBuffer(5) = &HB
                                    SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0x0B", pendingLinkAck)
                                End If
                                gridMode = "Emergency"
                                If cbResponseSim.Checked = True Then
                                    preShedOpState = OpStateBox.SelectedIndex 'Remembers old opstate
                                    If bRealDeviceRun.Text = "Stop" Then    'Simulation is running
                                        'In grid emergency shut down no matter what
                                        commodityArray(0).instRate = 0
                                        OpStateBox.SelectedIndex = 4
                                    Else
                                        'Set new state
                                        Select Case realSGDEmergencyResponse.SelectedIndex
                                            Case 0
                                        'Set to manual so do nothing
                                            Case 1
                                                'Not supported, send application level Nak
                                                SendMsgNotSupportedNak()
                                            Case 2
                                                If chkCustOverride.Checked = False Then
                                                    OpStateBox.SelectedIndex = 2
                                                Else
                                                    OpStateBox.SelectedIndex = 1
                                                End If
                                            Case 3
                                                If chkCustOverride.Checked = False Then
                                                    OpStateBox.SelectedIndex = 4
                                                Else
                                                    OpStateBox.SelectedIndex = 0
                                                End If
                                            Case 4
                                                OpStateBox.SelectedIndex = 5
                                        End Select
                                        'If a timer is supported, set timer to countdown
                                        If internalClockSupportedcb.Checked = True And receiveBuffer(5) <> 0 And receiveBuffer(5) <> &HFF Then
                                            shedEventTime = (receiveBuffer(5) * receiveBuffer(5)) * 2
                                            shedEventTimer.Enabled = True
                                        End If
                                    End If
                                End If
                            End If

                        End If

                    Case &HC        'Grid Guidance received
                        If cbVerboseLog.Checked = True Then
                            ProcessGridGuidance(receiveBuffer(5), 1, dispString)
                        Else
                            ProcessGridGuidance(receiveBuffer(5), 0, dispString)
                        End If
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 1
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 2
                            pendingAck = 0  'Set the pendingAck to nothing
                            pendingLinkAck = True  'Set the pendingLinkAck to true
                            If cbAppNakMsg.Checked = True Then
                                xmitBuffer(4) = 4       'Send a Nak instead
                                xmitBuffer(5) = nudAppNakRtn.Value
                                SendComData(xmitBuffer, 6, "Sent Application Nak", pendingLinkAck)
                            Else
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = &HC
                                SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0xC", pendingLinkAck)
                            End If
                        End If
                    Case &HE        'Outside comm Connection Status received
                        ReceivedText(dispString, "Comm Status received: " & commStatusText(receiveBuffer(5)))
                        SendToLog(dispString, "Comm Status received: " & commStatusText(receiveBuffer(5)))
                        If cbResponseSim.Checked = True And internalClockSupportedcb.Checked = True And realSGDNoCommTimeoutEnabledbtn.Text = "Disable" Then
                            commStatusTimeoutTime = realSGDNoCommTimeoutValBox.Value
                        End If
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 1
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 2
                            pendingAck = 0  'Set the pendingAck to nothing
                            pendingLinkAck = True  'Set the pendingLinkAck to true
                            If cbAppNakMsg.Checked = True Then
                                xmitBuffer(4) = 4       'Send a Nak instead
                                xmitBuffer(5) = nudAppNakRtn.Value
                                SendComData(xmitBuffer, 6, "Sent Application Nak", pendingLinkAck)
                            Else
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = &HE
                                SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0xE", pendingLinkAck)
                            End If
                        End If
                    Case &H11       'Customer override received
                        If receiveBuffer(5) = 1 Then
                            ReceivedText(dispString, "Received from UCM: Customer Override in Effect")
                            SendToLog(dispString, "Received from UCM: Customer Override in Effect")
                            ucmCustomerOverride = True
                            If chkCustOverride.Checked <> True Then
                                ignoreOverrideChange = True
                                chkCustOverride.Checked = True
                            End If
                        Else
                            ReceivedText(dispString, "Received from UCM: Customer Override no longer in Effect")
                            SendToLog(dispString, "Received from UCM: Customer Override no longer in Effect")
                            ucmCustomerOverride = False
                            If chkCustOverride.Checked <> False Then
                                ignoreOverrideChange = True
                                chkCustOverride.Checked = False
                            End If
                        End If
                        receiveIndex = 0
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            SendAppAck(&H11, "Sent Application Ack of command type: 0x11")
                        End If
                    Case &H12       'Request for Operational State received
                        ReceivedText(dispString, "Received Operational State Query")
                        SendToLog(dispString, "Received Operational State Query")
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 1
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 2
                            pendingAck = 0  'Set the pendingAck to nothing
                            pendingLinkAck = True  'Set the pendingLinkAck to true
                            If cbAppNakMsg.Checked = True Then
                                xmitBuffer(4) = 4       'Send a Nak instead
                                xmitBuffer(5) = nudAppNakRtn.Value
                                SendComData(xmitBuffer, 6, "Sent Application Nak", pendingLinkAck)
                            Else
                                xmitBuffer(4) = &H13
                                xmitBuffer(5) = OpStateBox.SelectedIndex
                                SendComData(xmitBuffer, 6, "Replied to Operational State Query", pendingLinkAck)
                            End If
                        End If
                    Case &H16       'Simple Time Sync
                        ReceivedText(dispString, "Simple Time Sync received. Value = " & receiveBuffer(5))
                        SendToLog(dispString, "Simple Time Sync received. Value = " & receiveBuffer(5))
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 1
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 2
                            pendingAck = 0  'Set the pendingAck to nothing
                            pendingLinkAck = True  'Set the pendingLinkAck to true
                            If cbAppNakMsg.Checked = True Then
                                xmitBuffer(4) = 4       'Send a Nak instead
                                xmitBuffer(5) = nudAppNakRtn.Value
                                SendComData(xmitBuffer, 6, "Sent Application Nak", pendingLinkAck)
                            Else
                                xmitBuffer(4) = 3
                                xmitBuffer(5) = &H16
                                SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0x16", pendingLinkAck)
                            End If
                        End If
                    Case &H17       'Load Up command received
                        ReceivedText(dispString, "Load Up command received. Duration = " & ByteToDurationStr(receiveBuffer(5)))
                        SendToLog(dispString, "Load Up command received. Duration = " & ByteToDurationStr(receiveBuffer(5)))
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            If chkSendNakOverride.Checked = True And overRideSet = True Then
                                tempByte = receiveBuffer(5)
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 1
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 2
                                xmitBuffer(4) = 4
                                xmitBuffer(5) = 5
                                pendingAck = 0  'Set the pendingAck to nothing
                                pendingLinkAck = True  'Set the pendingLinkAck to true
                                SendComData(xmitBuffer, 6, "Sent Application Nak with code: 0x5", pendingLinkAck)
                            Else
                                xmitBuffer(0) = 8
                                xmitBuffer(1) = 1
                                xmitBuffer(2) = 0
                                xmitBuffer(3) = 2
                                pendingAck = 0  'Set the pendingAck to nothing
                                pendingLinkAck = True  'Set the pendingLinkAck to true
                                If cbAppNakMsg.Checked = True Then
                                    xmitBuffer(4) = 4       'Send a Nak instead
                                    xmitBuffer(5) = nudAppNakRtn.Value
                                    SendComData(xmitBuffer, 6, "Sent Application Nak", pendingLinkAck)
                                Else
                                    xmitBuffer(4) = 3
                                    xmitBuffer(5) = &H17
                                    SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0x17", pendingLinkAck)
                                End If
                                gridMode = "Loadup"
                                If overRideSet = True Then sendOverridePend = True
                                preShedOpState = OpStateBox.SelectedIndex 'Remembers old opstate
                                If cbResponseSim.Checked = True Then
                                    nudRunningPower.Value = nudRunNormPwr.Value
                                    If bRealDeviceRun.Text = "Stop" Then
                                        If cbPoolPump.Checked = True Then
                                            If nudPPRunMin.Value > 0 And nudStartDelay.Value <= 0 Then
                                                'start pool pump
                                                OpStateBox.SelectedIndex = 3        'running heightened
                                                lbCommodityCode.SelectedIndex = 0
                                                commodityArray(0).instRate = nudRunningPower.Value
                                                commodityArray(6).cumAmount = nudTotalCapacity.Value / 60
                                                commodityArray(7).cumAmount = nudPresentCapacity.Value / 60
                                            Else
                                                OpStateBox.SelectedIndex = 6        'idle heightened
                                            End If
                                        ElseIf cbHVAC.Checked = True Or cbHotWater.Checked = True Then
                                            If nudPresentCapacity.Value >= nudRunningPower.Value Then
                                                'Start running heightened
                                                lbCommodityCode.SelectedIndex = 0
                                                commodityArray(lbCommodityCode.SelectedIndex).instRate = nudRunningPower.Value
                                                OpStateBox.SelectedIndex = 3
                                            Else
                                                'Set to idle heightened
                                                lbCommodityCode.SelectedIndex = 0
                                                commodityArray(lbCommodityCode.SelectedIndex).instRate = 0
                                                OpStateBox.SelectedIndex = 6
                                            End If
                                        End If
                                    Else
                                        'Set new state
                                        Select Case realSGDLoadUpResponse.SelectedIndex
                                            Case 0
                                        'Set to manual so do nothing
                                            Case 1
                                                'Not supported, send application level Nak
                                                SendMsgNotSupportedNak()
                                            Case 2
                                                OpStateBox.SelectedIndex = 1
                                            Case 3
                                                OpStateBox.SelectedIndex = 0
                                            Case 4
                                                OpStateBox.SelectedIndex = 5
                                        End Select
                                    End If
                                    'If a timer is supported, set timer to countdown
                                    If internalClockSupportedcb.Checked = True And receiveBuffer(5) <> 0 And receiveBuffer(5) <> &HFF Then
                                        shedEventTime = (receiveBuffer(5) * receiveBuffer(5)) * 2
                                        shedEventTimer.Enabled = True
                                    End If
                                End If
                            End If
                        End If
                    Case &H18        'Pending Event Time command received
                        ReceivedText(dispString, "Pending Event Time command received. Time = " & ByteToDurationStr(receiveBuffer(5)))
                        SendToLog(dispString, "Pending Event Time command received. Time = " & ByteToDurationStr(receiveBuffer(5)))
                        tbPendEventTime.Text = ByteToDurationStr(receiveBuffer(5))
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 1
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 2
                            xmitBuffer(4) = 3
                            xmitBuffer(5) = &H18
                            pendingAck = 0  'Set the pendingAck to nothing
                            pendingLinkAck = True  'Set the pendingLinkAck to true
                            SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0x18", pendingLinkAck)
                        End If
                    Case &H19        'Pending Event Type command received
                        ReceivedText(dispString, "Pending Event Type command received. Opcode2 = " & receiveBuffer(5))
                        SendToLog(dispString, "Pending Event Type command received. Opcode2 = " & receiveBuffer(5))
                        If receiveBuffer(5) = 1 Then
                            tbPendEventType.Text = "Shed"
                        ElseIf receiveBuffer(5) = 2 Then
                            tbPendEventType.Text = "End Shed/Run Normal"
                        ElseIf receiveBuffer(5) = &HA Then
                            tbPendEventType.Text = "Critical Peak"
                        ElseIf receiveBuffer(5) = &HB Then
                            tbPendEventType.Text = "Grid Emergency"
                        ElseIf receiveBuffer(5) = &H17 Then
                            tbPendEventType.Text = "Load Up"
                        End If
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            PauseMS(tARValBox.Value)      'Wait before sending response
                            xmitBuffer(0) = 8
                            xmitBuffer(1) = 1
                            xmitBuffer(2) = 0
                            xmitBuffer(3) = 2
                            xmitBuffer(4) = 3
                            xmitBuffer(5) = &H19
                            pendingAck = 0  'Set the pendingAck to nothing
                            pendingLinkAck = True  'Set the pendingLinkAck to true
                            SendComData(xmitBuffer, 6, "Sent Application Ack of command type: 0x19", pendingLinkAck)
                        End If
                    Case &H1A        'Reboot command received
                        ReceivedText(dispString, "Reboot command received. Opcode2 = " & receiveBuffer(5))
                        SendToLog(dispString, "Reboot command received. Opcode2 = " & receiveBuffer(5))
                        receiveIndex = 0
                        SendLinkAck()
                        If forceNak = True Then
                            Reset_state()
                        Else
                            SendAppAck(&H1A, "Sent Application Ack of command type: 0x1A")
                        End If

                    Case Else
                        ReceivedText(dispString, "Invalid Opcode Received: " & receiveBuffer(4))
                        SendToLog(dispString, "Invalid Opcode Received: " & receiveBuffer(4))
                        SendLinkNak(7)
                End Select
            End If
        End If
        receiveIndex = 0

    End Sub

    Private Sub ProcessGridGuidance(ByVal i As Byte, ByVal verbose As Byte, ByVal dispString As String)

        If i = 0 Then           'Bad time to use energy
            If verbose = 1 Then ReceivedText(dispString, "Received Grid Guidance: Bad Time to Use Energy")
            preGuidanceOpState = OpStateBox.SelectedIndex
            'If we are simulating a real device
            If cbResponseSim.Checked = True Then
                If realSGDBadTimeResponse.SelectedIndex = 0 Then        'Manual
                    If verbose = 1 Then ReceivedText("", "Grid Guidance 'Bad' recieved, but no change was made to Opstate")
                ElseIf realSGDBadTimeResponse.SelectedIndex = 1 Then    'Not Supported, send linknak
                    SendLinkNak(&H6)
                ElseIf realSGDBadTimeResponse.SelectedIndex = 2 Then    'Running Curtailed Grid/ Running normal (override set)
                    If chkCustOverride.Checked = True Then
                        OpStateBox.SelectedIndex = 1
                    Else
                        OpStateBox.SelectedIndex = 2
                    End If
                ElseIf realSGDBadTimeResponse.SelectedIndex = 3 Then    'Idle Grid/ Idle Normal (override set)
                    If chkCustOverride.Checked = True Then
                        OpStateBox.SelectedIndex = 0
                    Else
                        OpStateBox.SelectedIndex = 4
                    End If
                ElseIf realSGDBadTimeResponse.SelectedIndex = 4 Then    'SGD Error Condition
                    OpStateBox.SelectedIndex = 5
                End If
            End If

        ElseIf i = 1 Then       'Neutral guidance
            If verbose = 1 Then ReceivedText(dispString, "Received Grid Guidance: Neutral")
            'If we are simulating a real device
            If cbResponseSim.Checked = True Then
                If realSGDNeutralResponse.SelectedIndex = 0 Then        'Manual
                    If verbose = 1 Then ReceivedText("", "Grid Guidance 'Neutral' recieved, no change was made to Opstate")
                Else                                                    'Pre-guidance
                    OpStateBox.SelectedIndex = preGuidanceOpState
                End If
            End If

        ElseIf i = 2 Then       'Good time to use energy
            If verbose = 1 Then ReceivedText(dispString, "Received Grid Guidance: Good Time to Use Energy")
            preGuidanceOpState = OpStateBox.SelectedIndex
            'If we are simulating a real device
            If cbResponseSim.Checked = True Then
                If realSGDGoodTimeResponse.SelectedIndex = 0 Then        'Manual
                    If verbose = 1 Then ReceivedText("", "Grid Guidance 'Good' recieved, but no change was made to Opstate")
                ElseIf realSGDGoodTimeResponse.SelectedIndex = 1 Then    'Not Supported, send linknak
                    SendLinkNak(&H6)
                ElseIf realSGDGoodTimeResponse.SelectedIndex = 2 Then    'Running normal
                    OpStateBox.SelectedIndex = 1
                ElseIf realSGDGoodTimeResponse.SelectedIndex = 3 Then    'Idle Normal
                    OpStateBox.SelectedIndex = 0
                ElseIf realSGDGoodTimeResponse.SelectedIndex = 4 Then    'SGD Error Condition
                    OpStateBox.SelectedIndex = 5
                End If
            End If

        Else
            If verbose = 1 Then ReceivedText(dispString, "Received Invalid Grid Guidance = 0x" & i)
        End If

    End Sub

    Private Sub BtnSetUTC_Click(sender As Object, e As EventArgs) Handles btnSetUTC.Click
        Dim xmitBuffer(14) As Byte
        Dim uTime As Integer

        Try
            uTime = (DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds
            uTime -= 946684800      'Conver Unix time to seconds since 1/1/2000
            receiveIndex = 0
            xmitBuffer(0) = &H8
            xmitBuffer(1) = &H2
            xmitBuffer(2) = 0
            xmitBuffer(3) = 8
            xmitBuffer(4) = 2
            xmitBuffer(5) = 0
            xmitBuffer(6) = (uTime >> 24) And &HFF           'UTC time in seconds since 1/1/2000
            xmitBuffer(7) = (uTime >> 16) And &HFF
            xmitBuffer(8) = (uTime >> 8) And &HFF
            xmitBuffer(9) = uTime And &HFF
            xmitBuffer(10) = nudUTCOffset.Value And &HFF           'Time zone offset in 15 minute units
            xmitBuffer(11) = nudDSTOffset.Value         'DST offset
            pendingLinkAck = True
            SendComData(xmitBuffer, 12, "Sent UTC Offset", pendingLinkAck)
            expectingResponse = True
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub btnSetUTC_Click: " & ex.Message)
        End Try


    End Sub

    Private Sub BtnStartCycling_Click(sender As Object, e As EventArgs) Handles btnStartCycling.Click
        Dim xmitBuffer(36) As Byte
        Dim uTime As Integer
        Dim msgSize As Integer
        Dim startDate As New DateTime(1970, 1, 1, 0, 0, 0)

        'Build Header
        xmitBuffer(0) = &H8
        xmitBuffer(1) = &H2
        xmitBuffer(2) = &H0
        xmitBuffer(3) = &H10
        xmitBuffer(4) = &H4
        xmitBuffer(5) = &H0

        'Build Message
        'Builds Event ID
        xmitBuffer(9) = nudEventID.Value And &HFF
        xmitBuffer(8) = (nudEventID.Value >> 8) And &HFF
        xmitBuffer(7) = (nudEventID.Value >> 16) And &HFF
        xmitBuffer(6) = (nudEventID.Value >> 24) And &HFF

        'Build start time
        uTime = (dtpStartTime.Value - startDate).TotalSeconds
        If uTime < 946684800 Then
            uTime = 946684800
        End If
        uTime -= 946684800      'Conver Unix time to seconds since 1/1/2000
        xmitBuffer(13) = uTime And &HFF
        xmitBuffer(12) = (uTime >> 8) And &HFF
        xmitBuffer(11) = (uTime >> 16) And &HFF
        xmitBuffer(10) = (uTime >> 24) And &HFF

        'Build duration in minutes
        xmitBuffer(14) = (nudDuration.Value >> 8) And &HFF
        xmitBuffer(15) = nudDuration.Value And &HFF

        'Duty Cycle
        xmitBuffer(16) = nudDutyCycle.Value
        msgSize = 17
        'Start Randomization in mins - Optional. do not send if 0
        If nudStartRandomization.Value <> 0 Or nudEndRandomization.Value <> 0 Or nudCriticality.Value <> 0 Or nudDutyCyclePeriod.Value <> 0 Then
            xmitBuffer(17) = nudStartRandomization.Value
            msgSize = 18
        End If

        'End Randomization in mins - Optional. do not send if 0
        If nudEndRandomization.Value <> 0 Or nudCriticality.Value <> 0 Or nudDutyCyclePeriod.Value <> 0 Then
            xmitBuffer(18) = nudEndRandomization.Value
            msgSize = 19
        End If

        'Criticality - Optional. do not send if 0
        If nudCriticality.Value <> 0 Or nudDutyCyclePeriod.Value <> 0 Then
            xmitBuffer(19) = nudCriticality.Value
            msgSize = 20
        End If

        'Duty cycle period in minutes - Optional. do not send if 0
        If nudCriticality.Value <> 0 Or nudDutyCyclePeriod.Value <> 0 Then
            xmitBuffer(20) = nudDutyCyclePeriod.Value
            msgSize = 21
        End If
        xmitBuffer(3) = msgSize - 4

        'Send Message
        pendingLinkAck = True
        SendComData(xmitBuffer, msgSize, "Sent Start Autonomous Cycling Command", pendingLinkAck)
        expectingResponse = True
        pendingStartAutoCyclingAck = True

    End Sub

    Private Sub BtnStopCycling_Click(sender As Object, e As EventArgs) Handles btnStopCycling.Click
        Dim xmitBuffer(13) As Byte
        Dim tmparr(4) As Byte

        'Build Header
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 6
        xmitBuffer(4) = 4
        xmitBuffer(5) = 1

        'Build Message
        'Builds Event ID
        xmitBuffer(9) = nudStopEventID.Value And &HFF
        xmitBuffer(8) = (nudStopEventID.Value >> 8) And &HFF
        xmitBuffer(7) = (nudStopEventID.Value >> 16) And &HFF
        xmitBuffer(6) = (nudStopEventID.Value >> 24) And &HFF
        If nudStopEventID.Value <> 0 Then
            'End Randomization in mins - Optional. do not send if 0
            xmitBuffer(10) = nudStopEndRand.Value
            xmitBuffer(3) = 7
        End If

        pendingLinkAck = True
        SendComData(xmitBuffer, xmitBuffer(3) + 4, "Sent Stop Autonomous Cycling Command", pendingLinkAck)
        expectingResponse = True
        pendingStopAutoCyclingAck = True

    End Sub

    Private Sub PbCommoditySave_Click(sender As Object, e As EventArgs) Handles pbCommoditySave.Click

        commodityArray(lbCommodityCode.SelectedIndex).instRate = nudCommodityRate.Value
        commodityArray(lbCommodityCode.SelectedIndex).cumAmount = nudCommodityAmount.Value
        commodityArray(lbCommodityCode.SelectedIndex).supported = cbCommoditySupported.Checked
        commodityArray(lbCommodityCode.SelectedIndex).estimated = cbEstimated.Checked
        commodityArray(lbCommodityCode.SelectedIndex).updateFreq = nudCommodityFreq.Value
    End Sub

    Private Sub LbCommodityCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbCommodityCode.SelectedIndexChanged

        nudCommodityRate.Value = commodityArray(lbCommodityCode.SelectedIndex).instRate
        nudCommodityAmount.Value = commodityArray(lbCommodityCode.SelectedIndex).cumAmount
        cbCommoditySupported.Checked = commodityArray(lbCommodityCode.SelectedIndex).supported
        cbEstimated.Checked = commodityArray(lbCommodityCode.SelectedIndex).estimated
        nudCommodityFreq.Value = commodityArray(lbCommodityCode.SelectedIndex).updateFreq

        If lbCommodityCode.SelectedIndex = 6 Or lbCommodityCode.SelectedIndex = 7 Then
            nudCommodityRate.Enabled = False
        Else
            nudCommodityRate.Enabled = True
        End If
    End Sub

    Private Sub PbGetCommodity_Click(sender As Object, e As EventArgs) Handles pbGetCommodity.Click
        Dim xmitBuffer(8) As Byte
        'Get Commodity Read Request
        Try
            receiveIndex = 0
            xmitBuffer(0) = 8
            xmitBuffer(1) = 2
            xmitBuffer(2) = 0
            xmitBuffer(3) = 2
            xmitBuffer(4) = &H6
            xmitBuffer(5) = 0
            pendingLinkAck = True
            pendingAck = 0
            If nudCommodityNum.Value = 10 Then
                SendComData(xmitBuffer, 6, "Sent Get Commodity Read Request", pendingLinkAck)
            Else
                xmitBuffer(3) = 3
                xmitBuffer(6) = nudCommodityNum.Value
                SendComData(xmitBuffer, 7, "Sent Get Commodity Read Request", pendingLinkAck)
            End If
            expectingResponse = True

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub pbGetCommodity_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub PbSetCommodity_Click(sender As Object, e As EventArgs) Handles pbSetCommodity.Click
        Dim xmitBuffer(256) As Byte
        Dim i, j As Integer

        'Send your commodity information to the other device
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(4) = &H6
        xmitBuffer(5) = &H0
        j = 0
        For i = 0 To 9
            If commodityArray(i).supported = True Then
                If commodityArray(i).estimated = True Then
                    xmitBuffer(j * 13 + 6) = i
                Else
                    xmitBuffer(j * 13 + 6) = i + &H80
                End If
                xmitBuffer(j * 13 + 12) = commodityArray(i).instRate And &HFF
                xmitBuffer(j * 13 + 11) = (commodityArray(i).instRate >> 8) And &HFF
                xmitBuffer(j * 13 + 10) = (commodityArray(i).instRate >> 16) And &HFF
                xmitBuffer(j * 13 + 9) = (commodityArray(i).instRate >> 24) And &HFF
                xmitBuffer(j * 13 + 8) = (commodityArray(i).instRate >> 32) And &HFF
                xmitBuffer(j * 13 + 7) = (commodityArray(i).instRate >> 40) And &HFF
                xmitBuffer(j * 13 + 18) = commodityArray(i).cumAmount And &HFF
                xmitBuffer(j * 13 + 17) = (commodityArray(i).cumAmount >> 8) And &HFF
                xmitBuffer(j * 13 + 16) = (commodityArray(i).cumAmount >> 16) And &HFF
                xmitBuffer(j * 13 + 15) = (commodityArray(i).cumAmount >> 24) And &HFF
                xmitBuffer(j * 13 + 14) = (commodityArray(i).cumAmount >> 32) And &HFF
                xmitBuffer(j * 13 + 13) = (commodityArray(i).cumAmount >> 40) And &HFF
                j += 1
            End If
        Next i
        If j = 0 Then
            MessageBox.Show("There is no commodity information to send. Select 'Supported' for at least one commodity and try again.")
        Else
            i = j * 13 + 2      'Calculate payload size
            xmitBuffer(2) = i >> 8
            xmitBuffer(3) = i And &HFF
            pendingLinkAck = True
            SendComData(xmitBuffer, i + 4, "Sent Set Commodity Command", pendingLinkAck)
            expectingResponse = True
        End If

    End Sub

    Private Sub PbGetCommodSub_Click(sender As Object, e As EventArgs) Handles pbGetCommodSub.Click
        Dim xmitBuffer(16) As Byte

        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 6
        xmitBuffer(5) = 1
        pendingLinkAck = True
        SendComData(xmitBuffer, 6, "Sent Get Commodity Command", pendingLinkAck)
        expectingResponse = True

    End Sub

    Private Sub PbSetCommodSub_Click(sender As Object, e As EventArgs) Handles pbSetCommodSub.Click
        Dim xmitBuffer(32) As Byte
        Dim i, j As Integer

        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 6
        xmitBuffer(5) = 1
        j = 0
        For i = 0 To 9
            If commodityArray(i).supported = True Then
                xmitBuffer(3) += 3
                xmitBuffer((j * 3) + 6) = i
                xmitBuffer((j * 3) + 7) = commodityArray(i).updateFreq >> 8
                xmitBuffer((j * 3) + 8) = commodityArray(i).updateFreq And &HFF
                j += 1
            End If
        Next i
        pendingLinkAck = True
        SendComData(xmitBuffer, xmitBuffer(3) + 4, "Sent Set Commodity Command", pendingLinkAck)
        expectingResponse = True

    End Sub

    Private Sub PbSetTempOffset_Click(sender As Object, e As EventArgs) Handles pbSetTempOffset.Click
        Dim xmitBuffer(10) As Byte
        Dim tmparr(4) As Byte
        Dim problem As Boolean = False

        'Clear response boxes
        sgdTempRespCode.Text = ""

        'Build Msg
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 4
        xmitBuffer(4) = 3
        xmitBuffer(5) = 2

        'Gets current offset
        xmitBuffer(6) = nudTempOffset.Value And &HFF

        'Gets Units
        If tempUnitC.Checked = True Then
            xmitBuffer(7) = 1
        Else
            xmitBuffer(7) = 0
        End If

        'Send Msg
        If problem = False Then
            pendingLinkAck = True
            SendComData(xmitBuffer, 8, "Sent Set Temperature Offset Command", pendingLinkAck)
            expectingResponse = True
        End If

    End Sub

    Private Sub PbRequestTempOffset_Click(sender As Object, e As EventArgs) Handles pbRequestTempOffset.Click
        Dim xmitBuffer(8) As Byte

        'Clear response boxes
        sgdTempRespCode.Text = ""
        sgdTempUnits.Text = ""
        sgdCurrentTempOffset.Text = ""

        'Build Msg
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 3
        xmitBuffer(5) = 2

        expectingResponse = True
        pendingLinkAck = True
        SendComData(xmitBuffer, 6, "Sent Temerature Offset Request", pendingLinkAck)

    End Sub

    Private Sub BtnMaxPayload_Click(sender As Object, e As EventArgs) Handles btnMaxPayload.Click
        Dim xmitBuffer(8) As Byte

        Try
            receiveIndex = 0
            xmitBuffer(0) = &H8
            xmitBuffer(1) = &H3
            xmitBuffer(2) = 0
            xmitBuffer(3) = 2
            xmitBuffer(4) = &H18
            xmitBuffer(5) = 0
            pendingLinkAck = True
            SendComData(xmitBuffer, 6, "Sent Max Payload Query", pendingLinkAck)
            expectingResponse = True
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub btnMaxPayload_Click: " & ex.Message)
        End Try

    End Sub

    Private Sub PbCommRefresh_Click(sender As Object, e As EventArgs) Handles pbCommRefresh.Click
        Dim i As Integer

        Try
            If SerialPort1.IsOpen = False Then
                myPort = IO.Ports.SerialPort.GetPortNames() 'Get all com ports available
                CmbPort.Items.Clear()
                For i = 0 To UBound(myPort)
                    CmbPort.Items.Add(myPort(i))
                Next
                CmbPort.Text = CmbPort.Items.Item(0)    'Set cmbPort text to the first COM port detected
            Else                                                                               'without disconnecting first.
                MsgBox("Please disconnect before attempting to change comm port", vbCritical)
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub cmbPort_SelectedIndexChanged: " & ex.Message)
        End Try

    End Sub

    Private Sub PbOpenScript_Click(sender As Object, e As EventArgs) Handles pbOpenScript.Click
        Try
            If fbdScriptFileSelect.ShowDialog() = DialogResult.OK Then
                tbScriptFile.Text = fbdScriptFileSelect.FileName
            End If
            scriptFeedBox.Text = ""
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub pbOpenScript_Click: " & ex.Message)
        End Try

    End Sub

    Private Function ReadScriptFile(fileReader As System.IO.StreamReader) As Integer
        'This routine reads the data from the script file and executes the commands one at a time
        Dim stringReader As String
        Dim scriptIndex As Integer
        Dim byteOffset(5) As Integer
        Dim byteValue(5) As Integer
        'If index in bytePass has already been tripped, previous value has made it true
        Dim bytePass(20) As Boolean
        'True is corrosponding index is relevent. Only an index marked true in indexUsed is evaluated in bytePass
        Dim indexUsed(20) As Boolean
        Dim paramCount, i, j As Integer
        Dim verifyPass As Boolean

        'Initialize bytePass and indexUsed values
        i = 0
        Do While i < 20
            bytePass(i) = False
            indexUsed(i) = False
            i += 1
        Loop

        Try
            If pbManCont.Enabled = False Then
                stringReader = "#"
                Do While Mid(stringReader, 1, 1) = "#"
                    stringReader = fileReader.ReadLine()
                    testScriptLine += 1
                Loop

                '*******************************************
                'Script Control messages
                '*******************************************
                'The next script command is located
                If (Mid(stringReader, 1, 9) = "EndScript") Then
                    scriptFileReader.Close()
                    nextScriptTime = New DateTime(1970, 1, 1)
                    pbExecuteScript.Enabled = True
                    testScriptbtn.Enabled = True
                    pbOpenScript.Enabled = True
                    pbKillScript.Enabled = False
                    If scriptPassed = 0 Then
                        SendToLog("", "Test Script Execution Completed: All Tests Successful")
                        AddToScriptFeed("Test Script Execution Completed: All Tests Successful")
                    ElseIf scriptPassed = 1 Then
                        SendToLog("", "Test Script Execution Completed: 1 Test Failed")
                        AddToScriptFeed("Test Script Execution Completed: 1 Test Failed")
                    Else
                        SendToLog("", "Test Script Execution Completed: " & scriptPassed & " Tests Failed")
                        AddToScriptFeed("Test Script Execution Completed: " & scriptPassed & " Tests Failed")
                    End If
                    scriptPassed = 0
                    Return -1

                ElseIf (Mid(stringReader, 1, 10) = "LogComment") Then
                    SendToLog("", "Script Comment: " & Mid(stringReader, 12, stringReader.Length - 11))
                    AddToScriptFeed(Mid(stringReader, 12, stringReader.Length - 11))

                ElseIf (Mid(stringReader, 1, 14) = "ManualValidate") Then
                    pbManCont.Enabled = True        ' Set to true to halt script
                    pbManCont.Visible = False       ' but make invisible
                    pbManualPass.Enabled = True     ' Make pass button visible and functional
                    pbManualPass.Visible = True
                    pbManualFail.Enabled = True     ' Make pass button visible and functional
                    pbManualFail.Visible = True
                    AddToScriptFeed("Click Pass of Fail buttton to continue")

                ElseIf (Mid(stringReader, 1, 5) = "Delay") Then
                    nextScriptTime = DateTime.Now.AddMilliseconds(GetParam1int(7, stringReader))     'Wait for specified number of ms before processing next command
                    AddToScriptFeed("Delay")

                ElseIf (Mid(stringReader, 1, 6) = "Device") Then
                    If (Mid(stringReader, 8, 3) = "UCM") Then
                        If rbMode1.Checked = True Then
                            Return 0        'Device type is verified
                        Else
                            'Trying to run UCM script in SGD
                            ReceivedText("", "Error - Trying to run UCM script in SGD")
                            Return -1
                        End If
                    Else
                        If rbMode2.Checked = True Then
                            Return 0        'Device type is verified
                        Else
                            'Trying to run SGD script in UCM
                            ReceivedText("", "Error - Trying to run SGD script in UCM")
                            Return -1
                        End If
                    End If

                ElseIf (Mid(stringReader, 1, 10) = "HaltOnFail") Then
                    haltOnFail = True

                ElseIf (Mid(stringReader, 1, 5) = "Pause") Then
                    AddToScriptFeed(Mid(stringReader, 7, stringReader.Length - 6))
                    pbManCont.Enabled = True
                    pbManCont.Visible = True

                ElseIf (Mid(stringReader, 1, 9) = "BadOpCode") Then
                    scriptIndex = 11
                    badOpcode1cb.Checked = True
                    badOpcode2cb.Checked = True
                    badOpcode1valbox.Value = GetParam1int(scriptIndex, stringReader)
                    badOpcode2valbox.Value = GetParam1int(scriptIndex, stringReader)

                ElseIf (Mid(stringReader, 1, 14) = "ResetBadOpCode") Then
                    badOpcode1cb.Checked = False
                    badOpcode2cb.Checked = False
                    AddToScriptFeed("Bad OpCodes Reset")

                ElseIf (Mid(stringReader, 1, 13) = "CustomCommand") Then
                    scriptIndex = 15
                    Try
                        Do While scriptIndex <= stringReader.Length
                            i = GetParam1int(scriptIndex, stringReader)
                            j = GetParam1int(scriptIndex, stringReader)
                            Select Case i
                                Case 0
                                    customMsgType1cb.Checked = True
                                    customMsgType1ValBox.Value = j
                                Case 1
                                    customMsgType2cb.Checked = True
                                    customMsgType2ValBox.Value = j
                                Case 2
                                    customLength1cb.Checked = True
                                    customLength1ValBox.Value = j
                                Case 3
                                    customLength2cb.Checked = True
                                    customLength2ValBox.Value = j
                                Case 4
                                    badOpcode1cb.Checked = True
                                    badOpcode1valbox.Value = j
                                Case 5
                                    badOpcode2cb.Checked = True
                                    badOpcode2valbox.Value = j
                            End Select
                        Loop
                    Catch e As Exception
                        AddToScriptFeed("Custom Command on line " + Convert.ToString(testScriptLine) + " has a problem!")
                        PbKillScript_Click(Ex_sender, Ex_e)
                    End Try

                ElseIf (Mid(stringReader, 1, 18) = "ResetCustomCommand") Then
                    badOpcode1cb.Checked = False
                    badOpcode2cb.Checked = False
                    customLength1cb.Checked = False
                    customLength2cb.Checked = False
                    customMsgType1cb.Checked = False
                    customMsgType2cb.Checked = False
                    AddToScriptFeed("Custom bytes reset")

                ElseIf (Mid(stringReader, 1, 14) = "ValidateResult") Then
                    scriptIndex = 16
                    paramCount = 0
                    'Loop through arguments and add them to arrays for processing
                    Do While scriptIndex < stringReader.Length
                        byteOffset(paramCount) = GetParam1int(scriptIndex, stringReader)
                        byteValue(paramCount) = GetParam1int(scriptIndex, stringReader)
                        paramCount += 1
                    Loop
                    i = 0
                    verifyPass = True
                    'Loop through indecies and correct values
                    'If index appears twice, either accompaning value will be counted correct
                    Do While i < paramCount
                        If byteOffset(i) < lastReceivedMsgSize Then
                            If bytePass(byteOffset(i)) = False Then
                                If lastReceivedMsg(byteOffset(i)) = byteValue(i) Then
                                    bytePass(byteOffset(i)) = True
                                End If
                                indexUsed(byteOffset(i)) = True
                            End If
                            i += 1
                        Else
                            verifyPass = False
                            Exit Do
                        End If
                    Loop
                    'Loop through bytePass and check if any index marked used is false, if so, test fails
                    i = 0
                    Do While i < 20
                        If indexUsed(i) = True Then
                            If (bytePass(i) = False) Then
                                verifyPass = False
                            End If
                        End If
                        i += 1
                    Loop

                    If verifyPass = True Then
                        AddToScriptFeed("Pass")
                        SendToLog("", "Script: Pass")
                    Else
                        scriptPassed += 1
                        AddToScriptFeed("Fail")
                        SendToLog("", "Script: Fail")
                        If haltOnFail = True Then
                            scriptFileReader.Close()
                            nextScriptTime = New DateTime(1970, 1, 1)
                            pbExecuteScript.Enabled = True
                            testScriptbtn.Enabled = True
                            pbKillScript.Enabled = False
                            AddToScriptFeed("Test script execution aborted on failure")
                        End If
                    End If
                    lastReceivedMsgSize = 0

                    '*******************************************
                    'Link Layer messages
                    '*******************************************
                ElseIf (Mid(stringReader, 1, 14) = "MsgTypeSupport") Then
                    scriptIndex = 16
                    nudSupMsgQueryMSB.Value = GetParam1int(scriptIndex, stringReader)
                    nudSupMsgQueryLSB.Value = GetParam1int(scriptIndex, stringReader)
                    MsgTypeQuery_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Message Type Support query")

                ElseIf (Mid(stringReader, 1, 15) = "QueryMaxPayload") Then  'Send a Max Payload Query
                    BtnMaxPayload_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Max Payload query")

                ElseIf (Mid(stringReader, 1, 13) = "ReqPowerLimit") Then  'Send a Power Limit Request
                    scriptIndex = 15
                    nudPowerLimit.Value = GetParam1int(scriptIndex, stringReader)
                    PbPowerLimit_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Request Power Limit")

                    '*******************************************
                    'Basic messages
                    '*******************************************
                ElseIf (Mid(stringReader, 1, 4) = "Shed") Then
                    trkShedDur.Value = GetParam1int(6, stringReader)
                    BtnShedSend_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Shed Event")

                ElseIf (Mid(stringReader, 1, 9) = "RunNormal") Then
                    BtnEndShed_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("End Shed/Run Normal")

                ElseIf (Mid(stringReader, 1, 13) = "ReqPowerLevel") Then
                    tbarPower.Value = GetParam1int(15, stringReader)
                    BtnRPLAccept_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Request Power Level")

                ElseIf (Mid(stringReader, 1, 12) = "PresRelPrice") Then
                    presentPriceTrackBar.Value = GetParam1int(14, stringReader)
                    PresentPriceButton_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Present Relative Price")

                ElseIf (Mid(stringReader, 1, 12) = "NextRelPrice") Then
                    nextPeriodTrackBar.Value = GetParam1int(14, stringReader)
                    NextPeriodPriceButton_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Next Relative Price")

                ElseIf (Mid(stringReader, 1, 10) = "TimeRemain") Then
                    timeRemainingTrackBar.Value = GetParam1int(12, stringReader)
                    TimeRemainingButton_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Time Remaining")

                ElseIf (Mid(stringReader, 1, 12) = "CriticalPeak") Then
                    trkShedDur.Value = GetParam1int(14, stringReader)
                    CriticalPeakButton_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Critical Peak Pricing Event")

                ElseIf (Mid(stringReader, 1, 13) = "GridEmergency") Then
                    trkShedDur.Value = GetParam1int(15, stringReader)
                    GridEmergencyButton_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Grid Emergency Event")

                ElseIf (Mid(stringReader, 1, 12) = "GridGuidence") Then
                    cmbGridGuide.SelectedIndex = GetParam1int(14, stringReader)
                    SendGuidenceButton_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Grid Guidance Event")

                ElseIf (Mid(stringReader, 1, 10) = "CommStatus") Then       'Send out a comm status message
                    'Set the status type
                    If (Mid(stringReader, 12, 4) = "Good") Then     'Send Comm Good Message
                        realUCMCommStatusBox.SelectedIndex = 2             'Set Index to appropriate value
                    ElseIf (Mid(stringReader, 12, 4) = "None") Then 'Send Comm Bad Message
                        realUCMCommStatusBox.SelectedIndex = 1
                    ElseIf (Mid(stringReader, 12, 4) = "Poor") Then 'Send Comm Poor Message
                        realUCMCommStatusBox.SelectedIndex = 3
                    End If
                    scriptIndex = 17

                    'Set the auto update time
                    autoCommStatusTimer.Interval = GetParam1int(scriptIndex, stringReader)

                    'Send message
                    AddToScriptFeed("Sending Comm Status")
                    SendCommStatus(realUCMCommStatusBox.SelectedIndex - 1)

                ElseIf (Mid(stringReader, 1, 12) = "QueryOpState") Then
                    PbOpState_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Query Operating State")

                ElseIf (Mid(stringReader, 1, 12) = "QueryOpStateResp") Then
                    SendOpStateBtn_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Sent Query Operating State response")

                ElseIf (Mid(stringReader, 1, 6) = "LoadUp") Then
                    trkShedDur.Value = GetParam1int(8, stringReader)
                    PbLoadUp_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Load Up Event")

                ElseIf (Mid(stringReader, 1, 17) = "SendPendEventTime") Then
                    trkPendEventDuration.Value = GetParam1int(19, stringReader)
                    SendPendEventTimePb_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Sent Pending Event Time")

                ElseIf (Mid(stringReader, 1, 17) = "SendPendEventType") Then
                    pendEventTypeCb.SelectedIndex = GetParam1int(19, stringReader)
                    SendPendEventTypePb_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Sent Pending Event Type")

                ElseIf (Mid(stringReader, 1, 6) = "Reboot") Then
                    cbRebootType.SelectedIndex = GetParam1int(8, stringReader)
                    BReboot_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Reboot Request")

                    '*******************************************
                    'Intermediate messages
                    '*******************************************
                ElseIf (Mid(stringReader, 1, 13) = "DeviceInfo") Then
                    QueryDeviceInfoButton_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Query Device Information")

                ElseIf (Mid(stringReader, 1, 10) = "SetUTCTime") Then
                    scriptIndex = 12
                    nudUTCOffset.Value = GetParam1int(scriptIndex, stringReader)
                    nudDSTOffset.Value = GetParam1int(scriptIndex, stringReader)
                    BtnSetUTC_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Set UTC Time")

                ElseIf (Mid(stringReader, 1, 14) = "GetEnergyPrice") Then
                    PbGetEnergyPrice_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Sent Get Energy Price Request")

                ElseIf (Mid(stringReader, 1, 14) = "SetEnergyPrice") Then
                    PbSetEnergyPrice_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Sent Set Energy Price Request")

                ElseIf (Mid(stringReader, 1, 13) = "SetTempOffset") Then
                    nudTempOffset.Value = GetParam1int(15, stringReader)
                    PbSetTempOffset_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Sent Set Temperature Offset Request")

                ElseIf (Mid(stringReader, 1, 13) = "GetTempOffset") Then
                    PbRequestTempOffset_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Sent Get Temperature Offset Request")

                ElseIf (Mid(stringReader, 1, 15) = "SetTempSetpoint") Then
                    nudSetPoint1.Value = GetParam1int(17, stringReader)
                    nudSetPoint2.Value = GetParam1int(23, stringReader)
                    i = GetParam1int(29, stringReader)
                    If (i = 0) Then
                        cbSetpoint2Support.Checked = True
                    Else
                        cbSetpoint2Support.Checked = False
                    End If
                    PbSetSetPoint_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Sent Set Temperature Setpoint Request")

                ElseIf (Mid(stringReader, 1, 15) = "GetTempSetpoint") Then
                    PbRequestSetpoint_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Sent Get Temperature Setpoint Request")

                ElseIf (Mid(stringReader, 1, 11) = "GetPresTemp") Then
                    PbGetPresentTemp_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Get Present Temperature Request")

                ElseIf (Mid(stringReader, 1, 16) = "AutoCyclingStart") Then
                    BtnStartCycling_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Autonomous Cycling Started")

                ElseIf (Mid(stringReader, 1, 15) = "AutoCyclingStop") Then
                    BtnStopCycling_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Autonomous Cycling Stopped")

                ElseIf (Mid(stringReader, 1, 12) = "CommodityGet") Then
                    nudCommodityNum.Value = GetParam1int(14, stringReader)
                    PbGetCommodity_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Get Commodity")

                ElseIf (Mid(stringReader, 1, 13) = "ActivationGet") Then
                    PbGetActStatus_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Sent Get Activation command")

                ElseIf (Mid(stringReader, 1, 13) = "ActivationSet") Then
                    PbSetActStatus_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Sent Set Activation command")

                ElseIf (Mid(stringReader, 1, 16) = "UserPrefLevelGet") Then
                    PbGetPrefLevel_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Sent Get User Preference Level command")

                ElseIf (Mid(stringReader, 1, 16) = "UserPrefLevelSet") Then
                    PbSetPrefLevel_Click(Ex_sender, Ex_e)
                    AddToScriptFeed("Sent Set User Preference Level command")

                ElseIf (Mid(stringReader, 1, 20) = "SetInterResponseCode") Then
                    cbInterRespCode.SelectedIndex = GetParam1int(22, stringReader)
                    AddToScriptFeed("Set default intermediate command response code")

                ElseIf (Mid(stringReader, 1, 9) = "RawPacket") Then  'Send a Raw Packet to other device
                    Dim dataString As String()
                    Dim xmitBuffer() As Byte
                    Try
                        dataString = Mid(stringReader, 11).Split()
                        ReDim xmitBuffer(dataString.Count + 1)
                        For index As Integer = 0 To dataString.Count - 1
                            xmitBuffer(index) = CInt("&H" & dataString(index))
                        Next

                        SendComData(xmitBuffer, dataString.Length, "Sending Raw DR Packets", pendingLinkAck)

                    Catch e As Exception
                        addToScriptFeed("Custom Command on line " + Convert.ToString(testScriptLine) + " has a problem!")
                        pbKillScript_Click(Ex_sender, Ex_e)
                    End Try

                Else
                    scriptFileReader.Close()
                    nextScriptTime = New DateTime(1970, 1, 1)
                    pbExecuteScript.Enabled = True
                    testScriptbtn.Enabled = True
                    pbKillScript.Enabled = False
                    AddToScriptFeed("Undefined command in test script line " + Convert.ToString(testScriptLine))
                    Return -1
                End If
            End If
            Return 0

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub ReadScriptFile: " & ex.Message)
            Return -1
        End Try

    End Function

    Private Sub PbExecuteScript_Click(sender As Object, e As EventArgs) Handles pbExecuteScript.Click

        Ex_sender = sender
        Ex_e = e
        scriptFeedBox.Text = ""
        'Check that the file exists
        If My.Computer.FileSystem.FileExists(tbScriptFile.Text) Then
            testScriptLine = 0
            pbKillScript.Enabled = True
            pbOpenScript.Enabled = True
            pbManCont.Enabled = False
            pbExecuteScript.Enabled = False
            testScriptbtn.Enabled = False
            haltOnFail = False
            scriptFileReader = My.Computer.FileSystem.OpenTextFileReader(tbScriptFile.Text)
            nextScriptTime = DateTime.Now.AddMilliseconds(0)     'Execute immediately
            If ReadScriptFile(scriptFileReader) <> 0 Then
                'Device type failed validation
                scriptFileReader.Close()
                nextScriptTime = New DateTime(1970, 1, 1)
                pbExecuteScript.Enabled = True
                testScriptbtn.Enabled = True
                pbKillScript.Enabled = False
            End If
        Else
            MsgBox("No valid scipt file!")
        End If

    End Sub

    Private Sub PbKillScript_Click(sender As Object, e As EventArgs) Handles pbKillScript.Click
        scriptFileReader.Close()
        nextScriptTime = New DateTime(1970, 1, 1)
        nextScriptTestTime = New DateTime(1970, 1, 1)
        pbKillScript.Enabled = False
        pbExecuteScript.Enabled = True
        testScriptbtn.Enabled = True
        ReceivedText("", "Test Script Execution Aborted")

    End Sub

    'Add text to the feed box and continue to scroll to the bottom
    Private Sub AddToScriptFeed(ByRef text As String)

        Try
            'compares the ID of the creating Thread to the ID of the calling Thread
            If Me.rtbReceived.InvokeRequired Then
                Dim x As New SetTextCallback3(AddressOf AddToScriptFeed)
                Me.Invoke(x, New Object() {(text)})
            Else
                If text <> "" Then
                    Me.scriptFeedBox.Text &= text & ControlChars.CrLf
                    scriptFeedBox.Select(scriptFeedBox.Text.Length, 0)
                    scriptFeedBox.ScrollToCaret()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub ReceivedText: " & ex.Message)
        End Try
    End Sub

    Private Function GetParam1int(ByRef scriptIndex As Integer, ByRef textString As String)
        Dim tempStr As String
        ' TODO : Skip Extra Space between Commands or Parameters
        'For index = scriptIndex To (textString.Length + 1)
        '    If Mid(textString, scriptIndex, 1) <> " " Then
        '        Exit For
        '    End If
        '    scriptIndex += 1
        'Next
        tempStr = ""
        While Mid(textString, scriptIndex, 1) <> " " And scriptIndex < (textString.Length + 1)
            tempStr = tempStr + Mid(textString, scriptIndex, 1)
            scriptIndex = scriptIndex + 1
        End While
        scriptIndex = scriptIndex + 1
        GetParam1int = Convert.ToInt32(tempStr)
    End Function

    Private Sub PbManCont_Click(sender As Object, e As EventArgs) Handles pbManCont.Click
        pbManCont.Enabled = False
        pbManCont.Visible = False
        scriptFeedBox.Font = New Font(scriptFeedBox.Font.FontFamily, 10, FontStyle.Regular)
    End Sub

    Private Sub PbManualPass_Click(sender As Object, e As EventArgs) Handles pbManualPass.Click
        pbManCont.Enabled = False        ' Set to true to halt script
        pbManualPass.Enabled = False
        pbManualPass.Visible = False
        pbManualFail.Enabled = False
        pbManualFail.Visible = False
        'logFileBuffer &= "Pass"
        SendToLog("", "Script: Pass")

    End Sub

    Private Sub PbManualFail_Click(sender As Object, e As EventArgs) Handles pbManualFail.Click
        pbManCont.Enabled = False        ' Set to true to halt script
        pbManualPass.Enabled = False
        pbManualPass.Visible = False
        pbManualFail.Enabled = False
        pbManualFail.Visible = False
        scriptPassed += 1
        SendToLog("", "Script: Fail")

    End Sub

    Private Sub TsmAbout_Click(sender As Object, e As EventArgs)
        License.Show()
    End Sub

    Private Sub NudSupMsgQueryMSB_ValueChanged(sender As Object, e As EventArgs)
        'Valid messages currently only start with 8 or 9, other values cause bugs
        If nudSupMsgQueryMSB.Value > 9 Then
            nudSupMsgQueryMSB.Value = 9
        ElseIf nudSupMsgQueryMSB.Value < 8 Then
            nudSupMsgQueryMSB.Value = 8
        End If
    End Sub

    Private Sub SendCommStatusBtn_Click(sender As Object, e As EventArgs)
        MsgBox("5 Seconds = 5000ms" & Environment.NewLine &
                           "30 Seconds = 30000ms" & Environment.NewLine &
                           "1 Minute = 60000ms" & Environment.NewLine &
                           "4 Minutes = 240000ms" & Environment.NewLine &
                           "5 Minutes = 300000ms" & Environment.NewLine &
                           "10 Minutes = 600000ms" & Environment.NewLine &
                           "1 Hour = 3600000ms")
    End Sub

    Private Sub AutoCommStatusTimer_Tick(sender As Object, e As EventArgs) Handles autoCommStatusTimer.Tick

        Try
            'If enabled, send a comm status every tick
            If cbResponseSim.Checked = True Then
                If realUCMCommStatusBox.SelectedIndex <> 0 Then
                    SendCommStatus(realUCMCommStatusBox.SelectedIndex - 1)
                End If
            Else
                autoCommStatusTimer.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub autoCommStatusTimer_Tick" & ex.Message)
        End Try

    End Sub

    Private Sub RealUCMCommStatusBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles realUCMCommStatusBox.SelectedIndexChanged

        'If manual mode is not selected and simulating a real device
        If cbResponseSim.Checked = True And realUCMCommStatusBox.SelectedIndex <> 0 Then
            'Send first message
            SendCommStatus(realUCMCommStatusBox.SelectedIndex - 1)
            'Enable timer to start sending messages automatically
            autoCommStatusTimer.Enabled = True
        Else
            autoCommStatusTimer.Enabled = False
        End If

    End Sub

    Private Sub RealUCMTrasmissionIntervalBox_ValueChanged(sender As Object, e As EventArgs) Handles realUCMTrasmissionIntervalBox.ValueChanged
        autoCommStatusTimer.Interval = realUCMTrasmissionIntervalBox.Value * 1000
    End Sub

    Private Sub ShedEventTimer_Tick(sender As Object, e As EventArgs) Handles shedEventTimer.Tick
        'Count down to the end of the event
        If shedEventTime > 0 Then
            shedEventTime = shedEventTime - 1
        Else
            If rbMode1.Checked = True Then      'This is a UCM
                BtnEndShed_Click(Ex_sender, Ex_e)
            Else                                'This is an SGD
                Select Case realSGDEndShedResponse.SelectedIndex
                    Case 0
                        'Set to manual, so assume preshed
                        OpStateBox.SelectedIndex = preShedOpState
                    Case 1
                        OpStateBox.SelectedIndex = 1
                    Case 2
                        OpStateBox.SelectedIndex = 0
                    Case 3
                        OpStateBox.SelectedIndex = preShedOpState
                    Case 4
                        OpStateBox.SelectedIndex = 5
                End Select
            End If
            shedEventTimer.Enabled = False      'Shut off timer
        End If
    End Sub

    Private Sub CommStatusTimoutTmr_Tick(sender As Object, e As EventArgs) Handles commStatusTimoutTmr.Tick
        'Checks that everything is still enabled
        If cbResponseSim.Checked = True And internalClockSupportedcb.Checked = True Then
            'Count down from last comm status received
            If commStatusTimeoutTime > 0 Then
                commStatusTimeoutTime = commStatusTimeoutTime - 1
            Else
                'No comm status has been recieved within the specified time
                If cbResponseSim.Checked = True Then
                    'Cancel Shed Event
                    Select Case realSGDEndShedResponse.SelectedIndex
                        Case 0
                            'Set to manual so do nothing
                        Case 1
                            OpStateBox.SelectedIndex = 1
                        Case 2
                            OpStateBox.SelectedIndex = 0
                        Case 3
                            OpStateBox.SelectedIndex = preShedOpState
                        Case 4
                            OpStateBox.SelectedIndex = 5
                    End Select
                    'Shuts off shed event timer
                    shedEventTimer.Enabled = False
                End If
                ReceivedText("", "No Comm Status has been received in " & realSGDNoCommTimeoutValBox.Value & " seconds! Resetting.")
                'Reset Price
                'As of writing this, nothing is done when pricing info is recieved, so there is nothing to reset
                'Reset Grid Guidance
                ProcessGridGuidance(1, 0, "")
                'Reset timer
                commStatusTimeoutTime = realSGDNoCommTimeoutValBox.Value
            End If
        Else
            commStatusTimeoutTime = realSGDNoCommTimeoutValBox.Value
            autoCommStatusTimer.Enabled = False
            realSGDNoCommTimeoutEnabledbtn.Text = "Enable"
        End If
    End Sub

    Private Sub RealSGDNoCommTimeoutEnabledbtn_Click(sender As Object, e As EventArgs) Handles realSGDNoCommTimeoutEnabledbtn.Click
        If (cbResponseSim.Checked = True And internalClockSupportedcb.Checked = True) Or realSGDNoCommTimeoutEnabledbtn.Text = "Disable" Then
            If realSGDNoCommTimeoutEnabledbtn.Text = "Enable" Then
                commStatusTimeoutTime = realSGDNoCommTimeoutValBox.Value
                commStatusTimoutTmr.Enabled = True
                realSGDNoCommTimeoutEnabledbtn.Text = "Disable"
            Else
                commStatusTimoutTmr.Enabled = False
                realSGDNoCommTimeoutEnabledbtn.Text = "Enable"
            End If
        End If
    End Sub

    Private Sub SendCommStatusBtn_Click_1(sender As Object, e As EventArgs) Handles SendCommStatusBtn.Click
        SendCommStatus(cmbCommStatus.SelectedIndex)
    End Sub

    Private Sub CbResponseSim_CheckedChanged(sender As Object, e As EventArgs) Handles cbResponseSim.CheckedChanged

        If cbResponseSim.Checked = True Then
            autoCommStatusTimer.Enabled = True
        Else
            autoCommStatusTimer.Enabled = False
        End If
    End Sub

    Private Sub BadOpcode1cb_CheckedChanged(sender As Object, e As EventArgs) Handles badOpcode1cb.CheckedChanged
        If badOpcode1cb.Checked = True Then
            badOpcode1valbox.Enabled = True
        Else
            badOpcode1valbox.Enabled = False
        End If

    End Sub

    Private Sub BadOpcode2cb_CheckedChanged(sender As Object, e As EventArgs) Handles badOpcode2cb.CheckedChanged
        If badOpcode2cb.Checked = True Then
            badOpcode2valbox.Enabled = True
        Else
            badOpcode2valbox.Enabled = False
        End If
    End Sub

    Private Sub TestScriptbtn_Click(sender As Object, e As EventArgs) Handles testScriptbtn.Click
        Ex_sender = sender
        Ex_e = e
        scriptFeedBox.Text = ""
        'Check that the file exists
        If My.Computer.FileSystem.FileExists(tbScriptFile.Text) Then
            testScriptLine = 0
            pbKillScript.Enabled = True
            pbOpenScript.Enabled = True
            pbManCont.Enabled = False
            pbExecuteScript.Enabled = False
            testScriptbtn.Enabled = False
            haltOnFail = False
            scriptFileReader = My.Computer.FileSystem.OpenTextFileReader(tbScriptFile.Text)
            nextScriptTestTime = DateTime.Now.AddMilliseconds(0)     'Execute immediately
            If TestScriptFile(scriptFileReader) <> 0 Then
                'Device type failed validation
                scriptFileReader.Close()
                nextScriptTestTime = New DateTime(1970, 1, 1)
                pbExecuteScript.Enabled = True
                testScriptbtn.Enabled = True
                pbKillScript.Enabled = False
            End If
        Else
            MsgBox("No valid scipt file!")
        End If
    End Sub

    Private Function TestScriptFile(scriptFileReader As StreamReader) As Integer
        'This routine reads the data from the script file and executes the commands one at a time
        Dim stringReader As String
        Dim scriptIndex As Integer
        Dim byteOffset(5) As Integer
        Dim byteValue(5) As Integer
        Dim bytePass(20) As Boolean
        Dim indexUsed(20) As Boolean
        Dim i, j As Integer
        Dim paramCount As Integer

        Try
            'If pbManCont.Enabled = False Then
            stringReader = "#"
            Do While Mid(stringReader, 1, 1) = "#"
                stringReader = scriptFileReader.ReadLine()
                testScriptLine += 1
            Loop

            'The next script command is located
            If (Mid(stringReader, 1, 9) = "EndScript") Then
                scriptFileReader.Close()
                nextScriptTestTime = New DateTime(1970, 1, 1)
                pbExecuteScript.Enabled = True
                testScriptbtn.Enabled = True
                pbOpenScript.Enabled = True
                pbKillScript.Enabled = False
                AddToScriptFeed("Test script finished testing: All commands appear valid")
                Return 0

            ElseIf (Mid(stringReader, 1, 16) = "AutoCyclingStart") Then
                AddToScriptFeed("Autonomous Cycling Start Command")
                Return 0

            ElseIf (Mid(stringReader, 1, 15) = "AutoCyclingStop") Then
                AddToScriptFeed("Autonomous Cycling Stop Command")
                Return 0

            ElseIf (Mid(stringReader, 1, 12) = "CriticalPeak") Then
                Try
                    i = GetParam1int(14, stringReader)
                    AddToScriptFeed("Critical Peak Pricing Event: " + Convert.ToString(i))
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("Critical Peak command on line " + Convert.ToString(testScriptLine) + " has no time parameter!")
                End Try

            ElseIf (Mid(stringReader, 1, 5) = "Delay") Then
                Try
                    i = GetParam1int(7, stringReader)
                    AddToScriptFeed("Delay Command: " + Convert.ToString(i))
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("Delay command on line " + Convert.ToString(testScriptLine) + " has no time parameter!")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 13) = "DeviceInfo") Then
                AddToScriptFeed("Device Info Query Command")
                Return 0

            ElseIf (Mid(stringReader, 1, 6) = "Device") Then
                If (Mid(stringReader, 8, 3) = "UCM") Then
                    AddToScriptFeed("Device UCM")
                    Return 0
                ElseIf (Mid(stringReader, 8, 3) = "SGD") Then
                    AddToScriptFeed("Device SGD")
                    Return 0
                Else
                    AddToScriptFeed("Device command at line " + Convert.ToString(testScriptLine) + " is missing device type")
                    KillScriptTest()
                    Return 1
                End If

            ElseIf (Mid(stringReader, 1, 13) = "GridEmergency") Then
                Try
                    i = GetParam1int(15, stringReader)
                    AddToScriptFeed("Grid Emergency Event")
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("Grid Emergency command on line " + Convert.ToString(testScriptLine) + " has no time parameter!")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 12) = "GridGuidence") Then
                Try
                    i = GetParam1int(14, stringReader)
                    If i = 1 Or i = 2 Or i = 3 Then
                        AddToScriptFeed("Grid Guidance: " + Convert.ToString(i))
                        Return 0
                    Else
                        AddToScriptFeed("Grid Guidance command on line " + Convert.ToString(testScriptLine) + " does not have a valid parameter (guidance number)")
                        KillScriptTest()
                        Return 1
                    End If

                Catch e As Exception
                    AddToScriptFeed("Grid Guidance command on line " + Convert.ToString(testScriptLine) + " does not have a parameter!")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 10) = "HaltOnFail") Then
                AddToScriptFeed("Halt on Fail: True")
                Return 0

            ElseIf (Mid(stringReader, 1, 9) = "LoadUpEnd") Then
                AddToScriptFeed("Load Up Event Terminate")
                Return 0

            ElseIf (Mid(stringReader, 1, 6) = "LoadUp") Then
                Try
                    i = GetParam1int(8, stringReader)
                    AddToScriptFeed("Load Up Event")
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("Load Up command on line " + Convert.ToString(testScriptLine) + " has no time parameter!")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 10) = "LogComment") Then
                Try
                    AddToScriptFeed(Mid(stringReader, 12, stringReader.Length - 11))
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("Log Comment command on line " + Convert.ToString(testScriptLine) + " has no comment!")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 14) = "ManualValidate") Then
                AddToScriptFeed("Manual Validate Command")
                Return 0

            ElseIf (Mid(stringReader, 1, 14) = "MsgTypeSupport") Then
                scriptIndex = 16
                Try
                    i = GetParam1int(scriptIndex, stringReader)
                    j = GetParam1int(scriptIndex, stringReader)
                    AddToScriptFeed("Message Type Support Query Command " + Convert.ToString(i) + " " + Convert.ToString(j))
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("Message Type Supported Query command on line " + Convert.ToString(testScriptLine) + " does not have a valid number of parameters!")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 12) = "NextRelPrice") Then
                Try
                    i = GetParam1int(14, stringReader)
                    AddToScriptFeed("Next Relative Price ratio: " + Convert.ToString(i))
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("Next Relative Price command on line " + Convert.ToString(testScriptLine) + " has no parameter!")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 5) = "Pause") Then
                Try
                    AddToScriptFeed(Mid(stringReader, 7, stringReader.Length - 6))
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("Pause command on line " + Convert.ToString(testScriptLine) + " has no valid comment!")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 12) = "PresRelPrice") Then
                Try
                    i = GetParam1int(14, stringReader)
                    AddToScriptFeed("Present Relative Price ratio: " + Convert.ToString(i))
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("Present Relative Price command on line " + Convert.ToString(testScriptLine) + " has no parameter!")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 12) = "QueryOpState") Then
                AddToScriptFeed("Query Operating State")
                Return 0

            ElseIf (Mid(stringReader, 1, 13) = "ReqPowerLevel") Then
                Try
                    i = GetParam1int(15, stringReader)
                    AddToScriptFeed("Request Power Level ratio: " + Convert.ToString(i))
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("Request Power Level command on line " + Convert.ToString(testScriptLine) + " has no parameter!")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 9) = "RunNormal") Then
                AddToScriptFeed("End Shed/Run Normal")
                Return 0

            ElseIf (Mid(stringReader, 1, 10) = "SetUTCTime") Then
                scriptIndex = 12
                Try
                    i = GetParam1int(scriptIndex, stringReader)
                    j = GetParam1int(scriptIndex, stringReader)
                    AddToScriptFeed("Set UTC Time command. UTC offset: " + Convert.ToString(i) + "   STO offset: " + Convert.ToString(j))
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("UTC Time command on line " + Convert.ToString(testScriptLine) + " has incorrect number of parameters!")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 4) = "Shed") Then
                Try
                    i = GetParam1int(6, stringReader)
                    AddToScriptFeed("Shed Event: " + Convert.ToString(i))
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("Shed Event command on line " + Convert.ToString(testScriptLine) + " has no time parameter!")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 10) = "TimeRemain") Then
                Try
                    i = GetParam1int(12, stringReader)
                    AddToScriptFeed("Time Remaining: " + Convert.ToString(i))
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("Time Remaining command on line " + Convert.ToString(testScriptLine) + " has no time parameter!")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 9) = "BadOpCode") Then
                scriptIndex = 11
                Try
                    i = GetParam1int(scriptIndex, stringReader)
                    j = GetParam1int(scriptIndex, stringReader)
                    AddToScriptFeed("Bad Opcode. Opcode 1: " + Convert.ToString(i) + "   Opcode 2: " + Convert.ToString(j))
                    Return 0
                Catch e As Exception
                    AddToScriptFeed("Bad Opcode command on line " + Convert.ToString(testScriptLine) + " has incorrect number of parameters")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 13) = "CustomCommand") Then
                Try
                    scriptIndex = 15
                    paramCount = 0
                    Do While scriptIndex <= stringReader.Length
                        i = GetParam1int(scriptIndex, stringReader)
                        paramCount += 1
                    Loop
                    If paramCount Mod 2 = 1 Then
                        AddToScriptFeed("Custom command on line " + Convert.ToString(testScriptLine) + " has an odd number of parameters!")
                        KillScriptTest()
                        Return 1
                    ElseIf paramCount = 0 Then
                        AddToScriptFeed("Custom command on line " + Convert.ToString(testScriptLine) + " has no parameters!")
                        KillScriptTest()
                        Return 1
                    Else
                        AddToScriptFeed("Custom command")
                        Return 0
                    End If

                Catch e As Exception
                    AddToScriptFeed("Custom command on line " + Convert.ToString(testScriptLine) + " has incorrect number of parameters")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 18) = "ResetCustomCommand") Then
                AddToScriptFeed("ResetCustomCommand")
                Return 0

            ElseIf (Mid(stringReader, 1, 14) = "ResetBadOpCode") Then
                AddToScriptFeed("Reset Bad Opcode")
                Return 0

            ElseIf (Mid(stringReader, 1, 14) = "ValidateResult") Then
                scriptIndex = 16
                paramCount = 0
                Try
                    'Loop through arguments and add them to arrays for processing
                    Do While scriptIndex <= stringReader.Length
                        i = GetParam1int(scriptIndex, stringReader)
                        paramCount += 1
                    Loop
                    If paramCount Mod 2 = 1 Then
                        AddToScriptFeed("Validate Result command on line " + Convert.ToString(testScriptLine) + " has an odd number of parameters!")
                        KillScriptTest()
                        Return 1
                    ElseIf paramCount = 0 Then
                        AddToScriptFeed("Validate Result command on line " + Convert.ToString(testScriptLine) + " has no parameters!")
                        KillScriptTest()
                        Return 1
                    Else
                        AddToScriptFeed("Validate Result command")
                        Return 0
                    End If

                Catch e As Exception
                    AddToScriptFeed("Validate Result command on line " + Convert.ToString(testScriptLine) + " has incorrect number of parameters")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 10) = "CommStatus") Then       'Send out a comm status message
                'Set the status type
                Try
                    If (Mid(stringReader, 12, 4) = "Good") Then     'Send Comm Good Message
                        AddToScriptFeed("Comm Status: Good Command")
                    ElseIf (Mid(stringReader, 12, 4) = "None") Then 'Send Comm Bad Message
                        AddToScriptFeed("Comm Status: None Command")
                    ElseIf (Mid(stringReader, 12, 4) = "Poor") Then 'Send Comm Poor Message
                        AddToScriptFeed("Comm Status: Poor Command")
                    Else
                        AddToScriptFeed("Comm Status command on line " + Convert.ToString(testScriptLine) + " has invalid parameters")
                        KillScriptTest()
                    End If
                    i = GetParam1int(17, stringReader)
                    Return 0
                Catch ex As Exception
                    AddToScriptFeed("Comm Status command on on line " + Convert.ToString(testScriptLine) + " has invalid parameters")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 15) = "QueryMaxPayload") Then  'Send a Max Payload Query
                AddToScriptFeed("Max Payload query")
                Return 0

            ElseIf (Mid(stringReader, 1, 13) = "ReqPowerLimit") Then  'Send a Power Limit Request
                Try
                    i = GetParam1int(15, stringReader)
                    AddToScriptFeed("Request Power Limit")
                    Return 0
                Catch ex As Exception
                    AddToScriptFeed("Request Power Limit command on on line " + Convert.ToString(testScriptLine) + " has invalid parameters")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 12) = "QueryOpStateResp") Then
                AddToScriptFeed("Sent Query Operating State response")
                Return 0


            ElseIf (Mid(stringReader, 1, 17) = "SendPendEventTime") Then
                Try
                    i = GetParam1int(19, stringReader)
                    AddToScriptFeed("Sent Pending Event Time")
                    Return 0
                Catch ex As Exception
                    AddToScriptFeed("Pending Event Time command on on line " + Convert.ToString(testScriptLine) + " has invalid parameters")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 17) = "SendPendEventType") Then
                Try
                    i = GetParam1int(19, stringReader)
                    AddToScriptFeed("Sent Pending Event Type")
                    Return 0
                Catch ex As Exception
                    AddToScriptFeed("Pending Event Type command on on line " + Convert.ToString(testScriptLine) + " has invalid parameters")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 6) = "Reboot") Then
                Try
                    i = GetParam1int(8, stringReader)
                    AddToScriptFeed("Reboot Request")
                    Return 0
                Catch ex As Exception
                    AddToScriptFeed("Reboot command on on line " + Convert.ToString(testScriptLine) + " has invalid parameters")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 14) = "GetEnergyPrice") Then
                AddToScriptFeed("Sent Get Energy Price Request")
                Return 0


            ElseIf (Mid(stringReader, 1, 14) = "SetEnergyPrice") Then
                AddToScriptFeed("Sent Set Energy Price Request")
                Return 0


            ElseIf (Mid(stringReader, 1, 13) = "SetTempOffset") Then
                Try
                    i = GetParam1int(15, stringReader)
                    AddToScriptFeed("Sent Set Temperature Offset Request")
                    Return 0
                Catch ex As Exception
                    AddToScriptFeed("Set Temperature Offset command on on line " + Convert.ToString(testScriptLine) + " has invalid parameters")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 13) = "GetTempOffset") Then
                AddToScriptFeed("Sent Get Temperature Offset Request")
                Return 0


            ElseIf (Mid(stringReader, 1, 15) = "SetTempSetpoint") Then
                Try
                    i = GetParam1int(17, stringReader)
                    i = GetParam1int(23, stringReader)
                    i = GetParam1int(29, stringReader)
                    AddToScriptFeed("Sent Set Temperature Setpoint Request")
                    Return 0
                Catch ex As Exception
                    AddToScriptFeed("Set Temperature Setpoint command on on line " + Convert.ToString(testScriptLine) + " has invalid parameters")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 15) = "GetTempSetpoint") Then
                AddToScriptFeed("Sent Get Temperature Setpoint Request")
                Return 0


            ElseIf (Mid(stringReader, 1, 11) = "GetPresTemp") Then
                AddToScriptFeed("Get Present Temperature Request")
                Return 0


            ElseIf (Mid(stringReader, 1, 12) = "CommodityGet") Then
                Try
                    i = GetParam1int(14, stringReader)
                    AddToScriptFeed("Get Commodity")
                    Return 0
                Catch ex As Exception
                    AddToScriptFeed("Get Commodity command on on line " + Convert.ToString(testScriptLine) + " has invalid parameters")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 13) = "ActivationGet") Then
                AddToScriptFeed("Sent Get Activation command")
                Return 0


            ElseIf (Mid(stringReader, 1, 13) = "ActivationSet") Then
                AddToScriptFeed("Sent Set Activation command")
                Return 0


            ElseIf (Mid(stringReader, 1, 16) = "UserPrefLevelGet") Then
                AddToScriptFeed("Sent Get User Preference Level command")
                Return 0


            ElseIf (Mid(stringReader, 1, 16) = "UserPrefLevelSet") Then
                AddToScriptFeed("Sent Set User Preference Level command")
                Return 0


            ElseIf (Mid(stringReader, 1, 20) = "SetInterResponseCode") Then
                Try
                    i = GetParam1int(22, stringReader)
                    AddToScriptFeed("Set default intermediate command response code")
                    Return 0
                Catch ex As Exception
                    AddToScriptFeed("Set Intermediate Response Code command on on line " + Convert.ToString(testScriptLine) + " has invalid parameters")
                    KillScriptTest()
                    Return 1
                End Try

            ElseIf (Mid(stringReader, 1, 9) = "RawPacket") Then ' Send Raw Packet to other device
                Try
                    scriptIndex = 11
                    paramCount = 0
                    Do While scriptIndex <= stringReader.Length
                        i = GetParam1int(scriptIndex, stringReader)
                        paramCount += 1
                    Loop
                    If paramCount < 4 Then
                        AddToScriptFeed("Raw packet on line " + Convert.ToString(testScriptLine) + " has to few bytes!")
                        KillScriptTest()
                        Return 1
                    ElseIf paramCount = 0 Then
                        AddToScriptFeed("Raw packet on line " + Convert.ToString(testScriptLine) + " has no parameters!")
                        KillScriptTest()
                        Return 1
                    Else
                        AddToScriptFeed("Sending Raw packet")
                        Return 0
                    End If

                Catch e As Exception
                    AddToScriptFeed("Raw packet on line " + Convert.ToString(testScriptLine) + " has incorrect number of parameters")
                    KillScriptTest()
                    Return 1
                End Try

            Else
                KillScriptTest()
                AddToScriptFeed("Undefined command in test script line " + Convert.ToString(testScriptLine))
                Return -1
            End If
            Return 0

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub ReadScriptFile: " & ex.Message)
            Return -1
        End Try

    End Function

    Private Sub KillScriptTest()
        scriptFileReader.Close()
        nextScriptTestTime = New DateTime(1970, 1, 1)
        pbKillScript.Enabled = False
        pbExecuteScript.Enabled = True
        testScriptbtn.Enabled = True

    End Sub


    Private Sub CustomMsgType1cb_CheckedChanged(sender As Object, e As EventArgs) Handles customMsgType1cb.CheckedChanged
        If customMsgType1cb.Checked = True Then
            customMsgType1ValBox.Enabled = True
        Else
            customMsgType1ValBox.Enabled = False
        End If
    End Sub

    Private Sub CustomMsgType2cb_CheckedChanged(sender As Object, e As EventArgs) Handles customMsgType2cb.CheckedChanged
        If customMsgType2cb.Checked = True Then
            customMsgType2ValBox.Enabled = True
        Else
            customMsgType2ValBox.Enabled = False
        End If
    End Sub

    Private Sub CustomLength1cb_CheckedChanged(sender As Object, e As EventArgs) Handles customLength1cb.CheckedChanged
        If customLength1cb.Checked = True Then
            customLength1ValBox.Enabled = True
        Else
            customLength1ValBox.Enabled = False
        End If
    End Sub

    Private Sub CustomLength2cb_CheckedChanged(sender As Object, e As EventArgs) Handles customLength2cb.CheckedChanged
        If customLength2cb.Checked = True Then
            customLength2ValBox.Enabled = True
        Else
            customLength2ValBox.Enabled = False
        End If
    End Sub

    Private Sub PbSetSetPoint_Click(sender As Object, e As EventArgs) Handles pbSetSetPoint.Click
        Dim xmitBuffer(16) As Byte

        'Clear response boxes
        tbSetpointResponseCode.Text = ""

        'Build Msg
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 7
        xmitBuffer(4) = 3
        xmitBuffer(5) = 3

        'Device Type
        xmitBuffer(6) = (nudSetpointDeviceType.Value >> 8) And &HFF
        xmitBuffer(7) = nudSetpointDeviceType.Value And &HFF

        'Get Units
        If tempUnitC.Checked = True Then
            xmitBuffer(8) = 1
        Else
            xmitBuffer(8) = 0
        End If

        'Get setpoint1
        xmitBuffer(9) = (nudSetPoint1.Value >> 8) And &HFF
        xmitBuffer(10) = nudSetPoint1.Value And &HFF

        If cbSetpoint2Support.Checked = True Then
            'Get setpoint2
            xmitBuffer(11) = (nudSetPoint2.Value >> 8) And &HFF
            xmitBuffer(12) = nudSetPoint2.Value And &HFF
            xmitBuffer(3) = 9

            'Send responce
            SendComData(xmitBuffer, 13, "Sent Set Setpoint Request", pendingLinkAck)
        Else
            'Send responce
            SendComData(xmitBuffer, 11, "Sent Set Setpoint Request", pendingLinkAck)
        End If

        expectingResponse = True
        pendingLinkAck = True
        'Clear Buffer
        receiveIndex = 0
    End Sub

    Private Sub PbRequestSetpoint_Click(sender As Object, e As EventArgs) Handles pbRequestSetpoint.Click
        Dim xmitBuffer(16) As Byte

        'Clear response boxes
        tbSetpointResponseCode.Text = ""
        sgdSetPoint1.Text = ""
        sgdSetPoint2.Text = ""
        sgdTempUnits.Text = ""
        tbSgdDeviceType.Text = ""

        'Build Msg
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 3
        xmitBuffer(5) = 3
        SendComData(xmitBuffer, 6, "Sent Get Setpoint Request", pendingLinkAck)
        expectingResponse = True
        pendingLinkAck = True
        'Clear Buffer
        receiveIndex = 0

    End Sub


    Private Sub PbBrowsePT_Click(sender As Object, e As EventArgs) Handles pbBrowsePT.Click
        Try
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                tbFilePathPT.Text = OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub pbBrowsePT_Click: " & ex.Message)
        End Try

    End Sub

    Private Sub PbSendPT_Click(sender As Object, e As EventArgs) Handles pbSendPT.Click
        Dim xmitBuffer(512) As Byte
        Dim idx, length, count As Integer

        idx = 0
        If cbAddWrapper.Checked = True Then
            xmitBuffer(0) = 9
            xmitBuffer(1) = cbProtocolPT.SelectedIndex
            idx = 4
        End If
        Dim BinaryFile As New FileStream(tbFilePathPT.Text, FileMode.Open, FileAccess.Read)
        Dim Reader As New BinaryReader(BinaryFile)
        length = Reader.BaseStream.Length
        BinaryFile.Seek(0, SeekOrigin.Begin)
        count = 0
        While count < length
            If xmitBuffer.Length = idx Then
                Array.Resize(xmitBuffer, idx + 2) 'Extend buffer's with minimum payload size 
            End If
            xmitBuffer(idx) = Reader.ReadByte()
            count += 1
            idx += 1
        End While
        BinaryFile.Close()
        If cbAddWrapper.Checked = True Then
            xmitBuffer(2) = length >> 8
            xmitBuffer(3) = length And &HFF
            SendComData(xmitBuffer, idx, "Sent Pass Through Message", pendingLinkAck)
            expectingResponse = False
            pendingLinkAck = True
        Else
            SendComData(xmitBuffer, idx, "Raw Message", pendingLinkAck)
            expectingResponse = False
            pendingLinkAck = True
        End If
        'Clear Buffer
        receiveIndex = 0
    End Sub

    Private Sub LbCommodityCode1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbCommodityCode1.SelectedIndexChanged

        tbCommodityRate.Text = commodityArray2(lbCommodityCode1.SelectedIndex).instRate
        tbCommodityAmount.Text = commodityArray2(lbCommodityCode1.SelectedIndex).cumAmount
        cbCommoditySupported1.Checked = commodityArray2(lbCommodityCode1.SelectedIndex).supported
        cbEstimated1.Checked = commodityArray2(lbCommodityCode1.SelectedIndex).estimated
        tbCommodityFreq.Text = commodityArray2(lbCommodityCode1.SelectedIndex).updateFreq

    End Sub


    Private Sub PbGetEnergyPrice_Click(sender As Object, e As EventArgs) Handles pbGetEnergyPrice.Click
        Dim xmitBuffer(10) As Byte

        'Build Msg
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 3
        xmitBuffer(5) = 0

        'Send Msg
        pendingLinkAck = True
        SendComData(xmitBuffer, 6, "Sent Get Energy Price Request", pendingLinkAck)
        expectingResponse = True

    End Sub

    Private Sub PbSetEnergyPrice_Click(sender As Object, e As EventArgs) Handles pbSetEnergyPrice.Click
        Dim xmitBuffer(32) As Byte
        Dim uTime As Integer
        Dim startDate As New DateTime(1970, 1, 1, 0, 0, 0)

        'Build Msg
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 17
        xmitBuffer(4) = 3
        xmitBuffer(5) = 0
        xmitBuffer(6) = (nudCurrentPrice.Value >> 24) And &HFF     'Current price
        xmitBuffer(7) = (nudCurrentPrice.Value >> 16) And &HFF
        xmitBuffer(8) = (nudCurrentPrice.Value >> 8) And &HFF
        xmitBuffer(9) = nudCurrentPrice.Value And &HFF
        xmitBuffer(10) = (nudCurrencyCode.Value >> 8) And &HFF     'Currency code
        xmitBuffer(11) = nudCurrencyCode.Value And &HFF
        xmitBuffer(12) = nudDigitsAfterDecimal.Value      'Digits after decimal

        'Build expiration time
        uTime = (dtpExpTime.Value - startDate).TotalSeconds
        If uTime < 946684800 Then
            uTime = 946684800
        End If
        uTime -= 946684800      'Conver Unix time to seconds since 1/1/2000
        xmitBuffer(16) = uTime And &HFF
        xmitBuffer(15) = (uTime >> 8) And &HFF
        xmitBuffer(14) = (uTime >> 16) And &HFF
        xmitBuffer(13) = (uTime >> 24) And &HFF
        xmitBuffer(17) = (nudNextPrice.Value >> 24) And &HFF   'Next price
        xmitBuffer(18) = (nudNextPrice.Value >> 16) And &HFF
        xmitBuffer(19) = (nudNextPrice.Value >> 8) And &HFF
        xmitBuffer(20) = nudNextPrice.Value And &HFF
        'Send Msg
        pendingLinkAck = True
        SendComData(xmitBuffer, 21, "Sent Set Energy Price Request", pendingLinkAck)
        expectingResponse = True

    End Sub

    Private Sub PfGetTier_Click(sender As Object, e As EventArgs) Handles pfGetTier.Click
        Dim xmitBuffer(10) As Byte

        'Build Msg
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = 3
        xmitBuffer(5) = 1

        'Send Msg
        pendingLinkAck = True
        SendComData(xmitBuffer, 6, "Sent Get Tier Request", pendingLinkAck)
        expectingResponse = True

    End Sub

    Private Sub PbSetTier_Click(sender As Object, e As EventArgs) Handles pbSetTier.Click
        Dim xmitBuffer(20) As Byte

        'Build Msg
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 8
        xmitBuffer(4) = 3
        xmitBuffer(5) = 1
        xmitBuffer(6) = 2       'Current tier - 2)
        xmitBuffer(7) = &H1B   'Expire time/date 1/1/2000
        xmitBuffer(8) = &HCE
        xmitBuffer(9) = &H96
        xmitBuffer(10) = &H5C
        xmitBuffer(11) = 3   'Next tier - 3

        'Send Msg
        pendingLinkAck = True
        SendComData(xmitBuffer, 12, "Sent Set Tier Request", pendingLinkAck)
        expectingResponse = True

    End Sub

    Private Sub ChkShortMsg_CheckedChanged(sender As Object, e As EventArgs) Handles chkShortMsg.CheckedChanged
        If chkShortMsg.Checked = True Then
            useShortMsg = True
        Else
            useShortMsg = False
        End If

    End Sub

    Private Sub CbNakMsg_CheckedChanged(sender As Object, e As EventArgs) Handles cbNakMsg.CheckedChanged
        forceNak = True
        If cbNakMsg.Checked = True Then
            forceNak = True
        Else
            forceNak = False
        End If

    End Sub

    Private Sub MsgSupportQuery_Enter(sender As Object, e As EventArgs)
        RefreshODMsgList()
    End Sub

    Private Sub ODRefresh_Click(sender As Object, e As EventArgs) Handles ODRefresh.Click
        RefreshODMsgList()
    End Sub

    Private Sub RefreshODMsgList()
        Dim msgTypeAsString As String
        Dim i As Integer

        ODMsgTypeSup.Items.Clear()
        For i = 0 To 5
            If supportedMsgTypeOD(i, 0) <> 0 Then
                msgTypeAsString = "0x" & Convert.ToInt32(supportedMsgTypeOD(i, 0)).ToString("X") & " 0x" & Convert.ToInt32(supportedMsgTypeOD(i, 1)).ToString("X")
                ODMsgTypeSup.Items.Insert(i, msgTypeAsString)
            End If
        Next
    End Sub

    Private Sub PbGetPresentTemp_Click(sender As Object, e As EventArgs) Handles pbGetPresentTemp.Click
        Dim xmitBuffer(8) As Byte
        'Get Present Temperature Read Request
        Try

            'Clear response boxes
            tbResponseCode2.Text = ""
            tbPresentTemp.Text = ""
            sgdTempUnits.Text = ""
            tbSgdDeviceType.Text = ""

            receiveIndex = 0
            xmitBuffer(0) = 8
            xmitBuffer(1) = 2
            xmitBuffer(2) = 0
            xmitBuffer(3) = 2
            xmitBuffer(4) = 3
            xmitBuffer(5) = 4
            pendingLinkAck = True
            pendingAck = 0
            SendComData(xmitBuffer, 6, "Sent Get Present Temperature Request", pendingLinkAck)
            expectingResponse = True

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub pbGetPresentTemp_Click: " & ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim deviceFileReader As System.IO.StreamReader
        Dim stringReader As String
        Dim i As Int32

        Try
            If fbdScriptFileSelect.ShowDialog() = DialogResult.OK Then
                tbRealDevice.Text = fbdScriptFileSelect.FileName
            End If

            Ex_sender = sender
            Ex_e = e
            'Check that the file exists
            If My.Computer.FileSystem.FileExists(tbRealDevice.Text) Then
                deviceFileReader = My.Computer.FileSystem.OpenTextFileReader(tbRealDevice.Text)

                For i = 0 To 1439
                    stringReader = deviceFileReader.ReadLine()
                    realDeviceData(i) = Convert.ToInt32(stringReader)
                Next
                deviceFileReader.Close()
            Else
                MsgBox("No valid data file!")
            End If

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub Button2_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub Timer1Min_Tick(sender As Object, e As EventArgs) Handles Timer1Min.Tick

    End Sub

    Private Sub BRealDeviceRun_Click(sender As Object, e As EventArgs) Handles bRealDeviceRun.Click
        If bRealDeviceRun.Text = "Run" Then
            cbResponseSim.Checked = True
            If tbRealDevice.Text = "" Then
                MsgBox("No data file selected!")
                Return
            End If
            If CheckSupported(8, 2) = False Then
                supportedMsgTypeList.Items.Add("0x8 0x2")
            End If
            If CheckSupported(8, 3) = False Then
                supportedMsgTypeList.Items.Add("0x8 0x3")
            End If
            If cbPoolPump.Checked = True Then
                nudStartDelay.Value = realDeviceData(0)
                nudPPRunMin.Value = realDeviceData(1)
                nudTotalCapacity.Value = nudRunNormPwr.Value * realDeviceData(1)
            End If
            If cbPVInv.Checked = True Then
                OpStateBox.SelectedIndex = 1        'PV inverter is always in run mode
            Else
                OpStateBox.SelectedIndex = 0        'All other devices types go to idle normal
            End If
            bRealDeviceRun.Text = "Stop"
            nudDataFileIndex.Value = 0
            nudRealDevMin.Value = 0
            If cbPVInv.Checked = True Then
                commodityArray(1).supported = True
                commodityArray(1).estimated = False
                nudTotalCapacity.Value = 0
                nudPresentCapacity.Value = 0
            Else
                commodityArray(0).supported = True
                commodityArray(0).estimated = True
                commodityArray(6).supported = True
                commodityArray(6).estimated = True
                commodityArray(7).supported = True
                commodityArray(7).estimated = True
                commodityArray(0).cumAmount = 0
                commodityArray(0).instRate = 0
                commodityArray(6).cumAmount = nudTotalCapacity.Value / 60
                commodityArray(7).cumAmount = nudPresentCapacity.Value / 60
            End If
            nudDataFileIndex.Value = 0
            Timer1Min.Enabled = True
        Else
            bRealDeviceRun.Text = "Run"
            Timer1Min.Enabled = False
            nudDataFileIndex.Value = 0
        End If
    End Sub

    Private Sub CbPoolPump_CheckedChanged(sender As Object, e As EventArgs) Handles cbPoolPump.CheckedChanged
        If cbPoolPump.Checked = True Then
            cbHVAC.Checked = False
            cbHotWater.Checked = False
            cbPVInv.Checked = False
        End If
    End Sub

    Private Sub CbHVAC_CheckedChanged(sender As Object, e As EventArgs) Handles cbHVAC.CheckedChanged
        If cbHVAC.Checked = True Then
            cbPoolPump.Checked = False
            cbHotWater.Checked = False
            cbPVInv.Checked = False
        End If
    End Sub

    Private Sub CbHotWater_CheckedChanged(sender As Object, e As EventArgs) Handles cbHotWater.CheckedChanged
        If cbHotWater.Checked = True Then
            cbPoolPump.Checked = False
            cbHVAC.Checked = False
            cbPVInv.Checked = False
        End If
    End Sub

    Private Sub CbPVInv_CheckedChanged(sender As Object, e As EventArgs) Handles cbPVInv.CheckedChanged
        If cbPVInv.Checked = True Then
            cbPoolPump.Checked = False
            cbHVAC.Checked = False
            cbHotWater.Checked = False
        End If
    End Sub

    Private Sub LogCommentBtn_Click(sender As Object, e As EventArgs) Handles LogCommentBtn.Click
        'adds comments to the log with timestamp while remaining in simulation
        Try
            'log comment textbox then clear it
            Dim Now As DateTime = DateTime.Now
            Dim timeStr As String = DateDiff("s", #1/1/2000#, Now) & Now.ToString(".fff")
            Dim tempstring = (((Convert.ToDecimal(timeStr)) / 86400) + 36526).ToString
            Dim commentStr As String = timeStr & ", " & tempstring & ", Comment,,, " & LogCommentsTB.Text

            SendToLog("", commentStr)

            LogCommentsTB.Text = ""

        Catch ex As Exception
            MessageBox.Show("Error occurred in Sub LogCommentBtn_Click: " & ex.Message)
        End Try

    End Sub

    Private Sub LogDevInfoBtn_Click(sender As Object, e As EventArgs) Handles LogDevInfoBtn.Click
        'logs the device info
        Try
            SendToLog("", "Device Info, ")
            SendToLog("", "Device Info, CTA-2045 Version, " & otherDeviceCTA2045Version.Text)
            SendToLog("", "Device Info, Vendor ID, " & otherDeviceVendorID.Text)
            SendToLog("", "Device Info, Device Type, " & otherDeviceDeviceType.Text)
            SendToLog("", "Device Info, Device Revision, " & otherDeviceDeviceRevision.Text)
            SendToLog("", "Device Info, Capability Bitmap, " & otherDeviceCapabilityBitmap.Text)
            SendToLog("", "Device Info, Model Number, " & otherDeviceModelNumber.Text)
            SendToLog("", "Device Info, Serial Number, " & otherDeviceSerialNumber.Text)
            SendToLog("", "Device Info, Firmware Date, " & otherDeviceFirmwareDate.Text)
            SendToLog("", "Device Info, Firmware Major, " & otherDeviceFirmwareMajor.Text)
            SendToLog("", "Device Info, Firmware Minor, " & otherDeviceFirmwareMinor.Text)

        Catch ex As Exception
            MessageBox.Show("Error occurred in Sub LogDevInfoBtn_Click: " & ex.Message)
        End Try

    End Sub

    Private Sub LogCommodity()
        'logs all 8 commodity codes with corresponding values
        Dim commStr(10) As String
        Dim commodityCodes() As String = {"Electricity Consumed (W)", "Electricity Produced (W)", "Natrual Gas (cubic ft/hr)", "Water (gal/hr)", "Natural Gas (cubic m/hr)", "Water (liters/hr}", "Total Energy Storage Capacity (W-hr)", "Present Energy Storage Capacity (W-hr)", "Rated Max Consumption Level Electricity (W)", "Rated Max Production Level Electricity (W)"}
        Dim codeChk(10) As Boolean
        Dim timeStr As String = DateDiff("s", #1/1/2000#, Now) & Now.ToString(".fff")
        Dim tempstring = (((Convert.ToDecimal(timeStr)) / 86400) + 36526).ToString
        Dim timeInfo As String = timeStr & ", " & tempstring

        codeChk(0) = CommodityChk0.Checked
        codeChk(1) = CommodityChk1.Checked
        codeChk(2) = CommodityChk2.Checked
        codeChk(3) = CommodityChk3.Checked
        codeChk(4) = CommodityChk4.Checked
        codeChk(5) = CommodityChk5.Checked
        codeChk(6) = CommodityChk6.Checked
        codeChk(7) = CommodityChk7.Checked
        codeChk(8) = CommodityChk8.Checked
        codeChk(9) = CommodityChk9.Checked

        ' TODO : Add a check to confirm that all variable have same length

        For I = 0 To 9
            commStr(I) = timeInfo & ", Commodity Code: ," & I & ", " & commodityCodes(I) & ", Instantaneous Rate, " & commodityArray2(I).instRate & ", Cummulative Amount, "
            commStr(I) &= commodityArray2(I).cumAmount & ", Update Frequency (s), " & commodityArray2(I).updateFreq & ", Estimated, "
            commStr(I) &= commodityArray2(I).estimated & ", Supported, " & commodityArray2(I).supported
        Next I

        For J = 0 To 9
            If codeChk(J) = True Then
                SendToLog("", commStr(J))
            End If
        Next J
    End Sub

    Private Sub CommodityIntervalChkBox_CheckedChanged(sender As Object, e As EventArgs) Handles CommodityIntervalChkBox.CheckedChanged
        'activate/deactivate commodity interval update
        autoCommodityReadTimer.Interval = CommodityIntervalVal.Value * 1000
        ' assgin the change in checkbox to the timer
        autoCommodityReadTimer.Enabled = CommodityIntervalChkBox.Checked
    End Sub

    Private Sub AutoCommodityReadTimer_Tick(sender As Object, e As EventArgs) Handles autoCommodityReadTimer.Tick
        Dim xmitBuffer(8) As Byte
        'Get Commodity Read Request at each tick
        Try
            receiveIndex = 0
            xmitBuffer(0) = 8
            xmitBuffer(1) = 2
            xmitBuffer(2) = 0
            xmitBuffer(3) = 2
            xmitBuffer(4) = &H6
            xmitBuffer(5) = 0
            pendingLinkAck = True
            pendingAck = 0
            SendComData(xmitBuffer, 6, "Sent Get Commodity Read Request", pendingLinkAck)
            expectingResponse = True

        Catch ex As Exception
            MessageBox.Show("Error occured in Sub pbGetCommodity_Click: " & ex.Message)
        End Try

    End Sub

    Private Sub CommodityIntervalVal_ValueChanged(sender As Object, e As EventArgs) Handles CommodityIntervalVal.ValueChanged
        'changes interval for commodity updates
        autoCommodityReadTimer.Interval = CommodityIntervalVal.Value * 1000
    End Sub

    Private Sub OpStateQueryCheck_CheckedChanged(sender As Object, e As EventArgs) Handles OpStateQueryCheck.CheckedChanged
        'activates/deactivates timed query for op state
        autoOpStateTimer.Interval = OpStateIntervalVal.Value * 1000

        If OpStateQueryCheck.Checked = True Then
            autoOpStateTimer.Enabled = True
        Else
            autoOpStateTimer.Enabled = False
        End If

    End Sub

    Private Sub OpStateIntervalVal_ValueChanged(sender As Object, e As EventArgs) Handles OpStateIntervalVal.ValueChanged
        'changes interval for op state updates
        autoOpStateTimer.Interval = OpStateIntervalVal.Value * 1000
    End Sub

    Private Sub AutoOpStateTimer_Tick(sender As Object, e As EventArgs) Handles autoOpStateTimer.Tick
        'op state query at each tick
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = &H12
        xmitBuffer(5) = 0
        pendingLinkAck = True
        pendingAck = &H12  'Set the pendingAck
        SendComData(xmitBuffer, 6, "Sent Op State Query", pendingLinkAck)
        expectingResponse = True

        If GetLinkAck() = 0 Then
            'Wait for State Query Response
            rtnval = GetStateQueryResp()
        End If
        Reset_state()
        tmrProcessComm.Enabled = True

    End Sub

    Private Sub GrphCommodityBtn_Click(sender As Object, e As EventArgs) Handles GrphCommodityBtn.Click
        'opens commodity graph window
        CommodityChart.Show()
    End Sub

    Public Sub GraphCommodityUpdate()
        'updates commodity graph data
        For I = 0 To 7
            CommodityChart.InstAmChrt.Series(I).Points.AddXY(DateAndTime.Now, commodityArray2(I).instRate)
            CommodityChart.CumAmChrt.Series(I).Points.AddXY(DateAndTime.Now, commodityArray2(I).cumAmount)
        Next
    End Sub

    Private Sub ChkAllCommodity_Click(sender As Object, e As EventArgs) Handles ChkAllCommodity.Click
        'boolean variable for check all commodity btn
        Static Dim allChk As Boolean = False
        'activates all check boxes for loging commodities

        If allChk = False Then
            CommodityChk0.Checked = True
            CommodityChk1.Checked = True
            CommodityChk2.Checked = True
            CommodityChk3.Checked = True
            CommodityChk4.Checked = True
            CommodityChk5.Checked = True
            CommodityChk6.Checked = True
            CommodityChk7.Checked = True
            CommodityChk8.Checked = True
            CommodityChk9.Checked = True
        Else
            CommodityChk0.Checked = False
            CommodityChk1.Checked = False
            CommodityChk2.Checked = False
            CommodityChk3.Checked = False
            CommodityChk4.Checked = False
            CommodityChk5.Checked = False
            CommodityChk6.Checked = False
            CommodityChk7.Checked = False
            CommodityChk8.Checked = False
            CommodityChk9.Checked = False
        End If
        allChk = Not allChk

    End Sub

    Private Sub AddHeaderBtn_Click(sender As Object, e As EventArgs) Handles AddHeaderBtn.Click
        'opens test header window
        TestHeader.Show()
    End Sub

    Private Sub SendOpStateBtn_Click(sender As Object, e As EventArgs) Handles SendOpStateBtn.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        pendingAck = &H13  'Set the pendingAck
        pendingLinkAck = True  'Set the pendingLinkAck to true
        xmitBuffer(4) = &H13
        xmitBuffer(5) = OpStateBox.SelectedIndex
        SendComData(xmitBuffer, 6, "Sent Operational State Query response", pendingLinkAck)
        expectingResponse = True

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(&H13)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True
    End Sub

    Private Sub SendPendEventTypePb_Click(sender As Object, e As EventArgs) Handles sendPendEventTypePb.Click
        Dim xmitBuffer(8) As Byte
        Dim temp As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = &H19
        If pendEventTypeCb.SelectedIndex = 0 Then   'Shed
            temp = &H1
        ElseIf pendEventTypeCb.SelectedIndex = 1 Then   'End Shed
            temp = &H2
        ElseIf pendEventTypeCb.SelectedIndex = 2 Then   'Critical peak
            temp = &HA
        ElseIf pendEventTypeCb.SelectedIndex = 3 Then   'Grid emergency
            temp = &HB
        ElseIf pendEventTypeCb.SelectedIndex = 4 Then   'Load up
            temp = &H17
        End If
        xmitBuffer(5) = temp
        SendComData(xmitBuffer, 6, "Sent Pending event type: " & temp, pendingLinkAck)
        expectingResponse = True

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(&H19)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True

    End Sub

    Private Sub SendPendEventTimePb_Click(sender As Object, e As EventArgs) Handles sendPendEventTimePb.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = &H18
        xmitBuffer(5) = trkPendEventDuration.Value
        SendComData(xmitBuffer, 6, "Sent Pending Event Time Command", pendingLinkAck)
        expectingResponse = True

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(&H18)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True

    End Sub

    Private Sub TrkPendEventDuration_Scroll(sender As Object, e As EventArgs) Handles trkPendEventDuration.Scroll
        Dim duration As Long
        Dim durHours As Byte
        Dim durMin As Byte
        Dim durSec As Byte

        If trkPendEventDuration.Value = 0 Then
            txtPendDuration.Text = "Unknown"
        ElseIf trkPendEventDuration.Value = &HFF Then
            txtPendDuration.Text = ("> Maximum")
        Else
            duration = (trkPendEventDuration.Value * trkPendEventDuration.Value) * 2
            durHours = duration \ 3600
            durMin = (duration Mod 3600) \ 60
            durSec = duration Mod 60
            txtPendDuration.Text = durHours.ToString("00") & ":" & durMin.ToString("00") & ":" & durSec.ToString("00")
        End If

    End Sub

    Private Sub BReboot_Click(sender As Object, e As EventArgs) Handles bReboot.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        tmrProcessComm.Enabled = False
        receiveIndex = 0
        xmitBuffer(0) = 8
        xmitBuffer(1) = 1
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = &H1A
        xmitBuffer(5) = cbRebootType.SelectedIndex
        SendComData(xmitBuffer, 6, "Sent Reboot Command", pendingLinkAck)
        'xmitBuffer(4) = &H11
        'xmitBuffer(5) = 0
        'SendComData(xmitBuffer, 6, "Sent Customer Override Not in Effect", pendingLinkAck)
        expectingResponse = True

        rtnval = GetLinkAck()
        If rtnval = 0 Then
            'Wait for Application Ack
            rtnval = GetApplicationAck(&H1A)
            'rtnval = getApplicationAck(&H11)
        End If
        Reset_state()
        tmrProcessComm.Enabled = True

    End Sub

    Private Sub PbSetPrefLevel_Click(sender As Object, e As EventArgs) Handles pbSetPrefLevel.Click
        Dim xmitBuffer(16) As Byte

        'Build Msg
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 4
        xmitBuffer(4) = &HB
        xmitBuffer(5) = 1
        xmitBuffer(6) = nudPrefType.Value     'Preference type
        xmitBuffer(7) = nudPrefLevel.Value     'Preference level
        'Send Msg
        pendingLinkAck = True
        SendComData(xmitBuffer, 8, "Sent Set User Preference Level Request", pendingLinkAck)
        expectingResponse = True

    End Sub

    Private Sub PbGetPrefLevel_Click(sender As Object, e As EventArgs) Handles pbGetPrefLevel.Click
        Dim xmitBuffer(16) As Byte

        'Build Msg
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 3
        xmitBuffer(4) = &HB
        xmitBuffer(5) = 0
        xmitBuffer(6) = nudPrefType.Value     'Preference type
        'Send Msg
        pendingLinkAck = True
        SendComData(xmitBuffer, 7, "Sent Get User Preference Level Request", pendingLinkAck)
        expectingResponse = True

    End Sub

    Private Sub NudPrefLevel_ValueChanged(sender As Object, e As EventArgs) Handles nudPrefLevel.ValueChanged
        preference(nudPrefType.Value) = nudPrefLevel.Value
    End Sub

    Private Sub NudPrefType_ValueChanged(sender As Object, e As EventArgs) Handles nudPrefType.ValueChanged
        nudPrefLevel.Value = preference(nudPrefType.Value)
    End Sub

    Private Sub NudActIndex_ValueChanged(sender As Object, e As EventArgs) Handles nudActIndex.ValueChanged
        nudActStatus.Value = actStatus(nudActIndex.Value)
    End Sub

    Private Sub NudActStatus_ValueChanged(sender As Object, e As EventArgs) Handles nudActStatus.ValueChanged
        actStatus(nudActIndex.Value) = nudActStatus.Value
    End Sub

    Private Sub PbSetActStatus_Click(sender As Object, e As EventArgs) Handles pbSetActStatus.Click
        Dim tempByte As Byte
        Dim i As Integer
        Dim idx As Integer = 8 'Setting Text index
        Dim xmitBuffer(idx) As Byte

        'Build Msg
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 4
        xmitBuffer(4) = &HA
        xmitBuffer(5) = 1
        xmitBuffer(6) = nudActIndex.Value     'Activation Index
        xmitBuffer(7) = nudActStatus.Value     'Activation Status

        Array.Resize(xmitBuffer, tbActivateKey.TextLength + idx)
        If tbActivateKey.Text <> "" Then
            For i = 1 To (tbActivateKey.TextLength)
                tempByte = Asc(Mid(tbActivateKey.Text, i, 1))
                xmitBuffer(idx) = tempByte
                xmitBuffer(3) += 1
                idx += 1
            Next
        End If
        'Send Msg
        pendingLinkAck = True
        SendComData(xmitBuffer, xmitBuffer(3) + 4, "Sent Set Activation Status Request", pendingLinkAck)
        expectingResponse = True

    End Sub

    Private Sub PbGetActStatus_Click(sender As Object, e As EventArgs) Handles pbGetActStatus.Click
        Dim xmitBuffer(16) As Byte

        'Build Msg
        xmitBuffer(0) = 8
        xmitBuffer(1) = 2
        xmitBuffer(2) = 0
        xmitBuffer(3) = 3
        xmitBuffer(4) = &HA
        xmitBuffer(5) = 0
        xmitBuffer(6) = nudActIndex.Value     'Activation Index
        'Send Msg
        pendingLinkAck = True
        SendComData(xmitBuffer, 7, "Sent Get Activation Status Request", pendingLinkAck)
        expectingResponse = True

    End Sub

    Private Sub ChkCustOverride_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkCustOverride.CheckedChanged
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer

        If ignoreOverrideChange = False Then
            tmrProcessComm.Enabled = False
            CustomerOverride = chkCustOverride.Checked
            receiveIndex = 0
            xmitBuffer(0) = 8
            xmitBuffer(1) = 1
            xmitBuffer(2) = 0
            xmitBuffer(3) = 2
            xmitBuffer(4) = &H11
            If chkCustOverride.Checked = True Then
                xmitBuffer(5) = 1
                SendComData(xmitBuffer, 6, "Sent Customer Override in Effect", pendingLinkAck)
                overRideSet = True
            Else
                xmitBuffer(5) = 0
                SendComData(xmitBuffer, 6, "Sent Customer Override Not in Effect", pendingLinkAck)
                overRideSet = False
            End If
            expectingResponse = True

            rtnval = GetLinkAck()
            If rtnval = 0 Then
                'Wait for Application Ack
                rtnval = GetApplicationAck(&H11)
            End If
            Reset_state()
            tmrProcessComm.Enabled = True
        Else
            ignoreOverrideChange = False
        End If

    End Sub

    Private Sub PbPowerLimit_Click(sender As Object, e As EventArgs) Handles pbPowerLimit.Click
        Dim xmitBuffer(8) As Byte
        Dim rtnval As Integer
        Dim dispString As String

        dispString = ""
        xmitBuffer(0) = 8
        xmitBuffer(1) = 3
        xmitBuffer(2) = 0
        xmitBuffer(3) = 2
        xmitBuffer(4) = &H16
        xmitBuffer(5) = nudPowerLimit.Value
        pendingAck = 0  'Set the pendingAck to nothing
        pendingLinkAck = True  'Set the pendingLinkAck to true
        SendComData(xmitBuffer, 6, "Sent Power Limit request", pendingLinkAck)
        rtnval = GetLinkAck()
        If rtnval = 0 Then
            SendToLog(dispString, "Power Limit request approved")
            ReceivedText(dispString, "Power Limit request approved")
        Else
            SendToLog(dispString, "Power Limit request denied")
            ReceivedText(dispString, "Power Limit request denied")
        End If
        Reset_state()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <param name="delay"></param>
    Public Sub AdditonalInfo(sender As Object, e As EventArgs, Optional ByVal delay As Integer = 500)
        ' Perform click to request the maximum payload size of other device and adjust payload size
        TabSwitcher(deviceInfoTabControl, getDeviceInfo)
        BtnMaxPayload_Click(sender, e)
        WaistProcessorTime()
        MaxPayloadSize = MaxPayloadSizeCd

        '' Getting Connected Device Info
        devInfoTimer = New Windows.Forms.Timer With {
            .Interval = delay
        }
        AddHandler devInfoTimer.Tick, AddressOf QueryDeviceInfoButton_Click
        devInfoTimer.Start()

        '' Logging Connected Device Info
        AddHandler devInfoTimer.Tick, AddressOf LogDevInfoBtn_Click
        devInfoTimer.Start()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub StopEvent(sender As Object, e As EventArgs) Handles devInfoTimer.Tick
        devInfoTimer.Stop()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="parentTab"></param>
    ''' <param name="targetTab"></param>
    ''' <param name="sleep"></param>
    Private Sub TabSwitcher(parentTab As TabControl, targetTab As TabPage, Optional ByVal sleep As Integer = 500)
        simulatorDeviceTypeTabControl.SelectTab(parentTab.Parent)
        parentTab.SelectTab(targetTab)
        WaistProcessorTime(sleep) ' Wait for half a Second
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GenReportBtn_Click(sender As Object, e As EventArgs) Handles GenReportBtn.Click
        ' TODO : might give issues in case the log file is disabled
        TestReport.Show()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="timeout"></param>
    ''' <returns></returns>
    Public Function WaistProcessorTime(Optional ByVal timeout As ULong = 150) As Boolean
        Dim cycles As ULong = 0
        Dim max_time = timeout * GetCPUSpeed() / 1000 ' it takes # cycle per second
        Do
            cycles += 1
        Loop Until cycles >= max_time
        WaistProcessorTime = cycles <> 0
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns>The Current Speed of the Processor</returns>
    Private Function GetCPUSpeed() As ULong
        Dim CPUSpeed As ULong
        Try
            Dim hkey = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "~MHz", Nothing)
            CPUSpeed = Math.Pow(2, 10) * Convert.ToInt64(hkey, 16)
        Catch
            CPUSpeed = Math.Pow(10, 6) ' Minimum CPU Requirments for Win 7 & UP
        End Try
        GetCPUSpeed = CPUSpeed
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CloseBTN_Click(sender As Object, e As EventArgs) Handles CloseBTN.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CbAutoStartup_CheckedChanged(sender As Object, e As EventArgs) Handles cbAutoStartup.CheckedChanged
        Dim msgList As String() = {"08 01", "08 02", "08 03", "08 04", "09 01", "09 02", "09 03", "09 04", "09 05", "09 06", "09 07", "09 08", "09 09", "09 0A", "09 0B", "09 0C"}
        Dim rdsState = cbResponseSim.Checked ' Preserving RDS CB state

        If cbAutoStartup.Checked And btnDisconnect.Enabled Then
            '' Enable RDS CB
            If rdsState = False Then cbResponseSim.Checked = Not rdsState

            If rbMode1.Checked = True Then
                ' Perform click to send good communication status 
                SendCommStatus(1) '"Found / Good Connection"

                ' Perform click to request operational state of connected device
                PbOpState_Click(sender, e)
            ElseIf rbMode2.Checked Then
                ' Perform click to send current device's operational state
                SendOpStateBtn_Click(sender, e)
            End If

            ' Perform Click to verify all message type supported and add to list
            supportedMsgTypeList.Items.Clear()
            For Each msg In msgList
                nudSupMsgQueryMSB.Value = Convert.ToInt32(msg.Substring(0, 2), 16).ToString()
                nudSupMsgQueryLSB.Value = Convert.ToInt32(msg.Substring(4), 16).ToString()
                WaistProcessorTime()

                MsgTypeQuery_Click(sender, e)
                supportedMsgTypeList.Items.Add("0x" & Convert.ToInt32(nudSupMsgQueryMSB.Value).ToString("X") & " 0x" & Convert.ToInt32(nudSupMsgQueryLSB.Value).ToString("X"))
                WaistProcessorTime()
            Next

            ''Getting Other Device Information
            If ODMsgTypeSup.Items.Contains("0x8 0x2") Then
                QueryDeviceInfoButton_Click(sender, e)
                WaistProcessorTime()
            End If

            ''Getting Maximum Payload Size of Connected Device
            If ODMsgTypeSup.Items.Contains("0x8 0x3") Then
                BtnMaxPayload_Click(sender, e)
                WaistProcessorTime()
                MaxPayloadSize = MaxPayloadSizeCd
            End If

            cbResponseSim.Checked = rdsState ' Restoring RDS CB state
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AboutCTA2045SimulatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutCTA2045SimulatorToolStripMenuItem.Click
        AboutBox.ShowDialog()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ViewHelpContentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewHelpContentToolStripMenuItem.Click
        Dim GetFile = Function() As String
                          Dim parentLevel As Short = 1
                          Dim targetDir = Directory.GetCurrentDirectory()
                          Dim rootDir = Directory.GetDirectoryRoot(targetDir)
                          While parentLevel < 5
                              Dim chmFile = Directory.GetFiles(targetDir, "CTA-2045_Simulator_User_Guide.chm", SearchOption.AllDirectories)
                              If chmFile.Length > 0 Then Return chmFile.Last
                              If targetDir.Equals(rootDir) Then Exit While
                              targetDir = Directory.GetParent(targetDir).FullName
                              parentLevel += 1
                          End While
                          Return String.Empty
                      End Function

        Try
            Help.ShowHelp(Me, GetFile())
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Help Content", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class