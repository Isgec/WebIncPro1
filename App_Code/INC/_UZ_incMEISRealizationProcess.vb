Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.INC
  Partial Public Class incMEISRealizationProcess
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property SelectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumInvStates.Submitted
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ReturnWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumInvStates.Submitted
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ReturnWF(ByVal SerialNo As Int32, Optional RtnBatch As Integer = 0) As SIS.INC.incMEISRealizationProcess
      Dim Results As SIS.INC.incMEISRealizationProcess = incMEISRealizationProcessGetByID(SerialNo)
      If RtnBatch = 0 Then RtnBatch = SIS.INC.incMEISRealizationProcess.GetNextRtnBatchNo()
      Select Case Results.StatusID
        Case enumInvStates.Submitted
          With Results
            .ProcessedBy = HttpContext.Current.Session("LoginID")
            .ProcessedOn = Now
            .StatusID = enumInvStates.Returned
            .IsReturned = True
            .RtnBatchNo = RtnBatch
            .Selected = False
          End With
          SIS.INC.incMEISRealizationProcess.UpdateData(Results)
      End Select
      Return Results
    End Function
    Public Shared Function ReturnAllSubmitted(FWDBatchNo As Integer, RtnBatchNo As Integer) As Integer
      Dim mRet As Integer = 0
      Dim RtnBatch As Integer = SIS.INC.incMEISRealizationProcess.GetNextRtnBatchNo()
      Dim Sql As String = ""
      Sql &= "  Update INC_MEISRealization SET "
      Sql &= "    ProcessedBy='" & HttpContext.Current.Session("LoginID") & "', "
      Sql &= "    ProcessedOn=Convert(Datetime,'" & Now.ToString("dd/MM/yyyy HH:mm") & "',103), "
      Sql &= "    StatusID=" & enumInvStates.Returned & ", "
      Sql &= "    IsReturned = 1, "
      Sql &= "    RtnBatchNo=" & RtnBatch
      Sql &= "  Where StatusID=" & enumInvStates.Submitted
      If FWDBatchNo > 0 Then
        Sql &= " AND FwdBatchNo=" & FWDBatchNo
      End If
      If RtnBatchNo > 0 Then
        Sql &= " AND RtnBatchNo=" & RtnBatchNo
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          mRet = Cmd.ExecuteNonQuery
        End Using
      End Using
      Return mRet
    End Function
    Public Shadows ReadOnly Property ProcessWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumInvStates.Submitted
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function ProcessWF(ByVal SerialNo As Int32, Optional VchBatch As Integer = 0, Optional y As SIS.TA.taPostVoucherResult = Nothing) As SIS.INC.incMEISRealizationProcess
      Dim Results As SIS.INC.incMEISRealizationProcess = incMEISRealizationProcessGetByID(SerialNo)
      Dim MEIS_BatchNo As String = y.BatchNo
      Dim MEIS_DocumentNo As String = y.DocumentNo
      Dim MEIS_LineNo As String = y.LineNo

      If VchBatch = 0 Then VchBatch = SIS.INC.incMEISRealizationProcess.GetNextVchBatchNo()
      Select Case Results.StatusID
        Case enumInvStates.Submitted
          With Results
            .ProcessedBy = HttpContext.Current.Session("LoginID")
            .ProcessedOn = Now
            .StatusID = enumInvStates.Processed
            .IsReturned = False
            .VchBatchNo = VchBatch
            .Selected = False
            .MEIS_BatchNo = MEIS_BatchNo
            .MEIS_DocumentNo = MEIS_DocumentNo
            .MEIS_LineNo = MEIS_LineNo
          End With
          SIS.INC.incMEISRealizationProcess.UpdateData(Results)
          Dim pro As SIS.INC.incProvision = SIS.INC.incProvision.GetByCommercialInvoiceNo(Results.CustomInvoiceNo)
          With pro
            If .StatusID = enumInvStates.Processed Then
              .StatusID = enumInvStates.MEISRealized
            ElseIf .StatusID = enumInvStates.DBKRealized Then
              .StatusID = enumInvStates.Completed
            End If
          End With
          SIS.INC.incProvision.UpdateData(pro)
      End Select
      Return Results
    End Function
    'Select SerialNo in Memory, Which are selected for Voucher Posting
    'And Set only those records which are PREVIEW by user and Voucher Posted
    'enumInvoiceStatus.Selected for voucher posting
    Public Shared Function ProcessAllSubmitted(FWDBatchNo As Integer, RtnBatchNo As Integer, vchBatch As Integer, y As SIS.TA.taPostVoucherResult) As Integer
      Dim mRet As Integer = 0
      Dim MEIS_BatchNo As String = y.BatchNo
      Dim MEIS_DocumentNo As String = y.DocumentNo
      Dim MEIS_LineNo As String = y.LineNo
      Dim Sql As String = ""
      Sql &= "  Update INC_Provision SET "
      Sql &= "    StatusID= case when statusid=3 then 5 else case when statusid=4 then 6 end end "
      Sql &= "  Where StatusID in (3,4) "
      Sql &= "  AND CustomInvoiceNo in ("
      Sql &= "  select CustomInvoiceNo From INC_MEISRealization  "
      Sql &= "  Where StatusID=" & enumInvStates.Submitted
      If FWDBatchNo > 0 Then
        Sql &= " AND FwdBatchNo=" & FWDBatchNo
      End If
      If RtnBatchNo > 0 Then
        Sql &= " AND RtnBatchNo=" & RtnBatchNo
      End If
      Sql &= ")"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          mRet = Cmd.ExecuteNonQuery
        End Using
        Sql = ""
        Sql &= "  Update INC_MEISRealization SET "
        Sql &= "    StatusID=" & enumInvStates.Processed & ", "
        Sql &= "    IsReturned = 0, "
        Sql &= "    VchBatchNo=" & vchBatch & ", "
        Sql &= "    MEIS_BatchNo='" & MEIS_BatchNo & "', "
        Sql &= "    MEIS_DocumentNo='" & MEIS_DocumentNo & "', "
        Sql &= "    MEIS_LineNo='" & MEIS_LineNo & "' "
        Sql &= "  Where StatusID=" & enumInvStates.Submitted
        If FWDBatchNo > 0 Then
          Sql &= " AND FwdBatchNo=" & FWDBatchNo
        End If
        If RtnBatchNo > 0 Then
          Sql &= " AND RtnBatchNo=" & RtnBatchNo
        End If

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          mRet = Cmd.ExecuteNonQuery
        End Using

      End Using
      Return mRet
    End Function
    Public Shared Function GetVchData(SNs As String, FWDBatchNo As Integer, RtnBatchNo As Integer) As List(Of SIS.INC.vchData)
      Dim Results As New List(Of SIS.INC.vchData)
      Dim Sql As String = ""
      Sql &= "  Select "
      Sql &= "    aa.DivisionID, "
      Sql &= "    aa.ProjectCode, "
      Sql &= "    cc.GLCode, "
      Sql &= "    cc.BankName, "
      Sql &= "    Sum(bb.RealisedAmount) as DAmt, "
      Sql &= "    Sum(aa.MEISAmount) as MAmt "  'Provision Reverse Amount
      Sql &= "  From INC_MEISRealization as bb "
      Sql &= "  inner join INC_Provision as aa on aa.CustomInvoiceNo = bb.CustomInvoiceNo "
      Sql &= "  inner join INC_Banks as cc on cc.BankID = bb.BankID "
      Sql &= "  Where bb.StatusID=" & enumInvStates.Submitted
      Sql &= "  AND aa.StatusID IN (3,4) " 'Provision Must Be Processed or MEIS must be reversed. 
      If SNs <> "" Then
        Sql &= " AND bb.SerialNo IN (" & SNs & ")"
      Else
        If FWDBatchNo > 0 Then
          Sql &= " AND bb.FwdBatchNo=" & FWDBatchNo
        End If
        If RtnBatchNo > 0 Then
          Sql &= " AND bb.RtnBatchNo=" & RtnBatchNo
        End If
      End If
      Sql &= "  Group By "
      Sql &= "    aa.DivisionID, "
      Sql &= "    aa.ProjectCode, "
      Sql &= "    cc.GLCode, "
      Sql &= "    cc.BankName "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim I As Integer = 0
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.INC.vchData(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_incMEISRealizationProcessSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FwdBatchNo As Int32, ByVal RtnBatchNo As Int32, ByVal VchBatchNo As Int32, ByVal CustomInvoiceNo As String, ByVal BankID As Int32, ByVal StatusID As Int32) As List(Of SIS.INC.incMEISRealizationProcess)
      Dim Results As List(Of SIS.INC.incMEISRealizationProcess) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spinc_LG_MEISRealizationProcessSelectListSearch"
            Cmd.CommandText = "spincMEISRealizationProcessSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spinc_LG_MEISRealizationProcessSelectListFilteres"
            Cmd.CommandText = "spincMEISRealizationProcessSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FwdBatchNo", SqlDbType.Int, 10, IIf(FwdBatchNo = Nothing, 0, FwdBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RtnBatchNo", SqlDbType.Int, 10, IIf(RtnBatchNo = Nothing, 0, RtnBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VchBatchNo", SqlDbType.Int, 10, IIf(VchBatchNo = Nothing, 0, VchBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CustomInvoiceNo", SqlDbType.NVarChar, 9, IIf(CustomInvoiceNo Is Nothing, String.Empty, CustomInvoiceNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BankID", SqlDbType.Int, 10, IIf(BankID = Nothing, 0, BankID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID", SqlDbType.Int, 10, IIf(StatusID = Nothing, 0, StatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function UZ_incMEISRealizationProcessUpdate(ByVal Record As SIS.INC.incMEISRealizationProcess) As SIS.INC.incMEISRealizationProcess
      Dim _Result As SIS.INC.incMEISRealizationProcess = incMEISRealizationProcessUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
