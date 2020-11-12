Imports System.Web.Script.Serialization
Partial Class EF_incBanks
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
  Protected Sub ODSincBanks_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSincBanks.Selected
    Dim tmp As SIS.INC.incBanks = CType(e.ReturnValue, SIS.INC.incBanks)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVincBanks_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincBanks.Init
    DataClassName = "EincBanks"
    SetFormView = FVincBanks
  End Sub
  Protected Sub TBLincBanks_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincBanks.Init
    SetToolBar = TBLincBanks
  End Sub
  Protected Sub FVincBanks_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincBanks.PreRender
    TBLincBanks.EnableSave = Editable
    TBLincBanks.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/INC_Main/App_Edit") & "/EF_incBanks.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptincBanks") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptincBanks", mStr)
    End If
  End Sub

End Class
