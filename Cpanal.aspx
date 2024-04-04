<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cpanal.aspx.cs" Inherits="Collage_Managment_System.Cpanal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../lib/bootstrap.min.css" />
    <link
        href="https://unpkg.com/boxicons@2.1.2/css/boxicons.min.css"
        rel="stylesheet"
        asp-append-version="true" />
    <link rel="stylesheet" href="../lib/site.css" />
    <style>
        .hr {
            border: 3px groove red;
        }
    </style>
    <title>كلية تكنولوجيا المعلومات</title>
</head>
<body style="background-color: rgba(128, 128, 128,0.2)">
    <div class="container-fiud">
        <form id="form1" runat="server">


            <div class="border-1 border-opacity-25 mb-5 pb-3 p-3" style="background-color: rgba(128, 128, 128,0.4)">
                <h1 class=" pt-3 pb-3 ">
                    <img src="https://it.uobabylon.edu.iq/media/images/logo.png" />

                    كلية تكنولوجيا المعلومات

                </h1>
                <h3 align="center">اختر العملية المطلوبة</h3>


                <asp:DropDownList ID="functionDDl" Style="background-color: rgba(128, 128, 128,0.2)" OnSelectedIndexChanged="functionDDl_SelectedIndexChanged" runat="server" CssClass="border border-1 border-dark form-select focus-ring focus-ring-danger text-center" AutoPostBack="true">
                    <asp:ListItem Selected="True" Text="اختر العملية...." Value="-1">  </asp:ListItem>
                    <asp:ListItem Value="1"> إضافة قسم </asp:ListItem>
                    <asp:ListItem Value="2"> حذف قسم </asp:ListItem>
                    <asp:ListItem Value="13"> اضافة كروب عملي  </asp:ListItem>
                    <asp:ListItem Value="3"> اضافة طالب </asp:ListItem>
                    <asp:ListItem Value="4"> عرض الطلاب </asp:ListItem>
                    <asp:ListItem Value="5"> حذف طالب </asp:ListItem>
                    <asp:ListItem Value="6"> اضافة مادة </asp:ListItem>
                    <asp:ListItem Value="7"> حذف مادة </asp:ListItem>
                    <asp:ListItem Value="8"> عرض مواد قسم </asp:ListItem>
                    <asp:ListItem Value="9"> إضافة جدول لقسم </asp:ListItem>
                    <asp:ListItem Value="10"> عرض جداول قسم </asp:ListItem>
                    <asp:ListItem Value="11"> اضافة درجة طالب  </asp:ListItem>
                    <asp:ListItem Value="12"> عرض درجات لمادة  </asp:ListItem>
                </asp:DropDownList>
            </div>



            <div class="container-fluid mb-5">

                <div runat="server" visible="false" id="function1">
                    <div class="form-group">
                        <label class="control-label" for="deb_add_name">اسم القسم </label>
                        <input
                            type="text"
                            id="deb_add_name"
                            class="form-control"
                            runat="server" />
                    </div>
                    <br />
                    <asp:Button ID="deb_add_BTN" CssClass="btn btn-outline-success w-100" runat="server" Text="اضافة" OnClick="deb_add_BTN_Click" />


                    <div class="container-fluid mt-5 text-center pb-5">

                        <asp:Label ID="deb_add_errorLB" runat="server" Text=""></asp:Label>

                    </div>
                </div>
                <div runat="server" visible="false" id="function2">

                    <div>

                        <p class="text-center text-danger">
                            *
                في حالة حذف قسم سيتم حذف كل ما يرتبط بيه من مواد دراسية و طلاب و غيرها
                        </p>

                        <br />
                        <br />
                        <br />
                        <asp:DropDownList ID="del_deb_ddl" runat="server" CssClass="form-select text-center" AutoPostBack="true">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Button ID="del_deb_BTN" runat="server" CssClass="btn btn-outline-danger w-100" Text="حذف القسم " OnClick="del_deb_BTN_Click" />
                        <br />

                        <div class="container-fluid mt-5 text-center pb-5">

                            <asp:Label ID="del_deb_errorLB" runat="server" Text=""></asp:Label>

                        </div>

                    </div>

                </div>
                <div runat="server" visible="false" id="function3">

                    <div class="container-fluid mt-5 text-center pb-5">

                        <asp:Label ID="add_stu_errorLB" runat="server" Text=""></asp:Label>

                    </div>

                    <p>اسم الطالب</p>
                    <asp:TextBox ID="Add_stu_Name" CssClass="form-control" runat="server"></asp:TextBox>

                    <hr />

                    <p>تاريح ميلاد الطالب</p>

                    <asp:TextBox ID="Add_stu_birthday" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>

                    <hr />

                    <p>القسم</p>

                    <asp:DropDownList ID="add_stu_deb" CssClass="form-select" runat="server"></asp:DropDownList>

                    <hr />

                    <p>المرحلة</p>
                    <asp:DropDownList ID="add_stu_stage" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="add_stu_stage_SelectedIndexChanged">
                        <asp:ListItem Value="-1">اختر المرحلة</asp:ListItem>
                        <asp:ListItem Value="1">الأولى</asp:ListItem>
                        <asp:ListItem Value="2">الثانية</asp:ListItem>
                        <asp:ListItem Value="3">الثالثة</asp:ListItem>
                        <asp:ListItem Value="4">الرابعة</asp:ListItem>
                    </asp:DropDownList>
                    <hr />

                    <p>الكروب</p>
                    <asp:DropDownList ID="add_stu_group" CssClass="form-select" runat="server"></asp:DropDownList>
                    <hr />



                    <p>الجنس</p>
                    <asp:DropDownList ID="Add_stu_gender" CssClass="form-select" runat="server">
                        <asp:ListItem Value="ذكر">ذكر</asp:ListItem>
                        <asp:ListItem Value="أنثى">انثى</asp:ListItem>
                    </asp:DropDownList>

                    <hr />


                    <p>رقم موبايل الطالب</p>
                    <asp:TextBox ID="Add_stu_phone" CssClass="form-control" TextMode="Phone" runat="server"></asp:TextBox>
                    <hr />


                    <asp:Button ID="Add_stu_saveBTN" runat="server" CssClass="btn btn-outline-success w-100  text-center " Text="حفظ" OnClick="Add_stu_saveBTN_Click" />


                </div>
                <div runat="server" visible="false" id="function4">


                    <br />
                    <asp:DropDownList ID="show_stu_ddl" CssClass="form-select" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <br />


                    <asp:GridView ID="Student_show_DG" runat="server" CssClass="text-center" Style="width: 100%;" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="2px" CellPadding="4" DataSourceID="Student_Show_DG_DataSource" ForeColor="Black" GridLines="Vertical" PageSize="6">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Id_str" HeaderText="الرمز الجامعي" SortExpression="Id_str" />
                            <asp:BoundField DataField="Name" HeaderText="الاسم" SortExpression="Name" />
                            <asp:BoundField DataField="Birthdate" HeaderText="تاريخ الميلاد" SortExpression="Birthdate" />
                            <asp:BoundField DataField="Stage" HeaderText="المرحلة" SortExpression="Stage" />
                            <asp:BoundField DataField="groupLatter" HeaderText="الكروب" SortExpression="groupLatter" />
                            <asp:BoundField DataField="Gender" HeaderText="الجنس" SortExpression="Gender" />
                            <asp:BoundField DataField="phone_Number" HeaderText="رقم الهاتف" SortExpression="phone_Number" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>

                    <asp:SqlDataSource ID="Student_Show_DG_DataSource" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT dbo.Groups.groupLatter, dbo.Student.Name, dbo.Student.Birthdate, dbo.Student.Deb, dbo.Student.Stage, dbo.Student.Gender, dbo.Student.Phone_Number, dbo.Student.Id_str
