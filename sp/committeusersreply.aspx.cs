using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class committeusersreply : System.Web.UI.Page
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
    protected void btnReply_Click(object sender, EventArgs e)
    {
        string reply = TextBox1.Text;
        DateTime srepd = DateTime.Now;
        string userId = Request.QueryString["userid"];
        string msgid = Request.QueryString["msgid"];

        string committeeUser = Session["username"] != null ? Session["username"].ToString() : "Unknown";

        string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;
        string query = "UPDATE sp SET srep = @reply, srepd = @srepd, status = 'Replied', replied_by = @committeeUser WHERE userid = @UserID AND msgid = @MsgID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@reply", reply);
                cmd.Parameters.AddWithValue("@srepd", srepd);
                cmd.Parameters.AddWithValue("@committeeUser", committeeUser); 
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@MsgID", msgid);

                cmd.ExecuteNonQuery();
                Response.Redirect("committereport.aspx?userid=" + userId + "&msgid=" + msgid);
            }
        }
    }



    protected void btnDeny_Click(object sender, EventArgs e)
    {
        string msgid = Request.QueryString["msgid"];
        string userId = Request.QueryString["userid"];
        string committeeUser = Session["username"] != null ? Session["username"].ToString() : "Unknown";

        UpdateStatus(msgid, "Rejected by committee", committeeUser);

        Response.Redirect("committereport.aspx?userid=" + userId + "&msgid=" + msgid);
    }

    private void UpdateStatus(string msgid, string newStatus, string committeeUser)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;
        string query = "UPDATE sp SET status = @status, srep = 'None', replied_by = @committeeUser WHERE msgid = @msgid";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@committeeUser", committeeUser); 
                cmd.Parameters.AddWithValue("@msgid", msgid);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

}