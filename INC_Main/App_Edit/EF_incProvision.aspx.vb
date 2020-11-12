Imports System.Web.Script.Serialization
Partial Class EF_incProvision
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
  Protected Sub ODSincProvision_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSincProvision.Selected
    Dim tmp As SIS.INC.incProvision = CType(e.ReturnValue, SIS.INC.incProvision)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVincProvision_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincProvision.Init
    DataClassName = "EincProvision"
    SetFormView = FVincProvision
  End Sub
  Protected Sub TBLincProvision_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincProvision.Init
    SetToolBar = TBLincProvision
  End Sub
  Protected Sub FVincProvision_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincProvision.PreRender
    TBLincProvision.EnableSave = Editable
    TBLincProvision.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/INC_Main/App_Edit") & "/EF_incProvision.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptincProvision") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptincProvision", mStr)
    End If
  End Sub

End Class
