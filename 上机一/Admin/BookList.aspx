<%@ Page Title="" Language="C#" MasterPageFile="~/MyFilmMsater.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="上机一.Admin.BookList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="text-align:left;">
                <asp:TextBox ID="txtSearch" runat="server" Width="200px"></asp:TextBox>
                <asp:LinkButton ID="btnSearch" runat="server"><img src="../Image/magnifier-left.png" style="border:0px;" />查询</asp:LinkButton>
            </td>
            <td style="text-align:right;">
                <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" />
                <asp:Button ID="btnDeleteAll" runat="server" OnClientClick="return confirm('删除选中的数据？');" Text="删除" OnClick="btnDeleteAll_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
                <asp:ListView ID="lstDataList" runat="server" DataKeyNames="ID" OnItemDeleting="lstDataList_ItemDeleting">
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFF8DC;">
                            <td align="left">
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </td>
                            <td>
                                <asp:HyperLink ID="hyTitle" Text='<%# (Eval("Title").ToString().Length>40)?Eval("Title").ToString().Substring(0,23)+"...":Eval("Title") %>' NavigateUrl='<%# "~/Admin/BookData.aspx?id="+Eval("ID")  %>' runat="server"></asp:HyperLink>
                            </td>
                            <td>
                                <asp:Label ID="AuthorLabel" runat="server" Text='<%#Eval("Author") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="PublisherNameLabel" runat="server" Text='<%#Eval("PublisherName") %>'></asp:Label>
                            </td>
                            <td align="right">
                                <asp:LinkButton ID="btnDelete" CommandName="Delete" OnClientClick="return confirm('删除选中的数据？');" runat="server"><img src="../Image/delete.png" style="border:0px;" /></asp:LinkButton>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #DCDCDC; color: #000000;">
                            <td align="left">
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </td>
                            <td>
                                <asp:HyperLink ID="hyTitle" Text='<%# (Eval("Title").ToString().Length>40)?Eval("Title").ToString().Substring(0,23)+"...":Eval("Title") %>' NavigateUrl='<%# "~/Admin/BookData.aspx?id="+Eval("ID")  %>' runat="server"></asp:HyperLink>
                            </td>
                            <td>
                                <asp:Label ID="AuthorLabel" runat="server" Text='<%#Eval("Author") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="PublisherNameLabel" runat="server" Text='<%#Eval("PublisherName") %>'></asp:Label>
                            </td>
                            <td align="right">
                                <asp:LinkButton ID="btnDelete" CommandName="Delete" OnClientClick="return confirm('删除选中的数据？');" runat="server"><img src="../Image/delete.png" style="border:0px;" /></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table style="width: 100%; background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr style="background-color: #DCDCDC; color: #000000;">
                                <td align="left" style="width:20px;">
                                    <asp:CheckBox ID="chkSelectAll" AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged" runat="server" />
                                </td>
                                <td align="center">书名</td>
                                <td align="center" style="width:100px;">作者</td>
                                <td align="center" style="width:150px;">出版社</td>
                                <td align="right" style="width: 1px"></td>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                </asp:ListView>
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstDataList">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                </asp:DataPager>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetBook" TypeName="BLL.BookBLL"></asp:ObjectDataSource>
</asp:Content>
