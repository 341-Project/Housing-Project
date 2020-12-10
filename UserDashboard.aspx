<%@ Page Title="User Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="Housing_Project.UserDashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="profile">
        <h1>User Information</h1>
        <asp:Table ID="UserInfo" runat="server" Height="424px" Width="347px">
            <asp:TableRow ID="Username" runat="server">
                <asp:TableCell>Username</asp:TableCell>
                <asp:TableCell><textarea id="User"></textarea></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="Name" runat="server">
                <asp:TableCell>Name</asp:TableCell>
                <asp:TableCell><textarea id="User"></textarea></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="Email" runat="server">
                <asp:TableCell>Email</asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="Phone" runat="server">
                <asp:TableCell>Phone</asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="Income" runat="server">
                <asp:TableCell>Income</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="Household" runat="server">
                <asp:TableCell>Household Size</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="County1" runat="server">
                <asp:TableCell>County 1</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="County2" runat="server">
                <asp:TableCell>County 2</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="County3" runat="server">
                <asp:TableCell>County 3</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    </div>

    <p>
        <asp:Button ID="Update" runat="server" OnClick="Update_Click" Text="Update Account" />
    </p>

</asp:Content>
