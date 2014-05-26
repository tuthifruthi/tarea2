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
    public partial class Responder_MP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int GetIDRemitente()
        {
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

            con1.Close();

            return iduser;
        }

        public int GetIDBuzon()
        {
            int idbuzon = 0;

            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL = "SELECT id_buzon FROM MensajePrivado WHERE id_mensaje='" + Request.QueryString["IDMsj"] + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();
            while (d1.Read())
            {
                idbuzon = int.Parse(d1["id_buzon"].ToString());
            }
            d1.Close();
            con1.Close();

            return idbuzon;
        }

        protected void Send_Click(object sender, EventArgs e)
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

            Asunto.Text = String.Concat("Re: ", asunto);

            string qry2 = "INSERT INTO MensajePrivado ([id_buzon],[id_remitente],[leido],[mensaje],[fecha_de_envio],[asunto]) VALUES ('" + GetIDBuzon() + "','" + GetIDRemitente() + "',0,'" + Message.Text + "',GETDATE(),'" + Asunto.Text + "')";
            SqlCommand myCommand3 = new SqlCommand(qry2, con1);
            SqlDataReader d3 = myCommand3.ExecuteReader();
            d3.Close();


            con1.Close();

            Response.Redirect("~/MP.aspx");
        }
    }
}