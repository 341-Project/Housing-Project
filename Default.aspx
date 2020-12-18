<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Housing_Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center text-purple">THE HIVE - Affordable Housing</h1><br>
        <p style="font: bold 20px gothic;">In the world of Low Income Housing, the application process is a long and tedious one. This site's goal is to
        make low income housing easily available to the millions of Americans that are in desperate need of it. Our goal is to provide a simple and easy solution for
        individuals and families to find housing they can afford.</p>
        <br>
        <p><a href="/Web_Pages/Search.aspx" class="btn btn-dark btn-lg btn-block">Search for Housing</a></p>
        <p><a href="/Web_Pages/CreateAccount.aspx" class="btn btn-dark btn-lg btn-block">Create An Account</a></p>
    </div>
</asp:Content>
