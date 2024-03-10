using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collage_Managment_System.Material
{
    public partial class Show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                ListItem listItem1 = new ListItem()
                {
                    Value = "-1",

                    Text = "اختر القسم",
                    Selected = true,
                };
                departmentDDL.Items.Add(listItem1);

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
        }

        protected void departmentDDL_TextChanged(object sender, EventArgs e)
        {


            if (departmentDDL.SelectedValue != "-1")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = con;
                command.CommandText = "SELECT * FROM material where DebId= " + departmentDDL.SelectedValue;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var x = reader[1].ToString() + " \n ";
                    var y = reader[2].ToString() + " \n ";
                    var z = reader[3].ToString() + " \n ";
                    var q = reader[4].ToString() + " \n ";
                    while (reader.Read())
                    {
                        x += reader[1].ToString() + " \n ";
                        y += reader[2].ToString() + " \n ";
                        z += reader[3].ToString() + " \n ";
                        q += reader[4].ToString() + " \n ";
                    }


                    Label1.InnerText = x;
                    Label2.InnerText = y;
                    Label3.InnerText = z;
                    Label4.InnerText = q;


                }
                else
                {
                    Label1.InnerText = "لا يوجد";
                    Label2.InnerText = "لا يوجد";
                    Label3.InnerText = "لا يوجد";
                    Label4.InnerText = "لا يوجد";
                }

                reader.Close();
            }
            else
            {
                Label1.InnerText = "";
                Label2.InnerText = "";
                Label3.InnerText = "";
                Label4.InnerText = "";
            }
        }



    }
    
}