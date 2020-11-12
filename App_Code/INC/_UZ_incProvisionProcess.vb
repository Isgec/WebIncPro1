Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.INC
  Partial Public Class incProvisionProcess
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
    Public Shared Function ReturnWF(ByVal SerialNo As Int32, Optional RtnBatch As Integer = 0) As SIS.INC.incProvisionProcess
      Dim Results As SIS.INC.incProvisionProcess = incProvisionProcessGetByID(SerialNo)
      If RtnBatch = 0 Then RtnBatch = SIS.INC.incProvision.GetNextRtnBatchNo()
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
          SIS.INC.incProvision.UpdateData(Results)
      End Select
      Return Results
    End Function
    Public Shared Function ReturnAllSubmitted(FWDBatchNo As Integer, RtnBatchNo As Integer) As Integer
      Dim mRet As Integer = 0
      Dim RtnBatch As Integer = SIS.INC.incProvision.GetNextRtnBatchNo()
      Dim Sql As String = ""
      Sql &= "  Update INC_Provision SET "
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
    Public Shared Shadows Function ProcessWF(ByVal SerialNo As Int32, Optional VchBatch As Integer = 0, Optional y As List(Of SIS.TA.taPostVoucherResult) = Nothing) As SIS.INC.incProvisionProcess
      Dim Results As SIS.INC.incProvisionProcess = incProvisionProcessGetByID(SerialNo)
      Dim DBK_BatchNo As String = y(0).BatchNo
      Dim DBK_DocumentNo As String = y(0).DocumentNo
      Dim DBK_LineNo As String = y(0).LineNo
      Dim MEIS_BatchNo As String = y(1).BatchNo
      Dim MEIS_DocumentNo As String = y(1).DocumentNo
      Dim MEIS_LineNo As String = y(1).LineNo

      If VchBatch = 0 Then VchBatch = SIS.INC.incProvision.GetNextVchBatchNo()
      Select Case Results.StatusID
        Case enumInvStates.Submitted
          With Results
            .ProcessedBy = HttpContext.Current.Session("LoginID")
            .ProcessedOn = Now
            .StatusID = enumInvStates.Processed
            .IsReturned = False
            .VchBatchNo = VchBatch
            .Selected = False
            .DBK_BatchNo = DBK_BatchNo
            .DBK_DocumentNo = DBK_DocumentNo
            .DBK_LineNo = DBK_LineNo
            .MEIS_BatchNo = MEIS_BatchNo
            .MEIS_DocumentNo = MEIS_DocumentNo
            .MEIS_LineNo = MEIS_LineNo
          End With
          SIS.INC.incProvision.UpdateData(Results)
      End Select
      Return Results
    End Function
    Public Shared Function ProcessAllSubmitted(FWDBatchNo As Integer, RtnBatchNo As Integer, vchBatch As Integer, y As List(Of SIS.TA.taPostVoucherResult)) As Integer
      Dim mRet As Integer = 0
      Dim DBK_BatchNo As String = y(0).BatchNo
      Dim DBK_DocumentNo As String = y(0).DocumentNo
      Dim DBK_LineNo As String = y(0).LineNo
      Dim MEIS_BatchNo As String = y(1).BatchNo
      Dim MEIS_DocumentNo As String = y(1).DocumentNo
      Dim MEIS_LineNo As String = y(1).LineNo
      Dim Sql As String = ""
      Sql &= "  Update INC_Provision SET "
      Sql &= "    ProcessedBy='" & HttpContext.Current.Session("LoginID") & "', "
      Sql &= "    ProcessedOn=Convert(Datetime,'" & Now.ToString("dd/MM/yyyy HH:mm") & "',103), "
      Sql &= "    StatusID=" & enumInvStates.Processed & ", "
      Sql &= "    IsReturned = 0, "
      Sql &= "    VchBatchNo=" & vchBatch & ", "
      Sql &= "    DBK_BatchNo='" & DBK_BatchNo & "', "
      Sql &= "    DBK_DocumentNo='" & DBK_DocumentNo & "', "
      Sql &= "    DBK_LineNo='" & DBK_LineNo & "', "
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
    Public Shared Function GetVchData(SNs As String, FWDBatchNo As Integer, RtnBatchNo As Integer) As List(Of SIS.INC.vchData)
      Dim Results As New List(Of SIS.INC.vchData)
      Dim Sql As String = ""
      Sql &= "  Select "
      Sql &= "    DivisionID, "
      Sql &= "    ProjectCode, "
      Sql &= "    Sum(DBKAmountProvisional) as DAmt, "
      Sql &= "    Sum(MEISAmount) as MAmt "
      Sql &= "  From INC_Provision "
      Sql &= "  Where StatusID=" & enumInvStates.Submitted
      If SNs <> "" Then
        Sql &= " AND SerialNo IN (" & SNs & ")"
      Else
        If FWDBatchNo > 0 Then
          Sql &= " AND FwdBatchNo=" & FWDBatchNo
        End If
        If RtnBatchNo > 0 Then
          Sql &= " AND RtnBatchNo=" & RtnBatchNo
        End If
      End If
      Sql &= "  Group By "
      Sql &= "    DivisionID, "
      Sql &= "    ProjectCode "
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

    Public Shared Function UZ_incProvisionProcessSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DivisionID As String, ByVal CustomInvoiceNo As String, ByVal ProjectCode As String, ByVal FwdBatchNo As Int32, ByVal RtnBatchNo As Int32, ByVal VchBatchNo As Int32, ByVal StatusID As Int32) As List(Of SIS.INC.incProvisionProcess)
      Dim Results As List(Of SIS.INC.incProvisionProcess) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spinc_LG_ProvisionProcessSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spinc_LG_ProvisionProcessSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DivisionID", SqlDbType.NVarChar, 9, IIf(DivisionID Is Nothing, String.Empty, DivisionID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CustomInvoiceNo", SqlDbType.NVarChar, 9, IIf(CustomInvoiceNo Is Nothing, String.Empty, CustomInvoiceNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectCode", SqlDbType.NVarChar, 6, IIf(ProjectCode Is Nothing, String.Empty, ProjectCode))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FwdBatchNo", SqlDbType.Int, 10, IIf(FwdBatchNo = Nothing, 0, FwdBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RtnBatchNo", SqlDbType.Int, 10, IIf(RtnBatchNo = Nothing, 0, RtnBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VchBatchNo", SqlDbType.Int, 10, IIf(VchBatchNo = Nothing, 0, VchBatchNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID", SqlDbType.Int, 10, IIf(StatusID = Nothing, 0, StatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function UZ_incProvisionProcessUpdate(ByVal Record As SIS.INC.incProvisionProcess) As SIS.INC.incProvisionProcess
      Dim _Result As SIS.INC.incProvisionProcess = incProvisionProcessUpdate(Record)
      Return _Result
    End Function
  End Class
  Public Class vchDB
    Public Property dbk As New List(Of SIS.INC.vchData)
    Public Property meis As New List(Of SIS.INC.vchData)
  End Class
  Public Class vchData
    Public Property Seq As Integer = 0
    Public Property DivisionID As String = ""
    Public Property GLCode As String = ""
    Public Property BankName As String = ""
    Public Property ProjectCode As String = ""
    Public Property State As String = "UP"
    Public Property Amt As String = ""
    Public Property DAmt As String = ""
    Public Property MAmt As String = ""
    Public Property DrCr As String = ""
    Public Property Remarks As String = ""
    Public Shared Function GetHTML(xData As List(Of SIS.INC.vchData), IsDBK As Boolean) As String
      Dim mRet As String = ""
      mRet &= "<div class='x-div'>"
      mRet &= "<table class='x-tbl'>"
      mRet &= "<tr class='x-h-tbl'>"
      mRet &= "<td>Unit</td><td>GL Code</td><td>Dim-1</td><td>Dim-5</td><td>Amount</td><td>Dr/Cr</td><td>Remarks</td></tr>"
      For Each xd As SIS.INC.vchData In xData
        '1. Debit Row
        mRet &= "<tr class='x-d1-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        If IsDBK Then
          mRet &= "<td>1550248</td>"
        Else
          mRet &= "<td>1550247</td>"
        End If
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        If IsDBK Then
          mRet &= "<td>" & xd.DAmt & "</td>"
        Else
          mRet &= "<td>" & xd.MAmt & "</td>"
        End If
        mRet &= "<td>Debit</td>"
        If IsDBK Then
          mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        Else
          mRet &= "<td>" & "MRIS Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        End If
        mRet &= "</tr>"
        '2 Credit Row
        mRet &= "<tr class='x-d2-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        If IsDBK Then
          mRet &= "<td>5622110</td>"
        Else
          mRet &= "<td>5622110</td>"
        End If
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        If IsDBK Then
          mRet &= "<td>" & xd.DAmt & "</td>"
        Else
          mRet &= "<td>" & xd.MAmt & "</td>"
        End If
        mRet &= "<td>Credit</td>"
        If IsDBK Then
          mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        Else
          mRet &= "<td>" & "MRIS Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        End If
        mRet &= "</tr>"
      Next
      mRet &= "</table></div>"
      Return mRet
    End Function

    Public Shared Function GetHTMLDBK(xData As List(Of SIS.INC.vchData)) As String
      Dim mRet As String = ""
      mRet &= "<div class='x-div'>"
      mRet &= "<table class='x-tbl'>"
      mRet &= "<tr class='x-h-tbl'>"
      mRet &= "<td>Unit</td><td>GL Code</td><td>Dim-1</td><td>Dim-5</td><td>Amount</td><td>Dr/Cr</td><td>Remarks</td></tr>"
      For Each xd As SIS.INC.vchData In xData
        'A Realization
        '1. Debit Row
        mRet &= "<tr class='x-d1-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        mRet &= "<td>" & xd.GLCode & "</td>"
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        mRet &= "<td>" & xd.DAmt & "</td>"
        mRet &= "<td>Debit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & ", " & xd.BankName & "</td>"
        mRet &= "</tr>"
        '2 Credit Row
        mRet &= "<tr class='x-d2-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        mRet &= "<td>5622110</td>"
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        mRet &= "<td>" & xd.DAmt & "</td>"
        mRet &= "<td>Credit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & ", " & xd.BankName & "</td>"
        mRet &= "</tr>"
        'B Provision Reversal
        '1. Debit Row
        mRet &= "<tr class='x-d1-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        mRet &= "<td>5622110</td>"
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        mRet &= "<td>" & xd.MAmt & "</td>"
        mRet &= "<td>Debit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        mRet &= "</tr>"
        '2 Credit Row
        mRet &= "<tr class='x-d2-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        mRet &= "<td>1550248</td>"
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        mRet &= "<td>" & xd.DAmt & "</td>"
        mRet &= "<td>Credit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        mRet &= "</tr>"
      Next
      mRet &= "</table></div>"
      Return mRet
    End Function

    Public Shared Function GetHTMLMEIS(xData As List(Of SIS.INC.vchData)) As String
      Dim mRet As String = ""
      mRet &= "<div class='x-div'>"
      mRet &= "<table class='x-tbl'>"
      mRet &= "<tr class='x-h-tbl'>"
      mRet &= "<td>Unit</td><td>GL Code</td><td>Dim-1</td><td>Dim-5</td><td>Amount</td><td>Dr/Cr</td><td>Remarks</td></tr>"
      For Each xd As SIS.INC.vchData In xData
        'A Realization
        '1. Debit Row
        mRet &= "<tr class='x-d1-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        mRet &= "<td>" & xd.GLCode & "</td>"
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        mRet &= "<td>" & xd.DAmt & "</td>"
        mRet &= "<td>Debit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & ", " & xd.BankName & "</td>"
        mRet &= "</tr>"
        '2 Credit Row
        mRet &= "<tr class='x-d2-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        mRet &= "<td>1550247</td>"
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        mRet &= "<td>" & xd.DAmt & "</td>"
        mRet &= "<td>Credit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & ", " & xd.BankName & "</td>"
        mRet &= "</tr>"
        'B Provision Reversal
        '1. Debit Row
        mRet &= "<tr class='x-d1-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        mRet &= "<td>1550247</td>"
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        mRet &= "<td>" & xd.MAmt & "</td>"
        mRet &= "<td>Debit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        mRet &= "</tr>"
        '2 Credit Row
        mRet &= "<tr class='x-d2-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        mRet &= "<td>1550248</td>"
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        mRet &= "<td>" & xd.DAmt & "</td>"
        mRet &= "<td>Credit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        mRet &= "</tr>"
      Next
      mRet &= "</table></div>"
      Return mRet
    End Function

    Public Sub New(rd As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, rd)
    End Sub
    Public Sub New()

    End Sub
  End Class
End Namespace
