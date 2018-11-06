<%@ Page Title="" Language="C#" MasterPageFile="~/CommonPages.Master" AutoEventWireup="true" CodeBehind="CommonPageHome.aspx.cs" Inherits="e_Portfolio_System.CommonPageHome"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #container {
            margin: 0 auto;
            padding: 0;
            height: calc(100vh - 90px);
        }

        .bg {
            background-size: cover;
            background-repeat: no-repeat;
            max-height: 100vh;
        }

        #topContent {
            text-align: center;
            position: absolute;
            top: 48%;
            left: 70%;
            transform: translate(-50%, -50%);
            text-align: center;
            color: #fff;
        }

        h1 {
            color: #fff;
            font-size: 45px;
            margin-bottom: 10px;
            animation: fadeIn 5s;
            width: 1000px;
        }

        p {
            color: #fff;
            font-size: 21px;
            letter-spacing: 4px;
            font-weight: 400;
            margin-top: -8px;
        }

        @keyframes fadeIn {
            from {
                opacity: 0;
            }

            to {
                opacity: 1;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="container">
        <asp:Image ID="imgBackground" runat="server" ImageUrl="~/Images/Assets/np_bg.jpg" CssClass="bg"/>
        <div id="topContent">
            <h1>ngee ann polytechnic</h1>
            <p>school of infocomm technology</p>
        </div>
    </div>
</asp:Content>