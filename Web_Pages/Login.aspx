<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Housing_Project.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="login">
        <h2>User Login</h2>
        <br>
        <br>
        <div class="user_login">
            <div id="login_form" runat="server">
                Username:<br> 
                <asp:TextBox ID="username" runat="server"></asp:TextBox>
                <br>
                <br>
                Password:<br> 
                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                <br>
                <br>
                &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" Width="148px" />
            </div>
        </div>    
    </section>
</asp:Content>