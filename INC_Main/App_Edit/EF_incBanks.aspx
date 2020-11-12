<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_incBanks.aspx.vb" Inherits="EF_incBanks" title="Edit: Banks" %>
<asp:Content ID="CPHincBanks" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelincBanks" runat="server" Text="&nbsp;Edit: Banks"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLincBanks" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLincBanks"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "incBanks"
    runat = "server" />
<asp:FormView ID="FVincBanks"
  runat = "server"
  DataKeyNames = "BankID"
  DataSourceID = "ODSincBanks"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BankID" runat="server" ForeColor="#CC6633" Text="Bank ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BankID"
            Text='<%# Bind("BankID") %>'
            ToolTip="Value of Bank ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BankName" runat="server" Text="Bank Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BankName"
            Text='<%# Bind("BankName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="incBanks"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Bank Name."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OrganizationUnit" runat="server" Text="Organization Unit :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_OrganizationUnit"
            Text='<%# Bind("OrganizationUnit") %>'
            Width="88px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Organization Unit."
            MaxLength="10"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Branch" runat="server" Text="Branch :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Branch"
            Text='<%# Bind("Branch") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Branch."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AccountNo" runat="server" Text="Account No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AccountNo"
            Text='<%# Bind("AccountNo") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Account No."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ADCode" runat="server" Text="AD Code :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ADCode"
            Text='<%# Bind("ADCode") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for AD Code."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IFCSCode" runat="server" Text="IFCS Code :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IFCSCode"
            Text='<%# Bind("IFCSCode") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IFCS Code."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GLCode" runat="server" Text="GL Code :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GLCode"
            Text='<%# Bind("GLCode") %>'
            Width="88px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GL Code."
            MaxLength="10"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSincBanks"
  DataObjectTypeName = "SIS.INC.incBanks"
  SelectMethod = "incBanksGetByID"
  UpdateMethod="incBanksUpdate"
  DeleteMethod="incBanksDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.INC.incBanks"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="BankID" Name="BankID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
