<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BikeFactory1.WebUI._default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../lib/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="../Site.css" rel="stylesheet" />
    <script src="../lib/bootstrap/js/bootstrap.js"></script>
    <title>Home - Bike Factory</title>
     <link rel="icon" type="image/x-icon" href="./img/icon.png" />
</head>
<body>  
    <div id="welcome" class="fixed-top">       
    <form id="Bike" style="width:100%" runat="server" class="hero-container">
        <div style="width:100%; text-align:center" >
            <center>
                <asp:Image class="logo" runat="server" src="./img/bikeLogo2.png" Width="150px" />
            </center>
            <br />
            <h1>Welcome to BIKE FACTORY</h1>
            <br />
            <a  href="Management/ManageBikes.aspx" class="btn-get-started scrollto">Click here to Start</a>
        </div>
    </form>
    </div>
    
</body>
</html>
