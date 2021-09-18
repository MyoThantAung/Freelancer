using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Freelancer
{
    public partial class inter : System.Web.UI.Page
    {

        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ASP project\Freelancer-vs\Freelancer\Freelancer\App_Data\freelancerDB.mdf;Integrated Security=True");
            int job_id = Convert.ToInt32(Request.QueryString["job_id"].ToString());
            int amount = Convert.ToInt32(Request.QueryString["amount"].ToString());
            DateTime now = DateTime.Now;
            con.Open();

            SqlCommand cmd1 = new SqlCommand("select count(bids_id) from bids", con);
            int id = Convert.ToInt32(cmd1.ExecuteScalar());
            id += 1;

            SqlCommand cmd = new SqlCommand("insert into bids values (@id,@em_id,@job_id,@amount,@date)", con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@em_id", Convert.ToInt32(Session["user_id"].ToString()));
            cmd.Parameters.AddWithValue("@job_id", job_id);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(now));


            cmd.ExecuteNonQuery();

            con.Close();

            Response.Redirect("job_d.aspx?job_id="+job_id);

        }
    }
}