﻿using System;
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
    public partial class _Default : System.Web.UI.Page
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
            if (Session["is_logged_in"] != null && Session["is_logged_in"].Equals(true))
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Categoria", cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Categoria");
                Repeater1.DataSource = ds.Tables["Categoria"];
                Repeater1.DataBind();
                Repeater2.DataSource = ds.Tables["Categoria"];
                Repeater2.DataBind();

            }

            else
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Categoria WHERE publico=0", cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Categoria");
                Repeater1.DataSource = ds.Tables["Categoria"];
                Repeater1.DataBind();
            }

        }

        protected void MP_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MP.aspx", true);
        }

        protected void Profile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/profile.aspx", true);
        }
    }
}
