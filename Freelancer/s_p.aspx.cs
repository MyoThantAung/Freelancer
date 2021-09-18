using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace Freelancer
{
    public partial class s_p : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ASP project\Freelancer-vs\Freelancer\Freelancer\App_Data\freelancerDB.mdf;Integrated Security=True");

            string user_id = Request.QueryString["user_id"] ?? "";

            con.Open();



            SqlCommand cmd1 = new SqlCommand("select [user].user_id,[user].name,[user].email,[user].phone_no,[user].address,[user].degree,[user].experience,[user].self_description,[user].rating,[user].profile,[user].identify_document  from [user] where [user].user_id=@user_id", con);

            cmd1.Parameters.AddWithValue("@user_id", user_id);
            SqlDataReader rd1 = cmd1.ExecuteReader();



            while (rd1.Read())
            {
                Boolean isID = false;
                double d = 0;
                try
                {
                    try
                    {
                        d = Convert.ToDouble(rd1[8].ToString());
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

                loadperson(Convert.ToInt32(rd1[0].ToString()), rd1[1].ToString(), rd1[2].ToString(), rd1[3].ToString(), rd1[4].ToString(), rd1[5].ToString(), rd1[6].ToString(), rd1[7].ToString(), d, rd1[9].ToString(), isID);

            }


            con.Close();


        }


        protected void loadperson(int user_id, string name, string email, string phone_no, string address, string degree, string experience, string self_description, double rating, string profile, Boolean i_d)
        {
            try
            {

                d_person.InnerHtml += "<div style=\"width:400px;margin: 0 auto;margin-bottm:30px\">" +

                         " <div class=\"card p-2 m-2\" >" +

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


                                "</div>"+

                "</div>";


            }
            catch (Exception exp)
            {

            }

        }
    }
}