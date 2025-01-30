<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SugessionPortalLoginPage</title>
    <style>
        .txt {
            font-family: 'Times New Roman';
            font-weight: bold;
            font-size: 20px;
        }

        body {
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            background-image: url(Images/bc86bf81fc8d9ecf339d55cb24d37004.jpg);
            background-repeat: no-repeat;
            background-size: cover;
            background-color: #111111;
        }

        .card {
            width: 300px;
            padding: 20px;
            background: white;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            text-align: left;
        }

        .card-title {
            text-align: center;
        }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="card">
            <div class="card-title">
                <h3>Login</h3>
                <p>Welcome to the Suggestion Portal</p>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label for="TextBox1">UserId</label>
                    <asp:TextBox ID="TextBox1" CssClass="txt form-control" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="TextBox2">Password</label>
                    <asp:TextBox ID="TextBox2" TextMode="Password" CssClass="form-control" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                </div>
                <asp:Button ID="Button1" CssClass="btn btn-primary w-100" OnClick="Button1_Click" runat="server" Text="Login" />
            </div>
          </div>
    </form>
</body>
</html>
