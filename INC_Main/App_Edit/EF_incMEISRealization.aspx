<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_incMEISRealization.aspx.vb" Inherits="EF_incMEISRealization" title="Edit: MEIS Realization" %>
<asp:Content ID="CPHincMEISRealization" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelincMEISRealization" runat="server" Text="&nbsp;Edit: MEIS Realization"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLincMEISRealization" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLincMEISRealization"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "incMEISRealization"
    runat = "server" />
<asp:FormView ID="FVincMEISRealization"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSincMEISRealization"
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
            ValidationGroup="incMEISRealization"
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
            ValidationGroup = "incMEISRealization"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SBillNo" runat="server" Text="S-Bill No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SBillNo"
            Text='<%# Bind("SBillNo") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for S-Bill No."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SBillDate" runat="server" Text="S-Bill Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SBillDate"
            Text='<%# Bind("SBillDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonSBillDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CESBillDate"
            TargetControlID="F_SBillDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonSBillDate" />
          <AJX:MaskedEditExtender 
            ID = "MEESBillDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_SBillDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVSBillDate"
            runat = "server"
            ControlToValidate = "F_SBillDate"
            ControlExtender = "MEESBillDate"
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
          <asp:Label ID="L_FileNo" runat="server" Text="File No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FileNo"
            Text='<%# Bind("FileNo") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for File No."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_FileDate" runat="server" Text="File Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FileDate"
            Text='<%# Bind("FileDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonFileDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEFileDate"
            TargetControlID="F_FileDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonFileDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEFileDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FileDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVFileDate"
            runat = "server"
            ControlToValidate = "F_FileDate"
            ControlExtender = "MEEFileDate"
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
          <asp:Label ID="L_MEISNo" runat="server" Text="MEIS No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MEISNo"
            Text='<%# Bind("MEISNo") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for MEIS No."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MEISDate" runat="server" Text="MEIS Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MEISDate"
            Text='<%# Bind("MEISDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonMEISDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEMEISDate"
            TargetControlID="F_MEISDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonMEISDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEMEISDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_MEISDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVMEISDate"
            runat = "server"
            ControlToValidate = "F_MEISDate"
            ControlExtender = "MEEMEISDate"
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
          <asp:Label ID="L_MEISAmount" runat="server" Text="MEIS Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MEISAmount"
            Text='<%# Bind("MEISAmount") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            MaxLength="16"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_OtherTax" runat="server" Text="Other Tax :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OtherTax"
            Text='<%# Bind("OtherTax") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            MaxLength="16"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SaleAmount" runat="server" Text="Sale Amount :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SaleAmount"
            Text='<%# Bind("SaleAmount") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            MaxLength="16"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RealisedAmount" runat="server" Text="Realised Amount :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RealisedAmount"
            Text='<%# Bind("RealisedAmount") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            ValidationGroup= "incMEISRealization"
            MaxLength="16"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SoldTo" runat="server" Text="Sold To :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SoldTo"
            Text='<%# Bind("SoldTo") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Sold To."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BankID" runat="server" Text="Bank ID :" /><span style="color:red">*</span>
        </td>
        <td>
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
            ValidationGroup = "incMEISRealization"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td>
          <asp:DropDownList
            ID="F_StatusID"
            SelectedValue='<%# Bind("StatusID") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="1">Free</asp:ListItem>
            <asp:ListItem Value="2">Submitted</asp:ListItem>
          </asp:DropDownList>
         </td>
        <td class="alignright">
          <asp:Label ID="L_BatchNo" runat="server" Text="B.No. :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BatchNo"
            Text='<%# Bind("BatchNo") %>'
            ToolTip="Value of B.No.."
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
          <asp:Label ID="L_MEIS_BatchNo" runat="server" Text="MEIS Batch No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MEIS_BatchNo"
            Text='<%# Bind("MEIS_BatchNo") %>'
            ToolTip="Value of MEIS Batch No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MEIS_DocumentNo" runat="server" Text="MEIS Document No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MEIS_DocumentNo"
            Text='<%# Bind("MEIS_DocumentNo") %>'
            ToolTip="Value of MEIS Document No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MEIS_LineNo" runat="server" Text="MEIS Line No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MEIS_LineNo"
            Text='<%# Bind("MEIS_LineNo") %>'
            ToolTip="Value of MEIS Line No."
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
  ID = "ODSincMEISRealization"
  DataObjectTypeName = "SIS.INC.incMEISRealization"
  SelectMethod = "incMEISRealizationGetByID"
  UpdateMethod="UZ_incMEISRealizationUpdate"
  DeleteMethod="UZ_incMEISRealizationDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.INC.incMEISRealization"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
