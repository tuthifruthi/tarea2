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
    public partial class WebForm11 : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            String query = "SELECT nombre AS nombreuser, id_usuario AS iduser FROM Usuario";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con1);
            da.Fill(dt);

            NombreUsers.DataSource = dt;
            NombreUsers.DataTextField = "nombreuser";
            NombreUsers.DataValueField = "iduser";
            NombreUsers.DataBind();

            con1.Close();

            if (!IsPostBack)
            {
                prevPage = Request.UrlReferrer.ToString();
            }
        }

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

        protected void Send_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            //tener id_buzon
            int idbuzon = 0;

            string strSQL = "SELECT id_buzon FROM BuzonEntrada WHERE id_usuario='" + NombreUsers.SelectedValue + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();
            while (d1.Read())
            {
                idbuzon = int.Parse(d1["id_buzon"].ToString());
            }
            d1.Close();

            string qry2 = "INSERT INTO MensajePrivado ([id_buzon],[id_remitente],[leido],[mensaje],[fecha_de_envio],[asunto]) VALUES ('" + idbuzon + "','" + GetID() + "',0,'" + Message.Text + "',GETDATE(),'" + Asunto.Text + "')";
            SqlCommand myCommand2 = new SqlCommand(qry2, con1);
            SqlDataReader d2 = myCommand2.ExecuteReader();
            d2.Close();

            con1.Close();

            Response.Redirect(prevPage);
        }
    }
}