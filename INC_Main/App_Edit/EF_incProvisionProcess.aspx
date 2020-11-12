<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_incProvisionProcess.aspx.vb" Inherits="EF_incProvisionProcess" title="Edit: Process Provision" %>
<asp:Content ID="CPHincProvisionProcess" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelincProvisionProcess" runat="server" Text="&nbsp;Edit: Process Provision"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLincProvisionProcess" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLincProvisionProcess"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "incProvisionProcess"
    runat = "server" />
<asp:FormView ID="FVincProvisionProcess"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSincProvisionProcess"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="SN :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of SN."
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
          <asp:Label ID="L_ProjectCode" runat="server" Text="Project :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProjectCode"
            Text='<%# Bind("ProjectCode") %>'
            ToolTip="Value of Project."
            Enabled = "False"
            Width="56px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DivisionID" runat="server" Text="Division :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DivisionID"
            Text='<%# Bind("DivisionID") %>'
            ToolTip="Value of Division."
            Enabled = "False"
            Width="80px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CustomInvoiceNo" runat="server" Text="Custom Invoice No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CustomInvoiceNo"
            Text='<%# Bind("CustomInvoiceNo") %>'
            ToolTip="Value of Custom Invoice No."
            Enabled = "False"
            Width="80px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CustomInvoiceDate" runat="server" Text="Custom Invoice Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CustomInvoiceDate"
            Text='<%# Bind("CustomInvoiceDate") %>'
            ToolTip="Value of Custom Invoice Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CustomInvoiceAmount" runat="server" Text="Custom Invoice Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CustomInvoiceAmount"
            Text='<%# Bind("CustomInvoiceAmount") %>'
            ToolTip="Value of Custom Invoice Amount."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CustomInvoiceCurrency" runat="server" Text="Custom Invoice Currency :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CustomInvoiceCurrency"
            Text='<%# Bind("CustomInvoiceCurrency") %>'
            ToolTip="Value of Custom Invoice Currency."
            Enabled = "False"
            Width="248px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DBKAmountProvisional" runat="server" Text="DBK Amount Provisional :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DBKAmountProvisional"
            Text='<%# Bind("DBKAmountProvisional") %>'
            ToolTip="Value of DBK Amount Provisional."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MEISAmount" runat="server" Text="MEIS Amount Provisional :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MEISAmount"
            Text='<%# Bind("MEISAmount") %>'
            ToolTip="Value of MEIS Amount Provisional."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProcessedBy" runat="server" Text="ProcessedBy :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProcessedBy"
            Text='<%# Bind("ProcessedBy") %>'
            ToolTip="Value of ProcessedBy."
            Enabled = "False"
            Width="72px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ProcessedOn" runat="server" Text="ProcessedOn :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProcessedOn"
            Text='<%# Bind("ProcessedOn") %>'
            ToolTip="Value of ProcessedOn."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DBK_BatchNo" runat="server" Text="DBK Vch No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DBK_BatchNo"
            Text='<%# Bind("DBK_BatchNo") %>'
            ToolTip="Value of DBK Vch No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MEIS_BatchNo" runat="server" Text="MEIS Vch No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MEIS_BatchNo"
            Text='<%# Bind("MEIS_BatchNo") %>'
            ToolTip="Value of MEIS Vch No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
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
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSincProvisionProcess"
  DataObjectTypeName = "SIS.INC.incProvisionProcess"
  SelectMethod = "incProvisionProcessGetByID"
  UpdateMethod="UZ_incProvisionProcessUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.INC.incProvisionProcess"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
