<%@ Page Language="C#" AutoEventWireup="true" CodeFile="normaluser.aspx.cs" Inherits="Normaluser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>normaluserhomepage</title>
    <link href="Style/BootStrap.css" rel="stylesheet" />
    <style>
        body {
            margin: 0;
            font-family: Arial, sans-serif;
            background-color: #000;
            color: black;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-image: url(Images/bc86bf81fc8d9ecf339d55cb24d37004.jpg);
            background-repeat: no-repeat;
            background-size: cover;
            background-color: #111111;
        }

        .card {
    position: unset;
    display: flex
;
    flex-direction: column;
    min-width: 0;
    word-wrap: break-word;
    background-color: #fff;
    background-clip: border-box;
    border-radius: .25rem;
    top: -191px;
    left: 124px;
}

        .card {
            width: 500px;
            padding: 30px;
            background: white;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            text-align: left;
        }

        .container {
            display: flex;
            justify-content: center;
            align-items: center;
            width: 100%;
        }

        .row {
            display: flex;
            justify-content: center;
            width: 100%;
        }
        .value{
            

        .col-6 {
            display: flex;
            justify-content: center;
            width: 100%;
        }
               .sty{
                   font-family :Verdana;
                   font-weight:bold;
                   font-size:20px;
               }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row-2">
                <div class="col-6">
                </div>
                <div class="col-2" style="margin-top: 200px;">
                    <div class="card">
                        <div class="card-title m-3" style="text-align:center"><h3>Suggestion Portal</h3></div>
                        <div class="card-body" style="margin-left:auto; margin-right:auto">
                             <table style="width:100%; text-align:left;">
        <tr>
            <td><span class="sty">Name: </span><asp:Label ID="Label1" runat="server" CssClass="form-control" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td> <span class="sty">ID: </span><asp:Label ID="Label2" runat="server" CssClass="form-control" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><span class="sty">Department: </span><asp:Label ID="Label3" runat="server" CssClass="form-control" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><span class="sty">Desgination: </span><asp:Label ID="Label4" runat="server" CssClass="form-control" Text=""></asp:Label></td>
        </tr>
    </table>
                            <br />                        
                            <asp:Label ID="Label5" runat="server" Text="Label" ><h5>Category:</h5></asp:Label>
                            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="218px">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem>A</asp:ListItem>
                                <asp:ListItem>B</asp:ListItem>
                                <asp:ListItem>C</asp:ListItem>
                                <asp:ListItem>D</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                            <h4>Your Suggestion</h4>
                            <asp:TextBox ID="TextBox1" TextMode="MultiLine" CssClass="txt form-control" runat="server" rows="10" Columns="40" OnTextChanged="TextBox1_TextChanged"></asp:TextBox><br />
                            <asp:Button ID="Button1" CssClass="btn btn-primary" OnClick="Button1_Click" runat="server" Text="Submit" />
                        </div>
                    </div>
                </div>
                <div class="col-5">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
