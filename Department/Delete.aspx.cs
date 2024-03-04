using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collage_Managment_System.Department
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "SELECT * FROM Department";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
             {
                ListItem listItem = new ListItem (){Value= reader[0].ToString(),

                    Text = reader[1].ToString()
                };
              
                
                departmentDDL.Items.Add(listItem);
            }
            
        }

        protected void departmentDDL_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void DeleteBTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "delete from Classroom where Debid = "+ departmentDDL.SelectedValue + 
                ";delete from Material where DebId="+ departmentDDL.SelectedValue + 
                ";delete from Schedule where  DebId="+ departmentDDL.SelectedValue + 
                ";delete from Student where  Deb="+ departmentDDL.SelectedValue + 
                ";delete from Teacher where  Deb="+ departmentDDL.SelectedValue + 
                "  ;delete FROM Department where id = " + departmentDDL.SelectedValue;
            int x= command.ExecuteNonQuery();
            if (x > 0)
            {
                errorLB.Text = "تم حذف القسم ";
                errorLB.Visible = true;
                errorLB.CssClass = "alert alert-success h3";
            }


        }
    }
}