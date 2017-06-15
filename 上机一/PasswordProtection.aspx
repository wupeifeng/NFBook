<%@ Page Title="" Language="C#" MasterPageFile="~/MyFilmMsater.Master" AutoEventWireup="true" CodeBehind="PasswordProtection.aspx.cs" Inherits="上机一.PasswordProtection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:0 auto;margin-top:80px;text-align:center;">

        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Supplement.aspx">基本资料</asp:HyperLink>|
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Contact.aspx">联系方式</asp:HyperLink>|
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/PasswordProtection.aspx">密码保护</asp:HyperLink>|
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/GetBackPassword.aspx">密码找回</asp:HyperLink>
        <br />
        <br />
        <br />
        密保问题：<asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>请选择密保问题</asp:ListItem>
            <asp:ListItem>您母亲的姓名是？</asp:ListItem>
            <asp:ListItem>您父亲的姓名是？</asp:ListItem>
            <asp:ListItem>您配偶的姓名是？</asp:ListItem>
            <asp:ListItem>您的出生地是？</asp:ListItem>
            <asp:ListItem>您高中班主任的名字是？</asp:ListItem>
            <asp:ListItem>您初中班主任的名字是？</asp:ListItem>
            <asp:ListItem>您小学班主任的名字是？</asp:ListItem>
            <asp:ListItem>您的小学校名是？您的学号（或工号）是？</asp:ListItem>
            <asp:ListItem>您父亲的生日是？</asp:ListItem>
            <asp:ListItem>您母亲的生日是？</asp:ListItem>
            <asp:ListItem>您配偶的生日是？</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="请选择密保问题" InitialValue="请选择密保问题" ValidationGroup="Protection">*</asp:RequiredFieldValidator>
        <br />
        <br />
&nbsp; 答案： 
        <asp:TextBox ID="TextBox1" runat="server" Width="273px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="答案不能为空！" ValidationGroup="Protection">*</asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;确认答案：<asp:TextBox ID="TextBox2" runat="server" Width="273px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" ErrorMessage="确认答案不能为空！" ValidationGroup="Protection">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox1" ControlToValidate="TextBox2" ErrorMessage="两次答案必须一致！" ValidationGroup="Protection">*</asp:CompareValidator>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="保存" Width="100px" ValidationGroup="Protection" OnClick="Button1_Click" />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="发现以下错误" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Protection" />
        <br />

    </div>
</asp:Content>
