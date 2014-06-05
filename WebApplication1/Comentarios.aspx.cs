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
    public partial class WebForm2 : System.Web.UI.Page
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT mensaje FROM Comentario WHERE id_tema='" + Request.QueryString["IDTema"]+ "'", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Tema");
            Repeater1.DataSource = ds.Tables["Tema"];
            Repeater1.DataBind();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM Tema WHERE id_tema='" + Request.QueryString["IDTema"] + "'", cnn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "Tema");
            Repeater5.DataSource = ds2.Tables["Tema"];
            Repeater5.DataBind();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT nombre FROM Usuario WHERE id_usuario IN (SELECT id_usuario FROM Comentario WHERE id_tema='" + Request.QueryString["IDTema"] + "')", cnn);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "Usuario");
            Repeater4.DataSource = ds1.Tables["Usuario"];
            Repeater4.DataBind();

            SqlDataAdapter da3 = new SqlDataAdapter("SELECT avatar_url FROM Usuario WHERE id_usuario IN (SELECT id_usuario FROM Comentario WHERE id_tema='" + Request.QueryString["IDTema"] + "')", cnn);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "Usuario");
            Repeater2.DataSource = ds3.Tables["Usuario"];
            Repeater2.DataBind();

            SqlDataAdapter da4 = new SqlDataAdapter("SELECT id_comentario FROM Comentario WHERE id_tema='" + Request.QueryString["IDTema"] + "'", cnn);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4, "Comentario");
            Repeater3.DataSource = ds4.Tables["Comentario"];
            Repeater3.DataBind();

        }

    }
}