using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Freelancer
{
    public partial class employee : System.Web.UI.Page
    {
        SqlConnection con;
        Double rating;
        int index=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ASP project\Freelancer-vs\Freelancer\Freelancer\App_Data\freelancerDB.mdf;Integrated Security=True");

            try
            {
                index = Convert.ToInt32(Session["index"].ToString());
                Session["index"] = null;
            }
            catch (Exception epx)
            {



            }

            

        }

        protected string isUnPaid(string pay_status)
        {
            
                if (pay_status.Trim().Equals("Unpaid"))
                {
                    return "btn btn-info";
                }
                else
                {
                     return "text-hide";

                }
             

            
        }

        protected string isPaid(string pay_status)
        {
            if (pay_status.Trim().Equals("Unpaid"))
            {
                return "text-hide";
            }
            else
            {
                return "text-info";

            }


        }



        protected void btn_paid_Command(object sender, CommandEventArgs e)
        {


            Page.ClientScript.RegisterStartupScript(this.GetType(), "show_model1", "show_model1()", true);


           

            Session["index"] = e.CommandArgument;
            index = Convert.ToInt32(e.CommandArgument);



           



        }

        protected void r1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            string buttonId = button.ID;

            con.Open();

            SqlCommand cmdzs = new SqlCommand("select rating from [user] where user_id=@id", con);

           
            cmdzs.Parameters.AddWithValue("@id", Convert.ToInt32(GridView1.Rows[index].Cells[9].Text));

            SqlDataReader rdc = cmdzs.ExecuteReader();

            while (rdc.Read())
            {
                rating = Convert.ToDouble(rdc[0]);
            }



            con.Close();

            if (buttonId.Equals("r1"))
            {
                if (rating == 0)
                {
                    rating = 1;
                }
                else
                {
                    rating=(rating+1)/2;
                }
            }

            if (buttonId.Equals("r2"))
            {
                if (rating == 0)
                {
                    rating = 2;
                }
                else
                {
                    rating = (rating + 2) / 2;
                }
            }

            if (buttonId.Equals("r3"))
            {
                if (rating == 0)
                {
                    rating = 3;
                }
                else
                {
                    rating = (rating + 3) / 2;
                }
            }

            if (buttonId.Equals("r4"))
            {
                if (rating == 0)
                {
                    rating = 4;
                }
                else
                {
                    rating = (rating + 4) / 2;
                }
            }
           
           
          

            balance();
        }


        public void balance()
        {
       

          

           int amount = Convert.ToInt32(GridView1.Rows[index].Cells[5].Text);
           int con_id = Convert.ToInt32(GridView1.Rows[index].Cells[7].Text);
           int user_balance = Convert.ToInt32(GridView1.Rows[index].Cells[8].Text);


           int balance=0;
           con.Open();

           SqlCommand cmds = new SqlCommand("select balance from [user] where user_id=@id", con);

           cmds.Parameters.AddWithValue("id", Convert.ToInt32(Session["user_id"].ToString()));

           SqlDataReader rd = cmds.ExecuteReader();

           while (rd.Read())
           {

               balance = Convert.ToInt32(rd[0].ToString());
           }

           con.Close();


           

           if (balance > amount)
           {

                con.Open();

                SqlCommand cmdas = new SqlCommand("update [user] set rating=@rat where user_id=@id;", con);

                cmdas.Parameters.AddWithValue("@rat", rating);
                cmdas.Parameters.AddWithValue("@id", Convert.ToInt32(GridView1.Rows[index].Cells[9].Text));

                cmdas.ExecuteNonQuery();



                con.Close();

                DateTime now = DateTime.Now;

               con.Open();

               SqlCommand cmd1 = new SqlCommand("select count(pay_id) from payment_tranaction", con);
               int id = Convert.ToInt32(cmd1.ExecuteScalar());
               id += 1;

               cmd1 = new SqlCommand("update contract set payment_status='paid' where con_id=@con_id",con);
               cmd1.Parameters.AddWithValue("@con_id", con_id);
               cmd1.ExecuteNonQuery();

               SqlCommand cmd = new SqlCommand("insert into payment_tranaction values (@id,@c_id,@date)", con);

               cmd.Parameters.AddWithValue("@id", id);
               cmd.Parameters.AddWithValue("@c_id", con_id);

               cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(now));


               cmd.ExecuteNonQuery();

               con.Close();

               con.Open();

               balance -= amount; 

               SqlCommand cmdw = new SqlCommand("update [user] set balance=@ban where user_id=@id", con);

               cmdw.Parameters.AddWithValue("@ban", balance);
               cmdw.Parameters.AddWithValue("@id", Convert.ToInt32(Session["user_id"].ToString()));

               cmdw.ExecuteNonQuery();

               con.Close();

               con.Open();

               user_balance += amount;

               SqlCommand cmdz = new SqlCommand("update [user] set balance=@ban where user_id=@id", con);

               cmdz.Parameters.AddWithValue("@ban", user_balance);
               cmdz.Parameters.AddWithValue("@id", Convert.ToInt32(GridView1.Rows[index].Cells[9].Text));

               cmdz.ExecuteNonQuery();

               con.Close();

               Response.Redirect("employee.aspx");

           }
           else
           {
               model_text.InnerText = "Your Balance is lower than amount that you pay!!!";
               Page.ClientScript.RegisterStartupScript(this.GetType(), "show_model", "show_model()", true);
           }

     
        }

    }
}