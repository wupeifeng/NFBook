<%@ Page Title="" Language="C#" MasterPageFile="~/MyFilmMsater.Master" AutoEventWireup="true" CodeBehind="BookData.aspx.cs" Inherits="上机一.Admin.BookData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;" cellspacing="5">
        <tr>
            <td style="text-align:right;width:100px;">书名：</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="请输入图书的名称！">*</asp:RequiredFieldValidator>
            </td>
            <td rowspan="9" style="vertical-align:top;">
                <asp:Image ID="imgCover" Height="400" Width="240" runat="server" />
                <asp:FileUpload ID="FileUpload1" runat="server" Width="165px" />
                <asp:Button ID="btnUpload" runat="server" Text="上传" Width="61px" OnClick="btnUpload_Click"/>
                </td>
        </tr>
        <tr>
            <td style="text-align:right">作者：</td>
            <td>
                <asp:TextBox ID="txtAuthor" Width="300" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAuthor" ErrorMessage="请输入作者的名称！">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">书号：</td>
            <td>
                <asp:TextBox ID="txtISBN" Width="300" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">价格：</td>
            <td>
                <asp:TextBox ID="txtPrice" Width="200" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPrice" ErrorMessage="价格必须大于零！" Operator="GreaterThan" Type="Double" ValueToCompare="0">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">类别：</td>
            <td>
                <asp:DropDownList ID="dropCategory" Width="200" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">出版社：</td>
            <td>
                <asp:DropDownList ID="dropPublisher" Width="200" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">出版日期：</td>
            <td>
                <asp:TextBox ID="txtPublishDate" Width="200" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">内容简介：</td>
            <td> 
                <asp:TextBox ID="txtContent" Width="400" Height="150" TextMode="MultiLine" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">作者简介：</td>
            <td >
                <asp:TextBox ID="txtAuthorDesc" Width="400" Height="150" TextMode="MultiLine" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">编辑推介：</td>
            <td colspan="2">
                <asp:TextBox ID="txtEditorComment" Width="400" Height="150" TextMode="MultiLine" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="text-align:center">
        <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
        <input id="btnBack" type="button" onclick="history.back();" value="返回" />
        <br />
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
