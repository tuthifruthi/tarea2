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
        public int GetIDUser()
        {
            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL = "SELECT id_usuario FROM Usuario WHERE nombre='" + Session["UserName"].ToString() + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();
            int iduser = -1;
            while (d1.Read())
            {
                iduser = int.Parse(d1["id_usuario"].ToString());
            }


            d1.Close();
            con1.Close();
            return iduser;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Usuario WHERE nombre='" + Session["UserName"].ToString() + "'", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Usuario");
            Repeater7.DataSource = ds.Tables["Usuario"];
            Repeater7.DataBind();
            Repeater6.DataSource = ds.Tables["Usuario"];
            Repeater6.DataBind();
            Repeater5.DataSource = ds.Tables["Usuario"];
            Repeater5.DataBind();
            Repeater3.DataSource = ds.Tables["Usuario"];
            Repeater3.DataBind();
            Repeater1.DataSource = ds.Tables["Usuario"];
            Repeater1.DataBind();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT TOP 5 * FROM Tema WHERE id_usuario='" + GetIDUser() + "' ORDER BY id_tema DESC", cnn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "Tema");
            Repeater4.DataSource = ds2.Tables["Tema"];
            Repeater4.DataBind();

            SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM Tema WHERE id_tema IN (SELECT TOP 5 * FROM Comentario WHERE id_usuario='" + GetIDUser() + "' ORDER BY id_comentario DESC)", cnn);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "Tema");
            Repeater2.DataSource = ds3.Tables["Tema"];
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