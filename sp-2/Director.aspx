<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Director.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Directors Homepage</title>
    <link href="Style/BootStrap.css" rel="stylesheet" />
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
            display: flex;
            flex-direction: column;
            background-color: #fff;
            border-radius: 0.25rem;
            top: 133px;
            left: 350px;
            width: 900px;
            padding: 20px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            text-align: left;
        }

        .tab {
            overflow: hidden;
            border: 0px;
            background-color: #ffffff;
        }

        .tab button {
            background-color: inherit;
            border: 0px;
            outline: none;
            cursor: pointer;
            padding: 4px 21px;
            transition: 0.3s;
            font-size: 17px;
        }

        .tab button:hover {
            background-color: aqua;
        }

        .tab button.active {
            background-color: red;
        }

        .tabcontent {
            display: none;
            padding: 6px 12px;
            border: none;
        }

        table {
            width: 100%;
            border: 1px solid #ddd;
            margin: -15px;
            text-align: center;
        }
         .open-btn {
            padding: 5px 10px;
            background-color: #000;
            color: white;
            background-color: red;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        .open-btn:hover {
            background-color: #000;
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

        .center {
            margin-left: auto;
            margin-right: auto;
        }
    </style>
</head>
<body style="background-image: url(Images/bc86bf81fc8d9ecf339d55cb24d37004.jpg); background-repeat: no-repeat; background-size: cover;">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-3"></div>
                <div class="col-6" style="margin-top:200px;">
                    <div class="card">
                        <div class="card-title m-3" style="text-align:center;">
                            <h2>Suggestion Message Portal</h2>
                        </div>
                        <div class="card-body">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search by Name, ID, or Department"></asp:TextBox>
                             <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />
                            <br />
                            <br />
                            <div class="tab">
                                <button type="button" class="tablinks" onclick="openTab(event, 'Tab1')" id="defaultOpen">Recieved</button>
                                <button type="button" class="tablinks" onclick="openTab(event, 'Tab2')">CommitteeReply</button>
                                <button type="button" class="tablinks" onclick="openTab(event, 'Tab3')">Report</button>
                            </div>

                            <div id="Tab1" class="tabcontent">
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
                            <th>Status</th>
                            <th>Detail</th>
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
                                    <td><asp:Button ID="Button1" OnClick="Button1_Click" CssClass="open-btn" runat="server" Text="Open" CommandArgument='<%# Eval("userid") + "|" + Eval("msgid") %>' /></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                            </div>

                            <div id="Tab2" class="tabcontent">
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
                            <th>Status</th>
                            <th>Report</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptReportStatus3" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("username") %></td>
                                    <td><%# Eval("userid") %></td>
                                    <td><%# Eval("userdept") %></td>
                                    <td><%# Eval("userdesig") %></td>
                                    <td><%# Eval("category") %></td>
                                    <td><%# Eval("subd") %></td>
                                    <td><%# Eval("status") %></td>
                                    <td><asp:Button ID="Button2" OnClick="Button2_Click" CssClass="open-btn" runat="server" Text="Open" CommandArgument='<%# Eval("userid") + "|" + Eval("msgid") %>' /></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                            </div>
                            <div id="Tab3" class="tabcontent">
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
                            <th>Status</th>
                            <th>Report</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptReportStatus2" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("username") %></td>
                                    <td><%# Eval("userid") %></td>
                                    <td><%# Eval("userdept") %></td>
                                    <td><%# Eval("userdesig") %></td>
                                    <td><%# Eval("category") %></td>
                                    <td><%# Eval("subd") %></td>
                                    <td><%# Eval("status") %></td>
                                    <td><asp:Button ID="Button3" OnClick="Button3_Click" CssClass="open-btn" runat="server" Text="Open" CommandArgument='<%# Eval("userid") + "|" + Eval("msgid") %>' /></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-3"></div>
            </div>
        </div>
    </form>
    <script>
        function openTab(evt, tabName) {
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            document.getElementById(tabName).style.display = "block";
            evt.currentTarget.className += " active";
        }
        document.getElementById("defaultOpen").click();
    </script>
</body>
</html>
