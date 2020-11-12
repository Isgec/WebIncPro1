Partial Class AF_incBanks
  Inherits SIS.SYS.InsertBase
  Protected Sub FVincBanks_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincBanks.Init
    DataClassName = "AincBanks"
    SetFormView = FVincBanks
  End Sub
  Protected Sub TBLincBanks_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincBanks.Init
    SetToolBar = TBLincBanks
  End Sub
  Protected Sub FVincBanks_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincBanks.DataBound
    SIS.INC.incBanks.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVincBanks_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincBanks.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/INC_Main/App_Create") & "/AF_incBanks.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptincBanks") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptincBanks", mStr)
    End If
    If Request.QueryString("BankID") IsNot Nothing Then
      CType(FVincBanks.FindControl("F_BankID"), TextBox).Text = Request.QueryString("BankID")
      CType(FVincBanks.FindControl("F_BankID"), TextBox).Enabled = False
    End If
  End Sub

End Class
