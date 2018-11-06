<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommonPagesNav.ascx.cs" Inherits="e_Portfolio_System.CommonPages1" %>
<style>
    nav {
        font-size: 14px;
        /*height: 90px;*/
        margin-top: 10px;
    }

    nav a:first-child {
        margin-left: 30px;
    }

    #firstNavItem {
        margin-left: 30px;
    }

    #portfolioNavbar a {
        display: inline-block;
        padding: 25px 10px 0 20px;
        text-transform: uppercase;
        text-decoration: none;
        color: #7c7c7c;
        font-weight: 500;
        border-left: 1.5px solid #7c7c7c;
        cursor: pointer;
    }

    #portfolioNavbar a:hover {
        color: #6f1e7f;
        border-left: 1.5px solid #6f1e7f;
    }

    #loginBtn {
        margin-right: 15px;
    }
    
    #registerBtn {
        margin-right: 50px;
    }

    /*#loginBtn .on-page {
        color: #6f1e7f;
        border-left: 1.5px solid #6f1e7f;
    }*/

    /*nav.change {
        background: #222;
        transition: all ease .5s;
    }*/
</style>
<%--<script>
    if ($(location).attr('pathname') == 'CommonPages/Login.aspx') {
        $('#loginBtn').addClass('on-page');
    }
    else {
        $('#loginBtn').removeClass('on-page');
    }
</script>--%>

<nav class="navbar navbar-expand-md navbar-light">
    <!-- Brand -->
	<a class="navbar-brand" href="CommonPageHome.aspx">
         <img src="/Images/Assets/ict_logo.png" alt="ICT Logo" width="55"/>
	</a>
	
    <!-- Toggle/collapsible Button, also known as hamburger button -->
    <button class="navbar-toggler" type="button"
        data-toggle="collapse" data-target="#portfolioNavbar">
        <span class="navbar-toggler-icon"></span>
    </button>

	  <!-- Links in the navbar, displayed as drop-down list when collapsed -->
    <div class="collapse navbar-collapse" id="portfolioNavbar">
	<!-- Links that are aligned to the left, mr-auto: right margin auto-adjusted -->
	    <ul class="navbar-nav mr-auto">
            <li class="nav-item">
		        <a class="nav-link" href="About.aspx" id="firstNavItem">About ICT</a>
		    </li>
            <li class="nav-item">
		        <a class="nav-link" href="StudentPortfolio.aspx">Students' Portfolios</a>
		    </li>
            <li class="nav-item">
		        <a class="nav-link" href="DirectorMessage.aspx">Directors Message</a>
		    </li>
        </ul>

         <!-- Links that are aligned to the right, ml-auto: left margin auto-adjusted -->
        <ul class="navbar-nav ml-auto">
            <li class="nav-item">
		        <a class="nav-link" href="Login.aspx" id="loginBtn">Login</a>
            </li>
            <li class="nav-item">
		        <a class="nav-link" href="RegisterParent.aspx" id="registerBtn">Register</a>
            </li>
        </ul>
	</div>
</nav> 