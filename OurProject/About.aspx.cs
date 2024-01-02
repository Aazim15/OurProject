using OurProject.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OurProject
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //using (DBHelper dbHelper = new DBHelper())
                //{

                //    var returndataset = dbHelper.ExecDataSetProc("getallusers");
                //    if (returndataset != null && returndataset.Tables.Count > 0 && returndataset.Tables[0].Rows.Count > 0)
                //    {
                //        user.DataSource = returndataset.Tables[0];
                //        user.DataBind();
                //    }
                //}
            }

        }

        protected void Populate_Click(object sender, EventArgs e)
        {
            using (DBHelper dbHelper = new DBHelper())
            {

                var returndataset = dbHelper.ExecDataSetProc("getallusers");
                if (returndataset != null && returndataset.Tables.Count > 0 && returndataset.Tables[0].Rows.Count > 0)
                {
                    user.DataSource = returndataset.Tables[0];
                    user.DataBind();
                }
            }
        }
    }
}