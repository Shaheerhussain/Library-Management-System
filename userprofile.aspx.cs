using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace library
{
    public partial class userprofile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"]==null)
                {
                    Response.Write(" <script>alert('Session Expired Login Again'); </script> ");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getuserbookdata();
                    if(!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
                Response.Redirect("userlogin.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write(" <script>alert('Session Expired Login Again'); </script> ");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                updateUserPersonalDetails();
            }
        }

        void updateUserPersonalDetails()
        {
            string password = "";
            if (TextBox10.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox10.Text.Trim();
            }
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(" update user_master_tbl set full_name=@full_name, DOB=@DOB, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_address=@full_address, password=@password, account_status=@account_status where user_id='" + Session["username"].ToString().Trim() + "' ", conn);
                cmd.Parameters.AddWithValue("@full_name",TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@DOB", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                    Response.Write(" <script>alert('Your Details Updated Successfully'); </script> ");
                    getUserPersonalDetails();
                    getuserbookdata();
                }
                else
                {
                    Response.Write(" <script>alert('Invalid Entry'); </script> ");
                }

            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");

            }
        }

        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from user_master_tbl where user_id='" + Session["username"].ToString() + "' ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                TextBox2.Text = dt.Rows[0]["DOB"].ToString();
                TextBox3.Text = dt.Rows[0]["contact_no"].ToString();
                TextBox4.Text = dt.Rows[0]["email"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                TextBox6.Text = dt.Rows[0]["city"].ToString();
                TextBox7.Text = dt.Rows[0]["pincode"].ToString();
                TextBox5.Text = dt.Rows[0]["full_address"].ToString();
                TextBox8.Text = dt.Rows[0]["user_id"].ToString();
                TextBox9.Text = dt.Rows[0]["password"].ToString();

                Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if (dt.Rows[0]["account_status"].ToString().Trim() == "Active")
                {
                    Label1.Attributes.Add("class", "badge rounded-pill bg-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "Pending")
                {
                    Label1.Attributes.Add("class", "badge rounded-pill bg-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                {
                    Label1.Attributes.Add("class", "badge rounded-pill bg-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge rounded-pill bg-info");
                }

            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");

            }
        }

        void getuserbookdata()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_issue_tbl where user_id='" + Session["username"].ToString() + "' ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
            }
        }


    }
}