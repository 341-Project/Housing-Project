<%@ Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="Housing_Project.UserDashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>User Dashboard</h2>
    
    
    <div id="profile"></div>

    <p>
        <asp:Button ID="Update" runat="server" OnClick="Update_Click" Text="Update Account" />
    </p>

</asp:Content>