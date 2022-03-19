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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        // add button event
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (check_if_publisher_exist())
            {
                Response.Write("<script>alert('Publisher with this ID already Exist. You cannot add another publisher with the same publisher ID');</script>");
            }
            else
            {
                add_new_publisher();
            }
        }

        // update button event
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (check_if_publisher_exist())
            {
                updatepublisher();
            }
            else
            {
                Response.Write(" <script>alert('Publisher does not exist'); </script> ");
            }
        }
        // delete button event
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (check_if_publisher_exist())
            {
                Deletepublisher();
            }
            else
            {
                Response.Write(" <script>alert('Publisher does not exist'); </script> ");
            }
        }
        // Search button event
        protected void Button1_Click(object sender, EventArgs e)
        {
            getPublisherById();
        }

        //user defined functions

        void getPublisherById()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "' ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write(" <script>alert('Invalid Publisher Id'); </script> ");
                }

            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");

            }
        }

        void Deletepublisher()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE from publisher_master_tbl WHERE publisher_id='" + TextBox1.Text.Trim() + "' ", conn);

                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write(" <script>alert('Publisher deleted Successfully'); </script> ");
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
            }
        }

        void updatepublisher()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name WHERE publisher_id='" + TextBox1.Text.Trim() + "' ", conn);
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write(" <script>alert('Author Updated Successfully'); </script> ");
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
            }
        }

        void add_new_publisher()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl (publisher_id,publisher_name) values(@publisher_id,@publisher_name) ", conn);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write(" <script>alert('Publisher Added Successfully'); </script> ");
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
            }
        }

        bool check_if_publisher_exist()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "' ", conn);
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
        }
    }
}