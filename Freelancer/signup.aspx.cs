using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;

namespace Freelancer
{
    public partial class signup : System.Web.UI.Page
    {

        SqlConnection con;
      
      

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ASP project\Freelancer-vs\Freelancer\Freelancer\App_Data\freelancerDB.mdf;Integrated Security=True");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            if (pass.Value.Equals(cpass.Value))
            {
                con.Open();

                SqlCommand cmd1 = new SqlCommand("select count(user_id) from [user]",con);
                int id = Convert.ToInt32(cmd1.ExecuteScalar());
                id += 1;

                SqlCommand cmd = new SqlCommand("insert into [user](user_id,name,email,phone_no,password,profile,rating,balance,date) values (@id,@na,@email,@pho,@pass,@pro,@rat,@ban,@date)", con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@na", username.Value);
                cmd.Parameters.AddWithValue("@email", email.Value);
                cmd.Parameters.AddWithValue("@pho", phone_no.Value);
                cmd.Parameters.AddWithValue("@pass", SecurePasswordHasher.Hash(pass.Value));
                cmd.Parameters.AddWithValue("@pro", upload(username.Value).Equals("Error")?null:upload(username.Value));
                cmd.Parameters.AddWithValue("@rat", 0);
                cmd.Parameters.AddWithValue("@ban", 0);
                cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Now));

                cmd.ExecuteNonQuery();

                con.Close();

              

                Response.Redirect("login.aspx");
            }
            else
            {
                error.InnerText="password do not match";
            }

           

        }


        public string upload(String name)
        {
            if (FileUpload.HasFile)
            {
                try
                {

                    String Filename = FileUpload.FileName;
                    FileUpload.SaveAs(Server.MapPath(@"~/image/"+Filename));
                    
                    return "/image/" + Filename;


                }
                catch (Exception e)
                {
                    Response.Write(e.ToString());
                }
            }
            return "error";
        }
        public static class SecurePasswordHasher
        {
            /// <summary>
            /// Size of salt.
            /// </summary>
            private const int SaltSize = 16;

            /// <summary>
            /// Size of hash.
            /// </summary>
            private const int HashSize = 20;

            /// <summary>
            /// Creates a hash from a password.
            /// </summary>
            /// <param name="password">The password.</param>
            /// <param name="iterations">Number of iterations.</param>
            /// <returns>The hash.</returns>
            public static string Hash(string password, int iterations)
            {
                // Create salt
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

                // Create hash
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
                var hash = pbkdf2.GetBytes(HashSize);

                // Combine salt and hash
                var hashBytes = new byte[SaltSize + HashSize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

                // Convert to base64
                var base64Hash = Convert.ToBase64String(hashBytes);

                // Format hash with extra information
                return string.Format("$MYHASH$V1${0}${1}", iterations, base64Hash);
            }

            /// <summary>
            /// Creates a hash from a password with 10000 iterations
            /// </summary>
            /// <param name="password">The password.</param>
            /// <returns>The hash.</returns>
            public static string Hash(string password)
            {
                return Hash(password, 10000);
            }

            /// <summary>
            /// Checks if hash is supported.
            /// </summary>
            /// <param name="hashString">The hash.</param>
            /// <returns>Is supported?</returns>
            public static bool IsHashSupported(string hashString)
            {
                return hashString.Contains("$MYHASH$V1$");
            }

            /// <summary>
            /// Verifies a password against a hash.
            /// </summary>
            /// <param name="password">The password.</param>
            /// <param name="hashedPassword">The hash.</param>
            /// <returns>Could be verified?</returns>
            public static bool Verify(string password, string hashedPassword)
            {
                // Check hash
                if (!IsHashSupported(hashedPassword))
                {
                    throw new NotSupportedException("The hashtype is not supported");
                }

                // Extract iteration and Base64 string
                var splittedHashString = hashedPassword.Replace("$MYHASH$V1$", "").Split('$');
                var iterations = int.Parse(splittedHashString[0]);
                var base64Hash = splittedHashString[1];

                // Get hash bytes
                var hashBytes = Convert.FromBase64String(base64Hash);

                // Get salt
                var salt = new byte[SaltSize];
                Array.Copy(hashBytes, 0, salt, 0, SaltSize);

                // Create hash with given salt
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
                byte[] hash = pbkdf2.GetBytes(HashSize);

                // Get result
                for (var i = 0; i < HashSize; i++)
                {
                    if (hashBytes[i + SaltSize] != hash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

    }
}