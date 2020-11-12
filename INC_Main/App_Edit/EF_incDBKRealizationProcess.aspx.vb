Imports System.Web.Script.Serialization
Partial Class EF_incDBKRealizationProcess
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
  Protected Sub ODSincDBKRealizationProcess_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSincDBKRealizationProcess.Selected
    Dim tmp As SIS.INC.incDBKRealizationProcess = CType(e.ReturnValue, SIS.INC.incDBKRealizationProcess)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVincDBKRealizationProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincDBKRealizationProcess.Init
    DataClassName = "EincDBKRealizationProcess"
    SetFormView = FVincDBKRealizationProcess
  End Sub
  Protected Sub TBLincDBKRealizationProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincDBKRealizationProcess.Init
    SetToolBar = TBLincDBKRealizationProcess
  End Sub
  Protected Sub FVincDBKRealizationProcess_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincDBKRealizationProcess.PreRender
    TBLincDBKRealizationProcess.EnableSave = Editable
    TBLincDBKRealizationProcess.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/INC_Main/App_Edit") & "/EF_incDBKRealizationProcess.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptincDBKRealizationProcess") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptincDBKRealizationProcess", mStr)
    End If
  End Sub

End Class
