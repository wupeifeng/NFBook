<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="上机一.WebForm1" MasterPageFile="~/MyFilmMsater.Master"%>
<%@ MasterType VirtualPath="~/MyFilmMsater.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style=" width: 536px;text-align:center;margin:0 auto;margin-top:80px;">
    
        <asp:Label ID="lblUser" runat="server" Font-Bold="True" Font-Size="X-Large" Text="注册用户登录"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblName" runat="server" Text="帐号（N）：" AccessKey="N" AssociatedControlID="txtName"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" Height="16px" Width="187px" MaxLength="8"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="用户名不能为空！" ValidationGroup="login">*</asp:RequiredFieldValidator>
&nbsp;<asp:HyperLink ID="lnkUser" runat="server" NavigateUrl="~/CustomerRegist.aspx">用户注册</asp:HyperLink>
        <br />
        <br />
        <asp:Label ID="lblPwd" runat="server" Text="密码（P）：" AccessKey="P" AssociatedControlID="txtPwd"></asp:Label>
        <asp:TextBox ID="txtPwd" runat="server" Height="16px" Width="188px" TextMode="Password" MaxLength="8"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ControlToValidate="txtPwd" ErrorMessage="密码不能为空！" ValidationGroup="login">*</asp:RequiredFieldValidator>
&nbsp;<asp:HyperLink ID="lnkPwd" runat="server" NavigateUrl="~/GetBackPassword.aspx">找回密码</asp:HyperLink>
        <br />
        <br />
        <asp:Button ID="btnOK" runat="server" Height="26px" Text="登录" Width="164px" OnClick="btnOK_Click" ValidationGroup="login" />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblText" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="发生以下错误" ShowMessageBox="True" ShowSummary="False" ValidationGroup="login" />
            
    </div>
        </asp:Content>
