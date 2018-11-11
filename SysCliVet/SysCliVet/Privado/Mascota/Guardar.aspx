<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" CodeBehind="Guardar.aspx.cs" Inherits="SysCliVet.Privado.Mascota.Guardar" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>Paciente</h3>
            </div>
        </div>

        <div class="clearfix"></div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Datos </h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <br>
                        <div id="idMensaje"></div>

                        <div class="form-horizontal form-label-left">

                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtNombre">
                                    Nombre <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtNombre" runat="server" class="form-control col-md-7 col-xs-12" name="txtNombre" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Fecha Nac. <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtFechaNac" runat="server" class="form-control col-md-7 col-xs-12" name="txtFechaNac" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Raza
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtRaza" runat="server" class="form-control col-md-7 col-xs-12" name="txtRaza" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="color">
                                    Color
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="text" runat ="server"  id="txtColor" name="txtColor" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Especie <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="text" runat="server" id="txtEspecie" name="txtEspecie" required="required" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="sexo">
                                    Sexo <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div id="gender" class="btn-group" data-toggle="buttons">
                                        <label class="btn btn-default" data-toggle-class="btn-primary" data-toggle-passive-class="btn-default">
                                            <input type="radio" name="gender" id="rbMacho" runat="server">
                                            &nbsp; Macho &nbsp;                           
                                        </label>
                                        <label class="btn btn-primary" data-toggle-class="btn-primary" data-toggle-passive-class="btn-default">
                                            <input type="radio" name="gender" id="rbHembra" runat="server">
                                            Hembra                           
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Intac
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12" style="padding-top: 8px;">
                                    Sí
                                            <input type="radio" runat="server" class="flat" name="rbIntac" id="rbIntacSi" />
                                    No
                                            <input type="radio" runat="server" class="flat" name="rbIntac" id="rbIntacNo" />
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Cast
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12" style="padding-top: 8px;">
                                    Sí
                                            <input type="radio" runat="server" class="flat" name="rbCast" id="rbCastSi" />
                                    No
                                            <input type="radio" runat="server" class="flat" name="rbCast" id="rbCastNo" />
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Peso
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="text" id="txtPeso" runat="server" name="txtPeso" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Marca distintiva
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="text" id="txtMarcaDist" runat="server" name="txtMarcaDist" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group hidden">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtPropietario">
                                    Propietario <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtPropietario" runat="server" name="txtPropietario" required="required" maxlength="8" placeholder="DNI" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group" style="margin-top:15px;">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="foto">
                                    Foto 
                                </label>
                                <div class="col-md-9 col-sm-9 col-lg-9">                                    
                                    <div class="fileUpload btn btn-primary">
                                        <span>Upload File</span>
                                        <input type="file" class="upload" id="FuPMain" accept="image/*" onchange="FN_SubirImagen('FuPMain')" />
                                    </div>
                                    <img id="ImageMain" runat="server" style="margin-left: 8px; max-width: 100px" onerror="this.src='../../src/imagenes/default.png'" />
                                </div>
                            </div>
                            <div class="item form-group" style="margin-top:15px;">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Código QR 
                                </label>
                                <div class="col-md-9 col-sm-9 col-lg-9">      
                                    <asp:Button ID="btnGenerarQR" runat="server"
                                        Text="Generar" OnClick="btnGenerar_Click" CssClass="btn btn-success" />
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtMotivoCons">
                                </label>
                                <div class="control-label col-md-3 col-sm-3 col-xs-12">
                                    <h4 class="text-left">Información del Propietario</h4>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    DNI <span class="required">*</span>
                                </label>
                                <div class="input-group col-md-6 col-sm-6 col-xs-12" style="padding-right: 5px!important; padding-left: 10px!important; float: left!important">
                                    <input id="txtDni" runat="server" class="form-control col-md-7 col-xs-12" required="required" type="text" maxlength="8">
                                    <span class="input-group-btn">
                                        <button id="btnBuscarPropietario" type="button" class="btn btn-primary" style="height: 34px;"><i class="fa fa-search"></i></button>
                                    </span>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtNombrePro">
                                    Nombre <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtNombrePro" disabled runat="server" class="form-control col-md-7 col-xs-12" name="txtNombrePro" required="required" type="text">
                                </div>
                            </div>
                            <div class="ln_solid"></div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <a type="submit" class="btn btn-default" href="Listar.aspx"><i class="fa fa-arrow-circle-left"></i>Regresar</a>
                                    <asp:Button ID="btnGuardar" runat="server"
                                        Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfImageSrc" runat="server" />
    <asp:HiddenField ID="hfMain" runat="server" />
    <asp:HiddenField ID="hfIdPropietario" runat="server" />
    <asp:HiddenField ID="hfMascotaId" runat="server" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script src="<%=ResolveUrl("~/Privado/FichaClinica/js/autocomplete.js") %>"></script>
    <script type="text/javascript">
        $(function () {

          $("[id$=btnGuardar]").click(function (x) {
                var submit = true;

                // evaluate the form using generic validaing
                if (!validator.checkAll($('#FormPrincipal'))) {
                    submit = false;
                }

                if (!submit) { x.preventDefault(); }

            });

            $("[id$=btnBuscarPropietario]").on('click', function (e) {
                FN_BuscarPropietario();
            });

        });


        function FN_SubirImagen(input) {
            var archivos = document.getElementById(input);//Damos el valor del input tipo file
            var archivo = archivos.files;
            var data = new FormData();
            if (archivo.length == 0) {
                fn_message('e', "You have to upload a file");
            } else {

                for (i = 0; i < archivo.length; i++) {
                    data.append('archivo' + i, archivo[i]);
                }
                var url = '../../FileUpload.ashx?p=1';
                $.ajax({
                    url: url, //Url a donde la enviaremos
                    type: 'POST', //Metodo que usaremos
                    contentType: false, //Debe estar en false para que pase el objeto sin procesar
                    data: data, //Le pasamos el objeto que creamos con los archivos
                    processData: false, //Debe estar en false para que JQuery no procese los datos a enviar
                    cache: false //Para que el formulario no guarde cache
                }).done(function (msg) {
                    var img = $.parseJSON(msg).nombre;
                    console.log(img);
                    var s = img.split("/");
                    var str = s[s.length - 1];
                    $("input[id$=hfMain]").val(str);
                    $("input[id$=hfImageSrc]").val(img);
                    $("img[id$=ImageMain]").attr("src", img);
                });
            }
        }

        function FN_GenerarCodigoQR() {
            var mascotaId = $("input[id$=hfMascotaId]").val();
            var nombreMascota = $("input[id$=txtNombre]").val();
            success = function (response) {
                FN_Mensaje(response.d.tipo, response.d.mensaje);
            }
            error = function (xhr, ajaxOptions, thrownError) {
            };

            FN_LlamarMetodo("Guardar.aspx/GenerarCodigoQr", '{mascotaId:"'+mascotaId+'", nombreMascota:"'+nombreMascota+'"}', success, error);
        }

        function FN_BuscarPropietario() {
            $(".autocomplete-suggestions").remove();
            FN_LimpiarDatosPropietario();
            var Dni = $("[id$=txtDni]").val();

            success = function (response) {
                var lista = response.d;
                if (lista != null && lista.length > 0) {
                    var listaPropietarios = $.map(lista, function (value, key) {
                        return {
                            value: value,
                            data: key
                        };
                    });

                    // initialize autocomplete with custom appendTo
                    $('[id$=txtDni]').autocomplete({
                        lookup: listaPropietarios
                    });
                    setTimeout(function () { $("[id$=txtDni]").trigger('keyup'); }, 1000);
                }
            }

            error = function (xhr, ajaxOptions, thrownError) {
                console.log("colocar mensaje de error");
            };

            FN_LlamarMetodo("../FichaClinica/Guardar.aspx/ListaPropietariosPorDni", '{dni: "' + Dni + '" }', success, error);

        }

        function FN_LimpiarDatosPropietario() {
            $("input[id$=hfIdPropietario]").val("0");
            $("input[id$=txtNombrePro], input[id$=txtApellidos], input[id$=txtFechaNacPro], input[id$=txtDireccion], input[id$=txtCelular], input[id$=txtTelefono], input[id$=txtEmail]").val("");
        }

    </script>
</asp:Content>
