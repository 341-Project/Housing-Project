document.getElementById("logout").addEventListener("click", logout);


function find() {
    let login = document.getElementById("displayLogin");
    let create = document.getElementById("displayLogin");
    let dashboard = document.getElementById("displayLogin");
    let logout = document.getElementById("displayLogin");
}

function logout() {
    Session.Abandon();
    Session.Clear();
    Response.Cookies.Clear();
    Response.Redirect("/Default.aspx");
}