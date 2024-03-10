﻿using System;
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

            var y  = 0;
            if (reader.Read())
            {
                y++;

                while (reader.Read())
                {
                    y++;
                }
                Label2.Text = y.ToString();
            }
            else
                Label2.Text = "0";

            reader.Close();


            command.CommandText = "SELECT * FROM Material where DebId = " + departmentDDL.SelectedValue;
            reader = command.ExecuteReader();

            var z  = 0;
            if (reader.Read())
            {
                z++;

                while (reader.Read())
                {
                   z++;
                }
                Label3.Text = z.ToString();
            }
            else
                Label3.Text = "0";


            reader.Close();

             command.CommandText = "SELECT * FROM Classroom where DebID = " + departmentDDL.SelectedValue;
            reader = command.ExecuteReader();

            var c  = 0;
            if (reader.Read())
            {
                c++;

                while (reader.Read())
                {
                   c++;
                }
                Label4.Text = c.ToString();
            }
            else
                Label4.Text = "0";


            reader.Close();



        }
    }
}
