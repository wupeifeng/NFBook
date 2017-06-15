<%@ Page Title="" Language="C#" MasterPageFile="~/MyFilmMsater.Master" AutoEventWireup="true" CodeBehind="ShopCarList.aspx.cs" Inherits="上机一.ShopCarList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%; text-align:center;">
            <tr>
                <td style="width:10%;">商品信息</td>
                <td style="width:30%;">商品名称</td>
                <td style="width:15%;">单价</td>
                <td style="width:15%;">数量</td>
                <td style="width:15%;">金额</td>
                <td style="width:15%;">操作</td>
            </tr>

        </table>
    <asp:Repeater ID="rptShowData" runat="server" OnItemCommand="rptShowData_ItemCommand">
        <ItemTemplate>
            <table style="width:100%; text-align:center;">
                <tr>
                    <td style="width:10%;">
                        <asp:Image ID="Image1" runat="server" Width="60" Height="120" ImageUrl='<%# "~/Image/BookCover/"+Eval("ISBN")+".jpg" %>' />
                    </td>
                    <td style="width:30%;">
                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/BookDetail.aspx?id="+ Eval("ID") %>' Text='<%# Eval("Title") %>' runat="server">HyperLink</asp:HyperLink>
                    </td>
                    <td style="width:15%;">
                        ￥<asp:Label ID="Label1" runat="server" Text='<%# Eval("Price")%>'></asp:Label>
                    </td>
                    <td style="width:15%;">
                        <asp:Button ID="bntCut" Width="20" CommandArgument='<%# Eval("ID") %>' CommandName="Cut" runat="server" Text="-" />
                        <asp:TextBox ID="txtCount" Width="20" Text='<%# Eval("Count") %>' runat="server"></asp:TextBox>
                        <asp:Button ID="bntAdd" Width="20" CommandArgument='<%# Eval("ID") %>'  CommandName="Add" runat="server" Text="+" />
                    </td>
                    <td style="width:15%;">
                        ￥<asp:Label ID="txtPrice" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="width:15%;">
                        <asp:Button ID="Button1" runat="server" OnClientClick="return confirm('删除选中的数据？');" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' Text="删除" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <table style="width:100%; text-align:center;">
                <tr>
                    <td style="width:10%;">
                        <asp:Image ID="Image1" runat="server" Width="60" Height="120" ImageUrl='<%# "~/Image/BookCover/"+Eval("ISBN")+".jpg" %>' />
                    </td>
                    <td style="width:30%;">
                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/BookDetail.aspx?id="+ Eval("ID") %>' Text='<%# Eval("Title") %>' runat="server">HyperLink</asp:HyperLink>
                    </td>
                    <td style="width:15%;">
                        ￥<asp:Label ID="Label1" runat="server" Text='<%# Eval("Price")%>'></asp:Label>
                    </td>
                    <td style="width:15%;">
                        <asp:Button ID="bntCut" Width="20" CommandArgument='<%# Eval("ID") %>' CommandName="Cut" runat="server" Text="-" />
                        <asp:TextBox ID="txtCount" Width="20" Text='<%# Eval("Count") %>' runat="server"></asp:TextBox>
                        <asp:Button ID="bntAdd" Width="20" CommandArgument='<%# Eval("ID") %>'  CommandName="Add" runat="server" Text="+" />
                    </td>
                    <td style="width:15%;">
                        ￥<asp:Label ID="txtPrice" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="width:15%;">
                        <asp:Button ID="Button1" runat="server" OnClientClick="return confirm('删除选中的数据？');" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' Text="删除" />
                    </td>
                </tr>
            </table>
        </AlternatingItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:Repeater>
    <div style="text-align:center;">
        <asp:Button ID="btnProv" runat="server" Text="上一页" />
        <asp:Label ID="lblIndex" runat="server"></asp:Label>/
        <asp:Label ID="lblToCount" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnNext" runat="server" Text="下一页" />
    </div>
    <div style="text-align:right;">
        <asp:Button ID="Button2" runat="server" Text="结算" Width="150px" OnClick="Button2_Click" />
        
        <h1>总价：<asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></h1>
        <br />
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
