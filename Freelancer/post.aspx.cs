using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlClient;

namespace Freelancer
{
    public partial class post : System.Web.UI.Page
    {

        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ASP project\Freelancer-vs\Freelancer\Freelancer\App_Data\freelancerDB.mdf;Integrated Security=True");
        }

        protected void btn_post_Click(object sender, EventArgs e)
        {

          
                con.Open();

                SqlCommand cmd1 = new SqlCommand("select count(job_id) from [job]", con);
                int id = Convert.ToInt32(cmd1.ExecuteScalar());
                id += 1;

            DateTime now = DateTime.Now;

            SqlCommand cmd = new SqlCommand("insert into [job] values (@id,@emprid,@title,@des,@type,@duration,@wage,@job_status,@date)", con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@emprid", Session["user_id"].ToString());
                cmd.Parameters.AddWithValue("@title", title.Text);
                cmd.Parameters.AddWithValue("@des", des.Text);
                cmd.Parameters.AddWithValue("@type",type.Text);
                cmd.Parameters.AddWithValue("@duration", dur.Text);
                cmd.Parameters.AddWithValue("@wage", wage.Text);
                cmd.Parameters.AddWithValue("@job_status", "In Progress");
                cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(now));

                 cmd.ExecuteNonQuery();

                con.Close();

            Response.Redirect("mypost.aspx");
           
          
        }
    }
}