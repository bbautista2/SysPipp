<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="SysCliVet.Privado.Mascota.Listar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>Mascota</h3>
            </div>

            <div class="title_right">
                <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                    <div class="input-group">
                        <input type="text" class="form-control" placeholder="Buscar ...">
                        <span class="input-group-btn">
                            <button class="btn btn-default" type="button">Buscar</button>
                        </span>
                    </div>
                </div>
            </div>
        </div>

        <div class="clearfix"></div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Listado de Mascotas </h2>
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
                        <div class="form-group">
                            <div class="col-md-12 left">
                                <button id="send" type="submit" class="btn btn-success"><i class="fa fa-plus-square"></i>Añadir</button>
                            </div>
                        </div>
                        <br />
                        <br />
                        <table id="datatable-responsive" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th>Accion</th>
                                    <th>Foto</th>
                                    <th>Nombre</th>
                                    <th>Dueño</th>
                                    <th>Edad</th>
                                    <th>En tratamiento</th>

                                </tr>
                            </thead>
                            <tbody id="tbodyMascota">
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="ModalMascota">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title">¿Estás seguro?</h4>
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
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <asp:HiddenField ID="hfListadoMascotas" Value="[]" runat="server" />
    <script type="text/javascript">
        var tabla;
        $(function () {
            fn_iniciar();

        });

        function fn_iniciar() {
            Fn_ListarMascotas();
        }

        function Fn_ListarMascotas() {
            var object = {};
            object.items = $("input[type=hidden][id$=hfListadoMascotas]").val() != "[]" ? $.parseJSON($("input[type=hidden][id$=hfListadoMascotas]").val()) : "[]";
            var items = fn_CargarPlantilla("table-mascota", object);
            $("[id$=tbodyMascota]").append(items);
            tabla = $("[id$=datatable-responsive2]").DataTable();
        }

        function FN_Eliminar(id) {
            $("[id$=ModalMascota]").modal("show");
            $('#Confirmar').unbind().click(function() {
                FN_EliminarPropietario(id);
            });
        }

        function FN_EliminarPropietario(id) {

            success = function (response) {
                var result = response.d;
                if (result.correcto == true) {
                    tabla.destroy();
                    var object = {};
                    object.items = result.Lista;
                    var items = fn_CargarPlantilla("table-mascota", object);
                    $("[id$=tbodyMascota]").html(items);
                    tabla = $("[id$=datatable-responsive2]").DataTable();
                    FN_Mensaje('s', result.mensaje);
                }
                else
                    FN_Mensaje('e', result.mensaje);

                $("[id$=ModalMascota]").modal("hide");
            }

            error = function (xhr, ajaxOptions, thrownError) {
                $("[id$=ModalMascota]").modal("hide");
            };

            FN_LlamarMetodo("Listar.aspx/EliminarMascota", '{id: "' + id + '" }', success, error);
        }

    </script>

    <script type="text/x-handlebars-template" id="table-mascota">
        {{# each items}}                   
                        <tr>
                            <td>
                                <a onclick="fn_AbrirLink('Ver.aspx?i={{Id}}')" class="btn btn-default btn-xs" data-toggle="tooltip" data-placement="top" data-original-title="Ver Mascota"><i class="fa fa-eye"></i></a>
                                <a onclick="fn_AbrirLink('Guardar.aspx?i={{Id}}')" class="btn btn-default btn-xs" data-toggle="tooltip" data-placement="top" data-original-title="Editar"><i class="fa fa-pencil"></i></a>
                                <a onclick="FN_Eliminar('{{Id}}')" class="btn btn-default btn-xs" data-toggle="tooltip" data-placement="top" data-original-title="Eliminar"><i class="fa fa-trash-o"></i></a>
                            </td>
                            <td>
                                <ul class="list-inline">
                                    <li>
                                        <img src="{{Foto}}" class="avatar" alt="Avatar" onerror="this.src='../../src/imagenes/default.png'">
                                    </li>
                                </ul>
                            </td>
                            <td>{{Nombre}}</td>
                            <td>{{Propietario}}           
                            </td>
                            <td>{{Edad}}</td>
                            <td>
                                <div class="progress progress_sm">
                                    <div class="progress-bar bg-green" role="progressbar" data-transitiongoal="{{Progreso}}"></div>
                                </div>
                                <small>{{Progreso}}% Completo</small>
                            </td>

                        </tr>

        {{/each}}
    </script>
</asp:Content>
