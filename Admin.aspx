<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Collage_Managment_System.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="/lib/bootstrap.min.css" />
    <link
        href="https://unpkg.com/boxicons@2.1.2/css/boxicons.min.css"
        rel="stylesheet"
        asp-append-version="true" />
    <link rel="stylesheet" href="lib/site.css" />



    <title>كلية تكنولوجيا المعلومات</title>
</head>
<body>
     <h1 class="text-center pt-3 pb-3 bg-black bg-opacity-10 text-dark">كلية تكنولوجيا المعلومات</h1>


 <div class="row bg-info bg-opacity-25 text-center">


     <div class=" col-2 ms-2 me-2 border-black border-start border-1">
         <div class="dropdown">
             <a class="h5 text-success-emphasis text-decoration-none dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">الطلاب
             </a>
             <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                 <a class="dropdown-item" href="#">اضافة طالب</a>
                 <a class="dropdown-item" href="#">اضافة درجات لطالب</a>
                 <a class="dropdown-item" href="#">تعديل درجة لطالب</a>
                 <a class="dropdown-item" href="#">البحث عن طالب </a>
                 <a class="dropdown-item" href="#">حذف معلومات طالب</a>
                 <a class="dropdown-item" href="#">تعديل معلومات طالب</a>
                 <a class="dropdown-item" href="#"> البحث المتقدم</a>
             </div>
         </div>
     </div>

     <div class=" col-2 ms-2 me-2 border-black border-start border-1">
         <div class="dropdown">
             <a class="h5 text-success-emphasis text-decoration-none dropdown-toggle" href="#" role="button" id="dropdownMenuLink2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">الأساتذة
             </a>
             <div class="dropdown-menu" aria-labelledby="dropdownMenuLink2">
                 <a class="dropdown-item" href="#">اضافة استاذ</a>
                 <a class="dropdown-item" href="#">البحث عن استاذ </a>
                 <a class="dropdown-item" href="#">حذف معلومات استاذ</a>
                 <a class="dropdown-item" href="#">تعديل معلومات استاذ</a>
                 <a class="dropdown-item" href="#">البحث المتقدم</a>
             </div>
         </div>
     </div>

     <div class=" col-2 ms-2 me-2 border-black border-start border-1">
         <div class="dropdown">
             <a class="h5 text-success-emphasis text-decoration-none dropdown-toggle" href="#" role="button" id="dropdownMenuLink3" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">المواد و الجداول الدراسية  
             </a>
             <div class="dropdown-menu" aria-labelledby="dropdownMenuLink3">
                 <a class="dropdown-item" href="#">اضافة مادة دراسية</a>
                 <a class="dropdown-item" href="#">تعديل مادة دراسية </a>
                 <a class="dropdown-item" href="#">حذف مادة دراسية</a>
                 <a class="dropdown-item" href="#">عرض مواد دراسية لقسم</a>
                 <a class="dropdown-item" href="#">اضافة جدول</a>
                 <a class="dropdown-item" href="#">تعديل جدول </a>
                 <a class="dropdown-item" href="#">حذف جدول </a>
                 <a class="dropdown-item" href="#">عرض جداول قسم</a>
             </div>
         </div>
     </div>

     <div class=" col-2 ms-2 me-2 border-black border-start border-1">
         <div class="dropdown">
             <a class="h5 text-success-emphasis text-decoration-none dropdown-toggle" href="#" role="button" id="dropdownMenuLink4" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">الحضور
             </a>
             <div class="dropdown-menu" aria-labelledby="dropdownMenuLink4">
                 <a class="dropdown-item" href="#">اضافة حضور لمادة</a>
                 <a class="dropdown-item" href="#">تعديل حضور لمادة</a>
                 <a class="dropdown-item" href="#">عرض الحضور لمادة</a>
             </div>
         </div>
     </div>

     <div class=" col-2 ms-2 me-2 border-black border-start border-1">
         <div class="dropdown">
             <a class="h5 text-success-emphasis text-decoration-none dropdown-toggle" href="#" role="button" id="dropdownMenuLink5" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">الاقسام و القاعات الدراسية
             </a>
             <div class="dropdown-menu" aria-labelledby="dropdownMenuLink5">
                 <a class="dropdown-item" href="#">اضافة قسم جديد </a>
                 <a class="dropdown-item" href="#">حذف معلومات قسم </a>
                 <a class="dropdown-item" href="#">عرض معلومات </a>

                 <a class="dropdown-item" href="#">اضافة معلومات قاعة دراسية </a>
                 <a class="dropdown-item" href="#">حذف معلومات قاعة دراسية قاعة</a>
                 <a class="dropdown-item" href="#">عرض القاعات في قسم </a>
             </div>
         </div>
     </div>
     
     <div class=" col-1  border-black border-start border-1">
         <div class="dropdown">
             <a class="h5 text-success-emphasis text-decoration-none dropdown-toggle" href="#" role="button" id="dropdownMenuLink6" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">ادارة الحسابات
             </a>
             <div class="dropdown-menu" aria-labelledby="dropdownMenuLink5">
                 <a class="dropdown-item" href="Users/Add.aspx">اضافة حساب جديد </a>
                 <a class="dropdown-item" href="#">حذف حساب  </a>
                 <a class="dropdown-item" href="#">البحث عن الحساب </a>

             </div>
         </div>
     </div>
 </div>


 <br />




    <form id="form1" runat="server">
       

    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>


</body>
</html>
