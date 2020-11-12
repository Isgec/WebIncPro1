Partial Class lgModal
  Inherits System.Web.UI.UserControl
  Private _Height As String = "200px"
  Private _Width As String = "400px"
  Private _Header As String = "MyHeader"
  Private _ReturnTrueOnCancel As Boolean = False
  Private _OnBeforeCancel As String = ""
  Private _OnAfterCancel As String = ""
  Public Property Header As String
    Get
      Return _Header
    End Get
    Set(value As String)
      _Header = value
    End Set
  End Property
  Public ReadOnly Property GetCancelMethodName() As String
    Get
      Return "cancelMessage()"
    End Get
  End Property
  Public ReadOnly Property GetHideMethodName() As String
    Get
      Return "hideMessageMPV()"
    End Get
  End Property
  Public Property OnAfterCancel() As String
    Get
      Return _OnAfterCancel
    End Get
    Set(ByVal value As String)
      _OnAfterCancel = value
    End Set
  End Property
  Public Property OnBeforeCancel() As String
    Get
      Return _OnBeforeCancel
    End Get
    Set(ByVal value As String)
      _OnBeforeCancel = value
    End Set
  End Property
  Public ReadOnly Property GetReturnTrueOnCancel() As String
    Get
      Return IIf(_ReturnTrueOnCancel, "true", "false")
    End Get
  End Property
  Public Property ReturnTrueOnCancel() As Boolean
    Get
      Return _ReturnTrueOnCancel
    End Get
    Set(ByVal value As Boolean)
      _ReturnTrueOnCancel = value
    End Set
  End Property
  Public Property Width() As String
    Get
      Return _Width
    End Get
    Set(ByVal value As String)
      _Width = value
    End Set
  End Property
  Public Property Height() As String
    Get
      Return _Height
    End Get
    Set(ByVal value As String)
      _Height = value
    End Set
  End Property
End Class
