<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_incDBKRealizationProcess.aspx.vb" Inherits="EF_incDBKRealizationProcess" title="Edit: Process DBK Realization" %>
<asp:Content ID="CPHincDBKRealizationProcess" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelincDBKRealizationProcess" runat="server" Text="&nbsp;Edit: Process DBK Realization"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLincDBKRealizationProcess" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLincDBKRealizationProcess"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "incDBKRealizationProcess"
    runat = "server" />
<asp:FormView ID="FVincDBKRealizationProcess"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSincDBKRealizationProcess"
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
          <asp:Label ID="L_DBKAmount" runat="server" Text="DBK Realization Amount :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DBKAmount"
            Text='<%# Bind("DBKAmount") %>'
            ToolTip="Value of DBK Realization Amount."
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
          <asp:Label ID="L_BankID" runat="server" Text="Bank :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_BankID"
            Width="88px"
            Text='<%# Bind("BankID") %>'
            Enabled = "False"
            ToolTip="Value of Bank."
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID="F_StatusID"
            Text='<%# Eval("StatusName") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmytxt"
            Runat="Server" >
          </asp:TextBox>
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DBK_BatchNo" runat="server" Text="DBK Realization Batch :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DBK_BatchNo"
            Text='<%# Bind("DBK_BatchNo") %>'
            ToolTip="Value of DBK Realization Batch."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
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
  ID = "ODSincDBKRealizationProcess"
  DataObjectTypeName = "SIS.INC.incDBKRealizationProcess"
  SelectMethod = "incDBKRealizationProcessGetByID"
  UpdateMethod="UZ_incDBKRealizationProcessUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.INC.incDBKRealizationProcess"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
