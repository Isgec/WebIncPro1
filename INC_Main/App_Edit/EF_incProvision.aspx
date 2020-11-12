<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_incProvision.aspx.vb" Inherits="EF_incProvision" title="Edit: INC_Provision" %>
<asp:Content ID="CPHincProvision" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelincProvision" runat="server" Text="&nbsp;Edit: INC_Provision"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLincProvision" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLincProvision"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "incProvision"
    runat = "server" />
<asp:FormView ID="FVincProvision"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSincProvision"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="SN :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of SN."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BatchNo" runat="server" Text="BN :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BatchNo"
            Text='<%# Bind("BatchNo") %>'
            ToolTip="Value of BN."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DivisionID" runat="server" Text="DIV :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DivisionID"
            Text='<%# Bind("DivisionID") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DIV."
            MaxLength="9"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CustomInvoiceNo" runat="server" Text="Custom Invoice No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CustomInvoiceNo"
            Text='<%# Bind("CustomInvoiceNo") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="incProvision"
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
            ValidationGroup = "incProvision"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CustomInvoiceDate" runat="server" Text="Custom Invoice Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CustomInvoiceDate"
            Text='<%# Bind("CustomInvoiceDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonCustomInvoiceDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CECustomInvoiceDate"
            TargetControlID="F_CustomInvoiceDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonCustomInvoiceDate" />
          <AJX:MaskedEditExtender 
            ID = "MEECustomInvoiceDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CustomInvoiceDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVCustomInvoiceDate"
            runat = "server"
            ControlToValidate = "F_CustomInvoiceDate"
            ControlExtender = "MEECustomInvoiceDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ShippingBillNo" runat="server" Text="Shipping Bill No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ShippingBillNo"
            Text='<%# Bind("ShippingBillNo") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Shipping Bill No."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ShippingBillDate" runat="server" Text="Shipping Bill Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ShippingBillDate"
            Text='<%# Bind("ShippingBillDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonShippingBillDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEShippingBillDate"
            TargetControlID="F_ShippingBillDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonShippingBillDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEShippingBillDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ShippingBillDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVShippingBillDate"
            runat = "server"
            ControlToValidate = "F_ShippingBillDate"
            ControlExtender = "MEEShippingBillDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ShippingBillCHA" runat="server" Text="Shipping Bill CHA :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ShippingBillCHA"
            Text='<%# Bind("ShippingBillCHA") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Shipping Bill CHA."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_LEODate" runat="server" Text="LEO Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_LEODate"
            Text='<%# Bind("LEODate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonLEODate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CELEODate"
            TargetControlID="F_LEODate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonLEODate" />
          <AJX:MaskedEditExtender 
            ID = "MEELEODate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_LEODate" />
          <AJX:MaskedEditValidator 
            ID = "MEVLEODate"
            runat = "server"
            ControlToValidate = "F_LEODate"
            ControlExtender = "MEELEODate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CustomInvoiceAmount" runat="server" Text="Custom Invoice Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CustomInvoiceAmount"
            Text='<%# Bind("CustomInvoiceAmount") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            MaxLength="16"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CustomInvoiceCurrency" runat="server" Text="Custom Invoice Currency :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CustomInvoiceCurrency"
            Text='<%# Bind("CustomInvoiceCurrency") %>'
            Width="248px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Custom Invoice Currency."
            MaxLength="30"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CustomPLNo" runat="server" Text="EBA No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CustomPLNo"
            Text='<%# Bind("CustomPLNo") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter EBA No."
            MaxLength="9"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FinalInvoiceNo" runat="server" Text="Final Invoice No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FinalInvoiceNo"
            Text='<%# Bind("FinalInvoiceNo") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Final Invoice No."
            MaxLength="9"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_FinalInvoiceDate" runat="server" Text="Final Invoice Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FinalInvoiceDate"
            Text='<%# Bind("FinalInvoiceDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonFinalInvoiceDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEFinalInvoiceDate"
            TargetControlID="F_FinalInvoiceDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonFinalInvoiceDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEFinalInvoiceDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FinalInvoiceDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVFinalInvoiceDate"
            runat = "server"
            ControlToValidate = "F_FinalInvoiceDate"
            ControlExtender = "MEEFinalInvoiceDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_InvoiceType" runat="server" Text="Invoice Type :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_InvoiceType"
            Text='<%# Bind("InvoiceType") %>'
            Width="248px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Invoice Type."
            MaxLength="30"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DBKAmountProvisional" runat="server" Text="DBK Amount Provisional :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DBKAmountProvisional"
            Text='<%# Bind("DBKAmountProvisional") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            MaxLength="16"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FOBAmount" runat="server" Text="FOB Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FOBAmount"
            Text='<%# Bind("FOBAmount") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            MaxLength="16"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ExchangeRateCustom" runat="server" Text="Exchange Rate Custom :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ExchangeRateCustom"
            Text='<%# Bind("ExchangeRateCustom") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            MaxLength="16"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BillOfLadingNo" runat="server" Text="Bill Of Lading No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BillOfLadingNo"
            Text='<%# Bind("BillOfLadingNo") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Bill Of Lading No."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BillOfLadingDate" runat="server" Text="Bill Of Lading Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BillOfLadingDate"
            Text='<%# Bind("BillOfLadingDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonBillOfLadingDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEBillOfLadingDate"
            TargetControlID="F_BillOfLadingDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonBillOfLadingDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEBillOfLadingDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_BillOfLadingDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVBillOfLadingDate"
            runat = "server"
            ControlToValidate = "F_BillOfLadingDate"
            ControlExtender = "MEEBillOfLadingDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BuyerName" runat="server" Text="Buyer Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BuyerName"
            Text='<%# Bind("BuyerName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Buyer Name."
            MaxLength="100"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ProjectCode" runat="server" Text="PRJ :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProjectCode"
            Text='<%# Bind("ProjectCode") %>'
            Width="56px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for PRJ."
            MaxLength="6"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ITSHSCode" runat="server" Text="ITSHS Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ITSHSCode"
            Text='<%# Bind("ITSHSCode") %>'
            Width="88px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ITSHS Code."
            MaxLength="10"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ItemDescription" runat="server" Text="Item Description :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ItemDescription"
            Text='<%# Bind("ItemDescription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Item Description."
            MaxLength="250"
            runat="server" />
        </td>
      </tr>
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
          <asp:Label ID="L_LoadingPort" runat="server" Text="Loading Port :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_LoadingPort"
            Text='<%# Bind("LoadingPort") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Loading Port."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="STATUS :" />&nbsp;
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
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreatedBy"
            Text='<%# Bind("CreatedBy") %>'
            ToolTip="Value of Created By."
            Enabled = "False"
            Width="72px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
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
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSincProvision"
  DataObjectTypeName = "SIS.INC.incProvision"
  SelectMethod = "incProvisionGetByID"
  UpdateMethod="UZ_incProvisionUpdate"
  DeleteMethod="UZ_incProvisionDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.INC.incProvision"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
