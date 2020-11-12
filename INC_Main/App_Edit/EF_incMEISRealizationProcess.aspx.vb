Imports System.Web.Script.Serialization
Partial Class EF_incMEISRealizationProcess
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
  Protected Sub ODSincMEISRealizationProcess_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSincMEISRealizationProcess.Selected
    Dim tmp As SIS.INC.incMEISRealizationProcess = CType(e.ReturnValue, SIS.INC.incMEISRealizationProcess)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVincMEISRealizationProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincMEISRealizationProcess.Init
    DataClassName = "EincMEISRealizationProcess"
    SetFormView = FVincMEISRealizationProcess
  End Sub
  Protected Sub TBLincMEISRealizationProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincMEISRealizationProcess.Init
    SetToolBar = TBLincMEISRealizationProcess
  End Sub
  Protected Sub FVincMEISRealizationProcess_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVincMEISRealizationProcess.PreRender
    TBLincMEISRealizationProcess.EnableSave = Editable
    TBLincMEISRealizationProcess.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/INC_Main/App_Edit") & "/EF_incMEISRealizationProcess.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptincMEISRealizationProcess") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptincMEISRealizationProcess", mStr)
    End If
  End Sub

End Class
