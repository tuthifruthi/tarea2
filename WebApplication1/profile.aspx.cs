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

namespace WebApplication1.Account
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Usuario WHERE nombre='" + Session["UserName"].ToString() + "'", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Usuario");
            Repeater2.DataSource = ds.Tables["Usuario"];
            Repeater2.DataBind();

        }

        public string GetTipo()
        {
            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL = "SELECT id_grupo FROM Usuario WHERE nombre='" + Session["UserName"].ToString() + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();
            int grupo = 0;
            while (d1.Read())
            {
                grupo = int.Parse(d1["id_grupo"].ToString());
            }
            d1.Close();

            string group = "";

            if (grupo == 1)
            {
                group = "Administrador";
            }

            else if (grupo == 2)
            {
                group = "Moderador";
            }

            else if (grupo == 3)
            {
                group = "Usuario Común";
            }

            return group;
        }

        public string GetAge()
        {
            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL = "SELECT fecha_nacimiento FROM Usuario WHERE nombre='" + Session["UserName"].ToString() + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();
            DateTime birthday=default(DateTime);

            while (d1.Read())
            {
               birthday = Convert.ToDateTime(d1["fecha_nacimiento"].ToString());
            }
            
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;
            d1.Close();
            con1.Close();
            return age.ToString();
        }
    }
}