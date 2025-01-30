<%@ Page Language="C#" AutoEventWireup="true" CodeFile="submissionstatus.aspx.cs" Inherits="SubmissionStatus" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SubmissionStatus</title>
    <link href="Style/BootStrap.css" rel="stylesheet" />
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
            place-items: center;
            background-color: #111111;
        }
        table {
            width: 100%;
            http: //localhost:60690/SubmissionStatus.aspx border:thick;
            margin: -15px;
            padding: initial;
        }
        th {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
            text-emphasis-color: white;
        }
         td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }
        th {
            background-color: navajowhite;
        }
        .card {
    position: absolute;
    display: flex
;
    flex-direction: column;
    background-color: #fff;
    border-radius: 0.25rem;
    top: 133px;
    left: 428px;
    width: 670px;
    height: auto;
    padding: 20px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    text-align: left;
}
        .card {
            width: 800px;
            height:auto;
            padding: 20px;
            background: white;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            text-align: left;
            
        }

        .card-title {
            text-align: center;
        }

        .card-body {
            padding: 20px;
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
        .status-label {
            float: left;
            margin-right: 10px;
        }

        .btnrit-primary {
            padding: 5px 10px;
            color: white;
            background-color: red;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            float: right;
            margin-right: 10px; 
}
        }

        .btnrit-primary:hover {
            background-color: #000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="card">
            <div class="card-title">
                <h3>Your Suggestion Status:</h3>
            </div>
            <div class="card-body">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search by YYYY-MM-DD or category"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn btnrit-primary" Text="Search" OnClick="btnSearch_Click" />
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnback_Click" />
                            <br />
                            <br />
                <table class="table table-bordered">
                    <thead class="table-dark">
                        <tr>
                            <th>Name</th>
                            <th>User ID</th>
                            <th>Department</th>
                            <th>Designation</th>
                            <th>Category</th>
                            <th>SubmissionDate</th>
                            <th>SubmissionStatus</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptReportStatus" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("username") %></td>
                                    <td><%# Eval("userid") %></td>
                                    <td><%# Eval("userdept") %></td>
                                    <td><%# Eval("userdesig") %></td>
                                    <td><%# Eval("category") %></td>
                                    <td><%# Eval("subd") %></td>
                                    <td><%# Eval("status") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
               
            </div>
        </div>
    </form>
</body>
</html>
