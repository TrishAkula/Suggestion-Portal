using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class DirectorsPageReport : System.Web.UI.Page
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
            string query = "SELECT username, userid, userdept, userdesig, category, msgid, sug, status, srep, replied_by FROM sp WHERE userid = @UserID AND msgid = @MsgID";

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
                    Label7.Text = reader["status"].ToString();
                    Label8.Text = reader["srep"].ToString();
                    Label9.Text = reader["replied_by"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Record not found.');</script>");
                }
            }
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Director.aspx");
    }
}