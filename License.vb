Public Class License
    Private Sub License_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Application.Info.Title <> "" Then
            Me.ProductNameLabel.Text = My.Application.Info.Title
        Else
            Me.ProductNameLabel.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.ProductVersionLabel.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.BusinessNameLabel.Text = My.Application.Info.CompanyName
        Me.BusinessAddrLabel.Text = "3420 Hillview Ave. Palo Alto, CA 94304"
        Me.LiabilityNoticeLabel.Text = "This software is provided by EPRI ""As Is"" and without customer support beyond such embodiments within the distribution of this software that may or may not provide such support."
        Me.CopyrightLabel.Text = My.Application.Info.Copyright
        Me.PermissionLabel.Text = "Permission to use, copy, modify, and distribute this software for any purpose with or without fee is hereby granted, provided that the above copyright notice and this permission notice appear in all copies."
        Me.LicenseTextLabel.Text = "THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS ""As Is"" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL EPRI BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE."
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub
End Class