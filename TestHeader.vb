Imports System.IO

Public Class TestHeader
    Private BasePath As String

    Private Sub TestHeader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BasePath = IO.Path.GetDirectoryName(FrmMain.tbLogFile.Text)
        NewHeaderTB.Text = IO.Path.Combine(BasePath, "testHeader.csv")
        PrevHeaderTB.Text = IO.Path.Combine(BasePath, "testHeader.csv")
    End Sub

    Private Sub PrevHeaderCB_CheckedChanged(sender As Object, e As EventArgs) Handles PrevHeaderCB.CheckedChanged
        'enables/disables previous header controls
        If PrevHeaderCB.Checked = True Then
            NewHeaderCB.Checked = False
            PrevHeaderGrpBox.Enabled = True
        Else
            PrevHeaderGrpBox.Enabled = False
        End If
    End Sub

    Private Sub NewHeaderCB_CheckedChanged(sender As Object, e As EventArgs) Handles NewHeaderCB.CheckedChanged
        'enables/disables new header controls
        If NewHeaderCB.Checked = True Then
            PrevHeaderCB.Checked = False
            NewHeaderGrpBox.Enabled = True
        Else
            NewHeaderTB.Text = String.Empty
            NewHeaderGrpBox.Enabled = False
        End If
    End Sub

    Private Sub BrowseBtn_Click(sender As Object, e As EventArgs) Handles BrowsePrevBtn.Click
        'pulls up save dialog box to browse for previous header
        Try
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                PrevHeaderTB.Text = OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub Browse_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub BrowseNewBtn_Click(sender As Object, e As EventArgs) Handles BrowseNewBtn.Click
        'pulls up save dialog box to browse for new header
        Try
            Dim HeaderFile = New SaveFileDialog With {
                .DefaultExt = "csv",
                .InitialDirectory = IO.Directory.GetCurrentDirectory(),
                .Filter = "comma delimited (*.csv)|*.csv|All files (*.*)|*.*"
            }
            If HeaderFile.ShowDialog() = DialogResult.OK Then
                NewHeaderTB.Text = HeaderFile.FileName
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured in Sub Browse_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub DoneSavebtn_Click(sender As Object, e As EventArgs) Handles DoneSavebtn.Click
        'sets header file name in Main_form to selected file
        FrmMain.testHeaderSaveFile = PrevHeaderTB.Text
        Dim sr As StreamReader = New StreamReader(FrmMain.testHeaderSaveFile)
        Using sw As StreamWriter = New StreamWriter(FrmMain.tbLogFile.Text, True)
            sw.WriteLine(sr.ReadToEnd)
            sr.Close()
        End Using
        Me.Close()
    End Sub

    Private Sub CreateHeaderBtn_Click(sender As Object, e As EventArgs) Handles CreateHeaderBtn.Click
        FrmMain.testHeaderSaveFile = NewHeaderTB.Text
        NewHeader.Show()
        Me.Close()
    End Sub
End Class