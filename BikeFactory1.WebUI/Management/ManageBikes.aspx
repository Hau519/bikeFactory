<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageBikes.aspx.cs" Inherits="BikeFactory1.WebUI.Management.ManageBike" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../lib/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="../Site.css" rel="stylesheet" />
    
    <script src="../lib/bootstrap/js/bootstrap.js"></script>
    <style>
        *{
            margin:0;
            padding:0;
        }
        .box{
            width: 90%;
            margin: 0 auto;
        
        }
        .btnAddAndUpdate {
            width:100%;
            margin: 10px;
            margin-left: 0px;
        }
            
    </style>
    <title>Manage Bikes</title>
    <link rel="icon" type="image/x-icon" href="../img/icon.png" />
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <h1>Bike List</h1>
        </center>
        
        
        <br />
        <div class="containner box" >
            <div class="row">
                <div class="col-md-6">

                    <asp:Label runat="server" Text="Name:" CssClass="form-label"></asp:Label>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Contact Name is required" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                    <div class="suspenionType">
                        <asp:Label Text="Suspension Type:" AssociatedControlID="ddlSuspensionType" runat="server"></asp:Label>
                    <asp:CustomValidator ID="cvSuspensionType" Display="Dynamic" ErrorMessage="Suspension Type is required" ForeColor="Red" runat="server" OnServerValidate="cvSuspensionType_ServerValidate"/>
                    <asp:DropDownList ID="ddlSuspensionType" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Undefined"></asp:ListItem>
                        <asp:ListItem Text="Front"></asp:ListItem>
                        <asp:ListItem Text="Rear"></asp:ListItem>
                        <asp:ListItem Text="Dual"></asp:ListItem>
                    </asp:DropDownList>
                    </div>
                   
                    <div class="tireType">
                        <asp:Label Text="Tire Type:" AssociatedControlID="ddlTireType" runat="server"></asp:Label>
                    <asp:CustomValidator ID="cvTireType" Display="Dynamic" ForeColor="Red" ErrorMessage="Tire Type is required" runat="server" OnServerValidate="cvTireType_ServerValidate" />
                    <asp:DropDownList ID="ddlTireType" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Undefined"></asp:ListItem>
                        <asp:ListItem Text="Regular"></asp:ListItem>
                        <asp:ListItem Text="Commuter"></asp:ListItem>
                        <asp:ListItem Text="Gravel"></asp:ListItem>
                    </asp:DropDownList>
                    </div>
                    
                
                    <div class="container">
                        <div class="row">

                            <div class="col-md-6">
                                <asp:Button ID="btnAdd" CssClass="btn btn-success btnAddAndUpdate" Text="Add" runat="server" OnClick="btnAdd_Click"/>
                            </div>

                            <div class="col-md-6">
                                <asp:Button ID="btnUpdate" CssClass="btn btn-success btnAddAndUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click"/>
                            </div>

                        </div>
                        <center>
            <asp:LinkButton Style="margin:15px 0; background-color:#ec3f3f; color:white; padding: 8px 20px; text-align: center" ID="lkbSignOut" runat="server" OnClick="lkbSignOut_Click" CausesValidation = "false" CssClass="btn btn-light" class="logout">Sign Out</asp:LinkButton>
        </center>
                    </div>
                
                
                </div>

                <div class="col-md-6">
                     <asp:DataGrid ID="dgBikes" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="dgBikes_SelectedIndexChanged" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellSpacing="10" >
                         <AlternatingItemStyle BackColor="White" />
                         <Columns>
                             <asp:ButtonColumn CommandName="Select" HeaderText="Select" Text="Select"></asp:ButtonColumn>
                             <asp:BoundColumn DataField="Id" HeaderText="ID"></asp:BoundColumn>
                             <asp:BoundColumn DataField="Name" HeaderText="Bike Name"></asp:BoundColumn>
                             <asp:BoundColumn DataField="SuspensionType" HeaderText="Suspension Type"></asp:BoundColumn>
                             <asp:BoundColumn DataField="TireType" HeaderText="Tire Type"></asp:BoundColumn>
                         </Columns>
                         <EditItemStyle BackColor="#7C6F57" />
                         <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                         <ItemStyle BackColor="#E3EAEB" />
                         <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                         <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                     </asp:DataGrid>
                        
                     <div>
                        <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btn btn-danger col-md-3 btnAddAndUpdate"  OnClientClick="return btnRemoveClientClick();" OnClick="btnRemove_Click" />

                         <div class="row">
                            <div class="col-md-6">
                                <asp:TextBox ID="txtSearchById" placeholder="Search by Id" CssClass="form-control btnAddAndUpdate" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-light btnAddAndUpdate" CausesValidation="False" OnClick="btnSearch_Click"/>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>

        

      
   
    </form>
     


     <script>
        function btnRemoveClientClick() {
            if (confirm('Are you sure to delete?'))
                return true;
            else
                return false;
        }
     </script>
</body>
</html>

