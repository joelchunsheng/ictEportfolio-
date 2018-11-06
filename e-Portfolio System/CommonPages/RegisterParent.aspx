<%@ Page Title="" Language="C#" MasterPageFile="~/CommonPages.Master" AutoEventWireup="true" CodeBehind="RegisterParent.aspx.cs" Inherits="e_Portfolio_System.ParentPackage.RegisterParent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {}
        .auto-style2 {
            width: 169px;
        }
        .auto-style3 {
            color: #FF3300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style1" colspan="2">CREATE NEW ACCOUNT</td>
        </tr>
        <tr>
            <td class="auto-style2">FULL NAME:&nbsp;</td>
            <td>
                <asp:TextBox ID="txtParentName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtParentName" CssClass="auto-style3" Display="Dynamic" ErrorMessage="*Please enter your name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">EMAIL ADDRESS:</td>
            <td>
                <asp:TextBox ID="txtParentEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtParentEmail" CssClass="auto-style3" Display="Dynamic" ErrorMessage="*Please enter your email"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtParentEmail" CssClass="auto-style3" Display="Dynamic" ErrorMessage="*Please enter a valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="cuvEmail" runat="server" ControlToValidate="txtParentEmail" CssClass="auto-style3" Display="Dynamic" ErrorMessage="*An account with this email already exists" OnServerValidate="cuvEmail_ServerValidate">*An account with this email already exists</asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">PASSWORD:</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" CssClass="auto-style3" Display="Dynamic" ErrorMessage="*Please enter your preferred password"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexPassword" runat="server" ControlToValidate="txtPassword" CssClass="auto-style3" Display="Dynamic" ErrorMessage="*Please ensure your password has at least 1 uppercase letter, 1 lowercase letter, 1 number or special character, and at least 8 characters in length." ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtConfirmPassword" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="*Passwords do not match"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">CONFIRM PASSWORD:</td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" CssClass="auto-style3" Display="Dynamic" ErrorMessage="*Please re-enter your preferred password"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" CssClass="auto-style3" Display="Dynamic" ErrorMessage="*Passwords do not match"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="text-left">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
