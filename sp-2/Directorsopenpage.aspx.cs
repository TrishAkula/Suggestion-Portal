using System;
using System.Web;
using System.Web.UI;
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
            if (Request.QueryString["userid"] != null && Request.QueryString["msgid"] != null)
            {
                string userID = Request.QueryString["userid"];
                string MsgID = Request.QueryString["msgid"];
                LoadUserDetails(userID, MsgID);
            }
            else
            {
                Response.Write("<script>alert('User ID or MessageId is missing.');</script>");
            }
        }
    }

    private void LoadUserDetails(string userID, string msgid)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT username, userid, userdept, userdesig, category, msgid, sug FROM sp WHERE userid = @UserID AND msgid = @MsgID";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@MsgID", Convert.ToInt32(msgid));

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Label1.Text = reader["username"].ToString();
                    Label2.Text = reader["userid"].ToString();
                    Label3.Text = reader["userdept"].ToString();
                    Label4.Text = reader["userdesig"].ToString();
                    Label5.Text = reader["category"].ToString();
                    Label6.Text = reader["sug"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Record not found.');</script>");
                }
            }
        }
    }




    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Director.aspx");
    }

    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {

    }
    protected void btnShare_Click(object sender, EventArgs e)
    {
        string selectedCommittee = DropDownList1.SelectedValue;
        if (string.IsNullOrEmpty(selectedCommittee))
        {
            Response.Write("<script>alert('Please select a committee.');</script>");
            return;
        }
        string userId = Request.QueryString["userid"];
        string msgid = Request.QueryString["msgid"];

        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(msgid))
        {
            Response.Write("<script>alert('User ID or Message ID is missing.');</script>");
            return;
        }
        string query = "UPDATE sp SET committee = @Committee WHERE userid = @UserId AND msgid = @Msgid";

        string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Committee", selectedCommittee);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Msgid", msgid);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Response.Redirect("DirectorspageReport.aspx?userid=" + userId + "&msgid=" + msgid);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
                }
                Response.Redirect("DirectorspageReport.aspx?userid=" + userId + "&msgid=" + msgid);
            }
        }
    }

    protected void btnDeny_Click(object sender, EventArgs e)
    {
        string msgid = Request.QueryString["msgid"];
        string userId = Request.QueryString["userid"];
        string loggedInUser = Session["username"] != null ? Session["username"].ToString() : "Unknown";

        UpdateStatus(msgid, "Rejected", loggedInUser);

        Response.Redirect("DirectorsPageReport.aspx?userid=" + userId + "&msgid=" + msgid);
    }



    private void UpdateStatus(string msgid, string newStatus, string loggedInUser)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;
        string query = "UPDATE sp SET status = @status, srep = 'None', replied_by = @loggedInUser WHERE msgid = @msgid";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@loggedInUser", loggedInUser);
                cmd.Parameters.AddWithValue("@msgid", msgid);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }



    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
