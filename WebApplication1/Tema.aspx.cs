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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString);

            if (Session["is_logged_in"] != null && Session["is_logged_in"].Equals(true)) //si esta logueado, que muestre los temas privados
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tema WHERE id_categoria='" + Request.QueryString["IDCat"] + "'", cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Tema");
                Repeater2.DataSource = ds.Tables["Tema"];
                Repeater2.DataBind();
                Repeater3.DataSource = ds.Tables["Tema"];
                Repeater3.DataBind();

                SqlDataAdapter da1 = new SqlDataAdapter("SELECT nombre FROM Usuario WHERE id_usuario IN (SELECT id_usuario FROM Tema WHERE id_categoria='" + Request.QueryString["IDCat"] + "')", cnn);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "Usuario");
                Repeater4.DataSource = ds1.Tables["Usuario"];
                Repeater4.DataBind();

                SqlDataAdapter da2 = new SqlDataAdapter("SELECT nombre FROM Categoria WHERE id_categoria='" + Request.QueryString["IDCat"] + "'", cnn);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2, "Categoria");
                Repeater5.DataSource = ds2.Tables["Categoria"];
                Repeater5.DataBind();

                SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM Tema WHERE id_categoria='" + Request.QueryString["IDCat"] + "'", cnn);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3, "Tema");
                Repeater1.DataSource = ds.Tables["Tema"];
                Repeater1.DataBind();
            }

            else //si no esta logueado, que muestre los temas publicos
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tema WHERE id_categoria='" + Request.QueryString["IDCat"] + "' AND publico='0'", cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Tema");
                Repeater2.DataSource = ds.Tables["Tema"];
                Repeater2.DataBind();
                Repeater3.DataSource = ds.Tables["Tema"];
                Repeater3.DataBind();

                SqlDataAdapter da1 = new SqlDataAdapter("SELECT nombre FROM Usuario WHERE id_usuario IN (SELECT id_usuario FROM Tema WHERE id_categoria='" + Request.QueryString["IDCat"] + "' AND publico='0')", cnn);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "Usuario");
                Repeater4.DataSource = ds1.Tables["Usuario"];
                Repeater4.DataBind();

                SqlDataAdapter da2 = new SqlDataAdapter("SELECT nombre FROM Categoria WHERE id_categoria='" + Request.QueryString["IDCat"] + "'", cnn);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2, "Categoria");
                Repeater5.DataSource = ds2.Tables["Categoria"];
                Repeater5.DataBind();

                SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM Tema WHERE id_categoria='" + Request.QueryString["IDCat"] + "' AND publico='0'", cnn);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3, "Tema");
                Repeater1.DataSource = ds.Tables["Tema"];
                Repeater1.DataBind();
            }
        }
    }
}