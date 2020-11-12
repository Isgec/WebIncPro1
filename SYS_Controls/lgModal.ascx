<%@ Control Language="VB" AutoEventWireup="false" CodeFile="lgModal.ascx.vb" Inherits="lgModal" %>
<script type="text/javascript">
	function cancelMessage() {
		try {
			var tmp = '<%=OnBeforeCancel %>';
			eval(tmp);
		} catch (ex) { }
		var mPB = $find('mpe1');
		mPB.hide();
		try {
			var tmp = '<%=OnAfterCancel %>';
			eval(tmp);
		} catch (ex) { }

		return '<%=GetReturnTrueOnCancel %>';
	}
	function hideMessageMPV() {
		var mPB = $find('mpe1');
		mPB.hide();
		return false;
	}
</script>
<asp:Label ID="dummy" runat="server" Style="display: none"></asp:Label>
<asp:Panel ID="pnl1" runat="server" BackColor="Black" Style="display: none;" Height='<%# Height %>' Width='<%# Width %>'>
  <asp:Panel ID="pnlHeader" runat="server" style="width:100%;margin-top:2px; text-align:center;border-bottom:1pt solid lightgray;" >
    <asp:Label ID="HeaderText" runat="server" Font-Size="16px" Font-Bold="true" Text='<%# Header %>'></asp:Label>
  </asp:Panel>
  <asp:Panel ID="pnlFooter" runat="server" Height="40px" Width="100%" style="margin-bottom:2px;border-top:1pt solid lightgray;">
    <asp:Button ID="cmdOK" runat="server" Width="70px" Text="OK" style="text-align:center;margin-right:30px;" />
    <asp:Button ID="cmdCancel" runat="server" Width="70px" Text="Cancle" style="text-align:center;margin-right:30px;" />
  </asp:Panel>
</asp:Panel>
<AJX:ModalPopupExtender 
  ID="mPopup" 
  TargetControlID="dummy" 
  BackgroundCssClass="modalBackground" 
  CancelControlID="cmdCancel" 
  OkControlID="cmdOK" 
  PopupControlID="pnl1" 
  PopupDragHandleControlID="pnlHeader" 
  runat="server">
</AJX:ModalPopupExtender>
