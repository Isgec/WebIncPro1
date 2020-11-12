<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_incBanks.aspx.vb" Inherits="GF_incBanks" title="Maintain List: Banks" %>
<asp:Content ID="CPHincBanks" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelincBanks" runat="server" Text="&nbsp;List: Banks"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLincBanks" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLincBanks"
      ToolType = "lgNMGrid"
      EditUrl = "~/INC_Main/App_Edit/EF_incBanks.aspx"
      AddUrl = "~/INC_Main/App_Create/AF_incBanks.aspx"
      ValidationGroup = "incBanks"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSincBanks" runat="server" AssociatedUpdatePanelID="UPNLincBanks" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVincBanks" SkinID="gv_silver" runat="server" DataSourceID="ODSincBanks" DataKeyNames="BankID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bank ID" SortExpression="[INC_Banks].[BankID]">
          <ItemTemplate>
            <asp:Label ID="LabelBankID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BankID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bank Name" SortExpression="[INC_Banks].[BankName]">
          <ItemTemplate>
            <asp:Label ID="LabelBankName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BankName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Organization Unit" SortExpression="[INC_Banks].[OrganizationUnit]">
          <ItemTemplate>
            <asp:Label ID="LabelOrganizationUnit" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrganizationUnit") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Branch" SortExpression="[INC_Banks].[Branch]">
          <ItemTemplate>
            <asp:Label ID="LabelBranch" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Branch") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Account No" SortExpression="[INC_Banks].[AccountNo]">
          <ItemTemplate>
            <asp:Label ID="LabelAccountNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AccountNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="AD Code" SortExpression="[INC_Banks].[ADCode]">
          <ItemTemplate>
            <asp:Label ID="LabelADCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ADCode") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IFCS Code" SortExpression="[INC_Banks].[IFCSCode]">
          <ItemTemplate>
            <asp:Label ID="LabelIFCSCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IFCSCode") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Code" SortExpression="[INC_Banks].[GLCode]">
          <ItemTemplate>
            <asp:Label ID="LabelGLCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GLCode") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSincBanks"
      runat = "server"
      DataObjectTypeName = "SIS.INC.incBanks"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "incBanksSelectList"
      TypeName = "SIS.INC.incBanks"
      SelectCountMethod = "incBanksSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVincBanks" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
