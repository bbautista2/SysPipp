﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="Ver.aspx.cs" Inherits="SysCliVet.Privado.Recordatorios.Ver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EstilosPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>Recordatorios <small>Ver</small></h3>
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
                        <h2>Ver Agenda</h2>
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

                        <div id='calendar1'></div>

                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- calendar modal -->
    <div id="CalenderModalNew" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="myModalLabel">Nuevo Recordatorio</h4>
                </div>
                <div class="modal-body">
                    <div id="testmodal" style="padding: 5px 20px;">
                        <div id="antoform" class="form-horizontal calender" role="form">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Titulo</label>
                                <div class="col-sm-9">
                                    <input type="text" name="txtTitulo" id="txtTitulo" class="form-control col-md-10" />
                                </div>
                            </div>
                            <div class="form-group hide">
                                <label class="col-sm-3 control-label">Descripcion</label>
                                <div class="col-sm-9">
                                    <textarea class="form-control" style="height: 55px;" id="descr" name="descr"></textarea>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default antoclose" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary antosubmit hide">Guardar</button>
                </div>
            </div>
        </div>
    </div>
    <div id="CalenderModalEdit" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="myModalLabel2">Editar Recordatorio</h4>
                </div>
                <div class="modal-body">

                    <div id="testmodal2" style="padding: 5px 20px;">
                        <div id="antoform2" class="form-horizontal calender" role="form">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Título</label>
                                <div class="col-sm-9">
                                    <input type="text" name="txtTituloEditar" id="txtTituloEditar" class="form-control col-md-10" />
                                </div>
                            </div>
                            <div class="form-group hide">
                                <label class="col-sm-3 control-label">Descripcion</label>
                                <div class="col-sm-9">
                                    <textarea class="form-control" style="height: 55px;" id="descr2" name="descr"></textarea>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default antoclose2" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary antosubmit2 hide">Guardar</button>
                </div>
            </div>
        </div>
    </div>

    <div id="fc_create" data-toggle="modal" data-target="#CalenderModalNew"></div>
    <div id="fc_edit" data-toggle="modal" data-target="#CalenderModalEdit"></div>
    <!-- /calendar modal -->


</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">

    <script type="text/javascript">
        $(function () {
            Fn_Recordatorio_Listar();
        });

        function Fn_Recordatorio_Listar() {

            success = function (response) {
                var obj = response.d;
                init_calendar2(obj);
            }

            error = function (xhr, ajaxOptions, thrownError) {
                console.log("colocar mensaje de error");
            };

            FN_LlamarMetodo("Ver.aspx/Recordatorio_Listar", "{}", success, error);

        };

        function init_calendar2(object) {
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
                defaultView: 'month',
                allDaySlot: true,
                ignoreTimezone: false,
                selectable: false,
                longPressDelay: 10,
                select: function (start, end, allDay, jsEvent) {
                    $('#fc_create').click();

                    started = start;
                    ended = end;

                    $(".antosubmit").on("click", function () {
                        var title = $("#txtTitulo").val();
                        if (end) {
                            ended = end;
                        }

                        categoryClass = $("#event_type").val();

                        if (title) {
                            calendar.fullCalendar('renderEvent', {
                                title: title,
                                start: started,
                                end: end,
                                allDay: allDay
                            },
                                true // make the event "stick"
                            );
                        }

                        $('#txtTitulo').val('');

                        calendar.fullCalendar('unselect');

                        $('.antoclose').click();

                        return false;
                    });
                },
                eventClick: function (calEvent, jsEvent, view) {
                    $('#fc_edit').click();
                    $('#txtTituloEditar').val(calEvent.title);

                    categoryClass = $("#event_type").val();

                    $(".antosubmit2").on("click", function () {
                        calEvent.title = $("#txtTituloEditar").val();

                        calendar.fullCalendar('updateEvent', calEvent);
                        $('.antoclose2').click();
                    });

                    calendar.fullCalendar('unselect');
                },
                editable: true,
                events: object,
                timezone: 'local'
            });


        };


    </script>
</asp:Content>
