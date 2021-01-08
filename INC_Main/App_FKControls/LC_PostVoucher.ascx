<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_PostVoucher.ascx.vb" Inherits="LC_PostVoucher" %>
  <style>
    .x-div{
      font-family:Tahoma;
      font-size:12px;
    }
    .x-tbl{
      width:100%;
    }
    .x-h-tbl{
       font-weight:bold;
       color:white;
       background-color:#2f77f7;
    }
    .x-d1-tbl{
       /*color:black;
       background-color:white;*/
       color:green;
    }
    .x-d2-tbl{
       /*color:black;
       background-color:#cccaca;*/
       color:crimson;
    }
  </style>
  <asp:UpdatePanel runat="server">
    <ContentTemplate>
      <asp:Panel ID="pnl1" runat="server" Style="background-color: white; display: none; height:350px;border-radius:6px;" Width='800px'>
        <asp:Panel ID="pnlHeader" runat="server" Style="width: 100%; height: 33px; padding-top: 8px; text-align: center; border-bottom: 1pt solid lightgray;">
          <asp:Label ID="HeaderText" runat="server" Font-Size="16px" Font-Bold="true" Text='My Modal Text'></asp:Label>
          <asp:TextBox ID="F_VoucherDate" runat="server" MaxLength="10" Width="100px" CssClass="mytxt"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="modalContent" runat="server" Style="width:98%; height: 250px; padding:4px;overflow-y:scroll;">
          
        </asp:Panel>
        <asp:Panel ID="pnlFooter" runat="server" Style="width: 100%; height: 33px; padding-top: 8px; text-align: right; border-top: 1pt solid lightgray;">
          <asp:Label ID="L_PrimaryKey" runat="server" Style="display: none;"></asp:Label>
          <asp:Button ID="cmdOK" runat="server" CssClass="nt-but-success" Width="70px" Text="OK" Style="text-align: center; margin-right: 30px;" />
          <asp:Button ID="cmdCancel" runat="server" CssClass="nt-but-danger" Width="70px" Text="Cancel" Style="text-align: center; margin-right: 30px;" />
        </asp:Panel>
      </asp:Panel>
      <asp:Button ID="dummy" runat="server" Style="display: none;" Text="show"></asp:Button>
      <AJX:ModalPopupExtender
        ID="mPopup"
        BehaviorID="myMPE1"
        TargetControlID="dummy"
        BackgroundCssClass="modalBackground"
        CancelControlID="cmdCancel"
        OkControlID="cmdCancel"
        PopupControlID="pnl1"
        PopupDragHandleControlID="pnlHeader"
        DropShadow="true"
        runat="server">
      </AJX:ModalPopupExtender>
    </ContentTemplate>
    <Triggers>
      <asp:AsyncPostBackTrigger ControlID="cmdOK" EventName="Click" />
    </Triggers>
  </asp:UpdatePanel>


