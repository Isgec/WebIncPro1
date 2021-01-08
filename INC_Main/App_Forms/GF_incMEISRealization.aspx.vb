Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class GF_incMEISRealization
  Inherits SIS.SYS.GridBase
  Public ReadOnly Property DownloadFree As String
    Get
      Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/INC_Main/App_Downloads/meisdownload.aspx?code=free', 'left=20,top=20,width=100,height=100,toolbar=0,resizable=0,scrollbars=0'); return false;"
    End Get
  End Property
  Protected Sub GVincMEISRealization_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVincMEISRealization.RowCommand
    If e.CommandName.ToLower = "ToggleSelect".ToLower Then
      Try
        For Each r As GridViewRow In GVincMEISRealization.Rows
          If r.RowType = DataControlRowType.DataRow Then
            Dim tmp As CheckBox = CType(r.FindControl("chkSelect"), CheckBox)
            If Not tmp.Visible Then Continue For
            tmp.Checked = Not tmp.Checked
          End If
        Next
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "DeleteSelected".ToLower Then
      Try
        Dim ActionTaken As Boolean = False
        If Not chkAllFree.Checked Then
          For Each r As GridViewRow In GVincMEISRealization.Rows
            If r.RowType = DataControlRowType.DataRow Then
              Dim tmp As CheckBox = CType(r.FindControl("chkSelect"), CheckBox)
              If Not tmp.Visible Then Continue For
              If tmp.Checked Then
                Try
                  Dim SerialNo As Int32 = GVincMEISRealization.DataKeys(r.RowIndex).Values("SerialNo")
                  SIS.INC.incMEISRealization.DeleteWF(SerialNo)
                  ActionTaken = True
                Catch ex As Exception
                  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
                End Try
              End If
            End If
          Next
        Else
          Try
            Dim Filter_BatchNo As Integer = 0
            Dim Filter_FwdBatchNo As Integer = 0
            Dim Filter_RtnBatchNo As Integer = 0
            Try
              Filter_BatchNo = Convert.ToInt32(F_BatchNo.Text)
            Catch ex As Exception
              Filter_BatchNo = 0
            End Try
            Try
              Filter_FwdBatchNo = Convert.ToInt32(F_FwdBatchNo.Text)
            Catch ex As Exception
              Filter_FwdBatchNo = 0
            End Try
            Try
              Filter_RtnBatchNo = Convert.ToInt32(F_RtnBatchNo.Text)
            Catch ex As Exception
              Filter_RtnBatchNo = 0
            End Try
            Dim mRet As Integer = SIS.INC.incMEISRealization.DeleteAllFree(Filter_BatchNo, Filter_FwdBatchNo, Filter_RtnBatchNo)
            If mRet > 0 Then
              ActionTaken = True
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(mRet & " Record(s) Deleted.") & "');", True)
            End If
          Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
          End Try
        End If
        If ActionTaken Then
          GVincMEISRealization.DataBind()
        End If
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "ForwardSelected".ToLower Then
      Try
        Dim ActionTaken As Boolean = False
        If Not chkAllFree.Checked Then
          Dim FwdBatch As Integer = SIS.INC.incMEISRealization.GetNextFwdBatchNo()
          For Each r As GridViewRow In GVincMEISRealization.Rows
            If r.RowType = DataControlRowType.DataRow Then
              Dim tmp As CheckBox = CType(r.FindControl("chkSelect"), CheckBox)
              If Not tmp.Visible Then Continue For
              If tmp.Checked Then
                Try
                  Dim SerialNo As Int32 = GVincMEISRealization.DataKeys(r.RowIndex).Values("SerialNo")
                  SIS.INC.incMEISRealization.InitiateWF(SerialNo, FwdBatch)
                  ActionTaken = True
                Catch ex As Exception
                  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
                End Try
              End If
            End If
          Next
        Else
          Try
            Dim Filter_BatchNo As Integer = 0
            Dim Filter_FwdBatchNo As Integer = 0
            Dim Filter_RtnBatchNo As Integer = 0
            Try
              Filter_BatchNo = Convert.ToInt32(F_BatchNo.Text)
            Catch ex As Exception
              Filter_BatchNo = 0
            End Try
            Try
              Filter_FwdBatchNo = Convert.ToInt32(F_FwdBatchNo.Text)
            Catch ex As Exception
              Filter_FwdBatchNo = 0
            End Try
            Try
              Filter_RtnBatchNo = Convert.ToInt32(F_RtnBatchNo.Text)
            Catch ex As Exception
              Filter_RtnBatchNo = 0
            End Try
            Dim mRet As Integer = SIS.INC.incMEISRealization.InitiateAllFree(Filter_BatchNo, Filter_FwdBatchNo, Filter_RtnBatchNo)
            If mRet > 0 Then
              ActionTaken = True
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(mRet & " Record(s) Forwarded.") & "');", True)
            End If
          Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
          End Try
        End If
        If ActionTaken Then
          GVincMEISRealization.DataBind()
        End If
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVincMEISRealization.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim RedirectUrl As String = TBLincMEISRealization.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVincMEISRealization.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.INC.incMEISRealization.DeleteWF(SerialNo)
        GVincMEISRealization.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVincMEISRealization.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.INC.incMEISRealization.InitiateWF(SerialNo)
        GVincMEISRealization.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVincMEISRealization_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVincMEISRealization.Init
    DataClassName = "GincMEISRealization"
    SetGridView = GVincMEISRealization
  End Sub
  Protected Sub TBLincMEISRealization_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincMEISRealization.Init
    SetToolBar = TBLincMEISRealization
  End Sub
  Protected Sub F_BatchNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BatchNo.TextChanged
    Session("F_BatchNo") = F_BatchNo.Text
    InitGridPage()
  End Sub
  Protected Sub F_CustomInvoiceNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CustomInvoiceNo.TextChanged
    Session("F_CustomInvoiceNo") = F_CustomInvoiceNo.Text
    InitGridPage()
  End Sub
  Protected Sub F_BankID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BankID.SelectedIndexChanged
    Session("F_BankID") = F_BankID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_StatusID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_StatusID.TextChanged
    Session("F_StatusID") = F_StatusID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_BankID.SelectedValue = String.Empty
    If Not Session("F_BankID") Is Nothing Then
      If Session("F_BankID") <> String.Empty Then
        F_BankID.SelectedValue = Session("F_BankID")
      End If
    End If
  End Sub

  Private Sub GF_incMEISRealization_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    cmdDownload.OnClientClick = DownloadFree
  End Sub
  Private Sub cmdUpload_Click(sender As Object, e As EventArgs) Handles cmdUpload.Click
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim Msg As String = ""
    Try
      If F_Upload.HasFile Then
        Dim tmpPath As String = Server.MapPath("~/../App_Temp")
        Dim tmpName As String = IO.Path.GetRandomFileName()
        Dim tmpFile As String = tmpPath & "\\" & tmpName
        F_Upload.SaveAs(tmpFile)
        Dim fi As FileInfo = New FileInfo(tmpFile)
        Using xlP As ExcelPackage = New ExcelPackage(fi)
          Dim wsD As ExcelWorksheet = Nothing
          wsD = xlP.Workbook.Worksheets(1)
          If wsD Is Nothing Then
            Msg = "No worksheet found"
            xlP.Dispose()
            GoTo Err
          End If
          Try
            If wsD.Name.IndexOf("MEISRealization_") > -1 Then
              Msg = UploadMEISRealization(wsD)
            Else
              UploadBankData(wsD)
            End If
          Catch ex As Exception
            Msg = ex.Message
          End Try
          wsD.Dispose()
          xlP.Dispose()
        End Using
      End If
    Catch ex As Exception
      Msg = ex.Message
    End Try
