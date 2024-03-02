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
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveBTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "Update Student Set [Name]=N'"+STUnameTXT.Text+ "' , Birthdate=N'" + STUbirthdayTXT.Text+"' , Stage= "+stageTXT.Text+" ,Gender =N'"+genderDDL.SelectedValue+ "' , Phone_Number=N'" + phoneXT.Text+"' where id = "+idSearch.Text;
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                errorLB.Visible = true;
                errorLB.Text = "تم تعديل بيانات الطالب : " + STUnameTXT.Text;
                errorLB.CssClass = "alert alert-success h3";
            }
            else
            {
                errorLB.Visible = true;
                errorLB.Text = "حدث خطأ";
                errorLB.CssClass = "alert alert-danger h3";
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
            command.CommandText = "SELECT * FROM Student where id= "+idSearch.Text.Trim();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                STUnameTXT.Text = reader[1].ToString();
                STUbirthdayTXT.Text = reader[2].ToString();
                stageTXT.Text = reader[4].ToString();
                genderDDL.SelectedValue = reader[5].ToString();
                phoneXT.Text = reader[6].ToString();
            }
            else {
                STUnameTXT.Text = "";
                STUbirthdayTXT.Text = "";
                stageTXT.Text = "";
                genderDDL.SelectedValue = "";
                phoneXT.Text = "";

                errorLB.Text = "لايوجد طالب ";
                errorLB.Visible = true;
                errorLB.CssClass = "alert alert-danger h3";
                errorLB.Focus();
            }
        }
    }
}