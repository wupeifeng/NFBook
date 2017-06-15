<%@ Page Title="" Language="C#" MasterPageFile="~/MyFilmMsater.Master" AutoEventWireup="true" CodeBehind="PublisherManage.aspx.cs" Inherits="上机一.Admin.PublisherManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="text-align: left">
                <asp:TextBox ID="txtSearch" CssClass="txt" Width="200" runat="server"></asp:TextBox>
                <asp:LinkButton ID="btnSearch" runat="server"><img src="../Image/magnifier-left.png" style="border:0px;"/>查询</asp:LinkButton>
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click"/>
                <asp:Button ID="btnDeletaAll" runat="server" Text="删除"  />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ListView ID="lstShowData" runat="server" DataKeyNames="ID" OnItemEditing="lstShowData_ItemEditing" OnItemCanceling="lstShowData_ItemCanceling" OnItemUpdating="lstShowData_ItemUpdating" OnItemDeleting="lstShowData_ItemDeleting" >
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFF8DC;">
                            <td align="left">
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </td>
                            <td>
                                <%# Eval("PublishName") %>                               </td>
                            <td align="right">
                                <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server">编辑</asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" CommandName="Delete" OnClientClick="return confirm('删除选中的数据？');" runat="server">删除</asp:LinkButton>

                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #DCDCDC; color: #000000;">
                            <td align="left">
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </td>
                            <td>
                                <%# Eval("PublishName") %>                       
                            </td>
                            <td align="right">
                                <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server">编辑</asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" CommandName="Delete" OnClientClick="return confirm('删除选中的数据？');" runat="server">删除</asp:LinkButton>

                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table style="width: 100%; background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr style="background-color: #DCDCDC; color: #000000;">
                                <td align="left" style="width: 20px;">
                                    <asp:CheckBox ID="chkSelectAll" AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged" runat="server" /></td>
                                <td align="center">出版社名称</td>
                                <td align="right" style="width: 100px"></td>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <EditItemTemplate>
                        <tr>
                            <td>                                
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("PublishName") %>'></asp:TextBox>                      
                            </td>
                            <td align="right">
                                <asp:LinkButton ID="btnSave" CommandName="Update" runat="server">保存</asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" CommandName="Cancel" runat="server">取消</asp:LinkButton>
                            </td>
                        </tr>
                    </EditItemTemplate>
                </asp:ListView>
                
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
