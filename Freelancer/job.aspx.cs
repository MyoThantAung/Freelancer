using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Freelancer
{
    public partial class job : System.Web.UI.Page
    {

        SqlConnection con;
        int user_id = 0;
        int bids = 0, hire = 0;
        List<string> skill_list = new List<string>();

        string s_skill = "";
        string s_search = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            skill_list.Add("All");
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=X:\My Project\Application\Web\Freelancer\Freelancer-vs\Freelancer\Freelancer\App_Data\freelancerDB.mdf;Integrated Security=True;MultipleActiveResultSets=True");

            
            s_skill = Request.QueryString["skill"] ?? "";
            s_search = Request.QueryString["search"] ?? "";
            


            con.Open();



            SqlCommand cmd1 = new SqlCommand("SELECT skill FROM job", con);

            
            SqlDataReader rd1 = cmd1.ExecuteReader();



            while (rd1.Read())
            {
                string list = "";
                string[] words = rd1[0].ToString().Split(',');
                foreach (string word in words)
                {

                    bool Contains = skill_list.Contains(word);
                    if (!Contains)
                    {
                        skill_list.Add(word);
                    }


                }

            

            }

            foreach (string w in skill_list)
            {
                d_skill.Items.Add(w);
            }


            con.Close();


            if ((s_search.Equals("") || (s_skill.Equals("All"))) && s_skill.Equals(""))
            {
                con.Open();



                SqlCommand cmd = new SqlCommand("SELECT job.job_id,[user].name,job.title,job.description,job.skill,job.duration,job.wage,job.job_status,job.date,[user].user_id FROM job INNER JOIN [user] ON job.empr_id = [user].user_id; ", con);


                SqlDataReader rd = cmd.ExecuteReader();



                while (rd.Read())
                {

                    user_id = Convert.ToInt32(rd[9].ToString());
                    loadjob(Convert.ToInt32(rd[0].ToString()), rd[1].ToString(), rd[2].ToString(), rd[3].ToString(), rd[4].ToString(), rd[5].ToString(), rd[6].ToString(), rd[7].ToString(), rd[8].ToString());
                }




                con.Close();
            }
            else if(!s_search.Equals("") && (s_search.Equals("") || (s_skill.Equals("All"))))
            {
                con.Open();



                SqlCommand cmd = new SqlCommand("SELECT job.job_id,[user].name,job.title,job.description,job.skill,job.duration,job.wage,job.job_status,job.date,[user].user_id FROM job INNER JOIN [user] ON job.empr_id = [user].user_id where title like @title; ", con);

                cmd.Parameters.AddWithValue("@title", "%"+s_search+"%");
                SqlDataReader rd = cmd.ExecuteReader();



                while (rd.Read())
                {
                    user_id = Convert.ToInt32(rd[9].ToString());

                    loadjob(Convert.ToInt32(rd[0].ToString()), rd[1].ToString(), rd[2].ToString(), rd[3].ToString(), rd[4].ToString(), rd[5].ToString(), rd[6].ToString(), rd[7].ToString(), rd[8].ToString());
                }




                con.Close();
            }
            else if (s_search.Equals("") && !s_skill.Equals("All"))
            {
                con.Open();



                SqlCommand cmd = new SqlCommand("SELECT job.job_id,[user].name,job.title,job.description,job.skill,job.duration,job.wage,job.job_status,job.date FROM job INNER JOIN [user] ON job.empr_id = [user].user_id where skill like @skill; ", con);

                cmd.Parameters.AddWithValue("@skill", "%" + s_skill + "%");
                SqlDataReader rd = cmd.ExecuteReader();



                while (rd.Read())
                {


                    loadjob(Convert.ToInt32(rd[0].ToString()), rd[1].ToString(), rd[2].ToString(), rd[3].ToString(), rd[4].ToString(), rd[5].ToString(), rd[6].ToString(), rd[7].ToString(), rd[8].ToString());
                }




                con.Close();
            }
            else if (!s_search.Equals("") && !s_skill.Equals("All"))
            {
                con.Open();



                SqlCommand cmd = new SqlCommand("SELECT job.job_id,[user].name,job.title,job.description,job.skill,job.duration,job.wage,job.job_status,job.date FROM job INNER JOIN [user] ON job.empr_id = [user].user_id where title like @title and skill like @skill; ", con);

                cmd.Parameters.AddWithValue("@title", "%" + s_search + "%");
                cmd.Parameters.AddWithValue("@skill", "%" + s_skill + "%");
                SqlDataReader rd = cmd.ExecuteReader();



                while (rd.Read())
                {


                    loadjob(Convert.ToInt32(rd[0].ToString()), rd[1].ToString(), rd[2].ToString(), rd[3].ToString(), rd[4].ToString(), rd[5].ToString(), rd[6].ToString(), rd[7].ToString(), rd[8].ToString());
                }




                con.Close();
            }







        }

        protected void loadjob(int job_id,string name,string title,string description,string skill,string duration,string wage,string job_status,string date)
        {
            try
            {

                SqlCommand cmdz = new SqlCommand("select count(*) from [user] join bids on bids.empe_id=[user].user_id join job on job.job_id = bids.job_id where job.job_id = @jid", con);
                cmdz.Parameters.AddWithValue("@jid", job_id);

                bids = (int)cmdz.ExecuteScalar();




                SqlCommand cmdy = new SqlCommand("select count(*) from [user] join bids on bids.empe_id=[user].user_id join job on job.job_id = bids.job_id join contract on contract.bids_id=bids.bids_id where job.job_id = @jid", con);
                cmdy.Parameters.AddWithValue("@jid", job_id);

                hire = (int)cmdy.ExecuteScalar();


                if (title.Length > 45)
                {
                    String temp = title.Substring(0,45);
                    title = temp;
                    title += "<a href=\"job_d.aspx?job_id=" + job_id + "\"> ... </a>";
                }

                if (description.Length > 100)
                {
                    String temp = description.Substring(0, 100);
                    description = temp;
                    description += "<a href=\"job_d.aspx?job_id=" + job_id + "\"> ... </a>";
                }

                string list="";
                string[] words = skill.Split(',');
                foreach (string word in words)
                {
                    list += "<a href=\"job.aspx?skill=" + word + "\">" + word + "</a>";



                }





                name = "<a href=\"s_p.aspx?user_id=" + user_id + "\" class=\"text-white\">" + name + "</a>";

                if (job_status.Equals("Complete"))
                {
                    job_status = "<span class=\"btn border-danger text-danger h-50\">" + job_status + "</span>";
                }
                else
                {
                    job_status = "<span class=\"btn border-info text-info h-50\">" + job_status + "</span>";
                }
                

                jobs_post.InnerHtml += "<div class=\"col mt-3 col-sm-12 col-lg-6 h-100\" ><div class=\"card shadow-lg h-100\"><div class=\"p-3\"><div class=\"card-body\"><span class=\"row\"><div class=\"card-title col h4\">" + title + "</div>" + job_status +"</span><hr><div style = \"font-size: 14px;\" > <span class=\"btn border-info text-info h-50 m-2\">" + bids + " Bids</span><span class=\"btn border-info text-info h-50 m-2\">" + hire + " Hire</span> <hr><span> Skill - "

                    + list + "<hr></div><p class=\"card-text pt-3 pb-3\">" + description + "<br></p><hr><a href = \"job_d.aspx?job_id=" + job_id + "\" class=\"text-info card-link\">See More</a><span class=\"bg-dark text-white p-1  rounded float-right\" style=\"font-size: 13px\">Wages : " + wage + "</span> <span class=\"bg-dark text-white p-1  rounded float-right\" style=\"font-size: 13px;margin-right: 10px\">Duration : " + duration + "</span></div></div><div class=\"card-footer bg-success text-white\"  style=\"font-size:12px;\"><span >" + date + "</span> <span class=\"float-right\">" + name + "</span></div></div></div>";

                

                bids = 0;
                hire = 0;


            }
            catch (Exception exp)
            {
                Response.Write(exp.ToString());
            }
            
        }

        protected void d_skill_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void search_Click(object sender, EventArgs e)
        {
      
                Response.Redirect("job.aspx?skill=" + d_skill.SelectedValue + "&search=" + txt_search.Value);
           
            
        }
    }
}