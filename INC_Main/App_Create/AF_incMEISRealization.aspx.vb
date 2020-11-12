Partial Class AF_incMEISRealization
  Inherits SIS.SYS.InsertBase
  Protected Sub FVincMEISRealization_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincMEISRealization.Init
    DataClassName = "AincMEISRealization"
    SetFormView = FVincMEISRealization
  End Sub
  Protected Sub TBLincMEISRealization_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincMEISRealization.Init
    SetToolBar = TBLincMEISRealization
  End Sub
  Protected Sub FVincMEISRealization_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincMEISRealization.DataBound
    SIS.INC.incMEISRealization.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVincMEISRealization_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincMEISRealization.PreRender
    Dim oF_BankID As LC_incBanks = FVincMEISRealization.FindControl("F_BankID")
    oF_BankID.Enabled = True
    oF_BankID.SelectedValue = String.Empty
    If Not Session("F_BankID") Is Nothing Then
      If Session("F_BankID") <> String.Empty Then
        oF_BankID.SelectedValue = Session("F_BankID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/INC_Main/App_Create") & "/AF_incMEISRealization.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptincMEISRealization") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptincMEISRealization", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVincMEISRealization.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVincMEISRealization.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
