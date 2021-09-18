using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Freelancer
{
    public partial class control : System.Web.UI.MasterPage
    {


        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ASP project\Freelancer-vs\Freelancer\Freelancer\App_Data\freelancerDB.mdf;Integrated Security=True");
                con.Open();



                SqlCommand cmd = new SqlCommand("select name,profile from [user] where user_id=@id", con);


                cmd.Parameters.AddWithValue("@id", Session["user_id"].ToString());

                SqlDataReader rd = cmd.ExecuteReader();


                string name = "";
                string image_path = "";

                while (rd.Read())
                {
                    name = rd[0].ToString();
                    image_path = rd[1].ToString();
                }





                if (!image_path.Equals(""))
                {
                    img.InnerHtml = "<a href=\"profile.aspx\"><div class=\"ratio img-responsive img-circle\" style=\"background-image: url(" + image_path + ");width: 30px;height: 30px;margin-top:-30px;\">&nbsp;</div></a>";
                    img_p.InnerHtml = "<div  class=\"ratio img-responsive img-circle\" style=\"background-image: url(" + image_path + ");\"></div>";

                }
                else
                {
                    img.InnerHtml = "<a href=\"profile.aspx\"><div class=\"ratio img-responsive img-circle\" style=\"background-image: url(image/p-d.jpg);width: 30px;height: 30px;margin-top:-30px;\">&nbsp;</div></a>";
                    img_p.InnerHtml = " <div class=\"ratio img-responsive img-circle\" style=\"background-image: url(image/p-d.jpg);width: 30px;height: 30px;\">&nbsp;</div>";
                }

                dis_name.InnerText = name;

                con.Close();
            }
            catch (Exception exp)
            {
                Response.Redirect("index.aspx");
            }
            


        }

      
    }
}