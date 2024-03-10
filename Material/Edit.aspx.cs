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
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = con;
                command.CommandText = "SELECT * FROM Department";
                SqlDataReader reader = command.ExecuteReader();
                debDDL.Items.Clear();
                ListItem listItem = new ListItem()
                {
                    Value = "-1",

                    Text = "اختر القسم"
                };

                debDDL.Items.Add(listItem);

                while (reader.Read())
                {
                    listItem = new ListItem()
                    {
                        Value = reader[0].ToString(),

                        Text = reader[1].ToString()
                    };


                    debDDL.Items.Add(listItem);
                }
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
            command.CommandText = "SELECT * FROM Material where id= " + matDDL.SelectedValue;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                matnameTXT.Text = reader[1].ToString();
                unitNumberTXT.Text = reader[2].ToString();
                primaryOrSecoundryddl.SelectedValue = reader[3].ToString();
                stageddl.SelectedValue = reader[4].ToString();
            }
            else
            {
                matnameTXT.Text ="";
                unitNumberTXT.Text = "";
                primaryOrSecoundryddl.SelectedValue = "";
                stageddl.SelectedValue = "";

                errorLB.Text = "لايوجد طالب ";
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
            command.CommandText = "Update Material Set [Name]=N'" + matnameTXT.Text + "' , Unit_Numbers=" + unitNumberTXT.Text + " , PrimaryOrSecondary= " + primaryOrSecoundryddl.SelectedValue + " ,Stage = " + stageddl.SelectedValue + "  where Id = " +matDDL.SelectedValue ;
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                errorLB.Visible = true;
                errorLB.Text = "تم تعديل بيانات المادة : " + matnameTXT.Text;
                errorLB.CssClass = "alert alert-success h3";
                matnameTXT.Text = "";
                unitNumberTXT.Text = "";
            }
            else
            {
                errorLB.Visible = true;
                errorLB.Text = "حدث خطأ";
                errorLB.CssClass = "alert alert-danger h3";
                matnameTXT.Text = "";
                unitNumberTXT.Text = "";
            }
        }

        protected void debDDL_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "SELECT * FROM Material where DebId =" +debDDL.SelectedValue;
            SqlDataReader reader = command.ExecuteReader();
            matDDL.Items.Clear();
            
            while (reader.Read())
            {
               ListItem listItem = new ListItem()
                {
                    Value = reader[0].ToString(),

                    Text = reader[1].ToString()
                };


                matDDL.Items.Add(listItem);
            }
            matnameTXT.Text = "";
            unitNumberTXT.Text = "";
        }
    }
}