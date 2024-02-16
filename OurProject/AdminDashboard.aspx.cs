using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OurProject
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminManager manager = new AdminManager();
            DataTable data = manager.GetAllUser().Tables[0];
            if (data.Rows.Count > 0)
            {
                UserRep.DataSource = data;
                UserRep.DataBind();
            }
            else
            {
                NoRecords.Visible = true;
                myInput.Visible = false;
            }
        }
        [WebMethod(EnableSession = true)]
        public static string DeleteUser(int UserId)
        {
            AdminManager manager = new AdminManager();
            manager.DeleteUser(UserId);
            return "true";
        }
        [WebMethod(EnableSession = true)]
        public static string AddUser(string Name, string Pass, string PName, string Email)
        {
            AdminManager manager = new AdminManager();
            manager.AddUser(Name, Pass, PName, Email);
            return "true";
        }
    }
}