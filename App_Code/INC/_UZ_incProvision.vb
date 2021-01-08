Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.INC
  Partial Public Class incProvision
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
    Public Shared Function DeleteWF(ByVal SerialNo As Int32) As SIS.INC.incProvision
      Dim Results As SIS.INC.incProvision = incProvisionGetByID(SerialNo)
      Select Case Results.StatusID
        Case enumInvStates.Free, enumInvStates.Returned
          SIS.INC.incProvision.incProvisionDelete(Results)
      End Select
      Results.Selected = False
      Return Results
    End Function
    Public Shared Function DeleteAllFree(BatchNo As Integer, FWDBatchNo As Integer, RtnBatchNo As Integer) As Integer
      Dim mRet As Integer = 0
      Dim Sql As String = ""
      Sql = " Delete INC_Provision "
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
    Public Shared Function InitiateWF(ByVal SerialNo As Int32, Optional FwdBatch As Integer = 0) As SIS.INC.incProvision
      Dim Results As SIS.INC.incProvision = incProvisionGetByID(SerialNo)
      If FwdBatch = 0 Then FwdBatch = SIS.INC.incProvision.GetNextFwdBatchNo()
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
          SIS.INC.incProvision.UpdateData(Results)
      End Select
      Return Results
    End Function
    Public Shared Function InitiateAllFree(BatchNo As Integer, FWDBatchNo As Integer, RtnBatchNo As Integer) As Integer
      Dim mRet As Integer = 0
      Dim FwdBatch As Integer = GetNextFwdBatchNo()
      Dim Sql As String = ""
      Sql &= "  Update INC_Provision SET "
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
    Public Shared Function UZ_incProvisionInsert(ByVal Record As SIS.INC.incProvision) As SIS.INC.incProvision
      Dim _Result As SIS.INC.incProvision = incProvisionInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_incProvisionUpdate(ByVal Record As SIS.INC.incProvision) As SIS.INC.incProvision
      Dim _Result As SIS.INC.incProvision = incProvisionUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_incProvisionDelete(ByVal Record As SIS.INC.incProvision) As Integer
      Dim _Result As Integer = incProvisionDelete(Record)
      Return _Result
    End Function
    Public Shared Function GetProjectDivision(ByVal cprj As String) As String
      Dim mRet As String = ""
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select isnull(t_ncmp,'') from ttppdm600" & Comp & " where t_cprj='" & cprj & "'"
          Con.Open()
          mRet = Cmd.ExecuteScalar
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function GetByCommercialInvoiceNo(ByVal CInvNo As String) As SIS.INC.incProvision
      Dim Results As SIS.INC.incProvision = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select top 1 * from INC_Provision where CustomInvoiceNo='" & CInvNo & "'"
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
    Public Shared Function GetNextBatchNo() As Int32
      Dim mRet As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select isnull(max(BatchNo),0)+1 as nb from INC_Provision"
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
          Cmd.CommandText = "select isnull(max(FwdBatchNo),0)+1 as nb from INC_Provision"
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
          Cmd.CommandText = "select isnull(max(RtnBatchNo),0)+1 as nb from INC_Provision"
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
          Cmd.CommandText = "select isnull(max(VchBatchNo),0)+1 as nb from INC_Provision"
          Con.Open()
          mRet = Cmd.ExecuteScalar
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function UZ_incProvisionSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DivisionID As String, ByVal CustomInvoiceNo As String, ByVal ProjectCode As String, ByVal BatchNo As Int32, ByVal FwdBatchNo As Int32, ByVal RtnBatchNo As Int32, ByVal StatusID As Int32) As List(Of SIS.INC.incProvision)
      Dim Results As List(Of SIS.INC.incProvision) = Nothing
      If OrderBy = "" Then OrderBy = "SerialNo DESC"
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
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_DivisionID"), TextBox).Text = ""
          CType(.FindControl("F_CustomInvoiceNo"), TextBox).Text = ""
          CType(.FindControl("F_CustomInvoiceDate"), TextBox).Text = ""
          CType(.FindControl("F_ShippingBillNo"), TextBox).Text = ""
          CType(.FindControl("F_ShippingBillDate"), TextBox).Text = ""
          CType(.FindControl("F_ShippingBillCHA"), TextBox).Text = ""
          CType(.FindControl("F_LEODate"), TextBox).Text = ""
          CType(.FindControl("F_CustomInvoiceAmount"), TextBox).Text = 0
          CType(.FindControl("F_CustomInvoiceCurrency"), TextBox).Text = ""
          CType(.FindControl("F_CustomPLNo"), TextBox).Text = ""
          CType(.FindControl("F_FinalInvoiceNo"), TextBox).Text = ""
          CType(.FindControl("F_FinalInvoiceDate"), TextBox).Text = ""
          CType(.FindControl("F_InvoiceType"), TextBox).Text = ""
          CType(.FindControl("F_DBKAmountProvisional"), TextBox).Text = 0
          CType(.FindControl("F_FOBAmount"), TextBox).Text = 0
          CType(.FindControl("F_ExchangeRateCustom"), TextBox).Text = 0
          CType(.FindControl("F_BillOfLadingNo"), TextBox).Text = ""
          CType(.FindControl("F_BillOfLadingDate"), TextBox).Text = ""
          CType(.FindControl("F_BuyerName"), TextBox).Text = ""
          CType(.FindControl("F_ProjectCode"), TextBox).Text = ""
          CType(.FindControl("F_ITSHSCode"), TextBox).Text = ""
          CType(.FindControl("F_ItemDescription"), TextBox).Text = ""
          CType(.FindControl("F_MEISAmount"), TextBox).Text = 0
          CType(.FindControl("F_LoadingPort"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
