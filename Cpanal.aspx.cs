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
                show_stu_ddl.Items.Add(listItem1);
                del_deb_ddl.Items.Add(listItem1);
                add_mat_deb.Items.Add(listItem1);
                mat_del_deb.Items.Add(listItem1);
                show_mat_deb.Items.Add(listItem1);
                add_sch_deb.Items.Add(listItem1);
                add_grade_deb.Items.Add(listItem1);
                show_grade_deb.Items.Add(listItem1);
                show_sch_deb.Items.Add(listItem1);
                add_grp_deb.Items.Add(listItem1);

                while (reader.Read())
                {
                    ListItem listItem = new ListItem()
                    {
                        Value = reader[0].ToString(),

                        Text = reader[1].ToString()
                    };


                    add_stu_deb.Items.Add(listItem);
                    del_deb_ddl.Items.Add(listItem);
                    show_stu_ddl.Items.Add(listItem);
                    add_mat_deb.Items.Add(listItem);
                    mat_del_deb.Items.Add(listItem);
                    show_mat_deb.Items.Add(listItem);
                    add_sch_deb.Items.Add(listItem);
                    show_grade_deb.Items.Add(listItem);
                    add_grade_deb.Items.Add(listItem);
                    show_sch_deb.Items.Add(listItem);
                    add_grp_deb.Items.Add(listItem);
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
                if (Cnumber == "13") { function13.Visible = true; }
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
            function13.Visible = false;
        }

        protected void Add_stu_saveBTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();


            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.Text;
            command2.Connection = con;
            command2.CommandText = "select Id from Student order by Id desc";
            SqlDataReader sqlDataReader = command2.ExecuteReader();
            int id_str = 0;
            if (sqlDataReader.Read())
            { id_str = Convert.ToInt32(sqlDataReader["Id"].ToString()); }



            sqlDataReader.Close();

            id_str += 1;

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "INSERT INTO Student Values(N'" + Add_stu_Name.Text.Trim() + "' , N'" + Add_stu_birthday.Text + "' ," + add_stu_deb.SelectedValue + " ," + add_stu_group.SelectedValue + " ," + add_stu_stage.SelectedValue + ", N'" + Add_stu_gender.SelectedValue + "' , N'" + Add_stu_phone.Text + "',N'964-010-" + add_stu_deb.SelectedValue + "-" + id_str.ToString() + "')";
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



        protected void add_sch_save_Click(object sender, EventArgs e)
        {
            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con2.Open();
            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.Text;
            command2.Connection = con2;
            command2.CommandText = "SELECT * FROM Schedule where Stage = " + add_sch_stage.SelectedValue +" AND DayOrNight = '"+ add_sch_dayOrNight.SelectedValue+ "' AND DebID = " + add_sch_deb.SelectedValue + " AND Day = " + add_sch_day.SelectedValue + " AND FourOrThree = '" + add_sch_FourOrThree.SelectedValue + "' "; ;
            SqlDataReader reader2 = command2.ExecuteReader();


            if (!reader2.Read())
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = con;
                command.CommandText = "INSERT INTO Schedule Values(" + add_sch_stage.SelectedValue + " , " + add_sch_deb.SelectedValue +
                    " , '" + add_sch_dayOrNight.SelectedValue + "' , " + add_sch_day.SelectedValue + " , '" + add_sch_FourOrThree.SelectedValue +
                    "' , '" + add_sch_t1_from.Text + "' , '" + add_sch_t1_to.Text + "' , '" + add_sch_m1.SelectedItem + "' , '" + add_sch_i1.Text + "' , '" + add_sch_t2_from.Text +
                    "' , '" + add_sch_t2_to.Text + "' , '" + add_sch_m2.SelectedItem + "' , '" + add_sch_i2.Text + "' , '" + add_sch_t3_from.Text + "' ,' " + add_sch_t3_to.Text +
                    "' , '" + add_sch_m3.SelectedItem + "' , '" + add_sch_i3.Text + "' ,'" + add_sch_t4_from.Text + "' ,' " + add_sch_t4_to.Text + "' ,' " + add_sch_m4.SelectedItem +
                    "' , '" + add_sch_i4.Text + "' )";
                int x = command.ExecuteNonQuery();
                if (x > 0)
                {
                    add_sch_error.Visible = true;
                    add_sch_error.Text = "تم اضافة جدول جديد  ";
                    add_sch_error.CssClass = "alert alert-success ";
                }
                else
                {
                    add_sch_error.Visible = true;
                    add_sch_error.Text = "حدث خطأ";
                    add_sch_error.CssClass = "alert alert-danger ";
                }
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = con;
                command.CommandText = "delete from Schedule where Id = " + reader2[0].ToString() + ";INSERT INTO Schedule Values(" + add_sch_stage.SelectedValue + " , " + add_sch_deb.SelectedValue +
                    " , '" + add_sch_dayOrNight.SelectedValue + "' , " + add_sch_day.SelectedValue + " , '" + add_sch_FourOrThree.SelectedValue +
                    "' , '" + add_sch_t1_from.Text + "' , '" + add_sch_t1_to.Text + "' , '" + add_sch_m1.SelectedItem + "' , '" + add_sch_i1.Text + "' , '" + add_sch_t2_from.Text +
                    "' , '" + add_sch_t2_to.Text + "' , '" + add_sch_m2.SelectedItem + "' , '" + add_sch_i2.Text + "' , '" + add_sch_t3_from.Text + "' ,' " + add_sch_t3_to.Text +
                    "' , '" + add_sch_m3.SelectedItem + "' , '" + add_sch_i3.Text + "' ,'" + add_sch_t4_from.Text + "' ,' " + add_sch_t4_to.Text + "' ,' " + add_sch_m4.SelectedItem +
                    "' , '" + add_sch_i4.Text + "' )";
                int x = command.ExecuteNonQuery();
                if (x > 0)
                {
                    add_sch_error.Visible = true;
                    add_sch_error.Text = "تم اضافة جدول جديد  ";
                    add_sch_error.CssClass = "alert alert-success ";
                }
                else
                {
                    add_sch_error.Visible = true;
                    add_sch_error.Text = "حدث خطأ";
                    add_sch_error.CssClass = "alert alert-danger ";
                }
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
                add_grade_mat.Items.Add(new ListItem { Value = "-1", Text = "اختر المادة", Selected = true });

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

            command.CommandText = "SELECT * FROM Grade where StuID = " + add_grade_student.SelectedValue + "  AND MetID= " + add_grade_mat.SelectedValue;
            SqlDataReader reader = command.ExecuteReader();
            var finalgrade = (Convert.ToDouble(add_grade_g1.Text) + Convert.ToDouble(add_grade_g2.Text) + Convert.ToDouble(add_grade_g3.Text)) / 3;
            finalgrade += Convert.ToDouble(add_grade_absence.Text) + Convert.ToDouble(add_grade_plus.Text);
            if (reader.Read())
            {
                reader.Close();
                SqlConnection con2 = new SqlConnection();
                con2.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con2.Open();
                SqlCommand command2 = new SqlCommand();
                command2.CommandType = CommandType.Text;
                command2.Connection = con2;
                command2.CommandText = "Update Grade set [g1] = " + add_grade_g1.Text.Trim() +
                    ", [g2] = " + add_grade_g2.Text.Trim() +
                    ", [g3] = " + add_grade_g3.Text.Trim() +
                    ", [absence] = " + add_grade_absence.Text.Trim() +
                    ", [pluses] = " + add_grade_plus.Text.Trim() +
                    ", [FinalGrade] = " + finalgrade.ToString();
                int x = command2.ExecuteNonQuery();
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
            else
            {
                reader.Close();
                SqlConnection con2 = new SqlConnection();
                con2.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con2.Open();
                SqlCommand command2 = new SqlCommand();
                command2.CommandType = CommandType.Text;
                command2.Connection = con2;
                command2.CommandText = "INSERT INTO Grade Values(" + add_grade_g1.Text.Trim() + "," + add_grade_g2.Text.Trim() + " ," + add_grade_g3.Text.Trim() + "," + add_grade_absence.Text.Trim() + "," + add_grade_plus.Text.Trim() + " , " + finalgrade.ToString() + " , " + add_grade_student.SelectedValue + " , " + add_grade_mat.SelectedValue + " )";
                int x = command2.ExecuteNonQuery();
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

        protected void show_sch_deb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "SELECT * FROM Schedule where DebId = " + show_sch_deb.SelectedValue + " AND Stage = " + show_sch_stage.SelectedValue +" AND DayOrNight = '"+show_sch_dayOrNight.SelectedValue+"'";
            SqlDataReader reader = command.ExecuteReader();


            if (reader.Read())
            {
                int Day = Convert.ToInt32(reader["Day"].ToString());
                switch (Day)
                {
                    case 1:
                        if (reader["FourOrThree"].ToString()== "Three")
                        {
                            Sun_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                            Sun_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                            Sun_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                            Sun_time_4.Text = "لا يوجد ";

                            Sun_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                            Sun_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                            Sun_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                            Sun_info_4.Text = "لا يوجد ";
                        }
                        else
                        {
                            Sun_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                            Sun_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                            Sun_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                            Sun_time_4.Text = reader["t4From"].ToString() + "-" + reader["t4To"].ToString();

                            Sun_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                            Sun_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                            Sun_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                            Sun_info_4.Text = reader["m4"].ToString() + "<br/>" + reader["i4"].ToString();
                        }


                        break;
                    case 2:
                        if (reader["FourOrThree"].ToString() == "Three")
                        {
                            Mon_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                            Mon_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                            Mon_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                            Mon_time_4.Text = "لا يوجد ";

                            Mon_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                            Mon_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                            Mon_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                            Mon_info_4.Text = "لا يوجد ";
                        }
                        else
                        {
                            Mon_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                            Mon_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                            Mon_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                            Mon_time_4.Text = reader["t4From"].ToString() + "-" + reader["t4To"].ToString();

                            Mon_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                            Mon_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                            Mon_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                            Mon_info_4.Text = reader["m4"].ToString() + "<br/>" + reader["i4"].ToString();
                        }

                        break;
                    case 3:
                        if (reader["FourOrThree"].ToString() == "Three")
                        {
                            Thr_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                            Thr_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                            Thr_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                            Thr_time_4.Text = "لا يوجد ";

                            Thr_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                            Thr_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                            Thr_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                            Thr_info_4.Text = "لا يوجد ";
                        }
                        else
                        {
                            Thr_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                            Thr_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                            Thr_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                            Thr_time_4.Text = reader["t4From"].ToString() + "-" + reader["t4To"].ToString();

                            Thr_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                            Thr_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                            Thr_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                            Thr_info_4.Text = reader["m4"].ToString() + "<br/>" + reader["i4"].ToString();
                        }



                        break;
                    case 4:
                        if (reader["FourOrThree"].ToString() == "Three")
                        {
                            Wed_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                            Wed_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                            Wed_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                            Wed_time_4.Text = "لا يوجد ";

                            Wed_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                            Wed_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                            Wed_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                            Wed_info_4.Text = "لا يوجد ";
                        }
                        else
                        {
                            Wed_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                            Wed_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                            Wed_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                            Wed_time_4.Text = reader["t4From"].ToString() + "-" + reader["t4To"].ToString();

                            Wed_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                            Wed_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                            Wed_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                            Wed_info_4.Text = reader["m4"].ToString() + "<br/>" + reader["i4"].ToString();
                        }

                        break;
                    case 5:
                        if (reader["FourOrThree"].ToString() == "Three")
                        {
                            Thu_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                            Thu_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                            Thu_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                            Thu_time_4.Text = "لا يوجد ";

                            Thu_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                            Thu_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                            Thu_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                            Thu_info_4.Text = "لا يوجد ";
                        }
                        else
                        {
                            Thu_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                            Thu_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                            Thu_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                            Thu_time_4.Text = reader["t4From"].ToString() + "-" + reader["t4To"].ToString();

                            Thu_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                            Thu_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                            Thu_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                            Thu_info_4.Text = reader["m4"].ToString() + "<br/>" + reader["i4"].ToString();
                        }

                        break;
                    case 6:
                        if (reader["FourOrThree"].ToString() == "Three")
                        {
                            Sat_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                            Sat_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                            Sat_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                            Sat_time_4.Text = "لا يوجد ";

                            Sat_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                            Sat_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                            Sat_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                            Sat_info_4.Text = "لا يوجد ";
                        }
                        else
                        {
                            Sat_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                            Sat_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                            Sat_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                            Sat_time_4.Text = reader["t4From"].ToString() + "-" + reader["t4To"].ToString();

                            Sat_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                            Sat_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                            Sat_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                            Sat_info_4.Text = reader["m4"].ToString() + "<br/>" + reader["i4"].ToString();
                        }

                        break;
                   
                    
                }

                while(reader.Read())
                    {
                     Day = Convert.ToInt32(reader["Day"].ToString());
                    switch (Day)
                    {
                        case 1:
                            if (reader["FourOrThree"].ToString() == "Three")
                            {
                                Sun_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                                Sun_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                                Sun_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                                Sun_time_4.Text = "لا يوجد ";

                                Sun_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                                Sun_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                                Sun_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                                Sun_info_4.Text = "لا يوجد ";
                            }
                            else
                            {
                                Sun_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                                Sun_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                                Sun_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                                Sun_time_4.Text = reader["t4From"].ToString() + "-" + reader["t4To"].ToString();

                                Sun_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                                Sun_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                                Sun_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                                Sun_info_4.Text = reader["m4"].ToString() + "<br/>" + reader["i4"].ToString();
                            }


                            break;
                        case 2:
                            if (reader["FourOrThree"].ToString() == "Three")
                            {
                                Mon_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                                Mon_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                                Mon_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                                Mon_time_4.Text = "لا يوجد ";

                                Mon_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                                Mon_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                                Mon_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                                Mon_info_4.Text = "لا يوجد ";
                            }
                            else
                            {
                                Mon_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                                Mon_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                                Mon_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                                Mon_time_4.Text = reader["t4From"].ToString() + "-" + reader["t4To"].ToString();

                                Mon_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                                Mon_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                                Mon_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                                Mon_info_4.Text = reader["m4"].ToString() + "<br/>" + reader["i4"].ToString();
                            }

                            break;
                        case 3:
                            if (reader["FourOrThree"].ToString() == "Three")
                            {
                                Thr_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                                Thr_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                                Thr_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                                Thr_time_4.Text = "لا يوجد ";

                                Thr_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                                Thr_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                                Thr_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                                Thr_info_4.Text = "لا يوجد ";
                            }
                            else
                            {
                                Thr_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                                Thr_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                                Thr_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                                Thr_time_4.Text = reader["t4From"].ToString() + "-" + reader["t4To"].ToString();

                                Thr_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                                Thr_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                                Thr_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                                Thr_info_4.Text = reader["m4"].ToString() + "<br/>" + reader["i4"].ToString();
                            }



                            break;
                        case 4:
                            if (reader["FourOrThree"].ToString() == "Three")
                            {
                                Wed_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                                Wed_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                                Wed_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                                Wed_time_4.Text = "لا يوجد ";

                                Wed_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                                Wed_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                                Wed_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                                Wed_info_4.Text = "لا يوجد ";
                            }
                            else
                            {
                                Wed_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                                Wed_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                                Wed_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                                Wed_time_4.Text = reader["t4From"].ToString() + "-" + reader["t4To"].ToString();

                                Wed_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                                Wed_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                                Wed_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                                Wed_info_4.Text = reader["m4"].ToString() + "<br/>" + reader["i4"].ToString();
                            }

                            break;
                        case 5:
                            if (reader["FourOrThree"].ToString() == "Three")
                            {
                                Thu_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                                Thu_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                                Thu_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                                Thu_time_4.Text = "لا يوجد ";

                                Thu_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                                Thu_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                                Thu_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                                Thu_info_4.Text = "لا يوجد ";
                            }
                            else
                            {
                                Thu_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                                Thu_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                                Thu_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                                Thu_time_4.Text = reader["t4From"].ToString() + "-" + reader["t4To"].ToString();

                                Thu_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                                Thu_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                                Thu_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                                Thu_info_4.Text = reader["m4"].ToString() + "<br/>" + reader["i4"].ToString();
                            }

                            break;
                        case 6:
                            if (reader["FourOrThree"].ToString() == "Three")
                            {
                                Sat_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                                Sat_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                                Sat_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                                Sat_time_4.Text = "لا يوجد ";

                                Sat_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                                Sat_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                                Sat_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                                Sat_info_4.Text = "لا يوجد ";
                            }
                            else
                            {
                                Sat_time_1.Text = reader["t1From"].ToString() + "-" + reader["t1To"].ToString();
                                Sat_time_2.Text = reader["t2From"].ToString() + "-" + reader["t2To"].ToString();
                                Sat_time_3.Text = reader["t3From"].ToString() + "-" + reader["t3To"].ToString();
                                Sat_time_4.Text = reader["t4From"].ToString() + "-" + reader["t4To"].ToString();

                                Sat_info_1.Text = reader["m1"].ToString() + "<br/>" + reader["i1"].ToString();
                                Sat_info_2.Text = reader["m2"].ToString() + "<br/>" + reader["i2"].ToString();
                                Sat_info_3.Text = reader["m3"].ToString() + "<br/>" + reader["i3"].ToString();
                                Sat_info_4.Text = reader["m4"].ToString() + "<br/>" + reader["i4"].ToString();
                            }

                            break;


                    }
                }
            }

            else
            {

                        Sun_time_1.Text = "";
                        Sun_time_2.Text = "";
                        Sun_time_3.Text = "";
                        Sun_time_4.Text = "";

                        Sun_info_1.Text = "";
                        Sun_info_2.Text = "";
                        Sun_info_3.Text = "";
                        Sun_info_4.Text = "";
                   

                        Mon_time_1.Text = "";
                        Mon_time_2.Text = "";
                        Mon_time_3.Text = "";
                        Mon_time_4.Text = "";

                        Mon_info_1.Text = "";
                        Mon_info_2.Text = "";
                        Mon_info_3.Text = "";
                        Mon_info_4.Text = "";
                  

                        Thr_time_1.Text = "";
                        Thr_time_2.Text = "";
                        Thr_time_3.Text = "";
                        Thr_time_4.Text = "";

                        Thr_info_1.Text = "";
                        Thr_info_2.Text = "";
                        Thr_info_3.Text = "";
                        Thr_info_4.Text = "";
                    

                   
                        Wed_time_1.Text = "";
                        Wed_time_2.Text = "";
                        Wed_time_3.Text = "";
                        Wed_time_4.Text = "";

                        Wed_info_1.Text = "";
                        Wed_info_2.Text = "";
                        Wed_info_3.Text = "";
                        Wed_info_4.Text = "";
                   

                        Thu_time_1.Text = "";
                        Thu_time_2.Text = "";
                        Thu_time_3.Text = "";
                        Thu_time_4.Text = "";

                        Thu_info_1.Text = "";
                        Thu_info_2.Text = "";
                        Thu_info_3.Text = "";
                        Thu_info_4.Text = "";
                    

                        Sat_time_1.Text = "";
                        Sat_time_2.Text = "";
                        Sat_time_3.Text = "";
                        Sat_time_4.Text = "";

                        Sat_info_1.Text = "";
                        Sat_info_2.Text = "";
                        Sat_info_3.Text = "";
                        Sat_info_4.Text = "";
                   

                }
        }



        protected void add_grp_save_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "INSERT INTO Groups Values('" + add_grp_latter.Text + "' ," + add_grp_max.Text + " , " + add_grp_deb.SelectedValue + " , " + add_grp_stage.SelectedValue + " )";
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                add_grp_error.Visible = true;
                add_grp_error.Text = "تم اضافة كروب  ";
                add_grp_error.CssClass = "alert alert-success ";
            }
            else
            {
                add_grp_error.Visible = true;
                add_grp_error.Text = "حدث خطأ";
                add_grp_error.CssClass = "alert alert-danger ";
            }
        }

        protected void add_stu_stage_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "SELECT * FROM Groups where DebId = " + add_stu_deb.SelectedValue + " AND Stage = " + add_stu_stage.SelectedValue;
            SqlDataReader reader = command.ExecuteReader();

            add_stu_group.Items.Clear();

            while (reader.Read())
            {
                ListItem listItem = new ListItem()
                {
                    Value = reader["Id"].ToString(),

                    Text = reader["groupLatter"].ToString()
                };


                add_stu_group.Items.Add(listItem);
            }
        }

        protected void add_grade_mat_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = "SELECT * FROM Grade where StuID = " + add_grade_student.SelectedValue + "AND MetID = " + add_grade_mat.SelectedValue;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                add_grade_g1.Text = reader["g1"].ToString();
                add_grade_g2.Text = reader["g2"].ToString();
                add_grade_g3.Text = reader["g3"].ToString();
                add_grade_absence.Text = reader["absence"].ToString();
                add_grade_plus.Text = reader["pluses"].ToString();

            }
            else
            {
                add_grade_g1.Text = "0";
                add_grade_g2.Text = "0";
                add_grade_g3.Text = "0";
                add_grade_absence.Text = "0";
                add_grade_plus.Text = "0";
            }
        }

        protected void add_sch_deb_SelectedIndexChanged(object sender, EventArgs e)
        {

            add_sch_m1.Items.Clear();
            add_sch_m2.Items.Clear();
            add_sch_m3.Items.Clear();
            add_sch_m4.Items.Clear();

            SqlConnection con3 = new SqlConnection();
            con3.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con3.Open();
            SqlCommand command3 = new SqlCommand();
            command3.CommandType = CommandType.Text;
            command3.Connection = con3;
            command3.CommandText = "SELECT * FROM Material where Stage = " + add_sch_stage.SelectedValue +
            "  AND DebID = " + add_sch_deb.SelectedValue;
            SqlDataReader reader3 = command3.ExecuteReader();

            ListItem listItem = new ListItem()
            {
                Value = "0",
                Text = "اختر مادة"
            };

            add_sch_m1.Items.Add(listItem);
            add_sch_m2.Items.Add(listItem);
            add_sch_m3.Items.Add(listItem);
            add_sch_m4.Items.Add(listItem);

            while (reader3.Read())
            {
                listItem = new ListItem()
                {
                    Value = reader3[0].ToString(),
                    Text = reader3[1].ToString()
                };

                add_sch_m1.Items.Add(listItem);
                add_sch_m2.Items.Add(listItem);
                add_sch_m3.Items.Add(listItem);
                add_sch_m4.Items.Add(listItem);
            }
            reader3.Close();
            con3.Close();


            if (add_sch_FourOrThree.SelectedValue == "Three")
            {
                sch_1.Visible = true;
                sch_2.Visible = true;
                sch_3.Visible = true;
                sch_4.Visible = false;

                add_sch_t1_from.Text ="08:30" ;
                add_sch_t1_to.Text ="10:30";

                add_sch_t2_from.Text ="10:30";
                add_sch_t2_to.Text ="12:30";

                add_sch_t3_from.Text ="12:30";
                add_sch_t3_to.Text ="14:30";



                add_sch_t4_from.Text = "";
                add_sch_t4_to.Text = "";
                add_sch_m4.Items.Clear();
                add_sch_i4.Text = "";
            }
            else if (add_sch_FourOrThree.SelectedValue == "Four")
            {
                sch_1.Visible = true;
                sch_2.Visible = true;
                sch_3.Visible = true;
                sch_4.Visible = true;

                add_sch_t1_from.Text = "08:30";
                add_sch_t1_to.Text = "10:00";

                add_sch_t2_from.Text = "10:00";
                add_sch_t2_to.Text = "11:30";

                add_sch_t3_from.Text = "11:30";
                add_sch_t3_to.Text = "13:00";



                add_sch_t4_from.Text = "13:00";
                add_sch_t4_to.Text = "14:30";
            }


        }
    }
}