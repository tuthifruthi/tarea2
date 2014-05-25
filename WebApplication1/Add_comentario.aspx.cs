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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Responder_Click(object sender, EventArgs e)
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

            string qry2 = "INSERT INTO Comentario ([id_tema],[id_usuario],[mensaje]) VALUES ('" + Request.QueryString["IDTema"] + "','" + iduser + "','" + Message.Text + "')";
            SqlCommand myCommand2 = new SqlCommand(qry2, con1);
            SqlDataReader d2 = myCommand2.ExecuteReader();
            d2.Close();

            string qry3 = "UPDATE Usuario SET cantidad_comentarios=(cantidad_comentarios+1) WHERE id_usuario='"+iduser+"'";
            SqlCommand myCommand3 = new SqlCommand(qry3, con1);
            SqlDataReader d3 = myCommand3.ExecuteReader();
            d2.Close();

            con1.Close();


            string message = string.Empty;
            message = "Se ha agregado el comentario exitosamente!.";
            Response.Redirect("~/Default.aspx");

            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        }
    }
}