Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Namespace SIS.SYS.SQLDatabase
  Public Class DBCommon
    Implements IDisposable
    Public Shared Property hostname As String = ""
    Public Shared Function GetBaaNConnectionString() As String
      Dim BaaNLive As Boolean = Convert.ToBoolean(ConfigurationManager.AppSettings("BaaNLive"))
      If BaaNLive Then
        Return "Data Source=ganesha;Initial Catalog=inforerpdb;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=lalit;Password=scorpions"
      Else
        Return "Data Source=gstdrill04;Initial Catalog=inforerpdb;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=lalit;Password=scorpions"
      End If
    End Function
    Public Shared Function GetConnectionString() As String
      Dim JoomlaLive As Boolean = Convert.ToBoolean(ConfigurationManager.AppSettings("JoomlaLive"))

      If JoomlaLive Then
        Select Case HttpContext.Current.Session("FinanceCompany")
          Case "700"
            Return "Data Source=perk03;Initial Catalog=REDECAM;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
          Case "651"
            Return "Data Source=perk03;Initial Catalog=ICL;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
          Case Else
            Return "Data Source=perk03;Initial Catalog=IJTPerks;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
        End Select
      Else
        Select Case HttpContext.Current.Session("FinanceCompany")
          Case "700"
            Return "Data Source=.\LGSQL;Initial Catalog=REDECAM;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
          Case "651"
            Return "Data Source=.\LGSQL;Initial Catalog=ICL;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
          Case Else
            Return "Data Source=.\LGSQL;Initial Catalog=IJTPerks;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
        End Select
      End If
    End Function
    Public Shared Function GetConnectionString(Comp As String) As String
      Dim JoomlaLive As Boolean = Convert.ToBoolean(ConfigurationManager.AppSettings("JoomlaLive"))
      If JoomlaLive Then
        Select Case Comp
          Case "700"
            Return "Data Source=perk03;Initial Catalog=REDECAM;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
          Case "651"
            Return "Data Source=perk03;Initial Catalog=ICL;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
          Case Else
            Return "Data Source=perk03;Initial Catalog=IJTPerks;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
        End Select
      Else
        Select Case Comp
          Case "700"
            Return "Data Source=.\LGSQL;Initial Catalog=REDECAM;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
          Case "651"
            Return "Data Source=.\LGSQL;Initial Catalog=ICL;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
          Case Else
            Return "Data Source=.\LGSQL;Initial Catalog=IJTPerks;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
        End Select
      End If
    End Function
    Public Shared Function GetToolsConnectionString() As String
      Dim JoomlaLive As Boolean = Convert.ToBoolean(ConfigurationManager.AppSettings("JoomlaLive"))

      If JoomlaLive Then
        Return "Data Source=perk03;Initial Catalog=IJTPerks;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
      Else
        Return "Data Source=.\LGSQL;Initial Catalog=IJTPerks;Integrated Security=False;User Instance=False;Persist Security Info=True;User ID=sa;Password=isgec12345"
      End If
    End Function
    Shared Sub New()
      If hostname = String.Empty Then
        hostname = SYS.Utilities.SessionManager.GetComputerName("localhost")
      End If
    End Sub
    Public Shared Sub AddDBParameter(ByRef Cmd As SqlCommand, ByVal name As String, ByVal type As SqlDbType, ByVal size As Integer, ByVal value As Object)
      Dim Parm As SqlParameter = Cmd.CreateParameter()
      Parm.ParameterName = name
      Parm.SqlDbType = type
      Parm.Size = size
      Parm.Value = value
      Cmd.Parameters.Add(Parm)
    End Sub
#Region " IDisposable Support "
    Private disposedValue As Boolean = False    ' To detect redundant calls
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: free unmanaged resources when explicitly called
        End If

        ' TODO: free shared unmanaged resources
      End If
      Me.disposedValue = True
    End Sub
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
    Public Shared Function NewObj(this As Object, Reader As SqlDataReader) As Object
      Try
        For Each pi As System.Reflection.PropertyInfo In this.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(this, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(this, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(this, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(this, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
        Return Nothing
      End Try
      Return this
    End Function

  End Class
End Namespace
