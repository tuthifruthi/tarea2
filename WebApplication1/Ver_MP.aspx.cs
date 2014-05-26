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
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();
            
            string qry2 = "UPDATE MensajePrivado SET leido=1 WHERE id_mensaje='" + Request.QueryString["IDMsj"] + "'";
            SqlCommand myCommand3 = new SqlCommand(qry2, con1);
            SqlDataReader d3 = myCommand3.ExecuteReader();
            d3.Close();

            con1.Close();
        }

        public string GetNombreRemitente()
        {
            string nombre = "";
            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL = "SELECT id_remitente FROM MensajePrivado WHERE id_mensaje='" + Request.QueryString["IDMsj"] + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();
            int iduser = 0;
            while (d1.Read())
            {
                iduser = int.Parse(d1["id_remitente"].ToString());
            }
            d1.Close();

            string strSQL2 = "SELECT nombre FROM Usuario WHERE id_usuario='" + iduser + "'";
            SqlCommand myCommand2 = new SqlCommand(strSQL2, con1);
            SqlDataReader d2 = myCommand2.ExecuteReader();
            while (d2.Read())
            {
                nombre = d2["nombre"].ToString();
            }
            d2.Close();

            con1.Close();

            return nombre;
        }

        public string GetAsunto()
        {
            string asunto = "";

            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL2 = "SELECT asunto FROM MensajePrivado WHERE id_mensaje='" + Request.QueryString["IDMsj"] + "'";
            SqlCommand myCommand2 = new SqlCommand(strSQL2, con1);
            SqlDataReader d2 = myCommand2.ExecuteReader();
            while (d2.Read())
            {
                asunto = d2["asunto"].ToString();
            }
            d2.Close();

            con1.Close();

            return asunto;

        }

        public string GetFechaEnvio()
        {
            string fecha = "";

            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL2 = "SELECT fecha_de_envio FROM MensajePrivado WHERE id_mensaje='" + Request.QueryString["IDMsj"] + "'";
            SqlCommand myCommand2 = new SqlCommand(strSQL2, con1);
            SqlDataReader d2 = myCommand2.ExecuteReader();
            while (d2.Read())
            {
                fecha = d2["fecha_de_envio"].ToString();
            }
            d2.Close();

            con1.Close();

            return fecha;
        }

        public string GetMensaje()
        {
            string mensaje = "";

            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL2 = "SELECT mensaje FROM MensajePrivado WHERE id_mensaje='" + Request.QueryString["IDMsj"] + "'";
            SqlCommand myCommand2 = new SqlCommand(strSQL2, con1);
            SqlDataReader d2 = myCommand2.ExecuteReader();
            while (d2.Read())
            {
                mensaje = d2["mensaje"].ToString();
            }
            d2.Close();

            con1.Close();

            return mensaje;
        }
    }
}