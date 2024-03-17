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
    public partial class Add : System.Web.UI.Page
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
                debDDL.Items.Clear();
                ListItem listItem1 = new ListItem()
                {
                    Value = "-1",

                    Text = "اختر القسم",
                    Selected = true,
                };
                debDDL.Items.Add(listItem1);
                while (reader.Read())
                {
                    ListItem listItem = new ListItem()
                    {
                        Value = reader[0].ToString(),

                        Text = reader[1].ToString()
                    };


                    debDDL.Items.Add(listItem);
                }
            }
        }

        protected void saveBTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();

            
                SqlCommand command2 = new SqlCommand();
                command2.CommandType = CommandType.Text;
                command2.Connection = con;
                command2.CommandText = "select Id from Student";
                SqlDataReader sqlDataReader = command2.ExecuteReader();
                int id_str;
                if (sqlDataReader.Read())
                     id_str = Convert.ToInt32(sqlDataReader[0]);
                
                else
                    id_str=0;
                sqlDataReader.Close();
            
            id_str += 1;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "INSERT INTO Student Values(N'"+STUnameTXT.Text.Trim()+ "' , N'"+STUbirthdayTXT.Text+ "' ,"+debDDL.SelectedValue+" ,"+stageTXT.Text+", N'"+genderDDL.SelectedValue+"' , N'"+phoneXT.Text+ "',N'964-010-"+debDDL.SelectedValue+"-"+id_str.ToString()+"')";
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                errorLB.Visible = true;
                errorLB.Text = "تم اضافة طالب جديد : " +STUnameTXT.Text;
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