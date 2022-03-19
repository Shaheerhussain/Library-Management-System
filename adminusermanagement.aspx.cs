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
    public partial class adminusermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //search button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getuserbyid();
        }



        void getuserbyid()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from user_master_tbl where user_id='" + TextBox1.Text.Trim() + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(0).ToString();
                        TextBox7.Text = dr.GetValue(10).ToString();
                        TextBox8.Text = dr.GetValue(1).ToString();
                        TextBox3.Text = dr.GetValue(2).ToString();
                        TextBox4.Text = dr.GetValue(3).ToString();
                        TextBox9.Text = dr.GetValue(4).ToString();
                        TextBox10.Text = dr.GetValue(5).ToString();
                        TextBox11.Text = dr.GetValue(6).ToString();
                        TextBox6.Text = dr.GetValue(7).ToString();
                    }
                }
                else
                {
                    Response.Write("<script> alert('Invalid Username or Password'); </script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
            }
        }

        void updateuserstatus(string status)
        {
            if(check_if_user_exist())
            {
                try
                {
                    SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("update user_master_tbl set  account_status='" + status + "' where user_id='" + TextBox1.Text.Trim() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    GridView1.DataBind();
                    Response.Write(" <script>alert('User Status Updated'); </script> ");
                }
                catch (Exception ex)
                {
                    Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
                }
            }
            else
            {
                Response.Write(" <script>alert('Invalid user Id'); </script> ");
            }

        }

        //active button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateuserstatus("Active");
        }

        //pending button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateuserstatus("Pending");
        }

        //deactive button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateuserstatus("deactive");
        }

        //delete user permanently button
        protected void Button2_Click(object sender, EventArgs e)
        {
            delete_user_permanently();
        }

        void delete_user_permanently()
        {
            if(check_if_user_exist())
            {
                try
                {
                    SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE from user_master_tbl WHERE user_id='" + TextBox1.Text.Trim() + "' ", conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write(" <script>alert('User deleted Successfully'); </script> ");
                    clear();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
                }
                Response.Write(" <script>alert('User Id Is blank'); </script> ");
            }
            else
            {
                Response.Write(" <script>alert(' Invalid User Id '); </script> ");
            }
            
        }

        bool check_if_user_exist()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from user_master_tbl where user_id='" + TextBox1.Text.Trim() + "' ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
                return false;
            }
        }

        void clear()
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox7.Text = string.Empty;
            TextBox8.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox9.Text = string.Empty;
            TextBox10.Text = string.Empty;
            TextBox11.Text = string.Empty;
            TextBox6.Text = string.Empty;
        }
    }
}