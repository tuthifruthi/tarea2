﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Default.aspx", true);
        }

        protected void MP_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MP.aspx", true);
        }

        protected void Profile_Click(object sender, EventArgs e)
        {
           Response.Redirect("~/profile.aspx", true);
        }

    }
}
