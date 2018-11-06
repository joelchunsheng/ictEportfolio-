<%@ Page Title="" Language="C#" MasterPageFile="~/CommonPages.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="e_Portfolio_System.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #loginContainer {
            margin: 0 auto;
            text-align: center;
            width: 500px;
            position: relative;
            top: 20%;  
            height: calc(100vh - 91px);
        }
        
        .radioButton {
            margin: 3px;
        }

        .radioButton label {
            margin-left: 3px;
            font-weight: 500;
        }

        .btnLogin {
            width: 300px;
            height: 47px;
            background-color: #6f1e7f;
            color: #fff;
            border: none;
            font-weight: 500;
        }

        .textBox:first-child {
            margin-top: -5px;
        }

        .textBox {
            height: 45px;
            font-size: 1em;
            margin-top: 10px;
            border: none;
            padding: 10px 0;
            padding-bottom: 0px;
            border-bottom: solid 1px #6f1e7f;
            transition: all 0.3s cubic-bezier(0.64, 0.09, 0.08, 1);
            background: linear-gradient(to bottom, rgba(255, 255, 255, 0) 98%, #6f1e7f 4%);
            background-position: -320px 0;
            background-size: 310px 100%;
            background-repeat: no-repeat;
            color: #333;
            font-weight: 500;
        }

        .textBox::-webkit-input-placeholder {
            font-size: 14px;
        }

        .textBox:focus {
            box-shadow: none;
            outline: none;
            background-position: 0 0;
            font-weight: 500;
            border-bottom: solid 2px #6f1e7f;
        }       

        .textBox:focus::-webkit-input-placeholder {
            font-weight: 500;
            color: #333;
            font-size: 0.85em;
            -webkit-transform: translateY(-22px);
                    transform: translateY(-22px);
            visibility: visible;
        }

        .lblMessage {
            font-weight: 400;
        }

        .textBox:-webkit-autofill {
            -webkit-box-shadow: 0 0 0 30px white inset;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="loginContainer">
        <p>
            <asp:ImageButton ID="imgMenteePortfolios" runat="server" Width="80px" ImageUrl="~/Images/Assets/ict_logo.png" PostBackUrl="~/CommonPageHome.aspx"/>
        </p>
        <p>
            <%--<label for="user" class="animated-label">EMAIL ADDRESS</label>--%>
            <asp:TextBox ID="txtId" runat="server" placeholder="EMAIL ADDRESS" Width="300px" CssClass="textBox"></asp:TextBox><br />
            <%--<label for="pass" class="animated-label">PASSWORD</label>--%>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="PASSWORD" Width="300px" CssClass="textBox"></asp:TextBox>
        </p>
        <p>
            <asp:RadioButton ID="rdoStudent" runat="server" Checked="True" GroupName="login" Text="student" CssClass="radioButton"/>
            <asp:RadioButton ID="rdoMentor" runat="server" GroupName="login" Text="mentor" CssClass="radioButton"/>
            <asp:RadioButton ID="rdoParent" runat="server" GroupName="login" Text="parent" CssClass="radioButton"/>
            <asp:RadioButton ID="rdoSA" runat="server" GroupName="login" Text="admin" CssClass="radioButton"/>
        </p>
        <p><asp:Button ID="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click" CssClass="btnLogin"/></p>
        <p><asp:Label ID="lblMessage" runat="server" style="color: #FF0000" CssClass="lblMessage"></asp:Label></p>

    </div>


    <%--<table class="w-100">
    <tr>
        <td class="auto-style4">Login ID:</td>
        <td class="auto-style5">
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">Password:</td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1"></td>
        <td>
            <asp:RadioButton ID="rdoStudent" runat="server" Checked="True" GroupName="login" Text="Student " />
            <asp:RadioButton ID="rdoMentor" runat="server" GroupName="login" Text="Mentor" />
            <asp:RadioButton ID="rdoParent" runat="server" GroupName="login" Text="Parent" />
            <asp:RadioButton ID="rdoSA" runat="server" GroupName="login" Text="System Administrator " />
        </td>
    </tr>
    <tr>
        <td class="auto-style2"></td>
        <td class="auto-style3">
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Label ID="lblMessage" runat="server" style="color: #FF0000"></asp:Label>
        </td>
    </tr>
</table>--%>
</asp:Content>
