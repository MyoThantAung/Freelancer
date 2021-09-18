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
    public partial class wallet : System.Web.UI.Page
    {
        SqlConnection con;
        int balance;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ASP project\Freelancer-vs\Freelancer\Freelancer\App_Data\freelancerDB.mdf;Integrated Security=True");

            con.Open();

            SqlCommand cmd = new SqlCommand("select balance from [user] where user_id=@id", con);

            cmd.Parameters.AddWithValue("id", Convert.ToInt32(Session["user_id"].ToString()));

            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read()){

                d_balance.InnerText = rd[0].ToString() + " USD";
                balance = Convert.ToInt32(rd[0].ToString());
            }

            con.Close();
        }

        protected void deposit_Click(object sender, EventArgs e)
        {

            
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show_model", "show_model()", true);
        }

        protected void withdraw_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show_model1", "show_model1()", true);
        }

        protected void btn_deposit_Click(object sender, EventArgs e)
        {

            balance += Convert.ToInt32(Regex.Match(d_amount.Text, @"\d+").Value);

            con.Open();

            SqlCommand cmd = new SqlCommand("update [user] set balance=@ban where user_id=@id", con);

            cmd.Parameters.AddWithValue("@ban",balance);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Session["user_id"].ToString()));

            cmd.ExecuteNonQuery();

            con.Close();

            Response.Redirect("wallet.aspx");
        }

       

        protected void btn_withdraw_Click(object sender, EventArgs e)
        {
            int w_n = Convert.ToInt32(Regex.Match(w_amount.Text, @"\d+").Value);


            if(w_n <= balance)
            {
                balance -= w_n;

                con.Open();

                SqlCommand cmd = new SqlCommand("update [user] set balance=@ban where user_id=@id", con);

                cmd.Parameters.AddWithValue("@ban", balance);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Session["user_id"].ToString()));

                cmd.ExecuteNonQuery();

                con.Close();
                Response.Redirect("wallet.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show_model2", "show_model2()", true);
            }



           
        }
    }
}