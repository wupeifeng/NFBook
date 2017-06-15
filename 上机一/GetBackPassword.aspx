<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetBackPassword.aspx.cs" Inherits="上机一.GetBackPassword" MasterPageFile="~/MyFilmMsater.Master"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border-color: inherit; border-width: 1px; width: 615px;text-align:center;margin:0 auto;margin-top:80px;">
        
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Supplement.aspx">基本资料</asp:HyperLink>|
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Contact.aspx">联系方式</asp:HyperLink>|
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/PasswordProtection.aspx">密码保护</asp:HyperLink>|
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/GetBackPassword.aspx">密码找回</asp:HyperLink>
        
        <br />
        <br />
    
        <asp:Label ID="lblName" runat="server" Font-Size="X-Large" Text="密码找回"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblUid" runat="server" Text="帐号（N）："></asp:Label>
        <asp:TextBox ID="txtUid" runat="server" Width="169px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUid" runat="server" ControlToValidate="txtUid" ErrorMessage="请输入您的帐号!" ValidationGroup="select">*</asp:RequiredFieldValidator>
        <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="查询" ValidationGroup="select" />
        <br />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="发现以下错误" ShowMessageBox="True" ShowSummary="False" ValidationGroup="select" />
        <div style="height: 38px;text-align:left">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblSecurityName" runat="server"></asp:Label>
        </div>
        <br />
        <asp:Label ID="lblSecretAnswer" runat="server" Text="答案（A）："></asp:Label>
        <asp:TextBox ID="txtSecretAnswer" runat="server" Width="232px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvSecretAnswer" runat="server" ControlToValidate="txtSecretAnswer" ErrorMessage="请输入您的答案" ValidationGroup="SecretAnswer">*</asp:RequiredFieldValidator>
        <br />
        <br />
&nbsp;<asp:Button ID="btnOK" runat="server" Text="找回" ValidationGroup="SecretAnswer" Width="100px" OnClick="btnOK_Click" />
        <br />
        <br />
        <asp:Label ID="lblText" runat="server"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="发现以下错误" ShowMessageBox="True" ShowSummary="False" ValidationGroup="SecretAnswer" />
    
    </div>
</asp:Content>
