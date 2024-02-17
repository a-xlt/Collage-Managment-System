using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collage_Managment_System
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = UserName.Value;
            string password = Password.Value;

            SqlConnection con = new SqlConnection();
            SqlCommand command = new SqlCommand();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from Users where UserName = '"+username +"' and Password = '"+password+"' ";
            con.Open();
            command.Connection = con;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Session["Name"] = reader["Name"].ToString();
                Session["Privilage"] = reader["Privilage"].ToString();
                Response.Redirect("Admin.aspx");
            }
            else
                ClientScript.RegisterClientScriptBlock(this.GetType(), "x3", "alert('المعلومات خطأ');", true);

        }
    }
}