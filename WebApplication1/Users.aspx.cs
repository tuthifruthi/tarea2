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
    public partial class WebForm13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Usuario", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Usuario");
            Repeater1.DataSource = ds.Tables["Usuario"];
            Repeater1.DataBind();
            Repeater2.DataSource = ds.Tables["Usuario"];
            Repeater2.DataBind();
        }

        public int GetGrupoUser()
        {
            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL = "SELECT id_grupo FROM Usuario WHERE nombre='" + Session["UserName"].ToString() + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();
            int idgrupo = 0;
            while (d1.Read())
            {
                idgrupo = int.Parse(d1["id_grupo"].ToString());
            }
            d1.Close();
            con1.Close();

            return idgrupo;
        }
    }
}