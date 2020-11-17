<%@ Page Title ="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Housing_Project.Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <br />
        <br />
        <br />
        Household Size<br />
        <asp:TextBox ID="household" runat="server" OnTextChanged="TextBox1_TextChanged" TextMode="Number"></asp:TextBox>
        <br />
        <br />
        Gross Income<br />
        <asp:TextBox ID="income" runat="server" OnTextChanged="TextBox2_TextChanged" TextMode="Number"></asp:TextBox>
        <br />
        <asp:CheckBoxList ID="counties" runat="server" Width="142px">
            <asp:ListItem>Winnebago</asp:ListItem>
            <asp:ListItem>Outagamie</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Submit" />
        <br />
        <br />

        <asp:TextBox ID="results" runat="server" Height="173px" OnTextChanged="results_TextChanged" Width="249px"></asp:TextBox>
</div>
</asp:Content>