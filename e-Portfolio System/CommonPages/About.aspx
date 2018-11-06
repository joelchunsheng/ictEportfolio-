<%@ Page Title="" Language="C#" MasterPageFile="~/CommonPages.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="e_Portfolio_System.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
            color: #800080;
            font-style: italic;
            font-weight: bold;
            text-align: center;
        }
        .auto-style2 {
            height: 38px;
            text-align: center;
        }
        .auto-style3 {
            height: 38px;
            width: 294px;
            text-align: right;
        }
        .auto-style4 {
            width: 294px;
        }
        .auto-style6 {
            font-size: x-large;
            color: #800080;
            font-style: italic;
            font-weight: bold;
        }
        .auto-style7 {
            font-size: large;
        }
        .auto-style8 {
            font-size: large;
            color: #800080;
            font-weight: bold;
        }
        .auto-style9 {
            color: #800080;
            font-weight: bold;
        }
        .auto-style10 {
            height: 38px;
            text-align: center;
            width: 1159px;
        }
        .auto-style11 {
            width: 1159px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style1" colspan="3">About ICT</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Assets/ict_logo.png" Width="200px" />
            &nbsp;</td>
            <td class="auto-style10"><span style="color: rgb(34, 34, 34); font-family: &quot;SegoeUI Regular&quot;; font-size: 18px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.85); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Set up in 1982, the School of InfoComm Technology (ICT) is highly recognised for its broad-based, holistic IT education. Our students are trained to provide highly creative solutions for businesses and enterprises.</span></td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="3"><span class="auto-style6">Contact Us</span><br class="auto-style6" />
                <span class="auto-style8">School of InfoComm Technology</span><span class="auto-style9"><br class="auto-style7" />
                <span class="auto-style7">Ngee Ann Polytechnic<br />
                </span></span>
                <br />
                Block 31, Level 8, 535 Clementi Road Singapore 599 489<br />
                Telephone: (+65) 6460 6868</td>
        </tr>
    </table>
</asp:Content>
