<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acceso.aspx.cs" Inherits="SysCliVet.Publico.Acceso" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Pippa Pets</title>

    <!-- Bootstrap -->
    <link href="<%=ResolveUrl("~/src/vendors/bootstrap/dist/css/bootstrap.min.css") %>" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="<%=ResolveUrl("~/src/vendors/font-awesome/css/font-awesome.min.css") %>" rel="stylesheet">  
    <!-- NProgress -->
    <link href="<%=ResolveUrl("~/src/vendors/nprogress/nprogress.css") %>" rel="stylesheet">      
    <!-- Animate.css -->
    <link href="<%=ResolveUrl("~/src/vendors/animate.css/animate.min.css") %>" rel="stylesheet">  
    <!-- Custom Theme Style -->
    <link href="<%=ResolveUrl("~/src/build/css/custom-purple.min.css") %>" rel="stylesheet">  
   
   <style type="text/css">
       .Login_link {
       text-decoration: none !important;
       color:#ffffff;       
       }

        .Login_link:hover {
       text-decoration: none !important;
       color:#808080;       
       }
   </style>

  </head>

  <body class="login" style="">
    <div>
      <a class="hiddenanchor" id="signup"></a>
      <a class="hiddenanchor" id="signin"></a>


      <div class="login_wrapper">
        <div class="animate form login_form">
        <div  style="text-align:center;">
        <img src="src/img/logo.jpg" height="180" />
        </div>
          <section class="login_content">
            <form novalidate>
              <h1 style="color:#ffffff;letter-spacing:0">Iniciar Sesion</h1>
              <div>
                  <asp:TextBox ID="txtUsuario" class="form-control" runat="server" Placeholder="Usuario"></asp:TextBox> 
              </div>
              <div>
                  <asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password" Placeholder="Constraseña" required=""></asp:TextBox> 
              </div>
              <div>
                <a class="btn btn-default" href="<%=ResolveUrl("~/Privado/Inicio.aspx") %>">Ingresar</a>                
                  <asp:LinkButton ID="btnLogin" Text="Ingresar" class="btn btn-primary" runat="server" onclick="btnLogin_Click"></asp:LinkButton>
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <p class="change_link">
                  <a href="#signup" class="to_register Login_link"> Olvidaste tu Contraseña! </a>
                </p>

                <div class="clearfix"></div>
                <br />

                <div>
                 
                </div>
              </div>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </form>
          </section>
        </div>

        <div id="register" class="animate form registration_form">
        <div id="col-md-12" style="text-align:center;">
        <img src="src/img/logo.jpg" height="180" />
        </div>
          <section class="login_content">
            <form>
              <h2 style="color:#ffffff">Recuperar Contraseña</h2>
              <div>
                <input type="text" class="form-control" placeholder="Usuario" required="" />
              </div>
         
              <div>
                <a class="btn btn-default submit" href="index.html">Enviar</a>
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <p class="change_link" style="color:#fff">Eres usuario?
                  <a href="#signin" class="to_register Login_link"  > Ingresa </a>
                </p>

                <div class="clearfix"></div>
                <br />

                <div>
                  <h1><i class="fa fa-paw" style="color:#ffffff"></i> </h1>
                 
                </div>
              </div>
            </form>
          </section>
        </div>
      </div>
    </div>
  </body>
</html>

