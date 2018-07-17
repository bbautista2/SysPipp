<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="Ver.aspx.cs" Inherits="SysCliVet.Privado.Mascota.Ver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>Nro°
                    <asp:Label runat="server" ID="lblNumeroFicha"></asp:Label></h3>
            </div>

            <div class="title_right">
                <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                    <div class="input-group">
                        <input type="text" class="form-control" placeholder="Search for...">
                        <span class="input-group-btn">
                            <button class="btn btn-default" type="button">Go!</button>
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
                        <h2>Mascota <small>Historial</small></h2>
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
                        <div class="col-md-3 col-sm-3 col-xs-12 profile_left">
                            <div class="profile_img">
                                <div id="crop-avatar">
                                    <!-- Current avatar -->
                                    <asp:Image runat="server" CssClass="img-responsive avatar-view" ID="ImgFotoMascota" onerror="this.src='../../src/imagenes/default.png'" />

                                </div>
                            </div>
                            <h3>
                                <asp:Label ID="lblNombreMascota" runat="server"></asp:Label></h3>

                            <ul class="list-unstyled user_data">
                                <li><i class="fa fa-map-marker user-profile-icon"></i>
                                    <asp:Label ID="lblRazaMascota" runat="server"></asp:Label>
                                </li>

                                <li>
                                    <i class="fa fa-briefcase user-profile-icon"></i>
                                    <asp:Label ID="lblPesoMascota" runat="server"></asp:Label>
                                </li>

                                <li class="m-top-xs">
                                    <i class="fa fa-external-link user-profile-icon"></i>
                                    <asp:Label ID="lblEdadMascota" runat="server"></asp:Label>
                                </li>
                            </ul>

                            <a class="btn btn-success"><i class="fa fa-edit m-right-xs"></i>Guardar</a>
                            <br />



                        </div>
                        <div class="col-md-9 col-sm-9 col-xs-12">

                            <div class="profile_title hidden">
                                <div class="col-md-6">
                                    <h2>User Activity Report</h2>
                                </div>
                                <div class="col-md-6">
                                    <div id="reportrange" class="pull-right" style="margin-top: 5px; background: #fff; cursor: pointer; padding: 5px 10px; border: 1px solid #E6E9ED">
                                        <i class="glyphicon glyphicon-calendar fa fa-calendar"></i>
                                        <span>December 30, 2014 - January 28, 2015</span> <b class="caret"></b>
                                    </div>
                                </div>
                            </div>
                            <!-- start of user-activity-graph -->
                            <div id="graph_bar" style="width: 100%; height: 280px;" class="hidden"></div>
                            <!-- end of user-activity-graph -->

                            <div class="" role="tabpanel" data-example-id="togglable-tabs">
                                <ul id="myTab" class="nav nav-tabs bar_tabs right" role="tablist">
                                    <li role="presentation" class="active"><a href="#tab_vacunas" id="vacunas-tab" role="tab" data-toggle="tab" aria-expanded="true">Vacunas</a>
                                    </li>
                                    <li role="presentation" class=""><a href="#tab_desparacitaciones" role="tab" id="desparacitaciones-tab" data-toggle="tab" aria-expanded="false">Desparacitaciones</a>
                                    </li>

                                </ul>
                                <div id="myTabContent" class="tab-content">
                                    <div role="tabpanel" class="tab-pane fade active in" id="tab_vacunas" aria-labelledby="home-tab">

                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <button id="addVacuna" class="btn btn-primary">Agregar Vacuna</button>
                                        </div>

                                        <table class="table table-striped table-bordered nowrap" id="tbVacunas">
                                            <thead>
                                                <tr>
                                                    <th style="display: none">Id</th>
                                                    <th>Fecha</th>
                                                    <th>Descripción</th>
                                                    <th>Acciones</th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyVacunas">
                                            </tbody>
                                        </table>

                                    </div>
                                    <div role="tabpanel" class="tab-pane fade" id="tab_desparacitaciones" aria-labelledby="profile-tab">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <button id="addDesp" class="btn btn-primary">Agregar Desparasitación</button>
                                        </div>

                                        <table class="table table-striped table-bordered nowrap" id="tbDesparasitaciones">
                                            <thead>
                                                <tr>
                                                    <th style="display: none">Id</th>
                                                    <th>Fecha</th>
                                                    <th>Descripción</th>
                                                    <th>Acciones</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>

                                    </div>

                                </div>
                            </div>

                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12">

                            <div class="profile_title hidden">
                                <div class="col-md-6">
                                    <h2>User Activity Report</h2>
                                </div>
                                <div class="col-md-6">
                                    <div id="reportrange" class="pull-right" style="margin-top: 5px; background: #fff; cursor: pointer; padding: 5px 10px; border: 1px solid #E6E9ED">
                                        <i class="glyphicon glyphicon-calendar fa fa-calendar"></i>
                                        <span>December 30, 2014 - January 28, 2015</span> <b class="caret"></b>
                                    </div>
                                </div>
                            </div>
                            <!-- start of user-activity-graph -->
                            <div id="graph_bar" style="width: 100%; height: 280px;" class="hidden"></div>
                            <!-- end of user-activity-graph -->

                            <div class="" role="tabpanel" data-example-id="togglable-tabs">
                                <ul id="myTab" class="nav nav-tabs bar_tabs" role="tablist">
                                    <li role="presentation" class="active"><a href="#tab_content1" id="home-tab" role="tab" data-toggle="tab" aria-expanded="true">Historias</a>
                                    </li>
                                    <li role="presentation" class=""><a href="#tab_content2" role="tab" id="profile-tab" data-toggle="tab" aria-expanded="false">Projects Worked on</a>
                                    </li>
                                    <li role="presentation" class=""><a href="#tab_content3" role="tab" id="profile-tab2" data-toggle="tab" aria-expanded="false">Profile</a>
                                    </li>
                                </ul>
                                <div id="myTabContent" class="tab-content">
                                    <div role="tabpanel" class="tab-pane fade active in" id="tab_content1" aria-labelledby="home-tab">

                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <button id="agregarHistoria" class="btn btn-primary">Añadir</button>
                                        </div>

                                        <table class="table table-striped table-bordered nowrap" id="tbHistoria">
                                            <thead>
                                                <tr>
                                                    <th>Acciones</th>
                                                    <th>Fecha</th>
                                                    <th>N° de Ficha</th>
                                                    <th>Apetito</th>
                                                    <th>Condicion Corporal</th>
                                                    <th>Peso Actual</th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyHistoria">
                                            </tbody>
                                        </table>

                                    </div>
                                    <div role="tabpanel" class="tab-pane fade" id="tab_content2" aria-labelledby="profile-tab">

                                        <!-- start user projects -->
                                        <table class="data table table-striped no-margin">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Project Name</th>
                                                    <th>Client Company</th>
                                                    <th class="hidden-phone">Hours Spent</th>
                                                    <th>Contribution</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>1</td>
                                                    <td>New Company Takeover Review</td>
                                                    <td>Deveint Inc</td>
                                                    <td class="hidden-phone">18</td>
                                                    <td class="vertical-align-mid">
                                                        <div class="progress">
                                                            <div class="progress-bar progress-bar-success" data-transitiongoal="35"></div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>2</td>
                                                    <td>New Partner Contracts Consultanci</td>
                                                    <td>Deveint Inc</td>
                                                    <td class="hidden-phone">13</td>
                                                    <td class="vertical-align-mid">
                                                        <div class="progress">
                                                            <div class="progress-bar progress-bar-danger" data-transitiongoal="15"></div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>3</td>
                                                    <td>Partners and Inverstors report</td>
                                                    <td>Deveint Inc</td>
                                                    <td class="hidden-phone">30</td>
                                                    <td class="vertical-align-mid">
                                                        <div class="progress">
                                                            <div class="progress-bar progress-bar-success" data-transitiongoal="45"></div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>4</td>
                                                    <td>New Company Takeover Review</td>
                                                    <td>Deveint Inc</td>
                                                    <td class="hidden-phone">28</td>
                                                    <td class="vertical-align-mid">
                                                        <div class="progress">
                                                            <div class="progress-bar progress-bar-success" data-transitiongoal="75"></div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <!-- end user projects -->

                                    </div>
                                    <div role="tabpanel" class="tab-pane fade" id="tab_content3" aria-labelledby="profile-tab">
                                        <p>
                                            xxFood truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid. Exercitation +1 labore velit, blog sartorial PBR leggings next level wes anderson artisan four loko farm-to-table craft beer twee. Qui
                              photo booth letterpress, commodo enim craft beer mlkshk
                                        </p>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="ModalVacuna">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <asp:HiddenField ID="hfListadoVacunas" Value="[]" runat="server" />
    <asp:HiddenField ID="hfVacunas" runat="server" />
    <asp:HiddenField ID="hfListadoHistoria" Value="[]" runat="server" />

    <script type="text/javascript">
        $(function () {
            var tablaVacuna;
            var tableRelation;
            var tablaHistoria;
            Fn_ListarVacunas();
            Fn_ListarHistorias();
            $('[id$=txtFechaNacPro], [id$=txtFechaNacMas]').datetimepicker({
                format: 'DD/MM/YYYY'
            });
            tablaVacuna = $("#tbVacunas").DataTable({ searching: false, lengthChange: false, info: false });
            tablaDesparasitacion = $("#tbDesparasitaciones").DataTable({ searching: false, lengthChange: false, info: false });

            $("[id$=addVacuna]").on('click', function (e) {
                e.preventDefault();
                FN_AgregarFila();
            });

            $("[id$=addDesp]").on('click', function (e) {
                e.preventDefault();
                nombreTabla = "tbDesp";
                FN_AgregarFila();
            });

            function FN_GuardarVacunas() {
                var obj = { Id: "", Descripcion: "", Fecha: "" };
                var lista = [];
                var index = tablaVacuna.rows().data();
                var leng = tablaVacuna.rows().length;
                if (leng > 0) {
                    for (var i = 0; i < index.length; i++) {
                        var tempRow = $("#tbVacunas tbody tr:eq(" + i + ")");
                        obj.Id = tempRow.find("td:eq(0)").text() || "0";
                        obj.Fecha = tempRow.find("td:eq(1)").text();
                        obj.Nombre = tempRow.find("td:eq(2)").text();
                        lista[i] = $.extend(true, {}, obj);
                    }
                }
                $("input[id$=hfVacunas]").val(JSON.stringify(lista));
            }

            function FN_AgregarFila() {
                var acciones,
                    data,
                    $row,
                    tabla = nombreTabla == "tbVacuna" ? tablaVacuna : tablaDesparasitacion;

                if (nombreTabla == "tbVacuna")
                    $("#addVacuna").attr({ 'disabled': 'disabled' });
                else
                    $("#addDesp").attr({ 'disabled': 'disabled' });

                acciones = [
                    '<a href="#" class="btn btn-default btn-xs hidden on-editing save-row"><i class="fa fa-save"></i></a>',
                    '<a href="#" class="btn btn-default btn-xs hidden on-editing cancel-row"><i class="fa fa-times"></i></a>',
                    '<a href="#" class="btn btn-default btn-xs on-default edit-row"><i class="fa fa-pencil"></i></a>',
                    '<a href="#" class="btn btn-default btn-xs on-default remove-row"><i class="fa fa-trash-o"></i></a>'
                ].join(' ');

                data = tabla.row.add(['', '', '', acciones]);
                $row = tabla.row(data[0]).nodes().to$();
                $row.find('td:first').hide();
                $row
                    .addClass('adding')
                    .find('td:last')
                    .addClass('acciones');
                FN_EditarFila($row);
                tabla.order([1, 'asc']).draw();
                FN_AgregarDataPicker();
            }

            function FN_AgregarDataPicker() {
                //$('.fechaVacuna').datetimepicker({
                //    format: 'DD/MM/YYYY',
                //});
                if (nombreTabla == "tbVacuna") {
                    $('.fechaVacuna').daterangepicker({
                        locale: {
                            format: 'DD/MM/YYYY'
                        },
                        singleDatePicker: true,
                        singleClasses: "picker_3"
                    }, function (start, end, label) {
                    });
                } else {
                    $('.fechaDesp').daterangepicker({
                        locale: {
                            format: 'DD/MM/YYYY'
                        },
                        singleDatePicker: true,
                        singleClasses: "picker_3"
                    }, function (start, end, label) {
                    });
                }

            }

            function FN_EditarFila($row) {
                var data,
                    tabla = nombreTabla == "tbVacuna" ? tablaVacuna : tablaDesparasitacion;

                data = tabla.row($row.get(0)).data();

                $row.children('td').each(function (i) {
                    var $this = $(this);

                    if ($this.hasClass('acciones')) {
                        FN_SetAccionesEditar($row);
                    } else {
                        if (i == 1) {
                            if (nombreTabla == "tbVacuna")
                                $this.html('<input type="text" class="form-control fechaVacuna" value="' + data[i] + '"/>');
                            else
                                $this.html('<input type="text" class="form-control fechaDesp" value="' + data[i] + '"/>');
                        }
                        else
                            $this.html('<input type="text" class="form-control input-block" value="' + data[i] + '"/>');
                    }
                });
            }

            function FN_SetAccionesEditar($row) {
                $row.find('.on-editing').removeClass('hidden');
                $row.find('.on-default').addClass('hidden');
            }

            function FN_SetAccionesPorDefecto($row) {
                $row.find('.on-editing').addClass('hidden');
                $row.find('.on-default').removeClass('hidden');
            }

            function FN_CancelarFila($row) {
                var $acciones,
                    i,
                    data,
                    tabla = nombreTabla == "tbVacuna" ? tablaVacuna : tablaDesparasitacion;

                if ($row.hasClass('adding')) {
                    FN_EliminarFila($row);
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

            function FN_EliminarFila($row) {
                var tabla = nombreTabla == "tbVacuna" ? tablaVacuna : tablaDesparasitacion;
                if ($row.hasClass('adding')) {
                    if (nombreTabla == "tbVacuna")
                        $("#addVacuna").removeAttr('disabled');
                    else
                        $("#addDesp").removeAttr('disabled');
                }
                tabla.row($row.get(0)).remove().draw();
            }

            function FN_GuardarFila($row) {
                var $acciones,
                    tabla = nombreTabla == "tbVacuna" ? tablaVacuna : tablaDesparasitacion;
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
                    if (nombreTabla == "tbVacuna")
                        $("#addVacuna").removeAttr('disabled');
                    else
                        $("#addDesp").removeAttr('disabled');
                    $row.removeClass('adding');
                }
            }

            $("#tbVacunas").on('click', 'a.cancel-row', function (e) {
                e.preventDefault();
                FN_CancelarFila($(this).closest('tr'));
            });
            $("#tbVacunas").on('click', 'a.edit-row', function (e) {
                e.preventDefault();
                FN_EditarFila($(this).closest('tr'));
                FN_AgregarDataPicker();
            });
            $("#tbVacunas").on('click', 'a.save-row', function (e) {
                e.preventDefault();
                FN_GuardarFila($(this).closest('tr'));
            });
            $("#tbVacunas").on('click', 'a.remove-row', function (e) {
                e.preventDefault();
                $(".bs-example-modal-sm").modal("show");
                var $row = $(this).closest('tr');
                $('#Confirmar').on('click', function (e) {
                    e.preventDefault();
                    FN_EliminarFila($row);
                    $(".bs-example-modal-sm").modal("hide");
                });
            });
            $("#tbDesparasitaciones").on('click', 'a.cancel-row', function (e) {
                e.preventDefault();
                nombreTabla = "tbDesp";
                FN_CancelarFila($(this).closest('tr'));
            });
            $("#tbDesparasitaciones").on('click', 'a.edit-row', function (e) {
                e.preventDefault();
                nombreTabla = "tbDesp";
                FN_EditarFila($(this).closest('tr'));
                FN_AgregarDataPicker();
            });
            $("#tbDesparasitaciones").on('click', 'a.save-row', function (e) {
                e.preventDefault();
                nombreTabla = "tbDesp";
                FN_GuardarFila($(this).closest('tr'));
            });
            $("#tbDesparasitaciones").on('click', 'a.remove-row', function (e) {
                e.preventDefault();
                nombreTabla = "tbDesp";
                $(".bs-example-modal-sm").modal("show");
                var $row = $(this).closest('tr');
                $('#Confirmar').on('click', function (e) {
                    e.preventDefault();
                    FN_EliminarFila($row);
                    $(".bs-example-modal-sm").modal("hide");
                });
            });


        })
        function Fn_ListarVacunas() {
            var object = {};
            object.items = ($("input[type=hidden][id$=hfListadoVacunas]").val() != "" && $("input[type=hidden][id$=hfListadoVacunas]").val() != undefined) ? $.parseJSON($("input[type=hidden][id$=hfListadoVacunas]").val()) : "[]";
            var items = fn_CargarPlantilla("datatable-vacunas", object);
            $("[id$=tbodyVacunas]").append(items);

        }

        function Fn_ListarHistorias() {
            var object = {};
            object.items = $("input[type=hidden][id$=hfListadoHistoria]").val() != "[]" ? $.parseJSON($("input[type=hidden][id$=hfListadoHistoria]").val()) : "[]";
            var items = fn_CargarPlantilla("table-historia", object);
            $("[id$=tbodyHistoria]").html(items);
            tablaHistoria = $("[id$=tbHistoria]").DataTable();
        }


    </script>

    <script type="text/x-handlebars-template" id="datatable-vacunas">
        {{# each items}}
            <tr class="editable">
                <td style="display: none;" id='id_value'>{{id}}</td>
                <td>{{fecha}}</td>
                <td>{{descripcion}}</td>
                <td class="acciones">
                    <a href="#" class="btn btn-default btn-xs hidden on-editing save-row"><i class="fa fa-save"></i></a>
                    <a href="#" class="btn btn-default btn-xs hidden on-editing cancel-row"><i class="fa fa-times"></i></a>
                    <a href="#" class="btn btn-default btn-xs on-default edit-row"><i class="fa fa-pencil"></i></a>
                    <a href="#" class="btn btn-default btn-xs on-default remove-row"><i class="fa fa-trash-o"></i></a>
                </td>
            </tr>
        {{/each}}
    </script>

    <script type="text/x-handlebars-template" id="table-historia">
        {{# each items}}                   
            <tr>
                <td>
                    <a onclick="fn_AbrirLink('../HistorialClinico/Guardar.aspx?i={{Id}}')" class="btn btn-default btn-xs" data-toggle="tooltip" data-placement="top" data-original-title="Editar"><i class="fa fa-pencil"></i></a>
                    <a onclick="FN_Eliminar('{{Id}}')" class="btn btn-default btn-xs" data-toggle="tooltip" data-placement="top" data-original-title="Eliminar"><i class="fa fa-trash-o"></i></a>
                </td>
                <td>{{Fecha}}</td>
                <td>{{NroFicha}}</td>
                <td>{{Apetito}}</td>
                <td>{{CondicionCuerpo}}</td>
                <td>{{PesoActual}}</td>
            </tr>

        {{/each}}
    </script>

</asp:Content>




