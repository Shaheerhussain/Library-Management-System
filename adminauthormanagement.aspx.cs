using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace library
{
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // search button event
        protected void Button1_Click1(object sender, EventArgs e)
        {
            getAuthorById();
        }

        // add button event
        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (check_if_author_exist())
            {
                Response.Write("<script>alert('Author with this ID already Exist. You cannot add another Author with the same Author ID');</script>");
            }
            else
            {
                addnewauthor();
            }
        }

        //update  button event
        protected void Button3_Click1(object sender, EventArgs e)
        {
            if (check_if_author_exist())
            {
                updateAuthor();
            }
            else
            {
                Response.Write(" <script>alert('Author does not exist'); </script> ");
            }
        }
        // delete button event
        protected void Button4_Click1(object sender, EventArgs e)
        {
            if (check_if_author_exist())
            {
                DeleteAuthor();
            }
            else
            {
                Response.Write(" <script>alert('Author does not exist'); </script> ");
            }
        }

        //user defined function

        void getAuthorById()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from author_master_tbl where author_id='" + TextBox1.Text.Trim() + "' ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write(" <script>alert('Invalid Author Id'); </script> ");
                }

            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");

            }
        }


        void DeleteAuthor()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE from author_master_tbl WHERE author_id='" + TextBox1.Text.Trim() + "' ", conn);

                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write(" <script>alert('Author deleted Successfully'); </script> ");
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
            }
        }

        void updateAuthor()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name WHERE author_id='" + TextBox1.Text.Trim() + "' ", conn);
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

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

        void addnewauthor()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl (author_id,author_name) values(@author_id,@author_name) ", conn);

                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write(" <script>alert('Author Added Successfully'); </script> ");
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
            }
        }



        bool check_if_author_exist()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from author_master_tbl where author_id='" + TextBox1.Text.Trim() + "' ", conn);
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