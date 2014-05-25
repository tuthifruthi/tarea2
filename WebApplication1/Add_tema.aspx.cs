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
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Crear_Click(object sender, EventArgs e)
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

            if (Publico.SelectedItem.Text.Equals("Publico"))
            {
                string qry2 = "INSERT INTO Tema ([id_categoria],[id_usuario],[nombre],[descripcion],[mensaje],[publico]) VALUES ('" + Request.QueryString["IDCat"] + "','" + iduser + "','" + ThemeName.Text + "','" + Descr.Text + "','" + Message.Text + "',0)";
                SqlCommand myCommand2 = new SqlCommand(qry2, con1);
                SqlDataReader d2 = myCommand2.ExecuteReader();
                d2.Close();
                con1.Close();

                Response.Redirect("~/Default.aspx");
            }

            else
            {
                string qry2 = "INSERT INTO Tema ([id_categoria],[id_usuario],[nombre],[descripcion],[mensaje],[publico]) VALUES ('" + Request.QueryString["IDCat"] + "','" + iduser + "','" + ThemeName.Text + "','" + Descr.Text + "','" + Message.Text + "',1)";
                SqlCommand myCommand2 = new SqlCommand(qry2, con1);
                SqlDataReader d2 = myCommand2.ExecuteReader();
                d2.Close();
                con1.Close();

                Response.Redirect("~/Default.aspx");
            }
           
        }

    }
}