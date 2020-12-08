<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Housing_Project.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="login">
        <h2>Login</h2>
        <div class="user_login">
            <div id="login_form" runat="server">
                Username: -<asp:TextBox ID="username" runat="server"></asp:TextBox>
                <br>
                Password: -<asp:TextBox ID="password" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" Width="148px" />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
        </div>    
    </section>
</asp:Content>