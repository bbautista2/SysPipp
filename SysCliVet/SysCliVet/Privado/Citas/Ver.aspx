<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="Ver.aspx.cs" Inherits="SysCliVet.Privado.Citas.Ver" Async="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="EstilosPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>Citas <small>Añadir y eliminar</small></h3>
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
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Ver Citas</h2>
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
                        <div id='calendar1'></div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- calendar modal -->
    <div id="CalenderModalNew" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="z-index: 9999">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="myModalLabel">Nueva Cita</h4>
                </div>
                <div class="modal-body">
                    <div id="msjCrearCita"></div>
                    <div id="testmodal" style="padding: 5px 20px;">
                        <div id="antoform" class="form-horizontal calender" role="form">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Paciente</label>
                                <div class="col-sm-9">
                                    <input id="txtNombreMascota" runat="server" class="form-control col-md-6 col-xs-6" style="width: 80%!important" required="required" type="text" maxlength="8">
                                    <span class="input-group-btn">
                                        <button id="btnBuscarMascota" type="button" class="btn btn-primary" style="height: 34px;"><i class="fa fa-search"></i></button>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Tipo Cita</label>
                                <div class="col-sm-9">
                                    <asp:DropDownList ID="cmbTipoCita" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Motivo</label>
                                <div class="col-sm-9">
                                    <textarea class="form-control" style="height: 55px;" id="txtDescripcion" name="descr"></textarea>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary antosubmit">Guardar</button>
                    <button type="button" class="btn btn-default antoclose" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div id="CalenderModalEdit" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="z-index: 9999">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="myModalLabel2">Editar Cita</h4>
                </div>
                <div class="modal-body">

                    <div id="testmodal2" style="padding: 5px 20px;">
                        <div id="antoform2" class="form-horizontal calender" role="form">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Paciente</label>
                                <div class="col-sm-9" style="padding-top: 8px;">
                                    <label id="lblPaciente"></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Motivo</label>
                                <div class="col-sm-9">
                                    <textarea class="form-control" style="height: 55px;" id="txtMotivo" disabled name="descr"></textarea>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary antosubmit2">Eliminar</button>
                    <button type="button" class="btn btn-default antoclose2" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div id="fc_create" data-toggle="modal" data-target="#CalenderModalNew"></div>
    <div id="fc_edit" data-toggle="modal" data-target="#CalenderModalEdit"></div>
    <!-- /calendar modal -->