Err:
    HttpContext.Current.Server.ScriptTimeout = st
    If Msg.Length > 0 Then
      Msg = New JavaScriptSerializer().Serialize(Msg)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", String.Format("alert({0});", Msg), True)
    End If
  End Sub
  Private Sub UploadBankData(wsD As ExcelWorksheet)
    Dim bankFields() As String = {"S.No.", "Custom Invoice no.", "S. bill no.", "Date", "File no.", "Date", "MEIS no.", "Date", "MEIS amount", "GST/TCS/other tax", "sale amount", "realized amount", "Sold to ", "sold on", "Tax Invoice no.", "Tax Invoice date", "RTGS/NEFT No.", "Date"}
    For i = 0 To bankFields.Count - 1
      If wsD.Cells(8, i + 1).Text.ToLower <> bankFields(i).ToLower Then
        Throw New Exception("Fields in EXCEL do not match with Bank Stmt. discussed for Upload here.")
      End If
    Next
    Dim BankID As Integer = 0
    Try
      BankID = wsD.Cells(1, 3).Text
      Dim tmp As SIS.INC.incBanks = SIS.INC.incBanks.incBanksGetByID(BankID)
      If tmp Is Nothing Then
        Throw New Exception("BANK ID NOT Found.")
      End If
    Catch ex As Exception
      Throw New Exception("Invalid BANK ID.")
    End Try
    Dim nBatch As Integer = SIS.INC.incMEISRealization.GetNextBatchNo
    Dim cDt As DateTime = Now
    For I As Integer = 9 To 99000
      Dim CInvNo As String = wsD.Cells(I, 2).Text
      If CInvNo = String.Empty Then Exit For
      Dim xPro As SIS.INC.incMEISRealization = SIS.INC.incMEISRealization.GetByCommercialInvoiceNo(CInvNo)
      Dim Found As Boolean = False
      If xPro IsNot Nothing Then
        Select Case xPro.StatusID
          Case enumInvStates.Free, enumInvStates.Returned
          Case Else
            Continue For
        End Select
        Found = True
      End If
      If Not Found Then
        xPro = New SIS.INC.incMEISRealization
      End If
      With xPro
        .BatchNo = nBatch
        .StatusID = enumInvStates.Free
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = cDt
        .BankID = BankID

        .CustomInvoiceNo = wsD.Cells(I, 2).Text
        .SBillNo = wsD.Cells(I, 3).Text
        .SBillDate = wsD.Cells(I, 4).Text
        .FileNo = wsD.Cells(I, 5).Text
        .FileDate = wsD.Cells(I, 6).Text
        .MEISNo = wsD.Cells(I, 7).Text
        .MEISDate = wsD.Cells(I, 8).Text
        .MEISAmount = wsD.Cells(I, 9).Text
        .OtherTax = wsD.Cells(I, 10).Text
        .SaleAmount = wsD.Cells(I, 11).Text
        .RealisedAmount = wsD.Cells(I, 12).Text
        .SoldTo = wsD.Cells(I, 13).Text
        .SoldOn = wsD.Cells(I, 14).Text
        .TaxInvoiceNo = wsD.Cells(I, 15).Text
        .TaxInvoiceDate = wsD.Cells(I, 16).Text
        .RtgsNeftNo = wsD.Cells(I, 17).Text
        .RtgsNeftDate = wsD.Cells(I, 18).Text
      End With
      If Not Found Then
        xPro = SIS.INC.incMEISRealization.InsertData(xPro)
      Else
        xPro = SIS.INC.incMEISRealization.UpdateData(xPro)
      End If
    Next
  End Sub
  Private Function UploadMEISRealization(wsD As ExcelWorksheet) As String
    Dim RetStr As String = ""
    Dim xlFields() As String = {"SerialNo", "CustomInvoiceNo", "SBillNo", "SBillDate", "FileNo", "FileDate", "MEISNo", "MEISDate", "MEISAmount", "OtherTax", "SaleAmount", "RealisedAmount", "SoldTo", "SoldOn", "TaxInvoiceNo", "TaxInvoiceDate", "RtgsNeftNo", "RtgsNeftDate", "BankID"}
    Dim nBatch As Integer = SIS.INC.incMEISRealization.GetNextBatchNo
    Dim cDt As DateTime = Now
    For I As Integer = 2 To 99000
      Dim SerialNo As String = wsD.Cells(I, 1).Text
      If SerialNo = String.Empty Then Exit For
      Try
        SerialNo = Convert.ToInt32(SerialNo)
      Catch ex As Exception
        Continue For
      End Try
      Dim xPro As SIS.INC.incMEISRealization = SIS.INC.incMEISRealization.incMEISRealizationGetByID(SerialNo)
      If xPro Is Nothing Then Continue For
      Select Case xPro.StatusID
        Case enumInvStates.Free, enumInvStates.Returned
        Case Else
          Continue For
      End Select
      For J As Integer = 0 To xlFields.Length - 1
        Try
          Dim tmpD As String = wsD.Cells(I, J + 1).Text
          CallByName(xPro, xlFields(J), CallType.Let, wsD.Cells(I, J + 1).Text)
        Catch ex As Exception
        End Try
      Next
      With xPro
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = cDt
      End With
      Try
        xPro = SIS.INC.incMEISRealization.UpdateData(xPro)
      Catch ex As Exception
        RetStr &= "<br/>" & "Line " & I & ": " & ex.Message
      End Try
    Next
    Return RetStr
  End Function
End Class
