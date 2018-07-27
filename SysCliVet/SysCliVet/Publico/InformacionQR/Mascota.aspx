<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mascota.aspx.cs" Inherits="SysCliVet.Publico.InformacionQR.Mascota" %>


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
    <!-- jQuery -->
    <script src="<%=ResolveUrl("~/src/vendors/jquery/dist/jquery.min.js") %>"></script>

    <style type="text/css">
        .Login_link {
            text-decoration: none !important;
            color: #ffffff;
        }

            .Login_link:hover {
                text-decoration: none !important;
                color: #808080;
            }

        .divDatos {
            border-radius: 4% 4%;
            background: #fff;
            padding: 15px 0;
        }

        .login_content a:hover {
            text-decoration: none;
        }
    </style>

    <script type="text/javascript">

        $(function () {
            if ($("input[id$=hfNroPropietario]").val() != "0") {
                $("[id$=btnLlamar]").attr("href", "tel:" + $("input[id$=hfNroPropietario]").val());
            }
        });

        function FN_Mensaje(tipo, mensaje, id) {
            var result = '';
            switch (tipo) {
                case "s":
                    result = '<div class="myForm1_alert"><span class=""></span><p class="alert alert-success">' + ((mensaje == undefined) ? "Guardado Correctamente!" : mensaje) + '</p></div>'
                    break;
                case "e":
                    result = '<div class="myForm1_alert"><span class=""></span><p class="alert alert-danger">' + ((mensaje == undefined) ? "Ha ocurrido un error guardando" : mensaje) + '</p></div>';
                    break;
                case "i":
                    result = '<p class="alert alert-warning">' + ((mensaje == undefined) ? "Advertencia!" : mensaje) + '</p>';
                    break;
            }

            if (id == '' || id == undefined) {
                $('div[id$=idMensaje]').empty().fadeIn().append(result);
                $('div[id$=idMensaje]').delay("6000").fadeOut();
            } else {
                $('div[id$=' + id + ']').empty().fadeIn().append(result);
                $('div[id$=' + id + ']').delay("6000").fadeOut();
            }
            $('html, body').animate({ scrollTop: 1 }, 'slow');
        }
    </script>

</head>

<body class="login" style="">
    <div>
        <div class="login_wrapper">
            <div class="animate form login_form">
                <br>
                <div id="idMensaje"></div>
                <div style="text-align: center;">
                    <img src="../src/img/logo.jpg" height="180" />
                </div>
                <section class="login_content">
                    <form runat="server">
                        <h1 style="color: #ffffff; letter-spacing: 0">Datos de Mascota</h1>
                        <div class="divDatos">
                            <div>
                                <span style="font-weight: bold" class="">Nombre: <span id="lblNombre" runat="server"></span></span>
                            </div>
                            <div>
                                <span style="font-weight: bold" class="">Fecha de Nacimiento: <span id="lblFechaNac" runat="server"></span></span>
                            </div>
                            <div>
                                <span style="font-weight: bold" class="">Raza: <span id="lblRaza" runat="server"></span></span>
                            </div>
                            <div>
                                <span style="font-weight: bold" class="">Color: <span id="lblColor" runat="server"></span></span>
                            </div>
                            <div>
                                <span style="font-weight: bold" class="">Sexo: <span id="lblSexo" runat="server"></span></span>
                            </div>
                        </div>
                        <div class="clearfix"></div>

                        <div class="separator">
                            <div>
                                <a href="#" id="btnLlamar" style="background-color: #449d44;" class="btn btn-success" onclick="return (navigator.userAgent.match(/Android | iPhone | movile /i)) != null;">Llamar al Propietario</a>
                            </div>

                            <div class="clearfix"></div>
                            <br />

                            <div>
                            </div>
                        </div>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

                        <asp:HiddenField ID="hfNroPropietario" Value="0" runat="server" />
                    </form>
                </section>
            </div>

        </div>
    </div>
</body>
</html>
