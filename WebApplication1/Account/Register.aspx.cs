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

namespace WebApplication1.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int idusuario = 0;
            string constr = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("InsertUser"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre",UserName.Text);
                        cmd.Parameters.AddWithValue("@contrasena", Password.Text);
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", BirthDate.Text);
                        cmd.Parameters.AddWithValue("@avatar_url", AvURL.Text);
                        cmd.Parameters.AddWithValue("@sexo", Gender1.SelectedItem.Text);
                        cmd.Connection = con;
                        con.Open();
                        idusuario = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                string message = string.Empty;
                switch (idusuario)
                {
                    case -1:
                        message = "El nombre de usuario esta siendo utilizado, por favor escoja otro.";
                        break;
                    default:
                        message = "Se ha registrado exitosamente!.";
                        string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
                        SqlConnection con1 = new SqlConnection(conString);
                        con1.Open();

                        int iduser = 0;

                        string strSQL = "SELECT id_usuario FROM Usuario WHERE nombre='" + UserName.Text + "'";
                        SqlCommand myCommand = new SqlCommand(strSQL, con1);
                        SqlDataReader d1 = myCommand.ExecuteReader();
                        while (d1.Read())
                          {
                            iduser = int.Parse(d1["id_usuario"].ToString());
                          }
                         d1.Close();


                        string qry2 = "INSERT INTO BuzonEntrada ([id_usuario],[mensajes_sin_leer],[mensajes]) VALUES ('" + iduser + "',0,0)";
                        SqlCommand myCommand2 = new SqlCommand(qry2, con1);
                        SqlDataReader d2 = myCommand2.ExecuteReader(); 
                        d2.Close();

                        con1.Close();
                        Response.Redirect("~/Default.aspx");
                        break;
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
            
               

        }

    }
}
