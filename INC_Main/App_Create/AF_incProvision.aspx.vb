Partial Class AF_incProvision
  Inherits SIS.SYS.InsertBase
  Protected Sub FVincProvision_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincProvision.Init
    DataClassName = "AincProvision"
    SetFormView = FVincProvision
  End Sub
  Protected Sub TBLincProvision_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincProvision.Init
    SetToolBar = TBLincProvision
  End Sub
  Protected Sub FVincProvision_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincProvision.DataBound
    SIS.INC.incProvision.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVincProvision_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincProvision.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/INC_Main/App_Create") & "/AF_incProvision.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptincProvision") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptincProvision", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVincProvision.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVincProvision.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
