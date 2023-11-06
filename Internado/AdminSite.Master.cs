using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado
{
    public partial class AdminSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsername.Text = (Session["users"].ToString());
        }

        protected void ddlUserMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            string selectedMenu = ddl.SelectedValue;

            switch (selectedMenu)
            {
                case "ChangePassword":
                    Response.Redirect("#");
                    break;

                case "FinishSession":
                    Response.Redirect("Login.aspx");
                    break;
            }
        }
    }
}