using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;
public partial class Normaluser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        {
            if (!IsPostBack)
            {
                
                if (Session["UserName"] != null && Session["UserID"] != null &&
                    Session["Department"] != null && Session["Designation"] != null)
                {
                    Label1.Text = Session["UserName"].ToString();
                    Label2.Text = Session["UserID"].ToString();
                    Label3.Text =  Session["Department"].ToString();
                    Label4.Text = Session["Designation"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
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
        string query = "INSERT INTO sup (Category, sug, subd, username, userid, userdept, userdesig) VALUES (@Category, @Suggestion, @subdate, @userName, @userID, @dept, @desig)";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Suggestion", suggestion);
                cmd.Parameters.AddWithValue("@SubDate", subdate);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@dept", dept);
                cmd.Parameters.AddWithValue("@desig", desig);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("<script>alert('Data saved successfully!');</script>");
                    Response.Redirect("SubmissionStatus.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Failed to save data.');</script>");
                }
            }
        }
          
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}