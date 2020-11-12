<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_incMEISRealization.aspx.vb" Inherits="GF_incMEISRealization" title="Maintain List: MEIS Realization" %>
<asp:Content ID="CPHincMEISRealization" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelincMEISRealization" runat="server" Text="&nbsp;List: MEIS Realization"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLincMEISRealization" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLincMEISRealization"
      ToolType = "lgNMGrid"
      EditUrl = "~/INC_Main/App_Edit/EF_incMEISRealization.aspx"
      AddUrl = "~/INC_Main/App_Create/AF_incMEISRealization.aspx"
      ValidationGroup = "incMEISRealization"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSincMEISRealization" runat="server" AssociatedUpdatePanelID="UPNLincMEISRealization" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script>
      function xl_validate() {
        var fs = $get('F_Upload');
        if (fs.files.length == 0) {
          return false;
        }
        if (!confirm('Upload Data ?'))
          return false;
        showProcessingMPV();
        return true;
      }
    </script>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CustomInvoiceNo" runat="server" Text="Custom Invoice No :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_CustomInvoiceNo"
            Text=""
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="9"
            Width="80px"
            AutoPostBack="true"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BankID" runat="server" Text="Bank ID :" /></b>
        </td>
        <td>
          <LGM:LC_incBanks
            ID="F_BankID"
            OrderBy="BankName"
            DataTextField="BankName"
            DataValueField="BankID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BatchNo" runat="server" Text="Upload Batch [UB] :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_BatchNo"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            onblur ="return dc(this,0);"
            AutoPostBack="true"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FwdBatchNo" runat="server" Text="SB :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_FwdBatchNo"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            onblur="return dc(this,0);"
            AutoPostBack="true"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RtnBatchNo" runat="server" Text="RB :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_RtnBatchNo"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            onblur="return dc(this,0);"
            AutoPostBack="true"
            runat="server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <style>
      .nt-tools{
        width: 99.8%;
        height: 30px;
        border: solid 1pt #6495ED;
      }

      .nt-tools>div>div>div{
        vertical-align:middle;
        margin:5px;
      }
    </style>
    <div style="display:flex; flex-direction:row; justify-content: space-between; flex-wrap:nowrap;" class="nt-tools">
      <div>
        <div style="display:flex; flex-direction:row;justify-content:flex-start;">
          <div>
            <asp:Label runat="server" Text="Show Records:" Font-Bold="true"></asp:Label>
          </div>
          <div>
          <asp:DropDownList
            ID="F_StatusID"
            Width="200px"
            AutoPostBack="true"
            CssClass="myddl"
            Font-Names="Tahoma"
            Runat="Server" >
              <asp:ListItem Selected="True" Value="0">---ALL---</asp:ListItem>
              <asp:ListItem Value="1">Free</asp:ListItem>
              <asp:ListItem Value="2">Submitted</asp:ListItem>
              <asp:ListItem Value="3">Processed</asp:ListItem>
              <asp:ListItem Value="7">Returned</asp:ListItem>
          </asp:DropDownList>
          </div>
        </div>
      </div>
      <div>
        <div style="display:flex; flex-direction:row;justify-content:flex-end;">
          <div>
            <asp:FileUpload ID="F_Upload" runat="server" ClientIDMode="Static" ViewStateMode="Disabled" Font-Names="Tahoma" Width="200px" />
          </div>
          <div>
            <asp:Button ID="cmdUpload" CssClass="nt-but-primary" runat="server" Text="Upload" OnClientClick="return xl_validate();"></asp:Button>
          </div>
          <div style="border: 0.2pt solid grey; background-color: grey;"></div>
          <div>
            <asp:CheckBox ID="chkAllFree" CssClass="mychk" runat="server" Text="Refer ALL [FREE status]" ToolTip="Select all records [includes un-displayed] of FREE status to DELETE / FORWARD / DOWNLOAD"></asp:CheckBox>
          </div>
          <div style="border: 0.2pt solid grey; background-color: grey;"></div>
          <div>
            <asp:Button ID="cmdDownload" CssClass="nt-but-warning" runat="server" Text="Download" ></asp:Button>
          </div>
        </div>
      </div>
    </div>
    <asp:GridView ID="GVincMEISRealization" SkinID="gv_silver" runat="server" DataSourceID="ODSincMEISRealization" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SN" SortExpression="[INC_MEISRealization].[SerialNo]">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UN" SortExpression="[INC_DBKRealization].[BatchNo]">
          <ItemTemplate>
            <asp:Label ID="LabelBatchNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BatchNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="20px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FB" SortExpression="[INC_DBKRealization].[FwdBatchNo]">
          <ItemTemplate>
            <asp:Label ID="LabelFwdBatchNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# EVal("FwdBatchNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="20px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RB" SortExpression="[INC_DBKRealization].[RtnBatchNo]">
          <ItemTemplate>
            <asp:Label ID="LabelRtnBatchNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# EVal("RtnBatchNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="20px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Custom Invoice No" SortExpression="[INC_MEISRealization].[CustomInvoiceNo]">
          <ItemTemplate>
            <asp:Label ID="LabelCustomInvoiceNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("CustomInvoiceNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="S-Bill No" SortExpression="[INC_MEISRealization].[SBillNo]">
          <ItemTemplate>
            <asp:Label ID="LabelSBillNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SBillNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="S-Bill Date" SortExpression="[INC_MEISRealization].[SBillDate]">
          <ItemTemplate>
            <asp:Label ID="LabelSBillDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SBillDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MEIS No" SortExpression="[INC_MEISRealization].[MEISNo]">
          <ItemTemplate>
            <asp:Label ID="LabelMEISNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MEISNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MEIS Realised Amount" SortExpression="[INC_MEISRealization].[RealisedAmount]">
          <ItemTemplate>
            <asp:Label ID="LabelRealisedAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RealisedAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bank ID" SortExpression="[INC_Banks2].[BankName]">
          <ItemTemplate>
             <asp:Label ID="L_BankID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BankID") %>' Text='<%# Eval("INC_Banks2_BankName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="[INC_MEISRealization].[StatusID]">
          <ItemTemplate>
            <asp:Label ID="LabelStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("StatusName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField>
          <HeaderTemplate>
            <asp:Button ID="ToggalSelection" runat="server" CssClass="nt-but-warning" Text="&nbsp;&nbsp;&nbsp;" ToolTip="Change Selection" CommandName="ToggleSelect" />
          </HeaderTemplate>
          <ItemTemplate>
            <asp:CheckBox ID="chkSelect" runat="server" Visible='<%# Eval("SelectWFVisible") %>' ToolTip="Select" Checked='<%# Bind("Selected") %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField>
          <HeaderTemplate>
            <asp:Button ID="DeleteSelected" CommandName="DeleteSelected" runat="server" CssClass="nt-but-danger" Text="Delete" ToolTip="Delete Selected" OnClientClick="return confirm('Selected Records will be deleted, Do you want to continue ?');" />
          </HeaderTemplate>
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <HeaderTemplate>
            <asp:Button ID="ForwardSelected" CommandName="ForwardSelected" runat="server" CssClass="nt-but-success" Text="Forward" ToolTip="Forward Selected" OnClientClick="return confirm('Selected Records will be Forwarded, Do you want to continue ?');" />
          </HeaderTemplate>
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSincMEISRealization"
      runat = "server"
      DataObjectTypeName = "SIS.INC.incMEISRealization"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_incMEISRealizationSelectList"
      TypeName = "SIS.INC.incMEISRealization"
      SelectCountMethod = "incMEISRealizationSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_BatchNo" PropertyName="Text" Name="BatchNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_FwdBatchNo" PropertyName="Text" Name="FwdBatchNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_RtnBatchNo" PropertyName="Text" Name="RtnBatchNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CustomInvoiceNo" PropertyName="Text" Name="CustomInvoiceNo" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_BankID" PropertyName="SelectedValue" Name="BankID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_StatusID" PropertyName="Text" Name="StatusID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVincMEISRealization" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_BatchNo" />
    <asp:AsyncPostBackTrigger ControlID="F_FwdBatchNo" />
    <asp:AsyncPostBackTrigger ControlID="F_RtnBatchNo" />
    <asp:AsyncPostBackTrigger ControlID="F_CustomInvoiceNo" />
    <asp:AsyncPostBackTrigger ControlID="F_BankID" />
    <asp:AsyncPostBackTrigger ControlID="F_StatusID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
  <script>
    try {hideProcessingMPV();}catch (e){}
    //document Ready
    window.history.replaceState('', '', window.location.href);
  </script>
</asp:Content>
