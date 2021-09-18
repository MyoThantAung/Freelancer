using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Freelancer
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Profile_SqlDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void fileupload_Click(object sender, EventArgs e)
        {

            try
            {
                FileUpload fu2 = (FileUpload)ListView1.EditItem.FindControl("File_Upload");
                TextBox file = (TextBox)ListView1.EditItem.FindControl("profileTextBox");

                if (fu2.HasFile)
                {
                    string filename = fu2.FileName;
                    fu2.SaveAs(Server.MapPath("~/image/" + filename));
                    file.Text = "/image/" + filename;

                }
            }
            catch (Exception exp)
            {

            }
          
            

        
        }

        protected void flie1upload_Click(object sender, EventArgs e)
        {
            try
            {
                FileUpload fu2 = (FileUpload)ListView1.EditItem.FindControl("File_Upload1");
                TextBox file = (TextBox)ListView1.EditItem.FindControl("identify_documentTextBox");

                if (fu2.HasFile)
                {
                    string filename = fu2.FileName;
                    fu2.SaveAs(Server.MapPath("~/image/" + filename));
                    file.Text = "/image/" + filename;

                }
            }
            catch (Exception exp)
            {

            }
        }
    }
}