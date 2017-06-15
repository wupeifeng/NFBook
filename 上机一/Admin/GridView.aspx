<%@ Page Title="" Language="C#" MasterPageFile="~/MyFilmMsater.Master" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="上机一.Admin.GridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Height="329px" Width="766px" HorizontalAlign="Justify">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:TemplateField></asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="BookData.aspx?id={0}" DataTextField="Title" HeaderText="书名" />
            <asp:BoundField DataField="Author" HeaderText="作者" />
            <asp:BoundField DataField="CategoryName" HeaderText="类型" />
            <asp:BoundField DataField="Price" DataFormatString="{0:C}" HeaderText="价格" />
            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Image/delete.png" ShowDeleteButton="True" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetBook" TypeName="BLL.BookBLL"></asp:ObjectDataSource>

</asp:Content>
