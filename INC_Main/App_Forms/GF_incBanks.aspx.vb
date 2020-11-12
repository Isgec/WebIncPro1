Imports System.Web.Script.Serialization
Partial Class GF_incBanks
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/INC_Main/App_Display/DF_incBanks.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?BankID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVincBanks_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVincBanks.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim BankID As Int32 = GVincBanks.DataKeys(e.CommandArgument).Values("BankID")  
        Dim RedirectUrl As String = TBLincBanks.EditUrl & "?BankID=" & BankID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVincBanks_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVincBanks.Init
    DataClassName = "GincBanks"
    SetGridView = GVincBanks
  End Sub
  Protected Sub TBLincBanks_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincBanks.Init
    SetToolBar = TBLincBanks
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
