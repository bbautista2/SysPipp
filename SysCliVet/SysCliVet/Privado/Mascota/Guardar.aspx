<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" CodeBehind="Guardar.aspx.cs" Inherits="SysCliVet.Privado.Mascota.Guardar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>Mascota</h3>
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

                        <form class="form-horizontal form-label-left" novalidate>

                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">
                                    Nombre <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtNombre" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="txtNombre" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">
                                    Tipo<span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <select class="form-control" id="ddlTipo">
                                        <option>Choose option</option>
                                        <option>Tipo 1</option>
                                        <option>Tipo 2</option>
                                        <option>Tipo 3</option>
                                        <option>Tipo 4</option>
                                    </select>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="telephone">
                                    Raza <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <select class="form-control" id="ddlRaza">
                                        <option>Choose option</option>
                                        <option>Raza 1</option>
                                        <option>Raza 2</option>
                                        <option>Raza 3</option>
                                        <option>Raza 4</option>
                                    </select>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="telephone">
                                    Sexo <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div id="gender" class="btn-group" data-toggle="buttons">
                                        <label class="btn btn-default" data-toggle-class="btn-primary" data-toggle-passive-class="btn-default">
                                            <input type="radio" name="gender" value="male">
                                            &nbsp; Male &nbsp;
                           
                                        </label>
                                        <label class="btn btn-primary" data-toggle-class="btn-primary" data-toggle-passive-class="btn-default">
                                            <input type="radio" name="gender" value="female">
                                            Female
                           
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="telephone">
                                    Color <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="tel" id="txtColor" name="txtTelefono" required="required" data-validate-length-range="8,20" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="telephone">
                                    Propietario <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="tel" id="txtPropietario" name="txtTelefono" required="required" data-validate-length-range="8,20" placeholder="DNI" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="textarea">
                                    Notas 
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <textarea id="txtNotas" name="txtNotas" class="form-control col-md-7 col-xs-12"></textarea>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="textarea">
                                    Foto 
                                </label>
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <img id="ImageMain" runat="server" style="margin-top: 12px; margin-left: 8px; max-width: 100px" onerror="this.src='../../src/images/image_not_found.jpg'" />
                                    <div class="fileUpload btn btn-primary" style="margin-left: 18px;">
                                        <span>Upload File</span>
                                        <input type="file" class="upload" id="FuPMain" accept="image/*" onchange="uploadsliderimage('FuPMain')" />
                                    </div>
                                </div>
                            </div>
                            <div class="ln_solid"></div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <button type="submit" class="btn btn-default">Regresar</button>
                                    <button id="send" type="submit" class="btn btn-success">Guardar</button>
                                </div>
                            </div>
                        </form>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfImageSrc" runat="server" />
    <asp:HiddenField ID="hfMain" runat="server" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ScripPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            FN_Inicio();
        });

        function uploadsliderimage(input) {
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
                    var img = $.parseJSON(msg).name;
                    console.log(img);
                    var s = img.split("/");
                    var str = s[s.length - 1];
                    $("input[id$=hfMain]").val(str);
                    $("input[id$=hfImageSrc]").val(img);
                    $("input[id$=ImageMain]").attr("src", img);
                    });
            }
        }

    </script>
</asp:Content>
