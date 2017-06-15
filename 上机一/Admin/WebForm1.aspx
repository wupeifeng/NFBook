<%@ Page Title="" Language="C#" MasterPageFile="~/MyFilmMsater.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="上机一.Admin.WebForm1" %>


<%@ Register src="WinForn1.ascx" tagname="WinForn1" tagprefix="uc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    
                    <br />
                    <uc1:WinForn1 ID="WinForn11" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
