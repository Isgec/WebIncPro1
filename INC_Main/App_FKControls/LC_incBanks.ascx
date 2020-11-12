<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_incBanks.ascx.vb" Inherits="LC_incBanks" %>
<asp:DropDownList 
  ID = "DDLincBanks"
  DataSourceID = "OdsDdlincBanks"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorincBanks"
  Runat = "server" 
  ControlToValidate = "DDLincBanks"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlincBanks"
  TypeName = "SIS.INC.incBanks"
  SortParameterName = "OrderBy"
  SelectMethod = "incBanksSelectList"
  Runat="server" />
