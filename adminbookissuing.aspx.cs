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
    public partial class adminbookissuing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //search button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getnames();
        }

        //issue button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(checkifbookexist() && checkifmemberexist())
            {
                if(checkifentryexist())
                {
                    Response.Write(" <script>alert('This Member already has this book'); </script> ");
                }
                else
                {
                    issuebook();
                }

            }
            else
            {
                Response.Write(" <script>alert('Invalid User Id OR Book Id'); </script> ");
            }
        }
        //return button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkifbookexist() && checkifmemberexist())
            {
                if (checkifentryexist())
                {
                    returnbook();
                }
                else
                {
                    Response.Write(" <script>alert('This Entry Does not exist'); </script> ");
                }

            }
            else
            {
                Response.Write(" <script>alert('Invalid User Id OR Book Id'); </script> ");
            }
        }

        //user defined function
        void returnbook()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("delete from book_issue_tbl where book_id='"+TextBox1.Text.Trim()+ "' AND user_id='"+ TextBox2.Text.Trim() + "' ", conn);
                int result = cmd.ExecuteNonQuery();
                
                if(result>0)
                {
                    cmd = new SqlCommand("update book_master_tbl set current_stock=current_stock+1 where book_id='"+TextBox1.Text.Trim()+"' ", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Response.Write(" <script>alert(' Book Returned Successfully '); </script> ");
                    GridView1.DataBind();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
            }
        }


        void issuebook()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into book_issue_tbl (user_id,user_name,book_id,book_name,issue_date,due_date) values(@user_id, @user_name, @book_id, @book_name, @issue_date, @due_date) ", conn);

                cmd.Parameters.AddWithValue("@user_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@user_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("update book_master_tbl set current_stock=current_stock-1 where book_id='"+TextBox1.Text.Trim()+"'", conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                Response.Write(" <script>alert('Book Issued Successfully'); </script> ");

                
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
            }
        }

        bool checkifentryexist()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_issue_tbl where user_id='" + TextBox2.Text.Trim() + "' AND book_id='"+TextBox1.Text.Trim()+"' ", conn);
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

        bool checkifbookexist()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "' AND current_stock > 0  ", conn);
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
            catch(Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
                return false;
            }
        }

        bool checkifmemberexist()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("select full_name from user_master_tbl where user_id='" + TextBox2.Text.Trim() + "' ", conn);
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



        void getnames()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-6FL1Q87\\SHAHEER; Initial Catalog=eLibrary; Integrated Security = true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("select book_name from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "' ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write(" <script>alert('Invalid Book Id'); </script> ");
                }

                cmd = new SqlCommand("select full_name from user_master_tbl where user_id='"+TextBox2.Text.Trim()+"' ", conn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write(" <script>alert('Invalid User Id'); </script> ");
                }
            }
            catch(Exception ex)
            {
                Response.Write(" <script>alert('" + ex.Message + "'); </script> ");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType== DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if(today>dt)
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