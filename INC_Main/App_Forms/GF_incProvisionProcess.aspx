<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_incProvisionProcess.aspx.vb" Inherits="GF_incProvisionProcess" title="Maintain List: Process Provision" %>
<asp:Content ID="CPHincProvisionProcess" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelincProvisionProcess" runat="server" Text="&nbsp;List: Process Provision"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLincProvisionProcess" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLincProvisionProcess"
      ToolType = "lgNMGrid"
      EditUrl = "~/INC_Main/App_Edit/EF_incProvisionProcess.aspx"
      EnableAdd = "False"
      ValidationGroup = "incProvisionProcess"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSincProvisionProcess" runat="server" AssociatedUpdatePanelID="UPNLincProvisionProcess" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
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
          <b><asp:Label ID="L_ProjectCode" runat="server" Text="Project :" /></b>
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
          <b><asp:Label ID="L_DivisionID" runat="server" Text="Division :" /></b>
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
          <b><asp:Label ID="L_VchBatchNo" runat="server" Text="PB :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_VchBatchNo"
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
            Runat="Server" >
            <asp:ListItem Selected="True" Value="0">---ALL---</asp:ListItem>
            <asp:ListItem Value="2">Submitted</asp:ListItem>
            <asp:ListItem Value="3">Processed</asp:ListItem>
            <asp:ListItem Value="4">DBKRealized</asp:ListItem>
            <asp:ListItem Value="5">MEISRealized</asp:ListItem>
            <asp:ListItem Value="6">Completed</asp:ListItem>
            <asp:ListItem Value="7">Returned</asp:ListItem>
            <asp:ListItem Value="8">NOT REALIZED</asp:ListItem>
          </asp:DropDownList>
          </div>
        </div>
      </div>
      <div>
        <div style="display:flex; flex-direction:row;justify-content:flex-end;">
          <div>
            <asp:CheckBox ID="chkAllSubmitted" CssClass="mychk" runat="server" Text="Refer ALL [SUBMITTED status]" ToolTip="Select all records [includes un-displayed] of SUBMITTED status to RETURN / PROCESS / PREVIEW"></asp:CheckBox>
          </div>
          <div style="border: 0.2pt solid grey; background-color: grey;"></div>
        </div>
      </div>
    </div>
    <asp:GridView ID="GVincProvisionProcess" SkinID="gv_silver" runat="server" DataSourceID="ODSincProvisionProcess" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SN" SortExpression="[INC_Provision].[SerialNo]">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="4px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SB" SortExpression="[INC_Provision].[FwdBatchNo]">
          <ItemTemplate>
            <asp:Label ID="LabelFwdBatchNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FwdBatchNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="20px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RB" SortExpression="[INC_Provision].[RtnBatchNo]">
          <ItemTemplate>
            <asp:Label ID="LabelRtnBatchNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RtnBatchNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="20px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PB" SortExpression="[INC_Provision].[VchBatchNo]">
          <ItemTemplate>
            <asp:Label ID="LabelVchBatchNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VchBatchNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="20px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="[INC_Provision].[ProjectCode]">
          <ItemTemplate>
            <asp:Label ID="LabelProjectCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectCode") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Division" SortExpression="[INC_Provision].[DivisionID]">
          <ItemTemplate>
            <asp:Label ID="LabelDivisionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DivisionID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="C-Inv. No" SortExpression="[INC_Provision].[CustomInvoiceNo]">
          <ItemTemplate>
            <asp:Label ID="LabelCustomInvoiceNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CustomInvoiceNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="C-Inv. Date" SortExpression="[INC_Provision].[CustomInvoiceDate]">
          <ItemTemplate>
            <asp:Label ID="LabelCustomInvoiceDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CustomInvoiceDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="C-Inv.Amt" SortExpression="[INC_Provision].[CustomInvoiceAmount]">
          <ItemTemplate>
            <asp:Label ID="LabelCustomInvoiceAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CustomInvoiceAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="C-Inv. Currency" SortExpression="[INC_Provision].[CustomInvoiceCurrency]">
          <ItemTemplate>
            <asp:Label ID="LabelCustomInvoiceCurrency" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CustomInvoiceCurrency") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DBK Pro.-Amt." SortExpression="[INC_Provision].[DBKAmountProvisional]">
          <ItemTemplate>
            <asp:Label ID="LabelDBKAmountProvisional" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DBKAmountProvisional") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MEIS Pro.-Amt." SortExpression="[INC_Provision].[MEISAmount]">
          <ItemTemplate>
            <asp:Label ID="LabelMEISAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MEISAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DBK Vch" SortExpression="[INC_Provision].[DBK_BatchNo]">
          <ItemTemplate>
            <asp:Label ID="LabelDBK_BatchNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DBK_BatchNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MEIS Vch" SortExpression="[INC_Provision].[MEIS_BatchNo]">
          <ItemTemplate>
            <asp:Label ID="LabelMEIS_BatchNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MEIS_BatchNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STATUS" SortExpression="[INC_Provision].[StatusID]">
          <ItemTemplate>
            <asp:Label ID="LabelStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("StatusName") %>'></asp:Label>
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
            <asp:Button ID="ReturnSelected" CommandName="ReturnSelected" runat="server" CssClass="nt-but-danger" Text="Return" ToolTip="Return Selected" OnClientClick="return confirm('Selected Records will be returned, Do you want to continue ?');" />
          </HeaderTemplate>
          <ItemTemplate>
            <asp:ImageButton ID="cmdReturn" runat="server" Visible='<%# Eval("ReturnWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Return" SkinID="return" OnClientClick="return confirm('Return record ?');" CommandName="ReturnWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField>
          <HeaderTemplate>
            <asp:Button ID="ProcessSelected" CommandName="ProcessSelected" runat="server" CssClass="nt-but-success" Text="Process" ToolTip="Process Selected"  />
          </HeaderTemplate>
          <ItemTemplate>
            <asp:ImageButton ID="cmdProcessWF" runat="server" Visible='<%# Eval("ProcessWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Process" SkinID="forward" CommandName="ProcessWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSincProvisionProcess"
      runat = "server"
      DataObjectTypeName = "SIS.INC.incProvisionProcess"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_incProvisionProcessSelectList"
      TypeName = "SIS.INC.incProvisionProcess"
      SelectCountMethod = "incProvisionProcessSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_FwdBatchNo" PropertyName="Text" Name="FwdBatchNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_RtnBatchNo" PropertyName="Text" Name="RtnBatchNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_VchBatchNo" PropertyName="Text" Name="VchBatchNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ProjectCode" PropertyName="Text" Name="ProjectCode" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_DivisionID" PropertyName="Text" Name="DivisionID" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_CustomInvoiceNo" PropertyName="Text" Name="CustomInvoiceNo" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_StatusID" PropertyName="Text" Name="StatusID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVincProvisionProcess" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_FwdBatchNo" />
    <asp:AsyncPostBackTrigger ControlID="F_RtnBatchNo" />
    <asp:AsyncPostBackTrigger ControlID="F_VchBatchNo" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectCode" />
    <asp:AsyncPostBackTrigger ControlID="F_DivisionID" />
    <asp:AsyncPostBackTrigger ControlID="F_CustomInvoiceNo" />
    <asp:AsyncPostBackTrigger ControlID="F_StatusID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
  <style>
    .x-div{
      font-family:Tahoma;
      font-size:12px;
    }
    .x-tbl{
      width:100%;
    }
    .x-h-tbl{
       font-weight:bold;
       color:white;
       background-color:#2f77f7;
    }
    .x-d1-tbl{
       color:black;
       background-color:white;
    }
    .x-d2-tbl{
       color:black;
       background-color:#cccaca;
    }
  </style>
  <asp:UpdatePanel runat="server">
    <ContentTemplate>
      <asp:Panel ID="pnl1" runat="server" Style="background-color: white; display: none; height:350px;border-radius:6px;" Width='800px'>
        <asp:Panel ID="pnlHeader" runat="server" Style="width: 100%; height: 33px; padding-top: 8px; text-align: center; border-bottom: 1pt solid lightgray;">
          <asp:Label ID="HeaderText" runat="server" Font-Size="16px" Font-Bold="true" Text='My Modal Text'></asp:Label>
        </asp:Panel>
        <asp:Panel ID="modalContent" runat="server" Style="width:98%; height: 250px; padding:4px;overflow-y:scroll;">
          
        </asp:Panel>
        <asp:Panel ID="pnlFooter" runat="server" Style="width: 100%; height: 33px; padding-top: 8px; text-align: right; border-top: 1pt solid lightgray;">
          <asp:Label ID="L_PrimaryKey" runat="server" Style="display: none;"></asp:Label>
          <asp:Button ID="cmdOK" runat="server" CssClass="nt-but-success" Width="70px" Text="OK" Style="text-align: center; margin-right: 30px;" />
          <asp:Button ID="cmdCancel" runat="server" CssClass="nt-but-danger" Width="70px" Text="Cancle" Style="text-align: center; margin-right: 30px;" />
        </asp:Panel>
      </asp:Panel>
      <asp:Button ID="dummy" runat="server" Style="display: none;" Text="show"></asp:Button>
      <AJX:ModalPopupExtender
        ID="mPopup"
        BehaviorID="myMPE1"
        TargetControlID="dummy"
        BackgroundCssClass="modalBackground"
        CancelControlID="cmdCancel"
        OkControlID="cmdCancel"
        PopupControlID="pnl1"
        PopupDragHandleControlID="pnlHeader"
        DropShadow="true"
        runat="server">
      </AJX:ModalPopupExtender>
    </ContentTemplate>
    <Triggers>
      <asp:AsyncPostBackTrigger ControlID="cmdOK" EventName="Click" />
    </Triggers>
  </asp:UpdatePanel>

  <script>
    try {hideProcessingMPV();}catch (e){}
  </script>
</asp:Content>
