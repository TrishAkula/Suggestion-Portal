using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData(string searchKeyword = "")
    {
        string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;
        string queryTab1 = "SELECT msgid, category, sug, subd, username, userid, userdept, userdesig, status FROM sp WHERE status = 'In Progress'";
        string queryTab2 = "SELECT msgid, category, sug, subd, username, userid, userdept, userdesig, status FROM sp WHERE status IN ('Withheld by Committee', 'Replied', 'Rejected', 'Rejected by committee', 'Mail Forwarded')";
        string queryTab3 = "SELECT msgid, category, sug, subd, username, userid, userdept, userdesig, status FROM sp WHERE status IN ('Withheld by Committee', 'Replied', 'Rejected by committee')";

        if (!string.IsNullOrEmpty(searchKeyword))
        {
            string searchCondition = " AND (username LIKE @Search OR userid LIKE @Search OR userdept LIKE @Search OR category LIKE @Search OR CONVERT(VARCHAR, subd, 23) LIKE @Search)";

            queryTab1 += searchCondition;
            if (queryTab2.Contains("WHERE"))
            {
                queryTab2 += searchCondition;
            }
            else
            {
                queryTab2 += " WHERE " + searchCondition.TrimStart(" AND".ToCharArray());
            }

            if (queryTab3.Contains("WHERE"))
            {
                queryTab3 += searchCondition;
            }
            else
            {
                queryTab3 += " WHERE " + searchCondition.TrimStart(" AND".ToCharArray());
            }
        }

        queryTab1 += " ORDER BY subd DESC";
        queryTab2 += " ORDER BY subd DESC";
        queryTab3 += " ORDER BY subd DESC";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            using (SqlCommand cmd1 = new SqlCommand(queryTab1, con))
            {
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    cmd1.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");
                }

                using (SqlDataAdapter da1 = new SqlDataAdapter(cmd1))
                {
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    rptReportStatus.DataSource = dt1;
                    rptReportStatus.DataBind();
                }
            }

            using (SqlCommand cmd2 = new SqlCommand(queryTab2, con))
            {
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    cmd2.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");
                }

                using (SqlDataAdapter da2 = new SqlDataAdapter(cmd2))
                {
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    rptReportStatus2.DataSource = dt2;
                    rptReportStatus2.DataBind();
                }
            }

            using (SqlCommand cmd3 = new SqlCommand(queryTab3, con))
            {
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    cmd3.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");
                }

                using (SqlDataAdapter da3 = new SqlDataAdapter(cmd3))
                {
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    rptReportStatus3.DataSource = dt3;
                    rptReportStatus3.DataBind();
                }
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string[] args = btn.CommandArgument.Split('|');

        if (args.Length < 2)
        {
            Response.Write("<script>alert('User ID or Message ID is missing.');</script>");
            return;
        }

        string userId = args[0];
        string msgid = args[1];
        string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;
        string query = "UPDATE sp SET status = 'Withheld by Committee' WHERE msgid = @MsgID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MsgID", msgid);
                cmd.ExecuteNonQuery();
            }
        }

        Response.Redirect("Directorsopenpage.aspx?userid=" + userId + "&msgid=" + msgid);
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string[] args = btn.CommandArgument.Split('|');

        if (args.Length < 2)
        {
            Response.Write("<script>alert('User ID or Message ID is missing.');</script>");
            return;
        }

        string userId = args[0];
        string msgid = args[1];
        string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;
        string query = "SELECT status FROM sp WHERE msgid = @MsgID";
        string status = string.Empty;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MsgID", msgid);
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    status = result.ToString();
                }
            }
        }

        if (status == "Replied")
        {
            Response.Redirect("DirectorspageReport1.aspx?userid=" + userId + "&msgid=" + msgid);
        }
        else
        {
            Response.Redirect("DirectorspageReport.aspx?userid=" + userId + "&msgid=" + msgid);
        }
    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string[] args = btn.CommandArgument.Split('|');
        if (args.Length < 2)
        {
            Response.Write("<script>alert('User ID or Message ID is missing.');</script>");
            return;
        }

        string userId = args[0];
        string msgid = args[1];
        Response.Redirect("DirectorspageReport.aspx?userid=" + userId + "&msgid=" + msgid);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string searchKeyword = txtSearch.Text.Trim();
        BindData(searchKeyword);
    }
}