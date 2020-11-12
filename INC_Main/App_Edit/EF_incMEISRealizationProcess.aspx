<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_incMEISRealizationProcess.aspx.vb" Inherits="EF_incMEISRealizationProcess" title="Edit: Process MEIS Realization" %>
<asp:Content ID="CPHincMEISRealizationProcess" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelincMEISRealizationProcess" runat="server" Text="&nbsp;Edit: Process MEIS Realization"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLincMEISRealizationProcess" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLincMEISRealizationProcess"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "incMEISRealizationProcess"
    runat = "server" />
<asp:FormView ID="FVincMEISRealizationProcess"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSincMEISRealizationProcess"
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
          <asp:Label ID="L_CustomInvoiceNo" runat="server" Text="Custom Invoice No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CustomInvoiceNo"
            Text='<%# Bind("CustomInvoiceNo") %>'
            ToolTip="Value of Custom Invoice No."
            Enabled = "False"
            Width="80px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BankID" runat="server" Text="Bank ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_BankID"
            Width="88px"
            Text='<%# Bind("BankID") %>'
            Enabled = "False"
            ToolTip="Value of Bank ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BankID_Display"
            Text='<%# Eval("INC_Banks2_BankName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RealisedAmount" runat="server" Text="MEIS Realised Amount :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RealisedAmount"
            Text='<%# Bind("RealisedAmount") %>'
            ToolTip="Value of MEIS Realised Amount."
            Enabled = "False"
            Width="136px"
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
          <asp:Label ID="L_ProcessedBy" runat="server" Text="Processed By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProcessedBy"
            Text='<%# Bind("ProcessedBy") %>'
            ToolTip="Value of Processed By."
            Enabled = "False"
            Width="72px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ProcessedOn" runat="server" Text="Processed On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ProcessedOn"
            Text='<%# Bind("ProcessedOn") %>'
            ToolTip="Value of Processed On."
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
        <td colspan="3">
          <asp:DropDownList
            ID="F_StatusID"
            SelectedValue='<%# Bind("StatusID") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="0">ALL</asp:ListItem>
            <asp:ListItem Value="2">Submitted</asp:ListItem>
            <asp:ListItem Value="3">Processed</asp:ListItem>
          </asp:DropDownList>
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
  ID = "ODSincMEISRealizationProcess"
  DataObjectTypeName = "SIS.INC.incMEISRealizationProcess"
  SelectMethod = "incMEISRealizationProcessGetByID"
  UpdateMethod="UZ_incMEISRealizationProcessUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.INC.incMEISRealizationProcess"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