FROM     dbo.Groups INNER JOIN
                  dbo.Student ON dbo.Groups.Id = dbo.Student.GroupId
WHERE  (dbo.Student.Deb=@debId) ">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="show_stu_ddl" Name="debId" PropertyName="Text" Type="Int32" DefaultValue="0" />
                        </SelectParameters>
                    </asp:SqlDataSource>





                </div>
                <div runat="server" visible="false" id="function5">

                    <div class="mt-5 text-center">

                        <asp:Label ID="del_stu_errorLB" runat="server" Text=""></asp:Label>

                    </div>
                    <div>
                        <div class="input-group mb-3">
                            <asp:TextBox ID="del_stu_idSearch" CssClass="focus-ring focus-ring-danger w-50 form-control" placeholder="ID الطالب " runat="server"></asp:TextBox>
                            <div class="input-group-prepend">
                                <asp:Button ID="del_stu_SearchBTN" CssClass="btn btn-primary" runat="server" Text="بحث" OnClick="del_stu_SearchBTN_Click" />
                            </div>
                        </div>
                    </div>

                    <asp:DropDownList ID="del_stu_DDL" runat="server" CssClass="form-select text-center">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button ID="del_stu_BTN" runat="server" CssClass="btn btn-outline-danger w-100" Text="حذف الطالب " OnClick="del_stu_BTN_Click" />
                    <br />



                </div>
                <div runat="server" visible="false" id="function6">
                    <div class="container-fluid mt-5 text-center pb-5">

                        <asp:Label ID="add_mat_error" runat="server" Text=""></asp:Label>

                    </div>



                    <p>اسم المادة الدراسية</p>
                    <asp:TextBox ID="add_mat_Name" CssClass="form-control" runat="server"></asp:TextBox>
                    <hr />


                    <p>القسم</p>

                    <asp:DropDownList ID="add_mat_deb" CssClass="form-select" runat="server"></asp:DropDownList>
                    <hr />


                    <p>المرحلة </p>
                    <asp:DropDownList ID="add_mat_stage" CssClass="form-select" runat="server">
                        <asp:ListItem Value="1">الأولى</asp:ListItem>
                        <asp:ListItem Value="2">الثانية</asp:ListItem>
                        <asp:ListItem Value="3">الثالثة</asp:ListItem>
                        <asp:ListItem Value="4">الرابعة</asp:ListItem>
                    </asp:DropDownList>
                    <hr />

                    <p>عدد الوحدات</p>
                    <asp:TextBox ID="add_mat_UnitNumber" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    <hr />

                    <p>عدد الساعات النظرية</p>
                    <asp:TextBox ID="add_mat_th" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    <hr />

                    <p>عدد الساعات العملية</p>
                    <asp:TextBox ID="add_mat_lab" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    <hr />



                    <asp:Button ID="add_mat_save" runat="server" CssClass="btn btn-outline-success w-100  text-center " Text="حفظ" OnClick="add_mat_save_Click" />



                    <br />
                    <br />




                </div>
                <div runat="server" visible="false" id="function7">
                    <div class="container-fluid mt-5 text-center pb-5">

                        <asp:Label ID="mat_del_errorLB" runat="server" Text=""></asp:Label>

                    </div>

                    <p>القسم</p>
                    <asp:DropDownList ID="mat_del_deb" CssClass="form-select " runat="server"></asp:DropDownList>
                    <asp:Button ID="mat_del_search" CssClass="w-25 btn btn-outline-primary m-1" runat="server" OnClick="mat_del_search_Click" Text="بحث" />
                    <hr />
                    <p>المادة الدراسية</p>

                    <asp:DropDownList ID="mat_del_ddl" CssClass="form-control focus-ring focus-ring-success m-1" runat="server"></asp:DropDownList>

                    <asp:Button ID="mat_del_delete" CssClass="w-25 btn btn-outline-danger m-1" runat="server" OnClick="mat_del_delete_Click" Text="حذف" />

                </div>
                <div runat="server" visible="false" id="function8">


                    <asp:DropDownList ID="show_mat_deb" runat="server" CssClass="form-select text-center" AutoPostBack="true"></asp:DropDownList>
                    <br />

                    <asp:GridView ID="show_mat_dg" runat="server" CssClass="text-center" Style="width: 100%;" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="2px" CellPadding="4" DataSourceID="show_mat_DG_DataSource" ForeColor="Black" GridLines="Vertical" PageSize="6">



                        <Columns>

                            <asp:BoundField DataField="Name" HeaderText="إسم المادة" SortExpression="Name" />
                            <asp:BoundField DataField="Unit_Numbers" HeaderText="عدد الوحدات " SortExpression="Unit_Numbers" />
                            <asp:BoundField DataField="Stage" HeaderText="المرحلة" SortExpression="Stage" />
                            <asp:BoundField DataField="Th_hours" HeaderText="عدد الساعات النظري" SortExpression="Th_hours" />
                            <asp:BoundField DataField="Lab_hours" HeaderText="عدد الساعات العملي" SortExpression="Lab_hours" />
                        </Columns>


                        <AlternatingRowStyle BackColor="White" />
                        <HeaderStyle BackColor="#009688" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="Black" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F7DE" />

                    </asp:GridView>

                    <asp:SqlDataSource ID="show_mat_DG_DataSource" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT *  FROM Material where DebId =  @debId order by Stage ASC">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="show_mat_deb" Name="debId" PropertyName="Text" Type="Int32" DefaultValue="-1" />
                        </SelectParameters>
                    </asp:SqlDataSource>



                </div>
                <div runat="server" visible="false" id="function9">

                    <div class="container-fluid mt-5 text-center pb-5">

                        <asp:Label ID="add_sch_error" runat="server" Text=""></asp:Label>

                    </div>
                    <br />

                    <div class="input-group">
                        <span class="input-group-text  bg-dark-subtle text-primary">القسم</span>
                        <asp:DropDownList ID="add_sch_deb" CssClass="form-select text-center" runat="server" AutoPostBack="true" OnSelectedIndexChanged="add_sch_deb_SelectedIndexChanged">
                        </asp:DropDownList>

                        &nbsp;&nbsp;&nbsp;

                        <span class="input-group-text  bg-dark-subtle text-primary">المرحلة</span>
                        <asp:DropDownList ID="add_sch_stage" CssClass="form-select text-center" runat="server" AutoPostBack="true" OnSelectedIndexChanged="add_sch_deb_SelectedIndexChanged">
                            <asp:ListItem Value="1">الاولى </asp:ListItem>
                            <asp:ListItem Value="2">الثانية</asp:ListItem>
                            <asp:ListItem Value="3"> الثالثة</asp:ListItem>
                            <asp:ListItem Value="4">الرابعة</asp:ListItem>
                        </asp:DropDownList>

                        &nbsp;&nbsp;&nbsp;

                        <span class="input-group-text  bg-dark-subtle text-primary">نوع الدوام</span>
                        <asp:DropDownList ID="add_sch_dayOrNight" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="add_sch_deb_SelectedIndexChanged">
                            <asp:ListItem Value="صباحي">صباحي </asp:ListItem>
                            <asp:ListItem Value="مسائي">مسائي</asp:ListItem>
                        </asp:DropDownList>

                        &nbsp;&nbsp;&nbsp;

                        <span class="input-group-text  bg-dark-subtle text-primary">اليوم </span>
                        <asp:DropDownList ID="add_sch_day" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="add_sch_deb_SelectedIndexChanged">
                            <asp:ListItem Value="-1">اختر اليوم </asp:ListItem>
                            <asp:ListItem Value="1">الأحد </asp:ListItem>
                            <asp:ListItem Value="2">الإثنين </asp:ListItem>
                            <asp:ListItem Value="3">الثلاثاء </asp:ListItem>
                            <asp:ListItem Value="4">الاربعاء </asp:ListItem>
                            <asp:ListItem Value="5">الخميس </asp:ListItem>
                            <asp:ListItem Value="6">السبت </asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;

                          <span class="input-group-text  bg-dark-subtle text-primary">نظام المحاضرات </span>
                        <asp:DropDownList ID="add_sch_FourOrThree" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="add_sch_deb_SelectedIndexChanged">
                            <asp:ListItem Value="-1">اختر النظام </asp:ListItem>
                            <asp:ListItem Value="Three">ثلاث محاضرات</asp:ListItem>
                            <asp:ListItem Value="Four">اربع محاضرات </asp:ListItem>
                        </asp:DropDownList>


                    </div>


                    <hr />

                    <div runat="server" id="sch_1" class="mb-5" visible="false">
                        <span class="input-group-text mb-2  bg-dark-subtle text-primary">المحاضرة الأولى </span>
                        <div class="input-group">
                            <br />
                            <span class="input-group-text  bg-dark-subtle text-primary-emphasis">من الساعة  </span>
                            <asp:TextBox ID="add_sch_t1_from" runat="server" TextMode="Time" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            &nbsp;&nbsp;
                            
                            <span class="input-group-text  bg-dark-subtle text-primary-emphasis">الى الساعة  </span>
                            <asp:TextBox ID="add_sch_t1_to" runat="server" TextMode="Time" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            &nbsp;&nbsp;
                             
                            <span class="input-group-text  bg-dark-subtle text-primary-emphasis">المادة  </span>
                            <asp:DropDownList ID="add_sch_m1" runat="server" CssClass="form-select"></asp:DropDownList>
                            &nbsp;&nbsp;

                             <span class="input-group-text  bg-dark-subtle text-primary-emphasis">ملاحضات اخرى  </span>
                            <asp:TextBox ID="add_sch_i1" runat="server" CssClass="form-control" Style="resize: none" Rows="1" TextMode="MultiLine"></asp:TextBox>
                            &nbsp;&nbsp;

                        </div>
                    </div>

                    <div runat="server" id="sch_2" class="mb-5" visible="false">
                        <span class="input-group-text mb-2  bg-dark-subtle text-primary">المحاضرة الثانية </span>
                        <div class="input-group">
                            <br />
                            <span class="input-group-text  bg-dark-subtle text-primary-emphasis">من الساعة  </span>
                            <asp:TextBox ID="add_sch_t2_from" runat="server" TextMode="Time" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            &nbsp;&nbsp;
                            
                            <span class="input-group-text  bg-dark-subtle text-primary-emphasis">الى الساعة  </span>
                            <asp:TextBox ID="add_sch_t2_to" runat="server" TextMode="Time" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            &nbsp;&nbsp;
                             
                            <span class="input-group-text  bg-dark-subtle text-primary-emphasis">المادة  </span>
                            <asp:DropDownList ID="add_sch_m2" runat="server" CssClass="form-select"></asp:DropDownList>
                            &nbsp;&nbsp;

                             <span class="input-group-text  bg-dark-subtle text-primary-emphasis">ملاحضات اخرى  </span>
                            <asp:TextBox ID="add_sch_i2" runat="server" CssClass="form-control" Style="resize: none" Rows="1" TextMode="MultiLine"></asp:TextBox>
                            &nbsp;&nbsp;

                        </div>
                    </div>

                    <div runat="server" id="sch_3" class="mb-5" visible="false">
                        <span class="input-group-text mb-2  bg-dark-subtle text-primary">المحاضرة الثالثة </span>
                        <div class="input-group">
                            <br />
                            <span class="input-group-text  bg-dark-subtle text-primary-emphasis">من الساعة  </span>
                            <asp:TextBox ID="add_sch_t3_from" runat="server" TextMode="Time" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            &nbsp;&nbsp;
                            
                            <span class="input-group-text  bg-dark-subtle text-primary-emphasis">الى الساعة  </span>
                            <asp:TextBox ID="add_sch_t3_to" runat="server" TextMode="Time" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            &nbsp;&nbsp;
                             
                            <span class="input-group-text  bg-dark-subtle text-primary-emphasis">المادة  </span>
                            <asp:DropDownList ID="add_sch_m3" runat="server" CssClass="form-select"></asp:DropDownList>
                            &nbsp;&nbsp;

                             <span class="input-group-text  bg-dark-subtle text-primary-emphasis">ملاحضات اخرى  </span>
                            <asp:TextBox ID="add_sch_i3" runat="server" CssClass="form-control" Style="resize: none" Rows="1" TextMode="MultiLine"></asp:TextBox>
                            &nbsp;&nbsp;

                        </div>
                    </div>

                    <div runat="server" id="sch_4" class="mb-5" visible="false">
                        <span class="input-group-text mb-2  bg-dark-subtle text-primary">المحاضرة الرابعة </span>
                        <div class="input-group">
                            <br />
                            <span class="input-group-text  bg-dark-subtle text-primary-emphasis">من الساعة  </span>
                            <asp:TextBox ID="add_sch_t4_from" runat="server" TextMode="Time" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            &nbsp;&nbsp;
                            
                            <span class="input-group-text  bg-dark-subtle text-primary-emphasis">الى الساعة  </span>
                            <asp:TextBox ID="add_sch_t4_to" runat="server" TextMode="Time" CssClass="form-control " ReadOnly="true"></asp:TextBox>
                            &nbsp;&nbsp;
                             
                            <span class="input-group-text  bg-dark-subtle text-primary-emphasis">المادة  </span>
                            <asp:DropDownList ID="add_sch_m4" runat="server" CssClass="form-select"></asp:DropDownList>
                            &nbsp;&nbsp;

                             <span class="input-group-text  bg-dark-subtle text-primary-emphasis">ملاحضات اخرى  </span>
                            <asp:TextBox ID="add_sch_i4" runat="server" CssClass="form-control" Style="resize: none" Rows="1" TextMode="MultiLine"></asp:TextBox>
                            &nbsp;&nbsp;

                        </div>
                    </div>


                    <hr />

                    <asp:Button ID="add_sch_save" CssClass="w-100 btn btn-outline-success m-1" runat="server" OnClick="add_sch_save_Click" Text="حفظ" />




                </div>
                <div runat="server" visible="false" id="function10">

                    <div class="input-group">
                        <span class="input-group-text bg-dark-subtle text-primary">القسم</span>

                        <asp:DropDownList ID="show_sch_deb" CssClass="form-select text-center" runat="server" AutoPostBack="true" OnSelectedIndexChanged="show_sch_deb_SelectedIndexChanged"></asp:DropDownList>

                        &nbsp;&nbsp;&nbsp;
                        <span class="input-group-text bg-dark-subtle text-primary">المرحلة</span>
                        <asp:DropDownList ID="show_sch_stage" CssClass="form-select text-center" runat="server" AutoPostBack="true" OnSelectedIndexChanged="show_sch_deb_SelectedIndexChanged">
                            <asp:ListItem Value="1">الاولى </asp:ListItem>
                            <asp:ListItem Value="2">الثانية</asp:ListItem>
                            <asp:ListItem Value="3"> الثالثة</asp:ListItem>
                            <asp:ListItem Value="4">الرابعة</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;

                         <span class="input-group-text bg-dark-subtle text-primary">الدراسة</span>

                        <asp:DropDownList ID="show_sch_dayOrNight" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="show_sch_deb_SelectedIndexChanged">
                            <asp:ListItem Value="صباحي">صباحي </asp:ListItem>
                            <asp:ListItem Value="مسائي">مسائي</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <hr />


                    <div class="container-fliud w-100 mt-3 mb-3 justify-content-center d-flex ">




                        <table class="table table-bordered bg-black table-light">
                            <%--------------------------------------------------------------%>

                            <tr valign="middle" align="center" class="table-active">
                                <td rowspan="2">السبت</td>
                                <td>
                                    <asp:Label ID="Sat_time_1" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Sat_time_2" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Sat_time_3" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Sat_time_4" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr valign="middle" align="center" class="table-active">

                                <td>
                                    <asp:Label ID="Sat_info_1" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Sat_info_2" runat="server" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Sat_info_3" runat="server" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Sat_info_4" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <%--------------------------------------------------------------%>

                            <tr valign="middle" align="center" class="table-danger">
                                <td rowspan="2">الأحد</td>
                                <td>
                                    <asp:Label ID="Sun_time_1" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Sun_time_2" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Sun_time_3" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Sun_time_4" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr valign="middle" align="center" class="table-danger">

                                <td>
                                    <asp:Label ID="Sun_info_1" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Sun_info_2" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Sun_info_3" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Sun_info_4" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <%--------------------------------------------------------------%>

                            <tr valign="middle" align="center" class="table-active">
                                <td rowspan="2">الإثنين</td>
                                <td>
                                    <asp:Label ID="Mon_time_1" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Mon_time_2" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Mon_time_3" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Mon_time_4" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr valign="middle" align="center" class="table-active">

                                <td>
                                    <asp:Label ID="Mon_info_1" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Mon_info_2" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Mon_info_3" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Mon_info_4" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <%--------------------------------------------------------------%>
                            <tr valign="middle" align="center" class="table-danger">
                                <td rowspan="2">الثلاثاء</td>
                                <td>
                                    <asp:Label ID="Thr_time_1" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Thr_time_2" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Thr_time_3" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Thr_time_4" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr valign="middle" align="center" class="table-danger">

                                <td>
                                    <asp:Label ID="Thr_info_1" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Thr_info_2" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Thr_info_3" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Thr_info_4" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <%--------------------------------------------------------------%>

                            <tr valign="middle" align="center" class="table-active">
                                <td rowspan="2">الأربعاء</td>
                                <td>
                                    <asp:Label ID="Wed_time_1" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Wed_time_2" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Wed_time_3" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Wed_time_4" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr valign="middle" align="center" class="table-active ">

                                <td>
                                    <asp:Label ID="Wed_info_1" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Wed_info_2" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Wed_info_3" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Wed_info_4" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <%--------------------------------------------------------------%>
                            <tr valign="middle" align="center" class="table-danger">
                                <td rowspan="2">الخميس</td>
                                <td>
                                    <asp:Label ID="Thu_time_1" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Thu_time_2" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Thu_time_3" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Thu_time_4" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr valign="middle" align="center" class="table-danger">

                                <td>
                                    <asp:Label ID="Thu_info_1" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Thu_info_2" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Thu_info_3" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Thu_info_4" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>


                    </div>

                </div>
                <div runat="server" visible="false" id="function11">

                    <div class="container-fluid mt-5 text-center pb-5">

                        <asp:Label ID="add_grade_error" runat="server" Text=""></asp:Label>

                    </div>

                    <div class="input-group">
                        <span class="input-group-text  bg-dark-subtle text-primary">القسم</span>

                        <asp:DropDownList ID="add_grade_deb" CssClass="form-select text-center" AutoPostBack="true" OnSelectedIndexChanged="add_grade_deb_SelectedIndexChanged" runat="server"></asp:DropDownList>

                        &nbsp;&nbsp;&nbsp;
                            <span class="input-group-text  bg-dark-subtle text-primary">المرحلة</span>
                        <asp:DropDownList ID="add_grade_stage" CssClass="form-select text-center" AutoPostBack="true" OnSelectedIndexChanged="add_grade_deb_SelectedIndexChanged" runat="server">
                            <asp:ListItem Value="1">الاولى </asp:ListItem>
                            <asp:ListItem Value="2">الثانية</asp:ListItem>
                            <asp:ListItem Value="3"> الثالثة</asp:ListItem>
                            <asp:ListItem Value="4">الرابعة</asp:ListItem>
                        </asp:DropDownList>

                    </div>


                    <hr />

                    <div class="input-group">
                        <span class="input-group-text  bg-dark-subtle text-primary">الطالب</span>
                        <asp:DropDownList ID="add_grade_student" CssClass="form-select text-center" runat="server"></asp:DropDownList>
                        &nbsp;&nbsp;
                       
                        <span class="input-group-text  bg-dark-subtle text-primary">المادة</span>
                        <asp:DropDownList ID="add_grade_mat" CssClass="form-select text-center" runat="server" AutoPostBack="true" OnSelectedIndexChanged="add_grade_mat_SelectedIndexChanged"></asp:DropDownList>
                        &nbsp;&nbsp;
                       
                    </div>
                    <hr />

                    <div class="input-group">
                        <span class="input-group-text  bg-dark-subtle text-primary">الشهر الاول</span>
                        <asp:TextBox ID="add_grade_g1" CssClass="form-control text-center" step="0.01" TextMode="Number" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;

                        <span class="input-group-text  bg-dark-subtle text-primary">الشهر الثاني</span>
                        <asp:TextBox ID="add_grade_g2" CssClass="form-control text-center" step="0.01" TextMode="Number" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;

                        <span class="input-group-text  bg-dark-subtle text-primary">الشهر الثالث</span>
                        <asp:TextBox ID="add_grade_g3" CssClass="form-control text-center" step="0.01" TextMode="Number" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;

                        <span class="input-group-text  bg-dark-subtle text-primary">الغياب</span>
                        <asp:TextBox ID="add_grade_absence" CssClass="form-control text-center" step="0.01" TextMode="Number" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;

                        <span class="input-group-text  bg-dark-subtle text-primary">الاضافات</span>
                        <asp:TextBox ID="add_grade_plus" CssClass="form-control text-center" step="0.01" TextMode="Number" runat="server"></asp:TextBox>

                    </div>


                    <hr />
                    <asp:Button ID="add_grade_save" CssClass="w-100 btn btn-outline-success m-1" runat="server" OnClick="add_grade_save_Click" Text="حفظ" />





                </div>
                <div runat="server" visible="false" id="function12">


                    <div class="input-group">
                        <span class="input-group-text  bg-dark-subtle text-primary">القسم</span>

                        <asp:DropDownList ID="show_grade_deb" CssClass="form-select text-center" AutoPostBack="true" OnSelectedIndexChanged="show_grade_deb_SelectedIndexChanged" runat="server"></asp:DropDownList>

                        &nbsp;&nbsp;&nbsp;
                            <span class="input-group-text  bg-dark-subtle text-primary">المرحلة</span>
                        <asp:DropDownList ID="show_grade_stage" CssClass="form-select text-center" AutoPostBack="true" OnSelectedIndexChanged="show_grade_deb_SelectedIndexChanged" runat="server">
                            <asp:ListItem Value="1">الاولى </asp:ListItem>
                            <asp:ListItem Value="2">الثانية</asp:ListItem>
                            <asp:ListItem Value="3"> الثالثة</asp:ListItem>
                            <asp:ListItem Value="4">الرابعة</asp:ListItem>
                        </asp:DropDownList>
                        <span class="input-group-text  bg-dark-subtle text-primary">المادة</span>
                        <asp:DropDownList ID="show_grade_mat" CssClass="form-select text-center" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </div>
                    <hr />

                    <asp:GridView ID="GridView1" CssClass="w-100 text-center" runat="server" DataSourceID="show_degree_Datasource" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">

                        <Columns>

                            <asp:BoundField DataField="Name" HeaderText="إسم الطالب" SortExpression="Name" />
                            <asp:BoundField DataField="g1" HeaderText="الشهر الاول" SortExpression="Grade" />
                            <asp:BoundField DataField="g2" HeaderText="الشهر الثاني" SortExpression="Grade" />
                            <asp:BoundField DataField="g3" HeaderText="الشهر الثالث" SortExpression="Grade" />
                            <asp:BoundField DataField="absence" HeaderText="الغياب" SortExpression="Grade" />
                            <asp:BoundField DataField="pluses" HeaderText="الاضافات" SortExpression="Grade" />
                            <asp:BoundField DataField="FinalGrade" HeaderText="الدرجة النهائية (السعي)" SortExpression="Grade" />

                        </Columns>


                        <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>

                        <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="#000066"></PagerStyle>

                        <RowStyle ForeColor="#000066"></RowStyle>


                    </asp:GridView>




                    <asp:SqlDataSource runat="server" ID="show_degree_Datasource" ConnectionString='<%$ ConnectionStrings:con %>' SelectCommand="SELECT dbo.Student.Name, dbo.Grade.g1 ,dbo.Grade.g2 ,dbo.Grade.g3 ,dbo.Grade.absence ,dbo.Grade.pluses,  dbo.Grade.FinalGrade 
