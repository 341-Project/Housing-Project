<%@ Page Title ="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Housing_Project.Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <br />
        <br />
        <br />
        Household Size<br />
        <asp:TextBox ID="household" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <br />
        Gross Income<br />
        <asp:TextBox ID="income" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Submit" />
        <br />
        <br />
        <br />
        <asp:TextBox ID="results" runat="server" OnTextChanged="results_TextChanged"></asp:TextBox>
    </div>
</asp:Content>
