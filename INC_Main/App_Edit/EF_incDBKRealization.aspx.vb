Imports System.Web.Script.Serialization
Partial Class EF_incDBKRealization
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSincDBKRealization_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSincDBKRealization.Selected
    Dim tmp As SIS.INC.incDBKRealization = CType(e.ReturnValue, SIS.INC.incDBKRealization)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVincDBKRealization_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincDBKRealization.Init
    DataClassName = "EincDBKRealization"
    SetFormView = FVincDBKRealization
  End Sub
  Protected Sub TBLincDBKRealization_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincDBKRealization.Init
    SetToolBar = TBLincDBKRealization
  End Sub
  Protected Sub FVincDBKRealization_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincDBKRealization.PreRender
    TBLincDBKRealization.EnableSave = Editable
    TBLincDBKRealization.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/INC_Main/App_Edit") & "/EF_incDBKRealization.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptincDBKRealization") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptincDBKRealization", mStr)
    End If
  End Sub

End Class
