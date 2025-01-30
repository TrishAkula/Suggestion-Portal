using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class SubmissionStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["userid"] != null)
            {
                Session["UserID"] = Request.QueryString["userid"]; 
            }

            if (Session["UserID"] != null)
            {
                BindData();
            }
            else
            {
                Response.Write("<script>alert('User session expired. Please login again.');</script>");
            }
        }
    }

    private void BindData(string searchKeyword = "")
    {
        string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;
        string query = "SELECT category, sug, subd, username, userid, userdept, userdesig, status FROM sp WHERE userid = @UserID";

        if (!string.IsNullOrEmpty(searchKeyword))
        {
            query += " AND (CONVERT(VARCHAR, subd, 23) LIKE @Search OR category LIKE @Search)";
        }

        query += " ORDER BY subd DESC";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (Session["UserID"] != null)
                {
                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                }
                else
                {
                    Response.Write("<script>alert('Session expired. Please login again.');</script>");
                    return;
                }

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    cmd.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");
                }

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    rptReportStatus.DataSource = dt;
                    rptReportStatus.DataBind();
                }
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string searchKeyword = txtSearch.Text.Trim();
        BindData(searchKeyword);
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Normaluser2.aspx");
    }
}
