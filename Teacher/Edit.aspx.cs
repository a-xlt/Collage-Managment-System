using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace Collage_Managment_System.Teacher
{
    public partial class Edit : System.Web.UI.Page
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
            command.CommandText = "SELECT * FROM Teacher where id= " + idSearch.Text.Trim();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {

                teachrNameTXT.Text = reader[1].ToString();
                TaecherbirthdayTXT.Text = reader[2].ToString();
                genderDDL.SelectedValue = reader[4].ToString();
                phoneXT.Text = reader[5].ToString();
                specTXT.Text = reader[7].ToString();
                
                materialddl.Items.Clear();
                materialddl.SelectedValue = reader[6].ToString();
                
                SqlCommand command2 = new SqlCommand();
                command2.CommandType = CommandType.Text;
                command2.Connection = con;
                command2.CommandText = "SELECT * FROM Material where DebId= " + reader[3].ToString();
                reader.Close();

                SqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    ListItem listItem = new ListItem()
                    {
                        Value = reader2[0].ToString(),
                        Text = reader2[1].ToString()
                    };
                    materialddl.Items.Add(listItem);
                }

            }
            else
            {
                teachrNameTXT.Text ="";
                TaecherbirthdayTXT.Text ="";
                genderDDL.SelectedValue ="";
                phoneXT.Text ="";
                materialddl.SelectedValue ="";
                specTXT.Text ="";

                errorLB.Text = "لايوجد استاذ ";
                errorLB.Visible = true;
                errorLB.CssClass = "alert alert-danger h3";
                errorLB.Focus();
            }
        }

        protected void saveBTN_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "Update Teacher Set [Name]=N'" + teachrNameTXT.Text + "' , Birthdate=N'" + TaecherbirthdayTXT.Text + "' Gender =N'" + genderDDL.SelectedValue + "' , Phone_Number=N'" + phoneXT.Text + "' ,[Metrial]='"+materialddl.SelectedValue+"' ,[spec]='"+specTXT.Text+"'   where id = " + idSearch.Text;
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                errorLB.Visible = true;
                errorLB.Text = "تم تعديل بيانات الاستاذ : " + teachrNameTXT.Text;
                errorLB.CssClass = "alert alert-success h3";
            }
            else
            {
                errorLB.Visible = true;
                errorLB.Text = "حدث خطأ";
                errorLB.CssClass = "alert alert-danger h3";
            }
        }
    }
}