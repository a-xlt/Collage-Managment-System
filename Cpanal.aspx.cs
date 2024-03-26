using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;

namespace Collage_Managment_System
{
    public partial class Cpanal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                functionDDl.SelectedValue = "-1";

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = con;
                command.CommandText = "SELECT * FROM Department";
                SqlDataReader reader = command.ExecuteReader();

                ListItem listItem1 = new ListItem()
                {
                    Value = "-1",

                    Text = "اختر القسم",
                    Selected = true,
                };
                add_stu_deb.Items.Add(listItem1);
                show_stu_del_ddl.Items.Add(listItem1);
                del_deb_ddl.Items.Add(listItem1);
                add_mat_deb.Items.Add(listItem1);
                mat_del_deb.Items.Add(listItem1);
                show_mat_deb.Items.Add(listItem1);
                add_sch_deb.Items.Add(listItem1);
                add_grade_deb.Items.Add(listItem1);
                show_grade_deb.Items.Add(listItem1);

                while (reader.Read())
                {
                    ListItem listItem = new ListItem()
                    {
                        Value = reader[0].ToString(),

                        Text = reader[1].ToString()
                    };


                    add_stu_deb.Items.Add(listItem);
                    del_deb_ddl.Items.Add(listItem);
                    show_stu_del_ddl.Items.Add(listItem);
                    add_mat_deb.Items.Add(listItem);
                    mat_del_deb.Items.Add(listItem);
                    show_mat_deb.Items.Add(listItem);
                    add_sch_deb.Items.Add(listItem);
                    show_grade_deb.Items.Add(listItem);
                    add_grade_deb.Items.Add(listItem);
                }


            }
        }

        protected void functionDDl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (functionDDl.SelectedValue == "-1")
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
                add_stu_errorLB.Visible = true;
                add_stu_errorLB.Text = "تم اضافة طالب جديد : " + Add_stu_Name.Text;
                add_stu_errorLB.CssClass = "alert alert-success ";
            }
            else
            {
                add_stu_errorLB.Visible = true;
                add_stu_errorLB.Text = "حدث خطأ";
                add_stu_errorLB.CssClass = "alert alert-danger ";
            }
        }

        protected void del_stu_SearchBTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "select Id , Name from  Student where Id_str ='" + del_stu_idSearch.Text.Trim() + "' OR [Name] = '% " + del_stu_idSearch.Text.Trim() + " %'";
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                del_stu_DDL.Items.Clear();
                ListItem listItem = new ListItem()
                {
                    Value = reader[0].ToString(),

                    Text = reader[1].ToString()
                };


                del_stu_DDL.Items.Add(listItem);
            }
        }

        protected void del_stu_BTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "delete FROM Student where id = " + del_stu_DDL.SelectedValue;
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                del_stu_errorLB.Text = "تم حذف الطالب ";
                del_stu_errorLB.Visible = true;
                del_stu_errorLB.CssClass = "alert alert-success";
            }
        }

        protected void del_deb_BTN_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = 
                ";delete from Material where DebId=" + del_deb_ddl.SelectedValue +
                ";delete from Schedule where  DebId=" + del_deb_ddl.SelectedValue +
                ";delete from Student where  Deb=" + del_deb_ddl.SelectedValue +
                ";delete FROM Department where id = " + del_deb_ddl.SelectedValue;
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                del_deb_errorLB.Text = "تم حذف القسم ";
                del_deb_errorLB.Visible = true;
                del_deb_errorLB.CssClass = "alert alert-success";
            }

        }

        protected void deb_add_BTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "INSERT INTO Department VALUES(N'" + deb_add_name.Value + "')";
            int x = command.ExecuteNonQuery();
            con.Close();
            if (x > 0)
            {
                deb_add_errorLB.Visible = true;
                deb_add_errorLB.Text = "تم اضافة قسم جديد : " + deb_add_name.Value;
                deb_add_errorLB.CssClass = "alert alert-success ";
            }
            else
            {
                deb_add_errorLB.Visible = true;
                deb_add_errorLB.Text = "حدث خطأ";
                deb_add_errorLB.CssClass = "alert alert-danger ";
            }
        }

        protected void add_mat_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "INSERT INTO Material Values(N'" + add_mat_Name.Text.Trim() + "' ," + add_mat_UnitNumber.Text.Trim() + " ," + add_mat_th.Text.Trim() + " , " + add_mat_lab.Text.Trim() + ", " + add_mat_stage.Text.Trim() + " , " + add_mat_deb.SelectedValue + " )";
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                add_mat_error.Visible = true;
                add_mat_error.Text = "تم اضافة مادة جديدة : " + add_mat_Name.Text;
                add_mat_error.CssClass = "alert alert-success ";
            }
            else
            {
                add_mat_error.Visible = true;
                add_mat_error.Text = "حدث خطأ";
                add_mat_error.CssClass = "alert alert-danger ";
            }
        }

        protected void mat_del_search_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "SELECT * FROM Material where DebId = " + mat_del_deb.SelectedValue;
            SqlDataReader reader = command.ExecuteReader();
            mat_del_ddl.Items.Clear();
            while (reader.Read())
            {
                ListItem listItem = new ListItem()
                {
                    Value = reader[0].ToString(),

                    Text = reader[1].ToString()
                };


                mat_del_ddl.Items.Add(listItem);
            }
        }

        protected void mat_del_delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "delete from Material where Id =" + mat_del_ddl.SelectedValue;
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                mat_del_errorLB.Visible = true;
                mat_del_errorLB.Text = "تم حذف المادة الدراسية  : " + mat_del_ddl.SelectedItem;
                mat_del_errorLB.CssClass = "alert alert-success";
            }
            else
            {
                mat_del_errorLB.Visible = true;
                mat_del_errorLB.Text = "حدث خطأ";
                mat_del_errorLB.CssClass = "alert alert-danger ";
            }
        }

        protected void add_sch_deb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (add_sch_deb.SelectedValue != "-1")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = con;
                command.CommandText = "SELECT * FROM Material where DebId = " + add_sch_deb.SelectedValue + " AND Stage = " + add_sch_stage.SelectedValue;
                SqlDataReader reader = command.ExecuteReader();
                add_sch_mat.Items.Clear();
                while (reader.Read())
                {
                    ListItem listItem = new ListItem()
                    {
                        Value = reader[0].ToString(),

                        Text = reader[1].ToString()
                    };


                    add_sch_mat.Items.Add(listItem);
                }
            }
        }

        protected void add_sch_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "INSERT INTO Schedule Values(N'"+add_sch_from.Text.Trim()+"' , N'"+ add_sch_to.Text.Trim() + "',"+ add_sch_stage.SelectedValue + " , "+ add_sch_deb.SelectedValue+ " ,"+ add_sch_mat.SelectedValue+ " ,N'"+ add_sch_Teacher.Text.Trim() + "', N'"+ add_sch_note.Text.Trim() + "' , N'"+ add_sch_day.SelectedValue+ "')";
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                add_sch_error.Visible = true;
                add_sch_error.Text = "تم اضافة جدول جديد : " ;
                add_sch_error.CssClass = "alert alert-success ";
            }
            else
            {
                add_sch_error.Visible = true;
                add_sch_error.Text = "حدث خطأ";
                    add_sch_error.CssClass = "alert alert-danger ";
            }
        }

        protected void add_grade_deb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (add_grade_deb.SelectedValue != "-1")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = con;
                command.CommandText = "SELECT * FROM Student where Deb = " + add_grade_deb.SelectedValue + " AND Stage = " + add_grade_stage.SelectedValue;
                SqlDataReader reader = command.ExecuteReader();
                add_grade_student.Items.Clear();
                add_grade_mat.Items.Clear();

                while (reader.Read())
                {
                    ListItem listItem = new ListItem()
                    {
                        Value = reader[0].ToString(),

                        Text = reader[1].ToString()
                    };


                    add_grade_student.Items.Add(listItem);
                }
                reader.Close();
                command.CommandText = "SELECT * FROM Material where DebId = " + add_grade_deb.SelectedValue + " AND Stage = " + add_grade_stage.SelectedValue;
                SqlDataReader reader2 = command.ExecuteReader();
                add_grade_mat.Items.Clear();
                while (reader2.Read())
                {
                    ListItem listItem = new ListItem()
                    {
                        Value = reader2[0].ToString(),

                        Text = reader2[1].ToString()
                    };


                    add_grade_mat.Items.Add(listItem);
                }

            }

            else
            {
                add_grade_student.Items.Clear();
                add_grade_mat.Items.Clear();
            }
        }

        protected void add_grade_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "INSERT INTO Grade Values("+ add_grade_grade.Text.Trim()+ " , "+ add_grade_student.SelectedValue+ " , "+ add_grade_mat.SelectedValue+ " )";
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                add_grade_error.Visible = true;
                add_grade_error.Text = "تم اضافة  درجة الطالب  ";
                add_grade_error.CssClass = "alert alert-success ";
            }
            else
            {
                add_grade_error.Visible = true;
                add_grade_error.Text = "حدث خطأ";
                add_grade_error.CssClass = "alert alert-danger ";
            }
        }

        protected void show_grade_deb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "SELECT * FROM Material where DebId = " + show_grade_deb.SelectedValue + " AND Stage = " + show_grade_stage.SelectedValue;
            SqlDataReader reader = command.ExecuteReader();
           
           show_grade_mat.Items.Clear();

            while (reader.Read())
            {
                ListItem listItem = new ListItem()
                {
                    Value = reader[0].ToString(),

                    Text = reader[1].ToString()
                };


               show_grade_mat.Items.Add(listItem);
            }
        }
    }
}