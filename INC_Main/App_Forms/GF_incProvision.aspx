<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_incProvision.aspx.vb" Inherits="GF_incProvision" title="Maintain List: Provision" %>
<asp:Content ID="CPHincProvision" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelincProvision" runat="server" Text="&nbsp;List: Provision"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLincProvision" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLincProvision"
      ToolType = "lgNMGrid"
      EditUrl = "~/INC_Main/App_Edit/EF_incProvision.aspx"
      AddUrl = "~/INC_Main/App_Create/AF_incProvision.aspx"
      ValidationGroup = "incProvision"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSincProvision" runat="server" AssociatedUpdatePanelID="UPNLincProvision" DisplayAfter="100">
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
          <b><asp:Label ID="L_DivisionID" runat="server" Text="DIV :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_DivisionID"
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
          <b><asp:Label ID="L_ProjectCode" runat="server" Text="PRJ :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_ProjectCode"
            Text=""
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="6"
            Width="56px"
            AutoPostBack="true"
            runat="server" />
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
    <asp:GridView ID="GVincProvision" SkinID="gv_silver" runat="server" DataSourceID="ODSincProvision" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SN" SortExpression="[INC_Provision].[SerialNo]">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UB" SortExpression="[INC_Provision].[BatchNo]">
          <ItemTemplate>
            <asp:Label ID="LabelBatchNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# EVal("BatchNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="20px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FB" SortExpression="[INC_Provision].[FwdBatchNo]">
          <ItemTemplate>
            <asp:Label ID="LabelFwdBatchNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# EVal("FwdBatchNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="20px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RB" SortExpression="[INC_Provision].[RtnBatchNo]">
          <ItemTemplate>
            <asp:Label ID="LabelRtnBatchNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# EVal("RtnBatchNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="20px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="[INC_Provision].[ProjectCode]">
          <ItemTemplate>
            <asp:Label ID="LabelProjectCode" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("ProjectCode") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Div." SortExpression="[INC_Provision].[DivisionID]">
          <ItemTemplate>
            <asp:Label ID="LabelDivisionID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("DivisionID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Custom Invoice No" SortExpression="[INC_Provision].[CustomInvoiceNo]">
          <ItemTemplate>
            <asp:Label ID="LabelCustomInvoiceNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("CustomInvoiceNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Custom Invoice Date" SortExpression="[INC_Provision].[CustomInvoiceDate]">
          <ItemTemplate>
            <asp:Label ID="LabelCustomInvoiceDate" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("CustomInvoiceDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Custom Invoice Amount" SortExpression="[INC_Provision].[CustomInvoiceAmount]">
          <ItemTemplate>
            <asp:Label ID="LabelCustomInvoiceAmount" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("CustomInvoiceAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Custom Invoice Currency" SortExpression="[INC_Provision].[CustomInvoiceCurrency]">
          <ItemTemplate>
            <asp:Label ID="LabelCustomInvoiceCurrency" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CustomInvoiceCurrency") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DBK Amount Provisional" SortExpression="[INC_Provision].[DBKAmountProvisional]">
          <ItemTemplate>
            <asp:Label ID="LabelDBKAmountProvisional" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DBKAmountProvisional") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MEIS Amount Provisional" SortExpression="[INC_Provision].[MEISAmount]">
          <ItemTemplate>
            <asp:Label ID="LabelMEISAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MEISAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STATUS" SortExpression="[INC_Provision].[StatusID]">
          <ItemTemplate>
            <asp:Label ID="LabelStatusID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Eval("StatusName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
<%--
          <asp:TemplateField HeaderText="Created On" SortExpression="[INC_Provision].[CreatedOn]">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ITSHS Code" SortExpression="[INC_Provision].[ITSHSCode]">
          <ItemTemplate>
            <asp:Label ID="LabelITSHSCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ITSHSCode") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Of Lading Date" SortExpression="[INC_Provision].[BillOfLadingDate]">
          <ItemTemplate>
            <asp:Label ID="LabelBillOfLadingDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BillOfLadingDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Buyer Name" SortExpression="[INC_Provision].[BuyerName]">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Loading Port" SortExpression="[INC_Provision].[LoadingPort]">
          <ItemTemplate>
            <asp:Label ID="LabelLoadingPort" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LoadingPort") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created By" SortExpression="[INC_Provision].[CreatedBy]">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedBy") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Description" SortExpression="[INC_Provision].[ItemDescription]">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Final Invoice No" SortExpression="[INC_Provision].[FinalInvoiceNo]">
          <ItemTemplate>
            <asp:Label ID="LabelFinalInvoiceNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FinalInvoiceNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Final Invoice Date" SortExpression="[INC_Provision].[FinalInvoiceDate]">
          <ItemTemplate>
            <asp:Label ID="LabelFinalInvoiceDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FinalInvoiceDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Custom PL No" SortExpression="[INC_Provision].[CustomPLNo]">
          <ItemTemplate>
            <asp:Label ID="LabelCustomPLNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CustomPLNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="LEO Date" SortExpression="[INC_Provision].[LEODate]">
          <ItemTemplate>
            <asp:Label ID="LabelLEODate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LEODate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Exchange Rate Custom" SortExpression="[INC_Provision].[ExchangeRateCustom]">
          <ItemTemplate>
            <asp:Label ID="LabelExchangeRateCustom" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ExchangeRateCustom") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Of Lading No" SortExpression="[INC_Provision].[BillOfLadingNo]">
          <ItemTemplate>
            <asp:Label ID="LabelBillOfLadingNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BillOfLadingNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FOB Amount" SortExpression="[INC_Provision].[FOBAmount]">
          <ItemTemplate>
            <asp:Label ID="LabelFOBAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FOBAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Invoice Type" SortExpression="[INC_Provision].[InvoiceType]">
          <ItemTemplate>
            <asp:Label ID="LabelInvoiceType" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("InvoiceType") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Shipping Bill No" SortExpression="[INC_Provision].[ShippingBillNo]">
          <ItemTemplate>
            <asp:Label ID="LabelShippingBillNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("ShippingBillNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Shipping Bill Date" SortExpression="[INC_Provision].[ShippingBillDate]">
          <ItemTemplate>
            <asp:Label ID="LabelShippingBillDate" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("ShippingBillDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Shipping Bill CHA" SortExpression="[INC_Provision].[ShippingBillCHA]">
          <ItemTemplate>
            <asp:Label ID="LabelShippingBillCHA" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("ShippingBillCHA") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
  
  --%>
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
      ID = "ODSincProvision"
      runat = "server"
      DataObjectTypeName = "SIS.INC.incProvision"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_incProvisionSelectList"
      TypeName = "SIS.INC.incProvision"
      SelectCountMethod = "incProvisionSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectCode" PropertyName="Text" Name="ProjectCode" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_DivisionID" PropertyName="Text" Name="DivisionID" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_BatchNo" PropertyName="Text" Name="BatchNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_FwdBatchNo" PropertyName="Text" Name="FwdBatchNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_RtnBatchNo" PropertyName="Text" Name="RtnBatchNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CustomInvoiceNo" PropertyName="Text" Name="CustomInvoiceNo" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_StatusID" PropertyName="SelectedValue" Name="StatusID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVincProvision" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectCode" />
    <asp:AsyncPostBackTrigger ControlID="F_DivisionID" />
    <asp:AsyncPostBackTrigger ControlID="F_BatchNo" />
    <asp:AsyncPostBackTrigger ControlID="F_FwdBatchNo" />
    <asp:AsyncPostBackTrigger ControlID="F_RtnBatchNo" />
    <asp:AsyncPostBackTrigger ControlID="F_CustomInvoiceNo" />
    <asp:AsyncPostBackTrigger ControlID="F_StatusID" />
    <asp:PostBackTrigger ControlID="cmdUpload" />
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
