Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class GF_incProvision
  Inherits SIS.SYS.GridBase
  Public ReadOnly Property DownloadFree As String
    Get
      Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/INC_Main/App_Downloads/filedownload.aspx?code=free', 'left=20,top=20,width=100,height=100,toolbar=0,resizable=0,scrollbars=0'); return false;"
    End Get
  End Property
  Protected Sub GVincProvision_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVincProvision.RowCommand
    If e.CommandName.ToLower = "ToggleSelect".ToLower Then
      Try
        For Each r As GridViewRow In GVincProvision.Rows
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
          For Each r As GridViewRow In GVincProvision.Rows
            If r.RowType = DataControlRowType.DataRow Then
              Dim tmp As CheckBox = CType(r.FindControl("chkSelect"), CheckBox)
              If Not tmp.Visible Then Continue For
              If tmp.Checked Then
                Try
                  Dim SerialNo As Int32 = GVincProvision.DataKeys(r.RowIndex).Values("SerialNo")
                  SIS.INC.incProvision.DeleteWF(SerialNo)
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
            Dim mRet As Integer = SIS.INC.incProvision.DeleteAllFree(Filter_BatchNo, Filter_FwdBatchNo, Filter_RtnBatchNo)
            If mRet > 0 Then
              ActionTaken = True
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(mRet & " Record(s) Deleted.") & "');", True)
            End If
          Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
          End Try
        End If
        If ActionTaken Then
          GVincProvision.DataBind()
        End If
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "ForwardSelected".ToLower Then
      Try
        Dim ActionTaken As Boolean = False
        If Not chkAllFree.Checked Then
          Dim FwdBatch As Integer = SIS.INC.incProvision.GetNextFwdBatchNo()
          For Each r As GridViewRow In GVincProvision.Rows
            If r.RowType = DataControlRowType.DataRow Then
              Dim tmp As CheckBox = CType(r.FindControl("chkSelect"), CheckBox)
              If Not tmp.Visible Then Continue For
              If tmp.Checked Then
                Try
                  Dim SerialNo As Int32 = GVincProvision.DataKeys(r.RowIndex).Values("SerialNo")
                  SIS.INC.incProvision.InitiateWF(SerialNo, FwdBatch)
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
            Dim mRet As Integer = SIS.INC.incProvision.InitiateAllFree(Filter_BatchNo, Filter_FwdBatchNo, Filter_RtnBatchNo)
            If mRet > 0 Then
              ActionTaken = True
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(mRet & " Record(s) Forwarded.") & "');", True)
            End If
          Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
          End Try
        End If
        If ActionTaken Then
          GVincProvision.DataBind()
        End If
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVincProvision.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim RedirectUrl As String = TBLincProvision.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVincProvision.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.INC.incProvision.DeleteWF(SerialNo)
        GVincProvision.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      'Forward
      Try
        Dim SerialNo As Int32 = GVincProvision.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.INC.incProvision.InitiateWF(SerialNo)
        GVincProvision.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVincProvision_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVincProvision.Init
    DataClassName = "GincProvision"
    SetGridView = GVincProvision
  End Sub
  Protected Sub TBLincProvision_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincProvision.Init
    SetToolBar = TBLincProvision
  End Sub
  Protected Sub F_ProjectCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectCode.TextChanged
    Session("F_ProjectCode") = F_ProjectCode.Text
    InitGridPage()
  End Sub
  Protected Sub F_DivisionID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_DivisionID.TextChanged
    Session("F_DivisionID") = F_DivisionID.Text
    InitGridPage()
  End Sub
  Protected Sub F_BatchNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BatchNo.TextChanged
    Session("F_BatchNo") = F_BatchNo.Text
    InitGridPage()
  End Sub
  Protected Sub F_CustomInvoiceNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CustomInvoiceNo.TextChanged
    Session("F_CustomInvoiceNo") = F_CustomInvoiceNo.Text
    InitGridPage()
  End Sub
  Protected Sub F_StatusID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_StatusID.TextChanged
    Session("F_StatusID") = F_StatusID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
  Private Sub GF_incProvision_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
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
            If wsD.Name.IndexOf("IncProvision_") > -1 Then
              Msg = UploadIncentive(wsD)
            Else
              UploadERPData(wsD)
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
  Private Sub UploadERPData(wsD As ExcelWorksheet)
    Dim erpFields() As String = {"Project", "Description", "Country", "Billing Advice No.", "Final Invoice", "Final Inv. Date", "Total Billing Value", "Currency", "Bill of Ladding No.", "Date", "Supplier Code", "Name", "Custom Invoice No.", "Custom Inv. Date", "Custom Inv. Amount", "Shipping Bill No.", "Shipping Date", "Port Code", "AD Code"}
    For i = 0 To erpFields.Count - 1
      If wsD.Cells(1, i + 1).Text <> erpFields(i) Then
        Throw New Exception("Fields in EXCEL do not match with ERP-Report created for Upload here.")
      End If
    Next
    Dim nBatch As Integer = SIS.INC.incProvision.GetNextBatchNo
    Dim cDt As DateTime = Now
    For I As Integer = 2 To 99000
      Dim CInvNo As String = wsD.Cells(I, 13).Text
      If CInvNo = String.Empty Then Exit For
      Dim xPro As SIS.INC.incProvision = SIS.INC.incProvision.GetByCommercialInvoiceNo(CInvNo)
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
        xPro = New SIS.INC.incProvision
      End If
      With xPro
        .BatchNo = nBatch
        .StatusID = enumInvStates.Free
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = cDt
        .ProjectCode = wsD.Cells(I, 1).Text
        .DivisionID = SIS.INC.incProvision.GetProjectDivision(.ProjectCode)
        .BuyerName = wsD.Cells(I, 2).Text
        .CustomPLNo = wsD.Cells(I, 4).Text
        .FinalInvoiceNo = wsD.Cells(I, 5).Text
        .FinalInvoiceDate = wsD.Cells(I, 6).Text
        .CustomInvoiceCurrency = wsD.Cells(I, 8).Text
        .BillOfLadingNo = wsD.Cells(I, 9).Text
        .BillOfLadingDate = wsD.Cells(I, 10).Text
        .CustomInvoiceNo = wsD.Cells(I, 13).Text
        .CustomInvoiceDate = wsD.Cells(I, 14).Text
        .CustomInvoiceAmount = wsD.Cells(I, 15).Text
        .ShippingBillNo = wsD.Cells(I, 16).Text
        .ShippingBillDate = wsD.Cells(I, 17).Text
      End With
      If Not Found Then
        xPro = SIS.INC.incProvision.InsertData(xPro)
      Else
        xPro = SIS.INC.incProvision.UpdateData(xPro)
      End If
    Next
  End Sub
  Private Function UploadIncentive(wsD As ExcelWorksheet) As String
    Dim RetStr As String = ""
    Dim xlFields() As String = {"SerialNo", "DivisionID", "CustomInvoiceNo", "CustomInvoiceDate", "ShippingBillNo", "ShippingBillDate", "ShippingBillCHA", "LEODate", "CustomInvoiceAmount", "CustomInvoiceCurrency", "CustomPLNo", "FinalInvoiceNo", "FinalInvoiceDate", "InvoiceType", "DBKAmountProvisional", "FOBAmount", "ExchangeRateCustom", "BillOfLadingNo", "BillOfLadingDate", "BuyerName", "ProjectCode", "ITSHSCode", "ItemDescription", "MEISAmount", "LoadingPort"}
    Dim nBatch As Integer = SIS.INC.incProvision.GetNextBatchNo
    Dim cDt As DateTime = Now
    For I As Integer = 2 To 99000
      Dim SerialNo As String = wsD.Cells(I, 1).Text
      If SerialNo = String.Empty Then Exit For
      Try
        SerialNo = Convert.ToInt32(SerialNo)
      Catch ex As Exception
        Continue For
      End Try
      Dim xPro As SIS.INC.incProvision = SIS.INC.incProvision.incProvisionGetByID(SerialNo)
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
        xPro = SIS.INC.incProvision.UpdateData(xPro)
      Catch ex As Exception
        RetStr &= "<br/>" & "Line " & I & ": " & ex.Message
      End Try
    Next
    Return RetStr
  End Function

End Class
