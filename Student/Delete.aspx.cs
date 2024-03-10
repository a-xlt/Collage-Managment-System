using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collage_Managment_System.Student
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
            command.CommandText = "delete FROM Student where id = " + StudentDDL.SelectedValue;
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                errorLB.Text = "تم حذف الطالب ";
                errorLB.Visible = true;
                errorLB.CssClass = "alert alert-success h3";
            }
        }

        protected void SearchBTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "SELECT Id , Name FROM Student Where Id= "+idSearch.Text;
            SqlDataReader reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                    StudentDDL.Items.Clear();
                ListItem listItem = new ListItem()
                {
                    Value = reader[0].ToString(),

                    Text = reader[1].ToString()
                };


                StudentDDL.Items.Add(listItem);
            }
        }
    }
}