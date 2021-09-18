using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Freelancer
{
    public partial class job_d : System.Web.UI.Page
    {

        SqlConnection con;
        Boolean isbids=false;
        int job_id;
        int user_id = 0;
        int bid = 0, hire = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=X:\My Project\Application\Web\Freelancer\Freelancer-vs\Freelancer\Freelancer\App_Data\freelancerDB.mdf;Integrated Security=True;MultipleActiveResultSets=True");

            job_id = Convert.ToInt32(Request.QueryString["job_id"].ToString());

            con.Open();

            try
            {
               

                SqlCommand cmd1 = new SqlCommand("select bids_id from bids where empe_id=@empe_id and job_id=@job_id", con);

                cmd1.Parameters.AddWithValue("@empe_id", Convert.ToInt32(Session["user_id"].ToString()));
                cmd1.Parameters.AddWithValue("@job_id", job_id);

                SqlDataReader rd1 = cmd1.ExecuteReader();



                while (rd1.Read())
                {
                    if (Convert.ToInt32(rd1[0].ToString()) > 0)
                    {
                        isbids = true;
                    }
                }

                con.Close();

                con.Open();

            }catch(Exception exp)
            {

            }




            SqlCommand cmd = new SqlCommand("SELECT job.job_id,[user].name,job.title,job.description,job.skill,job.duration,job.wage,job.job_status,job.date,[user].user_id FROM job INNER JOIN [user] ON job.empr_id = [user].user_id where job_id=@jo;", con);

            cmd.Parameters.AddWithValue("@jo", job_id);
            SqlDataReader rd = cmd.ExecuteReader();



            while (rd.Read())
            {

                user_id = Convert.ToInt32(rd[9].ToString());
                loadjob(Convert.ToInt32(rd[0].ToString()), rd[1].ToString(), rd[2].ToString(), rd[3].ToString(), rd[4].ToString(), rd[5].ToString(), rd[6].ToString(), rd[7].ToString(), rd[8].ToString());
            }

            con.Close();

        }

        protected void loadjob(int job_id, string name, string title, string description, string skill, string duration, string wage, string job_status, string date)
        {

            Boolean isCom = false;
            try
            {


                SqlCommand cmdz = new SqlCommand("select count(*) from [user] join bids on bids.empe_id=[user].user_id join job on job.job_id = bids.job_id where job.job_id = @jid", con);
                cmdz.Parameters.AddWithValue("@jid", job_id);

                bid = (int)cmdz.ExecuteScalar();




                SqlCommand cmdy = new SqlCommand("select count(*) from [user] join bids on bids.empe_id=[user].user_id join job on job.job_id = bids.job_id join contract on contract.bids_id=bids.bids_id where job.job_id = @jid", con);
                cmdy.Parameters.AddWithValue("@jid", job_id);

                hire = (int)cmdy.ExecuteScalar();


                string list = "";
                string[] words = skill.Split(',');
                foreach (string word in words)
                {
                    list += "," + "<a href=\"#\">" + word + "</a>";
                }

                name = "<a href=\"s_p.aspx?user_id=" + user_id + "\" class=\"text-white\">" + name + "</a>";

                if (job_status.Equals("Complete"))
                {
                    isCom = true;
                    job_status = "<span class=\"btn border-danger text-danger h-50\">" + job_status + "</span>";
                }
                else
                {
                    job_status = "<span class=\"btn border-info text-info h-50\">" + job_status + "</span>";
                }

                string instatus = "";

                if (isbids || isCom)
                {
                    instatus = "<span class=\"text-info border-info\">Bidden</span>";
                }
                else
                {
                    wage_d.InnerText = "Bids amount should be between " + wage;
                    instatus = "<input class=\"btn btn-info card-link\" id=\"btn_bids\" type=\"button\" value=\"Bids\" onclick=\"show_model();\"/>";
                }

                job_display.InnerHtml += "<div class=\"col mt-3 h-100\" ><div class=\"card shadow-lg h-100\"><div class=\"p-3\"><div class=\"card-body\"><span class=\"row\"><div class=\"card-title col h4\">" + title + "</div>" + job_status + "</span><hr><div style = \"font-size: 14px;\" > <span class=\"btn border-info text-info h-50 m-2\">" + bid +" Bids</span><span class=\"btn border-info text-info h-50 m-2\">" + hire + " Hire</span> <hr><span> Skill - "

                    + list + "<hr></div><p class=\"card-text pt-3 pb-3\">" + description + "<br></p><hr>" + instatus + "<span class=\"bg-dark text-white p-1  rounded float-right\" style=\"font-size: 13px\">Wages : " + wage + "</span> <span class=\"bg-dark text-white p-1  rounded float-right\" style=\"font-size: 13px;margin-right: 10px\">Duration : " + duration + "</span></div></div><div class=\"card-footer bg-success text-white\"  style=\"font-size:12px;\"><span >" + date + "</span> <span class=\"float-right\">" + name + "</span></div></div></div>";


               

                bid = 0;
                hire = 0;

            }
            catch (Exception exp)
            {

            }

        }

        protected void bids_Click(object sender, EventArgs e)
        {
            try
            {
                String id =  Session["user_id"].ToString();
                
            }
            catch (Exception exp)
            {
                Response.Redirect("login.aspx");
            }

            Response.Redirect("inter.aspx?job_id=" + job_id + "&amount=" + bid_amount.Value);

        }
    }
}