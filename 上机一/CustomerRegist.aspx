<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRegist.aspx.cs" Inherits="上机一.CustomerRegist" MasterPageFile="~/MyFilmMsater.Master"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <div style="width: 573px; text-align:center;margin:0 auto;">
    
        <asp:Label ID="lblUser" runat="server" Font-Size="X-Large" Text="用户注册"></asp:Label>
        <br />
        <br />
        &nbsp;<asp:Label ID="lblUid" runat="server" Text="帐号（N）：" AccessKey="N" AssociatedControlID="txtID"></asp:Label>
        <asp:TextBox ID="txtID" runat="server" Width="203px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvID" runat="server" ControlToValidate="txtID" ErrorMessage="请输入您的帐号！" ValidationGroup="Regist">*</asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;<asp:Label ID="lblPwd" runat="server" Text="密码（P）：" AccessKey="P" AssociatedControlID="txtPwd"></asp:Label>
        <asp:TextBox ID="txtPwd" runat="server" Width="203px" MaxLength="8" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ControlToValidate="txtPwd" ErrorMessage="请输入您的密码！" ValidationGroup="Regist">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lblPwds" runat="server" Text="重负密码（R）：" AccessKey="R" AssociatedControlID="txtPwd2"></asp:Label>
        <asp:TextBox ID="txtPwd2" runat="server" Width="203px" MaxLength="8" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPwd2" runat="server" ControlToValidate="txtPwd2" ErrorMessage="请再次输入您的密码！" ValidationGroup="Regist">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPwd" ControlToValidate="txtPwd2" ErrorMessage="两次密码必须一致" ValidationGroup="Regist">*</asp:CompareValidator>
        <br />
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="电子邮箱（E）：" AccessKey="E" AssociatedControlID="txtEamil"></asp:Label>
        <asp:TextBox ID="txtEamil" runat="server" Width="203px"></asp:TextBox>
    
        <asp:RequiredFieldValidator ID="rfvEamil" runat="server" ControlToValidate="txtEamil" ErrorMessage="请输入您的电子邮箱地址" ValidationGroup="Regist">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEamil" ErrorMessage="电子邮件格式错误" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Regist">*</asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="注册" ValidationGroup="Regist" Width="145px" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblTxt" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="发现以下错误" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Regist" />
    
    </div>

</asp:Content>
