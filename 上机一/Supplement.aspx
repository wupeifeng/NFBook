<%@ Page Title="" Language="C#" MasterPageFile="~/MyFilmMsater.Master" AutoEventWireup="true" CodeBehind="Supplement.aspx.cs" Inherits="上机一.Supplement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top:80px;text-align:center;">

        <asp:HyperLink ID="HyperLink4" runat="server" Text="基本资料" NavigateUrl="~/Supplement.aspx"></asp:HyperLink>|
        <asp:HyperLink ID="HyperLink5" runat="server" Text="联系方式" NavigateUrl="~/Contact.aspx"></asp:HyperLink>|
        <asp:HyperLink ID="HyperLink6" runat="server" Text="密码保护" NavigateUrl="~/PasswordProtection.aspx"></asp:HyperLink>|
        <asp:HyperLink ID="HyperLink7" runat="server" Text="密码找回" NavigateUrl="~/GetBackPassword.aspx"></asp:HyperLink>

        <br />

        <br />

        <br />
        <br />
        <asp:Label ID="lblName" runat="server" Text="姓    名："></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="208px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="姓名不能为空！" ValidationGroup="Supp">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="性    别："></asp:Label>
        <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" Text="男" GroupName="Gerder" />
        &nbsp;&nbsp;
        <asp:RadioButton ID="RadioButton2" runat="server" Text="女" GroupName="Gerder" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="lblAge" runat="server" Text="年    龄："></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Width="208px" onkeypress="if (event.keyCode<48 || event.keyCode>57)event.returnValue=false;"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="年龄不能为空！" ValidationGroup="Supp">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="保存" ValidationGroup="Supp" Width="100px" OnClick="Button1_Click" />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="发现以下错误" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Supp" />
        <br />

    </div>
</asp:Content>
