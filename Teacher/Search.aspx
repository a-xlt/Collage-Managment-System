<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Collage_Managment_System.Teacher.Search" %>

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
     <h1 class="text-center pt-3 pb-3 bg-black bg-opacity-10 text-dark">كلية تكنولوجيا المعلومات</h1>


 <div class="row bg-info bg-opacity-25 text-center">


     <div class=" col-2 ms-2 me-2 border-black border-start border-1">
         <div class="dropdown">
             <a class="h6 text-success-emphasis text-decoration-none dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">الطلاب
             </a>
             <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                 <a class="dropdown-item" href="../Student/Add.aspx">اضافة طالب</a>
                 <a class="dropdown-item" href="../Student/AddDegree.aspx">اضافة درجات لطالب</a>
                 <a class="dropdown-item" href="../Student/EditDegree.aspx">تعديل درجة لطالب</a>
                 <a class="dropdown-item" href="../Student/Search.aspx">البحث عن طالب </a>
                 <a class="dropdown-item" href="../Student/Delete.aspx">حذف معلومات طالب</a>
                 <a class="dropdown-item" href="../Student/Edit.aspx">تعديل معلومات طالب</a>
                 <a class="dropdown-item" href="../Student/AdvanceSearch.aspx"> البحث المتقدم</a>
             </div>
         </div>
     </div>

     <div class=" col-2 ms-2 me-2 border-black border-start border-1">
         <div class="dropdown">
             <a class="h6 text-success-emphasis text-decoration-none dropdown-toggle" href="#" role="button" id="dropdownMenuLink2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">الأساتذة
             </a>
             <div class="dropdown-menu" aria-labelledby="dropdownMenuLink2">
                 <a class="dropdown-item" href="../Teacher/Add.aspx">اضافة استاذ</a>
                 <a class="dropdown-item" href="../Teacher/Search.aspx">البحث عن استاذ </a>
                 <a class="dropdown-item" href="../Teacher/Delete.aspx">حذف معلومات استاذ</a>
                 <a class="dropdown-item" href="../Teacher/Edit.aspx">تعديل معلومات استاذ</a>
                 <a class="dropdown-item" href="../Teacher/AdvanceSearch.aspx">البحث المتقدم</a>
             </div>
         </div>
     </div>

     <div class=" col-2 ms-2 me-2 border-black border-start border-1">
         <div class="dropdown">
             <a class="h6 text-success-emphasis text-decoration-none dropdown-toggle" href="#" role="button" id="dropdownMenuLink3" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">المواد و الجداول الدراسية  
             </a>
             <div class="dropdown-menu" aria-labelledby="dropdownMenuLink3">
                 <a class="dropdown-item" href="../Material/Add.aspx">اضافة مادة دراسية</a>
                 <a class="dropdown-item" href="../Material/Edit.aspx">تعديل مادة دراسية </a>
                 <a class="dropdown-item" href="../Material/Delete.aspx">حذف مادة دراسية</a>
                 <a class="dropdown-item" href="../Material/Show.aspx">عرض مواد دراسية لقسم</a>
                 <a class="dropdown-item" href="../Sch/Add.aspx">اضافة جدول</a>
                 <a class="dropdown-item" href="../Sch/Edit.aspx">تعديل جدول </a>
                 <a class="dropdown-item" href="../Sch/Delete.aspx">حذف جدول </a>
                 <a class="dropdown-item" href="../Sch/Show.aspx">عرض جداول قسم</a>
             </div>
         </div>
     </div>

     <div class=" col-2 ms-2 me-2 border-black border-start border-1">
         <div class="dropdown">
             <a class="h6 text-success-emphasis text-decoration-none dropdown-toggle" href="#" role="button" id="dropdownMenuLink4" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">الحضور
             </a>
             <div class="dropdown-menu" aria-labelledby="dropdownMenuLink4">
                 <a class="dropdown-item" href="../Absence/Add.aspx">اضافة حضور لمادة</a>
                 <a class="dropdown-item" href="../Absence/Edit.aspx">تعديل حضور لمادة</a>
                 <a class="dropdown-item" href="../Absence/show.aspx">عرض الحضور لمادة</a>
             </div>
         </div>
     </div>

     <div class=" col-2 ms-2 me-2 border-black border-start border-1">
         <div class="dropdown">
             <a class="h6 text-success-emphasis text-decoration-none dropdown-toggle" href="#" role="button" id="dropdownMenuLink5" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">الاقسام و القاعات الدراسية
             </a>
             <div class="dropdown-menu" aria-labelledby="dropdownMenuLink5">
                 <a class="dropdown-item" href="../Department/Add.aspx">اضافة قسم جديد </a>
                 <a class="dropdown-item" href="../Department/Delete.aspx">حذف معلومات قسم </a>
                 <a class="dropdown-item" href="../Department/Show.aspx">عرض معلومات قسم</a>

                 <a class="dropdown-item" href="../Classroom/Add.aspx">اضافة معلومات قاعة دراسية </a>
                 <a class="dropdown-item" href="../Classroom/Delete.aspx">حذف معلومات قاعة دراسية قاعة</a>
                 <a class="dropdown-item" href="../Classroom/Show.aspx">عرض القاعات في قسم </a>
             </div>
         </div>
     </div>
     
     <div class=" col-1  border-black border-start border-1">
         <div class="dropdown">
             <a class="h6 text-success-emphasis text-decoration-none dropdown-toggle" href="#" role="button" id="dropdownMenuLink6" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">ادارة الحسابات
             </a>
             <div class="dropdown-menu" aria-labelledby="dropdownMenuLink5">
                 <a class="dropdown-item" href="../Users/Add.aspx">اضافة حساب جديد </a>
                 <a class="dropdown-item" href="../Users/Delete.aspx">حذف حساب  </a>
                 <a class="dropdown-item" href="../Users/Search.aspx">البحث عن الحساب </a>

             </div>
         </div>
     </div>
 </div>


 <br />




    <form id="form1" runat="server">
        <div>
        </div>
   </form><script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script><script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script><script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
