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
                        Response.Redirect("~/Default.aspx");
                        break;
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
            
               

        }

    }
}
