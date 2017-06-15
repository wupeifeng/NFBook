<%@ Page Title="" Language="C#" MasterPageFile="~/MyFilmMsater.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="上机一.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top:80px; text-align:center;">

        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Supplement.aspx">基本资料</asp:HyperLink>|
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Contact.aspx">联系方式</asp:HyperLink>|
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/PasswordProtection.aspx">密码保护</asp:HyperLink>|
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/GetBackPassword.aspx">密码找回</asp:HyperLink>

        <br />

        <br />
        <br />
        <br />
        联系电话：<asp:TextBox ID="TextBox1" runat="server" Width="208px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="联系电话不能为空！">*</asp:RequiredFieldValidator>
        <br />
        <br />
        QQ/微信 ：<asp:TextBox ID="TextBox2" runat="server" Width="208px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="QQ/微信不能为空！">*</asp:RequiredFieldValidator>
        <br />

        <br />
        通信地址：<asp:TextBox ID="TextBox3" runat="server" Height="64px" Width="208px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="通信地址不能为空！">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="保存" Width="100px" OnClick="Button1_Click" />
        <br />

    <br />

    </div>
</asp:Content>
