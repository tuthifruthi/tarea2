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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            int idusuario = 0;
            string constr = ConfigurationManager.ConnectionStrings["foromagic"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("LoginUser"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", UserName.Text);
                        cmd.Parameters.AddWithValue("@contrasena", Password.Text);
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
                        message = "Se ha logueado exitosamente!.";
                        Session["is_logged_in"] = true;
                        Session["UserName"] = UserName.Text;
                        Session["Passw"] = Password.Text;
                        Response.Redirect("/WebApplication1/Default.aspx");
                        break;
                    default:
                        message = "El nombre de usuario no existe dentro del sistema.";
                        break;
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
        }
    }
}

