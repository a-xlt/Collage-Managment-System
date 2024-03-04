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
    public partial class Show : System.Web.UI.Page
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
            departmentDDL.Items.Clear();

            while (reader.Read())
            {
                ListItem listItem = new ListItem()
                {
                    Value = reader[0].ToString(),

                    Text = reader[1].ToString()
                };


                departmentDDL.Items.Add(listItem);
            }

        }

        protected void searchBTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "SELECT * FROM Teacher where Deb=" + departmentDDL.SelectedValue;
            SqlDataReader reader = command.ExecuteReader();
            var x = 0;
            if (reader.Read())
            {
                x++;

                while (reader.Read())
                {
                    x++;
                }
                Label1.Text = x.ToString();
            }
            else
                Label1.Text = "0";
            reader.Close();


            command.CommandText = "SELECT * FROM Student  where Deb=" + departmentDDL.SelectedValue;
            reader = command.ExecuteReader();

            x = 0;
            if (reader.Read())
            {
                x++;

                while (reader.Read())
                {
                    x++;
                }
                Label2.Text = x.ToString();
            }
            else
                Label2.Text = "0";

            reader.Close();



            command.CommandText = "SELECT * FROM Material where DebId=" + departmentDDL.SelectedValue;
            reader = command.ExecuteReader();

            x = 0;
            if (reader.Read())
            {
                x++;

                while (reader.Read())
                {
                    x++;
                }
                Label3.Text = x.ToString();
            }
            else
                Label3.Text = "0";


            reader.Close();



        }
    }
}
