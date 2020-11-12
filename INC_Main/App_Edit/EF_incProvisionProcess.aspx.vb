Imports System.Web.Script.Serialization
Partial Class EF_incProvisionProcess
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
  Protected Sub ODSincProvisionProcess_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSincProvisionProcess.Selected
    Dim tmp As SIS.INC.incProvisionProcess = CType(e.ReturnValue, SIS.INC.incProvisionProcess)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVincProvisionProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincProvisionProcess.Init
    DataClassName = "EincProvisionProcess"
    SetFormView = FVincProvisionProcess
  End Sub
  Protected Sub TBLincProvisionProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincProvisionProcess.Init
    SetToolBar = TBLincProvisionProcess
  End Sub
  Protected Sub FVincProvisionProcess_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincProvisionProcess.PreRender
    TBLincProvisionProcess.EnableSave = Editable
    TBLincProvisionProcess.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/INC_Main/App_Edit") & "/EF_incProvisionProcess.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptincProvisionProcess") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptincProvisionProcess", mStr)
    End If
  End Sub

End Class
