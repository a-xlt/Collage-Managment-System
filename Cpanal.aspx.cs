using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collage_Managment_System
{
    public partial class Cpanal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                functionDDl.SelectedValue = "-1";  
            }
        }

        protected void functionDDl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (functionDDl.SelectedValue=="-1")
            {
                CollapaseAll();
            }
            else
            {
                CollapaseAll();
                string Cnumber = functionDDl.SelectedValue;
                if (Cnumber == "1") { function1.Visible = true; }
                if (Cnumber == "2") { function2.Visible = true; }
                if (Cnumber == "3") { function3.Visible = true; }
                if (Cnumber == "4") { function4.Visible = true; }
                if (Cnumber == "5") { function5.Visible = true; }
                if (Cnumber == "6") { function6.Visible = true; }
                if (Cnumber == "7") { function7.Visible = true; }
                if (Cnumber == "8") { function8.Visible = true; }
                if (Cnumber == "9") { function9.Visible = true; }
                if (Cnumber == "10") { function10.Visible = true; }
                if (Cnumber == "11") { function11.Visible = true; }
                if (Cnumber == "12") { function12.Visible = true; }
            }
        }


        void CollapaseAll()
        {
            function1.Visible = false;
            function2.Visible = false;
            function3.Visible = false;
            function4.Visible = false;
            function5.Visible = false;
            function6.Visible = false;
            function7.Visible = false;
            function8.Visible = false;
            function9.Visible = false;
            function10.Visible = false;
            function11.Visible = false;
            function12.Visible = false;
        }

        protected void Add_stu_saveBTN_Click(object sender, EventArgs e)
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
                id_str = 0;
            sqlDataReader.Close();

            id_str += 1;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "INSERT INTO Student Values(N'" + Add_stu_Name.Text.Trim() + "' , N'" + Add_stu_birthday.Text + "' ," + add_stu_deb.SelectedValue + " ," + Add_stu_Stage.Text + ", N'" + Add_stu_gender.SelectedValue + "' , N'" + Add_stu_phone.Text + "',N'964-010-" + add_stu_deb.SelectedValue + "-" + id_str.ToString() + "')";
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                errorLB.Visible = true;
                errorLB.Text = "تم اضافة طالب جديد : " + Add_stu_Name.Text;
                errorLB.CssClass = "alert alert-success ";
            }
            else
            {
                errorLB.Visible = true;
                errorLB.Text = "حدث خطأ";
                errorLB.CssClass = "alert alert-danger ";
            }
        }
    }
}