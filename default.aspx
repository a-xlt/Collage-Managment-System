<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs"
Inherits="Collage_Managment_System._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <link rel="stylesheet" href="../lib/bootstrap.min.css" />
    <link
      href="https://unpkg.com/boxicons@2.1.2/css/boxicons.min.css"
      rel="stylesheet"
      asp-append-version="true"
    />
   <link rel="stylesheet" href="../lib/site.css" />
    <title>كلية تكنولوجيا المعلومات</title>
  </head>
  <body>
    <h1 class="text-center mt-3">كلية تكنولوجيا المعلومات</h1>
    <form id="form1" runat="server" class="justify-content-center" >
      <br />
      <hr />
      <div class="container  signInform">

        <div class="form-group">
          <label class="control-label" for="UserName">اسم المستخدم</label><br>
          <input
            type="text"
            id="UserName"
            name="UserName"
            class="form-control"
            runat="server"
          />
        </div>
        <br />
        <div class="form-group"> 
          <label class="control-label" for="Password">كلمة السر </label>
          <input
            type="text"
            id="Password"
            class="form-control"
            runat="server"
          />
        </div>
        <br>

        
        <br />
        <div class="form-group">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn btn-outline-success w-100" Text="تسجيل الدخول" />


        </div>
      </div>
   </form><script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script><script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script><script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
  </body>
</html>
