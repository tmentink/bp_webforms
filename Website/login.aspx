<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <link type="text/css" rel="Stylesheet" href="css/login.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">   
    <div class="container-fluid">                        
        
        <!-- Login Form
        ===========================================-->
        <div id="login-form" class="form form--centered fade collapse show">
            <div class="form__circle"><i class="fa fa-user"></i></div>          
            <div class="form__header">
                <asp:Literal runat="server" Text="<%$ Resources:login, LoginToWebsite %>"></asp:Literal>
            </div>           
            
            <div id="login-error" class="form__alert alert alert-danger fade collapse" role="alert"></div>

            <div class="form-group">
                <input type="text" id="txtUsername" runat="server" class="form-control" placeholder="<%$ Resources:login, UsernameOrEmail %>" maxlength="125" tabindex="0" autofocus>
            </div>
            <div class="form-group">
                <input type="password" id="txtPassword" runat="server" class="form-control" placeholder="<%$ Resources:login, Password %>" maxlength="50" tabindex="0">
            </div>
            <div class="form-group">
                <asp:HyperLink ID="btnLogin" runat="server" class="btn btn-primary text-white form__button" tabindex="0" Text="<%$ Resources:login, Login %>"></asp:HyperLink>
            </div>

            <asp:HyperLink ID="btnForgotPassword" runat="server" class="form__link text-muted" tabindex="0" Text="<%$ Resources:login, ForgotPassword %>"></asp:HyperLink>
        </div>


        <!-- Reset Form
        ===========================================-->
        <div id="reset-form" class="form form--centered fade collapse">                     
            <div class="form__header">
                <asp:Literal runat="server" Text="<%$ Resources:login, ResetPassword %>"></asp:Literal>
            </div>
            
            <div id="reset-msg" class="form__alert alert alert-success fade collapse" role="alert">
                <asp:Literal runat="server" Text="<%$ Resources:login, ResetEmailSent %>"></asp:Literal>
            </div>

            <div id="reset-error" class="form__alert alert alert-danger fade collapse" role="alert">
                <asp:Literal runat="server" Text="<%$ Resources:login, CantAccessServer %>"></asp:Literal>
            </div>

            <div class="form-group">
                <input type="text" runat="server" id="txtEmail" class="form-control" placeholder="<%$ Resources:login, UsernameOrEmail %>" maxlength="125" tabindex="0">
            </div>
            <div class="form-group">
                <asp:HyperLink ID="btnReset" runat="server" class="btn btn-primary text-white form__button" tabindex="0" Text="<%$ Resources:login, SendResetEmail %>"></asp:HyperLink>
            </div>

            <asp:HyperLink ID="btnBackToLogin" runat="server" class="form__link text-muted" tabindex="0" Text="<%$ Resources:login, BackToLogin %>"></asp:HyperLink>            
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
    <script type="text/javascript" src="js/login.min.js"></script>
</asp:Content>

