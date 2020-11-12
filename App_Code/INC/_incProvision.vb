Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.INC
  <DataObject()> _
  Partial Public Class incProvision
    Private Shared _RecordCount As Integer
    Public Property SerialNo As Int32 = 0
    Public Property DivisionID As String = ""
    Public Property CustomInvoiceNo As String = ""
    Private _CustomInvoiceDate As String = ""
    Public Property ShippingBillNo As String = ""
    Private _ShippingBillDate As String = ""
    Public Property ShippingBillCHA As String = ""
    Private _LEODate As String = ""
    Public Property CustomInvoiceAmount As String = "0.00"
    Public Property CustomInvoiceCurrency As String = ""
    Public Property CustomPLNo As String = ""
    Public Property FinalInvoiceNo As String = ""
    Private _FinalInvoiceDate As String = ""
    Public Property InvoiceType As String = ""
    Public Property DBKAmountProvisional As String = "0.00"
    Public Property FOBAmount As String = "0.00"
    Public Property ExchangeRateCustom As String = "0.00"
    Public Property BillOfLadingNo As String = ""
    Private _BillOfLadingDate As String = ""
    Public Property BuyerName As String = ""
    Public Property ProjectCode As String = ""
    Public Property ITSHSCode As String = ""
    Public Property ItemDescription As String = ""
    Public Property MEISAmount As String = "0.00"
    Public Property LoadingPort As String = ""
    Public Property BatchNo As Int32 = 0
    Public Property StatusID As Int32 = 0
    Public Property CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Public Property DBK_BatchNo As String = ""
    Public Property DBK_DocumentNo As String = ""
    Public Property DBK_LineNo As String = ""
    Public Property MEIS_BatchNo As String = ""
    Public Property MEIS_DocumentNo As String = ""
    Public Property MEIS_LineNo As String = ""
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
    Public Property CustomInvoiceDate() As String
      Get
        If Not _CustomInvoiceDate = String.Empty Then
          Return Convert.ToDateTime(_CustomInvoiceDate).ToString("dd/MM/yyyy")
        End If
        Return _CustomInvoiceDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CustomInvoiceDate = ""
         Else
           _CustomInvoiceDate = value
         End If
      End Set
    End Property
    Public Property ShippingBillDate() As String
      Get
        If Not _ShippingBillDate = String.Empty Then
          Return Convert.ToDateTime(_ShippingBillDate).ToString("dd/MM/yyyy")
        End If
        Return _ShippingBillDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ShippingBillDate = ""
         Else
           _ShippingBillDate = value
         End If
      End Set
    End Property
    Public Property LEODate() As String
      Get
        If Not _LEODate = String.Empty Then
          Return Convert.ToDateTime(_LEODate).ToString("dd/MM/yyyy")
        End If
        Return _LEODate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _LEODate = ""
         Else
           _LEODate = value
         End If
      End Set
    End Property
    Public Property FinalInvoiceDate() As String
      Get
        If Not _FinalInvoiceDate = String.Empty Then
          Return Convert.ToDateTime(_FinalInvoiceDate).ToString("dd/MM/yyyy")
        End If
        Return _FinalInvoiceDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _FinalInvoiceDate = ""
         Else
           _FinalInvoiceDate = value
         End If
      End Set
    End Property
    Public Property BillOfLadingDate() As String
      Get
        If Not _BillOfLadingDate = String.Empty Then
          Return Convert.ToDateTime(_BillOfLadingDate).ToString("dd/MM/yyyy")
        End If
        Return _BillOfLadingDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BillOfLadingDate = ""
         Else
           _BillOfLadingDate = value
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
    Public Class PKincProvision
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incProvisionGetNewRecord() As SIS.INC.incProvision
      Return New SIS.INC.incProvision()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incProvisionGetByID(ByVal SerialNo As Int32) As SIS.INC.incProvision
      Dim Results As SIS.INC.incProvision = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincProvisionSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.INC.incProvision(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function incProvisionSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DivisionID As String, ByVal CustomInvoiceNo As String, ByVal ProjectCode As String, ByVal BatchNo As Int32, ByVal FwdBatchNo As Int32, ByVal RtnBatchNo As Int32, ByVal StatusID As Int32) As List(Of SIS.INC.incProvision)
      Dim Results As List(Of SIS.INC.incProvision) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spincProvisionSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spincProvisionSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DivisionID", SqlDbType.NVarChar, 9, IIf(DivisionID Is Nothing, String.Empty, DivisionID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CustomInvoiceNo", SqlDbType.NVarChar, 9, IIf(CustomInvoiceNo Is Nothing, String.Empty, CustomInvoiceNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectCode", SqlDbType.NVarChar, 6, IIf(ProjectCode Is Nothing, String.Empty, ProjectCode))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BatchNo", SqlDbType.Int, 10, IIf(BatchNo = Nothing, 0, BatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FwdBatchNo", SqlDbType.Int, 10, IIf(FwdBatchNo = Nothing, 0, FwdBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RtnBatchNo", SqlDbType.Int, 10, IIf(RtnBatchNo = Nothing, 0, RtnBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID", SqlDbType.Int, 10, IIf(StatusID = Nothing, 0, StatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.INC.incProvision)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.INC.incProvision(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function incProvisionSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DivisionID As String, ByVal CustomInvoiceNo As String, ByVal ProjectCode As String, ByVal BatchNo As Int32, ByVal FwdBatchNo As Int32, ByVal RtnBatchNo As Int32, ByVal StatusID As Int32) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incProvisionGetByID(ByVal SerialNo As Int32, ByVal Filter_DivisionID As String, ByVal Filter_CustomInvoiceNo As String, ByVal Filter_ProjectCode As String, ByVal Filter_BatchNo As Int32, ByVal Filter_StatusID As Int32) As SIS.INC.incProvision
      Return incProvisionGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function incProvisionInsert(ByVal Record As SIS.INC.incProvision) As SIS.INC.incProvision
      Dim _Rec As SIS.INC.incProvision = SIS.INC.incProvision.incProvisionGetNewRecord()
      With _Rec
        .DivisionID = SIS.INC.incProvision.GetProjectDivision(Record.ProjectCode)
        .CustomInvoiceNo = Record.CustomInvoiceNo
        .CustomInvoiceDate = Record.CustomInvoiceDate
        .ShippingBillNo = Record.ShippingBillNo
        .ShippingBillDate = Record.ShippingBillDate
        .ShippingBillCHA = Record.ShippingBillCHA
        .LEODate = Record.LEODate
        .CustomInvoiceAmount = Record.CustomInvoiceAmount
        .CustomInvoiceCurrency = Record.CustomInvoiceCurrency
        .CustomPLNo = Record.CustomPLNo
        .FinalInvoiceNo = Record.FinalInvoiceNo
        .FinalInvoiceDate = Record.FinalInvoiceDate
        .InvoiceType = Record.InvoiceType
        .DBKAmountProvisional = Record.DBKAmountProvisional
        .FOBAmount = Record.FOBAmount
        .ExchangeRateCustom = Record.ExchangeRateCustom
        .BillOfLadingNo = Record.BillOfLadingNo
        .BillOfLadingDate = Record.BillOfLadingDate
        .BuyerName = Record.BuyerName
        .ProjectCode = Record.ProjectCode
        .ITSHSCode = Record.ITSHSCode
        .ItemDescription = Record.ItemDescription
        .MEISAmount = Record.MEISAmount
        .LoadingPort = Record.LoadingPort
        .StatusID = enumInvStates.Free
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      Return SIS.INC.incProvision.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.INC.incProvision) As SIS.INC.incProvision
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincProvisionInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,10, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceNo",SqlDbType.NVarChar,10, Iif(Record.CustomInvoiceNo= "" ,Convert.DBNull, Record.CustomInvoiceNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceDate",SqlDbType.DateTime,21, Iif(Record.CustomInvoiceDate= "" ,Convert.DBNull, Record.CustomInvoiceDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShippingBillNo",SqlDbType.NVarChar,51, Iif(Record.ShippingBillNo= "" ,Convert.DBNull, Record.ShippingBillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShippingBillDate",SqlDbType.DateTime,21, Iif(Record.ShippingBillDate= "" ,Convert.DBNull, Record.ShippingBillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShippingBillCHA",SqlDbType.NVarChar,51, Iif(Record.ShippingBillCHA= "" ,Convert.DBNull, Record.ShippingBillCHA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LEODate",SqlDbType.DateTime,21, Iif(Record.LEODate= "" ,Convert.DBNull, Record.LEODate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceAmount",SqlDbType.Decimal,17, Record.CustomInvoiceAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceCurrency",SqlDbType.NVarChar,31, Iif(Record.CustomInvoiceCurrency= "" ,Convert.DBNull, Record.CustomInvoiceCurrency))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomPLNo",SqlDbType.NVarChar,10, Iif(Record.CustomPLNo= "" ,Convert.DBNull, Record.CustomPLNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinalInvoiceNo",SqlDbType.NVarChar,10, Iif(Record.FinalInvoiceNo= "" ,Convert.DBNull, Record.FinalInvoiceNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinalInvoiceDate",SqlDbType.DateTime,21, Iif(Record.FinalInvoiceDate= "" ,Convert.DBNull, Record.FinalInvoiceDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceType",SqlDbType.NVarChar,31, Iif(Record.InvoiceType= "" ,Convert.DBNull, Record.InvoiceType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBKAmountProvisional",SqlDbType.Decimal,17, Record.DBKAmountProvisional)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FOBAmount",SqlDbType.Decimal,17, Record.FOBAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExchangeRateCustom",SqlDbType.Decimal,17, Record.ExchangeRateCustom)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillOfLadingNo",SqlDbType.NVarChar,51, Iif(Record.BillOfLadingNo= "" ,Convert.DBNull, Record.BillOfLadingNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillOfLadingDate",SqlDbType.DateTime,21, Iif(Record.BillOfLadingDate= "" ,Convert.DBNull, Record.BillOfLadingDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerName",SqlDbType.NVarChar,101, Iif(Record.BuyerName= "" ,Convert.DBNull, Record.BuyerName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectCode",SqlDbType.NVarChar,7, Iif(Record.ProjectCode= "" ,Convert.DBNull, Record.ProjectCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ITSHSCode",SqlDbType.NVarChar,11, Iif(Record.ITSHSCode= "" ,Convert.DBNull, Record.ITSHSCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,251, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MEISAmount",SqlDbType.Decimal,17, Record.MEISAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoadingPort",SqlDbType.NVarChar,51, Iif(Record.LoadingPort= "" ,Convert.DBNull, Record.LoadingPort))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BatchNo",SqlDbType.Int,11, Record.BatchNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Record.CreatedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBK_BatchNo", SqlDbType.NVarChar, 51, IIf(Record.DBK_BatchNo = "", Convert.DBNull, Record.DBK_BatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBK_DocumentNo", SqlDbType.NVarChar, 51, IIf(Record.DBK_DocumentNo = "", Convert.DBNull, Record.DBK_DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBK_LineNo", SqlDbType.NVarChar, 51, IIf(Record.DBK_LineNo = "", Convert.DBNull, Record.DBK_LineNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MEIS_BatchNo", SqlDbType.NVarChar, 51, IIf(Record.MEIS_BatchNo = "", Convert.DBNull, Record.MEIS_BatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MEIS_DocumentNo", SqlDbType.NVarChar, 51, IIf(Record.MEIS_DocumentNo = "", Convert.DBNull, Record.MEIS_DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MEIS_LineNo", SqlDbType.NVarChar, 51, IIf(Record.MEIS_LineNo = "", Convert.DBNull, Record.MEIS_LineNo))
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
    Public Shared Function incProvisionUpdate(ByVal Record As SIS.INC.incProvision) As SIS.INC.incProvision
      Dim _Rec As SIS.INC.incProvision = SIS.INC.incProvision.incProvisionGetByID(Record.SerialNo)
      With _Rec
        .DivisionID = SIS.INC.incProvision.GetProjectDivision(Record.ProjectCode)
        .CustomInvoiceNo = Record.CustomInvoiceNo
        .CustomInvoiceDate = Record.CustomInvoiceDate
        .ShippingBillNo = Record.ShippingBillNo
        .ShippingBillDate = Record.ShippingBillDate
        .ShippingBillCHA = Record.ShippingBillCHA
        .LEODate = Record.LEODate
        .CustomInvoiceAmount = Record.CustomInvoiceAmount
        .CustomInvoiceCurrency = Record.CustomInvoiceCurrency
        .CustomPLNo = Record.CustomPLNo
        .FinalInvoiceNo = Record.FinalInvoiceNo
        .FinalInvoiceDate = Record.FinalInvoiceDate
        .InvoiceType = Record.InvoiceType
        .DBKAmountProvisional = Record.DBKAmountProvisional
        .FOBAmount = Record.FOBAmount
        .ExchangeRateCustom = Record.ExchangeRateCustom
        .BillOfLadingNo = Record.BillOfLadingNo
        .BillOfLadingDate = Record.BillOfLadingDate
        .BuyerName = Record.BuyerName
        .ProjectCode = Record.ProjectCode
        .ITSHSCode = Record.ITSHSCode
        .ItemDescription = Record.ItemDescription
        .MEISAmount = Record.MEISAmount
        .LoadingPort = Record.LoadingPort
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      Return SIS.INC.incProvision.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.INC.incProvision) As SIS.INC.incProvision
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincProvisionUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,10, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceNo",SqlDbType.NVarChar,10, Iif(Record.CustomInvoiceNo= "" ,Convert.DBNull, Record.CustomInvoiceNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceDate",SqlDbType.DateTime,21, Iif(Record.CustomInvoiceDate= "" ,Convert.DBNull, Record.CustomInvoiceDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShippingBillNo",SqlDbType.NVarChar,51, Iif(Record.ShippingBillNo= "" ,Convert.DBNull, Record.ShippingBillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShippingBillDate",SqlDbType.DateTime,21, Iif(Record.ShippingBillDate= "" ,Convert.DBNull, Record.ShippingBillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShippingBillCHA",SqlDbType.NVarChar,51, Iif(Record.ShippingBillCHA= "" ,Convert.DBNull, Record.ShippingBillCHA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LEODate",SqlDbType.DateTime,21, Iif(Record.LEODate= "" ,Convert.DBNull, Record.LEODate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceAmount",SqlDbType.Decimal,17, Record.CustomInvoiceAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceCurrency",SqlDbType.NVarChar,31, Iif(Record.CustomInvoiceCurrency= "" ,Convert.DBNull, Record.CustomInvoiceCurrency))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomPLNo",SqlDbType.NVarChar,10, Iif(Record.CustomPLNo= "" ,Convert.DBNull, Record.CustomPLNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinalInvoiceNo",SqlDbType.NVarChar,10, Iif(Record.FinalInvoiceNo= "" ,Convert.DBNull, Record.FinalInvoiceNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinalInvoiceDate",SqlDbType.DateTime,21, Iif(Record.FinalInvoiceDate= "" ,Convert.DBNull, Record.FinalInvoiceDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceType",SqlDbType.NVarChar,31, Iif(Record.InvoiceType= "" ,Convert.DBNull, Record.InvoiceType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBKAmountProvisional",SqlDbType.Decimal,17, Record.DBKAmountProvisional)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FOBAmount",SqlDbType.Decimal,17, Record.FOBAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExchangeRateCustom",SqlDbType.Decimal,17, Record.ExchangeRateCustom)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillOfLadingNo",SqlDbType.NVarChar,51, Iif(Record.BillOfLadingNo= "" ,Convert.DBNull, Record.BillOfLadingNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillOfLadingDate",SqlDbType.DateTime,21, Iif(Record.BillOfLadingDate= "" ,Convert.DBNull, Record.BillOfLadingDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerName",SqlDbType.NVarChar,101, Iif(Record.BuyerName= "" ,Convert.DBNull, Record.BuyerName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectCode",SqlDbType.NVarChar,7, Iif(Record.ProjectCode= "" ,Convert.DBNull, Record.ProjectCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ITSHSCode",SqlDbType.NVarChar,11, Iif(Record.ITSHSCode= "" ,Convert.DBNull, Record.ITSHSCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,251, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MEISAmount",SqlDbType.Decimal,17, Record.MEISAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoadingPort",SqlDbType.NVarChar,51, Iif(Record.LoadingPort= "" ,Convert.DBNull, Record.LoadingPort))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BatchNo",SqlDbType.Int,11, Record.BatchNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Record.CreatedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBK_BatchNo", SqlDbType.NVarChar, 51, IIf(Record.DBK_BatchNo = "", Convert.DBNull, Record.DBK_BatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBK_DocumentNo", SqlDbType.NVarChar, 51, IIf(Record.DBK_DocumentNo = "", Convert.DBNull, Record.DBK_DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBK_LineNo", SqlDbType.NVarChar, 51, IIf(Record.DBK_LineNo = "", Convert.DBNull, Record.DBK_LineNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MEIS_BatchNo", SqlDbType.NVarChar, 51, IIf(Record.MEIS_BatchNo = "", Convert.DBNull, Record.MEIS_BatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MEIS_DocumentNo", SqlDbType.NVarChar, 51, IIf(Record.MEIS_DocumentNo = "", Convert.DBNull, Record.MEIS_DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MEIS_LineNo", SqlDbType.NVarChar, 51, IIf(Record.MEIS_LineNo = "", Convert.DBNull, Record.MEIS_LineNo))
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
    Public Shared Function incProvisionDelete(ByVal Record As SIS.INC.incProvision) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincProvisionDelete"
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
