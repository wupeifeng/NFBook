<%@ Page Title="" Language="C#" MasterPageFile="~/MyFilmMsater.Master" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="上机一.BookDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table style="width: 100%;" cellspacing="10">
        <tr>
            <td style="text-align:right;width:100px;">书名：</td>
            <td><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></td>
            <td rowspan="6">
                <asp:Image ID="imgCover" runat="server" />
                </td>
        </tr>
        <tr>
            <td style="text-align:right">作者：</td>
            <td><asp:Label ID="lblAuthor" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right">价格：</td>
            <td><asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right">类别：</td>
            <td><asp:Label ID="lblCategoryName" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right">出版社：</td>
            <td><asp:Label ID="lblPublisherName" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right">出版日期：</td>
            <td><asp:Label ID="lblPublishDate" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right">内容简介：</td>
            <td colspan ="2"><asp:Label ID="lblContent" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right">作者简介：</td>
            <td colspan="2"><asp:Label ID="lblAuthorDesc" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right">编辑推介：</td>
            <td colspan="2"><asp:Label ID="lblEditorComment" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
</asp:Content>
