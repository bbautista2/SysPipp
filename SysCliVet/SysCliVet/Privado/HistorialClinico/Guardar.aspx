<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="Guardar.aspx.cs" Inherits="SysCliVet.Privado.HistorialClinico.Guardar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<style type="text/css">
    .dataTables_length, .dataTables_filter, .dataTables_info, .dataTables_paginate {
        display: none;
    }
</style>

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
                                <div class="col-md-2 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkAgitacion" class="flat" runat="server">
                                    Agitación
                                </div>                                
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <input id="txtAgitacionDescripcion" runat="server" class="form-control col-md-7 col-xs-12" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-2 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkDepresion" class="flat" runat="server">
                                    Depresión
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <input id="txtDepresionDescripcion" runat="server" class="form-control col-md-7 col-xs-12" type="text">
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
                                <div class="col-md-2 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkHemo" class="flat chkAnalisis" value="1">
                                    Hemograma
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <input class="form-control col-md-7 col-xs-12 txtDescripcion" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-2 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkBio" class="flat chkAnalisis" value="2">
                                    Bioquímica
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <input class="form-control col-md-7 col-xs-12 txtDescripcion" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-2 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkUro" class="flat chkAnalisis" value="3">
                                    Uroanálisis
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <input class="form-control col-md-7 col-xs-12 txtDescripcion" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-2 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkRX" class="flat chkAnalisis" value="4">
                                    RX
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <input class="form-control col-md-7 col-xs-12 txtDescripcion" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-2 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkEco" class="flat chkAnalisis" value="5">
                                    Eco
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <input class="form-control col-md-7 col-xs-12 txtDescripcion" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                </label>
                                <div class="col-md-2 col-sm-6 col-xs-12">
                                    <input type="checkbox" id="chkCito" class="flat chkAnalisis" value="6">
                                    Citología
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <input class="form-control col-md-7 col-xs-12 txtDescripcion" type="text">
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
                                            <input id="txtFechaTrat_1" runat="server" class="form-control col-md-7 col-xs-12" required="required" type="text">
                                        </div>
                                    </div>
                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <table class="table table-striped table-bordered nowrap" id="tbTratamiento_1">
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
                                            <a id="btnAddTrat_1" class="btn btn-primary" onclick="FN_AgregarTratamiento(this)">Agregar</a>
                                        </div>
                                    </div>

                                    <div class="item form-group" style="margin-top: 14px;">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="textarea">
                                            Observaciones 
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <textarea id="txtObservacion_1" runat="server" class="form-control col-md-7 col-xs-12"></textarea>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="ln_solid"></div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <a type="submit" class="btn btn-default hide" href="Listar.aspx"><i class="fa fa-arrow-circle-left"></i>Regresar</a>
                                    <asp:Button runat="server" ID="btnGuardarHistoria" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardarHistoria_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="ModalTratamiento">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title" id="myModalLabel2">¿Estás seguro?</h4>
                </div>
                <div class="modal-body">
                    <p>¿Estás seguro que quieres eliminar esta fila?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" id="Confirmar">Confirmar</button>
                </div>

            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfNroFicha" Value="0" runat="server" />
    <asp:HiddenField ID="hfAnalisis" runat="server" />
    <asp:HiddenField ID="hfTratamientos" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            var tablaTratamiento;
            var nroTratamientoEliminar;
            var tablaTratamientoEliminar;
            var $rowEliminar;
            $('#FechaHistoria').datetimepicker({
                format: 'DD/MM/YYYY hh:mm A'
            });
            $('[id$=txtFechaTrat_1]').datetimepicker({
                format: 'DD/MM/YYYY'
            });
            //tablaTratamiento = $("#tbTratamiento_1").DataTable({ searching: false, lengthChange: false, info: false, paging: false });
            if ($("input[id$=hfTratamientos]").val() == "")
                $("#tbTratamiento_1").DataTable();
            $(".sintomas, #tags_2").tagsInput({
                width: "auto", defaultText: 'Añadir', autocomplete: { selectFirst: true, width: '100px', autoFill: true }, typeahead: {
                    source: ['Amsterdam', 'Washington', 'Sydney', 'Beijing', 'Cairo']
                },
            });

            $("[id$=btnGuardarHistoria]").click(function (e) {
                var issucces = true;
                if (validator.checkAll($('#FormPrincipal'))) {
                    FN_GuardarAnalisis();
                    FN_GuardarTratamientos();
                } else {
                    issucces = false;
                }
                return issucces;
            });

            $("[id$=addNuevoTratamiento]").click(function (e) {
                e.preventDefault();
                var nroTratamiento = $(".divTratamiento").length + 1;
                FN_AgregarNuevoTratamiento(nroTratamiento);
                $("#tbTratamiento_" + nroTratamiento).DataTable({ searching: false, lengthChange: false, info: false, paging: false });
                $('[id$=txtFechaTrat_' + nroTratamiento + ']').datetimepicker({
                    format: 'DD/MM/YYYY'
                });
            });

            if ($("input[id$=hfAnalisis]").val() != "")
                FN_CargarAnalisis();
            function FN_CargarAnalisis() {
                var lista = JSON.parse($("input[id$=hfAnalisis]").val());

                if (lista.length > 0) {
                    for (var i = 0; i < lista.length; i++) {
                        var tipoId = lista[i].TipoId;
                        var descripcion = lista[i].Descripcion;

                        switch (tipoId) {
                            case 1:
                                $("input[id$=chkHemo]").prop("checked", true);
                                $("input[id$=chkHemo]").parent().addClass("checked");
                                $("input[id$=chkHemo]").closest(".form-group").find(".txtDescripcion").val(descripcion);
                                break;
                            case 2:
                                $("input[id$=chkBio]").prop("checked", true);
                                $("input[id$=chkBio]").parent().addClass("checked");
                                $("input[id$=chkBio]").closest(".form-group").find(".txtDescripcion").val(descripcion);
                                break;
                            case 3:
                                $("input[id$=chkUro]").prop("checked", true);
                                $("input[id$=chkUro]").parent().addClass("checked");
                                $("input[id$=chkUro]").closest(".form-group").find(".txtDescripcion").val(descripcion);
                                break;
                            case 4:
                                $("input[id$=chkRX]").prop("checked", true);
                                $("input[id$=chkRX]").parent().addClass("checked");
                                $("input[id$=chkRX]").closest(".form-group").find(".txtDescripcion").val(descripcion);
                                break;
                            case 5:
                                $("input[id$=chkEco]").prop("checked", true);
                                $("input[id$=chkEco]").parent().addClass("checked");
                                $("input[id$=chkEco]").closest(".form-group").find(".txtDescripcion").val(descripcion);
                                break;
                            case 6:
                                $("input[id$=chkCito]").prop("checked", true);
                                $("input[id$=chkCito]").parent().addClass("checked");
                                $("input[id$=chkCito]").closest(".form-group").find(".txtDescripcion").val(descripcion);
                                break;
                        }
                    }

                }
            }

            if ($("input[id$=hfTratamientos]").val() != "")
                FN_CargarTratamientos();

            function FN_CargarTratamientos() {
                var lista = JSON.parse($("input[id$=hfTratamientos]").val());

                if (lista.length > 0) {
                    var nroTratamiento = 1;
                    var fecha = lista[0].FechaTratamiento;
                    var idTabla = "tbTratamiento_"
                    $("input[id$=txtFechaTrat_" + 1 + "]").val(fecha);
                    $("textarea[id$=txtObservacion_" + 1 + "]").val(lista[0].Observacion);

                    FN_InsertarDrogasyDosis(idTabla+"1",nroTratamiento,lista[0].Id,lista[0].Droga,lista[0].Dosis);
                    
                    for (var i = 1; i < lista.length; i++) {
                        var id = lista[i].Id;
                        var droga = lista[i].Droga;
                        var dosis = lista[i].Dosis;
                        var fechaTratamiento = lista[i].FechaTratamiento;
                        var observacion = lista[i].Observacion;

                        if (fechaTratamiento != lista[i - 1].FechaTratamiento) {
                            nroTratamiento++;
                            FN_AgregarNuevoTratamiento(nroTratamiento);
                            $("input[id$=txtFechaTrat_" + nroTratamiento + "]").val(fechaTratamiento);
                            $("textarea[id$=txtObservacion_" + nroTratamiento + "]").val(observacion);
                            FN_InsertarDrogasyDosis(idTabla, nroTratamiento, id, droga, dosis);                            
                        } else {
                            $("input[id$=txtFechaTrat_" + nroTratamiento + "]").val(fechaTratamiento);
                            $("textarea[id$=txtObservacion_" + nroTratamiento + "]").val(observacion);
                            FN_InsertarDrogasyDosis(idTabla, nroTratamiento, id, droga, dosis);
                        }
                    }

                    for (var j = 1; j <= nroTratamiento; j++) {
                        $("#tbTratamiento_" + j).DataTable();
                    }
                }
            }

            function FN_InsertarDrogasyDosis(idTabla, nroTratamiento, id, droga, dosis, fecha, observacion) {

                var items = 
                        '<tr class="editable">'
                            +'<td style="display: none;">'+id+'</td>'
                            +'<td>'+droga+'</td>'
                            +'<td>'+dosis+'</td>'
                            +'<td class="acciones">'
                                +'<a data-numero="' + nroTratamiento + '" onclick="FN_GuardarFilaTra(this)" class="btn btn-default btn-xs hidden on-editing save-row"><i class="fa fa-save"></i></a>'
                                +'<a data-numero="' + nroTratamiento + '" onclick="FN_CancelarFilaTra(this)" class="btn btn-default btn-xs hidden on-editing cancel-row"><i class="fa fa-times"></i></a>'
                                +'<a data-numero="' + nroTratamiento + '" onclick="FN_EditarFilaTra(this)" class="btn btn-default btn-xs on-default edit-row"><i class="fa fa-pencil"></i></a>'
                                +'<a data-numero="' + nroTratamiento + '" onclick="FN_EliminarFilaTra(this)" class="btn btn-default btn-xs on-default remove-row"><i class="fa fa-trash-o"></i></a>'
                    + '</td>'
                    + '</tr>';
                $("#tbTratamiento_" + nroTratamiento + " tbody").append(items);
            }

            function FN_GuardarAnalisis() {
                var obj = { Id: "", TipoId: "" };
                var lista = [];
                var elementos = $(".chkAnalisis:checked");
                for (var i = 0; i < elementos.length; i++) {
                    obj.Id = "0";
                    obj.TipoId = $(elementos[i]).val();
                    obj.Descripcion = $(elementos[i]).closest(".form-group").find(".txtDescripcion").val();
                    lista[i] = $.extend(true, {}, obj);
                }
                $("input[id$=hfAnalisis]").val(JSON.stringify(lista));
            }

            function FN_AgregarNuevoTratamiento(nroTratamiento) {
                var htmlTratamiento =
                    '<div class="divTratamiento">'
                    + '<div class="item form-group">'
                    + '<label class="control-label col-md-3 col-sm-3 col-xs-12">'
                    + '</label>'
                    + '<div class="control-label col-md-3 col-sm-3 col-xs-12">'
                    + '<h4 class="text-left">Tratamiento ' + nroTratamiento + '</h4>'
                    + '</div>'
                    + '</div>'
                    + '<div class="item form-group">'
                    + '<label class="control-label col-md-3 col-sm-3 col-xs-12">'
                    + 'Fecha<span class="required">*</span>'
                    + '</label>'
                    + '<div class="col-md-3 col-sm-6 col-xs-6">'
                    + '<input id="txtFechaTrat_' + nroTratamiento + '" class="form-control col-md-7 col-xs-12" required="required" type="text">'
                    + '</div>'
                    + '</div>'
                    + '<div class="item form-group">'
                    + '<label class="control-label col-md-3 col-sm-3 col-xs-12"></label>'
                    + '<div class="col-md-6 col-sm-6 col-xs-12">'
                    + '<table class="table table-striped table-bordered nowrap" id="tbTratamiento_' + nroTratamiento + '">'
                    + '<thead>'
                    + '<tr>'
                    + '<th style="display: none">Id</th>'
                    + '<th>Droga</th>'
                    + '<th>Dosis</th>'
                    + '<th>Acciones</th>'
                    + '</tr>'
                    + '</thead>'
                    + '<tbody></tbody>'
                    + '</table>'
                    + '</div>'
                    + '</div>'
                    + '<div class="item form-group">'
                    + '<label class="control-label col-md-3 col-sm-3 col-xs-12"></label>'
                    + '<div class="col-md-6 col-sm-6 col-xs-12">'
                    + '<a id="btnAddTrat_' + nroTratamiento + '" class="btn btn-primary" onclick="FN_AgregarTratamiento(this)">Agregar</a>'
                    + '</div>'
                    + '</div>'
                    + '<div class="item form-group" style="margin-top: 14px;">'
                    + '<label class="control-label col-md-3 col-sm-3 col-xs-12" for="textarea">Observaciones</label>'
                    + '<div class="col-md-6 col-sm-6 col-xs-12">'
                    + '<textarea id="txtObservacion_' + nroTratamiento + '" class="form-control col-md-7 col-xs-12"></textarea>'
                    + '</div>'
                    + '</div>'
                    + '</div>';
                $(".tratamientos").append(htmlTratamiento);
            }

        });

        function FN_AgregarTratamiento(e) {
            var nroTratamiento = $(e).attr("id").split("_")[1];
            var tablaTratamiento = $("#tbTratamiento_" + nroTratamiento).DataTable();
            FN_AgregarFila(tablaTratamiento, nroTratamiento);
        }

        function FN_AgregarFila(tablaTratamiento, nroTratamiento) {
            var acciones,
                data,
                $row,
                tabla = tablaTratamiento;

            $("#btnAddTrat_" + nroTratamiento).attr({ 'disabled': 'disabled' });

            acciones = [
                '<a data-numero="' + nroTratamiento + '" onclick="FN_GuardarFilaTra(this)" class="btn btn-default btn-xs hidden on-editing save-row"><i class="fa fa-save"></i></a>',
                '<a data-numero="' + nroTratamiento + '" onclick="FN_CancelarFilaTra(this)" class="btn btn-default btn-xs hidden on-editing cancel-row"><i class="fa fa-times"></i></a>',
                '<a data-numero="' + nroTratamiento + '" onclick="FN_EditarFilaTra(this)" class="btn btn-default btn-xs on-default edit-row"><i class="fa fa-pencil"></i></a>',
                '<a data-numero="' + nroTratamiento + '" onclick="FN_EliminarFilaTra(this)" class="btn btn-default btn-xs on-default remove-row"><i class="fa fa-trash-o"></i></a>'
            ].join(' ');

            data = tabla.row.add(['', '', '', acciones]);
            $row = tabla.row(data[0]).nodes().to$();
            $row.find('td:first').hide();
            $row
                .addClass('adding')
                .find('td:last')
                .addClass('acciones');
            FN_EditarFila($row, tablaTratamiento, nroTratamiento);
            tabla.order([1, 'asc']).draw();
        }

        function FN_EditarFila($row, tablaTratamiento, nroTratamiento) {
            var data,
                tabla = tablaTratamiento;

            data = tabla.row($row.get(0)).data();

            $row.children('td').each(function (i) {
                var $this = $(this);

                if ($this.hasClass('acciones')) {
                    FN_SetAccionesEditar($row);
                } else {
                    $this.html('<input type="text" class="form-control input-block" value="' + data[i] + '"/>');
                }
            });
        }

        function FN_EliminarFila($row, tablaTratamiento, nroTratamiento) {
            var tabla = tablaTratamiento;
            if ($row.hasClass('adding')) {
                $("#btnAddTrat_" + nroTratamiento).removeAttr('disabled');
            }
            tabla.row($row.get(0)).remove().draw();
        }

        function FN_GuardarFila($row, tablaTratamiento, nroTratamiento) {
            var $acciones,
                tabla = tablaTratamiento;
            values = [];
            var returnval = true;
            var tdid;
            values = $row.find('td').map(function (index, val) {
                var $this = $(this);
                var isEqual = false;
                if ($this.hasClass('acciones')) {
                    if (returnval) {
                        FN_SetAccionesPorDefecto($row);
                    }
                    return tabla.cell(this).data();
                } else {
                    var value = "";
                    if (index > 0) {
                        if ($this.find('input').length > 0) {
                            $this.find('.formError').remove();
                            var val = $.trim($this.find('input').val());
                            if (val == "") {
                                $this.find('input').attr("style", "border: 1px solid red;");
                                returnval = false;
                            } else {
                                $this.find('input').attr("style", "border: solid 1px gainsboro;");
                            }
                            value = $.trim($this.find('input').val());
                        }
                    } else {
                        value = $.trim($this.find('input').val());
                        tdid = value;
                    }
                    return value;
                }
            });

            if (!returnval) {
                return false;
            }
            tabla.row($row.get(0)).data(values);
            $acciones = $row.find('td.acciones');
            if ($acciones.get(0)) {
                FN_SetAccionesPorDefecto($row);
            }
            tabla.draw();
            if ($row.hasClass('adding')) {
                $("#btnAddTrat_" + nroTratamiento).removeAttr('disabled');
                $row.removeClass('adding');
            }
        }

        function FN_CancelarFila($row, tablaTratamiento, nroTratamiento) {
            var $acciones,
                i,
                data,
                tabla = tablaTratamiento;

            if ($row.hasClass('adding')) {
                FN_EliminarFila($row, tablaTratamiento, nroTratamiento);
            } else {

                data = tabla.row($row.get(0)).data();
                tabla.row($row.get(0)).data(data);

                $acciones = $row.find('td.acciones');
                if ($acciones.get(0)) {
                    FN_SetAccionesPorDefecto($row);
                }
                tabla.draw();
            }
        }

        function FN_SetAccionesEditar($row) {
            $row.find('.on-editing').removeClass('hidden');
            $row.find('.on-default').addClass('hidden');
        }

        function FN_SetAccionesPorDefecto($row) {
            $row.find('.on-editing').addClass('hidden');
            $row.find('.on-default').removeClass('hidden');
        }

        function FN_GuardarTratamientos() {
            var obj = { Id: "", SFechaTratamiento: "", Droga: "", Dosis: "", Observacion: "" };
            var lista = [];
            var nroTratamientos = $(".divTratamiento").length;

            if (nroTratamientos > 0) {
                var count = 0;
                for (var i = 1; i <= nroTratamientos; i++) {
                    var tabla = $("#tbTratamiento_" + i).DataTable();
                    var index = tabla.rows().data();
                    var length = tabla.rows().length;
                    if (length > 0) {
                        for (var j = 0; j < index.length; j++) {
                            var tempRow = $("#tbTratamiento_" + i + " tbody tr:eq(" + j + ")");
                            obj.Id = tempRow.find("td:eq(0)").text() || "0";
                            obj.SFechaTratamiento = $("input[id$=txtFechaTrat_" + i + "]").val();
                            obj.Droga = tempRow.find("td:eq(1)").text();
                            obj.Dosis = tempRow.find("td:eq(2)").text();
                            obj.Observacion = $("textarea[id$=txtObservacion_" + i + "]").val();
                            lista[count] = $.extend(true, {}, obj);
                            count++;
                        }
                    }
                }

            }

            $("input[id$=hfTratamientos]").val(JSON.stringify(lista));
        }

        //Acciones de la tabla Tratamiento
        function FN_GuardarFilaTra(e) {
            var nroTratamiento = $(e).attr("data-numero");
            var tablaTratamiento = $("#tbTratamiento_" + nroTratamiento).DataTable();
            FN_GuardarFila($(e).closest('tr'), tablaTratamiento, nroTratamiento);
        }

        function FN_CancelarFilaTra(e) {
            var nroTratamiento = $(e).attr("data-numero");
            var tablaTratamiento = $("#tbTratamiento_" + nroTratamiento).DataTable();
            FN_CancelarFila($(e).closest('tr'), tablaTratamiento, nroTratamiento);
        }

        function FN_EditarFilaTra(e) {
            var nroTratamiento = $(e).attr("data-numero");
            var tablaTratamiento = $("#tbTratamiento_" + nroTratamiento).DataTable();
            FN_EditarFila($(e).closest('tr'), tablaTratamiento, nroTratamiento);
        }

        function FN_EliminarFilaTra(e) {
            nroTratamientoEliminar = $(e).attr("data-numero");
            tablaTratamientoEliminar = $("#tbTratamiento_" + nroTratamientoEliminar).DataTable();
            $("#ModalTratamiento").modal("show");
            $rowEliminar = $(e).closest('tr');
            $('#Confirmar').unbind('click');
            $('#Confirmar').one('click', function (ex) {
                ex.preventDefault();
                FN_EliminarFila($rowEliminar, tablaTratamientoEliminar, nroTratamientoEliminar);
                $(".bs-example-modal-sm").modal("hide");
            });
        }

    </script>
</asp:Content>
