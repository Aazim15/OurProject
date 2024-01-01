using System;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Collections.Generic;
using OurProject.Models;
using System.Linq;
using OurProject.Data;
using System.Data;

namespace OurProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //string connetionString = "Data Source=virusfound;Initial Catalog=OurProject;Integrated Security=True;";
            //List<Users> users = new List<Users>();
            //using (SqlConnection cnn = new SqlConnection(connetionString))
            //{
            //    SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Users]", cnn);
            //    cnn.Open();
            //    SqlDataReader reader = command.ExecuteReader();
            //    try
            //    {
            //        while (reader.Read())
            //        {
            //            users.Add(new Users()
            //            {
            //                Id = int.Parse(reader["ID"].ToString()),
            //                Name = reader["Name"].ToString(),
            //                Password = reader["Password"].ToString(),
            //                Email = reader["Email"].ToString(),
            //                UserName = reader["UserName"].ToString()
            //            });
            //        }
            //    }
            //    finally
            //    {
            //        reader.Close();
            //    }

            //}
            FormsAuthenticationTicket tkt;
            string cookiestr;
            HttpCookie ck;
            tkt = new FormsAuthenticationTicket(1, "Umer", DateTime.Now,
            DateTime.Now.AddMinutes(5), true, "Umer");
            cookiestr = FormsAuthentication.Encrypt(tkt);
            ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            ck.Expires = tkt.Expiration;
            ck.Path = FormsAuthentication.FormsCookiePath;
            Response.Cookies.Add(ck);
            Response.Redirect("/");
            //using (DBHelper dbHelper = new DBHelper())
            //{
            //    List<SqlParameter> Sqlcomm = new List<SqlParameter>();
            //    Sqlcomm.Add(dbHelper.AddParameter("@UserName", SqlDbType.NVarChar, username.Text.ToLower()));
            //    Sqlcomm.Add(dbHelper.AddParameter("@Password", SqlDbType.NVarChar, Password.Text));
            //    var returndataset = dbHelper.ExecDataSetProc("GetLoginUser", Sqlcomm.ToArray());
            //    if (returndataset != null && returndataset.Tables.Count > 0 && returndataset.Tables[0].Rows.Count > 0)
            //    {
            //        FormsAuthenticationTicket tkt;
            //        string cookiestr;
            //        HttpCookie ck;
            //        tkt = new FormsAuthenticationTicket(1, "Umer", DateTime.Now,
            //        DateTime.Now.AddMinutes(5), true, "Umer");
            //        cookiestr = FormsAuthentication.Encrypt(tkt);
            //        ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            //        ck.Expires = tkt.Expiration;
            //        ck.Path = FormsAuthentication.FormsCookiePath;
            //        Response.Cookies.Add(ck);
            //        Response.Redirect("/");
            //    }
            //}
            //if (users.Where(x=> x.UserName.ToLower() == username.Text.ToLower() && Password.Text == x.Password).Any())
            //{

            //}
        }
    }
}