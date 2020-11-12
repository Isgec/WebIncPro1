<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_incDBKRealization.aspx.vb" Inherits="AF_incDBKRealization" title="Add: DBK Realization" %>
<asp:Content ID="CPHincDBKRealization" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelincDBKRealization" runat="server" Text="&nbsp;Add: DBK Realization"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLincDBKRealization" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLincDBKRealization"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "incDBKRealization"
    runat = "server" />
<asp:FormView ID="FVincDBKRealization"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSincDBKRealization"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgincDBKRealization" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CustomInvoiceNo" runat="server" Text="Custom Invoice No :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CustomInvoiceNo"
            Text='<%# Bind("CustomInvoiceNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="incDBKRealization"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Custom Invoice No."
            MaxLength="9"
            Width="80px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCustomInvoiceNo"
            runat = "server"
            ControlToValidate = "F_CustomInvoiceNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "incDBKRealization"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ValueDate" runat="server" Text="Value Date :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ValueDate"
            Text='<%# Bind("ValueDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonValueDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEValueDate"
            TargetControlID="F_ValueDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonValueDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEValueDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ValueDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVValueDate"
            runat = "server"
            ControlToValidate = "F_ValueDate"
            ControlExtender = "MEEValueDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ScrollNo" runat="server" Text="Scroll No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ScrollNo"
            Text='<%# Bind("ScrollNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Scroll No."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ScrollDate" runat="server" Text="Scroll Date :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ScrollDate"
            Text='<%# Bind("ScrollDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonScrollDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEScrollDate"
            TargetControlID="F_ScrollDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonScrollDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEScrollDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ScrollDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVScrollDate"
            runat = "server"
            ControlToValidate = "F_ScrollDate"
            ControlExtender = "MEEScrollDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DBKAmount" runat="server" Text="DBK Amount :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DBKAmount"
            Text='<%# Bind("DBKAmount") %>'
            Width="136px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="incDBKRealization"
            MaxLength="16"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BankID" runat="server" Text="Bank :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_incBanks
            ID="F_BankID"
            SelectedValue='<%# Bind("BankID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "incDBKRealization"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSincDBKRealization"
  DataObjectTypeName = "SIS.INC.incDBKRealization"
  InsertMethod="UZ_incDBKRealizationInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.INC.incDBKRealization"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
