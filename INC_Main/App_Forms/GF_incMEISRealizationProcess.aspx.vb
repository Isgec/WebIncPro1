Imports System.Web.Script.Serialization
Partial Class GF_incMEISRealizationProcess
  Inherits SIS.SYS.GridBase
  Dim ShowPopup As enumVoucherData = enumVoucherData.None
  Public Property SNos As String
    Get
      If ViewState("SNos") IsNot Nothing Then
        Return CType(ViewState("SNos"), String)
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("SNos", value)
    End Set
  End Property

  Protected Sub GVincMEISRealizationProcess_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVincMEISRealizationProcess.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVincMEISRealizationProcess.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim RedirectUrl As String = TBLincMEISRealizationProcess.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "ToggleSelect".ToLower Then
      Try
        For Each r As GridViewRow In GVincMEISRealizationProcess.Rows
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
    If e.CommandName.ToLower = "Returnwf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVincMEISRealizationProcess.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.INC.incMEISRealizationProcess.ReturnWF(SerialNo)
        GVincMEISRealizationProcess.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "ReturnSelected".ToLower Then
      Try
        Dim ActionTaken As Boolean = False
        If Not chkAllSubmitted.Checked Then
          Dim RtnBatch As Integer = SIS.INC.incMEISRealization.GetNextRtnBatchNo()
          For Each r As GridViewRow In GVincMEISRealizationProcess.Rows
            If r.RowType = DataControlRowType.DataRow Then
              Dim tmp As CheckBox = CType(r.FindControl("chkSelect"), CheckBox)
              If Not tmp.Visible Then Continue For
              If tmp.Checked Then
                Try
                  Dim SerialNo As Int32 = GVincMEISRealizationProcess.DataKeys(r.RowIndex).Values("SerialNo")
                  SIS.INC.incMEISRealizationProcess.ReturnWF(SerialNo, RtnBatch)
                  ActionTaken = True
                Catch ex As Exception
                  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
                End Try
              End If
            End If
          Next
        Else
          Try
            Dim Filter_FwdBatchNo As Integer = 0
            Dim Filter_RtnBatchNo As Integer = 0
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
            Dim mRet As Integer = SIS.INC.incMEISRealizationProcess.ReturnAllSubmitted(Filter_FwdBatchNo, Filter_RtnBatchNo)
            If mRet > 0 Then
              ActionTaken = True
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(mRet & " Record(s) Returned.") & "');", True)
            End If
          Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
          End Try
        End If
        If ActionTaken Then
          GVincMEISRealizationProcess.DataBind()
        End If
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "DisplayWF".ToLower Then
      Try
        SNos = ""
        Dim SerialNo As Int32 = GVincMEISRealizationProcess.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim x As List(Of SIS.TA.vchData) = SIS.INC.incMEISRealizationProcess.GetVchData(SerialNo, 0, 0, True)
        If x.Count > 0 Then
          SNos = SerialNo
          Dim sAmt As Decimal = x.Sum(Function(t) t.DAmt)
          Dim str As String = "<h3> MEIS Realization: " & sAmt & "</h3>"
          PostVoucher.DisplayContent.Controls.Add(New LiteralControl(str))
          sAmt = x.Sum(Function(t) t.MAmt)
          str = "<h3> MEIS Provision Reversal: " & sAmt & "</h3>"
          PostVoucher.DisplayContent.Controls.Add(New LiteralControl(str))
          PostVoucher.DisplayContent.Controls.Add(New LiteralControl(SIS.TA.vchData.GetHTMLMEIS(x)))
          ShowPopup = enumVoucherData.DisplayMode
        Else
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("No record Found / Selected.") & "');", True)
        End If
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "ProcessWF".ToLower Then
      Try
        SNos = ""
        Dim SerialNo As Int32 = GVincMEISRealizationProcess.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim x As List(Of SIS.TA.vchData) = SIS.INC.incMEISRealizationProcess.GetVchData(SerialNo, 0, 0)
        If x.Count > 0 Then
          SNos = SerialNo
          Dim sAmt As Decimal = x.Sum(Function(t) t.DAmt)
          Dim str As String = "<h3> MEIS Realization: " & sAmt & "</h3>"
          PostVoucher.DisplayContent.Controls.Add(New LiteralControl(str))
          sAmt = x.Sum(Function(t) t.MAmt)
          str = "<h3> MEIS Provision Reversal: " & sAmt & "</h3>"
          PostVoucher.DisplayContent.Controls.Add(New LiteralControl(str))
          PostVoucher.DisplayContent.Controls.Add(New LiteralControl(SIS.TA.vchData.GetHTMLMEIS(x)))
          ShowPopup = enumVoucherData.PostingMode
        Else
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("No record Found / Selected.") & "');", True)
        End If
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "ProcessSelected".ToLower Then
      Dim x As List(Of SIS.TA.vchData) = GetList()
      If x.Count > 0 Then
        Dim sAmt As Decimal = x.Sum(Function(t) t.DAmt)
        Dim str As String = "<h3> MEIS Realization: " & sAmt & "</h3>"
        PostVoucher.DisplayContent.Controls.Add(New LiteralControl(str))
        sAmt = x.Sum(Function(t) t.MAmt)
        str = "<h3> MEIS Provision Reversal: " & sAmt & "</h3>"
        PostVoucher.DisplayContent.Controls.Add(New LiteralControl(str))
        PostVoucher.DisplayContent.Controls.Add(New LiteralControl(SIS.TA.vchData.GetHTMLMEIS(x)))
        ShowPopup = enumVoucherData.PostingMode
      Else
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("No record Found / Selected.") & "');", True)
      End If
    End If
  End Sub
  Private Sub PostVoucher_Execute(vchDt As String) Handles PostVoucher.Execute
    Try
      Dim x As List(Of SIS.TA.vchData) = Nothing
      Dim y As SIS.TA.taPostVoucherResult = Nothing
      Dim VchBatch As Integer = 0
      Dim Filter_FwdBatchNo As Integer = 0
      Dim Filter_RtnBatchNo As Integer = 0
      If Not chkAllSubmitted.Checked Then
        If SNos <> "" Then
          x = SIS.INC.incMEISRealizationProcess.GetVchData(SNos, 0, 0)
        End If
      Else
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
        x = SIS.INC.incMEISRealizationProcess.GetVchData("", Filter_FwdBatchNo, Filter_RtnBatchNo)
      End If
      If x IsNot Nothing Then
        If x.Count > 0 Then
          VchBatch = SIS.INC.incMEISRealizationProcess.GetNextVchBatchNo()
          y = SIS.TA.taVoucher.CreateAndPostMEISRealization(x, vchDt, VchBatch)
        End If
      End If
      If y IsNot Nothing Then
        If Not chkAllSubmitted.Checked Then
          Dim z() As String = SNos.Split(",".ToCharArray)
          For Each sn As String In z
            SIS.INC.incMEISRealizationProcess.ProcessWF(sn, VchBatch, y)
          Next
        Else
          SIS.INC.incMEISRealizationProcess.ProcessAllSubmitted(Filter_FwdBatchNo, Filter_RtnBatchNo, VchBatch, y)
        End If
        GVincMEISRealizationProcess.DataBind()
      Else
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Error in Voucher posting.") & "');", True)
      End If
    Catch ex As Exception
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
    End Try
  End Sub
  Public Function GetList() As List(Of SIS.TA.vchData)
    Dim mRet As New List(Of SIS.TA.vchData)
    SNos = ""
    If Not chkAllSubmitted.Checked Then
      Dim SNs As String = ""
      For Each r As GridViewRow In GVincMEISRealizationProcess.Rows
        If r.RowType = DataControlRowType.DataRow Then
          Dim tmp As CheckBox = CType(r.FindControl("chkSelect"), CheckBox)
          If Not tmp.Visible Then Continue For
          If tmp.Checked Then
            Dim SerialNo As Int32 = GVincMEISRealizationProcess.DataKeys(r.RowIndex).Values("SerialNo")
            If SNs = "" Then
              SNs = SerialNo
            Else
              SNs &= "," & SerialNo
            End If
          End If
        End If
      Next
      If SNs <> "" Then
        SNos = SNs
        mRet = SIS.INC.incMEISRealizationProcess.GetVchData(SNs, 0, 0)
      End If
    Else
      Dim Filter_FwdBatchNo As Integer = 0
      Dim Filter_RtnBatchNo As Integer = 0
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
      mRet = SIS.INC.incMEISRealizationProcess.GetVchData("", Filter_FwdBatchNo, Filter_RtnBatchNo)
    End If
    Return mRet
  End Function
  Protected Sub GVincMEISRealizationProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVincMEISRealizationProcess.Init
    DataClassName = "GincMEISRealizationProcess"
    SetGridView = GVincMEISRealizationProcess
  End Sub
  Protected Sub TBLincMEISRealizationProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincMEISRealizationProcess.Init
    SetToolBar = TBLincMEISRealizationProcess
  End Sub
  Protected Sub F_FwdBatchNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_FwdBatchNo.TextChanged
    Session("F_FwdBatchNo") = F_FwdBatchNo.Text
    InitGridPage()
  End Sub
  Protected Sub F_RtnBatchNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RtnBatchNo.TextChanged
    Session("F_RtnBatchNo") = F_RtnBatchNo.Text
    InitGridPage()
  End Sub
  Protected Sub F_VchBatchNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_VchBatchNo.TextChanged
    Session("F_VchBatchNo") = F_VchBatchNo.Text
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

  Private Sub GF_incMEISRealizationProcess_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If ShowPopup <> enumVoucherData.None Then
      PostVoucher.Show(ShowPopup)
    End If
  End Sub
End Class
