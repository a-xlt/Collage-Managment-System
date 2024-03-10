using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collage_Managment_System.Teacher
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchBTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "SELECT Id , Name FROM Teacher Where Id= " + idSearch.Text;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                TeacherDDL.Items.Clear();
                ListItem listItem = new ListItem()
                {
                    Value = reader[0].ToString(),

                    Text = reader[1].ToString()
                };


                TeacherDDL.Items.Add(listItem);
            }
        }

        protected void DeleteBTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "delete FROM Teacher where id = " + TeacherDDL.SelectedValue;
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                errorLB.Text = "تم حذف الاستاذ ";
                errorLB.Visible = true;
                errorLB.CssClass = "alert alert-success h3";
            }
        }
    }
}