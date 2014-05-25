using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL = "DELETE FROM Comentario WHERE id_comentario='" + Request.QueryString["IDComentario"] + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();
            d1.Close();

            con1.Close();

            Response.Redirect("~/Default.aspx");

        }
    }
}