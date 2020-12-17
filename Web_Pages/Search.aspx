<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Housing_Project.Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 169px; height: 794px; float: left;">
        <br />
        <br />
        <br />
        Household Size<br />
        <asp:TextBox ID="household" runat="server" OnTextChanged="TextBox1_TextChanged" TextMode="Number" min="1" max="9" required></asp:TextBox>
        <br />
        <br />
        Gross Income<br />
        <asp:TextBox ID="income" runat="server" OnTextChanged="TextBox2_TextChanged" TextMode="Number" min="1" required></asp:TextBox>
        <br />
        <br />
        County #1<br />
        <asp:DropDownList ID="County1" runat="server" Selected="true" Value="1" OnSelectedIndexChanged="County1_SelectedIndexChanged" Width="118px" required>
            <asp:ListItem Value="null">None</asp:ListItem>
            <asp:ListItem>Brown</asp:ListItem>
            <asp:ListItem>Calumet</asp:ListItem>
            <asp:ListItem>Chippewa</asp:ListItem>
            <asp:ListItem>Columbia</asp:ListItem>
            <asp:ListItem>Dane</asp:ListItem>
            <asp:ListItem>Dodge</asp:ListItem>
            <asp:ListItem>Door</asp:ListItem>
            <asp:ListItem>Douglas</asp:ListItem>
            <asp:ListItem>Dunn</asp:ListItem>
            <asp:ListItem>Eau Claire</asp:ListItem>
            <asp:ListItem>Fond du Lac</asp:ListItem>
            <asp:ListItem>Grant</asp:ListItem>
            <asp:ListItem>Green</asp:ListItem>
            <asp:ListItem>Green Lake</asp:ListItem>
            <asp:ListItem>Iowa</asp:ListItem>
            <asp:ListItem>Jefferson</asp:ListItem>
            <asp:ListItem>Kenosha</asp:ListItem>
            <asp:ListItem>Kewaunee</asp:ListItem>
            <asp:ListItem>La Crosse</asp:ListItem>
            <asp:ListItem>Lafayette</asp:ListItem>
            <asp:ListItem>Lincoln</asp:ListItem>
            <asp:ListItem>Manitowoc</asp:ListItem>
            <asp:ListItem>Marathon</asp:ListItem>
            <asp:ListItem>Milwaukee</asp:ListItem>
            <asp:ListItem>Monroe</asp:ListItem>
            <asp:ListItem>Oconto</asp:ListItem>
            <asp:ListItem>Outagamie</asp:ListItem>
            <asp:ListItem>Ozaukee</asp:ListItem>
            <asp:ListItem>Pepin</asp:ListItem>
            <asp:ListItem>Pierce</asp:ListItem>
            <asp:ListItem>Polk</asp:ListItem>
            <asp:ListItem>Portage</asp:ListItem>
            <asp:ListItem>Racine</asp:ListItem>
            <asp:ListItem>Rock</asp:ListItem>
            <asp:ListItem>Sauk</asp:ListItem>
            <asp:ListItem>Sheboygan</asp:ListItem>
            <asp:ListItem>St. Croix</asp:ListItem>
            <asp:ListItem>Trempealeau</asp:ListItem>
            <asp:ListItem>Walworth</asp:ListItem>
            <asp:ListItem>Washington</asp:ListItem>
            <asp:ListItem>Waukesha</asp:ListItem>
            <asp:ListItem>Waupaca</asp:ListItem>
            <asp:ListItem>Winnebago</asp:ListItem>
            <asp:ListItem>Wood</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        County #2<br />
        <asp:DropDownList ID="County2" runat="server" Selected="tue" Value="1" OnSelectedIndexChanged="County2_SelectedIndexChanged" Width="118px">
            <asp:ListItem Value="null">None</asp:ListItem>
            <asp:ListItem>Brown</asp:ListItem>
            <asp:ListItem>Calumet</asp:ListItem>
            <asp:ListItem>Chippewa</asp:ListItem>
            <asp:ListItem>Columbia</asp:ListItem>
            <asp:ListItem>Dane</asp:ListItem>
            <asp:ListItem>Dodge</asp:ListItem>
            <asp:ListItem>Door</asp:ListItem>
            <asp:ListItem>Douglas</asp:ListItem>
            <asp:ListItem>Dunn</asp:ListItem>
            <asp:ListItem>Eau Claire</asp:ListItem>
            <asp:ListItem>Fond du Lac</asp:ListItem>
            <asp:ListItem>Grant</asp:ListItem>
            <asp:ListItem>Green</asp:ListItem>
            <asp:ListItem>Green Lake</asp:ListItem>
            <asp:ListItem>Iowa</asp:ListItem>
            <asp:ListItem>Jefferson</asp:ListItem>
            <asp:ListItem>Kenosha</asp:ListItem>
            <asp:ListItem>Kewaunee</asp:ListItem>
            <asp:ListItem>La Crosse</asp:ListItem>
            <asp:ListItem>Lafayette</asp:ListItem>
            <asp:ListItem>Lincoln</asp:ListItem>
            <asp:ListItem>Manitowoc</asp:ListItem>
            <asp:ListItem>Marathon</asp:ListItem>
            <asp:ListItem>Milwaukee</asp:ListItem>
            <asp:ListItem>Monroe</asp:ListItem>
            <asp:ListItem>Oconto</asp:ListItem>
            <asp:ListItem>Outagamie</asp:ListItem>
            <asp:ListItem>Ozaukee</asp:ListItem>
            <asp:ListItem>Pepin</asp:ListItem>
            <asp:ListItem>Pierce</asp:ListItem>
            <asp:ListItem>Polk</asp:ListItem>
            <asp:ListItem>Portage</asp:ListItem>
            <asp:ListItem>Racine</asp:ListItem>
            <asp:ListItem>Rock</asp:ListItem>
            <asp:ListItem>Sauk</asp:ListItem>
            <asp:ListItem>Sheboygan</asp:ListItem>
            <asp:ListItem>St. Croix</asp:ListItem>
            <asp:ListItem>Trempealeau</asp:ListItem>
            <asp:ListItem>Walworth</asp:ListItem>
            <asp:ListItem>Washington</asp:ListItem>
            <asp:ListItem>Waukesha</asp:ListItem>
            <asp:ListItem>Waupaca</asp:ListItem>
            <asp:ListItem>Winnebago</asp:ListItem>
            <asp:ListItem>Wood</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        County #3<br />
        <asp:DropDownList ID="County3" runat="server" Selected="true" Value="1" OnSelectedIndexChanged="County3_SelectedIndexChanged" Width="118px">
            <asp:ListItem Value="null">None</asp:ListItem>
            <asp:ListItem>Brown</asp:ListItem>
            <asp:ListItem>Calumet</asp:ListItem>
            <asp:ListItem>Chippewa</asp:ListItem>
            <asp:ListItem>Columbia</asp:ListItem>
            <asp:ListItem>Dane</asp:ListItem>
            <asp:ListItem>Dodge</asp:ListItem>
            <asp:ListItem>Door</asp:ListItem>
            <asp:ListItem>Douglas</asp:ListItem>
            <asp:ListItem>Dunn</asp:ListItem>
            <asp:ListItem>Eau Claire</asp:ListItem>
            <asp:ListItem>Fond du Lac</asp:ListItem>
            <asp:ListItem>Grant</asp:ListItem>
            <asp:ListItem>Green</asp:ListItem>
            <asp:ListItem>Green Lake</asp:ListItem>
            <asp:ListItem>Iowa</asp:ListItem>
            <asp:ListItem>Jefferson</asp:ListItem>
            <asp:ListItem>Kenosha</asp:ListItem>
            <asp:ListItem>Kewaunee</asp:ListItem>
            <asp:ListItem>La Crosse</asp:ListItem>
            <asp:ListItem>Lafayette</asp:ListItem>
            <asp:ListItem>Lincoln</asp:ListItem>
            <asp:ListItem>Manitowoc</asp:ListItem>
            <asp:ListItem>Marathon</asp:ListItem>
            <asp:ListItem>Milwaukee</asp:ListItem>
            <asp:ListItem>Monroe</asp:ListItem>
            <asp:ListItem>Oconto</asp:ListItem>
            <asp:ListItem>Outagamie</asp:ListItem>
            <asp:ListItem>Ozaukee</asp:ListItem>
            <asp:ListItem>Pepin</asp:ListItem>
            <asp:ListItem>Pierce</asp:ListItem>
            <asp:ListItem>Polk</asp:ListItem>
            <asp:ListItem>Portage</asp:ListItem>
            <asp:ListItem>Racine</asp:ListItem>
            <asp:ListItem>Rock</asp:ListItem>
            <asp:ListItem>Sauk</asp:ListItem>
            <asp:ListItem>Sheboygan</asp:ListItem>
            <asp:ListItem>St. Croix</asp:ListItem>
            <asp:ListItem>Trempealeau</asp:ListItem>
            <asp:ListItem>Walworth</asp:ListItem>
            <asp:ListItem>Washington</asp:ListItem>
            <asp:ListItem>Waukesha</asp:ListItem>
            <asp:ListItem>Waupaca</asp:ListItem>
            <asp:ListItem>Winnebago</asp:ListItem>
            <asp:ListItem>Wood</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Submit" class="btn btn-dark" runat="server" OnClick="Submit_Click" Text="Submit" />
        <br />
        <br />
        <br />

        <br />

        <div id="DIV1" runat="server" style="width: 1001px; height: 467px; float: left;"></div>

    </div>





    </div>

    



    </div>

    



</asp:Content>
