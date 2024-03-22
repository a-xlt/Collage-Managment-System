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
<body>




    <div class="container-fluid">
        <form id="form1" runat="server">

            <h1 class="text-center pt-3 pb-3 bg-black bg-opacity-10 text-dark">كلية تكنولوجيا المعلومات</h1>

            <h3 align="center">اختر العملية المطلوبة</h3>
            <div class="border-1 border-opacity-25 border-bottom">
                <asp:DropDownList ID="functionDDl" OnSelectedIndexChanged="functionDDl_SelectedIndexChanged" runat="server" CssClass="form-select user-select-none text-center" AutoPostBack="true">
                    <asp:ListItem Selected="True" Text="اختر العملية...." Value="-1">  </asp:ListItem>
                    <asp:ListItem Value="1"> إضافة قسم </asp:ListItem>
                    <asp:ListItem Value="2"> حذف قسم </asp:ListItem>
                    <asp:ListItem Value="3"> اضافة طالب </asp:ListItem>
                    <asp:ListItem Value="4"> عرض الطلاب </asp:ListItem>
                    <asp:ListItem Value="5"> حذف طالب </asp:ListItem>
                    <asp:ListItem Value="6"> اضافة مادة </asp:ListItem>
                    <asp:ListItem Value="7"> حذف مادة </asp:ListItem>
                    <asp:ListItem Value="8"> عرض مواد قسم </asp:ListItem>
                    <asp:ListItem Value="9"> إضافة جدول لقسم </asp:ListItem>
                    <asp:ListItem Value="10"> عرض جداول قسم </asp:ListItem>
                    <asp:ListItem Value="11"> اضافة درجة طالب  </asp:ListItem>
                    <asp:ListItem Value="12"> حذف درجة مادة  </asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="container-fluid">

                <hr class="hr" />
                <div class="container-fluid">
                    <hr class="hr" />
                    <div class="container-fluid">
                        <hr class="hr" />
                    </div>

                </div>

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


                    <div class="container-fluid mt-5 text-center">

                        <asp:Label ID="errorLB" runat="server" Text=""></asp:Label>

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

                        <div class="container-fluid mt-5 text-center">

                            <asp:Label ID="del_deb_errorLB" runat="server" Text=""></asp:Label>

                        </div>

                    </div>

                </div>
                <div runat="server" visible="false" id="function3">

                    <div class="container-fluid mt-5 text-center">

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
                    <asp:TextBox ID="Add_stu_Stage" CssClass="form-control" TextMode="Number" max="4" min="1" runat="server"></asp:TextBox>
                    <hr />



                    <p>الجنس</p>
                    <asp:DropDownList ID="Add_stu_gender" CssClass="form-select" runat="server">
                        <asp:ListItem Value="male">ذكر</asp:ListItem>
                        <asp:ListItem Value="female">انثى</asp:ListItem>
                    </asp:DropDownList>

                    <hr />


                    <p>رقم موبايل الطالب</p>
                    <asp:TextBox ID="Add_stu_phone" CssClass="form-control" TextMode="Phone" runat="server"></asp:TextBox>
                    <hr />


                    <asp:Button ID="Add_stu_saveBTN" runat="server" CssClass="btn btn-outline-success w-100  text-center " Text="حفظ" OnClick="Add_stu_saveBTN_Click" />


                </div>
                <div runat="server" visible="false" id="function4">


                    <br />
                    <asp:DropDownList ID="show_stu_del_ddl" CssClass="form-select" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <br />


                    <asp:GridView ID="Student_show_DG" runat="server" CssClass="text-center" Style="width: 100%;" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="2px" CellPadding="4" DataSourceID="Student_Show_DG_DataSource" ForeColor="Black" GridLines="Vertical" PageSize="6">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Id_str" HeaderText="الرمز الجامعي" SortExpression="Id_str" />
                            <asp:BoundField DataField="Name" HeaderText="الاسم" SortExpression="Name" />
                            <asp:BoundField DataField="Birthdate" HeaderText="تاريخ الميلاد" SortExpression="Birthdate" />
                            <asp:BoundField DataField="Stage" HeaderText="المرحلة" SortExpression="Stage" />
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

                    <asp:SqlDataSource ID="Student_Show_DG_DataSource" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT *  FROM Student where Deb =  @debId">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="show_stu_del_ddl" Name="debId" PropertyName="Text" Type="Int32" DefaultValue="0" />
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

                </div>
                <div runat="server" visible="false" id="function7">
                </div>
                <div runat="server" visible="false" id="function8">
                </div>
                <div runat="server" visible="false" id="function9">
                </div>
                <div runat="server" visible="false" id="function10">
                </div>
                <div runat="server" visible="false" id="function11">
                </div>
                <div runat="server" visible="false" id="function12">
                </div>

            </div>


        </form>
    </div>

</body>
</html>
