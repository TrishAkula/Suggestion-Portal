<%@ Page Language="C#" AutoEventWireup="true" CodeFile="committeusersreply.aspx.cs" Inherits="committeusersreply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>committereply</title>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CommitteeUserReply</title>
    <link href="Style/BootStrap.css" rel="stylesheet" />
</head>
    <style>
         body {
      margin: 0;
      display: flex;
      justify-content: center;
      align-items: center;
      min-height: 100vh;
      background-color:#111111;
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
      width: 600px;
      height:400px
      padding: 20px;
      background: white;
      box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
      border-radius: 10px;
      text-align: left;
    }
    .cardtitle{
        text-align:center;
        margin-top: 20px;
    }
    </style>
<body style="background-image: url(Images/bc86bf81fc8d9ecf339d55cb24d37004.jpg); background-repeat: no-repeat; background-size: cover; ">
    <form id="form1" runat="server">
    <div>
         <div class="container" >
        <div class="row" >
            <div class="col-4"></div>
            <div class="col-4" style="margin-top:200px;">  
                <div class="card">
                    <div class="cardtitle" class="card-title m-3 style="text-align:center"><h3>Suggestion Portal</h3> </div>
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
            <td><span class="sty">SugessionSubmitted: </span><asp:Label ID="Label6" runat="server" CssClass="form-control" Text=""></asp:Label><br /></td>
        </tr>
             </table>
         <h5>SugessionReply</h5>
              <asp:TextBox ID="TextBox1" TextMode="MultiLine" CssClass="txt form-control" runat="server" rows="5" Columns="20" OnTextChanged="TextBox1_TextChanged"></asp:TextBox><br />
   
    
    <asp:Button ID="btnReply" runat="server" CssClass="btn btn-primary" BackColor="#ff0000" Text="Reply" OnClick="btnReply_Click" CommandArgument='<%# Eval("msgid") %>' />
    <asp:Button ID="btnDeny" runat="server" CssClass="btn btn-primary" BackColor="#ff0000" Text="Deny" OnClick="btnDeny_Click" CommandArgument='<%# Eval("msgid") %>' />
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