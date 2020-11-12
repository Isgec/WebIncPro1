Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.INC
  <DataObject()> _
  Partial Public Class incBanks
    Private Shared _RecordCount As Integer
    Public Property BankID As Int32 = 0
    Public Property BankName As String = ""
    Public Property OrganizationUnit As String = ""
    Public Property Branch As String = ""
    Public Property AccountNo As String = ""
    Public Property ADCode As String = ""
    Public Property IFCSCode As String = ""
    Public Property GLCode As String = ""
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _BankName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _BankID
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKincBanks
      Private _BankID As Int32 = 0
      Public Property BankID() As Int32
        Get
          Return _BankID
        End Get
        Set(ByVal value As Int32)
          _BankID = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incBanksSelectList(ByVal OrderBy As String) As List(Of SIS.INC.incBanks)
      Dim Results As List(Of SIS.INC.incBanks) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincBanksSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.INC.incBanks)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.INC.incBanks(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incBanksGetNewRecord() As SIS.INC.incBanks
      Return New SIS.INC.incBanks()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incBanksGetByID(ByVal BankID As Int32) As SIS.INC.incBanks
      Dim Results As SIS.INC.incBanks = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincBanksSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankID",SqlDbType.Int,BankID.ToString.Length, BankID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.INC.incBanks(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incBanksSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.INC.incBanks)
      Dim Results As List(Of SIS.INC.incBanks) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spincBanksSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spincBanksSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.INC.incBanks)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.INC.incBanks(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function incBanksSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function incBanksInsert(ByVal Record As SIS.INC.incBanks) As SIS.INC.incBanks
      Dim _Rec As SIS.INC.incBanks = SIS.INC.incBanks.incBanksGetNewRecord()
      With _Rec
        .BankName = Record.BankName
        .OrganizationUnit = Record.OrganizationUnit
        .Branch = Record.Branch
        .AccountNo = Record.AccountNo
        .ADCode = Record.ADCode
        .IFCSCode = Record.IFCSCode
        .GLCode = Record.GLCode
      End With
      Return SIS.INC.incBanks.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.INC.incBanks) As SIS.INC.incBanks
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincBanksInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankName",SqlDbType.NVarChar,51, Iif(Record.BankName= "" ,Convert.DBNull, Record.BankName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrganizationUnit",SqlDbType.NVarChar,11, Iif(Record.OrganizationUnit= "" ,Convert.DBNull, Record.OrganizationUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Branch",SqlDbType.NVarChar,51, Iif(Record.Branch= "" ,Convert.DBNull, Record.Branch))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AccountNo",SqlDbType.NVarChar,51, Iif(Record.AccountNo= "" ,Convert.DBNull, Record.AccountNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ADCode",SqlDbType.NVarChar,51, Iif(Record.ADCode= "" ,Convert.DBNull, Record.ADCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IFCSCode",SqlDbType.NVarChar,51, Iif(Record.IFCSCode= "" ,Convert.DBNull, Record.IFCSCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLCode",SqlDbType.NChar,11, Iif(Record.GLCode= "" ,Convert.DBNull, Record.GLCode))
          Cmd.Parameters.Add("@Return_BankID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_BankID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.BankID = Cmd.Parameters("@Return_BankID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function incBanksUpdate(ByVal Record As SIS.INC.incBanks) As SIS.INC.incBanks
      Dim _Rec As SIS.INC.incBanks = SIS.INC.incBanks.incBanksGetByID(Record.BankID)
      With _Rec
        .BankName = Record.BankName
        .OrganizationUnit = Record.OrganizationUnit
        .Branch = Record.Branch
        .AccountNo = Record.AccountNo
        .ADCode = Record.ADCode
        .IFCSCode = Record.IFCSCode
        .GLCode = Record.GLCode
      End With
      Return SIS.INC.incBanks.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.INC.incBanks) As SIS.INC.incBanks
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincBanksUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BankID",SqlDbType.Int,11, Record.BankID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankName",SqlDbType.NVarChar,51, Iif(Record.BankName= "" ,Convert.DBNull, Record.BankName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrganizationUnit",SqlDbType.NVarChar,11, Iif(Record.OrganizationUnit= "" ,Convert.DBNull, Record.OrganizationUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Branch",SqlDbType.NVarChar,51, Iif(Record.Branch= "" ,Convert.DBNull, Record.Branch))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AccountNo",SqlDbType.NVarChar,51, Iif(Record.AccountNo= "" ,Convert.DBNull, Record.AccountNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ADCode",SqlDbType.NVarChar,51, Iif(Record.ADCode= "" ,Convert.DBNull, Record.ADCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IFCSCode",SqlDbType.NVarChar,51, Iif(Record.IFCSCode= "" ,Convert.DBNull, Record.IFCSCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLCode",SqlDbType.NChar,11, Iif(Record.GLCode= "" ,Convert.DBNull, Record.GLCode))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function incBanksDelete(ByVal Record As SIS.INC.incBanks) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincBanksDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BankID",SqlDbType.Int,Record.BankID.ToString.Length, Record.BankID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
'    Autocomplete Method
    Public Shared Function SelectincBanksAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincBanksAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.INC.incBanks = New SIS.INC.incBanks(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
