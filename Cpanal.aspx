﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cpanal.aspx.cs" Inherits="Collage_Managment_System.Cpanal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../lib/bootstrap.min.css" />
    <link
        href="https://unpkg.com/boxicons@2.1.2/css/boxicons.min.css"
        rel="stylesheet"
        asp-append-version="true" />
    <link rel="stylesheet" href="../lib/site.css" />
    <title>كلية تكنولوجيا المعلومات</title>
</head>
<body>
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


        <div runat="server" visible="false" id="function1">
        </div>
        <div runat="server" visible="false" id="function2">
        </div>
        <div runat="server" visible="false" id="function3">
          
              <div class="container-fluid mt-5 text-center">

      <asp:Label ID="errorLB" runat="server" Text=""></asp:Label>

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
        </div>
        <div runat="server" visible="false" id="function5">
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



    </form>
</body>
</html>
