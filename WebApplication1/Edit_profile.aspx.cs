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
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            usergroup.Text = GetTipo();
            username.Text = Session["UserName"].ToString();

            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL = "SELECT sexo FROM Usuario WHERE nombre='" + Session["UserName"].ToString() + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();
            string sex = "";
            while (d1.Read())
            {
                 sex= d1["sexo"].ToString();
            }

            sex1.Text = sex;
        }

        public string GetTipo()
        {
            string conString = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();

            string strSQL = "SELECT id_grupo FROM Usuario WHERE nombre='" + Session["UserName"].ToString() + "'";
            SqlCommand myCommand = new SqlCommand(strSQL, con1);
            SqlDataReader d1 = myCommand.ExecuteReader();
            int grupo = 0;
            while (d1.Read())
            {
                grupo = int.Parse(d1["id_grupo"].ToString());
            }
            d1.Close();

            string group = "";

            if (grupo == 1)
            {
                group = "Administrador";
            }

            else if (grupo == 2)
            {
                group = "Moderador";
            }

            else if (grupo == 3)
            {
                group = "Usuario Común";
            }
            
            return group;
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            if(Passw.Text.Equals(RepeatPassw.Text) && (Session["Passw"].ToString().Equals(Passw.Text)))
            {
                 string commandText = "UPDATE Usuario SET avatar_url = @avatar_url, fecha_nacimiento=@fechanac "
       + "WHERE nombre='" + Session["UserName"].ToString() + "'";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@avatar_url", AvURL.Text);
                command.Parameters.AddWithValue("@fechanac", BirthDate.Text);

                try
                {
                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                    Response.Redirect("~/profile.aspx");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            }
            
            else if(!(Passw.Text.Equals(RepeatPassw.Text)))
            {
                string message = string.Empty;
                message = "Las contraseñas ingresadas no son iguales.";

            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }

            else if(!(Session["Passw"].ToString().Equals(Passw.Text)))
            {
                string message = string.Empty;
                message = "La contraseña ingresada no coincide con la del usuario.";

            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
        }
    }
}