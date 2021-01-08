<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_incBanks.aspx.vb" Inherits="AF_incBanks" title="Add: Banks" %>
<asp:Content ID="CPHincBanks" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelincBanks" runat="server" Text="&nbsp;Add: Banks"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLincBanks" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLincBanks"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "incBanks"
    runat = "server" />
<asp:FormView ID="FVincBanks"
  runat = "server"
  DataKeyNames = "BankID"
  DataSourceID = "ODSincBanks"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgincBanks" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BankID" ForeColor="#CC6633" runat="server" Text="Bank ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BankID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BankName" runat="server" Text="Bank Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BankName"
            Text='<%# Bind("BankName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="incBanks"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Bank Name."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBankName"
            runat = "server"
            ControlToValidate = "F_BankName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "incBanks"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OrganizationUnit" runat="server" Text="ISGEC Organization Unit :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_OrganizationUnit"
            Text='<%# Bind("OrganizationUnit") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Organization Unit."
            MaxLength="10"
            Width="88px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Branch" runat="server" Text="Branch :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Branch"
            Text='<%# Bind("Branch") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Branch."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AccountNo" runat="server" Text="Account No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AccountNo"
            Text='<%# Bind("AccountNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Account No."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ADCode" runat="server" Text="AD Code :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ADCode"
            Text='<%# Bind("ADCode") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for AD Code."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IFCSCode" runat="server" Text="IFCS Code :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IFCSCode"
            Text='<%# Bind("IFCSCode") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IFCS Code."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GLCode" runat="server" Text="GL Code :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLCode"
            Text='<%# Bind("GLCode") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GL Code."
            MaxLength="10"
            Width="88px"
            runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSincBanks"
  DataObjectTypeName = "SIS.INC.incBanks"
  InsertMethod="incBanksInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.INC.incBanks"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
