Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.INC
  Partial Public Class incMEISRealization
    Public Property Selected As Boolean = False
    Public ReadOnly Property StatusName As String
      Get
        Return System.Enum.GetName(GetType(enumInvStates), StatusID)
      End Get
    End Property

    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Try
        Select Case StatusID
          Case enumInvStates.Free
            mRet = Drawing.Color.Black
            If IsReturned Then mRet = Drawing.Color.Red
          Case enumInvStates.Submitted
            mRet = Drawing.Color.Green
          Case enumInvStates.Processed
            mRet = Drawing.Color.DarkGoldenrod
          Case enumInvStates.Returned
            mRet = Drawing.Color.Red
        End Select
      Catch ex As Exception
      End Try
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumInvStates.Free, enumInvStates.Returned
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumInvStates.Free, enumInvStates.Returned
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SelectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumInvStates.Free, enumInvStates.Returned
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumInvStates.Free, enumInvStates.Returned
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal SerialNo As Int32) As SIS.INC.incMEISRealization
      Dim Results As SIS.INC.incMEISRealization = incMEISRealizationGetByID(SerialNo)
      Select Case Results.StatusID
        Case enumInvStates.Free, enumInvStates.Returned
          SIS.INC.incMEISRealization.incMEISRealizationDelete(Results)
      End Select
      Results.Selected = False
      Return Results
    End Function
    Public Shared Function DeleteAllFree(BatchNo As Integer, FWDBatchNo As Integer, RtnBatchNo As Integer) As Integer
      Dim mRet As Integer = 0
      Dim Sql As String = ""
      Sql = " Delete INC_MEISRealization "
      Sql &= " where StatusID IN (" & enumInvStates.Free & "," & enumInvStates.Returned & ")"
      If BatchNo > 0 Then
        Sql &= " AND BatchNo=" & BatchNo
      End If
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
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumInvStates.Free, enumInvStates.Returned
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal SerialNo As Int32, Optional FwdBatch As Integer = 0) As SIS.INC.incMEISRealization
      Dim Results As SIS.INC.incMEISRealization = incMEISRealizationGetByID(SerialNo)
      If FwdBatch = 0 Then FwdBatch = SIS.INC.incMEISRealization.GetNextFwdBatchNo()
      Select Case Results.StatusID
        Case enumInvStates.Free, enumInvStates.Returned
          With Results
            .CreatedBy = HttpContext.Current.Session("LoginID")
            .CreatedOn = Now
            .StatusID = enumInvStates.Submitted
            .IsReturned = False
            .FwdBatchNo = FwdBatch
            .Selected = False
          End With
          SIS.INC.incMEISRealization.UpdateData(Results)
      End Select
      Return Results
    End Function
    Public Shared Function InitiateAllFree(BatchNo As Integer, FWDBatchNo As Integer, RtnBatchNo As Integer) As Integer
      Dim mRet As Integer = 0
      Dim FwdBatch As Integer = GetNextFwdBatchNo()
      Dim Sql As String = ""
      Sql &= "  Update INC_MEISRealization SET "
      Sql &= "    CreatedBy='" & HttpContext.Current.Session("LoginID") & "', "
      Sql &= "    CreatedOn=Convert(Datetime,'" & Now.ToString("dd/MM/yyyy HH:mm") & "',103), "
      Sql &= "    StatusID=" & enumInvStates.Submitted & ", "
      Sql &= "    IsReturned = 0, "
      Sql &= "    FwdBatchNo=" & FwdBatch
      Sql &= "  Where StatusID IN (" & enumInvStates.Free & "," & enumInvStates.Returned & ")"
      If BatchNo > 0 Then
        Sql &= " AND BatchNo=" & BatchNo
      End If
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
    Public Shared Function GetByCommercialInvoiceNo(ByVal CInvNo As String) As SIS.INC.incMEISRealization
      Dim Results As SIS.INC.incMEISRealization = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select top 1 * from INC_MEISRealization where CustomInvoiceNo='" & CInvNo & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.INC.incMEISRealization(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetNextBatchNo() As Int32
      Dim mRet As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select isnull(max(BatchNo),0)+1 as nb from INC_MEISRealization"
          Con.Open()
          mRet = Cmd.ExecuteScalar
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function GetNextFwdBatchNo() As Int32
      Dim mRet As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select isnull(max(FwdBatchNo),0)+1 as nb from INC_MEISRealization"
          Con.Open()
          mRet = Cmd.ExecuteScalar
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function GetNextRtnBatchNo() As Int32
      Dim mRet As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select isnull(max(RtnBatchNo),0)+1 as nb from INC_MEISRealization"
          Con.Open()
          mRet = Cmd.ExecuteScalar
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function GetNextVchBatchNo() As Int32
      Dim mRet As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select isnull(max(VchBatchNo),0)+1 as nb from INC_MEISRealization"
          Con.Open()
          mRet = Cmd.ExecuteScalar
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function UZ_incMEISRealizationSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CustomInvoiceNo As String, ByVal BankID As Int32, ByVal StatusID As Int32, ByVal BatchNo As Int32, ByVal FwdBatchNo As Int32, ByVal RtnBatchNo As Int32) As List(Of SIS.INC.incMEISRealization)
      Dim Results As List(Of SIS.INC.incMEISRealization) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spincMEISRealizationSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spincMEISRealizationSelectListFilteres"
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
          Results = New List(Of SIS.INC.incMEISRealization)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.INC.incMEISRealization(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_incMEISRealizationInsert(ByVal Record As SIS.INC.incMEISRealization) As SIS.INC.incMEISRealization
      Dim _Result As SIS.INC.incMEISRealization = incMEISRealizationInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_incMEISRealizationUpdate(ByVal Record As SIS.INC.incMEISRealization) As SIS.INC.incMEISRealization
      Dim _Result As SIS.INC.incMEISRealization = incMEISRealizationUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_incMEISRealizationDelete(ByVal Record As SIS.INC.incMEISRealization) As Integer
      Dim _Result as Integer = incMEISRealizationDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_CustomInvoiceNo"), TextBox).Text = ""
        CType(.FindControl("F_SBillNo"), TextBox).Text = ""
        CType(.FindControl("F_SBillDate"), TextBox).Text = ""
        CType(.FindControl("F_FileNo"), TextBox).Text = ""
        CType(.FindControl("F_FileDate"), TextBox).Text = ""
        CType(.FindControl("F_MEISNo"), TextBox).Text = ""
        CType(.FindControl("F_MEISDate"), TextBox).Text = ""
        CType(.FindControl("F_MEISAmount"), TextBox).Text = 0
        CType(.FindControl("F_OtherTax"), TextBox).Text = 0
        CType(.FindControl("F_SaleAmount"), TextBox).Text = 0
        CType(.FindControl("F_RealisedAmount"), TextBox).Text = 0
        CType(.FindControl("F_SoldTo"), TextBox).Text = ""
        CType(.FindControl("F_BankID"),Object).SelectedValue = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
