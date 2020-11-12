Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.INC
  <DataObject()> _
  Partial Public Class incMEISRealizationProcess
    Inherits SIS.INC.incMEISRealization
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incMEISRealizationProcessGetNewRecord() As SIS.INC.incMEISRealizationProcess
      Return New SIS.INC.incMEISRealizationProcess()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incMEISRealizationProcessSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FwdBatchNo As Int32, ByVal RtnBatchNo As Int32, ByVal VchBatchNo As Int32, ByVal CustomInvoiceNo As String, ByVal BankID As Int32, ByVal StatusID As Int32) As List(Of SIS.INC.incMEISRealizationProcess)
      Dim Results As List(Of SIS.INC.incMEISRealizationProcess) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spincMEISRealizationProcessSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spincMEISRealizationProcessSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FwdBatchNo",SqlDbType.Int,10, IIf(FwdBatchNo = Nothing, 0,FwdBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RtnBatchNo",SqlDbType.Int,10, IIf(RtnBatchNo = Nothing, 0,RtnBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VchBatchNo",SqlDbType.Int,10, IIf(VchBatchNo = Nothing, 0,VchBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CustomInvoiceNo",SqlDbType.NVarChar,9, IIf(CustomInvoiceNo Is Nothing, String.Empty,CustomInvoiceNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BankID",SqlDbType.Int,10, IIf(BankID = Nothing, 0,BankID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.INC.incMEISRealizationProcess)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.INC.incMEISRealizationProcess(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function incMEISRealizationProcessSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FwdBatchNo As Int32, ByVal RtnBatchNo As Int32, ByVal VchBatchNo As Int32, ByVal CustomInvoiceNo As String, ByVal BankID As Int32, ByVal StatusID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incMEISRealizationProcessGetByID(ByVal SerialNo As Int32) As SIS.INC.incMEISRealizationProcess
      Dim Results As SIS.INC.incMEISRealizationProcess = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spincMEISRealizationSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.INC.incMEISRealizationProcess(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function incMEISRealizationProcessGetByID(ByVal SerialNo As Int32, ByVal Filter_FwdBatchNo As Int32, ByVal Filter_RtnBatchNo As Int32, ByVal Filter_VchBatchNo As Int32, ByVal Filter_CustomInvoiceNo As String, ByVal Filter_BankID As Int32, ByVal Filter_StatusID As Int32) As SIS.INC.incMEISRealizationProcess
      Dim Results As SIS.INC.incMEISRealizationProcess = SIS.INC.incMEISRealizationProcess.incMEISRealizationProcessGetByID(SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function incMEISRealizationProcessInsert(ByVal Record As SIS.INC.incMEISRealizationProcess) As SIS.INC.incMEISRealizationProcess
      Dim _Rec As SIS.INC.incMEISRealizationProcess = SIS.INC.incMEISRealizationProcess.incMEISRealizationProcessGetNewRecord()
      With _Rec
        .FwdBatchNo = Record.FwdBatchNo
        .RtnBatchNo = Record.RtnBatchNo
        .VchBatchNo = Record.VchBatchNo
        .IsReturned = Record.IsReturned
        .ProcessedBy = Record.ProcessedBy
        .ProcessedOn = Record.ProcessedOn
        .CustomInvoiceNo = Record.CustomInvoiceNo
        .SBillNo = Record.SBillNo
        .SBillDate = Record.SBillDate
        .FileNo = Record.FileNo
        .FileDate = Record.FileDate
        .MEISNo = Record.MEISNo
        .MEISDate = Record.MEISDate
        .MEISAmount = Record.MEISAmount
        .OtherTax = Record.OtherTax
        .SaleAmount = Record.SaleAmount
        .RealisedAmount = Record.RealisedAmount
        .SoldTo = Record.SoldTo
        .BankID = Record.BankID
        .BatchNo = Record.BatchNo
        .StatusID = Record.StatusID
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
      End With
      Return SIS.INC.incMEISRealizationProcess.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function incMEISRealizationProcessUpdate(ByVal Record As SIS.INC.incMEISRealizationProcess) As SIS.INC.incMEISRealizationProcess
      Dim _Rec As SIS.INC.incMEISRealizationProcess = SIS.INC.incMEISRealizationProcess.incMEISRealizationProcessGetByID(Record.SerialNo)
      With _Rec
        .FwdBatchNo = Record.FwdBatchNo
        .RtnBatchNo = Record.RtnBatchNo
        .VchBatchNo = Record.VchBatchNo
        .IsReturned = Record.IsReturned
        .ProcessedBy = Record.ProcessedBy
        .ProcessedOn = Record.ProcessedOn
        .CustomInvoiceNo = Record.CustomInvoiceNo
        .SBillNo = Record.SBillNo
        .SBillDate = Record.SBillDate
        .FileNo = Record.FileNo
        .FileDate = Record.FileDate
        .MEISNo = Record.MEISNo
        .MEISDate = Record.MEISDate
        .MEISAmount = Record.MEISAmount
        .OtherTax = Record.OtherTax
        .SaleAmount = Record.SaleAmount
        .RealisedAmount = Record.RealisedAmount
        .SoldTo = Record.SoldTo
        .BankID = Record.BankID
        .BatchNo = Record.BatchNo
        .StatusID = Record.StatusID
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
      End With
      Return SIS.INC.incMEISRealizationProcess.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
