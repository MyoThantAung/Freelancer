using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Freelancer


{
    public partial class bids : System.Web.UI.Page
    {

        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ASP project\Freelancer-vs\Freelancer\Freelancer\App_Data\freelancerDB.mdf;Integrated Security=True");
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void b_bids_Command(object sender, CommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int bids_id = Convert.ToInt32(GridView1.Rows[index].Cells[0].Text);
            int job_id = Convert.ToInt32(Request.QueryString["job_id"].ToString());
            int empe_id = Convert.ToInt32(GridView1.Rows[index].Cells[1].Text);
            string duration="";
            int days = 0;

            con.Open();


            SqlCommand cmdsa = new SqlCommand("select con_id from contract inner join bids on contract.bids_id=bids.bids_id where job_id=@job_id and empe_id=@user_id", con);

            cmdsa.Parameters.AddWithValue("@user_id", empe_id);
            cmdsa.Parameters.AddWithValue("@job_id", job_id);

            SqlDataReader req = cmdsa.ExecuteReader();

            Boolean isHire = false; 

            while (req.Read())
            {
                if (Convert.ToInt32(req[0].ToString()) > 0)
                {
                   
                    isHire = true;
                }
            }

            con.Close();

            if (!isHire)
            {
                con.Open();


                SqlCommand cmds = new SqlCommand("select job.duration from job inner join bids on job.job_id=bids.job_id where bids.bids_id=@bids_id", con);

                cmds.Parameters.AddWithValue("@bids_id", bids_id);

                SqlDataReader re = cmds.ExecuteReader();

                while (re.Read())
                {
                    duration = re[0].ToString();
                }

                con.Close();


                DateTime s_date = DateTime.Now;
                DateTime now = DateTime.Now;

                if (duration.Contains("days") || duration.Contains("day"))
                {
                    days += Convert.ToInt32(Regex.Match(duration, @"\d+").Value);
                }

                if (duration.Contains("months") || duration.Contains("month"))
                {
                    days += Convert.ToInt32(Regex.Match(duration, @"\d+").Value) * 30;
                }

                if (duration.Contains("years") || duration.Contains("year"))
                {
                    days += Convert.ToInt32(Regex.Match(duration, @"\d+").Value) * 365;
                }


                for (int i = 0; i < days;)        // Put number of days to add instead of 5
                {
                    s_date = s_date.AddDays(1);

                    i++;
                }
                DateTime f_date = s_date;


                con.Open();

                SqlCommand cmd1 = new SqlCommand("select count(con_id) from contract", con);
                int id = Convert.ToInt32(cmd1.ExecuteScalar());
                id += 1;

                SqlCommand cmd = new SqlCommand("insert into contract values (@id,@b_id,@f_date,@p_status,@date)", con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@b_id", bids_id);
                cmd.Parameters.AddWithValue("@f_date", Convert.ToDateTime(f_date));
                cmd.Parameters.AddWithValue("@p_status", "Unpaid");
                cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(now));


                cmd.ExecuteNonQuery();

                con.Close();


                Response.Redirect("employee.aspx");
            }
            else
            {
                model_text.InnerText = "Already Hire !!! ";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show_model", "show_model()", true);
            }

          
        }
    }
}