</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <asp:HiddenField ID="hfIdMascota" runat="server" />
    <asp:HiddenField ID="hfEmailPropietario" Value="" runat="server" />
    <script src="<%=ResolveUrl("~/Privado/Citas/js/autocomplete-buscarMascota.js?a=1") %>"></script>
    <script type="text/javascript">
        $(function () {
            Fn_Cita_Listar();

            $("[id$=btnBuscarMascota]").on('click', function (e) {
                Fn_BuscarMascota();
            });
        });

        function Fn_Cita_Listar() {

            success = function (response) {
                var obj = response.d;
                init_calendar1(obj);
            }

            error = function (xhr, ajaxOptions, thrownError) {
                console.log("colocar mensaje de error");
            };

            FN_LlamarMetodo("Ver.aspx/Cita_Listar", "{}", success, error);

        };

        function Fn_Cita_Listar_Editar() {

            success = function (response) {
                var obj = response.d;                
                $('#calendar1').fullCalendar('removeEvents');
                $('#calendar1').fullCalendar('addEventSource', obj);  
            }

            error = function (xhr, ajaxOptions, thrownError) {
                console.log("colocar mensaje de error");
            };

            FN_LlamarMetodo("Ver.aspx/Cita_Listar", "{}", success, error);

        };

        function Fn_Cita_Guardar(objCita) {

            success = function (response) {
                var result = response.d;
                if (result.correcto == true) {
                    Fn_Cita_Listar_Editar();
                    FN_Mensaje('s', result.mensaje);
                } else
                    FN_Mensaje('e', result.mensaje);                   
            }

            error = function (xhr, ajaxOptions, thrownError) {
                console.log("colocar mensaje de error");
            };

            FN_LlamarMetodo("Ver.aspx/Cita_Guardar", JSON.stringify(objCita), success, error);

        };

        function Fn_Cita_Eliminar(idCita) {

            success = function (response) {
                var result = response.d;
                if (result.correcto == true) {
                    Fn_Cita_Listar_Editar();
                    FN_Mensaje('s', result.mensaje);
                } else
                    FN_Mensaje('e', result.mensaje);   
                $('#fc_edit').click();
            }

            error = function (xhr, ajaxOptions, thrownError) {
                console.log("colocar mensaje de error");
                $('#fc_edit').click();
            };

            FN_LlamarMetodo("Ver.aspx/Cita_Eliminar", '{id: ' + idCita + ' }', success, error);

        };

        function Fn_Limpiar_CrearCita() {
            $("[id$=hfIdMascota], [id$=hfEmailPropietario], input[id$=txtNombreMascota], [id$=txtDescripcion]").val("");

        }

        function init_calendar1(object) {

            var date = new Date(),
                d = date.getDate(),
                m = date.getMonth(),
                y = date.getFullYear(),
                started,
                categoryClass;
            var calendar = $('#calendar1').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay,listMonth'
                },
                defaultView: 'agendaDay',
                allDaySlot: false,
                ignoreTimezone: false,
                selectable: true,
                longPressDelay: 10,
                select: function (start, end, allDay, jsEvent) {
                    Fn_Limpiar_CrearCita();
                    $('#fc_create').click();
                    
                    started = start;
                    ended = end;

                    $('.antosubmit').unbind('click');
                    $(".antosubmit").one("click", function () {
                        var mascotaId = $("[id$=hfIdMascota]").val();
                        var tipoCita = $("[id$=cmbTipoCita]").val();
                        var motivo = $("[id$=txtDescripcion]").val();
                        var nombrePropietario = $("input[id$=txtNombreMascota]").val().split("-")[1];
                        var emailPropietario = $("[id$=hfEmailPropietario]").val();
                        categoryClass = $("#event_type").val();

                        var objCita = {
                            objCita: {
                                mascotaId: mascotaId,
                                inicio: moment(started).format("YYYY-MM-DD hh:mm:ss a"),
                                fin: moment(ended).format("YYYY-MM-DD hh:mm:ss a"),
                                tipoCita: tipoCita,
                                motivo: motivo,
                                nombrePropietario: nombrePropietario,
                                emailPropietario: emailPropietario
                            }
                        }

                        Fn_Cita_Guardar(objCita);

                        calendar.fullCalendar('unselect');

                        $('.antoclose').click();    

                        return false;
                    });
                },
                eventClick: function (calEvent, jsEvent, view) {
                    $('#fc_edit').click();
                    $('#autocomplete-custom-append1').val(calEvent.title);
                    $('[id$=lblPaciente]').text(calEvent.mascota);
                    $('[id$=txtMotivo]').val(calEvent.motivo);
                    var id = calEvent.id;

                    $('.antosubmit2').unbind('click');
                    $(".antosubmit2").one("click", function () {
                        Fn_Cita_Eliminar(id);
                    });

                    calendar.fullCalendar('unselect');
                },
                editable: true,
                events: object,
                timezone: 'local'
            });


        };

        function Fn_BuscarMascota() {
            $(".autocomplete-suggestions").remove();


            $("[id$=btnBuscarMascota]").addClass("btn-loading");

            $("[id$=btnBuscarMascota]").attr("disabled", true);
            var nombre = $("[id$=txtNombreMascota]").val();

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
                    $('[id$=txtNombreMascota]').autocomplete({
                        lookup: listaPropietarios


                    });
                    setTimeout(function () { $("[id$=txtNombreMascota]").trigger('keyup'); }, 1000);
                    $("[id$=btnBuscarMascota]").removeClass("btn-loading");
                    $("[id$=btnBuscarMascota]").attr("disabled", false);
                } else {
                    $("[id$=btnBuscarMascota]").removeClass("btn-loading");
                    $("[id$=btnBuscarMascota]").attr("disabled", false);
                    FN_Mensaje("i", "No hay mascota registrada con ese nombre", "msjCrearCita");
                }

            }

            error = function (xhr, ajaxOptions, thrownError) {
                console.log("colocar mensaje de error");
                $("[id$=btnBuscarMascota]").removeClass("btn-loading");
                $("[id$=btnBuscarMascota]").attr("disabled", false);
            };

            FN_LlamarMetodo("Ver.aspx/ListaMascotasPorNombre", '{nombre: "' + nombre + '" }', success, error);

        };


    </script>
</asp:Content>
