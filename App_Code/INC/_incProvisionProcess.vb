Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.INC
  <DataObject()> _
  Partial Public Class incProvisionProcess
    Inherits SIS.INC.incProvision
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incProvisionProcessGetNewRecord() As SIS.INC.incProvisionProcess
      Return New SIS.INC.incProvisionProcess()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incProvisionProcessSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DivisionID As String, ByVal CustomInvoiceNo As String, ByVal ProjectCode As String, ByVal FwdBatchNo As Int32, ByVal RtnBatchNo As Int32, ByVal VchBatchNo As Int32, ByVal StatusID As Int32) As List(Of SIS.INC.incProvisionProcess)
      Dim Results As List(Of SIS.INC.incProvisionProcess) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spincProvisionProcessSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spincProvisionProcessSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DivisionID",SqlDbType.NVarChar,9, IIf(DivisionID Is Nothing, String.Empty,DivisionID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CustomInvoiceNo",SqlDbType.NVarChar,9, IIf(CustomInvoiceNo Is Nothing, String.Empty,CustomInvoiceNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectCode",SqlDbType.NVarChar,6, IIf(ProjectCode Is Nothing, String.Empty,ProjectCode))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FwdBatchNo",SqlDbType.Int,10, IIf(FwdBatchNo = Nothing, 0,FwdBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RtnBatchNo",SqlDbType.Int,10, IIf(RtnBatchNo = Nothing, 0,RtnBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VchBatchNo",SqlDbType.Int,10, IIf(VchBatchNo = Nothing, 0,VchBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.INC.incProvisionProcess)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.INC.incProvisionProcess(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function incProvisionProcessSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DivisionID As String, ByVal CustomInvoiceNo As String, ByVal ProjectCode As String, ByVal FwdBatchNo As Int32, ByVal RtnBatchNo As Int32, ByVal VchBatchNo As Int32, ByVal StatusID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incProvisionProcessGetByID(ByVal SerialNo As Int32) As SIS.INC.incProvisionProcess
      Dim Results As SIS.INC.incProvisionProcess = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincProvisionSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.INC.incProvisionProcess(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incProvisionProcessGetByID(ByVal SerialNo As Int32, ByVal Filter_DivisionID As String, ByVal Filter_CustomInvoiceNo As String, ByVal Filter_ProjectCode As String, ByVal Filter_FwdBatchNo As Int32, ByVal Filter_RtnBatchNo As Int32, ByVal Filter_VchBatchNo As Int32, ByVal Filter_StatusID As Int32) As SIS.INC.incProvisionProcess
      Dim Results As SIS.INC.incProvisionProcess = SIS.INC.incProvisionProcess.incProvisionProcessGetByID(SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function incProvisionProcessInsert(ByVal Record As SIS.INC.incProvisionProcess) As SIS.INC.incProvisionProcess
      Dim _Rec As SIS.INC.incProvisionProcess = SIS.INC.incProvisionProcess.incProvisionProcessGetNewRecord()
      With _Rec
        .DivisionID = Record.DivisionID
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
        .DBK_BatchNo = Record.DBK_BatchNo
        .DBK_DocumentNo = Record.DBK_DocumentNo
        .DBK_LineNo = Record.DBK_LineNo
        .MEIS_BatchNo = Record.MEIS_BatchNo
        .MEIS_DocumentNo = Record.MEIS_DocumentNo
        .MEIS_LineNo = Record.MEIS_LineNo
        .FwdBatchNo = Record.FwdBatchNo
        .RtnBatchNo = Record.RtnBatchNo
        .VchBatchNo = Record.VchBatchNo
        .IsReturned = Record.IsReturned
        .ProcessedBy = Record.ProcessedBy
        .ProcessedOn = Record.ProcessedOn
        .CreatedOn = Record.CreatedOn
        .CreatedBy = Record.CreatedBy
        .StatusID = Record.StatusID
        .BatchNo = Record.BatchNo
      End With
      Return SIS.INC.incProvisionProcess.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function incProvisionProcessUpdate(ByVal Record As SIS.INC.incProvisionProcess) As SIS.INC.incProvisionProcess
      Dim _Rec As SIS.INC.incProvisionProcess = SIS.INC.incProvisionProcess.incProvisionProcessGetByID(Record.SerialNo)
      With _Rec
        .DivisionID = Record.DivisionID
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
        .DBK_BatchNo = Record.DBK_BatchNo
        .DBK_DocumentNo = Record.DBK_DocumentNo
        .DBK_LineNo = Record.DBK_LineNo
        .MEIS_BatchNo = Record.MEIS_BatchNo
        .MEIS_DocumentNo = Record.MEIS_DocumentNo
        .MEIS_LineNo = Record.MEIS_LineNo
        .FwdBatchNo = Record.FwdBatchNo
        .RtnBatchNo = Record.RtnBatchNo
        .VchBatchNo = Record.VchBatchNo
        .IsReturned = Record.IsReturned
        .ProcessedBy = Record.ProcessedBy
        .ProcessedOn = Record.ProcessedOn
        .CreatedOn = Record.CreatedOn
        .CreatedBy = Record.CreatedBy
        .StatusID = Record.StatusID
        .BatchNo = Record.BatchNo
      End With
      Return SIS.INC.incProvisionProcess.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
