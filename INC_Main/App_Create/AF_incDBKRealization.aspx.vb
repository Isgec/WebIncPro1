Partial Class AF_incDBKRealization
  Inherits SIS.SYS.InsertBase
  Protected Sub FVincDBKRealization_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincDBKRealization.Init
    DataClassName = "AincDBKRealization"
    SetFormView = FVincDBKRealization
  End Sub
  Protected Sub TBLincDBKRealization_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincDBKRealization.Init
    SetToolBar = TBLincDBKRealization
  End Sub
  Protected Sub FVincDBKRealization_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincDBKRealization.DataBound
    SIS.INC.incDBKRealization.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVincDBKRealization_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincDBKRealization.PreRender
    Dim oF_BankID As LC_incBanks = FVincDBKRealization.FindControl("F_BankID")
    oF_BankID.Enabled = True
    oF_BankID.SelectedValue = String.Empty
    If Not Session("F_BankID") Is Nothing Then
      If Session("F_BankID") <> String.Empty Then
        oF_BankID.SelectedValue = Session("F_BankID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/INC_Main/App_Create") & "/AF_incDBKRealization.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptincDBKRealization") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptincDBKRealization", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVincDBKRealization.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVincDBKRealization.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
