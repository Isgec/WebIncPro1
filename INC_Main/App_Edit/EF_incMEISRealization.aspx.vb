Imports System.Web.Script.Serialization
Partial Class EF_incMEISRealization
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
  Protected Sub ODSincMEISRealization_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSincMEISRealization.Selected
    Dim tmp As SIS.INC.incMEISRealization = CType(e.ReturnValue, SIS.INC.incMEISRealization)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVincMEISRealization_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincMEISRealization.Init
    DataClassName = "EincMEISRealization"
    SetFormView = FVincMEISRealization
  End Sub
  Protected Sub TBLincMEISRealization_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincMEISRealization.Init
    SetToolBar = TBLincMEISRealization
  End Sub
  Protected Sub FVincMEISRealization_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincMEISRealization.PreRender
    TBLincMEISRealization.EnableSave = Editable
    TBLincMEISRealization.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/INC_Main/App_Edit") & "/EF_incMEISRealization.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptincMEISRealization") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptincMEISRealization", mStr)
    End If
  End Sub

End Class
