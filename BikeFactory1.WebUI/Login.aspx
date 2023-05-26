<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BikeFactory1.WebUI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="icon" type="image/x-icon" href="./img/icon.png" />
    <link href="../lib/bootstrap/css/bootstrap.css" rel="stylesheet" />
     <link href="../lib/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet" />
    <link href="../Site.css" rel="stylesheet" />
    <script src="../lib/bootstrap/js/bootstrap.js"></script>
    
    <style>
        h1{
              margin: 0 0 10px 0;
              font-size: 40px;
              font-weight: 700;
              line-height: 56px;
              text-transform: uppercase;
              color: gold;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server" class="frmalg w-auto">
        
        <div id="login" class="container login container-fluid">
            
            <center>
                <img src="./img/bikeLogo.png" width="70"/>
                <br />
                <h1>Login </h1>
            </center>
            <span class="ico-circle"><i class="bi bi-envelope-at"></i></span>
            
            <asp:Label Text="E-mail:" AssociatedControlID="txtEmail" runat="server"></asp:Label>
            <asp:TextBox runat="server" ID="txtEmail" placeholder="Enter email" ValidationGroup="signin"></asp:TextBox>
            <div class="row">
                <asp:RequiredFieldValidator ControlToValidate="txtEmail"  Display="Dynamic" ForeColor="Red" ErrorMessage="E-mail is required" runat="server" ValidationGroup="signin" />
            </div>
            <span class="ico-circle"><i class="bi bi-key"></i></span>
             <asp:Label Text="Password:" AssociatedControlID="txtPassword" runat="server"></asp:Label>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="Enter Password" ValidationGroup="signin"></asp:TextBox>
            <div class="row">
                <asp:RequiredFieldValidator ControlToValidate="txtPassword"  ForeColor="Red" Display="Dynamic" ErrorMessage="Password is required" runat="server" ValidationGroup="signin" />
            </div>
            <center>
                 <asp:Button runat="server" ID="btnSignIn" CssClass="lgnbtn" Text="Login"  ValidationGroup="signin" OnClick="btnSignIn_Click" />
            </center>
            <br />
            <center>
                <asp:HyperLink style="color:gold" ID="HyperLink1" runat="server" href="#btnRegister" >Don't have an account? Register here!</asp:HyperLink>
            </center>
                </div>
           
           
       
      <br />
      <br />
        <div class="container register container-fluid"id="register">    
                <center>
                <h1>Register </h1>
            </center>
            <asp:Label Text="E-mail:" AssociatedControlID="txtNewEmail" runat="server"></asp:Label>
            <asp:TextBox ID="txtNewEmail" placeholder="Type your e-mail here" CssClass="form-control"  runat="server" TextMode="Email" ValidationGroup="newuser"></asp:TextBox>
            <div class="row">
                <asp:RequiredFieldValidator ControlToValidate="txtNewEmail" ForeColor="Red" Display="Dynamic" ErrorMessage="E-mail is required" runat="server" ValidationGroup="newuser" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" runat="server" ErrorMessage="Email is invalid" ControlToValidate="txtNewEmail" EnableTheming="False" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="newuser"></asp:RegularExpressionValidator>
            </div>

            <asp:Label Text="Password:" AssociatedControlID="txtNewPassword1" runat="server"></asp:Label>
            <asp:TextBox ID="txtNewPassword1" placeholder="Type your password here"  CssClass="form-control"  Display="Dynamic" runat="server" TextMode="Password" ValidationGroup="newuser"></asp:TextBox>
            <div class="row">
                <asp:RequiredFieldValidator ControlToValidate="txtNewPassword1" ForeColor="Red" Display="Dynamic" ErrorMessage="Password is required" runat="server" ValidationGroup="newuser" />
            </div>

            <asp:Label Text="Repeat your password:" AssociatedControlID="txtNewPassword2" runat="server"></asp:Label>
            <asp:TextBox ID="txtNewPassword2" placeholder="Repeat your password here" CssClass="form-control"  Display="Dynamic" runat="server" TextMode="Password" ValidationGroup="newuser"></asp:TextBox>
            <div class="row">
                <asp:CompareValidator ID="CompareValidator1" ForeColor="Red" runat="server" ErrorMessage="Passwords do not match" ControlToCompare="txtNewPassword2" ControlToValidate="txtNewPassword1" ValidationGroup="newuser"></asp:CompareValidator>
            </div>
            <center>
                <asp:Button ID="btnRegister" Text="Register" class="lgnbtn"  runat="server" ValidationGroup="newuser" OnClick="btnRegister_Click"/>
            </center>  
            <br />
            <center>
                <asp:HyperLink style="color:gold" ID="HyperLink2" runat="server" href="#login" >Go back to login!</asp:HyperLink>
            </center>
        </div>
       
    </form>
   
</body>
</html>
