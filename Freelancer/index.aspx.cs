using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace Freelancer
{
    public partial class index : System.Web.UI.Page
    {

        SqlConnection con;
        int user_id = 0;
        int bids = 0,hire=0;

        protected String dbpath()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return path;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            d_person.InnerHtml += dbpath();

            Console.WriteLine(dbpath());

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=X:\My Project\Application\Web\Freelancer\Freelancer-vs\Freelancer\Freelancer\App_Data\freelancerDB.mdf;Integrated Security=True;MultipleActiveResultSets=True");

            con.Open();

            

            SqlCommand cmd1 = new SqlCommand("select count(job_id) from job", con);
            int id = Convert.ToInt32(cmd1.ExecuteScalar());
            id -= 2;

            SqlCommand cmd = new SqlCommand("SELECT job.job_id,[user].name,job.title,job.description,job.skill,job.duration,job.wage,job.job_status,job.date,[user].user_id FROM job INNER JOIN [user] ON job.empr_id = [user].user_id where job_id>@id; ", con);
            cmd.Parameters.AddWithValue("@id",id);

            SqlDataReader rd = cmd.ExecuteReader();



            while (rd.Read())
            {
                user_id = Convert.ToInt32(rd[9].ToString());

                loadjob(Convert.ToInt32(rd[0].ToString()), rd[1].ToString(), rd[2].ToString(), rd[3].ToString(), rd[4].ToString(), rd[5].ToString(), rd[6].ToString(), rd[7].ToString(), rd[8].ToString());
            }




            con.Close();


           



            con.Open();

            SqlCommand cmdq = new SqlCommand("select DISTINCT top (3) [user].rating,[user].user_id,[user].name,[user].email,[user].phone_no,[user].address,[user].degree,[user].experience,[user].self_description,[user].profile,[user].identify_document from[user] inner join bids on bids.empe_id =[user].user_Id order by rating desc", con);


            SqlDataReader rd1 = cmdq.ExecuteReader();



            while (rd1.Read())
            {
                Boolean isID = false;
                double d = 0;
                try
                {
                    try
                    {
                        d = Convert.ToDouble(rd1[0].ToString());
                    }
                    catch (Exception expp)
                    {

                    }

                    if (!rd1[10].ToString().Equals(""))
                    {
                        isID = true;
                    }
                }
                catch (Exception exp)
                {

                }

                loadperson(d,Convert.ToInt32(rd1[1].ToString()), rd1[2].ToString(), rd1[3].ToString(), rd1[4].ToString(), rd1[5].ToString(), rd1[6].ToString(), rd1[7].ToString(), rd1[8].ToString(), rd1[9].ToString(), isID);

            }


            con.Close();




        }


        protected void loadperson(double rating,int user_id, string name, string email, string phone_no, string address, string degree, string experience, string self_description, string profile, Boolean i_d)
        {
            try
            {

                d_person.InnerHtml += "<div class=\"col\">" +

                         " <div class=\"card p-5 m-2\">" +

                               " <div class=\"card-body text-center\">" +
                                       "<div class=\"pl-5 pr-5\" style=\"padding: 50px\">" +

                                               " <div class=\"ratio img-responsive img-circle\" style=\"background-image: url(" + profile + ");\"></div>" +
                                           " </div>" +

                                  "<h4 class=\"card-title\">" + name + "</h4>" +
                                  "<p class=\"card-text\">" + self_description + "<br><br>" +
                                    "<i class=\"fas fa-star\">&nbsp&nbsp" + rating + "</i> <br>" +
                                "</p>" +
                                    "<hr />" +
                                    "<div class=\"row\">" +
                                        "<div class=\"col p-2\">" +
                                            "<i class=\"fas fa-envelope\"></i>" +
                                        "</div>" +
                                        "<div class=\"col-7 p-2\">" +
                                            email +
                                        "</div>" +
                                    "</div>" +



                     "<div class=\"row\">" +
                                        "<div class=\"col p-2\">" +
                                            "<i class=\"fas fa-phone\"></i>" +
                                        "</div>" +
                                        "<div class=\"col-7 p-2\">" +
                                            phone_no +
                                        "</div>" +
                                    "</div>" +

                     "<div class=\"row\">" +
                                        "<div class=\"col p-2\">" +
                                            "<i class=\"fas fa-map-marked\"></i>" +
                                        "</div>" +
                                        "<div class=\"col-7 p-2\">" +
                                            address +
                                        "</div>" +
                                    "</div>" +

                     "<div class=\"row\">" +
                                        "<div class=\"col p-2\">" +
                                            "<i class=\"fas fas fa-award\"></i>" +
                                        "</div>" +
                                        "<div class=\"col-7 p-2\">" +
                                            degree +
                                        "</div>" +
                                    "</div>" +

                                       "<div class=\"row\">" +
                                        "<div class=\"col p-2\">" +
                                            "<i class=\"fas fa-code-branch\"></i>" +
                                        "</div>" +
                                        "<div class=\"col-7 p-2\">" +
                                             experience +
                                        "</div>" +
                                    "</div>" +

                                       "<div class=\"row\">" +
                                        "<div class=\"col p-2\">" +
                                            "<i class=\"fas fa-id-card-alt\"></i>" +
                                        "</div>" +
                                        "<div class=\"col-7 p-2\">" +
                                             i_d +
                                        "</div>" +
                                    "</div>" +



                                "</div>" +


                                "</div>" +
                              "</div>";

            }
            catch (Exception exp)
            {

            }

        }

        protected void loadjob(int job_id, string name, string title, string description, string skill, string duration, string wage, string job_status, string date)
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
                    String temp = title.Substring(0, 45);
                    title = temp;
                  
                    title += "<a href=\"job_d.aspx?job_id=" + job_id + "\"> ... </a>";
                }

                if (description.Length > 100)
                {
                    String temp = description.Substring(0, 100);
                    description = temp;
                    description += "<a href=\"job_d.aspx?job_id=" + job_id + "\"> ... </a>";
                }



                string list = "";
                string[] words = skill.Split(',');
                foreach (string word in words)
                {
                    list += "<a href=\"job.aspx?skill=" + word + "\">" + word + "</a>";



                }





                name = "<a href=\"s_p.aspx?user_id="+user_id+"\" class=\"text-white\">" + name + "</a>";

                if (job_status.Equals("Complete"))
                {
                    job_status = "<span class=\"btn border-danger text-danger h-50\">" + job_status + "</span>";
                }
                else
                {
                    job_status = "<span class=\"btn border-info text-info h-50\">" + job_status + "</span>";
                }


                job_card.InnerHtml += "<div class=\"col col-sm-12 col-lg-6 mt-3 h-100\" ><div class=\"card shadow-lg h-100\"><div class=\"p-3\"><div class=\"card-body\"><span class=\"row\"><div class=\"card-title col h4\">" + title + "</div>" + job_status + "</span><hr><div style = \"font-size: 14px;\" > <span class=\"btn border-info text-info h-50 m-2\">" + bids + " Bids</span><span class=\"btn border-info text-info h-50 m-2\">"+ hire +" Hire</span> <hr><span> Skill - "

                    + list + "<hr></div><p class=\"card-text pt-3 pb-3\">" + description + "<br></p><hr><a href = \"job_d.aspx?job_id=" + job_id + "\" class=\"text-info card-link\">See More</a><span class=\"bg-dark text-white p-1  rounded float-right\" style=\"font-size: 13px\">Wages : " + wage + "</span> <span class=\"bg-dark text-white p-1  rounded float-right\" style=\"font-size: 13px;margin-right: 10px\">Duration : " + duration + "</span></div></div><div class=\"card-footer bg-success text-white\"  style=\"font-size:12px;\"><span >" + date + "</span> <span class=\"float-right\">" + name + "</span></div></div></div>";

                bids = 0;
                hire = 0;

            }
            catch (Exception exp)
            {
                Response.Write(exp.ToString());
            }

        }

       
    }
}