FROM     dbo.Student INNER JOIN
                  dbo.Grade ON dbo.Student.Id = dbo.Grade.StuID INNER JOIN
                  dbo.Department ON dbo.Student.Deb = dbo.Department.Id INNER JOIN
                  dbo.Material ON dbo.Grade.MetID = dbo.Material.Id AND dbo.Department.Id = dbo.Material.DebId
WHERE  (dbo.Department.Id = @debid) AND (dbo.Student.Stage = @stageid) AND (dbo.Material.Id = @matid)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="show_grade_deb" PropertyName="SelectedValue" DefaultValue="-1" Name="debId"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="show_grade_stage" PropertyName="SelectedValue" DefaultValue="-1" Name="stageid"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="show_grade_mat" PropertyName="SelectedValue" DefaultValue="-1" Name="matId"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div runat="server" visible="false" id="function13">

                    <div class="container-fluid mt-5 text-center pb-5">

                        <asp:Label ID="add_grp_error" runat="server" Text=""></asp:Label>

                    </div>

                    <p>اسم الكروب</p>
                    <asp:TextBox ID="add_grp_latter" CssClass="form-control" runat="server"></asp:TextBox>

                    <hr />

                    <p>الحد الأقصى لعدد الطلاب</p>

                    <asp:TextBox ID="add_grp_max" CssClass="form-control" TextMode="number" runat="server"></asp:TextBox>

                    <hr />

                    <p>القسم</p>

                    <asp:DropDownList ID="add_grp_deb" CssClass="form-select" runat="server"></asp:DropDownList>

                    <hr />

                    <p>المرحلة</p>
                    <asp:DropDownList ID="add_grp_stage" CssClass="form-select" runat="server">
                        <asp:ListItem Value="-1">اختر المرحلة</asp:ListItem>
                        <asp:ListItem Value="1">الأولى</asp:ListItem>
                        <asp:ListItem Value="2">الثانية</asp:ListItem>
                        <asp:ListItem Value="3">الثالثة</asp:ListItem>
                        <asp:ListItem Value="4">الرابعة</asp:ListItem>
                    </asp:DropDownList>
                    <hr />

                    <asp:Button ID="add_grp_save" runat="server" CssClass="btn btn-outline-success w-100  text-center " Text="حفظ" OnClick="add_grp_save_Click" />


                </div>
            </div>
        </form>
    </div>

</body>
</html>
