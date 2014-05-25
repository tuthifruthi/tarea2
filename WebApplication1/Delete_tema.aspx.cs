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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL = "DELETE FROM Comentario WHERE id_tema='" + Request.QueryString["IDTema"] + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();
            d1.Close();

            string strSQL2 = "DELETE FROM Tema WHERE id_tema='" + Request.QueryString["IDTema"] + "'";
            SqlCommand myCommand2 = new SqlCommand(strSQL2, con1);
            SqlDataReader d2 = myCommand2.ExecuteReader();
            d2.Close();

            con1.Close();

            Response.Redirect("~/Default.aspx");
        }
    }
}