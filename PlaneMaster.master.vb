Imports System.Web.Services
Imports System.IO
Partial Class lgPlaneMasterPage
  Inherits System.Web.UI.MasterPage
  Public WriteOnly Property SetEncType As String
    Set(value As String)
      Me.form1.Attributes.Add("enctype", "multipart/form-data")
    End Set
  End Property
  Public Function GetRelativePath(ByVal mPath As String) As String
    Return VirtualPathUtility.MakeRelative(Page.AppRelativeVirtualPath, mPath)
  End Function
  Public Property Master_Form() As HtmlForm
    Get
      Return Me.form1
    End Get
    Set(ByVal value As HtmlForm)
      Me.form1 = value
    End Set
  End Property
  Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
    If (e.Exception.Data("ExtraInfo") <> Nothing) Then
      ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.Message & e.Exception.Data("ExtraInfo").ToString()
    Else
      ToolkitScriptManager1.AsyncPostBackErrorMessage = "An unspecified error occurred."
    End If
  End Sub
End Class

