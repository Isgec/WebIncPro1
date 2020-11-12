Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.INC
  <DataObject()> _
  Partial Public Class incDBKRealization
    Private Shared _RecordCount As Integer
    Public Property SerialNo As Int32 = 0
    Public Property CustomInvoiceNo As String = ""
    Private _ValueDate As String = ""
    Public Property Description As String = ""
    Public Property ScrollNo As String = ""
    Private _ScrollDate As String = ""
    Public Property DBKAmount As String = "0.00"
    Public Property BankID As String = ""
    Public Property CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Public Property StatusID As Int32 = 0
    Public Property BatchNo As Int32 = 0
    Public Property DBK_DocumentNo As String = ""
    Public Property DBK_BatchNo As String = ""
    Public Property DBK_LineNo As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property INC_Banks2_BankName As String = ""
    Private _FK_INC_DBKRealization_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_INC_DBKRealization_BankID As SIS.INC.incBanks = Nothing
    Public Property FwdBatchNo As Int32 = 0
    Public Property RtnBatchNo As Int32 = 0
    Public Property VchBatchNo As Int32 = 0
    Public Property IsReturned As Boolean = False
    Public Property ProcessedBy As String = ""
    Private _ProcessedOn As String = ""
    Public Property ProcessedOn() As String
      Get
        If Not _ProcessedOn = String.Empty Then
          Return Convert.ToDateTime(_ProcessedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _ProcessedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ProcessedOn = ""
        Else
          _ProcessedOn = value
        End If
      End Set
    End Property
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
    Public Property ValueDate() As String
      Get
        If Not _ValueDate = String.Empty Then
          Return Convert.ToDateTime(_ValueDate).ToString("dd/MM/yyyy")
        End If
        Return _ValueDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ValueDate = ""
         Else
           _ValueDate = value
         End If
      End Set
    End Property
    Public Property ScrollDate() As String
      Get
        If Not _ScrollDate = String.Empty Then
          Return Convert.ToDateTime(_ScrollDate).ToString("dd/MM/yyyy")
        End If
        Return _ScrollDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ScrollDate = ""
         Else
           _ScrollDate = value
         End If
      End Set
    End Property
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _CreatedOn
      End Get
      Set(ByVal value As String)
         _CreatedOn = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo
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
    Public Class PKincDBKRealization
      Private _SerialNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_INC_DBKRealization_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_INC_DBKRealization_CreatedBy Is Nothing Then
          _FK_INC_DBKRealization_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_INC_DBKRealization_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_INC_DBKRealization_BankID() As SIS.INC.incBanks
      Get
        If _FK_INC_DBKRealization_BankID Is Nothing Then
          _FK_INC_DBKRealization_BankID = SIS.INC.incBanks.incBanksGetByID(_BankID)
        End If
        Return _FK_INC_DBKRealization_BankID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incDBKRealizationGetNewRecord() As SIS.INC.incDBKRealization
      Return New SIS.INC.incDBKRealization()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incDBKRealizationGetByID(ByVal SerialNo As Int32) As SIS.INC.incDBKRealization
      Dim Results As SIS.INC.incDBKRealization = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincDBKRealizationSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.INC.incDBKRealization(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function incDBKRealizationSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CustomInvoiceNo As String, ByVal BankID As Int32, ByVal StatusID As Int32, ByVal BatchNo As Int32, ByVal FwdBatchNo As Int32, ByVal RtnBatchNo As Int32) As List(Of SIS.INC.incDBKRealization)
      Dim Results As List(Of SIS.INC.incDBKRealization) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spincDBKRealizationSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spincDBKRealizationSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CustomInvoiceNo", SqlDbType.NVarChar, 9, IIf(CustomInvoiceNo Is Nothing, String.Empty, CustomInvoiceNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BankID", SqlDbType.Int, 10, IIf(BankID = Nothing, 0, BankID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID", SqlDbType.Int, 10, IIf(StatusID = Nothing, 0, StatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BatchNo", SqlDbType.Int, 10, IIf(BatchNo = Nothing, 0, BatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FwdBatchNo", SqlDbType.Int, 10, IIf(FwdBatchNo = Nothing, 0, FwdBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RtnBatchNo", SqlDbType.Int, 10, IIf(RtnBatchNo = Nothing, 0, RtnBatchNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.INC.incDBKRealization)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.INC.incDBKRealization(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function incDBKRealizationSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CustomInvoiceNo As String, ByVal BankID As Int32, ByVal StatusID As Int32, ByVal BatchNo As Int32, ByVal FwdBatchNo As Int32, ByVal RtnBatchNo As Int32) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incDBKRealizationGetByID(ByVal SerialNo As Int32, ByVal Filter_CustomInvoiceNo As String, ByVal Filter_BankID As Int32, ByVal Filter_StatusID As Int32, ByVal Filter_BatchNo As Int32) As SIS.INC.incDBKRealization
      Return incDBKRealizationGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function incDBKRealizationInsert(ByVal Record As SIS.INC.incDBKRealization) As SIS.INC.incDBKRealization
      Dim _Rec As SIS.INC.incDBKRealization = SIS.INC.incDBKRealization.incDBKRealizationGetNewRecord()
      With _Rec
        .CustomInvoiceNo = Record.CustomInvoiceNo
        .ValueDate = Record.ValueDate
        .Description = Record.Description
        .ScrollNo = Record.ScrollNo
        .ScrollDate = Record.ScrollDate
        .DBKAmount = Record.DBKAmount
        .BankID = Record.BankID
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .StatusID = enumInvStates.Free
        .BatchNo = Record.BatchNo
      End With
      Return SIS.INC.incDBKRealization.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.INC.incDBKRealization) As SIS.INC.incDBKRealization
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincDBKRealizationInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceNo",SqlDbType.NVarChar,10, Record.CustomInvoiceNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDate",SqlDbType.DateTime,21, Iif(Record.ValueDate= "" ,Convert.DBNull, Record.ValueDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ScrollNo",SqlDbType.NVarChar,51, Iif(Record.ScrollNo= "" ,Convert.DBNull, Record.ScrollNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ScrollDate",SqlDbType.DateTime,21, Iif(Record.ScrollDate= "" ,Convert.DBNull, Record.ScrollDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBKAmount",SqlDbType.Decimal,17, Record.DBKAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankID",SqlDbType.Int,11, Iif(Record.BankID= "" ,Convert.DBNull, Record.BankID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Record.CreatedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BatchNo",SqlDbType.Int,11, Record.BatchNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBK_DocumentNo",SqlDbType.NVarChar,51, Iif(Record.DBK_DocumentNo= "" ,Convert.DBNull, Record.DBK_DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBK_BatchNo",SqlDbType.NVarChar,51, Iif(Record.DBK_BatchNo= "" ,Convert.DBNull, Record.DBK_BatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBK_LineNo",SqlDbType.NVarChar,51, Iif(Record.DBK_LineNo= "" ,Convert.DBNull, Record.DBK_LineNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FwdBatchNo", SqlDbType.Int, 11, Record.FwdBatchNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RtnBatchNo", SqlDbType.Int, 11, Record.RtnBatchNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VchBatchNo", SqlDbType.Int, 11, Record.VchBatchNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsReturned", SqlDbType.Bit, 3, Record.IsReturned)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedBy", SqlDbType.NVarChar, 9, IIf(Record.ProcessedBy = "", Convert.DBNull, Record.ProcessedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedOn", SqlDbType.DateTime, 21, IIf(Record.ProcessedOn = "", Convert.DBNull, Record.ProcessedOn))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function incDBKRealizationUpdate(ByVal Record As SIS.INC.incDBKRealization) As SIS.INC.incDBKRealization
      Dim _Rec As SIS.INC.incDBKRealization = SIS.INC.incDBKRealization.incDBKRealizationGetByID(Record.SerialNo)
      With _Rec
        .CustomInvoiceNo = Record.CustomInvoiceNo
        .ValueDate = Record.ValueDate
        .Description = Record.Description
        .ScrollNo = Record.ScrollNo
        .ScrollDate = Record.ScrollDate
        .DBKAmount = Record.DBKAmount
        .BankID = Record.BankID
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      Return SIS.INC.incDBKRealization.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.INC.incDBKRealization) As SIS.INC.incDBKRealization
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincDBKRealizationUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceNo",SqlDbType.NVarChar,10, Record.CustomInvoiceNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDate",SqlDbType.DateTime,21, Iif(Record.ValueDate= "" ,Convert.DBNull, Record.ValueDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ScrollNo",SqlDbType.NVarChar,51, Iif(Record.ScrollNo= "" ,Convert.DBNull, Record.ScrollNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ScrollDate",SqlDbType.DateTime,21, Iif(Record.ScrollDate= "" ,Convert.DBNull, Record.ScrollDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBKAmount",SqlDbType.Decimal,17, Record.DBKAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankID",SqlDbType.Int,11, Iif(Record.BankID= "" ,Convert.DBNull, Record.BankID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Record.CreatedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BatchNo",SqlDbType.Int,11, Record.BatchNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBK_DocumentNo",SqlDbType.NVarChar,51, Iif(Record.DBK_DocumentNo= "" ,Convert.DBNull, Record.DBK_DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBK_BatchNo",SqlDbType.NVarChar,51, Iif(Record.DBK_BatchNo= "" ,Convert.DBNull, Record.DBK_BatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBK_LineNo",SqlDbType.NVarChar,51, Iif(Record.DBK_LineNo= "" ,Convert.DBNull, Record.DBK_LineNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FwdBatchNo", SqlDbType.Int, 11, Record.FwdBatchNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RtnBatchNo", SqlDbType.Int, 11, Record.RtnBatchNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VchBatchNo", SqlDbType.Int, 11, Record.VchBatchNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsReturned", SqlDbType.Bit, 3, Record.IsReturned)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedBy", SqlDbType.NVarChar, 9, IIf(Record.ProcessedBy = "", Convert.DBNull, Record.ProcessedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedOn", SqlDbType.DateTime, 21, IIf(Record.ProcessedOn = "", Convert.DBNull, Record.ProcessedOn))
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
    Public Shared Function incDBKRealizationDelete(ByVal Record As SIS.INC.incDBKRealization) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincDBKRealizationDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
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
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
