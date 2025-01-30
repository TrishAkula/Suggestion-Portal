using System;
using System.Data.SqlClient;
using System.Configuration;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Text))
        {
            Response.Write("<script>alert('Please enter both username and password.');</script>");
            return;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["test1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            try
            {
                con.Open();
                string query = "SELECT eid, ename, epass, department, designation, role, committee FROM edatad WHERE eid = @id AND epass = @pass";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", TextBox2.Text.Trim());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Session["UserName"] = reader["ename"].ToString();
                            Session["UserID"] = reader["eid"].ToString();
                            Session["Department"] = reader["department"].ToString();
                            Session["Designation"] = reader["designation"].ToString();
                            Session["Committee"] = reader["committee"].ToString();
                            if (reader["role"].ToString().Trim().Equals("Normal", StringComparison.OrdinalIgnoreCase))
                            {
                                Response.Redirect("NormalUser2.aspx");
                            }
                            else if (reader["role"].ToString().Trim().Equals("Director", StringComparison.OrdinalIgnoreCase))
                            {
                                Response.Redirect("Director.aspx");
                            }
                            else if (reader["role"].ToString().Trim().Equals("Committee", StringComparison.OrdinalIgnoreCase))
                            {
                                Response.Redirect("committeusersdialog.aspx");
                            }
                            else
                            {
                                Response.Write("<script>alert('Unknown designation.');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid username or password');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }
        }
        Response.Redirect("SubmissionStatus.aspx");
    }
protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
      
        
    }

protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

}
