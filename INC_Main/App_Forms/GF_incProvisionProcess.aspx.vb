Imports System.Web.Script.Serialization
Partial Class GF_incProvisionProcess
  Inherits SIS.SYS.GridBase
  Protected Sub GVincProvisionProcess_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVincProvisionProcess.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVincProvisionProcess.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim RedirectUrl As String = TBLincProvisionProcess.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "ToggleSelect".ToLower Then
      Try
        For Each r As GridViewRow In GVincProvisionProcess.Rows
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
        Dim SerialNo As Int32 = GVincProvisionProcess.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.INC.incProvisionProcess.ReturnWF(SerialNo)
        GVincProvisionProcess.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "ReturnSelected".ToLower Then
      Try
        Dim ActionTaken As Boolean = False
        If Not chkAllSubmitted.Checked Then
          Dim RtnBatch As Integer = SIS.INC.incProvision.GetNextRtnBatchNo()
          For Each r As GridViewRow In GVincProvisionProcess.Rows
            If r.RowType = DataControlRowType.DataRow Then
              Dim tmp As CheckBox = CType(r.FindControl("chkSelect"), CheckBox)
              If Not tmp.Visible Then Continue For
              If tmp.Checked Then
                Try
                  Dim SerialNo As Int32 = GVincProvisionProcess.DataKeys(r.RowIndex).Values("SerialNo")
                  SIS.INC.incProvisionProcess.ReturnWF(SerialNo, RtnBatch)
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
            Dim mRet As Integer = SIS.INC.incProvisionProcess.ReturnAllSubmitted(Filter_FwdBatchNo, Filter_RtnBatchNo)
            If mRet > 0 Then
              ActionTaken = True
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(mRet & " Record(s) Returned.") & "');", True)
            End If
          Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
          End Try
        End If
        If ActionTaken Then
          GVincProvisionProcess.DataBind()
        End If
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If

    If e.CommandName.ToLower = "ProcessWF".ToLower Then
      Try
        SNos = ""
        Dim SerialNo As Int32 = GVincProvisionProcess.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim x As List(Of SIS.INC.vchData) = SIS.INC.incProvisionProcess.GetVchData(SerialNo, 0, 0)
        If x.Count > 0 Then
          SNos = SerialNo
          Dim sAmt As Decimal = x.Sum(Function(t) t.DAmt)
          Dim str As String = "<h3> DBK Voucher: " & sAmt & "</h3>"
          modalContent.Controls.Add(New LiteralControl(str))
          modalContent.Controls.Add(New LiteralControl(SIS.INC.vchData.GetHTML(x, True)))
          sAmt = x.Sum(Function(t) t.MAmt)
          str = "<h3> MEIS Voucher: " & sAmt & "</h3>"
          modalContent.Controls.Add(New LiteralControl(str))
          modalContent.Controls.Add(New LiteralControl(SIS.INC.vchData.GetHTML(x, False)))
          ShowPopup = True
        Else
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("No record Found / Selected.") & "');", True)
        End If

        'SIS.INC.incProvisionProcess.ProcessWF(SerialNo)
        'GVincProvisionProcess.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "ProcessSelected".ToLower Then
      Dim x As List(Of SIS.INC.vchData) = GetList()
      If x.Count > 0 Then
        Dim sAmt As Decimal = x.Sum(Function(t) t.DAmt)
        Dim str As String = "<h3> DBK Voucher: " & sAmt & "</h3>"
        modalContent.Controls.Add(New LiteralControl(str))
        modalContent.Controls.Add(New LiteralControl(SIS.INC.vchData.GetHTML(x, True)))
        sAmt = x.Sum(Function(t) t.MAmt)
        str = "<h3> MEIS Voucher: " & sAmt & "</h3>"
        modalContent.Controls.Add(New LiteralControl(str))
        modalContent.Controls.Add(New LiteralControl(SIS.INC.vchData.GetHTML(x, False)))
        ShowPopup = True
      Else
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("No record Found / Selected.") & "');", True)
      End If
    End If
  End Sub
  Protected Sub GVincProvisionProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVincProvisionProcess.Init
    DataClassName = "GincProvisionProcess"
    SetGridView = GVincProvisionProcess
  End Sub
  Protected Sub TBLincProvisionProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLincProvisionProcess.Init
    SetToolBar = TBLincProvisionProcess
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
  Protected Sub F_ProjectCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectCode.TextChanged
    Session("F_ProjectCode") = F_ProjectCode.Text
    InitGridPage()
  End Sub
  Protected Sub F_DivisionID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_DivisionID.TextChanged
    Session("F_DivisionID") = F_DivisionID.Text
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
  Dim ShowPopup As Boolean = False
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
  Private Sub GF_incProvisionProcess_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If ShowPopup Then
      HeaderText.Text = "Voucher Details"
      mPopup.Show()
    End If
  End Sub
  Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
    Try
      Dim x As List(Of SIS.INC.vchData) = Nothing
      Dim y As List(Of SIS.TA.taPostVoucherResult) = Nothing
      Dim VchBatch As Integer = 0
      Dim Filter_FwdBatchNo As Integer = 0
      Dim Filter_RtnBatchNo As Integer = 0
      If Not chkAllSubmitted.Checked Then
        If SNos <> "" Then
          x = SIS.INC.incProvisionProcess.GetVchData(SNos, 0, 0)
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
        x = SIS.INC.incProvisionProcess.GetVchData("", Filter_FwdBatchNo, Filter_RtnBatchNo)
      End If
      If x IsNot Nothing Then
        If x.Count > 0 Then
          VchBatch = SIS.INC.incProvision.GetNextVchBatchNo()
          y = SIS.TA.taVoucher.CreatePostVoucherData(x, Now.ToString("dd/MM/yyyy"), VchBatch)
        End If
      End If
      If y IsNot Nothing Then
        If y.Count = 2 Then
          If Not chkAllSubmitted.Checked Then
            Dim z() As String = SNos.Split(",".ToCharArray)
            For Each sn As String In z
              SIS.INC.incProvisionProcess.ProcessWF(sn, VchBatch, y)
            Next
          Else
            SIS.INC.incProvisionProcess.ProcessAllSubmitted(Filter_FwdBatchNo, Filter_RtnBatchNo, VchBatch, y)
          End If
          GVincProvisionProcess.DataBind()
        Else
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Error in Voucher posting.") & "');", True)
        End If
      End If
    Catch ex As Exception
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
    End Try
  End Sub
  Public Function GetList() As List(Of SIS.INC.vchData)
    Dim mRet As New List(Of SIS.INC.vchData)
    SNos = ""
    If Not chkAllSubmitted.Checked Then
      Dim SNs As String = ""
      For Each r As GridViewRow In GVincProvisionProcess.Rows
        If r.RowType = DataControlRowType.DataRow Then
          Dim tmp As CheckBox = CType(r.FindControl("chkSelect"), CheckBox)
          If Not tmp.Visible Then Continue For
          If tmp.Checked Then
            Dim SerialNo As Int32 = GVincProvisionProcess.DataKeys(r.RowIndex).Values("SerialNo")
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
        mRet = SIS.INC.incProvisionProcess.GetVchData(SNs, 0, 0)
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
      mRet = SIS.INC.incProvisionProcess.GetVchData("", Filter_FwdBatchNo, Filter_RtnBatchNo)
    End If
    Return mRet
  End Function
End Class
