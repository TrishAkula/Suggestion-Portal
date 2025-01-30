using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net.Mail;

public partial class DirectorsPageReport1 : System.Web.UI.Page
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

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        string recipientEmail = txtEmail.Text.Trim();
        string userMessage = txtMessage.Text.Trim();
        if (string.IsNullOrEmpty(recipientEmail))
        {
            Response.Write("<script>alert('Please enter an email address.');</script>");
            return;
        }

        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("ajtrish19062005@gmail.com");
            mail.To.Add(recipientEmail);
            mail.Subject = Subject.Text;
            mail.Body = String.Format(
    "User Details:\nUsername: {0}\nUser ID: {1}\nDepartment: {2}\nDesignation: {3}\nCategory: {4}\nSuggestion: {5}\nStatus: {6}\nReply: {7}\nReplied By: {8}\n\nUser Message:\n{9}",
    Label1.Text, Label2.Text, Label3.Text, Label4.Text, Label5.Text, Label6.Text, Label7.Text, Label8.Text, Label9.Text, userMessage);



            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("ajtrish19062005@gmail.com", "dgal gvrx qlee yqqs");
            smtp.Send(mail);

            string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE sp SET status = @Status WHERE userid = @UserID AND msgid = @MsgID";
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Status", "Mail Forwarded");
                    cmd.Parameters.AddWithValue("@UserID", Request.QueryString["userid"]);
                    cmd.Parameters.AddWithValue("@MsgID", Convert.ToInt32(Request.QueryString["msgid"]));

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            Response.Redirect("Director.aspx");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error sending email: " + ex.Message + "');</script>");
        }
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Director.aspx");
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

}
