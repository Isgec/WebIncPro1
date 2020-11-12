<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_incDBKRealization.aspx.vb" Inherits="EF_incDBKRealization" title="Edit: DBK Realization" %>
<asp:Content ID="CPHincDBKRealization" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelincDBKRealization" runat="server" Text="&nbsp;Edit: DBK Realization"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLincDBKRealization" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLincDBKRealization"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "incDBKRealization"
    runat = "server" />
<asp:FormView ID="FVincDBKRealization"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSincDBKRealization"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
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
          <asp:Label ID="L_CustomInvoiceNo" runat="server" Text="Custom Invoice No :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CustomInvoiceNo"
            Text='<%# Bind("CustomInvoiceNo") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="incDBKRealization"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Custom Invoice No."
            MaxLength="9"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ScrollNo" runat="server" Text="Scroll No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ScrollNo"
            Text='<%# Bind("ScrollNo") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Scroll No."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DBKAmount" runat="server" Text="DBK Amount :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DBKAmount"
            Text='<%# Bind("DBKAmount") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            ValidationGroup= "incDBKRealization"
            MaxLength="16"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            Width="72px"
            Text='<%# Bind("CreatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Created By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Created On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID="F_StatusID"
            Text='<%# Eval("StatusName") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmytxt"
            Runat="Server" >
          </asp:TextBox>
         </td>
        <td class="alignright">
          <asp:Label ID="L_BatchNo" runat="server" Text="B.No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BatchNo"
            Text='<%# Bind("BatchNo") %>'
            ToolTip="Value of B.No."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DBK_DocumentNo" runat="server" Text="DBK Document No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DBK_DocumentNo"
            Text='<%# Bind("DBK_DocumentNo") %>'
            ToolTip="Value of DBK Document No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DBK_BatchNo" runat="server" Text="DBK Batch No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DBK_BatchNo"
            Text='<%# Bind("DBK_BatchNo") %>'
            ToolTip="Value of DBK Batch No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DBK_LineNo" runat="server" Text="DBK Line No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DBK_LineNo"
            Text='<%# Bind("DBK_LineNo") %>'
            ToolTip="Value of DBK Line No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSincDBKRealization"
  DataObjectTypeName = "SIS.INC.incDBKRealization"
  SelectMethod = "incDBKRealizationGetByID"
  UpdateMethod="UZ_incDBKRealizationUpdate"
  DeleteMethod="UZ_incDBKRealizationDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.INC.incDBKRealization"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
