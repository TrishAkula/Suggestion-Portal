using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class committeusersdialog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userCommittee = Session["Committee"] != null ? Session["Committee"].ToString() : null;
            if (!string.IsNullOrEmpty(userCommittee))
            {
                BindData(userCommittee);
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            BindData();
        }
    }

    private void BindData(string searchKeyword = "")
    {
        string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;
        string userCommittee = Session["Committee"] != null ? Session["Committee"].ToString() : null;
        string queryTab1 = "SELECT msgid, category, sug, subd, username, userid, userdept, userdesig, status " +
                            "FROM sp WHERE status = 'Withheld by Committee' AND committee = @Committee";
        string queryTab2 = "SELECT msgid, category, sug, subd, username, userid, userdept, userdesig, status " +
                            "FROM sp WHERE committee = @Committee";
        if (!string.IsNullOrEmpty(searchKeyword))
        {
            queryTab1 += " AND (username LIKE @Search OR userid LIKE @Search OR userdept LIKE @Search OR category LIKE @Search OR CONVERT(VARCHAR, subd, 23) LIKE @Search)";
            queryTab2 += " AND (username LIKE @Search OR userid LIKE @Search OR userdept LIKE @Search OR category LIKE @Search OR CONVERT(VARCHAR, subd, 23) LIKE @Search)";
        }

        queryTab1 += " ORDER BY subd DESC";
        queryTab2 += " ORDER BY subd DESC";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            using (SqlCommand cmd1 = new SqlCommand(queryTab1, con))
            {
                cmd1.Parameters.AddWithValue("@Committee", userCommittee);
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
                cmd2.Parameters.AddWithValue("@Committee", userCommittee);
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
        }
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string searchKeyword = txtSearch.Text.Trim();  
        BindData(searchKeyword);
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
        Response.Redirect("committeusersreply.aspx?userid=" + userId + "&msgid=" + msgid);
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
        Response.Redirect("committereport.aspx?userid=" + userId + "&msgid=" + msgid);
    }
}