<%@ Page Title="" Language="C#" MasterPageFile="~/CommonPages.Master" AutoEventWireup="true" CodeBehind="ConfirmNewAccount.aspx.cs" Inherits="e_Portfolio_System.ParentPackage.ConfirmNewAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 135px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        CONFIRM NEW ACCOUNT</p>
    <p>
        Your account with the details below has been successfully created.</p>
    <table class="w-100">
        <tr>
            <td class="auto-style1">Name:</td>
            <td>
                <asp:Label ID="lblParentName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Email Address:</td>
            <td>
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
