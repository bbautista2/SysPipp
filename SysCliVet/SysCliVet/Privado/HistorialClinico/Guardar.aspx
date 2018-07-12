<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="Guardar.aspx.cs" Inherits="SysCliVet.Privado.HistorialClinico.Guardar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="">

        <div class="clearfix">
        </div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Historia </h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="#">Settings 1</a>
                                    </li>
                                    <li><a href="#">Settings 2</a>
                                    </li>
                                </ul>
                            </li>
                            <li><a class="close-link"><i class="fa fa-close"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <br>
                        <div id="idMensaje"></div>
                        <div class="form-horizontal form-label-left">
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">
                                    Fecha <span class="required">*</span>
                                </label>
                                <div class="col-md-5 col-sm-6 col-xs-12">
                                    <div class='input-group date' id='FechaHistoria'>
                                        <input id='txtFechaHistoria' runat="server" type='text' class="form-control" required="required" />
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    N° de Ficha <span class="required">*</span>
                                </label>
                                <div class="col-md-2 col-sm-4 col-xs-12">
                                    <asp:Label ID="lblNroFicha" runat="server" CssClass="col-md-7 col-xs-12" Style="padding-top: 8px"></asp:Label>
                                </div>
                            </div>
                            <div class="item form-group">
                                <div class="control-label col-md-3 col-sm-3 col-xs-12">
                                    <h4>Estado General</h4>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-3 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkAgitacion" class="flat" runat="server">
                                    Agitación
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-3 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkDepresion" class="flat" runat="server">
                                    Depresión
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                    Apetito
                                </label>
                                <div class="col-md-5 col-sm-6 col-xs-12">
                                    <div class="radio">
                                        <label>
                                            <input type="radio" runat="server" id="rbApBueno" class="flat" name="rbApetito">
                                            Bueno 
                                        </label>
                                    </div>
                                    <div class="radio">
                                        <label>
                                            <input type="radio" runat="server" id="rbApMalo" class="flat" name="rbApetito">
                                            Malo 
                                        </label>
                                    </div>
                                    <div class="radio">
                                        <label>
                                            <input type="radio" runat="server" id="rbApNormal" class="flat" name="rbApetito">
                                            Normal</label>
                                    </div>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                    Condición Corporal
                                </label>
                                <div class="col-md-5 col-sm-6 col-xs-12">
                                    <div class="radio">
                                        <label>
                                            <input type="radio" class="flat" runat="server" id="rbCCNormal" name="rbCC">
                                            Normal 
                                        </label>
                                    </div>
                                    <div class="radio">
                                        <label>
                                            <input type="radio" class="flat" runat="server" id="rbCCObeso" name="rbCC">
                                            Obeso 
                                        </label>
                                    </div>
                                    <div class="radio">
                                        <label>
                                            <input type="radio" class="flat" runat="server" id="rbCCCaquesico" name="rbCC">
                                            Caquésico</label>
                                    </div>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Peso Actual
                                </label>
                                <div class="col-md-1 col-sm-3 col-xs-12">
                                    <input id="txtPeso" runat="server" class="form-control col-md-7 col-xs-12">
                                </div>
                                <div class="col-md-2 col-sm-4 col-xs-12">
                                    <input id="txtPesoPerdida" runat="server" placeholder="PÉRDIDA/KG/DÍA" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>

                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Signos Clínicos / Sintomas 
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtSintomas" runat="server" type="text" class="sintomas tags form-control" value="" placeholder="Agrega sintoma" />
                                    <div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>
                                </div>
                            </div>

                            <div class="item form-group">
                                <div class="control-label col-md-3 col-sm-3 col-xs-12">
                                    <h3>Análisis Solicitados</h3>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-3 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkHemo" class="flat chkAnalisis" value="1">
                                    Hemograma
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-3 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkBio" class="flat chkAnalisis" value="2">
                                    Bioquímica
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-3 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkUro" class="flat chkAnalisis" value="3">
                                    Uroanálisis
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-3 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkRX" class="flat chkAnalisis" value="4">
                                    RX
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-3 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkEco" class="flat chkAnalisis" value="5">
                                    Eco
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-3 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkCito" class="flat chkAnalisis" value="6">
                                    Citología
                                </div>
                            </div>

                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="textarea">
                                    Descarte 
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <textarea id="txtDescarte" runat="server" name="txtDescarte" class="form-control col-md-7 col-xs-12"></textarea>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="textarea">
                                    Resultados 
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <textarea id="txtResultado" runat="server" name="txtResultado" class="form-control col-md-7 col-xs-12"></textarea>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    DX Presuntivo/Definitivo <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtPresunDefin" runat="server" class="form-control col-md-7 col-xs-12" name="txtNroFicha" required="required" type="text">
                                </div>
                            </div>
                            <div class="tratamientos">
                            <div class="divTratamiento">
                                <div class="item form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    </label>
                                    <div class="control-label col-md-3 col-sm-3 col-xs-12">
                                        <h4 class="text-left">Tratamiento</h4>
                                    </div>
                                    <div class="control-label col-md-3 col-sm-6 col-xs-12">
                                        <button id="addNuevoTratamiento" class="btn btn-primary">Agregar</button>
                                    </div>
                                </div>
                                <div class="item form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                        Fecha<span class="required">*</span>
                                    </label>
                                    <div class="col-md-3 col-sm-6 col-xs-6">
                                        <input id="txtFechaTrat" runat="server" class="form-control col-md-7 col-xs-12" required="required" type="text">
                                    </div>
                                </div>
                                <div class="item form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <table class="table table-striped table-bordered nowrap" id="tbTratamiento">
                                            <thead>
                                                <tr>
                                                    <th style="display: none">Id</th>
                                                    <th>Droga</th>
                                                    <th>Dosis</th>
                                                    <th>Acciones</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>

                                <div class="item form-group">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <button class="btn btn-primary addTratamiento">Agregar</button>
                                    </div>
                                </div>

                                <div class="item form-group" style="margin-top: 14px;">
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="textarea">
                                        Observaciones 
                                    </label>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <textarea id="txtObservacion" runat="server" class="form-control col-md-7 col-xs-12"></textarea>
                                    </div>
                                </div>
                            </div>
                                </div>
                            <div class="ln_solid"></div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <a type="submit" class="btn btn-default" href="Listar.aspx"><i class="fa fa-arrow-circle-left"></i>Regresar</a>
                                    <asp:Button runat="server" ID="btnGuardarHistoria" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardarHistoria_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfNroFicha" Value="0" runat="server" />
    <asp:HiddenField ID="hfAnalisis" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            var tablaTratamiento;
            $('#FechaHistoria').datetimepicker({
                format: 'DD/MM/YYYY hh:mm A'
            });
            $('[id$=txtFechaTrat]').datetimepicker({
                format: 'DD/MM/YYYY'
            });
            tablaTratamiento = $("#tbTratamiento").DataTable({ searching: false, lengthChange: false, info: false, paging: false });
            $(".sintomas, #tags_2").tagsInput({
                width: "auto", defaultText: 'Añadir', autocomplete: { selectFirst: true, width: '100px', autoFill: true }, typeahead: {
                    source: ['Amsterdam', 'Washington', 'Sydney', 'Beijing', 'Cairo']
                },
            });

            $("[id$=btnGuardarHistoria]").click(function (e) {
                var issucces = true;

                if (validator.checkAll($('#FormPrincipal'))) {
                    FN_GuardarAnalisis();
                } else {
                    issucces = false;
                }

                return issucces;

            });

            $("[id$=addNuevoTratamiento]").click(function (e) {
                e.preventDefault();
                var nroTratamiento = $(".divTratamiento").length+1;
                FN_AgregarTratamiento(nroTratamiento);
                $("#tbTratamiento" + nroTratamiento).DataTable({ searching: false, lengthChange: false, info: false, paging: false });
                $('[id$=txtFechaTrat' + nroTratamiento +']').datetimepicker({
                format: 'DD/MM/YYYY'
            });
            });

            function FN_GuardarAnalisis() {
                var obj = { Id: "", TipoId: "" };
                var lista = [];
                var elementos = $(".chkAnalisis:checked");
                for (var i = 0; i < elementos.length; i++) {
                    obj.Id = "0";
                    obj.TipoId = $(elementos[i]).val();
                    lista[i] = $.extend(true, {}, obj);
                }
                $("input[id$=hfAnalisis]").val(JSON.stringify(lista));
            }

            function FN_AgregarTratamiento(nroTratamiento) {
                var htmlTratamiento = 
                    '<div class="divTratamiento">'
                                +'<div class="item form-group">'
                                    +'<label class="control-label col-md-3 col-sm-3 col-xs-12">'
                                    +'</label>'
                                    +'<div class="control-label col-md-3 col-sm-3 col-xs-12">'
                                        +'<h4 class="text-left">Tratamiento '+nroTratamiento+'</h4>'
                                    +'</div>'
                                +'</div>'
                                +'<div class="item form-group">'
                                    +'<label class="control-label col-md-3 col-sm-3 col-xs-12">'
                                        +'Fecha<span class="required">*</span>'
                                    +'</label>'
                                    +'<div class="col-md-3 col-sm-6 col-xs-6">'
                                        +'<input id="txtFechaTrat'+nroTratamiento+'" class="form-control col-md-7 col-xs-12" required="required" type="text">'
                                    +'</div>'
                                +'</div>'
                                +'<div class="item form-group">'
                                    +'<label class="control-label col-md-3 col-sm-3 col-xs-12"></label>'
                                    +'<div class="col-md-6 col-sm-6 col-xs-12">'
                                        +'<table class="table table-striped table-bordered nowrap" id="tbTratamiento'+nroTratamiento+'">'
                                            +'<thead>'
                                                +'<tr>'
                                                    +'<th style="display: none">Id</th>'
                                                    +'<th>Droga</th>'
                                                    +'<th>Dosis</th>'
                                                    +'<th>Acciones</th>'
                                                +'</tr>'
                                            +'</thead>'
                                            +'<tbody></tbody>'
                                        +'</table>'
                                    +'</div>'
                                +'</div>'
                                +'<div class="item form-group">'
                                    +'<label class="control-label col-md-3 col-sm-3 col-xs-12"></label>'
                                    +'<div class="col-md-6 col-sm-6 col-xs-12">'
                                        +'<button class="btn btn-primary addTratamiento'+nroTratamiento+'">Agregar</button>'
                                    +'</div>'
                                +'</div>'
                                +'<div class="item form-group" style="margin-top: 14px;">'
                                    +'<label class="control-label col-md-3 col-sm-3 col-xs-12" for="textarea">Observaciones</label>'
                                    +'<div class="col-md-6 col-sm-6 col-xs-12">'
                                        +'<textarea id="txtObservacion'+nroTratamiento+'" class="form-control col-md-7 col-xs-12"></textarea>'
                                    +'</div>'
                                +'</div>'
                    + '</div>';
                $(".tratamientos").append(htmlTratamiento);
            }

        })

    </script>
</asp:Content>
