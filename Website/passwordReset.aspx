<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="passwordReset.aspx.vb" Inherits="passwordReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <link type="text/css" rel="Stylesheet" href="css/passwordReset.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">   
    <div class="container-fluid">                        
        <div id="password-form" class="form form--centered fade collapse show">
            <div class="form__header">
                <asp:Literal runat="server" Text="<%$ Resources:passwordReset, CreateNewPassword %>"></asp:Literal>
            </div>    
                     
            <div id="password-info" class="form__alert alert alert-info fade collapse show" role="alert">
                <asp:Literal runat="server" Text="<%$ Resources:passwordReset, PasswordRequirements %>"></asp:Literal>
            </div>

            <div id="password-error" class="form__alert alert alert-danger fade collapse" role="alert"></div>

            <div id="password-success" class="form__alert alert alert-success fade collapse" role="alert">
                <asp:Literal runat="server" Text="<%$ Resources:passwordReset, PasswordSaved %>"></asp:Literal>
                <br/>
                <asp:HyperLink runat="server" NavigateUrl="/login.aspx" class="alert-link" Text="<%$ Resources:passwordReset, ClickToLogin %>"></asp:HyperLink>
            </div>

            <div class="form-group collapse show">
                <input type="password" id="txtNewPassword" runat="server" class="form-control" placeholder="<%$ Resources:passwordReset, NewPassword %>" maxlength="50" tabindex="0" autofocus>
            </div>
            <div class="form-group collapse show">
                <input type="password" id="txtConfirmPassword" runat="server" class="form-control" placeholder="<%$ Resources:passwordReset, ConfirmNewPassword %>" maxlength="50" tabindex="0">
            </div>
            <div class="form-group collapse show">
                <asp:HyperLink ID="btnResetPassword" runat="server" class="btn btn-primary text-white form__button" Text="<%$ Resources:passwordReset, CreateNewPassword %>" tabindex="0"></asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
    <script type="text/javascript" src="js/passwordReset.min.js"></script>
</asp:Content>