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
    public partial class WebForm12 : System.Web.UI.Page
    {
        public int GetID()
        {
            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL = "SELECT id_usuario FROM Usuario WHERE nombre='" + Session["UserName"].ToString() + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();
            int iduser = 0;
            while (d1.Read())
            {
                iduser = int.Parse(d1["id_usuario"].ToString());
            }
            d1.Close();
            con1.Close();
            return iduser;
        }

        public int GetIDBuzon()
        {
            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL2 = "SELECT id_buzon FROM BuzonEntrada WHERE id_usuario='" + GetID() + "'";
            SqlCommand myCommand2 = new SqlCommand(strSQL2, con1);
            SqlDataReader d2 = myCommand2.ExecuteReader();
            int idbuzon = 0;

            while (d2.Read())
            {
                idbuzon = int.Parse(d2["id_buzon"].ToString());
            }
            d2.Close();
            con1.Close();

            return idbuzon;
        }

        public int CountMensajesRecibidos()
        {
            int cant = 0;

            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL = "SELECT mensajes FROM BuzonEntrada WHERE id_buzon='" + GetIDBuzon() + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();

            while (d1.Read())
            {
                cant = int.Parse(d1["mensajes"].ToString());
            }

            d1.Close();
            con1.Close();

            return cant;
        }

        public int GetMensajesNoLeidos()
        {
            int cant = 0;

            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL = "SELECT mensajes_sin_leer FROM BuzonEntrada WHERE id_buzon='" + GetIDBuzon() + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();

            while (d1.Read())
            {
                cant = int.Parse(d1["mensajes_sin_leer"].ToString());
            }

            d1.Close();
            con1.Close();

            return cant;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MensajePrivado WHERE id_buzon='" + GetIDBuzon() + "'", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "MensajePrivado");
            Repeater1.DataSource = ds.Tables["MensajePrivado"];
            Repeater1.DataBind();
            Repeater2.DataSource = ds.Tables["MensajePrivado"];
            Repeater2.DataBind();
            Repeater3.DataSource = ds.Tables["MensajePrivado"];
            Repeater3.DataBind();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT nombre FROM Usuario WHERE id_usuario IN (SELECT id_remitente FROM MensajePrivado WHERE id_buzon='" + GetIDBuzon() + "')", cnn);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "Usuario");
            Repeater4.DataSource = ds1.Tables["Usuario"];
            Repeater4.DataBind();
        }


    }
}