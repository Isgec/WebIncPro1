
Partial Class LC_PostVoucher
  Inherits System.Web.UI.UserControl
  Public Event Cancelled()
  Public Event Execute(VoucherDate As String)
  Private Property DisplayMode As enumVoucherData
    Get
      If ViewState("DisplayMode") IsNot Nothing Then
        Return Convert.ToInt32(ViewState("DisplayMode"))
      End If
      Return enumVoucherData.PostingMode
    End Get
    Set(value As enumVoucherData)
      ViewState.Add("DisplayMode", value)
    End Set
  End Property
  Public Sub Show(Optional mode As enumVoucherData = enumVoucherData.PostingMode)
    Select Case mode
      Case enumVoucherData.PostingMode
        DisplayMode = mode
        HeaderText.Text = "Voucher Date: "
        F_VoucherDate.Text = Now.ToString("dd/MM/yyyy")
        F_VoucherDate.Visible = True
        mPopup.Show()
      Case enumVoucherData.ErrorMode
        mPopup.Show()
      Case enumVoucherData.DisplayMode
        DisplayMode = mode
        HeaderText.Text = "Voucher Details"
        F_VoucherDate.Visible = False
        mPopup.Show()
    End Select
  End Sub
  Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
    If DisplayMode = enumVoucherData.PostingMode Then
      Try
        Dim tmp As DateTime = Convert.ToDateTime(F_VoucherDate.Text)
        RaiseEvent Execute(F_VoucherDate.Text)
      Catch ex As Exception
        'Raise error
      End Try
    End If
  End Sub
  Public Property DisplayContent As Panel
    Get
      Return modalContent
    End Get
    Set(value As Panel)
      modalContent = value
    End Set
  End Property
End Class
