﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbPort = New System.Windows.Forms.ComboBox()
        Me.CmbBaud = New System.Windows.Forms.ComboBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnClearDebug = New System.Windows.Forms.Button()
        Me.rtbReceived = New System.Windows.Forms.RichTextBox()
        Me.grpChangeBaud = New System.Windows.Forms.GroupBox()
        Me.cmbChangeBaud = New System.Windows.Forms.ComboBox()
        Me.btnAcceptChangeBaud = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.rbMode1 = New System.Windows.Forms.RadioButton()
        Me.rbMode2 = New System.Windows.Forms.RadioButton()
        Me.gbErrors = New System.Windows.Forms.GroupBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.nudAppNakRtn = New System.Windows.Forms.NumericUpDown()
        Me.cbAppNakMsg = New System.Windows.Forms.CheckBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.nudNakRtn = New System.Windows.Forms.NumericUpDown()
        Me.cbNakMsg = New System.Windows.Forms.CheckBox()
        Me.chkShortMsg = New System.Windows.Forms.CheckBox()
        Me.chkLongMsg = New System.Windows.Forms.CheckBox()
        Me.chkBadCheckSum = New System.Windows.Forms.CheckBox()
        Me.grpSGDConfig = New System.Windows.Forms.GroupBox()
        Me.chkCustOverride = New System.Windows.Forms.CheckBox()
        Me.grpOpState = New System.Windows.Forms.GroupBox()
        Me.OpStateBox = New System.Windows.Forms.ComboBox()
        Me.tmrTimeSync = New System.Windows.Forms.Timer(Me.components)
        Me.tmrBaudDefault = New System.Windows.Forms.Timer(Me.components)
        Me.tbLogFile = New System.Windows.Forms.TextBox()
        Me.Browse = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.disableLogFile = New System.Windows.Forms.CheckBox()
        Me.logFile = New System.Windows.Forms.GroupBox()
        Me.cbVerboseLog = New System.Windows.Forms.CheckBox()
        Me.logFilePathLabel = New System.Windows.Forms.Label()
        Me.sgdTabControl = New System.Windows.Forms.TabControl()
        Me.sgdOpStateTab = New System.Windows.Forms.TabPage()
        Me.GetUtc = New System.Windows.Forms.TabPage()
        Me.btnGetUTC = New System.Windows.Forms.Button()
        Me.simulatorDeviceTypeTabControl = New System.Windows.Forms.TabControl()
        Me.deviceInfoTab = New System.Windows.Forms.TabPage()
        Me.deviceInfoTabControl = New System.Windows.Forms.TabControl()
        Me.generalInfoTab = New System.Windows.Forms.TabPage()
        Me.tbCEA2045Version = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.nudCapBitMap3 = New System.Windows.Forms.NumericUpDown()
        Me.nudCapBitMap2 = New System.Windows.Forms.NumericUpDown()
        Me.nudCapBitMap1 = New System.Windows.Forms.NumericUpDown()
        Me.nudCapBitMap0 = New System.Windows.Forms.NumericUpDown()
        Me.nudDevRevLSB = New System.Windows.Forms.NumericUpDown()
        Me.nudDevRevMSB = New System.Windows.Forms.NumericUpDown()
        Me.nudVendorIDLSB = New System.Windows.Forms.NumericUpDown()
        Me.nudVendorIDMSB = New System.Windows.Forms.NumericUpDown()
        Me.nudFirmwareMinor = New System.Windows.Forms.NumericUpDown()
        Me.nudFirmwareMajor = New System.Windows.Forms.NumericUpDown()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.firmwareMajorMinorSupportedCheckbox = New System.Windows.Forms.CheckBox()
        Me.serialNumberSupportedCheckbox = New System.Windows.Forms.CheckBox()
        Me.modelNumberSupportedCheckbox = New System.Windows.Forms.CheckBox()
        Me.deviceTypeLSBTextBox = New System.Windows.Forms.TextBox()
        Me.firmwareDayComboBox = New System.Windows.Forms.ComboBox()
        Me.firmwareMonthComboBox = New System.Windows.Forms.ComboBox()
        Me.firmwareYearComboBox = New System.Windows.Forms.ComboBox()
        Me.serialNumberTextBox = New System.Windows.Forms.TextBox()
        Me.modelNumberTextBox = New System.Windows.Forms.TextBox()
        Me.deviceTypeMSBTextBox = New System.Windows.Forms.TextBox()
        Me.deviceTypeLabel = New System.Windows.Forms.Label()
        Me.capabilityBitmapLabel = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.deviceTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.firmwareMinorLabel = New System.Windows.Forms.Label()
        Me.vendorIDLabel = New System.Windows.Forms.Label()
        Me.firmwareMajorLabel = New System.Windows.Forms.Label()
        Me.firmwareMonthLabel = New System.Windows.Forms.Label()
        Me.cea2045VersionLabel = New System.Windows.Forms.Label()
        Me.firmwareDayLabel = New System.Windows.Forms.Label()
        Me.deviceRevisionLabel = New System.Windows.Forms.Label()
        Me.firmwareYearLabel = New System.Windows.Forms.Label()
        Me.serialNumberLabel = New System.Windows.Forms.Label()
        Me.modelNumberLabel = New System.Windows.Forms.Label()
        Me.getDeviceInfo = New System.Windows.Forms.TabPage()
        Me.otherDeviceFirmwareMinor = New System.Windows.Forms.TextBox()
        Me.otherDeviceFirmwareMajor = New System.Windows.Forms.TextBox()
        Me.otherDeviceFirmwareDate = New System.Windows.Forms.TextBox()
        Me.otherDeviceModelNumber = New System.Windows.Forms.TextBox()
        Me.otherDeviceCEA2045Version = New System.Windows.Forms.TextBox()
        Me.otherDeviceVendorID = New System.Windows.Forms.TextBox()
        Me.otherDeviceDeviceType = New System.Windows.Forms.TextBox()
        Me.otherDeviceSerialNumber = New System.Windows.Forms.TextBox()
        Me.otherDeviceDeviceRevision = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.otherDeviceCapabilityBitmap = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.queryDeviceInfoButton = New System.Windows.Forms.Button()
        Me.msgTypeSupportedTab = New System.Windows.Forms.TabPage()
        Me.msgSupportQuery = New System.Windows.Forms.GroupBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.ODRefresh = New System.Windows.Forms.Button()
        Me.ODMsgTypeSup = New System.Windows.Forms.ListBox()
        Me.nudSupMsgQueryLSB = New System.Windows.Forms.NumericUpDown()
        Me.nudSupMsgQueryMSB = New System.Windows.Forms.NumericUpDown()
        Me.typeSupportedQueryCodeLookup = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.msgTypeQuery = New System.Windows.Forms.Button()
        Me.msgSupportedBox = New System.Windows.Forms.GroupBox()
        Me.nudMsgSuppLSB = New System.Windows.Forms.NumericUpDown()
        Me.nudMsgSuppMSB = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.supportedMsgTypeList = New System.Windows.Forms.ListBox()
        Me.removeSupportedType = New System.Windows.Forms.Button()
        Me.addSupportedType = New System.Windows.Forms.Button()
        Me.setMaxPayloadTab = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.btnMaxPayload = New System.Windows.Forms.Button()
        Me.cdMaxPayloadSize = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbMaxPayload1 = New System.Windows.Forms.RadioButton()
        Me.rbMaxPayload14 = New System.Windows.Forms.RadioButton()
        Me.rbMaxPayload2 = New System.Windows.Forms.RadioButton()
        Me.rbMaxPayload13 = New System.Windows.Forms.RadioButton()
        Me.rbMaxPayload3 = New System.Windows.Forms.RadioButton()
        Me.rbMaxPayload12 = New System.Windows.Forms.RadioButton()
        Me.rbMaxPayload4 = New System.Windows.Forms.RadioButton()
        Me.rbMaxPayload11 = New System.Windows.Forms.RadioButton()
        Me.rbMaxPayload5 = New System.Windows.Forms.RadioButton()
        Me.rbMaxPayload10 = New System.Windows.Forms.RadioButton()
        Me.rbMaxPayload6 = New System.Windows.Forms.RadioButton()
        Me.rbMaxPayload9 = New System.Windows.Forms.RadioButton()
        Me.rbMaxPayload7 = New System.Windows.Forms.RadioButton()
        Me.rbMaxPayload8 = New System.Windows.Forms.RadioButton()
        Me.tempF = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.pbGetPresentTemp = New System.Windows.Forms.Button()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.nudPresentTemp = New System.Windows.Forms.NumericUpDown()
        Me.tbResponseCode2 = New System.Windows.Forms.TextBox()
        Me.tbPresentTemp = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.tmpUnitF = New System.Windows.Forms.RadioButton()
        Me.tempUnitC = New System.Windows.Forms.RadioButton()
        Me.tbSgdDeviceType = New System.Windows.Forms.TextBox()
        Me.sgdTempUnits = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.nudSetpointDeviceType = New System.Windows.Forms.NumericUpDown()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.pbSetTempOffset = New System.Windows.Forms.Button()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.nudTempOffset = New System.Windows.Forms.NumericUpDown()
        Me.sgdTempRespCode = New System.Windows.Forms.TextBox()
        Me.pbRequestTempOffset = New System.Windows.Forms.Button()
        Me.sgdCurrentTempOffset = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.pbSetSetPoint = New System.Windows.Forms.Button()
        Me.tbSetpointResponseCode = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.pbRequestSetpoint = New System.Windows.Forms.Button()
        Me.nudSetPoint1 = New System.Windows.Forms.NumericUpDown()
        Me.cbSetpoint2Support = New System.Windows.Forms.CheckBox()
        Me.nudSetPoint2 = New System.Windows.Forms.NumericUpDown()
        Me.sgdSetPoint1 = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.sgdSetPoint2 = New System.Windows.Forms.TextBox()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.commodity = New System.Windows.Forms.TabPage()
        Me.cdCommodityGb = New System.Windows.Forms.GroupBox()
        Me.pbGetCommodity = New System.Windows.Forms.Button()
        Me.tbCommodityFreq = New System.Windows.Forms.TextBox()
        Me.pbSetCommodity = New System.Windows.Forms.Button()
        Me.tbCommodityAmount = New System.Windows.Forms.TextBox()
        Me.pbGetCommodSub = New System.Windows.Forms.Button()
        Me.tbCommodityRate = New System.Windows.Forms.TextBox()
        Me.pbSetCommodSub = New System.Windows.Forms.Button()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.lbCommodityCode1 = New System.Windows.Forms.ComboBox()
        Me.cbEstimated1 = New System.Windows.Forms.CheckBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.cbCommoditySupported1 = New System.Windows.Forms.CheckBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.tdCommodityCodes = New System.Windows.Forms.GroupBox()
        Me.lbCommodityCode = New System.Windows.Forms.ComboBox()
        Me.nudCommodityFreq = New System.Windows.Forms.NumericUpDown()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cbEstimated = New System.Windows.Forms.CheckBox()
        Me.nudCommodityRate = New System.Windows.Forms.NumericUpDown()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.cbCommoditySupported = New System.Windows.Forms.CheckBox()
        Me.nudCommodityAmount = New System.Windows.Forms.NumericUpDown()
        Me.pbCommoditySave = New System.Windows.Forms.Button()
        Me.getSet = New System.Windows.Forms.TabPage()
        Me.pbGetEnergyPrice = New System.Windows.Forms.Button()
        Me.pbSetTier = New System.Windows.Forms.Button()
        Me.pfGetTier = New System.Windows.Forms.Button()
        Me.pbSetEnergyPrice = New System.Windows.Forms.Button()
        Me.commonCommandsTab = New System.Windows.Forms.TabPage()
        Me.commonCommandsTabControl = New System.Windows.Forms.TabControl()
        Me.changeBaudTab = New System.Windows.Forms.TabPage()
        Me.simulateErrorsTab = New System.Windows.Forms.TabPage()
        Me.opcodeErrorsGroup = New System.Windows.Forms.GroupBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.customLength2ValBox = New System.Windows.Forms.NumericUpDown()
        Me.customLength1ValBox = New System.Windows.Forms.NumericUpDown()
        Me.customLength2cb = New System.Windows.Forms.CheckBox()
        Me.customLength1cb = New System.Windows.Forms.CheckBox()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.customMsgType2ValBox = New System.Windows.Forms.NumericUpDown()
        Me.customMsgType1ValBox = New System.Windows.Forms.NumericUpDown()
        Me.customMsgType2cb = New System.Windows.Forms.CheckBox()
        Me.customMsgType1cb = New System.Windows.Forms.CheckBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.badOpcode2valbox = New System.Windows.Forms.NumericUpDown()
        Me.badOpcode1valbox = New System.Windows.Forms.NumericUpDown()
        Me.badOpcode2cb = New System.Windows.Forms.CheckBox()
        Me.badOpcode1cb = New System.Windows.Forms.CheckBox()
        Me.TimingTab = New System.Windows.Forms.TabPage()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.label3i4lskjfdlj = New System.Windows.Forms.Label()
        Me.tMLValBox = New System.Windows.Forms.NumericUpDown()
        Me.labelwhatever = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.tIMValBox = New System.Windows.Forms.NumericUpDown()
        Me.tRAValBox = New System.Windows.Forms.NumericUpDown()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.label61 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tARValBox = New System.Windows.Forms.NumericUpDown()
        Me.tMAValBox = New System.Windows.Forms.NumericUpDown()
        Me.PassThrough = New System.Windows.Forms.TabPage()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.pbSendPT = New System.Windows.Forms.Button()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.cbProtocolPT = New System.Windows.Forms.ComboBox()
        Me.pbBrowsePT = New System.Windows.Forms.Button()
        Me.tbFilePathPT = New System.Windows.Forms.TextBox()
        Me.cbAddWrapper = New System.Windows.Forms.CheckBox()
        Me.ucmTab = New System.Windows.Forms.TabPage()
        Me.ucmTabControl = New System.Windows.Forms.TabControl()
        Me.ucmManageDeviceTab = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.shedLoadTab = New System.Windows.Forms.TabPage()
        Me.criticalPeakButton = New System.Windows.Forms.Button()
        Me.btnEndShed = New System.Windows.Forms.Button()
        Me.gridEmergencyButton = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pbLoadUp = New System.Windows.Forms.Button()
        Me.btnShedSend = New System.Windows.Forms.Button()
        Me.txtShedDur = New System.Windows.Forms.TextBox()
        Me.trkShedDur = New System.Windows.Forms.TrackBar()
        Me.gridGuidenceTab = New System.Windows.Forms.TabPage()
        Me.grpGridGuide = New System.Windows.Forms.GroupBox()
        Me.sendGuidenceButton = New System.Windows.Forms.Button()
        Me.cmbGridGuide = New System.Windows.Forms.ComboBox()
        Me.nextPeriodRelativePriceTab = New System.Windows.Forms.TabPage()
        Me.nextPeriodPriceGroup = New System.Windows.Forms.GroupBox()
        Me.nextPeriodPriceButton = New System.Windows.Forms.Button()
        Me.nextPeriodPriceTextBox = New System.Windows.Forms.TextBox()
        Me.nextPeriodTrackBar = New System.Windows.Forms.TrackBar()
        Me.presentRelativePriceTab = New System.Windows.Forms.TabPage()
        Me.presentPriceGroup = New System.Windows.Forms.GroupBox()
        Me.presentPriceButton = New System.Windows.Forms.Button()
        Me.presentPriceTextBox = New System.Windows.Forms.TextBox()
        Me.presentPriceTrackBar = New System.Windows.Forms.TrackBar()
        Me.requestPowerLevelTab = New System.Windows.Forms.TabPage()
        Me.gbReqPowerLevel = New System.Windows.Forms.GroupBox()
        Me.rbAbsorbed = New System.Windows.Forms.RadioButton()
        Me.rbProduced = New System.Windows.Forms.RadioButton()
        Me.btnRPLAccept = New System.Windows.Forms.Button()
        Me.tbPowerAP = New System.Windows.Forms.TextBox()
        Me.tbarPower = New System.Windows.Forms.TrackBar()
        Me.timeRemainingTab = New System.Windows.Forms.TabPage()
        Me.timeRemainingGroup = New System.Windows.Forms.GroupBox()
        Me.timeRemainingButton = New System.Windows.Forms.Button()
        Me.timeRemainingTextBox = New System.Windows.Forms.TextBox()
        Me.timeRemainingTrackBar = New System.Windows.Forms.TrackBar()
        Me.ucmQueryTab = New System.Windows.Forms.TabPage()
        Me.currentStategb = New System.Windows.Forms.GroupBox()
        Me.currentStatetb = New System.Windows.Forms.TextBox()
        Me.gbQuery = New System.Windows.Forms.GroupBox()
        Me.pbOpState = New System.Windows.Forms.Button()
        Me.ucmComStatusTab = New System.Windows.Forms.TabPage()
        Me.gbCommStatus = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbCommStatus = New System.Windows.Forms.ComboBox()
        Me.ucmTimeSyncTab = New System.Windows.Forms.TabPage()
        Me.gbTimeSync = New System.Windows.Forms.GroupBox()
        Me.btnTimeSyncOff = New System.Windows.Forms.Button()
        Me.btnTimeSyncOn = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.ucmSetUTC = New System.Windows.Forms.TabPage()
        Me.nudUTCOffset = New System.Windows.Forms.NumericUpDown()
        Me.nudDSTOffset = New System.Windows.Forms.NumericUpDown()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.btnSetUTC = New System.Windows.Forms.Button()
        Me.ucmAutoCycling = New System.Windows.Forms.TabPage()
        Me.nudStopEndRand = New System.Windows.Forms.NumericUpDown()
        Me.nudStopEventID = New System.Windows.Forms.NumericUpDown()
        Me.nudEndRandomization = New System.Windows.Forms.NumericUpDown()
        Me.nudStartRandomization = New System.Windows.Forms.NumericUpDown()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.dtpStartTime = New System.Windows.Forms.DateTimePicker()
        Me.nudDuration = New System.Windows.Forms.NumericUpDown()
        Me.nudDutyCycle = New System.Windows.Forms.NumericUpDown()
        Me.nudEventID = New System.Windows.Forms.NumericUpDown()
        Me.btnStopCycling = New System.Windows.Forms.Button()
        Me.btnStartCycling = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.sgdTab = New System.Windows.Forms.TabPage()
        Me.TestScripts = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.scriptFeedBox = New System.Windows.Forms.RichTextBox()
        Me.testScriptbtn = New System.Windows.Forms.Button()
        Me.pbManualFail = New System.Windows.Forms.Button()
        Me.pbManualPass = New System.Windows.Forms.Button()
        Me.pbManCont = New System.Windows.Forms.Button()
        Me.pbKillScript = New System.Windows.Forms.Button()
        Me.pbExecuteScript = New System.Windows.Forms.Button()
        Me.pbOpenScript = New System.Windows.Forms.Button()
        Me.tbScriptFile = New System.Windows.Forms.TextBox()
        Me.realDeviceTab = New System.Windows.Forms.TabPage()
        Me.realDeviceTabControl = New System.Windows.Forms.TabControl()
        Me.commonRealFunctionsTab = New System.Windows.Forms.TabPage()
        Me.realCommonFunctionsGroup = New System.Windows.Forms.GroupBox()
        Me.realDeviceCommandRetrycb = New System.Windows.Forms.CheckBox()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.realDeviceIgnoreMaxPayloadCheckBox = New System.Windows.Forms.CheckBox()
        Me.realUCMFunctionsTab = New System.Windows.Forms.TabPage()
        Me.realUCMFunctionsGroup = New System.Windows.Forms.GroupBox()
        Me.realUCMTrasmissionIntervalBox = New System.Windows.Forms.NumericUpDown()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.realUCMCommStatusBox = New System.Windows.Forms.ComboBox()
        Me.realSGDFunctionsTab = New System.Windows.Forms.TabPage()
        Me.realSGDFunctionsGroup = New System.Windows.Forms.GroupBox()
        Me.realSGDNoCommTimeoutEnabledbtn = New System.Windows.Forms.Button()
        Me.realSGDNoCommTimeoutValBox = New System.Windows.Forms.NumericUpDown()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.realSGDNeutralResponse = New System.Windows.Forms.ComboBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.realSGDBadTimeResponse = New System.Windows.Forms.ComboBox()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.realSGDGoodTimeResponse = New System.Windows.Forms.ComboBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.realSGDEmergencyResponse = New System.Windows.Forms.ComboBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.realSGDLoadUpResponse = New System.Windows.Forms.ComboBox()
        Me.realSGDEndShedResponse = New System.Windows.Forms.ComboBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.realSGDCritPeakResponse = New System.Windows.Forms.ComboBox()
        Me.realSGDShedResponse = New System.Windows.Forms.ComboBox()
        Me.internalClockSupportedcb = New System.Windows.Forms.CheckBox()
        Me.tmrProcessComm = New System.Windows.Forms.Timer(Me.components)
        Me.pbCommRefresh = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsmAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.fbdScriptFileSelect = New System.Windows.Forms.OpenFileDialog()
        Me.cbResponseSim = New System.Windows.Forms.CheckBox()
        Me.autoCommStatusTimer = New System.Windows.Forms.Timer(Me.components)
        Me.commStatusTimoutTmr = New System.Windows.Forms.Timer(Me.components)
        Me.shedEventTimer = New System.Windows.Forms.Timer(Me.components)
        Me.loadUpEventTimer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox2.SuspendLayout()
        Me.grpChangeBaud.SuspendLayout()
        Me.gbErrors.SuspendLayout()
        CType(Me.nudAppNakRtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNakRtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSGDConfig.SuspendLayout()
        Me.grpOpState.SuspendLayout()
        Me.logFile.SuspendLayout()
        Me.sgdTabControl.SuspendLayout()
        Me.sgdOpStateTab.SuspendLayout()
        Me.GetUtc.SuspendLayout()
        Me.simulatorDeviceTypeTabControl.SuspendLayout()
        Me.deviceInfoTab.SuspendLayout()
        Me.deviceInfoTabControl.SuspendLayout()
        Me.generalInfoTab.SuspendLayout()
        CType(Me.nudCapBitMap3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCapBitMap2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCapBitMap1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCapBitMap0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDevRevLSB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDevRevMSB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudVendorIDLSB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudVendorIDMSB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFirmwareMinor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFirmwareMajor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.getDeviceInfo.SuspendLayout()
        Me.msgTypeSupportedTab.SuspendLayout()
        Me.msgSupportQuery.SuspendLayout()
        CType(Me.nudSupMsgQueryLSB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSupMsgQueryMSB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msgSupportedBox.SuspendLayout()
        CType(Me.nudMsgSuppLSB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMsgSuppMSB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.setMaxPayloadTab.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tempF.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.nudPresentTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.nudSetpointDeviceType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.nudTempOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.nudSetPoint1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSetPoint2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.commodity.SuspendLayout()
        Me.cdCommodityGb.SuspendLayout()
        Me.tdCommodityCodes.SuspendLayout()
        CType(Me.nudCommodityFreq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCommodityRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCommodityAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.getSet.SuspendLayout()
        Me.commonCommandsTab.SuspendLayout()
        Me.commonCommandsTabControl.SuspendLayout()
        Me.changeBaudTab.SuspendLayout()
        Me.simulateErrorsTab.SuspendLayout()
        Me.opcodeErrorsGroup.SuspendLayout()
        CType(Me.customLength2ValBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.customLength1ValBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.customMsgType2ValBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.customMsgType1ValBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.badOpcode2valbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.badOpcode1valbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TimingTab.SuspendLayout()
        CType(Me.tMLValBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tIMValBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tRAValBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tARValBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tMAValBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PassThrough.SuspendLayout()
        Me.ucmTab.SuspendLayout()
        Me.ucmTabControl.SuspendLayout()
        Me.ucmManageDeviceTab.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.shedLoadTab.SuspendLayout()
        CType(Me.trkShedDur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gridGuidenceTab.SuspendLayout()
        Me.grpGridGuide.SuspendLayout()
        Me.nextPeriodRelativePriceTab.SuspendLayout()
        Me.nextPeriodPriceGroup.SuspendLayout()
        CType(Me.nextPeriodTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.presentRelativePriceTab.SuspendLayout()
        Me.presentPriceGroup.SuspendLayout()
        CType(Me.presentPriceTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.requestPowerLevelTab.SuspendLayout()
        Me.gbReqPowerLevel.SuspendLayout()
        CType(Me.tbarPower, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.timeRemainingTab.SuspendLayout()
        Me.timeRemainingGroup.SuspendLayout()
        CType(Me.timeRemainingTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ucmQueryTab.SuspendLayout()
        Me.currentStategb.SuspendLayout()
        Me.gbQuery.SuspendLayout()
        Me.ucmComStatusTab.SuspendLayout()
        Me.gbCommStatus.SuspendLayout()
        Me.ucmTimeSyncTab.SuspendLayout()
        Me.gbTimeSync.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.ucmSetUTC.SuspendLayout()
        CType(Me.nudUTCOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDSTOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ucmAutoCycling.SuspendLayout()
        CType(Me.nudStopEndRand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudStopEventID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudEndRandomization, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudStartRandomization, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDutyCycle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudEventID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sgdTab.SuspendLayout()
        Me.TestScripts.SuspendLayout()
        Me.realDeviceTab.SuspendLayout()
        Me.realDeviceTabControl.SuspendLayout()
        Me.commonRealFunctionsTab.SuspendLayout()
        Me.realCommonFunctionsGroup.SuspendLayout()
        Me.realUCMFunctionsTab.SuspendLayout()
        Me.realUCMFunctionsGroup.SuspendLayout()
        CType(Me.realUCMTrasmissionIntervalBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.realSGDFunctionsTab.SuspendLayout()
        Me.realSGDFunctionsGroup.SuspendLayout()
        CType(Me.realSGDNoCommTimeoutValBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Comm Port:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Bit Rate:"
        '
        'CmbPort
        '
        Me.CmbPort.FormattingEnabled = True
        Me.CmbPort.Location = New System.Drawing.Point(93, 36)
        Me.CmbPort.Name = "CmbPort"
        Me.CmbPort.Size = New System.Drawing.Size(121, 21)
        Me.CmbPort.TabIndex = 2
        '
        'CmbBaud
        '
        Me.CmbBaud.FormattingEnabled = True
        Me.CmbBaud.Location = New System.Drawing.Point(93, 67)
        Me.CmbBaud.Name = "CmbBaud"
        Me.CmbBaud.Size = New System.Drawing.Size(121, 21)
        Me.CmbBaud.TabIndex = 3
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(235, 36)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 4
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(235, 65)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(75, 23)
        Me.btnDisconnect.TabIndex = 5
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnClearDebug)
        Me.GroupBox2.Controls.Add(Me.rtbReceived)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 201)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(437, 292)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Serial Data"
        '
        'btnClearDebug
        '
        Me.btnClearDebug.Location = New System.Drawing.Point(412, 31)
        Me.btnClearDebug.Name = "btnClearDebug"
        Me.btnClearDebug.Size = New System.Drawing.Size(19, 23)
        Me.btnClearDebug.TabIndex = 1
        Me.btnClearDebug.Text = "X"
        Me.btnClearDebug.UseVisualStyleBackColor = True
        '
        'rtbReceived
        '
        Me.rtbReceived.BackColor = System.Drawing.Color.White
        Me.rtbReceived.Location = New System.Drawing.Point(25, 19)
        Me.rtbReceived.Name = "rtbReceived"
        Me.rtbReceived.ReadOnly = True
        Me.rtbReceived.Size = New System.Drawing.Size(380, 259)
        Me.rtbReceived.TabIndex = 0
        Me.rtbReceived.Text = ""
        '
        'grpChangeBaud
        '
        Me.grpChangeBaud.Controls.Add(Me.cmbChangeBaud)
        Me.grpChangeBaud.Controls.Add(Me.btnAcceptChangeBaud)
        Me.grpChangeBaud.Location = New System.Drawing.Point(6, 6)
        Me.grpChangeBaud.Name = "grpChangeBaud"
        Me.grpChangeBaud.Size = New System.Drawing.Size(216, 91)
        Me.grpChangeBaud.TabIndex = 27
        Me.grpChangeBaud.TabStop = False
        Me.grpChangeBaud.Text = "Change Bit Rate"
        Me.grpChangeBaud.Visible = False
        '
        'cmbChangeBaud
        '
        Me.cmbChangeBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChangeBaud.FormattingEnabled = True
        Me.cmbChangeBaud.Items.AddRange(New Object() {"19200", "38400", "57600", "115200", "256000", "460800", "921600", "1843200", "3686400"})
        Me.cmbChangeBaud.Location = New System.Drawing.Point(14, 28)
        Me.cmbChangeBaud.Name = "cmbChangeBaud"
        Me.cmbChangeBaud.Size = New System.Drawing.Size(188, 21)
        Me.cmbChangeBaud.TabIndex = 15
        '
        'btnAcceptChangeBaud
        '
        Me.btnAcceptChangeBaud.Location = New System.Drawing.Point(106, 62)
        Me.btnAcceptChangeBaud.Name = "btnAcceptChangeBaud"
        Me.btnAcceptChangeBaud.Size = New System.Drawing.Size(96, 23)
        Me.btnAcceptChangeBaud.TabIndex = 13
        Me.btnAcceptChangeBaud.Text = "Change Bit Rate"
        Me.btnAcceptChangeBaud.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        '
        'rbMode1
        '
        Me.rbMode1.AutoSize = True
        Me.rbMode1.Checked = True
        Me.rbMode1.Location = New System.Drawing.Point(329, 37)
        Me.rbMode1.Name = "rbMode1"
        Me.rbMode1.Size = New System.Drawing.Size(102, 17)
        Me.rbMode1.TabIndex = 8
        Me.rbMode1.TabStop = True
        Me.rbMode1.Text = "UCM (Controller)"
        Me.rbMode1.UseVisualStyleBackColor = True
        '
        'rbMode2
        '
        Me.rbMode2.AutoSize = True
        Me.rbMode2.Location = New System.Drawing.Point(329, 68)
        Me.rbMode2.Name = "rbMode2"
        Me.rbMode2.Size = New System.Drawing.Size(104, 17)
        Me.rbMode2.TabIndex = 9
        Me.rbMode2.Text = "SGD (Appliance)"
        Me.rbMode2.UseVisualStyleBackColor = True
        '
        'gbErrors
        '
        Me.gbErrors.Controls.Add(Me.Label55)
        Me.gbErrors.Controls.Add(Me.nudAppNakRtn)
        Me.gbErrors.Controls.Add(Me.cbAppNakMsg)
        Me.gbErrors.Controls.Add(Me.Label54)
        Me.gbErrors.Controls.Add(Me.nudNakRtn)
        Me.gbErrors.Controls.Add(Me.cbNakMsg)
        Me.gbErrors.Controls.Add(Me.chkShortMsg)
        Me.gbErrors.Controls.Add(Me.chkLongMsg)
        Me.gbErrors.Controls.Add(Me.chkBadCheckSum)
        Me.gbErrors.Location = New System.Drawing.Point(6, 142)
        Me.gbErrors.Name = "gbErrors"
        Me.gbErrors.Size = New System.Drawing.Size(611, 124)
        Me.gbErrors.TabIndex = 18
        Me.gbErrors.TabStop = False
        Me.gbErrors.Text = "Other Errors"
        Me.gbErrors.Visible = False
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(218, 90)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(86, 13)
        Me.Label55.TabIndex = 12
        Me.Label55.Text = "App NAK Return"
        '
        'nudAppNakRtn
        '
        Me.nudAppNakRtn.Location = New System.Drawing.Point(172, 88)
        Me.nudAppNakRtn.Name = "nudAppNakRtn"
        Me.nudAppNakRtn.Size = New System.Drawing.Size(44, 20)
        Me.nudAppNakRtn.TabIndex = 11
        '
        'cbAppNakMsg
        '
        Me.cbAppNakMsg.AutoSize = True
        Me.cbAppNakMsg.Location = New System.Drawing.Point(171, 61)
        Me.cbAppNakMsg.Name = "cbAppNakMsg"
        Me.cbAppNakMsg.Size = New System.Drawing.Size(116, 17)
        Me.cbAppNakMsg.TabIndex = 10
        Me.cbAppNakMsg.Text = "App NAK Message"
        Me.cbAppNakMsg.UseVisualStyleBackColor = True
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(57, 93)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(64, 13)
        Me.Label54.TabIndex = 9
        Me.Label54.Text = "NAK Return"
        '
        'nudNakRtn
        '
        Me.nudNakRtn.Location = New System.Drawing.Point(13, 91)
        Me.nudNakRtn.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudNakRtn.Name = "nudNakRtn"
        Me.nudNakRtn.Size = New System.Drawing.Size(42, 20)
        Me.nudNakRtn.TabIndex = 8
        '
        'cbNakMsg
        '
        Me.cbNakMsg.AutoSize = True
        Me.cbNakMsg.Location = New System.Drawing.Point(14, 61)
        Me.cbNakMsg.Name = "cbNakMsg"
        Me.cbNakMsg.Size = New System.Drawing.Size(117, 17)
        Me.cbNakMsg.TabIndex = 7
        Me.cbNakMsg.Text = "Link NAK Message"
        Me.cbNakMsg.UseVisualStyleBackColor = True
        '
        'chkShortMsg
        '
        Me.chkShortMsg.AutoSize = True
        Me.chkShortMsg.Location = New System.Drawing.Point(334, 29)
        Me.chkShortMsg.Name = "chkShortMsg"
        Me.chkShortMsg.Size = New System.Drawing.Size(119, 17)
        Me.chkShortMsg.TabIndex = 6
        Me.chkShortMsg.Text = "Message Too Short"
        Me.chkShortMsg.UseVisualStyleBackColor = True
        '
        'chkLongMsg
        '
        Me.chkLongMsg.AutoSize = True
        Me.chkLongMsg.Location = New System.Drawing.Point(170, 29)
        Me.chkLongMsg.Name = "chkLongMsg"
        Me.chkLongMsg.Size = New System.Drawing.Size(118, 17)
        Me.chkLongMsg.TabIndex = 5
        Me.chkLongMsg.Text = "Message Too Long"
        Me.chkLongMsg.UseVisualStyleBackColor = True
        '
        'chkBadCheckSum
        '
        Me.chkBadCheckSum.AutoSize = True
        Me.chkBadCheckSum.Location = New System.Drawing.Point(14, 29)
        Me.chkBadCheckSum.Name = "chkBadCheckSum"
        Me.chkBadCheckSum.Size = New System.Drawing.Size(98, 17)
        Me.chkBadCheckSum.TabIndex = 3
        Me.chkBadCheckSum.Text = "Bad Checksum"
        Me.chkBadCheckSum.UseVisualStyleBackColor = True
        '
        'grpSGDConfig
        '
        Me.grpSGDConfig.Controls.Add(Me.chkCustOverride)
        Me.grpSGDConfig.Location = New System.Drawing.Point(24, 99)
        Me.grpSGDConfig.Name = "grpSGDConfig"
        Me.grpSGDConfig.Size = New System.Drawing.Size(206, 57)
        Me.grpSGDConfig.TabIndex = 23
        Me.grpSGDConfig.TabStop = False
        Me.grpSGDConfig.Text = "SGD Configuration"
        Me.grpSGDConfig.Visible = False
        '
        'chkCustOverride
        '
        Me.chkCustOverride.AutoSize = True
        Me.chkCustOverride.Location = New System.Drawing.Point(17, 28)
        Me.chkCustOverride.Name = "chkCustOverride"
        Me.chkCustOverride.Size = New System.Drawing.Size(113, 17)
        Me.chkCustOverride.TabIndex = 1
        Me.chkCustOverride.Text = "Customer Override"
        Me.chkCustOverride.UseVisualStyleBackColor = True
        '
        'grpOpState
        '
        Me.grpOpState.Controls.Add(Me.OpStateBox)
        Me.grpOpState.Location = New System.Drawing.Point(24, 19)
        Me.grpOpState.Name = "grpOpState"
        Me.grpOpState.Size = New System.Drawing.Size(224, 53)
        Me.grpOpState.TabIndex = 0
        Me.grpOpState.TabStop = False
        Me.grpOpState.Text = "Current Operating State"
        Me.grpOpState.Visible = False
        '
        'OpStateBox
        '
        Me.OpStateBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OpStateBox.FormattingEnabled = True
        Me.OpStateBox.Items.AddRange(New Object() {"Idle Normal", "Running Normal", "Running Curtailed Grid", "Running Heightened Grid", "Idle Grid", "SGD Error Condition", "Idle Heightened", "Cycling On", "cycling Off", "Variable Following", "Variable Not Following", "Idle Opted Out", "Running Opted Out"})
        Me.OpStateBox.Location = New System.Drawing.Point(12, 19)
        Me.OpStateBox.Name = "OpStateBox"
        Me.OpStateBox.Size = New System.Drawing.Size(206, 21)
        Me.OpStateBox.TabIndex = 24
        '
        'tmrTimeSync
        '
        '
        'tmrBaudDefault
        '
        Me.tmrBaudDefault.Interval = 900000
        '
        'tbLogFile
        '
        Me.tbLogFile.Location = New System.Drawing.Point(49, 19)
        Me.tbLogFile.Name = "tbLogFile"
        Me.tbLogFile.Size = New System.Drawing.Size(354, 20)
        Me.tbLogFile.TabIndex = 28
        '
        'Browse
        '
        Me.Browse.Location = New System.Drawing.Point(49, 45)
        Me.Browse.Name = "Browse"
        Me.Browse.Size = New System.Drawing.Size(93, 24)
        Me.Browse.TabIndex = 30
        Me.Browse.Text = "Browse"
        Me.Browse.UseVisualStyleBackColor = True
        '
        'disableLogFile
        '
        Me.disableLogFile.AutoSize = True
        Me.disableLogFile.Location = New System.Drawing.Point(157, 50)
        Me.disableLogFile.Name = "disableLogFile"
        Me.disableLogFile.Size = New System.Drawing.Size(101, 17)
        Me.disableLogFile.TabIndex = 34
        Me.disableLogFile.Text = "Disable Log File"
        Me.disableLogFile.UseVisualStyleBackColor = True
        '
        'logFile
        '
        Me.logFile.Controls.Add(Me.cbVerboseLog)
        Me.logFile.Controls.Add(Me.logFilePathLabel)
        Me.logFile.Controls.Add(Me.tbLogFile)
        Me.logFile.Controls.Add(Me.disableLogFile)
        Me.logFile.Controls.Add(Me.Browse)
        Me.logFile.Location = New System.Drawing.Point(17, 116)
        Me.logFile.Name = "logFile"
        Me.logFile.Size = New System.Drawing.Size(437, 79)
        Me.logFile.TabIndex = 35
        Me.logFile.TabStop = False
        Me.logFile.Text = "Log File"
        '
        'cbVerboseLog
        '
        Me.cbVerboseLog.AutoSize = True
        Me.cbVerboseLog.Location = New System.Drawing.Point(264, 50)
        Me.cbVerboseLog.Name = "cbVerboseLog"
        Me.cbVerboseLog.Size = New System.Drawing.Size(65, 17)
        Me.cbVerboseLog.TabIndex = 36
        Me.cbVerboseLog.Text = "Verbose"
        Me.cbVerboseLog.UseVisualStyleBackColor = True
        '
        'logFilePathLabel
        '
        Me.logFilePathLabel.AutoSize = True
        Me.logFilePathLabel.Location = New System.Drawing.Point(11, 26)
        Me.logFilePathLabel.Name = "logFilePathLabel"
        Me.logFilePathLabel.Size = New System.Drawing.Size(32, 13)
        Me.logFilePathLabel.TabIndex = 35
        Me.logFilePathLabel.Text = "Path:"
        '
        'sgdTabControl
        '
        Me.sgdTabControl.Controls.Add(Me.sgdOpStateTab)
        Me.sgdTabControl.Controls.Add(Me.GetUtc)
        Me.sgdTabControl.Location = New System.Drawing.Point(6, 6)
        Me.sgdTabControl.Multiline = True
        Me.sgdTabControl.Name = "sgdTabControl"
        Me.sgdTabControl.SelectedIndex = 0
        Me.sgdTabControl.Size = New System.Drawing.Size(631, 339)
        Me.sgdTabControl.TabIndex = 37
        '
        'sgdOpStateTab
        '
        Me.sgdOpStateTab.Controls.Add(Me.grpOpState)
        Me.sgdOpStateTab.Controls.Add(Me.grpSGDConfig)
        Me.sgdOpStateTab.Location = New System.Drawing.Point(4, 22)
        Me.sgdOpStateTab.Name = "sgdOpStateTab"
        Me.sgdOpStateTab.Padding = New System.Windows.Forms.Padding(3)
        Me.sgdOpStateTab.Size = New System.Drawing.Size(623, 313)
        Me.sgdOpStateTab.TabIndex = 0
        Me.sgdOpStateTab.Text = "Operating State"
        Me.sgdOpStateTab.UseVisualStyleBackColor = True
        '
        'GetUtc
        '
        Me.GetUtc.Controls.Add(Me.btnGetUTC)
        Me.GetUtc.Location = New System.Drawing.Point(4, 22)
        Me.GetUtc.Name = "GetUtc"
        Me.GetUtc.Padding = New System.Windows.Forms.Padding(3)
        Me.GetUtc.Size = New System.Drawing.Size(623, 313)
        Me.GetUtc.TabIndex = 1
        Me.GetUtc.Text = "Get UTC Time"
        Me.GetUtc.UseVisualStyleBackColor = True
        '
        'btnGetUTC
        '
        Me.btnGetUTC.Location = New System.Drawing.Point(10, 9)
        Me.btnGetUTC.Name = "btnGetUTC"
        Me.btnGetUTC.Size = New System.Drawing.Size(86, 29)
        Me.btnGetUTC.TabIndex = 0
        Me.btnGetUTC.Text = "Get UTC Time"
        Me.btnGetUTC.UseVisualStyleBackColor = True
        '
        'simulatorDeviceTypeTabControl
        '
        Me.simulatorDeviceTypeTabControl.Controls.Add(Me.deviceInfoTab)
        Me.simulatorDeviceTypeTabControl.Controls.Add(Me.commonCommandsTab)
        Me.simulatorDeviceTypeTabControl.Controls.Add(Me.ucmTab)
        Me.simulatorDeviceTypeTabControl.Controls.Add(Me.sgdTab)
        Me.simulatorDeviceTypeTabControl.Controls.Add(Me.TestScripts)
        Me.simulatorDeviceTypeTabControl.Controls.Add(Me.realDeviceTab)
        Me.simulatorDeviceTypeTabControl.Location = New System.Drawing.Point(478, 116)
        Me.simulatorDeviceTypeTabControl.Name = "simulatorDeviceTypeTabControl"
        Me.simulatorDeviceTypeTabControl.SelectedIndex = 0
        Me.simulatorDeviceTypeTabControl.Size = New System.Drawing.Size(651, 377)
        Me.simulatorDeviceTypeTabControl.TabIndex = 39
        '
        'deviceInfoTab
        '
        Me.deviceInfoTab.Controls.Add(Me.deviceInfoTabControl)
        Me.deviceInfoTab.Location = New System.Drawing.Point(4, 22)
        Me.deviceInfoTab.Name = "deviceInfoTab"
        Me.deviceInfoTab.Padding = New System.Windows.Forms.Padding(3)
        Me.deviceInfoTab.Size = New System.Drawing.Size(643, 351)
        Me.deviceInfoTab.TabIndex = 3
        Me.deviceInfoTab.Text = "Device Information"
        Me.deviceInfoTab.UseVisualStyleBackColor = True
        '
        'deviceInfoTabControl
        '
        Me.deviceInfoTabControl.Controls.Add(Me.generalInfoTab)
        Me.deviceInfoTabControl.Controls.Add(Me.getDeviceInfo)
        Me.deviceInfoTabControl.Controls.Add(Me.msgTypeSupportedTab)
        Me.deviceInfoTabControl.Controls.Add(Me.setMaxPayloadTab)
        Me.deviceInfoTabControl.Controls.Add(Me.tempF)
        Me.deviceInfoTabControl.Controls.Add(Me.commodity)
        Me.deviceInfoTabControl.Controls.Add(Me.getSet)
        Me.deviceInfoTabControl.Location = New System.Drawing.Point(6, 6)
        Me.deviceInfoTabControl.Name = "deviceInfoTabControl"
        Me.deviceInfoTabControl.SelectedIndex = 0
        Me.deviceInfoTabControl.Size = New System.Drawing.Size(631, 339)
        Me.deviceInfoTabControl.TabIndex = 0
        '
        'generalInfoTab
        '
        Me.generalInfoTab.Controls.Add(Me.tbCEA2045Version)
        Me.generalInfoTab.Controls.Add(Me.Label49)
        Me.generalInfoTab.Controls.Add(Me.nudCapBitMap3)
        Me.generalInfoTab.Controls.Add(Me.nudCapBitMap2)
        Me.generalInfoTab.Controls.Add(Me.nudCapBitMap1)
        Me.generalInfoTab.Controls.Add(Me.nudCapBitMap0)
        Me.generalInfoTab.Controls.Add(Me.nudDevRevLSB)
        Me.generalInfoTab.Controls.Add(Me.nudDevRevMSB)
        Me.generalInfoTab.Controls.Add(Me.nudVendorIDLSB)
        Me.generalInfoTab.Controls.Add(Me.nudVendorIDMSB)
        Me.generalInfoTab.Controls.Add(Me.nudFirmwareMinor)
        Me.generalInfoTab.Controls.Add(Me.nudFirmwareMajor)
        Me.generalInfoTab.Controls.Add(Me.Label26)
        Me.generalInfoTab.Controls.Add(Me.Label21)
        Me.generalInfoTab.Controls.Add(Me.firmwareMajorMinorSupportedCheckbox)
        Me.generalInfoTab.Controls.Add(Me.serialNumberSupportedCheckbox)
        Me.generalInfoTab.Controls.Add(Me.modelNumberSupportedCheckbox)
        Me.generalInfoTab.Controls.Add(Me.deviceTypeLSBTextBox)
        Me.generalInfoTab.Controls.Add(Me.firmwareDayComboBox)
        Me.generalInfoTab.Controls.Add(Me.firmwareMonthComboBox)
        Me.generalInfoTab.Controls.Add(Me.firmwareYearComboBox)
        Me.generalInfoTab.Controls.Add(Me.serialNumberTextBox)
        Me.generalInfoTab.Controls.Add(Me.modelNumberTextBox)
        Me.generalInfoTab.Controls.Add(Me.deviceTypeMSBTextBox)
        Me.generalInfoTab.Controls.Add(Me.deviceTypeLabel)
        Me.generalInfoTab.Controls.Add(Me.capabilityBitmapLabel)
        Me.generalInfoTab.Controls.Add(Me.Label11)
        Me.generalInfoTab.Controls.Add(Me.Label12)
        Me.generalInfoTab.Controls.Add(Me.deviceTypeComboBox)
        Me.generalInfoTab.Controls.Add(Me.Label14)
        Me.generalInfoTab.Controls.Add(Me.Label8)
        Me.generalInfoTab.Controls.Add(Me.Label3)
        Me.generalInfoTab.Controls.Add(Me.firmwareMinorLabel)
        Me.generalInfoTab.Controls.Add(Me.vendorIDLabel)
        Me.generalInfoTab.Controls.Add(Me.firmwareMajorLabel)
        Me.generalInfoTab.Controls.Add(Me.firmwareMonthLabel)
        Me.generalInfoTab.Controls.Add(Me.cea2045VersionLabel)
        Me.generalInfoTab.Controls.Add(Me.firmwareDayLabel)
        Me.generalInfoTab.Controls.Add(Me.deviceRevisionLabel)
        Me.generalInfoTab.Controls.Add(Me.firmwareYearLabel)
        Me.generalInfoTab.Controls.Add(Me.serialNumberLabel)
        Me.generalInfoTab.Controls.Add(Me.modelNumberLabel)
        Me.generalInfoTab.Location = New System.Drawing.Point(4, 22)
        Me.generalInfoTab.Name = "generalInfoTab"
        Me.generalInfoTab.Padding = New System.Windows.Forms.Padding(3)
        Me.generalInfoTab.Size = New System.Drawing.Size(623, 313)
        Me.generalInfoTab.TabIndex = 0
        Me.generalInfoTab.Text = "Device Info"
        Me.generalInfoTab.UseVisualStyleBackColor = True
        '
        'tbCEA2045Version
        '
        Me.tbCEA2045Version.Location = New System.Drawing.Point(161, 73)
        Me.tbCEA2045Version.MaxLength = 2
        Me.tbCEA2045Version.Name = "tbCEA2045Version"
        Me.tbCEA2045Version.Size = New System.Drawing.Size(41, 20)
        Me.tbCEA2045Version.TabIndex = 72
        Me.tbCEA2045Version.Text = "10"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(433, 139)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(27, 13)
        Me.Label49.TabIndex = 71
        Me.Label49.Text = "LSB"
        '
        'nudCapBitMap3
        '
        Me.nudCapBitMap3.Hexadecimal = True
        Me.nudCapBitMap3.Location = New System.Drawing.Point(372, 137)
        Me.nudCapBitMap3.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudCapBitMap3.Name = "nudCapBitMap3"
        Me.nudCapBitMap3.Size = New System.Drawing.Size(56, 20)
        Me.nudCapBitMap3.TabIndex = 66
        '
        'nudCapBitMap2
        '
        Me.nudCapBitMap2.Hexadecimal = True
        Me.nudCapBitMap2.Location = New System.Drawing.Point(311, 137)
        Me.nudCapBitMap2.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudCapBitMap2.Name = "nudCapBitMap2"
        Me.nudCapBitMap2.Size = New System.Drawing.Size(56, 20)
        Me.nudCapBitMap2.TabIndex = 65
        '
        'nudCapBitMap1
        '
        Me.nudCapBitMap1.Hexadecimal = True
        Me.nudCapBitMap1.Location = New System.Drawing.Point(250, 136)
        Me.nudCapBitMap1.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudCapBitMap1.Name = "nudCapBitMap1"
        Me.nudCapBitMap1.Size = New System.Drawing.Size(56, 20)
        Me.nudCapBitMap1.TabIndex = 64
        '
        'nudCapBitMap0
        '
        Me.nudCapBitMap0.Hexadecimal = True
        Me.nudCapBitMap0.Location = New System.Drawing.Point(189, 136)
        Me.nudCapBitMap0.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudCapBitMap0.Name = "nudCapBitMap0"
        Me.nudCapBitMap0.Size = New System.Drawing.Size(56, 20)
        Me.nudCapBitMap0.TabIndex = 63
        '
        'nudDevRevLSB
        '
        Me.nudDevRevLSB.Location = New System.Drawing.Point(296, 41)
        Me.nudDevRevLSB.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudDevRevLSB.Name = "nudDevRevLSB"
        Me.nudDevRevLSB.Size = New System.Drawing.Size(56, 20)
        Me.nudDevRevLSB.TabIndex = 62
        '
        'nudDevRevMSB
        '
        Me.nudDevRevMSB.Location = New System.Drawing.Point(190, 42)
        Me.nudDevRevMSB.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudDevRevMSB.Name = "nudDevRevMSB"
        Me.nudDevRevMSB.Size = New System.Drawing.Size(56, 20)
        Me.nudDevRevMSB.TabIndex = 61
        '
        'nudVendorIDLSB
        '
        Me.nudVendorIDLSB.Location = New System.Drawing.Point(295, 13)
        Me.nudVendorIDLSB.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudVendorIDLSB.Name = "nudVendorIDLSB"
        Me.nudVendorIDLSB.Size = New System.Drawing.Size(56, 20)
        Me.nudVendorIDLSB.TabIndex = 60
        '
        'nudVendorIDMSB
        '
        Me.nudVendorIDMSB.Location = New System.Drawing.Point(189, 14)
        Me.nudVendorIDMSB.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudVendorIDMSB.Name = "nudVendorIDMSB"
        Me.nudVendorIDMSB.Size = New System.Drawing.Size(56, 20)
        Me.nudVendorIDMSB.TabIndex = 59
        '
        'nudFirmwareMinor
        '
        Me.nudFirmwareMinor.Location = New System.Drawing.Point(279, 265)
        Me.nudFirmwareMinor.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudFirmwareMinor.Name = "nudFirmwareMinor"
        Me.nudFirmwareMinor.Size = New System.Drawing.Size(51, 20)
        Me.nudFirmwareMinor.TabIndex = 58
        '
        'nudFirmwareMajor
        '
        Me.nudFirmwareMajor.Location = New System.Drawing.Point(105, 265)
        Me.nudFirmwareMajor.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudFirmwareMajor.Name = "nudFirmwareMajor"
        Me.nudFirmwareMajor.Size = New System.Drawing.Size(51, 20)
        Me.nudFirmwareMajor.TabIndex = 57
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(358, 106)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(18, 13)
        Me.Label26.TabIndex = 54
        Me.Label26.Text = "0x"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(427, 106)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(18, 13)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "0x"
        '
        'firmwareMajorMinorSupportedCheckbox
        '
        Me.firmwareMajorMinorSupportedCheckbox.AutoSize = True
        Me.firmwareMajorMinorSupportedCheckbox.Location = New System.Drawing.Point(343, 268)
        Me.firmwareMajorMinorSupportedCheckbox.Name = "firmwareMajorMinorSupportedCheckbox"
        Me.firmwareMajorMinorSupportedCheckbox.Size = New System.Drawing.Size(75, 17)
        Me.firmwareMajorMinorSupportedCheckbox.TabIndex = 52
        Me.firmwareMajorMinorSupportedCheckbox.Text = "Supported"
        Me.firmwareMajorMinorSupportedCheckbox.UseVisualStyleBackColor = True
        '
        'serialNumberSupportedCheckbox
        '
        Me.serialNumberSupportedCheckbox.AutoSize = True
        Me.serialNumberSupportedCheckbox.Location = New System.Drawing.Point(455, 200)
        Me.serialNumberSupportedCheckbox.Name = "serialNumberSupportedCheckbox"
        Me.serialNumberSupportedCheckbox.Size = New System.Drawing.Size(75, 17)
        Me.serialNumberSupportedCheckbox.TabIndex = 50
        Me.serialNumberSupportedCheckbox.Text = "Supported"
        Me.serialNumberSupportedCheckbox.UseVisualStyleBackColor = True
        '
        'modelNumberSupportedCheckbox
        '
        Me.modelNumberSupportedCheckbox.AutoSize = True
        Me.modelNumberSupportedCheckbox.Location = New System.Drawing.Point(455, 168)
        Me.modelNumberSupportedCheckbox.Name = "modelNumberSupportedCheckbox"
        Me.modelNumberSupportedCheckbox.Size = New System.Drawing.Size(75, 17)
        Me.modelNumberSupportedCheckbox.TabIndex = 49
        Me.modelNumberSupportedCheckbox.Text = "Supported"
        Me.modelNumberSupportedCheckbox.UseVisualStyleBackColor = True
        '
        'deviceTypeLSBTextBox
        '
        Me.deviceTypeLSBTextBox.Location = New System.Drawing.Point(446, 103)
        Me.deviceTypeLSBTextBox.MaxLength = 2
        Me.deviceTypeLSBTextBox.Name = "deviceTypeLSBTextBox"
        Me.deviceTypeLSBTextBox.Size = New System.Drawing.Size(44, 20)
        Me.deviceTypeLSBTextBox.TabIndex = 42
        Me.deviceTypeLSBTextBox.Text = "10"
        '
        'firmwareDayComboBox
        '
        Me.firmwareDayComboBox.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.firmwareDayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.firmwareDayComboBox.FormattingEnabled = True
        Me.firmwareDayComboBox.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.firmwareDayComboBox.Location = New System.Drawing.Point(438, 231)
        Me.firmwareDayComboBox.Name = "firmwareDayComboBox"
        Me.firmwareDayComboBox.Size = New System.Drawing.Size(73, 21)
        Me.firmwareDayComboBox.TabIndex = 39
        '
        'firmwareMonthComboBox
        '
        Me.firmwareMonthComboBox.AutoCompleteCustomSource.AddRange(New String() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.firmwareMonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.firmwareMonthComboBox.FormattingEnabled = True
        Me.firmwareMonthComboBox.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.firmwareMonthComboBox.Location = New System.Drawing.Point(279, 231)
        Me.firmwareMonthComboBox.Name = "firmwareMonthComboBox"
        Me.firmwareMonthComboBox.Size = New System.Drawing.Size(73, 21)
        Me.firmwareMonthComboBox.TabIndex = 38
        '
        'firmwareYearComboBox
        '
        Me.firmwareYearComboBox.AutoCompleteCustomSource.AddRange(New String() {"2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020"})
        Me.firmwareYearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.firmwareYearComboBox.FormattingEnabled = True
        Me.firmwareYearComboBox.Items.AddRange(New Object() {"2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020"})
        Me.firmwareYearComboBox.Location = New System.Drawing.Point(101, 231)
        Me.firmwareYearComboBox.Name = "firmwareYearComboBox"
        Me.firmwareYearComboBox.Size = New System.Drawing.Size(73, 21)
        Me.firmwareYearComboBox.TabIndex = 37
        '
        'serialNumberTextBox
        '
        Me.serialNumberTextBox.Location = New System.Drawing.Point(159, 198)
        Me.serialNumberTextBox.MaxLength = 16
        Me.serialNumberTextBox.Name = "serialNumberTextBox"
        Me.serialNumberTextBox.Size = New System.Drawing.Size(286, 20)
        Me.serialNumberTextBox.TabIndex = 35
        '
        'modelNumberTextBox
        '
        Me.modelNumberTextBox.Location = New System.Drawing.Point(159, 166)
        Me.modelNumberTextBox.MaxLength = 16
        Me.modelNumberTextBox.Name = "modelNumberTextBox"
        Me.modelNumberTextBox.Size = New System.Drawing.Size(286, 20)
        Me.modelNumberTextBox.TabIndex = 34
        '
        'deviceTypeMSBTextBox
        '
        Me.deviceTypeMSBTextBox.Location = New System.Drawing.Point(377, 103)
        Me.deviceTypeMSBTextBox.MaxLength = 2
        Me.deviceTypeMSBTextBox.Name = "deviceTypeMSBTextBox"
        Me.deviceTypeMSBTextBox.Size = New System.Drawing.Size(42, 20)
        Me.deviceTypeMSBTextBox.TabIndex = 36
        '
        'deviceTypeLabel
        '
        Me.deviceTypeLabel.AutoSize = True
        Me.deviceTypeLabel.Location = New System.Drawing.Point(18, 106)
        Me.deviceTypeLabel.Name = "deviceTypeLabel"
        Me.deviceTypeLabel.Size = New System.Drawing.Size(71, 13)
        Me.deviceTypeLabel.TabIndex = 1
        Me.deviceTypeLabel.Text = "Device Type:"
        '
        'capabilityBitmapLabel
        '
        Me.capabilityBitmapLabel.AutoSize = True
        Me.capabilityBitmapLabel.Location = New System.Drawing.Point(18, 138)
        Me.capabilityBitmapLabel.Name = "capabilityBitmapLabel"
        Me.capabilityBitmapLabel.Size = New System.Drawing.Size(90, 13)
        Me.capabilityBitmapLabel.TabIndex = 4
        Me.capabilityBitmapLabel.Text = "Capability Bitmap:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(262, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "LSB:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(156, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "MSB:"
        '
        'deviceTypeComboBox
        '
        Me.deviceTypeComboBox.BackColor = System.Drawing.Color.White
        Me.deviceTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.deviceTypeComboBox.FormattingEnabled = True
        Me.deviceTypeComboBox.Location = New System.Drawing.Point(159, 103)
        Me.deviceTypeComboBox.Name = "deviceTypeComboBox"
        Me.deviceTypeComboBox.Size = New System.Drawing.Size(188, 21)
        Me.deviceTypeComboBox.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(156, 138)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "MSB:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(263, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "LSB:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(156, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "MSB:"
        '
        'firmwareMinorLabel
        '
        Me.firmwareMinorLabel.AutoSize = True
        Me.firmwareMinorLabel.Location = New System.Drawing.Point(192, 269)
        Me.firmwareMinorLabel.Name = "firmwareMinorLabel"
        Me.firmwareMinorLabel.Size = New System.Drawing.Size(81, 13)
        Me.firmwareMinorLabel.TabIndex = 11
        Me.firmwareMinorLabel.Text = "Firmware Minor:"
        '
        'vendorIDLabel
        '
        Me.vendorIDLabel.AutoSize = True
        Me.vendorIDLabel.Location = New System.Drawing.Point(18, 16)
        Me.vendorIDLabel.Name = "vendorIDLabel"
        Me.vendorIDLabel.Size = New System.Drawing.Size(58, 13)
        Me.vendorIDLabel.TabIndex = 0
        Me.vendorIDLabel.Text = "Vendor ID:"
        '
        'firmwareMajorLabel
        '
        Me.firmwareMajorLabel.AutoSize = True
        Me.firmwareMajorLabel.Location = New System.Drawing.Point(18, 269)
        Me.firmwareMajorLabel.Name = "firmwareMajorLabel"
        Me.firmwareMajorLabel.Size = New System.Drawing.Size(81, 13)
        Me.firmwareMajorLabel.TabIndex = 10
        Me.firmwareMajorLabel.Text = "Firmware Major:"
        '
        'firmwareMonthLabel
        '
        Me.firmwareMonthLabel.AutoSize = True
        Me.firmwareMonthLabel.Location = New System.Drawing.Point(192, 234)
        Me.firmwareMonthLabel.Name = "firmwareMonthLabel"
        Me.firmwareMonthLabel.Size = New System.Drawing.Size(85, 13)
        Me.firmwareMonthLabel.TabIndex = 9
        Me.firmwareMonthLabel.Text = "Firmware Month:"
        '
        'cea2045VersionLabel
        '
        Me.cea2045VersionLabel.AutoSize = True
        Me.cea2045VersionLabel.Location = New System.Drawing.Point(18, 76)
        Me.cea2045VersionLabel.Name = "cea2045VersionLabel"
        Me.cea2045VersionLabel.Size = New System.Drawing.Size(96, 13)
        Me.cea2045VersionLabel.TabIndex = 2
        Me.cea2045VersionLabel.Text = "CEA-2045 Version:"
        '
        'firmwareDayLabel
        '
        Me.firmwareDayLabel.AutoSize = True
        Me.firmwareDayLabel.Location = New System.Drawing.Point(358, 234)
        Me.firmwareDayLabel.Name = "firmwareDayLabel"
        Me.firmwareDayLabel.Size = New System.Drawing.Size(74, 13)
        Me.firmwareDayLabel.TabIndex = 8
        Me.firmwareDayLabel.Text = "Firmware Day:"
        '
        'deviceRevisionLabel
        '
        Me.deviceRevisionLabel.AutoSize = True
        Me.deviceRevisionLabel.Location = New System.Drawing.Point(18, 45)
        Me.deviceRevisionLabel.Name = "deviceRevisionLabel"
        Me.deviceRevisionLabel.Size = New System.Drawing.Size(88, 13)
        Me.deviceRevisionLabel.TabIndex = 3
        Me.deviceRevisionLabel.Text = "Device Revision:"
        '
        'firmwareYearLabel
        '
        Me.firmwareYearLabel.AutoSize = True
        Me.firmwareYearLabel.Location = New System.Drawing.Point(18, 234)
        Me.firmwareYearLabel.Name = "firmwareYearLabel"
        Me.firmwareYearLabel.Size = New System.Drawing.Size(77, 13)
        Me.firmwareYearLabel.TabIndex = 7
        Me.firmwareYearLabel.Text = "Firmware Year:"
        '
        'serialNumberLabel
        '
        Me.serialNumberLabel.AutoSize = True
        Me.serialNumberLabel.Location = New System.Drawing.Point(18, 201)
        Me.serialNumberLabel.Name = "serialNumberLabel"
        Me.serialNumberLabel.Size = New System.Drawing.Size(76, 13)
        Me.serialNumberLabel.TabIndex = 6
        Me.serialNumberLabel.Text = "Serial Number:"
        '
        'modelNumberLabel
        '
        Me.modelNumberLabel.AutoSize = True
        Me.modelNumberLabel.Location = New System.Drawing.Point(18, 169)
        Me.modelNumberLabel.Name = "modelNumberLabel"
        Me.modelNumberLabel.Size = New System.Drawing.Size(79, 13)
        Me.modelNumberLabel.TabIndex = 5
        Me.modelNumberLabel.Text = "Model Number:"
        '
        'getDeviceInfo
        '
        Me.getDeviceInfo.Controls.Add(Me.otherDeviceFirmwareMinor)
        Me.getDeviceInfo.Controls.Add(Me.otherDeviceFirmwareMajor)
        Me.getDeviceInfo.Controls.Add(Me.otherDeviceFirmwareDate)
        Me.getDeviceInfo.Controls.Add(Me.otherDeviceModelNumber)
        Me.getDeviceInfo.Controls.Add(Me.otherDeviceCEA2045Version)
        Me.getDeviceInfo.Controls.Add(Me.otherDeviceVendorID)
        Me.getDeviceInfo.Controls.Add(Me.otherDeviceDeviceType)
        Me.getDeviceInfo.Controls.Add(Me.otherDeviceSerialNumber)
        Me.getDeviceInfo.Controls.Add(Me.otherDeviceDeviceRevision)
        Me.getDeviceInfo.Controls.Add(Me.Label19)
        Me.getDeviceInfo.Controls.Add(Me.otherDeviceCapabilityBitmap)
        Me.getDeviceInfo.Controls.Add(Me.Label13)
        Me.getDeviceInfo.Controls.Add(Me.Label15)
        Me.getDeviceInfo.Controls.Add(Me.Label16)
        Me.getDeviceInfo.Controls.Add(Me.Label17)
        Me.getDeviceInfo.Controls.Add(Me.Label18)
        Me.getDeviceInfo.Controls.Add(Me.Label20)
        Me.getDeviceInfo.Controls.Add(Me.Label22)
        Me.getDeviceInfo.Controls.Add(Me.Label23)
        Me.getDeviceInfo.Controls.Add(Me.Label24)
        Me.getDeviceInfo.Controls.Add(Me.Label25)
        Me.getDeviceInfo.Controls.Add(Me.queryDeviceInfoButton)
        Me.getDeviceInfo.Location = New System.Drawing.Point(4, 22)
        Me.getDeviceInfo.Name = "getDeviceInfo"
        Me.getDeviceInfo.Size = New System.Drawing.Size(623, 313)
        Me.getDeviceInfo.TabIndex = 6
        Me.getDeviceInfo.Text = "Get Device Info"
        Me.getDeviceInfo.UseVisualStyleBackColor = True
        '
        'otherDeviceFirmwareMinor
        '
        Me.otherDeviceFirmwareMinor.Location = New System.Drawing.Point(419, 218)
        Me.otherDeviceFirmwareMinor.Name = "otherDeviceFirmwareMinor"
        Me.otherDeviceFirmwareMinor.ReadOnly = True
        Me.otherDeviceFirmwareMinor.Size = New System.Drawing.Size(161, 20)
        Me.otherDeviceFirmwareMinor.TabIndex = 56
        '
        'otherDeviceFirmwareMajor
        '
        Me.otherDeviceFirmwareMajor.Location = New System.Drawing.Point(419, 190)
        Me.otherDeviceFirmwareMajor.Name = "otherDeviceFirmwareMajor"
        Me.otherDeviceFirmwareMajor.ReadOnly = True
        Me.otherDeviceFirmwareMajor.Size = New System.Drawing.Size(161, 20)
        Me.otherDeviceFirmwareMajor.TabIndex = 55
        '
        'otherDeviceFirmwareDate
        '
        Me.otherDeviceFirmwareDate.Location = New System.Drawing.Point(419, 160)
        Me.otherDeviceFirmwareDate.Name = "otherDeviceFirmwareDate"
        Me.otherDeviceFirmwareDate.ReadOnly = True
        Me.otherDeviceFirmwareDate.Size = New System.Drawing.Size(161, 20)
        Me.otherDeviceFirmwareDate.TabIndex = 54
        '
        'otherDeviceModelNumber
        '
        Me.otherDeviceModelNumber.Location = New System.Drawing.Point(419, 98)
        Me.otherDeviceModelNumber.Name = "otherDeviceModelNumber"
        Me.otherDeviceModelNumber.ReadOnly = True
        Me.otherDeviceModelNumber.Size = New System.Drawing.Size(161, 20)
        Me.otherDeviceModelNumber.TabIndex = 53
        '
        'otherDeviceCEA2045Version
        '
        Me.otherDeviceCEA2045Version.Location = New System.Drawing.Point(139, 98)
        Me.otherDeviceCEA2045Version.Name = "otherDeviceCEA2045Version"
        Me.otherDeviceCEA2045Version.ReadOnly = True
        Me.otherDeviceCEA2045Version.Size = New System.Drawing.Size(163, 20)
        Me.otherDeviceCEA2045Version.TabIndex = 52
        '
        'otherDeviceVendorID
        '
        Me.otherDeviceVendorID.Location = New System.Drawing.Point(139, 129)
        Me.otherDeviceVendorID.Name = "otherDeviceVendorID"
        Me.otherDeviceVendorID.ReadOnly = True
        Me.otherDeviceVendorID.Size = New System.Drawing.Size(163, 20)
        Me.otherDeviceVendorID.TabIndex = 51
        '
        'otherDeviceDeviceType
        '
        Me.otherDeviceDeviceType.Location = New System.Drawing.Point(139, 160)
        Me.otherDeviceDeviceType.Name = "otherDeviceDeviceType"
        Me.otherDeviceDeviceType.ReadOnly = True
        Me.otherDeviceDeviceType.Size = New System.Drawing.Size(163, 20)
        Me.otherDeviceDeviceType.TabIndex = 50
        '
        'otherDeviceSerialNumber
        '
        Me.otherDeviceSerialNumber.Location = New System.Drawing.Point(419, 129)
        Me.otherDeviceSerialNumber.Name = "otherDeviceSerialNumber"
        Me.otherDeviceSerialNumber.ReadOnly = True
        Me.otherDeviceSerialNumber.Size = New System.Drawing.Size(161, 20)
        Me.otherDeviceSerialNumber.TabIndex = 49
        '
        'otherDeviceDeviceRevision
        '
        Me.otherDeviceDeviceRevision.Location = New System.Drawing.Point(139, 190)
        Me.otherDeviceDeviceRevision.Name = "otherDeviceDeviceRevision"
        Me.otherDeviceDeviceRevision.ReadOnly = True
        Me.otherDeviceDeviceRevision.Size = New System.Drawing.Size(163, 20)
        Me.otherDeviceDeviceRevision.TabIndex = 48
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(43, 67)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(126, 18)
        Me.Label19.TabIndex = 47
        Me.Label19.Text = "Other Device Info:"
        '
        'otherDeviceCapabilityBitmap
        '
        Me.otherDeviceCapabilityBitmap.Location = New System.Drawing.Point(139, 218)
        Me.otherDeviceCapabilityBitmap.Name = "otherDeviceCapabilityBitmap"
        Me.otherDeviceCapabilityBitmap.ReadOnly = True
        Me.otherDeviceCapabilityBitmap.Size = New System.Drawing.Size(163, 20)
        Me.otherDeviceCapabilityBitmap.TabIndex = 46
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(43, 163)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "Device Type:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(43, 221)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 13)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Capability Bitmap:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(334, 221)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 13)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Firmware Minor:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(43, 132)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 13)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "Vendor ID:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(334, 193)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 13)
        Me.Label18.TabIndex = 44
        Me.Label18.Text = "Firmware Major:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(43, 101)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 13)
        Me.Label20.TabIndex = 38
        Me.Label20.Text = "CEA-2045 Version:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(43, 193)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(88, 13)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "Device Revision:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(334, 162)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(78, 13)
        Me.Label23.TabIndex = 43
        Me.Label23.Text = "Firmware Date:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(334, 132)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(76, 13)
        Me.Label24.TabIndex = 42
        Me.Label24.Text = "Serial Number:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(334, 101)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(79, 13)
        Me.Label25.TabIndex = 41
        Me.Label25.Text = "Model Number:"
        '
        'queryDeviceInfoButton
        '
        Me.queryDeviceInfoButton.Location = New System.Drawing.Point(46, 32)
        Me.queryDeviceInfoButton.Name = "queryDeviceInfoButton"
        Me.queryDeviceInfoButton.Size = New System.Drawing.Size(123, 23)
        Me.queryDeviceInfoButton.TabIndex = 35
        Me.queryDeviceInfoButton.Text = "Query Other Device"
        Me.queryDeviceInfoButton.UseVisualStyleBackColor = True
        '
        'msgTypeSupportedTab
        '
        Me.msgTypeSupportedTab.Controls.Add(Me.msgSupportQuery)
        Me.msgTypeSupportedTab.Controls.Add(Me.msgSupportedBox)
        Me.msgTypeSupportedTab.Location = New System.Drawing.Point(4, 22)
        Me.msgTypeSupportedTab.Name = "msgTypeSupportedTab"
        Me.msgTypeSupportedTab.Padding = New System.Windows.Forms.Padding(3)
        Me.msgTypeSupportedTab.Size = New System.Drawing.Size(623, 313)
        Me.msgTypeSupportedTab.TabIndex = 1
        Me.msgTypeSupportedTab.Text = "Msg Types Supported"
        Me.msgTypeSupportedTab.UseVisualStyleBackColor = True
        '
        'msgSupportQuery
        '
        Me.msgSupportQuery.Controls.Add(Me.Label56)
        Me.msgSupportQuery.Controls.Add(Me.ODRefresh)
        Me.msgSupportQuery.Controls.Add(Me.ODMsgTypeSup)
        Me.msgSupportQuery.Controls.Add(Me.nudSupMsgQueryLSB)
        Me.msgSupportQuery.Controls.Add(Me.nudSupMsgQueryMSB)
        Me.msgSupportQuery.Controls.Add(Me.typeSupportedQueryCodeLookup)
        Me.msgSupportQuery.Controls.Add(Me.Label5)
        Me.msgSupportQuery.Controls.Add(Me.Label4)
        Me.msgSupportQuery.Controls.Add(Me.msgTypeQuery)
        Me.msgSupportQuery.Location = New System.Drawing.Point(7, 168)
        Me.msgSupportQuery.Name = "msgSupportQuery"
        Me.msgSupportQuery.Size = New System.Drawing.Size(411, 132)
        Me.msgSupportQuery.TabIndex = 33
        Me.msgSupportQuery.TabStop = False
        Me.msgSupportQuery.Text = "Supported Message Query"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(244, 10)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(70, 13)
        Me.Label56.TabIndex = 16
        Me.Label56.Text = "Other Device"
        '
        'ODRefresh
        '
        Me.ODRefresh.Location = New System.Drawing.Point(136, 47)
        Me.ODRefresh.Name = "ODRefresh"
        Me.ODRefresh.Size = New System.Drawing.Size(87, 23)
        Me.ODRefresh.TabIndex = 15
        Me.ODRefresh.Text = "Refresh"
        Me.ODRefresh.UseVisualStyleBackColor = True
        '
        'ODMsgTypeSup
        '
        Me.ODMsgTypeSup.FormattingEnabled = True
        Me.ODMsgTypeSup.Location = New System.Drawing.Point(247, 29)
        Me.ODMsgTypeSup.Name = "ODMsgTypeSup"
        Me.ODMsgTypeSup.Size = New System.Drawing.Size(148, 95)
        Me.ODMsgTypeSup.TabIndex = 14
        '
        'nudSupMsgQueryLSB
        '
        Me.nudSupMsgQueryLSB.Hexadecimal = True
        Me.nudSupMsgQueryLSB.Location = New System.Drawing.Point(104, 100)
        Me.nudSupMsgQueryLSB.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudSupMsgQueryLSB.Name = "nudSupMsgQueryLSB"
        Me.nudSupMsgQueryLSB.Size = New System.Drawing.Size(75, 20)
        Me.nudSupMsgQueryLSB.TabIndex = 13
        '
        'nudSupMsgQueryMSB
        '
        Me.nudSupMsgQueryMSB.Hexadecimal = True
        Me.nudSupMsgQueryMSB.Location = New System.Drawing.Point(15, 100)
        Me.nudSupMsgQueryMSB.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudSupMsgQueryMSB.Name = "nudSupMsgQueryMSB"
        Me.nudSupMsgQueryMSB.Size = New System.Drawing.Size(75, 20)
        Me.nudSupMsgQueryMSB.TabIndex = 12
        '
        'typeSupportedQueryCodeLookup
        '
        Me.typeSupportedQueryCodeLookup.Location = New System.Drawing.Point(17, 46)
        Me.typeSupportedQueryCodeLookup.Name = "typeSupportedQueryCodeLookup"
        Me.typeSupportedQueryCodeLookup.Size = New System.Drawing.Size(87, 23)
        Me.typeSupportedQueryCodeLookup.TabIndex = 5
        Me.typeSupportedQueryCodeLookup.Text = "Code Lookup"
        Me.typeSupportedQueryCodeLookup.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(107, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "LSB in Hex"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "MSB in Hex"
        '
        'msgTypeQuery
        '
        Me.msgTypeQuery.Location = New System.Drawing.Point(17, 19)
        Me.msgTypeQuery.Name = "msgTypeQuery"
        Me.msgTypeQuery.Size = New System.Drawing.Size(87, 24)
        Me.msgTypeQuery.TabIndex = 0
        Me.msgTypeQuery.Text = "Send Query"
        Me.msgTypeQuery.UseVisualStyleBackColor = True
        '
        'msgSupportedBox
        '
        Me.msgSupportedBox.Controls.Add(Me.nudMsgSuppLSB)
        Me.msgSupportedBox.Controls.Add(Me.nudMsgSuppMSB)
        Me.msgSupportedBox.Controls.Add(Me.Label7)
        Me.msgSupportedBox.Controls.Add(Me.Label6)
        Me.msgSupportedBox.Controls.Add(Me.supportedMsgTypeList)
        Me.msgSupportedBox.Controls.Add(Me.removeSupportedType)
        Me.msgSupportedBox.Controls.Add(Me.addSupportedType)
        Me.msgSupportedBox.Location = New System.Drawing.Point(6, 31)
        Me.msgSupportedBox.Name = "msgSupportedBox"
        Me.msgSupportedBox.Size = New System.Drawing.Size(411, 116)
        Me.msgSupportedBox.TabIndex = 31
        Me.msgSupportedBox.TabStop = False
        Me.msgSupportedBox.Text = "Messages Supported by This Device"
        '
        'nudMsgSuppLSB
        '
        Me.nudMsgSuppLSB.Hexadecimal = True
        Me.nudMsgSuppLSB.Location = New System.Drawing.Point(106, 39)
        Me.nudMsgSuppLSB.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudMsgSuppLSB.Name = "nudMsgSuppLSB"
        Me.nudMsgSuppLSB.Size = New System.Drawing.Size(75, 20)
        Me.nudMsgSuppLSB.TabIndex = 15
        '
        'nudMsgSuppMSB
        '
        Me.nudMsgSuppMSB.Hexadecimal = True
        Me.nudMsgSuppMSB.Location = New System.Drawing.Point(17, 38)
        Me.nudMsgSuppMSB.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudMsgSuppMSB.Name = "nudMsgSuppMSB"
        Me.nudMsgSuppMSB.Size = New System.Drawing.Size(75, 20)
        Me.nudMsgSuppMSB.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(109, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "LSB in Hex"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "MSB in Hex"
        '
        'supportedMsgTypeList
        '
        Me.supportedMsgTypeList.FormattingEnabled = True
        Me.supportedMsgTypeList.Location = New System.Drawing.Point(292, 22)
        Me.supportedMsgTypeList.Name = "supportedMsgTypeList"
        Me.supportedMsgTypeList.Size = New System.Drawing.Size(111, 82)
        Me.supportedMsgTypeList.TabIndex = 3
        '
        'removeSupportedType
        '
        Me.removeSupportedType.Location = New System.Drawing.Point(206, 66)
        Me.removeSupportedType.Name = "removeSupportedType"
        Me.removeSupportedType.Size = New System.Drawing.Size(75, 23)
        Me.removeSupportedType.TabIndex = 2
        Me.removeSupportedType.Text = "Remove Selected"
        Me.removeSupportedType.UseVisualStyleBackColor = True
        '
        'addSupportedType
        '
        Me.addSupportedType.Location = New System.Drawing.Point(206, 26)
        Me.addSupportedType.Name = "addSupportedType"
        Me.addSupportedType.Size = New System.Drawing.Size(75, 23)
        Me.addSupportedType.TabIndex = 1
        Me.addSupportedType.Text = "Add"
        Me.addSupportedType.UseVisualStyleBackColor = True
        '
        'setMaxPayloadTab
        '
        Me.setMaxPayloadTab.Controls.Add(Me.GroupBox3)
        Me.setMaxPayloadTab.Controls.Add(Me.GroupBox1)
        Me.setMaxPayloadTab.Location = New System.Drawing.Point(4, 22)
        Me.setMaxPayloadTab.Name = "setMaxPayloadTab"
        Me.setMaxPayloadTab.Size = New System.Drawing.Size(623, 313)
        Me.setMaxPayloadTab.TabIndex = 2
        Me.setMaxPayloadTab.Text = "Max Payload"
        Me.setMaxPayloadTab.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.Label57)
        Me.GroupBox3.Controls.Add(Me.btnMaxPayload)
        Me.GroupBox3.Controls.Add(Me.cdMaxPayloadSize)
        Me.GroupBox3.Location = New System.Drawing.Point(364, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(241, 116)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Connected Device"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(81, 34)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(154, 13)
        Me.Label27.TabIndex = 17
        Me.Label27.Text = "Request maximum payload size"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(81, 76)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(91, 13)
        Me.Label57.TabIndex = 19
        Me.Label57.Text = "Max Payload Size"
        '
        'btnMaxPayload
        '
        Me.btnMaxPayload.Location = New System.Drawing.Point(21, 31)
        Me.btnMaxPayload.Name = "btnMaxPayload"
        Me.btnMaxPayload.Size = New System.Drawing.Size(54, 23)
        Me.btnMaxPayload.TabIndex = 16
        Me.btnMaxPayload.Text = "Query"
        Me.btnMaxPayload.UseVisualStyleBackColor = True
        '
        'cdMaxPayloadSize
        '
        Me.cdMaxPayloadSize.Enabled = False
        Me.cdMaxPayloadSize.Location = New System.Drawing.Point(21, 72)
        Me.cdMaxPayloadSize.Name = "cdMaxPayloadSize"
        Me.cdMaxPayloadSize.Size = New System.Drawing.Size(54, 20)
        Me.cdMaxPayloadSize.TabIndex = 18
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload1)
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload14)
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload2)
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload13)
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload3)
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload12)
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload4)
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload11)
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload5)
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload10)
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload6)
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload9)
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload7)
        Me.GroupBox1.Controls.Add(Me.rbMaxPayload8)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(313, 189)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select This Device Maximum Payload Size"
        '
        'rbMaxPayload1
        '
        Me.rbMaxPayload1.AutoSize = True
        Me.rbMaxPayload1.Location = New System.Drawing.Point(20, 19)
        Me.rbMaxPayload1.Name = "rbMaxPayload1"
        Me.rbMaxPayload1.Size = New System.Drawing.Size(100, 17)
        Me.rbMaxPayload1.TabIndex = 1
        Me.rbMaxPayload1.TabStop = True
        Me.rbMaxPayload1.Text = "2 bytes (default)"
        Me.rbMaxPayload1.UseVisualStyleBackColor = True
        '
        'rbMaxPayload14
        '
        Me.rbMaxPayload14.AutoSize = True
        Me.rbMaxPayload14.Location = New System.Drawing.Point(178, 159)
        Me.rbMaxPayload14.Name = "rbMaxPayload14"
        Me.rbMaxPayload14.Size = New System.Drawing.Size(77, 17)
        Me.rbMaxPayload14.TabIndex = 14
        Me.rbMaxPayload14.TabStop = True
        Me.rbMaxPayload14.Text = "4096 bytes"
        Me.rbMaxPayload14.UseVisualStyleBackColor = True
        '
        'rbMaxPayload2
        '
        Me.rbMaxPayload2.AutoSize = True
        Me.rbMaxPayload2.Location = New System.Drawing.Point(20, 43)
        Me.rbMaxPayload2.Name = "rbMaxPayload2"
        Me.rbMaxPayload2.Size = New System.Drawing.Size(59, 17)
        Me.rbMaxPayload2.TabIndex = 2
        Me.rbMaxPayload2.TabStop = True
        Me.rbMaxPayload2.Text = "4 bytes"
        Me.rbMaxPayload2.UseVisualStyleBackColor = True
        '
        'rbMaxPayload13
        '
        Me.rbMaxPayload13.AutoSize = True
        Me.rbMaxPayload13.Location = New System.Drawing.Point(178, 136)
        Me.rbMaxPayload13.Name = "rbMaxPayload13"
        Me.rbMaxPayload13.Size = New System.Drawing.Size(77, 17)
        Me.rbMaxPayload13.TabIndex = 13
        Me.rbMaxPayload13.TabStop = True
        Me.rbMaxPayload13.Text = "2048 bytes"
        Me.rbMaxPayload13.UseVisualStyleBackColor = True
        '
        'rbMaxPayload3
        '
        Me.rbMaxPayload3.AutoSize = True
        Me.rbMaxPayload3.Location = New System.Drawing.Point(20, 67)
        Me.rbMaxPayload3.Name = "rbMaxPayload3"
        Me.rbMaxPayload3.Size = New System.Drawing.Size(59, 17)
        Me.rbMaxPayload3.TabIndex = 3
        Me.rbMaxPayload3.TabStop = True
        Me.rbMaxPayload3.Text = "8 bytes"
        Me.rbMaxPayload3.UseVisualStyleBackColor = True
        '
        'rbMaxPayload12
        '
        Me.rbMaxPayload12.AutoSize = True
        Me.rbMaxPayload12.Location = New System.Drawing.Point(178, 113)
        Me.rbMaxPayload12.Name = "rbMaxPayload12"
        Me.rbMaxPayload12.Size = New System.Drawing.Size(77, 17)
        Me.rbMaxPayload12.TabIndex = 12
        Me.rbMaxPayload12.TabStop = True
        Me.rbMaxPayload12.Text = "1500 bytes"
        Me.rbMaxPayload12.UseVisualStyleBackColor = True
        '
        'rbMaxPayload4
        '
        Me.rbMaxPayload4.AutoSize = True
        Me.rbMaxPayload4.Location = New System.Drawing.Point(20, 90)
        Me.rbMaxPayload4.Name = "rbMaxPayload4"
        Me.rbMaxPayload4.Size = New System.Drawing.Size(65, 17)
        Me.rbMaxPayload4.TabIndex = 4
        Me.rbMaxPayload4.TabStop = True
        Me.rbMaxPayload4.Text = "16 bytes"
        Me.rbMaxPayload4.UseVisualStyleBackColor = True
        '
        'rbMaxPayload11
        '
        Me.rbMaxPayload11.AutoSize = True
        Me.rbMaxPayload11.Location = New System.Drawing.Point(178, 90)
        Me.rbMaxPayload11.Name = "rbMaxPayload11"
        Me.rbMaxPayload11.Size = New System.Drawing.Size(77, 17)
        Me.rbMaxPayload11.TabIndex = 11
        Me.rbMaxPayload11.TabStop = True
        Me.rbMaxPayload11.Text = "1280 bytes"
        Me.rbMaxPayload11.UseVisualStyleBackColor = True
        '
        'rbMaxPayload5
        '
        Me.rbMaxPayload5.AutoSize = True
        Me.rbMaxPayload5.Location = New System.Drawing.Point(20, 113)
        Me.rbMaxPayload5.Name = "rbMaxPayload5"
        Me.rbMaxPayload5.Size = New System.Drawing.Size(65, 17)
        Me.rbMaxPayload5.TabIndex = 5
        Me.rbMaxPayload5.TabStop = True
        Me.rbMaxPayload5.Text = "32 bytes"
        Me.rbMaxPayload5.UseVisualStyleBackColor = True
        '
        'rbMaxPayload10
        '
        Me.rbMaxPayload10.AutoSize = True
        Me.rbMaxPayload10.Location = New System.Drawing.Point(178, 67)
        Me.rbMaxPayload10.Name = "rbMaxPayload10"
        Me.rbMaxPayload10.Size = New System.Drawing.Size(77, 17)
        Me.rbMaxPayload10.TabIndex = 10
        Me.rbMaxPayload10.TabStop = True
        Me.rbMaxPayload10.Text = "1024 bytes"
        Me.rbMaxPayload10.UseVisualStyleBackColor = True
        '
        'rbMaxPayload6
        '
        Me.rbMaxPayload6.AutoSize = True
        Me.rbMaxPayload6.Location = New System.Drawing.Point(20, 136)
        Me.rbMaxPayload6.Name = "rbMaxPayload6"
        Me.rbMaxPayload6.Size = New System.Drawing.Size(65, 17)
        Me.rbMaxPayload6.TabIndex = 6
        Me.rbMaxPayload6.TabStop = True
        Me.rbMaxPayload6.Text = "64 bytes"
        Me.rbMaxPayload6.UseVisualStyleBackColor = True
        '
        'rbMaxPayload9
        '
        Me.rbMaxPayload9.AutoSize = True
        Me.rbMaxPayload9.Location = New System.Drawing.Point(178, 43)
        Me.rbMaxPayload9.Name = "rbMaxPayload9"
        Me.rbMaxPayload9.Size = New System.Drawing.Size(71, 17)
        Me.rbMaxPayload9.TabIndex = 9
        Me.rbMaxPayload9.TabStop = True
        Me.rbMaxPayload9.Text = "512 bytes"
        Me.rbMaxPayload9.UseVisualStyleBackColor = True
        '
        'rbMaxPayload7
        '
        Me.rbMaxPayload7.AutoSize = True
        Me.rbMaxPayload7.Location = New System.Drawing.Point(20, 159)
        Me.rbMaxPayload7.Name = "rbMaxPayload7"
        Me.rbMaxPayload7.Size = New System.Drawing.Size(71, 17)
        Me.rbMaxPayload7.TabIndex = 7
        Me.rbMaxPayload7.TabStop = True
        Me.rbMaxPayload7.Text = "128 bytes"
        Me.rbMaxPayload7.UseVisualStyleBackColor = True
        '
        'rbMaxPayload8
        '
        Me.rbMaxPayload8.AutoSize = True
        Me.rbMaxPayload8.Location = New System.Drawing.Point(178, 19)
        Me.rbMaxPayload8.Name = "rbMaxPayload8"
        Me.rbMaxPayload8.Size = New System.Drawing.Size(71, 17)
        Me.rbMaxPayload8.TabIndex = 8
        Me.rbMaxPayload8.TabStop = True
        Me.rbMaxPayload8.Text = "256 bytes"
        Me.rbMaxPayload8.UseVisualStyleBackColor = True
        '
        'tempF
        '
        Me.tempF.Controls.Add(Me.GroupBox4)
        Me.tempF.Controls.Add(Me.GroupBox7)
        Me.tempF.Controls.Add(Me.GroupBox6)
        Me.tempF.Controls.Add(Me.GroupBox5)
        Me.tempF.Location = New System.Drawing.Point(4, 22)
        Me.tempF.Name = "tempF"
        Me.tempF.Padding = New System.Windows.Forms.Padding(3)
        Me.tempF.Size = New System.Drawing.Size(623, 313)
        Me.tempF.TabIndex = 3
        Me.tempF.Text = "Temp Get/Set"
        Me.tempF.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label104)
        Me.GroupBox4.Controls.Add(Me.Label103)
        Me.GroupBox4.Controls.Add(Me.Label102)
        Me.GroupBox4.Controls.Add(Me.pbGetPresentTemp)
        Me.GroupBox4.Controls.Add(Me.Label101)
        Me.GroupBox4.Controls.Add(Me.nudPresentTemp)
        Me.GroupBox4.Controls.Add(Me.tbResponseCode2)
        Me.GroupBox4.Controls.Add(Me.tbPresentTemp)
        Me.GroupBox4.Location = New System.Drawing.Point(411, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(206, 148)
        Me.GroupBox4.TabIndex = 45
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Get Present Temp"
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.Location = New System.Drawing.Point(59, 73)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(34, 13)
        Me.Label104.TabIndex = 46
        Me.Label104.Text = "Temp"
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.Location = New System.Drawing.Point(97, 48)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(96, 13)
        Me.Label103.TabIndex = 45
        Me.Label103.Text = "Connected Device"
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.Location = New System.Drawing.Point(4, 48)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(64, 13)
        Me.Label102.TabIndex = 44
        Me.Label102.Text = "This Device"
        '
        'pbGetPresentTemp
        '
        Me.pbGetPresentTemp.Location = New System.Drawing.Point(79, 21)
        Me.pbGetPresentTemp.Name = "pbGetPresentTemp"
        Me.pbGetPresentTemp.Size = New System.Drawing.Size(118, 24)
        Me.pbGetPresentTemp.TabIndex = 5
        Me.pbGetPresentTemp.Text = "Get Present Temp"
        Me.pbGetPresentTemp.UseVisualStyleBackColor = True
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.Location = New System.Drawing.Point(99, 106)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(83, 13)
        Me.Label101.TabIndex = 42
        Me.Label101.Text = "Response Code"
        '
        'nudPresentTemp
        '
        Me.nudPresentTemp.Location = New System.Drawing.Point(7, 70)
        Me.nudPresentTemp.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudPresentTemp.Name = "nudPresentTemp"
        Me.nudPresentTemp.Size = New System.Drawing.Size(49, 20)
        Me.nudPresentTemp.TabIndex = 6
        Me.nudPresentTemp.Value = New Decimal(New Integer() {70, 0, 0, 0})
        '
        'tbResponseCode2
        '
        Me.tbResponseCode2.Location = New System.Drawing.Point(94, 122)
        Me.tbResponseCode2.Name = "tbResponseCode2"
        Me.tbResponseCode2.ReadOnly = True
        Me.tbResponseCode2.Size = New System.Drawing.Size(104, 20)
        Me.tbResponseCode2.TabIndex = 43
        '
        'tbPresentTemp
        '
        Me.tbPresentTemp.Location = New System.Drawing.Point(94, 70)
        Me.tbPresentTemp.Name = "tbPresentTemp"
        Me.tbPresentTemp.ReadOnly = True
        Me.tbPresentTemp.Size = New System.Drawing.Size(105, 20)
        Me.tbPresentTemp.TabIndex = 41
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label94)
        Me.GroupBox7.Controls.Add(Me.Label33)
        Me.GroupBox7.Controls.Add(Me.tmpUnitF)
        Me.GroupBox7.Controls.Add(Me.tempUnitC)
        Me.GroupBox7.Controls.Add(Me.tbSgdDeviceType)
        Me.GroupBox7.Controls.Add(Me.sgdTempUnits)
        Me.GroupBox7.Controls.Add(Me.Label40)
        Me.GroupBox7.Controls.Add(Me.nudSetpointDeviceType)
        Me.GroupBox7.Controls.Add(Me.Label93)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 205)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(611, 105)
        Me.GroupBox7.TabIndex = 36
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Common"
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Location = New System.Drawing.Point(187, 17)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(96, 13)
        Me.Label94.TabIndex = 33
        Me.Label94.Text = "Connected Device"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(6, 17)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(64, 13)
        Me.Label33.TabIndex = 2
        Me.Label33.Text = "This Device"
        '
        'tmpUnitF
        '
        Me.tmpUnitF.AutoSize = True
        Me.tmpUnitF.Checked = True
        Me.tmpUnitF.Location = New System.Drawing.Point(9, 33)
        Me.tmpUnitF.Name = "tmpUnitF"
        Me.tmpUnitF.Size = New System.Drawing.Size(75, 17)
        Me.tmpUnitF.TabIndex = 0
        Me.tmpUnitF.TabStop = True
        Me.tmpUnitF.Text = "Fahrenheit"
        Me.tmpUnitF.UseVisualStyleBackColor = True
        '
        'tempUnitC
        '
        Me.tempUnitC.AutoSize = True
        Me.tempUnitC.Location = New System.Drawing.Point(9, 56)
        Me.tempUnitC.Name = "tempUnitC"
        Me.tempUnitC.Size = New System.Drawing.Size(58, 17)
        Me.tempUnitC.TabIndex = 1
        Me.tempUnitC.Text = "Celsius"
        Me.tempUnitC.UseVisualStyleBackColor = True
        '
        'tbSgdDeviceType
        '
        Me.tbSgdDeviceType.Location = New System.Drawing.Point(190, 79)
        Me.tbSgdDeviceType.Name = "tbSgdDeviceType"
        Me.tbSgdDeviceType.ReadOnly = True
        Me.tbSgdDeviceType.Size = New System.Drawing.Size(79, 20)
        Me.tbSgdDeviceType.TabIndex = 32
        '
        'sgdTempUnits
        '
        Me.sgdTempUnits.Location = New System.Drawing.Point(190, 46)
        Me.sgdTempUnits.Name = "sgdTempUnits"
        Me.sgdTempUnits.ReadOnly = True
        Me.sgdTempUnits.Size = New System.Drawing.Size(79, 20)
        Me.sgdTempUnits.TabIndex = 17
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(113, 50)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(31, 13)
        Me.Label40.TabIndex = 15
        Me.Label40.Text = "Units"
        '
        'nudSetpointDeviceType
        '
        Me.nudSetpointDeviceType.Hexadecimal = True
        Me.nudSetpointDeviceType.Location = New System.Drawing.Point(8, 79)
        Me.nudSetpointDeviceType.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudSetpointDeviceType.Name = "nudSetpointDeviceType"
        Me.nudSetpointDeviceType.Size = New System.Drawing.Size(76, 20)
        Me.nudSetpointDeviceType.TabIndex = 31
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Location = New System.Drawing.Point(89, 83)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(96, 13)
        Me.Label93.TabIndex = 28
        Me.Label93.Text = "Device Type (Hex)"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.pbSetTempOffset)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.Label90)
        Me.GroupBox6.Controls.Add(Me.nudTempOffset)
        Me.GroupBox6.Controls.Add(Me.sgdTempRespCode)
        Me.GroupBox6.Controls.Add(Me.pbRequestTempOffset)
        Me.GroupBox6.Controls.Add(Me.sgdCurrentTempOffset)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(197, 148)
        Me.GroupBox6.TabIndex = 35
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Offset"
        '
        'pbSetTempOffset
        '
        Me.pbSetTempOffset.Location = New System.Drawing.Point(6, 19)
        Me.pbSetTempOffset.Name = "pbSetTempOffset"
        Me.pbSetTempOffset.Size = New System.Drawing.Size(75, 24)
        Me.pbSetTempOffset.TabIndex = 13
        Me.pbSetTempOffset.Text = "Set Offset"
        Me.pbSetTempOffset.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(61, 53)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(72, 13)
        Me.Label36.TabIndex = 3
        Me.Label36.Text = "Current Offset"
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Location = New System.Drawing.Point(103, 102)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(83, 13)
        Me.Label90.TabIndex = 19
        Me.Label90.Text = "Response Code"
        '
        'nudTempOffset
        '
        Me.nudTempOffset.Location = New System.Drawing.Point(6, 68)
        Me.nudTempOffset.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudTempOffset.Name = "nudTempOffset"
        Me.nudTempOffset.Size = New System.Drawing.Size(75, 20)
        Me.nudTempOffset.TabIndex = 11
        '
        'sgdTempRespCode
        '
        Me.sgdTempRespCode.Location = New System.Drawing.Point(109, 118)
        Me.sgdTempRespCode.Name = "sgdTempRespCode"
        Me.sgdTempRespCode.ReadOnly = True
        Me.sgdTempRespCode.Size = New System.Drawing.Size(75, 20)
        Me.sgdTempRespCode.TabIndex = 18
        '
        'pbRequestTempOffset
        '
        Me.pbRequestTempOffset.Location = New System.Drawing.Point(109, 19)
        Me.pbRequestTempOffset.Name = "pbRequestTempOffset"
        Me.pbRequestTempOffset.Size = New System.Drawing.Size(75, 24)
        Me.pbRequestTempOffset.TabIndex = 12
        Me.pbRequestTempOffset.Text = "Get Offset"
        Me.pbRequestTempOffset.UseVisualStyleBackColor = True
        '
        'sgdCurrentTempOffset
        '
        Me.sgdCurrentTempOffset.Location = New System.Drawing.Point(109, 67)
        Me.sgdCurrentTempOffset.Name = "sgdCurrentTempOffset"
        Me.sgdCurrentTempOffset.ReadOnly = True
        Me.sgdCurrentTempOffset.Size = New System.Drawing.Size(75, 20)
        Me.sgdCurrentTempOffset.TabIndex = 16
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.pbSetSetPoint)
        Me.GroupBox5.Controls.Add(Me.tbSetpointResponseCode)
        Me.GroupBox5.Controls.Add(Me.Label39)
        Me.GroupBox5.Controls.Add(Me.pbRequestSetpoint)
        Me.GroupBox5.Controls.Add(Me.nudSetPoint1)
        Me.GroupBox5.Controls.Add(Me.cbSetpoint2Support)
        Me.GroupBox5.Controls.Add(Me.nudSetPoint2)
        Me.GroupBox5.Controls.Add(Me.sgdSetPoint1)
        Me.GroupBox5.Controls.Add(Me.Label92)
        Me.GroupBox5.Controls.Add(Me.sgdSetPoint2)
        Me.GroupBox5.Controls.Add(Me.Label91)
        Me.GroupBox5.Location = New System.Drawing.Point(212, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(189, 198)
        Me.GroupBox5.TabIndex = 34
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Setpoint"
        '
        'pbSetSetPoint
        '
        Me.pbSetSetPoint.Location = New System.Drawing.Point(8, 24)
        Me.pbSetSetPoint.Name = "pbSetSetPoint"
        Me.pbSetSetPoint.Size = New System.Drawing.Size(76, 24)
        Me.pbSetSetPoint.TabIndex = 20
        Me.pbSetSetPoint.Text = "Set Setpoint"
        Me.pbSetSetPoint.UseVisualStyleBackColor = True
        '
        'tbSetpointResponseCode
        '
        Me.tbSetpointResponseCode.Location = New System.Drawing.Point(101, 173)
        Me.tbSetpointResponseCode.Name = "tbSetpointResponseCode"
        Me.tbSetpointResponseCode.ReadOnly = True
        Me.tbSetpointResponseCode.Size = New System.Drawing.Size(79, 20)
        Me.tbSetpointResponseCode.TabIndex = 33
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(99, 157)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(83, 13)
        Me.Label39.TabIndex = 14
        Me.Label39.Text = "Response Code"
        '
        'pbRequestSetpoint
        '
        Me.pbRequestSetpoint.Location = New System.Drawing.Point(102, 24)
        Me.pbRequestSetpoint.Name = "pbRequestSetpoint"
        Me.pbRequestSetpoint.Size = New System.Drawing.Size(78, 24)
        Me.pbRequestSetpoint.TabIndex = 21
        Me.pbRequestSetpoint.Text = "Get Setpoint"
        Me.pbRequestSetpoint.UseVisualStyleBackColor = True
        '
        'nudSetPoint1
        '
        Me.nudSetPoint1.Location = New System.Drawing.Point(8, 71)
        Me.nudSetPoint1.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
        Me.nudSetPoint1.Minimum = New Decimal(New Integer() {32768, 0, 0, -2147483648})
        Me.nudSetPoint1.Name = "nudSetPoint1"
        Me.nudSetPoint1.Size = New System.Drawing.Size(76, 20)
        Me.nudSetPoint1.TabIndex = 22
        '
        'cbSetpoint2Support
        '
        Me.cbSetpoint2Support.AutoSize = True
        Me.cbSetpoint2Support.Location = New System.Drawing.Point(9, 102)
        Me.cbSetpoint2Support.Name = "cbSetpoint2Support"
        Me.cbSetpoint2Support.Size = New System.Drawing.Size(75, 17)
        Me.cbSetpoint2Support.TabIndex = 30
        Me.cbSetpoint2Support.Text = "Supported"
        Me.cbSetpoint2Support.UseVisualStyleBackColor = True
        '
        'nudSetPoint2
        '
        Me.nudSetPoint2.Location = New System.Drawing.Point(8, 122)
        Me.nudSetPoint2.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
        Me.nudSetPoint2.Minimum = New Decimal(New Integer() {32768, 0, 0, -2147483648})
        Me.nudSetPoint2.Name = "nudSetPoint2"
        Me.nudSetPoint2.Size = New System.Drawing.Size(76, 20)
        Me.nudSetPoint2.TabIndex = 23
        '
        'sgdSetPoint1
        '
        Me.sgdSetPoint1.Location = New System.Drawing.Point(102, 71)
        Me.sgdSetPoint1.Name = "sgdSetPoint1"
        Me.sgdSetPoint1.ReadOnly = True
        Me.sgdSetPoint1.Size = New System.Drawing.Size(77, 20)
        Me.sgdSetPoint1.TabIndex = 24
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Location = New System.Drawing.Point(90, 103)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(52, 13)
        Me.Label92.TabIndex = 27
        Me.Label92.Text = "Setpoint2"
        '
        'sgdSetPoint2
        '
        Me.sgdSetPoint2.Location = New System.Drawing.Point(100, 121)
        Me.sgdSetPoint2.Name = "sgdSetPoint2"
        Me.sgdSetPoint2.ReadOnly = True
        Me.sgdSetPoint2.Size = New System.Drawing.Size(79, 20)
        Me.sgdSetPoint2.TabIndex = 25
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Location = New System.Drawing.Point(69, 55)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(52, 13)
        Me.Label91.TabIndex = 26
        Me.Label91.Text = "Setpoint1"
        '
        'commodity
        '
        Me.commodity.Controls.Add(Me.cdCommodityGb)
        Me.commodity.Controls.Add(Me.tdCommodityCodes)
        Me.commodity.Location = New System.Drawing.Point(4, 22)
        Me.commodity.Name = "commodity"
        Me.commodity.Size = New System.Drawing.Size(623, 313)
        Me.commodity.TabIndex = 4
        Me.commodity.Text = "Commodity"
        Me.commodity.UseVisualStyleBackColor = True
        '
        'cdCommodityGb
        '
        Me.cdCommodityGb.Controls.Add(Me.pbGetCommodity)
        Me.cdCommodityGb.Controls.Add(Me.tbCommodityFreq)
        Me.cdCommodityGb.Controls.Add(Me.pbSetCommodity)
        Me.cdCommodityGb.Controls.Add(Me.tbCommodityAmount)
        Me.cdCommodityGb.Controls.Add(Me.pbGetCommodSub)
        Me.cdCommodityGb.Controls.Add(Me.tbCommodityRate)
        Me.cdCommodityGb.Controls.Add(Me.pbSetCommodSub)
        Me.cdCommodityGb.Controls.Add(Me.Label35)
        Me.cdCommodityGb.Controls.Add(Me.lbCommodityCode1)
        Me.cdCommodityGb.Controls.Add(Me.cbEstimated1)
        Me.cdCommodityGb.Controls.Add(Me.Label51)
        Me.cdCommodityGb.Controls.Add(Me.Label50)
        Me.cdCommodityGb.Controls.Add(Me.cbCommoditySupported1)
        Me.cdCommodityGb.Controls.Add(Me.Label37)
        Me.cdCommodityGb.Location = New System.Drawing.Point(228, 11)
        Me.cdCommodityGb.Name = "cdCommodityGb"
        Me.cdCommodityGb.Size = New System.Drawing.Size(379, 291)
        Me.cdCommodityGb.TabIndex = 32
        Me.cdCommodityGb.TabStop = False
        Me.cdCommodityGb.Text = "Connected Device"
        '
        'pbGetCommodity
        '
        Me.pbGetCommodity.Location = New System.Drawing.Point(6, 19)
        Me.pbGetCommodity.Name = "pbGetCommodity"
        Me.pbGetCommodity.Size = New System.Drawing.Size(88, 23)
        Me.pbGetCommodity.TabIndex = 0
        Me.pbGetCommodity.Text = "Get Commodity"
        Me.pbGetCommodity.UseVisualStyleBackColor = True
        '
        'tbCommodityFreq
        '
        Me.tbCommodityFreq.Enabled = False
        Me.tbCommodityFreq.Location = New System.Drawing.Point(188, 165)
        Me.tbCommodityFreq.Name = "tbCommodityFreq"
        Me.tbCommodityFreq.Size = New System.Drawing.Size(100, 20)
        Me.tbCommodityFreq.TabIndex = 30
        '
        'pbSetCommodity
        '
        Me.pbSetCommodity.Location = New System.Drawing.Point(6, 57)
        Me.pbSetCommodity.Name = "pbSetCommodity"
        Me.pbSetCommodity.Size = New System.Drawing.Size(88, 23)
        Me.pbSetCommodity.TabIndex = 1
        Me.pbSetCommodity.Text = "Set Commodity"
        Me.pbSetCommodity.UseVisualStyleBackColor = True
        '
        'tbCommodityAmount
        '
        Me.tbCommodityAmount.Enabled = False
        Me.tbCommodityAmount.Location = New System.Drawing.Point(188, 121)
        Me.tbCommodityAmount.Name = "tbCommodityAmount"
        Me.tbCommodityAmount.Size = New System.Drawing.Size(100, 20)
        Me.tbCommodityAmount.TabIndex = 29
        '
        'pbGetCommodSub
        '
        Me.pbGetCommodSub.Location = New System.Drawing.Point(6, 100)
        Me.pbGetCommodSub.Name = "pbGetCommodSub"
        Me.pbGetCommodSub.Size = New System.Drawing.Size(149, 23)
        Me.pbGetCommodSub.TabIndex = 2
        Me.pbGetCommodSub.Text = "Get Commodity Subscription"
        Me.pbGetCommodSub.UseVisualStyleBackColor = True
        '
        'tbCommodityRate
        '
        Me.tbCommodityRate.Enabled = False
        Me.tbCommodityRate.Location = New System.Drawing.Point(188, 74)
        Me.tbCommodityRate.Name = "tbCommodityRate"
        Me.tbCommodityRate.Size = New System.Drawing.Size(100, 20)
        Me.tbCommodityRate.TabIndex = 28
        '
        'pbSetCommodSub
        '
        Me.pbSetCommodSub.Location = New System.Drawing.Point(6, 140)
        Me.pbSetCommodSub.Name = "pbSetCommodSub"
        Me.pbSetCommodSub.Size = New System.Drawing.Size(149, 23)
        Me.pbSetCommodSub.TabIndex = 3
        Me.pbSetCommodSub.Text = "Set Commodity Subscription"
        Me.pbSetCommodSub.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(191, 149)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(151, 13)
        Me.Label35.TabIndex = 26
        Me.Label35.Text = "Update Frequency in Seconds"
        '
        'lbCommodityCode1
        '
        Me.lbCommodityCode1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lbCommodityCode1.FormattingEnabled = True
        Me.lbCommodityCode1.Items.AddRange(New Object() {"0 Electricity consumed", "1 Electricity produced", "2 Natural gas - cubic ft/hr", "3 Water - gal/hr", "4 Natural gas - cubic meters/hr", "5 Water - liters/hr", "6 Total Energy Storage Capacity", "7 Present Energy Storage Capacity"})
        Me.lbCommodityCode1.Location = New System.Drawing.Point(188, 30)
        Me.lbCommodityCode1.Name = "lbCommodityCode1"
        Me.lbCommodityCode1.Size = New System.Drawing.Size(181, 21)
        Me.lbCommodityCode1.TabIndex = 24
        '
        'cbEstimated1
        '
        Me.cbEstimated1.AutoSize = True
        Me.cbEstimated1.Enabled = False
        Me.cbEstimated1.Location = New System.Drawing.Point(188, 201)
        Me.cbEstimated1.Name = "cbEstimated1"
        Me.cbEstimated1.Size = New System.Drawing.Size(72, 17)
        Me.cbEstimated1.TabIndex = 25
        Me.cbEstimated1.Text = "Estimated"
        Me.cbEstimated1.UseVisualStyleBackColor = True
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(192, 14)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(86, 13)
        Me.Label51.TabIndex = 18
        Me.Label51.Text = "Commodity Code"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(191, 58)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(100, 13)
        Me.Label50.TabIndex = 19
        Me.Label50.Text = "Instantaneous Rate"
        '
        'cbCommoditySupported1
        '
        Me.cbCommoditySupported1.AutoSize = True
        Me.cbCommoditySupported1.Enabled = False
        Me.cbCommoditySupported1.Location = New System.Drawing.Point(188, 231)
        Me.cbCommoditySupported1.Name = "cbCommoditySupported1"
        Me.cbCommoditySupported1.Size = New System.Drawing.Size(75, 17)
        Me.cbCommoditySupported1.TabIndex = 23
        Me.cbCommoditySupported1.Text = "Supported"
        Me.cbCommoditySupported1.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(191, 105)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(98, 13)
        Me.Label37.TabIndex = 21
        Me.Label37.Text = "Cumulative Amount"
        '
        'tdCommodityCodes
        '
        Me.tdCommodityCodes.Controls.Add(Me.lbCommodityCode)
        Me.tdCommodityCodes.Controls.Add(Me.nudCommodityFreq)
        Me.tdCommodityCodes.Controls.Add(Me.Label31)
        Me.tdCommodityCodes.Controls.Add(Me.Label59)
        Me.tdCommodityCodes.Controls.Add(Me.Label32)
        Me.tdCommodityCodes.Controls.Add(Me.cbEstimated)
        Me.tdCommodityCodes.Controls.Add(Me.nudCommodityRate)
        Me.tdCommodityCodes.Controls.Add(Me.Label34)
        Me.tdCommodityCodes.Controls.Add(Me.cbCommoditySupported)
        Me.tdCommodityCodes.Controls.Add(Me.nudCommodityAmount)
        Me.tdCommodityCodes.Controls.Add(Me.pbCommoditySave)
        Me.tdCommodityCodes.Location = New System.Drawing.Point(11, 11)
        Me.tdCommodityCodes.Name = "tdCommodityCodes"
        Me.tdCommodityCodes.Size = New System.Drawing.Size(196, 291)
        Me.tdCommodityCodes.TabIndex = 18
        Me.tdCommodityCodes.TabStop = False
        Me.tdCommodityCodes.Text = "This Device"
        '
        'lbCommodityCode
        '
        Me.lbCommodityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lbCommodityCode.FormattingEnabled = True
        Me.lbCommodityCode.Items.AddRange(New Object() {"0 Electricity consumed", "1 Electricity produced", "2 Natural gas - cubic ft/hr", "3 Water - gal/hr", "4 Natural gas - cubic meters/hr", "5 Water - liters/hr", "6 Total Energy Storage Capacity", "7 Present Energy Storage Capacity"})
        Me.lbCommodityCode.Location = New System.Drawing.Point(6, 35)
        Me.lbCommodityCode.Name = "lbCommodityCode"
        Me.lbCommodityCode.Size = New System.Drawing.Size(181, 21)
        Me.lbCommodityCode.TabIndex = 11
        '
        'nudCommodityFreq
        '
        Me.nudCommodityFreq.Location = New System.Drawing.Point(6, 170)
        Me.nudCommodityFreq.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudCommodityFreq.Name = "nudCommodityFreq"
        Me.nudCommodityFreq.Size = New System.Drawing.Size(120, 20)
        Me.nudCommodityFreq.TabIndex = 17
        Me.nudCommodityFreq.Value = New Decimal(New Integer() {300, 0, 0, 0})
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(10, 19)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(86, 13)
        Me.Label31.TabIndex = 2
        Me.Label31.Text = "Commodity Code"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(9, 154)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(151, 13)
        Me.Label59.TabIndex = 16
        Me.Label59.Text = "Update Frequency in Seconds"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(9, 63)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(100, 13)
        Me.Label32.TabIndex = 4
        Me.Label32.Text = "Instantaneous Rate"
        '
        'cbEstimated
        '
        Me.cbEstimated.AutoSize = True
        Me.cbEstimated.Location = New System.Drawing.Point(6, 206)
        Me.cbEstimated.Name = "cbEstimated"
        Me.cbEstimated.Size = New System.Drawing.Size(72, 17)
        Me.cbEstimated.TabIndex = 13
        Me.cbEstimated.Text = "Estimated"
        Me.cbEstimated.UseVisualStyleBackColor = True
        '
        'nudCommodityRate
        '
        Me.nudCommodityRate.Location = New System.Drawing.Point(6, 79)
        Me.nudCommodityRate.Maximum = New Decimal(New Integer() {-1, 65535, 0, 0})
        Me.nudCommodityRate.Name = "nudCommodityRate"
        Me.nudCommodityRate.Size = New System.Drawing.Size(120, 20)
        Me.nudCommodityRate.TabIndex = 5
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(9, 110)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(98, 13)
        Me.Label34.TabIndex = 6
        Me.Label34.Text = "Cumulative Amount"
        '
        'cbCommoditySupported
        '
        Me.cbCommoditySupported.AutoSize = True
        Me.cbCommoditySupported.Location = New System.Drawing.Point(6, 236)
        Me.cbCommoditySupported.Name = "cbCommoditySupported"
        Me.cbCommoditySupported.Size = New System.Drawing.Size(75, 17)
        Me.cbCommoditySupported.TabIndex = 10
        Me.cbCommoditySupported.Text = "Supported"
        Me.cbCommoditySupported.UseVisualStyleBackColor = True
        '
        'nudCommodityAmount
        '
        Me.nudCommodityAmount.Location = New System.Drawing.Point(6, 125)
        Me.nudCommodityAmount.Maximum = New Decimal(New Integer() {-1, 65535, 0, 0})
        Me.nudCommodityAmount.Name = "nudCommodityAmount"
        Me.nudCommodityAmount.Size = New System.Drawing.Size(120, 20)
        Me.nudCommodityAmount.TabIndex = 7
        '
        'pbCommoditySave
        '
        Me.pbCommoditySave.Location = New System.Drawing.Point(97, 238)
        Me.pbCommoditySave.Name = "pbCommoditySave"
        Me.pbCommoditySave.Size = New System.Drawing.Size(75, 23)
        Me.pbCommoditySave.TabIndex = 8
        Me.pbCommoditySave.Text = "Save"
        Me.pbCommoditySave.UseVisualStyleBackColor = True
        '
        'getSet
        '
        Me.getSet.Controls.Add(Me.pbGetEnergyPrice)
        Me.getSet.Controls.Add(Me.pbSetTier)
        Me.getSet.Controls.Add(Me.pfGetTier)
        Me.getSet.Controls.Add(Me.pbSetEnergyPrice)
        Me.getSet.Location = New System.Drawing.Point(4, 22)
        Me.getSet.Name = "getSet"
        Me.getSet.Size = New System.Drawing.Size(623, 313)
        Me.getSet.TabIndex = 5
        Me.getSet.Text = "Get/Set"
        Me.getSet.UseVisualStyleBackColor = True
        '
        'pbGetEnergyPrice
        '
        Me.pbGetEnergyPrice.Location = New System.Drawing.Point(26, 23)
        Me.pbGetEnergyPrice.Name = "pbGetEnergyPrice"
        Me.pbGetEnergyPrice.Size = New System.Drawing.Size(102, 23)
        Me.pbGetEnergyPrice.TabIndex = 4
        Me.pbGetEnergyPrice.Text = "Get Energy Price"
        Me.pbGetEnergyPrice.UseVisualStyleBackColor = True
        '
        'pbSetTier
        '
        Me.pbSetTier.Location = New System.Drawing.Point(26, 110)
        Me.pbSetTier.Name = "pbSetTier"
        Me.pbSetTier.Size = New System.Drawing.Size(102, 23)
        Me.pbSetTier.TabIndex = 3
        Me.pbSetTier.Text = "Set Tier"
        Me.pbSetTier.UseVisualStyleBackColor = True
        '
        'pfGetTier
        '
        Me.pfGetTier.Location = New System.Drawing.Point(26, 81)
        Me.pfGetTier.Name = "pfGetTier"
        Me.pfGetTier.Size = New System.Drawing.Size(102, 23)
        Me.pfGetTier.TabIndex = 2
        Me.pfGetTier.Text = "Get Tier"
        Me.pfGetTier.UseVisualStyleBackColor = True
        '
        'pbSetEnergyPrice
        '
        Me.pbSetEnergyPrice.Location = New System.Drawing.Point(26, 52)
        Me.pbSetEnergyPrice.Name = "pbSetEnergyPrice"
        Me.pbSetEnergyPrice.Size = New System.Drawing.Size(102, 23)
        Me.pbSetEnergyPrice.TabIndex = 1
        Me.pbSetEnergyPrice.Text = "Set Energy Price"
        Me.pbSetEnergyPrice.UseVisualStyleBackColor = True
        '
        'commonCommandsTab
        '
        Me.commonCommandsTab.Controls.Add(Me.commonCommandsTabControl)
        Me.commonCommandsTab.Location = New System.Drawing.Point(4, 22)
        Me.commonCommandsTab.Name = "commonCommandsTab"
        Me.commonCommandsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.commonCommandsTab.Size = New System.Drawing.Size(643, 351)
        Me.commonCommandsTab.TabIndex = 2
        Me.commonCommandsTab.Text = "Common Commands"
        Me.commonCommandsTab.UseVisualStyleBackColor = True
        '
        'commonCommandsTabControl
        '
        Me.commonCommandsTabControl.Controls.Add(Me.changeBaudTab)
        Me.commonCommandsTabControl.Controls.Add(Me.simulateErrorsTab)
        Me.commonCommandsTabControl.Controls.Add(Me.TimingTab)
        Me.commonCommandsTabControl.Controls.Add(Me.PassThrough)
        Me.commonCommandsTabControl.Location = New System.Drawing.Point(6, 6)
        Me.commonCommandsTabControl.Multiline = True
        Me.commonCommandsTabControl.Name = "commonCommandsTabControl"
        Me.commonCommandsTabControl.SelectedIndex = 0
        Me.commonCommandsTabControl.Size = New System.Drawing.Size(631, 339)
        Me.commonCommandsTabControl.TabIndex = 0
        '
        'changeBaudTab
        '
        Me.changeBaudTab.Controls.Add(Me.grpChangeBaud)
        Me.changeBaudTab.Location = New System.Drawing.Point(4, 22)
        Me.changeBaudTab.Name = "changeBaudTab"
        Me.changeBaudTab.Padding = New System.Windows.Forms.Padding(3)
        Me.changeBaudTab.Size = New System.Drawing.Size(623, 313)
        Me.changeBaudTab.TabIndex = 0
        Me.changeBaudTab.Text = "Change Bit Rate"
        Me.changeBaudTab.UseVisualStyleBackColor = True
        '
        'simulateErrorsTab
        '
        Me.simulateErrorsTab.Controls.Add(Me.opcodeErrorsGroup)
        Me.simulateErrorsTab.Controls.Add(Me.gbErrors)
        Me.simulateErrorsTab.Location = New System.Drawing.Point(4, 22)
        Me.simulateErrorsTab.Name = "simulateErrorsTab"
        Me.simulateErrorsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.simulateErrorsTab.Size = New System.Drawing.Size(623, 313)
        Me.simulateErrorsTab.TabIndex = 1
        Me.simulateErrorsTab.Text = "Simulate Errors"
        Me.simulateErrorsTab.UseVisualStyleBackColor = True
        '
        'opcodeErrorsGroup
        '
        Me.opcodeErrorsGroup.Controls.Add(Me.Label88)
        Me.opcodeErrorsGroup.Controls.Add(Me.Label89)
        Me.opcodeErrorsGroup.Controls.Add(Me.customLength2ValBox)
        Me.opcodeErrorsGroup.Controls.Add(Me.customLength1ValBox)
        Me.opcodeErrorsGroup.Controls.Add(Me.customLength2cb)
        Me.opcodeErrorsGroup.Controls.Add(Me.customLength1cb)
        Me.opcodeErrorsGroup.Controls.Add(Me.Label86)
        Me.opcodeErrorsGroup.Controls.Add(Me.Label87)
        Me.opcodeErrorsGroup.Controls.Add(Me.customMsgType2ValBox)
        Me.opcodeErrorsGroup.Controls.Add(Me.customMsgType1ValBox)
        Me.opcodeErrorsGroup.Controls.Add(Me.customMsgType2cb)
        Me.opcodeErrorsGroup.Controls.Add(Me.customMsgType1cb)
        Me.opcodeErrorsGroup.Controls.Add(Me.Label71)
        Me.opcodeErrorsGroup.Controls.Add(Me.Label70)
        Me.opcodeErrorsGroup.Controls.Add(Me.badOpcode2valbox)
        Me.opcodeErrorsGroup.Controls.Add(Me.badOpcode1valbox)
        Me.opcodeErrorsGroup.Controls.Add(Me.badOpcode2cb)
        Me.opcodeErrorsGroup.Controls.Add(Me.badOpcode1cb)
        Me.opcodeErrorsGroup.Location = New System.Drawing.Point(6, 18)
        Me.opcodeErrorsGroup.Name = "opcodeErrorsGroup"
        Me.opcodeErrorsGroup.Size = New System.Drawing.Size(611, 118)
        Me.opcodeErrorsGroup.TabIndex = 19
        Me.opcodeErrorsGroup.TabStop = False
        Me.opcodeErrorsGroup.Text = "Custom Bytes"
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Location = New System.Drawing.Point(298, 32)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(49, 13)
        Me.Label88.TabIndex = 22
        Me.Label88.Text = "Length 2"
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Location = New System.Drawing.Point(204, 32)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(49, 13)
        Me.Label89.TabIndex = 21
        Me.Label89.Text = "Length 1"
        '
        'customLength2ValBox
        '
        Me.customLength2ValBox.Location = New System.Drawing.Point(301, 48)
        Me.customLength2ValBox.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.customLength2ValBox.Name = "customLength2ValBox"
        Me.customLength2ValBox.Size = New System.Drawing.Size(53, 20)
        Me.customLength2ValBox.TabIndex = 20
        '
        'customLength1ValBox
        '
        Me.customLength1ValBox.Location = New System.Drawing.Point(207, 48)
        Me.customLength1ValBox.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.customLength1ValBox.Name = "customLength1ValBox"
        Me.customLength1ValBox.Size = New System.Drawing.Size(53, 20)
        Me.customLength1ValBox.TabIndex = 19
        '
        'customLength2cb
        '
        Me.customLength2cb.AutoSize = True
        Me.customLength2cb.Location = New System.Drawing.Point(320, 74)
        Me.customLength2cb.Name = "customLength2cb"
        Me.customLength2cb.Size = New System.Drawing.Size(15, 14)
        Me.customLength2cb.TabIndex = 18
        Me.customLength2cb.UseVisualStyleBackColor = True
        '
        'customLength1cb
        '
        Me.customLength1cb.AutoSize = True
        Me.customLength1cb.Location = New System.Drawing.Point(225, 74)
        Me.customLength1cb.Name = "customLength1cb"
        Me.customLength1cb.Size = New System.Drawing.Size(15, 14)
        Me.customLength1cb.TabIndex = 17
        Me.customLength1cb.UseVisualStyleBackColor = True
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Location = New System.Drawing.Point(105, 32)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(63, 13)
        Me.Label86.TabIndex = 16
        Me.Label86.Text = "Msg Type 2"
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Location = New System.Drawing.Point(11, 32)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(63, 13)
        Me.Label87.TabIndex = 15
        Me.Label87.Text = "Msg Type 1"
        '
        'customMsgType2ValBox
        '
        Me.customMsgType2ValBox.Location = New System.Drawing.Point(108, 48)
        Me.customMsgType2ValBox.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.customMsgType2ValBox.Name = "customMsgType2ValBox"
        Me.customMsgType2ValBox.Size = New System.Drawing.Size(53, 20)
        Me.customMsgType2ValBox.TabIndex = 14
        '
        'customMsgType1ValBox
        '
        Me.customMsgType1ValBox.Location = New System.Drawing.Point(14, 48)
        Me.customMsgType1ValBox.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.customMsgType1ValBox.Name = "customMsgType1ValBox"
        Me.customMsgType1ValBox.Size = New System.Drawing.Size(53, 20)
        Me.customMsgType1ValBox.TabIndex = 13
        '
        'customMsgType2cb
        '
        Me.customMsgType2cb.AutoSize = True
        Me.customMsgType2cb.Location = New System.Drawing.Point(127, 74)
        Me.customMsgType2cb.Name = "customMsgType2cb"
        Me.customMsgType2cb.Size = New System.Drawing.Size(15, 14)
        Me.customMsgType2cb.TabIndex = 12
        Me.customMsgType2cb.UseVisualStyleBackColor = True
        '
        'customMsgType1cb
        '
        Me.customMsgType1cb.AutoSize = True
        Me.customMsgType1cb.Location = New System.Drawing.Point(32, 74)
        Me.customMsgType1cb.Name = "customMsgType1cb"
        Me.customMsgType1cb.Size = New System.Drawing.Size(15, 14)
        Me.customMsgType1cb.TabIndex = 11
        Me.customMsgType1cb.UseVisualStyleBackColor = True
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(489, 32)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(55, 13)
        Me.Label71.TabIndex = 10
        Me.Label71.Text = "OpCode 2"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(395, 32)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(55, 13)
        Me.Label70.TabIndex = 9
        Me.Label70.Text = "OpCode 1"
        '
        'badOpcode2valbox
        '
        Me.badOpcode2valbox.Location = New System.Drawing.Point(492, 48)
        Me.badOpcode2valbox.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.badOpcode2valbox.Name = "badOpcode2valbox"
        Me.badOpcode2valbox.Size = New System.Drawing.Size(53, 20)
        Me.badOpcode2valbox.TabIndex = 8
        '
        'badOpcode1valbox
        '
        Me.badOpcode1valbox.Location = New System.Drawing.Point(398, 48)
        Me.badOpcode1valbox.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.badOpcode1valbox.Name = "badOpcode1valbox"
        Me.badOpcode1valbox.Size = New System.Drawing.Size(53, 20)
        Me.badOpcode1valbox.TabIndex = 7
        '
        'badOpcode2cb
        '
        Me.badOpcode2cb.AutoSize = True
        Me.badOpcode2cb.Location = New System.Drawing.Point(511, 74)
        Me.badOpcode2cb.Name = "badOpcode2cb"
        Me.badOpcode2cb.Size = New System.Drawing.Size(15, 14)
        Me.badOpcode2cb.TabIndex = 6
        Me.badOpcode2cb.UseVisualStyleBackColor = True
        '
        'badOpcode1cb
        '
        Me.badOpcode1cb.AutoSize = True
        Me.badOpcode1cb.Location = New System.Drawing.Point(416, 74)
        Me.badOpcode1cb.Name = "badOpcode1cb"
        Me.badOpcode1cb.Size = New System.Drawing.Size(15, 14)
        Me.badOpcode1cb.TabIndex = 5
        Me.badOpcode1cb.UseVisualStyleBackColor = True
        '
        'TimingTab
        '
        Me.TimingTab.Controls.Add(Me.Label62)
        Me.TimingTab.Controls.Add(Me.Label69)
        Me.TimingTab.Controls.Add(Me.label3i4lskjfdlj)
        Me.TimingTab.Controls.Add(Me.tMLValBox)
        Me.TimingTab.Controls.Add(Me.labelwhatever)
        Me.TimingTab.Controls.Add(Me.Label64)
        Me.TimingTab.Controls.Add(Me.Label65)
        Me.TimingTab.Controls.Add(Me.Label66)
        Me.TimingTab.Controls.Add(Me.Label67)
        Me.TimingTab.Controls.Add(Me.Label68)
        Me.TimingTab.Controls.Add(Me.tIMValBox)
        Me.TimingTab.Controls.Add(Me.tRAValBox)
        Me.TimingTab.Controls.Add(Me.Label63)
        Me.TimingTab.Controls.Add(Me.label61)
        Me.TimingTab.Controls.Add(Me.Label60)
        Me.TimingTab.Controls.Add(Me.Label58)
        Me.TimingTab.Controls.Add(Me.Label38)
        Me.TimingTab.Controls.Add(Me.Label30)
        Me.TimingTab.Controls.Add(Me.tARValBox)
        Me.TimingTab.Controls.Add(Me.tMAValBox)
        Me.TimingTab.Location = New System.Drawing.Point(4, 22)
        Me.TimingTab.Name = "TimingTab"
        Me.TimingTab.Padding = New System.Windows.Forms.Padding(3)
        Me.TimingTab.Size = New System.Drawing.Size(623, 313)
        Me.TimingTab.TabIndex = 7
        Me.TimingTab.Text = "Timing Variables"
        Me.TimingTab.UseVisualStyleBackColor = True
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(326, 58)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(86, 13)
        Me.Label62.TabIndex = 20
        Me.Label62.Text = "(In Spec: 500ms)"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(404, 37)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(26, 13)
        Me.Label69.TabIndex = 19
        Me.Label69.Text = "(ms)"
        '
        'label3i4lskjfdlj
        '
        Me.label3i4lskjfdlj.AutoSize = True
        Me.label3i4lskjfdlj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3i4lskjfdlj.Location = New System.Drawing.Point(276, 35)
        Me.label3i4lskjfdlj.Name = "label3i4lskjfdlj"
        Me.label3i4lskjfdlj.Size = New System.Drawing.Size(31, 15)
        Me.label3i4lskjfdlj.TabIndex = 18
        Me.label3i4lskjfdlj.Text = "tML:"
        '
        'tMLValBox
        '
        Me.tMLValBox.Location = New System.Drawing.Point(329, 35)
        Me.tMLValBox.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.tMLValBox.Name = "tMLValBox"
        Me.tMLValBox.Size = New System.Drawing.Size(69, 20)
        Me.tMLValBox.TabIndex = 17
        '
        'labelwhatever
        '
        Me.labelwhatever.AutoSize = True
        Me.labelwhatever.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelwhatever.Location = New System.Drawing.Point(110, 238)
        Me.labelwhatever.Name = "labelwhatever"
        Me.labelwhatever.Size = New System.Drawing.Size(129, 13)
        Me.labelwhatever.TabIndex = 16
        Me.labelwhatever.Text = "(In Spec: 100ms minimum)"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(110, 117)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(129, 13)
        Me.Label64.TabIndex = 15
        Me.Label64.Text = "(In Spec: 100ms minimum)"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(188, 217)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(26, 13)
        Me.Label65.TabIndex = 14
        Me.Label65.Text = "(ms)"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(188, 158)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(26, 13)
        Me.Label66.TabIndex = 13
        Me.Label66.Text = "(ms)"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(60, 215)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(27, 15)
        Me.Label67.TabIndex = 12
        Me.Label67.Text = "tIM:"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(60, 156)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(29, 15)
        Me.Label68.TabIndex = 11
        Me.Label68.Text = "tRA:"
        '
        'tIMValBox
        '
        Me.tIMValBox.Location = New System.Drawing.Point(113, 215)
        Me.tIMValBox.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.tIMValBox.Name = "tIMValBox"
        Me.tIMValBox.Size = New System.Drawing.Size(69, 20)
        Me.tIMValBox.TabIndex = 10
        '
        'tRAValBox
        '
        Me.tRAValBox.Location = New System.Drawing.Point(113, 156)
        Me.tRAValBox.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.tRAValBox.Name = "tRAValBox"
        Me.tRAValBox.Size = New System.Drawing.Size(69, 20)
        Me.tRAValBox.TabIndex = 9
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(110, 179)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(120, 13)
        Me.Label63.TabIndex = 8
        Me.Label63.Text = "(In Spec: 40ms - 200ms)"
        '
        'label61
        '
        Me.label61.AutoSize = True
        Me.label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label61.Location = New System.Drawing.Point(110, 58)
        Me.label61.Name = "label61"
        Me.label61.Size = New System.Drawing.Size(120, 13)
        Me.label61.TabIndex = 6
        Me.label61.Text = "(In Spec: 40ms - 200ms)"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(188, 96)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(26, 13)
        Me.Label60.TabIndex = 5
        Me.Label60.Text = "(ms)"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(188, 37)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(26, 13)
        Me.Label58.TabIndex = 4
        Me.Label58.Text = "(ms)"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(60, 94)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(29, 15)
        Me.Label38.TabIndex = 3
        Me.Label38.Text = "tAR:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(60, 35)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(31, 15)
        Me.Label30.TabIndex = 2
        Me.Label30.Text = "tMA:"
        '
        'tARValBox
        '
        Me.tARValBox.Location = New System.Drawing.Point(113, 94)
        Me.tARValBox.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.tARValBox.Name = "tARValBox"
        Me.tARValBox.Size = New System.Drawing.Size(69, 20)
        Me.tARValBox.TabIndex = 1
        '
        'tMAValBox
        '
        Me.tMAValBox.Location = New System.Drawing.Point(113, 35)
        Me.tMAValBox.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.tMAValBox.Name = "tMAValBox"
        Me.tMAValBox.Size = New System.Drawing.Size(69, 20)
        Me.tMAValBox.TabIndex = 0
        '
        'PassThrough
        '
        Me.PassThrough.Controls.Add(Me.Label53)
        Me.PassThrough.Controls.Add(Me.pbSendPT)
        Me.PassThrough.Controls.Add(Me.Label52)
        Me.PassThrough.Controls.Add(Me.cbProtocolPT)
        Me.PassThrough.Controls.Add(Me.pbBrowsePT)
        Me.PassThrough.Controls.Add(Me.tbFilePathPT)
        Me.PassThrough.Controls.Add(Me.cbAddWrapper)
        Me.PassThrough.Location = New System.Drawing.Point(4, 22)
        Me.PassThrough.Name = "PassThrough"
        Me.PassThrough.Size = New System.Drawing.Size(623, 313)
        Me.PassThrough.TabIndex = 8
        Me.PassThrough.Text = "Pass Through"
        Me.PassThrough.UseVisualStyleBackColor = True
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(232, 40)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(151, 13)
        Me.Label53.TabIndex = 6
        Me.Label53.Text = "Enter file name or click browse"
        '
        'pbSendPT
        '
        Me.pbSendPT.Location = New System.Drawing.Point(14, 140)
        Me.pbSendPT.Name = "pbSendPT"
        Me.pbSendPT.Size = New System.Drawing.Size(75, 23)
        Me.pbSendPT.TabIndex = 5
        Me.pbSendPT.Text = "Send File"
        Me.pbSendPT.UseVisualStyleBackColor = True
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(151, 112)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(46, 13)
        Me.Label52.TabIndex = 4
        Me.Label52.Text = "Protocol"
        '
        'cbProtocolPT
        '
        Me.cbProtocolPT.FormattingEnabled = True
        Me.cbProtocolPT.Items.AddRange(New Object() {"0 Undefined", "1 USNAP1.0", "2 ClimateTalk", "3 Undefined", "4 Undefined", "5 SEP1.0", "6 Undefined", "7 General Internet", "8 ECHONET Lite", "9 KNX", "10 LonTalk", "11 SunSpec"})
        Me.cbProtocolPT.Location = New System.Drawing.Point(14, 104)
        Me.cbProtocolPT.Name = "cbProtocolPT"
        Me.cbProtocolPT.Size = New System.Drawing.Size(121, 21)
        Me.cbProtocolPT.TabIndex = 3
        '
        'pbBrowsePT
        '
        Me.pbBrowsePT.Location = New System.Drawing.Point(14, 66)
        Me.pbBrowsePT.Name = "pbBrowsePT"
        Me.pbBrowsePT.Size = New System.Drawing.Size(75, 23)
        Me.pbBrowsePT.TabIndex = 2
        Me.pbBrowsePT.Text = "Browse"
        Me.pbBrowsePT.UseVisualStyleBackColor = True
        '
        'tbFilePathPT
        '
        Me.tbFilePathPT.Location = New System.Drawing.Point(14, 37)
        Me.tbFilePathPT.Name = "tbFilePathPT"
        Me.tbFilePathPT.Size = New System.Drawing.Size(203, 20)
        Me.tbFilePathPT.TabIndex = 1
        '
        'cbAddWrapper
        '
        Me.cbAddWrapper.AutoSize = True
        Me.cbAddWrapper.Checked = True
        Me.cbAddWrapper.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAddWrapper.Location = New System.Drawing.Point(14, 14)
        Me.cbAddWrapper.Name = "cbAddWrapper"
        Me.cbAddWrapper.Size = New System.Drawing.Size(86, 17)
        Me.cbAddWrapper.TabIndex = 0
        Me.cbAddWrapper.Text = "Add wrapper"
        Me.cbAddWrapper.UseVisualStyleBackColor = True
        '
        'ucmTab
        '
        Me.ucmTab.Controls.Add(Me.ucmTabControl)
        Me.ucmTab.Location = New System.Drawing.Point(4, 22)
        Me.ucmTab.Name = "ucmTab"
        Me.ucmTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ucmTab.Size = New System.Drawing.Size(643, 351)
        Me.ucmTab.TabIndex = 0
        Me.ucmTab.Text = "UCM Commands"
        Me.ucmTab.UseVisualStyleBackColor = True
        '
        'ucmTabControl
        '
        Me.ucmTabControl.Controls.Add(Me.ucmManageDeviceTab)
        Me.ucmTabControl.Controls.Add(Me.ucmQueryTab)
        Me.ucmTabControl.Controls.Add(Me.ucmComStatusTab)
        Me.ucmTabControl.Controls.Add(Me.ucmTimeSyncTab)
        Me.ucmTabControl.Controls.Add(Me.TabPage4)
        Me.ucmTabControl.Location = New System.Drawing.Point(6, 6)
        Me.ucmTabControl.Multiline = True
        Me.ucmTabControl.Name = "ucmTabControl"
        Me.ucmTabControl.SelectedIndex = 0
        Me.ucmTabControl.Size = New System.Drawing.Size(631, 339)
        Me.ucmTabControl.TabIndex = 36
        '
        'ucmManageDeviceTab
        '
        Me.ucmManageDeviceTab.Controls.Add(Me.TabControl1)
        Me.ucmManageDeviceTab.Location = New System.Drawing.Point(4, 22)
        Me.ucmManageDeviceTab.Name = "ucmManageDeviceTab"
        Me.ucmManageDeviceTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ucmManageDeviceTab.Size = New System.Drawing.Size(623, 313)
        Me.ucmManageDeviceTab.TabIndex = 0
        Me.ucmManageDeviceTab.Text = "Basic Commands"
        Me.ucmManageDeviceTab.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.shedLoadTab)
        Me.TabControl1.Controls.Add(Me.gridGuidenceTab)
        Me.TabControl1.Controls.Add(Me.nextPeriodRelativePriceTab)
        Me.TabControl1.Controls.Add(Me.presentRelativePriceTab)
        Me.TabControl1.Controls.Add(Me.requestPowerLevelTab)
        Me.TabControl1.Controls.Add(Me.timeRemainingTab)
        Me.TabControl1.Location = New System.Drawing.Point(6, 6)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(611, 301)
        Me.TabControl1.TabIndex = 0
        '
        'shedLoadTab
        '
        Me.shedLoadTab.Controls.Add(Me.criticalPeakButton)
        Me.shedLoadTab.Controls.Add(Me.btnEndShed)
        Me.shedLoadTab.Controls.Add(Me.gridEmergencyButton)
        Me.shedLoadTab.Controls.Add(Me.Label9)
        Me.shedLoadTab.Controls.Add(Me.pbLoadUp)
        Me.shedLoadTab.Controls.Add(Me.btnShedSend)
        Me.shedLoadTab.Controls.Add(Me.txtShedDur)
        Me.shedLoadTab.Controls.Add(Me.trkShedDur)
        Me.shedLoadTab.Location = New System.Drawing.Point(4, 22)
        Me.shedLoadTab.Name = "shedLoadTab"
        Me.shedLoadTab.Padding = New System.Windows.Forms.Padding(3)
        Me.shedLoadTab.Size = New System.Drawing.Size(603, 275)
        Me.shedLoadTab.TabIndex = 0
        Me.shedLoadTab.Text = "Curtailments"
        Me.shedLoadTab.UseVisualStyleBackColor = True
        '
        'criticalPeakButton
        '
        Me.criticalPeakButton.Location = New System.Drawing.Point(12, 166)
        Me.criticalPeakButton.Name = "criticalPeakButton"
        Me.criticalPeakButton.Size = New System.Drawing.Size(137, 23)
        Me.criticalPeakButton.TabIndex = 10
        Me.criticalPeakButton.Text = "Initiate CPP Event"
        Me.criticalPeakButton.UseVisualStyleBackColor = True
        '
        'btnEndShed
        '
        Me.btnEndShed.Location = New System.Drawing.Point(170, 108)
        Me.btnEndShed.Name = "btnEndShed"
        Me.btnEndShed.Size = New System.Drawing.Size(153, 23)
        Me.btnEndShed.TabIndex = 2
        Me.btnEndShed.Text = "Run Normal / End Event"
        Me.btnEndShed.UseVisualStyleBackColor = True
        '
        'gridEmergencyButton
        '
        Me.gridEmergencyButton.Location = New System.Drawing.Point(12, 137)
        Me.gridEmergencyButton.Name = "gridEmergencyButton"
        Me.gridEmergencyButton.Size = New System.Drawing.Size(137, 23)
        Me.gridEmergencyButton.TabIndex = 10
        Me.gridEmergencyButton.Text = "Initiate Grid Emergency"
        Me.gridEmergencyButton.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(105, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Duration"
        '
        'pbLoadUp
        '
        Me.pbLoadUp.Location = New System.Drawing.Point(12, 195)
        Me.pbLoadUp.Name = "pbLoadUp"
        Me.pbLoadUp.Size = New System.Drawing.Size(137, 23)
        Me.pbLoadUp.TabIndex = 11
        Me.pbLoadUp.Text = "Load Up"
        Me.pbLoadUp.UseVisualStyleBackColor = True
        '
        'btnShedSend
        '
        Me.btnShedSend.Location = New System.Drawing.Point(12, 108)
        Me.btnShedSend.Name = "btnShedSend"
        Me.btnShedSend.Size = New System.Drawing.Size(137, 23)
        Me.btnShedSend.TabIndex = 10
        Me.btnShedSend.Text = "Shed Load"
        Me.btnShedSend.UseVisualStyleBackColor = True
        '
        'txtShedDur
        '
        Me.txtShedDur.Location = New System.Drawing.Point(28, 12)
        Me.txtShedDur.MaxLength = 4
        Me.txtShedDur.Name = "txtShedDur"
        Me.txtShedDur.ReadOnly = True
        Me.txtShedDur.Size = New System.Drawing.Size(71, 20)
        Me.txtShedDur.TabIndex = 9
        Me.txtShedDur.Text = "0"
        Me.txtShedDur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtShedDur.WordWrap = False
        '
        'trkShedDur
        '
        Me.trkShedDur.Location = New System.Drawing.Point(12, 42)
        Me.trkShedDur.Maximum = 255
        Me.trkShedDur.Name = "trkShedDur"
        Me.trkShedDur.Size = New System.Drawing.Size(311, 45)
        Me.trkShedDur.TabIndex = 8
        '
        'gridGuidenceTab
        '
        Me.gridGuidenceTab.Controls.Add(Me.grpGridGuide)
        Me.gridGuidenceTab.Location = New System.Drawing.Point(4, 22)
        Me.gridGuidenceTab.Name = "gridGuidenceTab"
        Me.gridGuidenceTab.Padding = New System.Windows.Forms.Padding(3)
        Me.gridGuidenceTab.Size = New System.Drawing.Size(603, 275)
        Me.gridGuidenceTab.TabIndex = 5
        Me.gridGuidenceTab.Text = "Grid Guidance"
        Me.gridGuidenceTab.UseVisualStyleBackColor = True
        '
        'grpGridGuide
        '
        Me.grpGridGuide.Controls.Add(Me.sendGuidenceButton)
        Me.grpGridGuide.Controls.Add(Me.cmbGridGuide)
        Me.grpGridGuide.Location = New System.Drawing.Point(6, 19)
        Me.grpGridGuide.Name = "grpGridGuide"
        Me.grpGridGuide.Size = New System.Drawing.Size(242, 82)
        Me.grpGridGuide.TabIndex = 21
        Me.grpGridGuide.TabStop = False
        Me.grpGridGuide.Text = "Grid Guidance"
        Me.grpGridGuide.Visible = False
        '
        'sendGuidenceButton
        '
        Me.sendGuidenceButton.Location = New System.Drawing.Point(12, 48)
        Me.sendGuidenceButton.Name = "sendGuidenceButton"
        Me.sendGuidenceButton.Size = New System.Drawing.Size(109, 23)
        Me.sendGuidenceButton.TabIndex = 4
        Me.sendGuidenceButton.Text = "Send Guidance"
        Me.sendGuidenceButton.UseVisualStyleBackColor = True
        '
        'cmbGridGuide
        '
        Me.cmbGridGuide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGridGuide.FormattingEnabled = True
        Me.cmbGridGuide.Items.AddRange(New Object() {"Bad Time to Use Energy", "Neutral", "Good Time to Use Energy"})
        Me.cmbGridGuide.Location = New System.Drawing.Point(6, 16)
        Me.cmbGridGuide.Name = "cmbGridGuide"
        Me.cmbGridGuide.Size = New System.Drawing.Size(214, 21)
        Me.cmbGridGuide.TabIndex = 3
        '
        'nextPeriodRelativePriceTab
        '
        Me.nextPeriodRelativePriceTab.Controls.Add(Me.nextPeriodPriceGroup)
        Me.nextPeriodRelativePriceTab.Location = New System.Drawing.Point(4, 22)
        Me.nextPeriodRelativePriceTab.Name = "nextPeriodRelativePriceTab"
        Me.nextPeriodRelativePriceTab.Padding = New System.Windows.Forms.Padding(3)
        Me.nextPeriodRelativePriceTab.Size = New System.Drawing.Size(603, 275)
        Me.nextPeriodRelativePriceTab.TabIndex = 3
        Me.nextPeriodRelativePriceTab.Text = "Next Period Relative Price"
        Me.nextPeriodRelativePriceTab.UseVisualStyleBackColor = True
        '
        'nextPeriodPriceGroup
        '
        Me.nextPeriodPriceGroup.Controls.Add(Me.nextPeriodPriceButton)
        Me.nextPeriodPriceGroup.Controls.Add(Me.nextPeriodPriceTextBox)
        Me.nextPeriodPriceGroup.Controls.Add(Me.nextPeriodTrackBar)
        Me.nextPeriodPriceGroup.Location = New System.Drawing.Point(6, 19)
        Me.nextPeriodPriceGroup.Name = "nextPeriodPriceGroup"
        Me.nextPeriodPriceGroup.Size = New System.Drawing.Size(329, 142)
        Me.nextPeriodPriceGroup.TabIndex = 22
        Me.nextPeriodPriceGroup.TabStop = False
        Me.nextPeriodPriceGroup.Text = "Relative Price"
        Me.nextPeriodPriceGroup.Visible = False
        '
        'nextPeriodPriceButton
        '
        Me.nextPeriodPriceButton.Location = New System.Drawing.Point(28, 104)
        Me.nextPeriodPriceButton.Name = "nextPeriodPriceButton"
        Me.nextPeriodPriceButton.Size = New System.Drawing.Size(75, 23)
        Me.nextPeriodPriceButton.TabIndex = 10
        Me.nextPeriodPriceButton.Text = "Set Price"
        Me.nextPeriodPriceButton.UseVisualStyleBackColor = True
        '
        'nextPeriodPriceTextBox
        '
        Me.nextPeriodPriceTextBox.Location = New System.Drawing.Point(15, 22)
        Me.nextPeriodPriceTextBox.MaxLength = 4
        Me.nextPeriodPriceTextBox.Name = "nextPeriodPriceTextBox"
        Me.nextPeriodPriceTextBox.ReadOnly = True
        Me.nextPeriodPriceTextBox.Size = New System.Drawing.Size(71, 20)
        Me.nextPeriodPriceTextBox.TabIndex = 9
        Me.nextPeriodPriceTextBox.Text = "0"
        Me.nextPeriodPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nextPeriodPriceTextBox.WordWrap = False
        '
        'nextPeriodTrackBar
        '
        Me.nextPeriodTrackBar.Location = New System.Drawing.Point(12, 53)
        Me.nextPeriodTrackBar.Maximum = 255
        Me.nextPeriodTrackBar.Name = "nextPeriodTrackBar"
        Me.nextPeriodTrackBar.Size = New System.Drawing.Size(311, 45)
        Me.nextPeriodTrackBar.TabIndex = 8
        '
        'presentRelativePriceTab
        '
        Me.presentRelativePriceTab.Controls.Add(Me.presentPriceGroup)
        Me.presentRelativePriceTab.Location = New System.Drawing.Point(4, 22)
        Me.presentRelativePriceTab.Name = "presentRelativePriceTab"
        Me.presentRelativePriceTab.Padding = New System.Windows.Forms.Padding(3)
        Me.presentRelativePriceTab.Size = New System.Drawing.Size(603, 275)
        Me.presentRelativePriceTab.TabIndex = 0
        Me.presentRelativePriceTab.Text = "Present Relative Price"
        Me.presentRelativePriceTab.UseVisualStyleBackColor = True
        '
        'presentPriceGroup
        '
        Me.presentPriceGroup.Controls.Add(Me.presentPriceButton)
        Me.presentPriceGroup.Controls.Add(Me.presentPriceTextBox)
        Me.presentPriceGroup.Controls.Add(Me.presentPriceTrackBar)
        Me.presentPriceGroup.Location = New System.Drawing.Point(6, 19)
        Me.presentPriceGroup.Name = "presentPriceGroup"
        Me.presentPriceGroup.Size = New System.Drawing.Size(329, 139)
        Me.presentPriceGroup.TabIndex = 22
        Me.presentPriceGroup.TabStop = False
        Me.presentPriceGroup.Text = "Relative Price"
        Me.presentPriceGroup.Visible = False
        '
        'presentPriceButton
        '
        Me.presentPriceButton.Location = New System.Drawing.Point(25, 104)
        Me.presentPriceButton.Name = "presentPriceButton"
        Me.presentPriceButton.Size = New System.Drawing.Size(98, 23)
        Me.presentPriceButton.TabIndex = 10
        Me.presentPriceButton.Text = "Set Price"
        Me.presentPriceButton.UseVisualStyleBackColor = True
        '
        'presentPriceTextBox
        '
        Me.presentPriceTextBox.Location = New System.Drawing.Point(15, 22)
        Me.presentPriceTextBox.MaxLength = 4
        Me.presentPriceTextBox.Name = "presentPriceTextBox"
        Me.presentPriceTextBox.ReadOnly = True
        Me.presentPriceTextBox.Size = New System.Drawing.Size(71, 20)
        Me.presentPriceTextBox.TabIndex = 9
        Me.presentPriceTextBox.Text = "0"
        Me.presentPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.presentPriceTextBox.WordWrap = False
        '
        'presentPriceTrackBar
        '
        Me.presentPriceTrackBar.Location = New System.Drawing.Point(12, 53)
        Me.presentPriceTrackBar.Maximum = 255
        Me.presentPriceTrackBar.Name = "presentPriceTrackBar"
        Me.presentPriceTrackBar.Size = New System.Drawing.Size(311, 45)
        Me.presentPriceTrackBar.TabIndex = 8
        '
        'requestPowerLevelTab
        '
        Me.requestPowerLevelTab.Controls.Add(Me.gbReqPowerLevel)
        Me.requestPowerLevelTab.Location = New System.Drawing.Point(4, 22)
        Me.requestPowerLevelTab.Name = "requestPowerLevelTab"
        Me.requestPowerLevelTab.Padding = New System.Windows.Forms.Padding(3)
        Me.requestPowerLevelTab.Size = New System.Drawing.Size(603, 275)
        Me.requestPowerLevelTab.TabIndex = 3
        Me.requestPowerLevelTab.Text = "Power Level"
        Me.requestPowerLevelTab.UseVisualStyleBackColor = True
        '
        'gbReqPowerLevel
        '
        Me.gbReqPowerLevel.Controls.Add(Me.rbAbsorbed)
        Me.gbReqPowerLevel.Controls.Add(Me.rbProduced)
        Me.gbReqPowerLevel.Controls.Add(Me.btnRPLAccept)
        Me.gbReqPowerLevel.Controls.Add(Me.tbPowerAP)
        Me.gbReqPowerLevel.Controls.Add(Me.tbarPower)
        Me.gbReqPowerLevel.Location = New System.Drawing.Point(6, 23)
        Me.gbReqPowerLevel.Name = "gbReqPowerLevel"
        Me.gbReqPowerLevel.Size = New System.Drawing.Size(260, 138)
        Me.gbReqPowerLevel.TabIndex = 13
        Me.gbReqPowerLevel.TabStop = False
        Me.gbReqPowerLevel.Text = "Request for Power Level"
        Me.gbReqPowerLevel.Visible = False
        '
        'rbAbsorbed
        '
        Me.rbAbsorbed.AutoSize = True
        Me.rbAbsorbed.Location = New System.Drawing.Point(168, 34)
        Me.rbAbsorbed.Name = "rbAbsorbed"
        Me.rbAbsorbed.Size = New System.Drawing.Size(70, 17)
        Me.rbAbsorbed.TabIndex = 9
        Me.rbAbsorbed.Text = "Absorbed"
        Me.rbAbsorbed.UseVisualStyleBackColor = True
        '
        'rbProduced
        '
        Me.rbProduced.AutoSize = True
        Me.rbProduced.Checked = True
        Me.rbProduced.Location = New System.Drawing.Point(168, 16)
        Me.rbProduced.Name = "rbProduced"
        Me.rbProduced.Size = New System.Drawing.Size(71, 17)
        Me.rbProduced.TabIndex = 8
        Me.rbProduced.TabStop = True
        Me.rbProduced.Text = "Produced"
        Me.rbProduced.UseVisualStyleBackColor = True
        '
        'btnRPLAccept
        '
        Me.btnRPLAccept.Location = New System.Drawing.Point(30, 104)
        Me.btnRPLAccept.Name = "btnRPLAccept"
        Me.btnRPLAccept.Size = New System.Drawing.Size(75, 23)
        Me.btnRPLAccept.TabIndex = 6
        Me.btnRPLAccept.Text = "Request Power Level"
        Me.btnRPLAccept.UseVisualStyleBackColor = True
        '
        'tbPowerAP
        '
        Me.tbPowerAP.Location = New System.Drawing.Point(22, 22)
        Me.tbPowerAP.MaxLength = 4
        Me.tbPowerAP.Name = "tbPowerAP"
        Me.tbPowerAP.ReadOnly = True
        Me.tbPowerAP.Size = New System.Drawing.Size(48, 20)
        Me.tbPowerAP.TabIndex = 5
        Me.tbPowerAP.Text = "0"
        Me.tbPowerAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbPowerAP.WordWrap = False
        '
        'tbarPower
        '
        Me.tbarPower.Location = New System.Drawing.Point(19, 53)
        Me.tbarPower.Maximum = 127
        Me.tbarPower.Name = "tbarPower"
        Me.tbarPower.Size = New System.Drawing.Size(234, 45)
        Me.tbarPower.TabIndex = 2
        '
        'timeRemainingTab
        '
        Me.timeRemainingTab.Controls.Add(Me.timeRemainingGroup)
        Me.timeRemainingTab.Location = New System.Drawing.Point(4, 22)
        Me.timeRemainingTab.Name = "timeRemainingTab"
        Me.timeRemainingTab.Padding = New System.Windows.Forms.Padding(3)
        Me.timeRemainingTab.Size = New System.Drawing.Size(603, 275)
        Me.timeRemainingTab.TabIndex = 4
        Me.timeRemainingTab.Text = "Time Remaining"
        Me.timeRemainingTab.UseVisualStyleBackColor = True
        '
        'timeRemainingGroup
        '
        Me.timeRemainingGroup.Controls.Add(Me.timeRemainingButton)
        Me.timeRemainingGroup.Controls.Add(Me.timeRemainingTextBox)
        Me.timeRemainingGroup.Controls.Add(Me.timeRemainingTrackBar)
        Me.timeRemainingGroup.Location = New System.Drawing.Point(6, 19)
        Me.timeRemainingGroup.Name = "timeRemainingGroup"
        Me.timeRemainingGroup.Size = New System.Drawing.Size(329, 138)
        Me.timeRemainingGroup.TabIndex = 39
        Me.timeRemainingGroup.TabStop = False
        Me.timeRemainingGroup.Text = "Duration"
        Me.timeRemainingGroup.Visible = False
        '
        'timeRemainingButton
        '
        Me.timeRemainingButton.Location = New System.Drawing.Point(22, 104)
        Me.timeRemainingButton.Name = "timeRemainingButton"
        Me.timeRemainingButton.Size = New System.Drawing.Size(116, 23)
        Me.timeRemainingButton.TabIndex = 10
        Me.timeRemainingButton.Text = "Set Time Remaining"
        Me.timeRemainingButton.UseVisualStyleBackColor = True
        '
        'timeRemainingTextBox
        '
        Me.timeRemainingTextBox.Location = New System.Drawing.Point(15, 22)
        Me.timeRemainingTextBox.MaxLength = 4
        Me.timeRemainingTextBox.Name = "timeRemainingTextBox"
        Me.timeRemainingTextBox.ReadOnly = True
        Me.timeRemainingTextBox.Size = New System.Drawing.Size(71, 20)
        Me.timeRemainingTextBox.TabIndex = 9
        Me.timeRemainingTextBox.Text = "0"
        Me.timeRemainingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.timeRemainingTextBox.WordWrap = False
        '
        'timeRemainingTrackBar
        '
        Me.timeRemainingTrackBar.Location = New System.Drawing.Point(12, 53)
        Me.timeRemainingTrackBar.Maximum = 255
        Me.timeRemainingTrackBar.Name = "timeRemainingTrackBar"
        Me.timeRemainingTrackBar.Size = New System.Drawing.Size(311, 45)
        Me.timeRemainingTrackBar.TabIndex = 8
        '
        'ucmQueryTab
        '
        Me.ucmQueryTab.Controls.Add(Me.currentStategb)
        Me.ucmQueryTab.Controls.Add(Me.gbQuery)
        Me.ucmQueryTab.Location = New System.Drawing.Point(4, 22)
        Me.ucmQueryTab.Name = "ucmQueryTab"
        Me.ucmQueryTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ucmQueryTab.Size = New System.Drawing.Size(623, 313)
        Me.ucmQueryTab.TabIndex = 1
        Me.ucmQueryTab.Text = "Query Operating State"
        Me.ucmQueryTab.UseVisualStyleBackColor = True
        '
        'currentStategb
        '
        Me.currentStategb.Controls.Add(Me.currentStatetb)
        Me.currentStategb.Location = New System.Drawing.Point(13, 88)
        Me.currentStategb.Name = "currentStategb"
        Me.currentStategb.Size = New System.Drawing.Size(174, 54)
        Me.currentStategb.TabIndex = 15
        Me.currentStategb.TabStop = False
        Me.currentStategb.Text = "SGD Curent State:"
        Me.currentStategb.Visible = False
        '
        'currentStatetb
        '
        Me.currentStatetb.BackColor = System.Drawing.Color.White
        Me.currentStatetb.Location = New System.Drawing.Point(6, 20)
        Me.currentStatetb.Name = "currentStatetb"
        Me.currentStatetb.ReadOnly = True
        Me.currentStatetb.Size = New System.Drawing.Size(162, 20)
        Me.currentStatetb.TabIndex = 0
        '
        'gbQuery
        '
        Me.gbQuery.Controls.Add(Me.pbOpState)
        Me.gbQuery.Location = New System.Drawing.Point(13, 15)
        Me.gbQuery.Name = "gbQuery"
        Me.gbQuery.Size = New System.Drawing.Size(174, 54)
        Me.gbQuery.TabIndex = 14
        Me.gbQuery.TabStop = False
        Me.gbQuery.Text = "Query"
        Me.gbQuery.Visible = False
        '
        'pbOpState
        '
        Me.pbOpState.Location = New System.Drawing.Point(6, 19)
        Me.pbOpState.Name = "pbOpState"
        Me.pbOpState.Size = New System.Drawing.Size(99, 23)
        Me.pbOpState.TabIndex = 0
        Me.pbOpState.Text = "Operating State"
        Me.pbOpState.UseVisualStyleBackColor = True
        '
        'ucmComStatusTab
        '
        Me.ucmComStatusTab.Controls.Add(Me.gbCommStatus)
        Me.ucmComStatusTab.Location = New System.Drawing.Point(4, 22)
        Me.ucmComStatusTab.Name = "ucmComStatusTab"
        Me.ucmComStatusTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ucmComStatusTab.Size = New System.Drawing.Size(623, 313)
        Me.ucmComStatusTab.TabIndex = 2
        Me.ucmComStatusTab.Text = "Comm Status"
        Me.ucmComStatusTab.UseVisualStyleBackColor = True
        '
        'gbCommStatus
        '
        Me.gbCommStatus.Controls.Add(Me.Button1)
        Me.gbCommStatus.Controls.Add(Me.cmbCommStatus)
        Me.gbCommStatus.Location = New System.Drawing.Point(23, 20)
        Me.gbCommStatus.Name = "gbCommStatus"
        Me.gbCommStatus.Size = New System.Drawing.Size(404, 53)
        Me.gbCommStatus.TabIndex = 15
        Me.gbCommStatus.TabStop = False
        Me.gbCommStatus.Text = "Comm Status"
        Me.gbCommStatus.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(235, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(140, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Send Comm Status"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbCommStatus
        '
        Me.cmbCommStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCommStatus.FormattingEnabled = True
        Me.cmbCommStatus.Items.AddRange(New Object() {"No / Lost Connection", "Found / Good Connection", "Poor / Unreliable Connection"})
        Me.cmbCommStatus.Location = New System.Drawing.Point(6, 16)
        Me.cmbCommStatus.Name = "cmbCommStatus"
        Me.cmbCommStatus.Size = New System.Drawing.Size(214, 21)
        Me.cmbCommStatus.TabIndex = 3
        '
        'ucmTimeSyncTab
        '
        Me.ucmTimeSyncTab.Controls.Add(Me.gbTimeSync)
        Me.ucmTimeSyncTab.Location = New System.Drawing.Point(4, 22)
        Me.ucmTimeSyncTab.Name = "ucmTimeSyncTab"
        Me.ucmTimeSyncTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ucmTimeSyncTab.Size = New System.Drawing.Size(623, 313)
        Me.ucmTimeSyncTab.TabIndex = 4
        Me.ucmTimeSyncTab.Text = "Time Sync"
        Me.ucmTimeSyncTab.UseVisualStyleBackColor = True
        '
        'gbTimeSync
        '
        Me.gbTimeSync.Controls.Add(Me.btnTimeSyncOff)
        Me.gbTimeSync.Controls.Add(Me.btnTimeSyncOn)
        Me.gbTimeSync.Location = New System.Drawing.Point(17, 18)
        Me.gbTimeSync.Name = "gbTimeSync"
        Me.gbTimeSync.Size = New System.Drawing.Size(277, 100)
        Me.gbTimeSync.TabIndex = 16
        Me.gbTimeSync.TabStop = False
        Me.gbTimeSync.Text = "Simple Time Sync"
        Me.gbTimeSync.Visible = False
        '
        'btnTimeSyncOff
        '
        Me.btnTimeSyncOff.Location = New System.Drawing.Point(119, 31)
        Me.btnTimeSyncOff.Name = "btnTimeSyncOff"
        Me.btnTimeSyncOff.Size = New System.Drawing.Size(98, 23)
        Me.btnTimeSyncOff.TabIndex = 1
        Me.btnTimeSyncOff.Text = "Disable"
        Me.btnTimeSyncOff.UseVisualStyleBackColor = True
        '
        'btnTimeSyncOn
        '
        Me.btnTimeSyncOn.Location = New System.Drawing.Point(6, 31)
        Me.btnTimeSyncOn.Name = "btnTimeSyncOn"
        Me.btnTimeSyncOn.Size = New System.Drawing.Size(98, 23)
        Me.btnTimeSyncOn.TabIndex = 0
        Me.btnTimeSyncOn.Text = "Enable"
        Me.btnTimeSyncOn.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.TabControl2)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(623, 313)
        Me.TabPage4.TabIndex = 8
        Me.TabPage4.Text = "Intermediate"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.ucmSetUTC)
        Me.TabControl2.Controls.Add(Me.ucmAutoCycling)
        Me.TabControl2.Location = New System.Drawing.Point(3, 3)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(614, 304)
        Me.TabControl2.TabIndex = 0
        '
        'ucmSetUTC
        '
        Me.ucmSetUTC.Controls.Add(Me.nudUTCOffset)
        Me.ucmSetUTC.Controls.Add(Me.nudDSTOffset)
        Me.ucmSetUTC.Controls.Add(Me.Label41)
        Me.ucmSetUTC.Controls.Add(Me.Label42)
        Me.ucmSetUTC.Controls.Add(Me.btnSetUTC)
        Me.ucmSetUTC.Location = New System.Drawing.Point(4, 22)
        Me.ucmSetUTC.Name = "ucmSetUTC"
        Me.ucmSetUTC.Padding = New System.Windows.Forms.Padding(3)
        Me.ucmSetUTC.Size = New System.Drawing.Size(606, 278)
        Me.ucmSetUTC.TabIndex = 0
        Me.ucmSetUTC.Text = "Set UTC"
        Me.ucmSetUTC.UseVisualStyleBackColor = True
        '
        'nudUTCOffset
        '
        Me.nudUTCOffset.Location = New System.Drawing.Point(125, 49)
        Me.nudUTCOffset.Maximum = New Decimal(New Integer() {48, 0, 0, 0})
        Me.nudUTCOffset.Minimum = New Decimal(New Integer() {48, 0, 0, -2147483648})
        Me.nudUTCOffset.Name = "nudUTCOffset"
        Me.nudUTCOffset.Size = New System.Drawing.Size(79, 20)
        Me.nudUTCOffset.TabIndex = 10
        '
        'nudDSTOffset
        '
        Me.nudDSTOffset.Location = New System.Drawing.Point(125, 8)
        Me.nudDSTOffset.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nudDSTOffset.Name = "nudDSTOffset"
        Me.nudDSTOffset.Size = New System.Drawing.Size(79, 20)
        Me.nudDSTOffset.TabIndex = 1
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(215, 51)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(140, 13)
        Me.Label41.TabIndex = 9
        Me.Label41.Text = "UTC offset in 15 min. blocks"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(215, 10)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(140, 13)
        Me.Label42.TabIndex = 7
        Me.Label42.Text = "DST offset in 15 min. blocks"
        '
        'btnSetUTC
        '
        Me.btnSetUTC.Location = New System.Drawing.Point(15, 11)
        Me.btnSetUTC.Name = "btnSetUTC"
        Me.btnSetUTC.Size = New System.Drawing.Size(91, 27)
        Me.btnSetUTC.TabIndex = 5
        Me.btnSetUTC.Text = "Set UTC Time"
        Me.btnSetUTC.UseVisualStyleBackColor = True
        '
        'ucmAutoCycling
        '
        Me.ucmAutoCycling.Controls.Add(Me.nudStopEndRand)
        Me.ucmAutoCycling.Controls.Add(Me.nudStopEventID)
        Me.ucmAutoCycling.Controls.Add(Me.nudEndRandomization)
        Me.ucmAutoCycling.Controls.Add(Me.nudStartRandomization)
        Me.ucmAutoCycling.Controls.Add(Me.Label28)
        Me.ucmAutoCycling.Controls.Add(Me.dtpStartTime)
        Me.ucmAutoCycling.Controls.Add(Me.nudDuration)
        Me.ucmAutoCycling.Controls.Add(Me.nudDutyCycle)
        Me.ucmAutoCycling.Controls.Add(Me.nudEventID)
        Me.ucmAutoCycling.Controls.Add(Me.btnStopCycling)
        Me.ucmAutoCycling.Controls.Add(Me.btnStartCycling)
        Me.ucmAutoCycling.Controls.Add(Me.Label29)
        Me.ucmAutoCycling.Controls.Add(Me.Label43)
        Me.ucmAutoCycling.Controls.Add(Me.Label44)
        Me.ucmAutoCycling.Controls.Add(Me.Label45)
        Me.ucmAutoCycling.Controls.Add(Me.Label46)
        Me.ucmAutoCycling.Controls.Add(Me.Label47)
        Me.ucmAutoCycling.Controls.Add(Me.Label48)
        Me.ucmAutoCycling.Location = New System.Drawing.Point(4, 22)
        Me.ucmAutoCycling.Name = "ucmAutoCycling"
        Me.ucmAutoCycling.Padding = New System.Windows.Forms.Padding(3)
        Me.ucmAutoCycling.Size = New System.Drawing.Size(606, 278)
        Me.ucmAutoCycling.TabIndex = 1
        Me.ucmAutoCycling.Text = "Autonomous Cycling"
        Me.ucmAutoCycling.UseVisualStyleBackColor = True
        '
        'nudStopEndRand
        '
        Me.nudStopEndRand.Location = New System.Drawing.Point(341, 65)
        Me.nudStopEndRand.Name = "nudStopEndRand"
        Me.nudStopEndRand.Size = New System.Drawing.Size(120, 20)
        Me.nudStopEndRand.TabIndex = 62
        '
        'nudStopEventID
        '
        Me.nudStopEventID.Location = New System.Drawing.Point(341, 17)
        Me.nudStopEventID.Maximum = New Decimal(New Integer() {-1, 0, 0, 0})
        Me.nudStopEventID.Name = "nudStopEventID"
        Me.nudStopEventID.Size = New System.Drawing.Size(120, 20)
        Me.nudStopEventID.TabIndex = 61
        '
        'nudEndRandomization
        '
        Me.nudEndRandomization.Location = New System.Drawing.Point(40, 241)
        Me.nudEndRandomization.Name = "nudEndRandomization"
        Me.nudEndRandomization.Size = New System.Drawing.Size(120, 20)
        Me.nudEndRandomization.TabIndex = 60
        '
        'nudStartRandomization
        '
        Me.nudStartRandomization.Location = New System.Drawing.Point(40, 195)
        Me.nudStartRandomization.Name = "nudStartRandomization"
        Me.nudStartRandomization.Size = New System.Drawing.Size(120, 20)
        Me.nudStartRandomization.TabIndex = 59
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(41, 45)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(55, 13)
        Me.Label28.TabIndex = 56
        Me.Label28.Text = "Start Time"
        '
        'dtpStartTime
        '
        Me.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartTime.Location = New System.Drawing.Point(41, 62)
        Me.dtpStartTime.Name = "dtpStartTime"
        Me.dtpStartTime.ShowUpDown = True
        Me.dtpStartTime.Size = New System.Drawing.Size(139, 20)
        Me.dtpStartTime.TabIndex = 55
        '
        'nudDuration
        '
        Me.nudDuration.Location = New System.Drawing.Point(41, 104)
        Me.nudDuration.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudDuration.Name = "nudDuration"
        Me.nudDuration.Size = New System.Drawing.Size(96, 20)
        Me.nudDuration.TabIndex = 52
        '
        'nudDutyCycle
        '
        Me.nudDutyCycle.Location = New System.Drawing.Point(41, 152)
        Me.nudDutyCycle.Name = "nudDutyCycle"
        Me.nudDutyCycle.Size = New System.Drawing.Size(75, 20)
        Me.nudDutyCycle.TabIndex = 51
        '
        'nudEventID
        '
        Me.nudEventID.Location = New System.Drawing.Point(41, 17)
        Me.nudEventID.Maximum = New Decimal(New Integer() {-1, 0, 0, 0})
        Me.nudEventID.Name = "nudEventID"
        Me.nudEventID.Size = New System.Drawing.Size(120, 20)
        Me.nudEventID.TabIndex = 50
        '
        'btnStopCycling
        '
        Me.btnStopCycling.Location = New System.Drawing.Point(490, 1)
        Me.btnStopCycling.Name = "btnStopCycling"
        Me.btnStopCycling.Size = New System.Drawing.Size(79, 27)
        Me.btnStopCycling.TabIndex = 49
        Me.btnStopCycling.Text = "Stop Cycling"
        Me.btnStopCycling.UseVisualStyleBackColor = True
        '
        'btnStartCycling
        '
        Me.btnStartCycling.Location = New System.Drawing.Point(186, 1)
        Me.btnStartCycling.Name = "btnStartCycling"
        Me.btnStartCycling.Size = New System.Drawing.Size(80, 28)
        Me.btnStartCycling.TabIndex = 41
        Me.btnStartCycling.Text = "Start Cycling"
        Me.btnStartCycling.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(339, 49)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(129, 13)
        Me.Label29.TabIndex = 48
        Me.Label29.Text = "End Randomization (mins)"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(37, 1)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(49, 13)
        Me.Label43.TabIndex = 42
        Me.Label43.Text = "Event ID"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(37, 88)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(77, 13)
        Me.Label44.TabIndex = 43
        Me.Label44.Text = "Duration (mins)"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(338, 1)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(49, 13)
        Me.Label45.TabIndex = 47
        Me.Label45.Text = "Event ID"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(37, 133)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(75, 13)
        Me.Label46.TabIndex = 44
        Me.Label46.Text = "Duty Cycle (%)"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(38, 179)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(202, 13)
        Me.Label47.TabIndex = 45
        Me.Label47.Text = "Start Randomization (mins) - 0 = Not used"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(38, 225)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(199, 13)
        Me.Label48.TabIndex = 46
        Me.Label48.Text = "End Randomization (mins) - 0 = Not used"
        '
        'sgdTab
        '
        Me.sgdTab.Controls.Add(Me.sgdTabControl)
        Me.sgdTab.Location = New System.Drawing.Point(4, 22)
        Me.sgdTab.Name = "sgdTab"
        Me.sgdTab.Padding = New System.Windows.Forms.Padding(3)
        Me.sgdTab.Size = New System.Drawing.Size(643, 351)
        Me.sgdTab.TabIndex = 1
        Me.sgdTab.Text = "SGD Commands"
        Me.sgdTab.UseVisualStyleBackColor = True
        '
        'TestScripts
        '
        Me.TestScripts.Controls.Add(Me.Label10)
        Me.TestScripts.Controls.Add(Me.scriptFeedBox)
        Me.TestScripts.Controls.Add(Me.testScriptbtn)
        Me.TestScripts.Controls.Add(Me.pbManualFail)
        Me.TestScripts.Controls.Add(Me.pbManualPass)
        Me.TestScripts.Controls.Add(Me.pbManCont)
        Me.TestScripts.Controls.Add(Me.pbKillScript)
        Me.TestScripts.Controls.Add(Me.pbExecuteScript)
        Me.TestScripts.Controls.Add(Me.pbOpenScript)
        Me.TestScripts.Controls.Add(Me.tbScriptFile)
        Me.TestScripts.Location = New System.Drawing.Point(4, 22)
        Me.TestScripts.Name = "TestScripts"
        Me.TestScripts.Size = New System.Drawing.Size(643, 351)
        Me.TestScripts.TabIndex = 4
        Me.TestScripts.Text = "Test Scripts"
        Me.TestScripts.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(125, 157)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Script Feed"
        '
        'scriptFeedBox
        '
        Me.scriptFeedBox.BackColor = System.Drawing.Color.White
        Me.scriptFeedBox.ForeColor = System.Drawing.SystemColors.WindowText
        Me.scriptFeedBox.Location = New System.Drawing.Point(145, 173)
        Me.scriptFeedBox.Name = "scriptFeedBox"
        Me.scriptFeedBox.ReadOnly = True
        Me.scriptFeedBox.Size = New System.Drawing.Size(335, 135)
        Me.scriptFeedBox.TabIndex = 11
        Me.scriptFeedBox.Text = ""
        '
        'testScriptbtn
        '
        Me.testScriptbtn.Enabled = False
        Me.testScriptbtn.Location = New System.Drawing.Point(502, 108)
        Me.testScriptbtn.Name = "testScriptbtn"
        Me.testScriptbtn.Size = New System.Drawing.Size(92, 24)
        Me.testScriptbtn.TabIndex = 10
        Me.testScriptbtn.Text = "Test Script"
        Me.testScriptbtn.UseVisualStyleBackColor = True
        '
        'pbManualFail
        '
        Me.pbManualFail.Location = New System.Drawing.Point(502, 220)
        Me.pbManualFail.Name = "pbManualFail"
        Me.pbManualFail.Size = New System.Drawing.Size(92, 41)
        Me.pbManualFail.TabIndex = 8
        Me.pbManualFail.Text = "Manual Fail"
        Me.pbManualFail.UseVisualStyleBackColor = True
        '
        'pbManualPass
        '
        Me.pbManualPass.Location = New System.Drawing.Point(502, 173)
        Me.pbManualPass.Name = "pbManualPass"
        Me.pbManualPass.Size = New System.Drawing.Size(92, 41)
        Me.pbManualPass.TabIndex = 7
        Me.pbManualPass.Text = "Manual Pass"
        Me.pbManualPass.UseVisualStyleBackColor = True
        '
        'pbManCont
        '
        Me.pbManCont.Location = New System.Drawing.Point(502, 267)
        Me.pbManCont.Name = "pbManCont"
        Me.pbManCont.Size = New System.Drawing.Size(92, 41)
        Me.pbManCont.TabIndex = 6
        Me.pbManCont.Text = "Manual Continue"
        Me.pbManCont.UseVisualStyleBackColor = True
        '
        'pbKillScript
        '
        Me.pbKillScript.Enabled = False
        Me.pbKillScript.Location = New System.Drawing.Point(502, 78)
        Me.pbKillScript.Name = "pbKillScript"
        Me.pbKillScript.Size = New System.Drawing.Size(92, 24)
        Me.pbKillScript.TabIndex = 5
        Me.pbKillScript.Text = "Kill Script"
        Me.pbKillScript.UseVisualStyleBackColor = True
        '
        'pbExecuteScript
        '
        Me.pbExecuteScript.Enabled = False
        Me.pbExecuteScript.Location = New System.Drawing.Point(502, 48)
        Me.pbExecuteScript.Name = "pbExecuteScript"
        Me.pbExecuteScript.Size = New System.Drawing.Size(92, 25)
        Me.pbExecuteScript.TabIndex = 2
        Me.pbExecuteScript.Text = "Execute Script"
        Me.pbExecuteScript.UseVisualStyleBackColor = True
        '
        'pbOpenScript
        '
        Me.pbOpenScript.Location = New System.Drawing.Point(502, 18)
        Me.pbOpenScript.Name = "pbOpenScript"
        Me.pbOpenScript.Size = New System.Drawing.Size(92, 23)
        Me.pbOpenScript.TabIndex = 1
        Me.pbOpenScript.Text = "Open Script"
        Me.pbOpenScript.UseVisualStyleBackColor = True
        '
        'tbScriptFile
        '
        Me.tbScriptFile.Enabled = False
        Me.tbScriptFile.Location = New System.Drawing.Point(145, 20)
        Me.tbScriptFile.Name = "tbScriptFile"
        Me.tbScriptFile.Size = New System.Drawing.Size(335, 20)
        Me.tbScriptFile.TabIndex = 0
        '
        'realDeviceTab
        '
        Me.realDeviceTab.Controls.Add(Me.realDeviceTabControl)
        Me.realDeviceTab.Location = New System.Drawing.Point(4, 22)
        Me.realDeviceTab.Name = "realDeviceTab"
        Me.realDeviceTab.Padding = New System.Windows.Forms.Padding(3)
        Me.realDeviceTab.Size = New System.Drawing.Size(643, 351)
        Me.realDeviceTab.TabIndex = 5
        Me.realDeviceTab.Text = "Real Device Options"
        Me.realDeviceTab.UseVisualStyleBackColor = True
        '
        'realDeviceTabControl
        '
        Me.realDeviceTabControl.Controls.Add(Me.commonRealFunctionsTab)
        Me.realDeviceTabControl.Controls.Add(Me.realUCMFunctionsTab)
        Me.realDeviceTabControl.Controls.Add(Me.realSGDFunctionsTab)
        Me.realDeviceTabControl.Location = New System.Drawing.Point(6, 6)
        Me.realDeviceTabControl.Name = "realDeviceTabControl"
        Me.realDeviceTabControl.SelectedIndex = 0
        Me.realDeviceTabControl.Size = New System.Drawing.Size(631, 339)
        Me.realDeviceTabControl.TabIndex = 0
        '
        'commonRealFunctionsTab
        '
        Me.commonRealFunctionsTab.Controls.Add(Me.realCommonFunctionsGroup)
        Me.commonRealFunctionsTab.Location = New System.Drawing.Point(4, 22)
        Me.commonRealFunctionsTab.Name = "commonRealFunctionsTab"
        Me.commonRealFunctionsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.commonRealFunctionsTab.Size = New System.Drawing.Size(623, 313)
        Me.commonRealFunctionsTab.TabIndex = 0
        Me.commonRealFunctionsTab.Text = "Common Functions"
        Me.commonRealFunctionsTab.UseVisualStyleBackColor = True
        '
        'realCommonFunctionsGroup
        '
        Me.realCommonFunctionsGroup.Controls.Add(Me.realDeviceCommandRetrycb)
        Me.realCommonFunctionsGroup.Controls.Add(Me.Label84)
        Me.realCommonFunctionsGroup.Controls.Add(Me.Label83)
        Me.realCommonFunctionsGroup.Controls.Add(Me.realDeviceIgnoreMaxPayloadCheckBox)
        Me.realCommonFunctionsGroup.Location = New System.Drawing.Point(6, 6)
        Me.realCommonFunctionsGroup.Name = "realCommonFunctionsGroup"
        Me.realCommonFunctionsGroup.Size = New System.Drawing.Size(611, 301)
        Me.realCommonFunctionsGroup.TabIndex = 0
        Me.realCommonFunctionsGroup.TabStop = False
        '
        'realDeviceCommandRetrycb
        '
        Me.realDeviceCommandRetrycb.AutoSize = True
        Me.realDeviceCommandRetrycb.Location = New System.Drawing.Point(220, 86)
        Me.realDeviceCommandRetrycb.Name = "realDeviceCommandRetrycb"
        Me.realDeviceCommandRetrycb.Size = New System.Drawing.Size(15, 14)
        Me.realDeviceCommandRetrycb.TabIndex = 3
        Me.realDeviceCommandRetrycb.UseVisualStyleBackColor = True
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Location = New System.Drawing.Point(44, 86)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(121, 13)
        Me.Label84.TabIndex = 2
        Me.Label84.Text = "Command Retry Enable:"
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(44, 49)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(148, 13)
        Me.Label83.TabIndex = 1
        Me.Label83.Text = "Ignore Maximum Payload Size"
        '
        'realDeviceIgnoreMaxPayloadCheckBox
        '
        Me.realDeviceIgnoreMaxPayloadCheckBox.AutoSize = True
        Me.realDeviceIgnoreMaxPayloadCheckBox.Location = New System.Drawing.Point(220, 48)
        Me.realDeviceIgnoreMaxPayloadCheckBox.Name = "realDeviceIgnoreMaxPayloadCheckBox"
        Me.realDeviceIgnoreMaxPayloadCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.realDeviceIgnoreMaxPayloadCheckBox.TabIndex = 0
        Me.realDeviceIgnoreMaxPayloadCheckBox.UseVisualStyleBackColor = True
        '
        'realUCMFunctionsTab
        '
        Me.realUCMFunctionsTab.Controls.Add(Me.realUCMFunctionsGroup)
        Me.realUCMFunctionsTab.Location = New System.Drawing.Point(4, 22)
        Me.realUCMFunctionsTab.Name = "realUCMFunctionsTab"
        Me.realUCMFunctionsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.realUCMFunctionsTab.Size = New System.Drawing.Size(623, 313)
        Me.realUCMFunctionsTab.TabIndex = 1
        Me.realUCMFunctionsTab.Text = "UCM Functions"
        Me.realUCMFunctionsTab.UseVisualStyleBackColor = True
        '
        'realUCMFunctionsGroup
        '
        Me.realUCMFunctionsGroup.Controls.Add(Me.realUCMTrasmissionIntervalBox)
        Me.realUCMFunctionsGroup.Controls.Add(Me.Label76)
        Me.realUCMFunctionsGroup.Controls.Add(Me.Label75)
        Me.realUCMFunctionsGroup.Controls.Add(Me.realUCMCommStatusBox)
        Me.realUCMFunctionsGroup.Location = New System.Drawing.Point(6, 6)
        Me.realUCMFunctionsGroup.Name = "realUCMFunctionsGroup"
        Me.realUCMFunctionsGroup.Size = New System.Drawing.Size(611, 304)
        Me.realUCMFunctionsGroup.TabIndex = 0
        Me.realUCMFunctionsGroup.TabStop = False
        '
        'realUCMTrasmissionIntervalBox
        '
        Me.realUCMTrasmissionIntervalBox.Location = New System.Drawing.Point(193, 91)
        Me.realUCMTrasmissionIntervalBox.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.realUCMTrasmissionIntervalBox.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.realUCMTrasmissionIntervalBox.Name = "realUCMTrasmissionIntervalBox"
        Me.realUCMTrasmissionIntervalBox.Size = New System.Drawing.Size(180, 20)
        Me.realUCMTrasmissionIntervalBox.TabIndex = 3
        Me.realUCMTrasmissionIntervalBox.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(47, 93)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(135, 13)
        Me.Label76.TabIndex = 2
        Me.Label76.Text = "Transmission Interval (sec):"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(47, 48)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(124, 13)
        Me.Label75.TabIndex = 1
        Me.Label75.Text = "Comm Status to be Sent:"
        '
        'realUCMCommStatusBox
        '
        Me.realUCMCommStatusBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.realUCMCommStatusBox.FormattingEnabled = True
        Me.realUCMCommStatusBox.Items.AddRange(New Object() {"Manual", "No / Lost Connection", "Found / Good Connection", "Poor / Unreliable Connection"})
        Me.realUCMCommStatusBox.Location = New System.Drawing.Point(193, 45)
        Me.realUCMCommStatusBox.Name = "realUCMCommStatusBox"
        Me.realUCMCommStatusBox.Size = New System.Drawing.Size(180, 21)
        Me.realUCMCommStatusBox.TabIndex = 0
        '
        'realSGDFunctionsTab
        '
        Me.realSGDFunctionsTab.Controls.Add(Me.realSGDFunctionsGroup)
        Me.realSGDFunctionsTab.Location = New System.Drawing.Point(4, 22)
        Me.realSGDFunctionsTab.Name = "realSGDFunctionsTab"
        Me.realSGDFunctionsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.realSGDFunctionsTab.Size = New System.Drawing.Size(623, 313)
        Me.realSGDFunctionsTab.TabIndex = 2
        Me.realSGDFunctionsTab.Text = "SGD Functions"
        Me.realSGDFunctionsTab.UseVisualStyleBackColor = True
        '
        'realSGDFunctionsGroup
        '
        Me.realSGDFunctionsGroup.Controls.Add(Me.realSGDNoCommTimeoutEnabledbtn)
        Me.realSGDFunctionsGroup.Controls.Add(Me.realSGDNoCommTimeoutValBox)
        Me.realSGDFunctionsGroup.Controls.Add(Me.Label85)
        Me.realSGDFunctionsGroup.Controls.Add(Me.Label82)
        Me.realSGDFunctionsGroup.Controls.Add(Me.realSGDNeutralResponse)
        Me.realSGDFunctionsGroup.Controls.Add(Me.Label81)
        Me.realSGDFunctionsGroup.Controls.Add(Me.realSGDBadTimeResponse)
        Me.realSGDFunctionsGroup.Controls.Add(Me.Label80)
        Me.realSGDFunctionsGroup.Controls.Add(Me.realSGDGoodTimeResponse)
        Me.realSGDFunctionsGroup.Controls.Add(Me.Label79)
        Me.realSGDFunctionsGroup.Controls.Add(Me.realSGDEmergencyResponse)
        Me.realSGDFunctionsGroup.Controls.Add(Me.Label77)
        Me.realSGDFunctionsGroup.Controls.Add(Me.Label78)
        Me.realSGDFunctionsGroup.Controls.Add(Me.realSGDLoadUpResponse)
        Me.realSGDFunctionsGroup.Controls.Add(Me.realSGDEndShedResponse)
        Me.realSGDFunctionsGroup.Controls.Add(Me.Label74)
        Me.realSGDFunctionsGroup.Controls.Add(Me.Label73)
        Me.realSGDFunctionsGroup.Controls.Add(Me.Label72)
        Me.realSGDFunctionsGroup.Controls.Add(Me.realSGDCritPeakResponse)
        Me.realSGDFunctionsGroup.Controls.Add(Me.realSGDShedResponse)
        Me.realSGDFunctionsGroup.Controls.Add(Me.internalClockSupportedcb)
        Me.realSGDFunctionsGroup.Location = New System.Drawing.Point(6, 6)
        Me.realSGDFunctionsGroup.Name = "realSGDFunctionsGroup"
        Me.realSGDFunctionsGroup.Size = New System.Drawing.Size(611, 301)
        Me.realSGDFunctionsGroup.TabIndex = 3
        Me.realSGDFunctionsGroup.TabStop = False
        '
        'realSGDNoCommTimeoutEnabledbtn
        '
        Me.realSGDNoCommTimeoutEnabledbtn.Location = New System.Drawing.Point(324, 264)
        Me.realSGDNoCommTimeoutEnabledbtn.Name = "realSGDNoCommTimeoutEnabledbtn"
        Me.realSGDNoCommTimeoutEnabledbtn.Size = New System.Drawing.Size(75, 20)
        Me.realSGDNoCommTimeoutEnabledbtn.TabIndex = 19
        Me.realSGDNoCommTimeoutEnabledbtn.Text = "Enable"
        Me.realSGDNoCommTimeoutEnabledbtn.UseVisualStyleBackColor = True
        '
        'realSGDNoCommTimeoutValBox
        '
        Me.realSGDNoCommTimeoutValBox.Location = New System.Drawing.Point(206, 264)
        Me.realSGDNoCommTimeoutValBox.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.realSGDNoCommTimeoutValBox.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.realSGDNoCommTimeoutValBox.Name = "realSGDNoCommTimeoutValBox"
        Me.realSGDNoCommTimeoutValBox.Size = New System.Drawing.Size(97, 20)
        Me.realSGDNoCommTimeoutValBox.TabIndex = 17
        Me.realSGDNoCommTimeoutValBox.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(46, 266)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(139, 13)
        Me.Label85.TabIndex = 16
        Me.Label85.Text = "Comm Status Timeout (sec):"
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(46, 240)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(115, 13)
        Me.Label82.TabIndex = 15
        Me.Label82.Text = "Neutral Grid Guidance:"
        '
        'realSGDNeutralResponse
        '
        Me.realSGDNeutralResponse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.realSGDNeutralResponse.FormattingEnabled = True
        Me.realSGDNeutralResponse.Items.AddRange(New Object() {"Manual", "Pre-guidance"})
        Me.realSGDNeutralResponse.Location = New System.Drawing.Point(206, 237)
        Me.realSGDNeutralResponse.Name = "realSGDNeutralResponse"
        Me.realSGDNeutralResponse.Size = New System.Drawing.Size(352, 21)
        Me.realSGDNeutralResponse.TabIndex = 14
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(46, 213)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(126, 13)
        Me.Label81.TabIndex = 13
        Me.Label81.Text = "Bad Time Grid Guidance:"
        '
        'realSGDBadTimeResponse
        '
        Me.realSGDBadTimeResponse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.realSGDBadTimeResponse.FormattingEnabled = True
        Me.realSGDBadTimeResponse.Items.AddRange(New Object() {"Manual", "Not supported", "Running Curtailed Grid/ Running Normal if override is set", "Idle Grid/ Idle Normal if override is set", "SGD Error Condition"})
        Me.realSGDBadTimeResponse.Location = New System.Drawing.Point(206, 210)
        Me.realSGDBadTimeResponse.Name = "realSGDBadTimeResponse"
        Me.realSGDBadTimeResponse.Size = New System.Drawing.Size(352, 21)
        Me.realSGDBadTimeResponse.TabIndex = 12
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Location = New System.Drawing.Point(46, 186)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(133, 13)
        Me.Label80.TabIndex = 11
        Me.Label80.Text = "Good Time Grid Guidance:"
        '
        'realSGDGoodTimeResponse
        '
        Me.realSGDGoodTimeResponse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.realSGDGoodTimeResponse.FormattingEnabled = True
        Me.realSGDGoodTimeResponse.Items.AddRange(New Object() {"Manual", "Not supported", "Running Normal", "Running Idle", "SGD Error Condition"})
        Me.realSGDGoodTimeResponse.Location = New System.Drawing.Point(206, 183)
        Me.realSGDGoodTimeResponse.Name = "realSGDGoodTimeResponse"
        Me.realSGDGoodTimeResponse.Size = New System.Drawing.Size(352, 21)
        Me.realSGDGoodTimeResponse.TabIndex = 10
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(46, 159)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(136, 13)
        Me.Label79.TabIndex = 9
        Me.Label79.Text = "Grid Emergency Response:"
        '
        'realSGDEmergencyResponse
        '
        Me.realSGDEmergencyResponse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.realSGDEmergencyResponse.FormattingEnabled = True
        Me.realSGDEmergencyResponse.Items.AddRange(New Object() {"Manual", "Not Supported", "Running Curtailed Grid/ Running Normal if override is set", "Idle Grid/ Idle Normal if override is set", "SGD Error Condition"})
        Me.realSGDEmergencyResponse.Location = New System.Drawing.Point(206, 156)
        Me.realSGDEmergencyResponse.Name = "realSGDEmergencyResponse"
        Me.realSGDEmergencyResponse.Size = New System.Drawing.Size(352, 21)
        Me.realSGDEmergencyResponse.TabIndex = 8
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(46, 132)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(102, 13)
        Me.Label77.TabIndex = 7
        Me.Label77.Text = "Load Up Response:"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(46, 78)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(158, 13)
        Me.Label78.TabIndex = 6
        Me.Label78.Text = "End Shed Command Response:"
        '
        'realSGDLoadUpResponse
        '
        Me.realSGDLoadUpResponse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.realSGDLoadUpResponse.FormattingEnabled = True
        Me.realSGDLoadUpResponse.Items.AddRange(New Object() {"Manual", "Not Supported", "Running Normal", "Idle Normal", "SGD Error Condition"})
        Me.realSGDLoadUpResponse.Location = New System.Drawing.Point(206, 129)
        Me.realSGDLoadUpResponse.Name = "realSGDLoadUpResponse"
        Me.realSGDLoadUpResponse.Size = New System.Drawing.Size(352, 21)
        Me.realSGDLoadUpResponse.TabIndex = 4
        '
        'realSGDEndShedResponse
        '
        Me.realSGDEndShedResponse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.realSGDEndShedResponse.FormattingEnabled = True
        Me.realSGDEndShedResponse.Items.AddRange(New Object() {"Manual", "Running Normal", "Idle Normal", "Pre-Shed state (either Running Normal or Idle Normal)", "SGD Error Condition"})
        Me.realSGDEndShedResponse.Location = New System.Drawing.Point(206, 75)
        Me.realSGDEndShedResponse.Name = "realSGDEndShedResponse"
        Me.realSGDEndShedResponse.Size = New System.Drawing.Size(352, 21)
        Me.realSGDEndShedResponse.TabIndex = 5
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(46, 105)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(120, 13)
        Me.Label74.TabIndex = 3
        Me.Label74.Text = "Critical Peak Response:"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(46, 51)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(136, 13)
        Me.Label73.TabIndex = 2
        Me.Label73.Text = "Shed Command Response:"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(46, 20)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(101, 13)
        Me.Label72.TabIndex = 1
        Me.Label72.Text = "SGD Internal Clock:"
        '
        'realSGDCritPeakResponse
        '
        Me.realSGDCritPeakResponse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.realSGDCritPeakResponse.FormattingEnabled = True
        Me.realSGDCritPeakResponse.Items.AddRange(New Object() {"Manual", "Not Supported", "Running Curtailed Grid/ Running Normal (if override is set)", "Idle Grid/ Idle Normal (if override is set)", "SGD Error Condition"})
        Me.realSGDCritPeakResponse.Location = New System.Drawing.Point(206, 102)
        Me.realSGDCritPeakResponse.Name = "realSGDCritPeakResponse"
        Me.realSGDCritPeakResponse.Size = New System.Drawing.Size(352, 21)
        Me.realSGDCritPeakResponse.TabIndex = 0
        '
        'realSGDShedResponse
        '
        Me.realSGDShedResponse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.realSGDShedResponse.FormattingEnabled = True
        Me.realSGDShedResponse.Items.AddRange(New Object() {"Manual", "Running Curtailed Grid/ Running Normal (if override is set)", "Idle Grid/ Idle Normal (if override is set)", "SGD Error Condition"})
        Me.realSGDShedResponse.Location = New System.Drawing.Point(206, 48)
        Me.realSGDShedResponse.Name = "realSGDShedResponse"
        Me.realSGDShedResponse.Size = New System.Drawing.Size(352, 21)
        Me.realSGDShedResponse.TabIndex = 0
        '
        'internalClockSupportedcb
        '
        Me.internalClockSupportedcb.AccessibleDescription = "If unchecked, device will not terminate shed commands, et. when time expires"
        Me.internalClockSupportedcb.AutoSize = True
        Me.internalClockSupportedcb.Location = New System.Drawing.Point(206, 19)
        Me.internalClockSupportedcb.Name = "internalClockSupportedcb"
        Me.internalClockSupportedcb.Size = New System.Drawing.Size(75, 17)
        Me.internalClockSupportedcb.TabIndex = 0
        Me.internalClockSupportedcb.Text = "Supported"
        Me.internalClockSupportedcb.UseVisualStyleBackColor = True
        '
        'tmrProcessComm
        '
        Me.tmrProcessComm.Interval = 1
        '
        'pbCommRefresh
        '
        Me.pbCommRefresh.Location = New System.Drawing.Point(93, 94)
        Me.pbCommRefresh.Name = "pbCommRefresh"
        Me.pbCommRefresh.Size = New System.Drawing.Size(75, 23)
        Me.pbCommRefresh.TabIndex = 41
        Me.pbCommRefresh.Text = "Refresh"
        Me.pbCommRefresh.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAbout})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1162, 24)
        Me.MenuStrip1.TabIndex = 42
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmAbout
        '
        Me.tsmAbout.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2})
        Me.tsmAbout.Name = "tsmAbout"
        Me.tsmAbout.Size = New System.Drawing.Size(52, 20)
        Me.tsmAbout.Text = "About"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(112, 22)
        Me.ToolStripMenuItem2.Text = "Version"
        '
        'fbdScriptFileSelect
        '
        Me.fbdScriptFileSelect.FileName = "OpenFileDialog1"
        '
        'cbResponseSim
        '
        Me.cbResponseSim.AutoSize = True
        Me.cbResponseSim.Location = New System.Drawing.Point(235, 98)
        Me.cbResponseSim.Name = "cbResponseSim"
        Me.cbResponseSim.Size = New System.Drawing.Size(166, 17)
        Me.cbResponseSim.TabIndex = 43
        Me.cbResponseSim.Text = "Real Device Simulation Mode"
        Me.cbResponseSim.UseVisualStyleBackColor = True
        '
        'autoCommStatusTimer
        '
        '
        'commStatusTimoutTmr
        '
        Me.commStatusTimoutTmr.Interval = 1000
        '
        'shedEventTimer
        '
        Me.shedEventTimer.Interval = 1000
        '
        'loadUpEventTimer
        '
        Me.loadUpEventTimer.Interval = 1000
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1162, 564)
        Me.Controls.Add(Me.cbResponseSim)
        Me.Controls.Add(Me.pbCommRefresh)
        Me.Controls.Add(Me.simulatorDeviceTypeTabControl)
        Me.Controls.Add(Me.logFile)
        Me.Controls.Add(Me.rbMode2)
        Me.Controls.Add(Me.rbMode1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnDisconnect)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.CmbBaud)
        Me.Controls.Add(Me.CmbPort)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.Text = "CTA-2045 Simulator"
        Me.GroupBox2.ResumeLayout(False)
        Me.grpChangeBaud.ResumeLayout(False)
        Me.gbErrors.ResumeLayout(False)
        Me.gbErrors.PerformLayout()
        CType(Me.nudAppNakRtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNakRtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSGDConfig.ResumeLayout(False)
        Me.grpSGDConfig.PerformLayout()
        Me.grpOpState.ResumeLayout(False)
        Me.logFile.ResumeLayout(False)
        Me.logFile.PerformLayout()
        Me.sgdTabControl.ResumeLayout(False)
        Me.sgdOpStateTab.ResumeLayout(False)
        Me.GetUtc.ResumeLayout(False)
        Me.simulatorDeviceTypeTabControl.ResumeLayout(False)
        Me.deviceInfoTab.ResumeLayout(False)
        Me.deviceInfoTabControl.ResumeLayout(False)
        Me.generalInfoTab.ResumeLayout(False)
        Me.generalInfoTab.PerformLayout()
        CType(Me.nudCapBitMap3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCapBitMap2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCapBitMap1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCapBitMap0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDevRevLSB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDevRevMSB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudVendorIDLSB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudVendorIDMSB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFirmwareMinor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFirmwareMajor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.getDeviceInfo.ResumeLayout(False)
        Me.getDeviceInfo.PerformLayout()
        Me.msgTypeSupportedTab.ResumeLayout(False)
        Me.msgSupportQuery.ResumeLayout(False)
        Me.msgSupportQuery.PerformLayout()
        CType(Me.nudSupMsgQueryLSB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSupMsgQueryMSB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msgSupportedBox.ResumeLayout(False)
        Me.msgSupportedBox.PerformLayout()
        CType(Me.nudMsgSuppLSB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMsgSuppMSB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.setMaxPayloadTab.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tempF.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.nudPresentTemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.nudSetpointDeviceType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.nudTempOffset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.nudSetPoint1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSetPoint2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.commodity.ResumeLayout(False)
        Me.cdCommodityGb.ResumeLayout(False)
        Me.cdCommodityGb.PerformLayout()
        Me.tdCommodityCodes.ResumeLayout(False)
        Me.tdCommodityCodes.PerformLayout()
        CType(Me.nudCommodityFreq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCommodityRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCommodityAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.getSet.ResumeLayout(False)
        Me.commonCommandsTab.ResumeLayout(False)
        Me.commonCommandsTabControl.ResumeLayout(False)
        Me.changeBaudTab.ResumeLayout(False)
        Me.simulateErrorsTab.ResumeLayout(False)
        Me.opcodeErrorsGroup.ResumeLayout(False)
        Me.opcodeErrorsGroup.PerformLayout()
        CType(Me.customLength2ValBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.customLength1ValBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.customMsgType2ValBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.customMsgType1ValBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.badOpcode2valbox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.badOpcode1valbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TimingTab.ResumeLayout(False)
        Me.TimingTab.PerformLayout()
        CType(Me.tMLValBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tIMValBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tRAValBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tARValBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tMAValBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PassThrough.ResumeLayout(False)
        Me.PassThrough.PerformLayout()
        Me.ucmTab.ResumeLayout(False)
        Me.ucmTabControl.ResumeLayout(False)
        Me.ucmManageDeviceTab.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.shedLoadTab.ResumeLayout(False)
        Me.shedLoadTab.PerformLayout()
        CType(Me.trkShedDur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gridGuidenceTab.ResumeLayout(False)
        Me.grpGridGuide.ResumeLayout(False)
        Me.nextPeriodRelativePriceTab.ResumeLayout(False)
        Me.nextPeriodPriceGroup.ResumeLayout(False)
        Me.nextPeriodPriceGroup.PerformLayout()
        CType(Me.nextPeriodTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.presentRelativePriceTab.ResumeLayout(False)
        Me.presentPriceGroup.ResumeLayout(False)
        Me.presentPriceGroup.PerformLayout()
        CType(Me.presentPriceTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.requestPowerLevelTab.ResumeLayout(False)
        Me.gbReqPowerLevel.ResumeLayout(False)
        Me.gbReqPowerLevel.PerformLayout()
        CType(Me.tbarPower, System.ComponentModel.ISupportInitialize).EndInit()
        Me.timeRemainingTab.ResumeLayout(False)
        Me.timeRemainingGroup.ResumeLayout(False)
        Me.timeRemainingGroup.PerformLayout()
        CType(Me.timeRemainingTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ucmQueryTab.ResumeLayout(False)
        Me.currentStategb.ResumeLayout(False)
        Me.currentStategb.PerformLayout()
        Me.gbQuery.ResumeLayout(False)
        Me.ucmComStatusTab.ResumeLayout(False)
        Me.gbCommStatus.ResumeLayout(False)
        Me.ucmTimeSyncTab.ResumeLayout(False)
        Me.gbTimeSync.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.ucmSetUTC.ResumeLayout(False)
        Me.ucmSetUTC.PerformLayout()
        CType(Me.nudUTCOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDSTOffset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ucmAutoCycling.ResumeLayout(False)
        Me.ucmAutoCycling.PerformLayout()
        CType(Me.nudStopEndRand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudStopEventID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudEndRandomization, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudStartRandomization, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDuration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDutyCycle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudEventID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sgdTab.ResumeLayout(False)
        Me.TestScripts.ResumeLayout(False)
        Me.TestScripts.PerformLayout()
        Me.realDeviceTab.ResumeLayout(False)
        Me.realDeviceTabControl.ResumeLayout(False)
        Me.commonRealFunctionsTab.ResumeLayout(False)
        Me.realCommonFunctionsGroup.ResumeLayout(False)
        Me.realCommonFunctionsGroup.PerformLayout()
        Me.realUCMFunctionsTab.ResumeLayout(False)
        Me.realUCMFunctionsGroup.ResumeLayout(False)
        Me.realUCMFunctionsGroup.PerformLayout()
        CType(Me.realUCMTrasmissionIntervalBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.realSGDFunctionsTab.ResumeLayout(False)
        Me.realSGDFunctionsGroup.ResumeLayout(False)
        Me.realSGDFunctionsGroup.PerformLayout()
        CType(Me.realSGDNoCommTimeoutValBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbPort As System.Windows.Forms.ComboBox
    Friend WithEvents CmbBaud As System.Windows.Forms.ComboBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rtbReceived As System.Windows.Forms.RichTextBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents rbMode1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMode2 As System.Windows.Forms.RadioButton
    Friend WithEvents gbErrors As System.Windows.Forms.GroupBox
    Friend WithEvents btnClearDebug As System.Windows.Forms.Button
    Friend WithEvents grpSGDConfig As System.Windows.Forms.GroupBox
    Friend WithEvents grpOpState As System.Windows.Forms.GroupBox
    Friend WithEvents chkCustOverride As System.Windows.Forms.CheckBox
    Friend WithEvents tmrTimeSync As System.Windows.Forms.Timer
    Friend WithEvents chkBadCheckSum As System.Windows.Forms.CheckBox
    Friend WithEvents chkLongMsg As System.Windows.Forms.CheckBox
    Friend WithEvents tmrBaudDefault As System.Windows.Forms.Timer
    Friend WithEvents grpChangeBaud As System.Windows.Forms.GroupBox
    Friend WithEvents cmbChangeBaud As System.Windows.Forms.ComboBox
    Friend WithEvents btnAcceptChangeBaud As System.Windows.Forms.Button
    Friend WithEvents tbLogFile As System.Windows.Forms.TextBox
    Friend WithEvents Browse As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents disableLogFile As System.Windows.Forms.CheckBox
    Friend WithEvents logFile As System.Windows.Forms.GroupBox
    Friend WithEvents logFilePathLabel As System.Windows.Forms.Label
    Friend WithEvents sgdTabControl As System.Windows.Forms.TabControl
    Friend WithEvents sgdOpStateTab As System.Windows.Forms.TabPage
    Friend WithEvents simulatorDeviceTypeTabControl As System.Windows.Forms.TabControl
    Friend WithEvents ucmTab As System.Windows.Forms.TabPage
    Friend WithEvents sgdTab As System.Windows.Forms.TabPage
    Friend WithEvents commonCommandsTab As System.Windows.Forms.TabPage
    Friend WithEvents commonCommandsTabControl As System.Windows.Forms.TabControl
    Friend WithEvents changeBaudTab As System.Windows.Forms.TabPage
    Friend WithEvents simulateErrorsTab As System.Windows.Forms.TabPage
    Friend WithEvents msgSupportedBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents supportedMsgTypeList As System.Windows.Forms.ListBox
    Friend WithEvents removeSupportedType As System.Windows.Forms.Button
    Friend WithEvents addSupportedType As System.Windows.Forms.Button
    Friend WithEvents deviceInfoTab As System.Windows.Forms.TabPage
    Friend WithEvents firmwareMinorLabel As System.Windows.Forms.Label
    Friend WithEvents firmwareMajorLabel As System.Windows.Forms.Label
    Friend WithEvents firmwareMonthLabel As System.Windows.Forms.Label
    Friend WithEvents firmwareDayLabel As System.Windows.Forms.Label
    Friend WithEvents firmwareYearLabel As System.Windows.Forms.Label
    Friend WithEvents serialNumberLabel As System.Windows.Forms.Label
    Friend WithEvents modelNumberLabel As System.Windows.Forms.Label
    Friend WithEvents capabilityBitmapLabel As System.Windows.Forms.Label
    Friend WithEvents deviceRevisionLabel As System.Windows.Forms.Label
    Friend WithEvents cea2045VersionLabel As System.Windows.Forms.Label
    Friend WithEvents deviceTypeLabel As System.Windows.Forms.Label
    Friend WithEvents vendorIDLabel As System.Windows.Forms.Label
    Friend WithEvents deviceInfoTabControl As System.Windows.Forms.TabControl
    Friend WithEvents generalInfoTab As System.Windows.Forms.TabPage
    Friend WithEvents msgTypeSupportedTab As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents deviceTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents deviceTypeMSBTextBox As System.Windows.Forms.TextBox
    Friend WithEvents serialNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents modelNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents firmwareDayComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents firmwareMonthComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents firmwareYearComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents deviceTypeLSBTextBox As System.Windows.Forms.TextBox
    Friend WithEvents serialNumberSupportedCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents modelNumberSupportedCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents firmwareMajorMinorSupportedCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents setMaxPayloadTab As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMaxPayload1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxPayload14 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxPayload2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxPayload13 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxPayload3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxPayload12 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxPayload4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxPayload11 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxPayload5 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxPayload10 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxPayload6 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxPayload9 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxPayload7 As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaxPayload8 As System.Windows.Forms.RadioButton
    Friend WithEvents GetUtc As System.Windows.Forms.TabPage
    Friend WithEvents btnGetUTC As System.Windows.Forms.Button
    Friend WithEvents tmrProcessComm As System.Windows.Forms.Timer
    Friend WithEvents tempF As System.Windows.Forms.TabPage
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents tempUnitC As System.Windows.Forms.RadioButton
    Friend WithEvents tmpUnitF As System.Windows.Forms.RadioButton
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents ucmTabControl As System.Windows.Forms.TabControl
    Friend WithEvents ucmManageDeviceTab As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents shedLoadTab As System.Windows.Forms.TabPage
    Friend WithEvents btnEndShed As System.Windows.Forms.Button
    Friend WithEvents btnShedSend As System.Windows.Forms.Button
    Friend WithEvents txtShedDur As System.Windows.Forms.TextBox
    Friend WithEvents trkShedDur As System.Windows.Forms.TrackBar
    Friend WithEvents requestPowerLevelTab As System.Windows.Forms.TabPage
    Friend WithEvents gbReqPowerLevel As System.Windows.Forms.GroupBox
    Friend WithEvents rbAbsorbed As System.Windows.Forms.RadioButton
    Friend WithEvents rbProduced As System.Windows.Forms.RadioButton
    Friend WithEvents btnRPLAccept As System.Windows.Forms.Button
    Friend WithEvents tbPowerAP As System.Windows.Forms.TextBox
    Friend WithEvents tbarPower As System.Windows.Forms.TrackBar
    Friend WithEvents ucmQueryTab As System.Windows.Forms.TabPage
    Friend WithEvents gbQuery As System.Windows.Forms.GroupBox
    Friend WithEvents pbOpState As System.Windows.Forms.Button
    Friend WithEvents ucmComStatusTab As System.Windows.Forms.TabPage
    Friend WithEvents gbCommStatus As System.Windows.Forms.GroupBox
    Friend WithEvents cmbCommStatus As System.Windows.Forms.ComboBox
    Friend WithEvents presentRelativePriceTab As System.Windows.Forms.TabPage
    Friend WithEvents presentPriceGroup As System.Windows.Forms.GroupBox
    Friend WithEvents presentPriceButton As System.Windows.Forms.Button
    Friend WithEvents presentPriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents presentPriceTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents criticalPeakButton As System.Windows.Forms.Button
    Friend WithEvents gridEmergencyButton As System.Windows.Forms.Button
    Friend WithEvents nextPeriodRelativePriceTab As System.Windows.Forms.TabPage
    Friend WithEvents nextPeriodPriceGroup As System.Windows.Forms.GroupBox
    Friend WithEvents nextPeriodPriceButton As System.Windows.Forms.Button
    Friend WithEvents nextPeriodPriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents nextPeriodTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents timeRemainingTab As System.Windows.Forms.TabPage
    Friend WithEvents timeRemainingGroup As System.Windows.Forms.GroupBox
    Friend WithEvents timeRemainingButton As System.Windows.Forms.Button
    Friend WithEvents timeRemainingTextBox As System.Windows.Forms.TextBox
    Friend WithEvents timeRemainingTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents gridGuidenceTab As System.Windows.Forms.TabPage
    Friend WithEvents grpGridGuide As System.Windows.Forms.GroupBox
    Friend WithEvents sendGuidenceButton As System.Windows.Forms.Button
    Friend WithEvents cmbGridGuide As System.Windows.Forms.ComboBox
    Friend WithEvents ucmTimeSyncTab As System.Windows.Forms.TabPage
    Friend WithEvents gbTimeSync As System.Windows.Forms.GroupBox
    Friend WithEvents btnTimeSyncOff As System.Windows.Forms.Button
    Friend WithEvents btnTimeSyncOn As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents ucmSetUTC As System.Windows.Forms.TabPage
    Friend WithEvents ucmAutoCycling As System.Windows.Forms.TabPage
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents btnSetUTC As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents dtpStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents nudDuration As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudDutyCycle As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudEventID As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnStopCycling As System.Windows.Forms.Button
    Friend WithEvents btnStartCycling As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents nudStopEndRand As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudStopEventID As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudEndRandomization As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudStartRandomization As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudFirmwareMajor As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudFirmwareMinor As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudUTCOffset As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudDSTOffset As System.Windows.Forms.NumericUpDown
    Friend WithEvents pbLoadUp As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents commodity As System.Windows.Forms.TabPage
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents nudCommodityRate As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents pbCommoditySave As System.Windows.Forms.Button
    Friend WithEvents nudCommodityAmount As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbCommoditySupported As System.Windows.Forms.CheckBox
    Friend WithEvents lbCommodityCode As System.Windows.Forms.ComboBox
    Friend WithEvents cbEstimated As System.Windows.Forms.CheckBox
    Friend WithEvents nudVendorIDLSB As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudVendorIDMSB As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudDevRevLSB As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudDevRevMSB As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCapBitMap3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCapBitMap2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCapBitMap1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCapBitMap0 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudTempOffset As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMsgSuppLSB As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMsgSuppMSB As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents tbCEA2045Version As System.Windows.Forms.TextBox
    Friend WithEvents nudCommodityFreq As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents sgdTempUnits As System.Windows.Forms.TextBox
    Friend WithEvents sgdCurrentTempOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents pbSetTempOffset As System.Windows.Forms.Button
    Friend WithEvents pbRequestTempOffset As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnMaxPayload As System.Windows.Forms.Button
    Friend WithEvents pbCommRefresh As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents TestScripts As System.Windows.Forms.TabPage
    Friend WithEvents pbOpenScript As System.Windows.Forms.Button
    Friend WithEvents tbScriptFile As System.Windows.Forms.TextBox
    Friend WithEvents fbdScriptFileSelect As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pbKillScript As System.Windows.Forms.Button
    Friend WithEvents pbExecuteScript As System.Windows.Forms.Button
    Friend WithEvents pbManCont As System.Windows.Forms.Button
    Friend WithEvents pbManualFail As System.Windows.Forms.Button
    Friend WithEvents pbManualPass As System.Windows.Forms.Button
    Friend WithEvents cbResponseSim As System.Windows.Forms.CheckBox
    Friend WithEvents cbVerboseLog As System.Windows.Forms.CheckBox
    Friend WithEvents TimingTab As System.Windows.Forms.TabPage
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents tARValBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents tMAValBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents label61 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents labelwhatever As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents tIMValBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents tRAValBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents label3i4lskjfdlj As System.Windows.Forms.Label
    Friend WithEvents tMLValBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents currentStategb As System.Windows.Forms.GroupBox
    Friend WithEvents currentStatetb As System.Windows.Forms.TextBox
    Friend WithEvents realDeviceTab As System.Windows.Forms.TabPage
    Friend WithEvents realDeviceTabControl As System.Windows.Forms.TabControl
    Friend WithEvents commonRealFunctionsTab As System.Windows.Forms.TabPage
    Friend WithEvents realUCMFunctionsTab As System.Windows.Forms.TabPage
    Friend WithEvents realSGDFunctionsTab As System.Windows.Forms.TabPage
    Friend WithEvents internalClockSupportedcb As System.Windows.Forms.CheckBox
    Friend WithEvents realSGDCritPeakResponse As System.Windows.Forms.ComboBox
    Friend WithEvents realSGDShedResponse As System.Windows.Forms.ComboBox
    Friend WithEvents realSGDFunctionsGroup As System.Windows.Forms.GroupBox
    Friend WithEvents realCommonFunctionsGroup As System.Windows.Forms.GroupBox
    Friend WithEvents realUCMFunctionsGroup As System.Windows.Forms.GroupBox
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents realUCMTrasmissionIntervalBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents realUCMCommStatusBox As System.Windows.Forms.ComboBox
    Friend WithEvents realDeviceIgnoreMaxPayloadCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents realSGDNeutralResponse As System.Windows.Forms.ComboBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents realSGDBadTimeResponse As System.Windows.Forms.ComboBox
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents realSGDGoodTimeResponse As System.Windows.Forms.ComboBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents realSGDEmergencyResponse As System.Windows.Forms.ComboBox
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents realSGDLoadUpResponse As System.Windows.Forms.ComboBox
    Friend WithEvents realSGDEndShedResponse As System.Windows.Forms.ComboBox
    Friend WithEvents realDeviceCommandRetrycb As System.Windows.Forms.CheckBox
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents realSGDNoCommTimeoutValBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents OpStateBox As System.Windows.Forms.ComboBox
    Friend WithEvents autoCommStatusTimer As System.Windows.Forms.Timer
    Friend WithEvents commStatusTimoutTmr As System.Windows.Forms.Timer
    Friend WithEvents shedEventTimer As System.Windows.Forms.Timer
    Friend WithEvents loadUpEventTimer As System.Windows.Forms.Timer
    Friend WithEvents realSGDNoCommTimeoutEnabledbtn As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents opcodeErrorsGroup As System.Windows.Forms.GroupBox
    Friend WithEvents badOpcode2valbox As System.Windows.Forms.NumericUpDown
    Friend WithEvents badOpcode1valbox As System.Windows.Forms.NumericUpDown
    Friend WithEvents badOpcode2cb As System.Windows.Forms.CheckBox
    Friend WithEvents badOpcode1cb As System.Windows.Forms.CheckBox
    Friend WithEvents scriptFeedBox As System.Windows.Forms.RichTextBox
    Friend WithEvents testScriptbtn As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents customLength2ValBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents customLength1ValBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents customLength2cb As System.Windows.Forms.CheckBox
    Friend WithEvents customLength1cb As System.Windows.Forms.CheckBox
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents customMsgType2ValBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents customMsgType1ValBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents customMsgType2cb As System.Windows.Forms.CheckBox
    Friend WithEvents customMsgType1cb As System.Windows.Forms.CheckBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents sgdTempRespCode As System.Windows.Forms.TextBox
    Friend WithEvents nudSetPoint2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudSetPoint1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents pbRequestSetpoint As System.Windows.Forms.Button
    Friend WithEvents pbSetSetPoint As System.Windows.Forms.Button
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents sgdSetPoint2 As System.Windows.Forms.TextBox
    Friend WithEvents sgdSetPoint1 As System.Windows.Forms.TextBox
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents nudSetpointDeviceType As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbSetpoint2Support As System.Windows.Forms.CheckBox
    Friend WithEvents tbSgdDeviceType As System.Windows.Forms.TextBox
    Friend WithEvents tbSetpointResponseCode As System.Windows.Forms.TextBox
    Friend WithEvents PassThrough As System.Windows.Forms.TabPage
    Friend WithEvents pbBrowsePT As System.Windows.Forms.Button
    Friend WithEvents tbFilePathPT As System.Windows.Forms.TextBox
    Friend WithEvents cbAddWrapper As System.Windows.Forms.CheckBox
    Friend WithEvents pbSendPT As System.Windows.Forms.Button
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents cbProtocolPT As System.Windows.Forms.ComboBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents getSet As System.Windows.Forms.TabPage
    Friend WithEvents pbGetEnergyPrice As System.Windows.Forms.Button
    Friend WithEvents pbSetTier As System.Windows.Forms.Button
    Friend WithEvents pfGetTier As System.Windows.Forms.Button
    Friend WithEvents pbSetEnergyPrice As System.Windows.Forms.Button
    Friend WithEvents chkShortMsg As System.Windows.Forms.CheckBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents nudNakRtn As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbNakMsg As System.Windows.Forms.CheckBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents nudAppNakRtn As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbAppNakMsg As System.Windows.Forms.CheckBox
    Friend WithEvents getDeviceInfo As System.Windows.Forms.TabPage
    Friend WithEvents otherDeviceFirmwareMinor As System.Windows.Forms.TextBox
    Friend WithEvents otherDeviceFirmwareMajor As System.Windows.Forms.TextBox
    Friend WithEvents otherDeviceFirmwareDate As System.Windows.Forms.TextBox
    Friend WithEvents otherDeviceModelNumber As System.Windows.Forms.TextBox
    Friend WithEvents otherDeviceCEA2045Version As System.Windows.Forms.TextBox
    Friend WithEvents otherDeviceVendorID As System.Windows.Forms.TextBox
    Friend WithEvents otherDeviceDeviceType As System.Windows.Forms.TextBox
    Friend WithEvents otherDeviceSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents otherDeviceDeviceRevision As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents otherDeviceCapabilityBitmap As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents queryDeviceInfoButton As System.Windows.Forms.Button
    Friend WithEvents msgSupportQuery As System.Windows.Forms.GroupBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents ODRefresh As System.Windows.Forms.Button
    Friend WithEvents ODMsgTypeSup As System.Windows.Forms.ListBox
    Friend WithEvents nudSupMsgQueryLSB As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudSupMsgQueryMSB As System.Windows.Forms.NumericUpDown
    Friend WithEvents typeSupportedQueryCodeLookup As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents msgTypeQuery As System.Windows.Forms.Button
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents cdMaxPayloadSize As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cdCommodityGb As System.Windows.Forms.GroupBox
    Friend WithEvents pbGetCommodity As System.Windows.Forms.Button
    Friend WithEvents tbCommodityFreq As System.Windows.Forms.TextBox
    Friend WithEvents pbSetCommodity As System.Windows.Forms.Button
    Friend WithEvents tbCommodityAmount As System.Windows.Forms.TextBox
    Friend WithEvents pbGetCommodSub As System.Windows.Forms.Button
    Friend WithEvents tbCommodityRate As System.Windows.Forms.TextBox
    Friend WithEvents pbSetCommodSub As System.Windows.Forms.Button
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lbCommodityCode1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbEstimated1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents cbCommoditySupported1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents tdCommodityCodes As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents pbGetPresentTemp As System.Windows.Forms.Button
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents nudPresentTemp As System.Windows.Forms.NumericUpDown
    Friend WithEvents tbResponseCode2 As System.Windows.Forms.TextBox
    Friend WithEvents tbPresentTemp As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label94 As System.Windows.Forms.Label

End Class
