<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DirectorsPageReport1.aspx.cs" Inherits="DirectorsPageReport1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>directorsreportpage1</title>
    <link href="Style/BootStrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form3" runat="server">
    <div>
    </head>
    <style>
         body {
      margin: 0;
      display: flex;
      justify-content: center;
      align-items: center;
      min-height: 100vh;
      background-color: #111111;
    }
     .card {
    position: absolute;
    display: flex
;
    flex-direction: column;
    min-width: 0;
    word-wrap: break-word;
    background-color: #fff;
    background-clip: border-box;
    border-radius: .25rem;
    top: 165px;
    left: 500px;
}

    .card {
      width: 500px;
      padding: 20px;
      background: white;
      box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
      border-radius: 10px;
      text-align: center;
    }
    .btn-primary {
            padding: 5px 10px;
            color: white;
            background-color: red;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .btn-primary:hover {
            background-color: #000;
        }
    </style>
<body style="background-image: url(Images/bc86bf81fc8d9ecf339d55cb24d37004.jpg); background-repeat: no-repeat; background-size: cover; ">
    
    <div>
         <div class="container" >
        <div class="row" >
            <div class="col-4"></div>
            <div class="col-4" style="margin-top:200px;">  
                <div class="card">
                    <div class="card-title m-3 style="text-align:center"><h3>Suggestion Portal</h3> </div>
<div class="card-body">
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
         <tr>
            <td><span class="sty">Category:</span><asp:Label ID="Label5" runat="server" CssClass="form-control" Text=""></asp:Label></td>
        </tr>
         <tr>
            <td><span class="sty">SugessionSubmitted: </span><asp:Label ID="Label6" runat="server" CssClass="form-control" Text=""></asp:Label></td>
        </tr>
            <tr>
            <td><span class="sty">SubmissionStatus:</span><asp:Label ID="Label7" runat="server" CssClass="form-control" Text=""></asp:Label></td>
        </tr>
            <tr>
            <td><span class="sty">SuggestionReply:</span><asp:Label ID="Label8" runat="server" CssClass="form-control" Text=""></asp:Label></td>
        </tr>
            <tr>
            <td><span class="sty">Replied By:</span><asp:Label ID="Label9" runat="server" CssClass="form-control" Text=""></asp:Label></td>
        </tr>
            <tr>
            <td><span>Email:</span> <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Enter email"></asp:TextBox></td>
        </tr>
            <tr><td><span>Subject:</span> <asp:TextBox ID="Subject" runat="server" CssClass="form-control" Placeholder="Subject"></asp:TextBox></td></tr>
            <tr><td><span>Content:</span><asp:TextBox ID="txtMessage" TextMode="MultiLine" CssClass="txt form-control" runat="server" rows="5" Columns="20" OnTextChanged="TextBox1_TextChanged" Placeholder="Content"></asp:TextBox><br /></td></tr>

    </table>
    <asp:Button ID="btnSendEmail" runat="server" CssClass="btn btn-primary" Text="Send Email" OnClick="btnSendEmail_Click" />
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnback_Click" />
</div>
                </div>

            </div>
       <div class="col-4">
        </div>
       
            </div>
    </div>
    </form>
</body>
</html>
