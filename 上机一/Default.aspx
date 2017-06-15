<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="上机一.Default" MasterPageFile="~/MyFilmMsater.Master"%>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptShowData" runat="server" OnItemCommand="rptShowData_ItemCommand">
        <ItemTemplate>
            <table style="width:100%;">
                <tr>
                    <td rowspan="5">
                        <a target="_blank" href='<%# "MyHandler.ashx?name="+Eval("ISBN") %>'>
                        <asp:Image ID="Image1" runat="server" Width="120" Height="200" ImageUrl='<%# "~/Image/BookCover/"+Eval("ISBN")+".jpg" %>' /></a>
                    </td>
                    <td>
                        书名：<asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/BookDetail.aspx?id="+ Eval("ID") %>' Text='<%# Eval("Title") %>' runat="server">HyperLink</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        作者：<%# Eval("Author") %></td>
                </tr>
                <tr>
                    <td>
                        价格：<%# Eval("Price","{0:C}") %></td>
                </tr>
                <tr>
                    <td>
                        简介：<div style="width:630px;white-space:nowrap;overflow:hidden;text-overflow:ellipsis">
                            <%# Eval("Content") %>
                           </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="btnBuy" runat="server" Text="购买" CommandArgument='<%# Eval("ID") %>'/>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <table style="width:100%;">
                <tr>
                    <td rowspan="5">
                        <a target="_blank" href='<%# "MyHandler.ashx?name="+Eval("ISBN") %>'>
                        <asp:Image ID="Image1" runat="server" Width="120" Height="200" ImageUrl='<%# "~/Image/BookCover/"+Eval("ISBN")+".jpg" %>' /></a>
                    </td>
                    <td>
                        书名：<asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/BookDetail.aspx?id="+ Eval("ID") %>'  Text='<%# Eval("Title") %>' runat="server">HyperLink</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        作者：<%# Eval("Author") %></td>
                </tr>
                <tr>
                    <td>
                        价格：<%# Eval("Price","{0:C}") %></td>
                </tr>
                <tr>
                    <td>
                        简介：<div style="width:630px;white-space:nowrap;overflow:hidden;text-overflow:ellipsis">
                            <%# Eval("Content") %>
                           </div>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="btnBuy" CommandArgument='<%# Eval("ID") %>' runat="server" Text="购买" />
                    </td>
                </tr>
            </table>
        </AlternatingItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
        <HeaderTemplate>
            <div style="text-align:center;font-size:xx-large;" >
            图书列表
               </div>
        </HeaderTemplate>
    </asp:Repeater>
    <asp:Button ID="btnProv" runat="server" Text="上一页" OnClick="btnProv_Click" />
&nbsp;<asp:Label ID="lblIndex" runat="server"></asp:Label>/<asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
&nbsp;<asp:Button ID="btnNext" runat="server" Text="下一页" OnClick="btnNext_Click" />
</asp:Content>
