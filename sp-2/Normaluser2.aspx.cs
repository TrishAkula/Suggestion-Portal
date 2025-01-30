using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserName"] != null && Session["UserID"] != null &&
                Session["Department"] != null && Session["Designation"] != null)
            {
                Label1.Text = Session["UserName"].ToString();
                Label2.Text = Session["UserID"].ToString();
                Label3.Text = Session["Department"].ToString();
                Label4.Text = Session["Designation"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            if (Request.QueryString["userid"] != null)
            {
                Session["UserID"] = Request.QueryString["userid"];
            }

            if (Session["UserID"] != null)
            {
                BindReportData();
            }
            else
            {
                Response.Write("<script>alert('User ID is missing. Please login again.');</script>");
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string category = DropDownList1.SelectedValue;
        string suggestion = TextBox1.Text;
        DateTime subdate = DateTime.Now;
        string username = Session["UserName"] != null ? Session["UserName"].ToString() : "guest";
        string userID = Session["UserID"] != null ? Session["UserID"].ToString() : "0";
        string dept = Session["Department"] != null ? Session["Department"].ToString() : "unknown";
        string desig = Session["Designation"] != null ? Session["Designation"].ToString() : "unknown";

        string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;
        string query = "INSERT INTO sp (category, sug, subd, username, userid, userdept, userdesig) VALUES (@Category, @Suggestion, @subdate, @userName, @userID, @dept, @desig)";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Suggestion", suggestion);
                cmd.Parameters.AddWithValue("@subdate", subdate);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@dept", dept);
                cmd.Parameters.AddWithValue("@desig", desig);

                cmd.ExecuteNonQuery();
                Response.Redirect("SubmissionStatus.aspx");
            }
        }
    }

    private void BindReportData(string searchKeyword = "")
    {
        string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;

        if (Session["UserID"] == null)
        {
            Response.Write("<script>alert('Session expired. Please log in again.');</script>");
            return;
        }

        string userID = Session["UserID"].ToString();
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
                cmd.Parameters.AddWithValue("@UserID", userID);

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
        BindReportData(searchKeyword);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
    }
}
