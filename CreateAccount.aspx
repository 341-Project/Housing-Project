<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="Housing_Project.About" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <br />
    First Name:<br />
    <asp:TextBox ID="fName" runat="server"></asp:TextBox>
    <br />
    Last Name:<br />
    <asp:TextBox ID="lName" runat="server"></asp:TextBox>
    <br />
    Phone Number:<p>
        <asp:TextBox ID="phone" runat="server"></asp:TextBox>
    </p>
    <p>
        Email:</p>
    <p>
        <asp:TextBox ID="email" runat="server"></asp:TextBox>
    </p>
    <p>
        Address:</p>
    <p>
        <asp:TextBox ID="address" runat="server" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
    </p>
    <p>
        Username:</p>
    <p>
        <asp:TextBox ID="user" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
    </p>
    <p>
        Password:</p>
    <p>
        <asp:TextBox ID="password" runat="server"></asp:TextBox>
    </p>
    <p>
        Income:</p>
    <p>
        <asp:TextBox ID="income" runat="server" OnTextChanged="TextBox8_TextChanged"></asp:TextBox>
    </p>
<p>
        Householdsize:</p>
<p>
        <asp:TextBox ID="household" runat="server" OnTextChanged="TextBox9_TextChanged"></asp:TextBox>
    </p>
<p>
        Counties:</p>
<p>
        <asp:CheckBoxList ID="counties" runat="server" Height="41px" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
            <asp:ListItem>Winnebago</asp:ListItem>
            <asp:ListItem>Outagamie</asp:ListItem>
        </asp:CheckBoxList>
    </p>
<p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create a User" />
    </p>
    <p>
        <asp:Button ID="Button2" runat="server"  OnClick="Button1_Click" Text="Create a Property Owner" />
    </p>
<p>
        <asp:TextBox ID="results" runat="server" Height="160px" OnTextChanged="TextBox1_TextChanged" Width="213px">hello</asp:TextBox>
    </p>
</asp:Content>
