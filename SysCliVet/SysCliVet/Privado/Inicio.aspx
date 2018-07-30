<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SysCliVet.Privado.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="dashboard_graph">

                <div class="row x_title">
                    <div class="col-md-6">
                        <h3>Ventas <small></small></h3>
                    </div>
                    <div class="col-md-6">
                        <div id="reportrange" class="pull-right" style="background: #fff; cursor: pointer; padding: 5px 10px; border: 1px solid #ccc">
                            <i class="glyphicon glyphicon-calendar fa fa-calendar"></i>
                            <span>December 30, 2014 - January 28, 2015</span> <b class="caret"></b>
                        </div>
                    </div>
                </div>

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div id="chart_plot_cu" class="demo-placeholder"></div>
                </div>


                <div class="clearfix"></div>
            </div>
        </div>

    </div>
    <br />

    <div class="row">


        <div class="col-md-4 col-sm-4 col-xs-12">
            <div class="x_panel tile fixed_height_320">
                <div class="x_title">
                    <h2>Top 5</h2>
                    <ul class="nav navbar-right panel_toolbox" style="min-width: 46px;">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <h4>Productos mas vendidos</h4>
                    <div id="divProductos">
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-4 col-sm-4 col-xs-12">
            <div class="x_panel tile fixed_height_320 overflow_hidden">
                <div class="x_title">
                    <h2>Citas del día</h2>
                    <ul class="nav navbar-right panel_toolbox" style="min-width: 46px;">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div id="divCitas">
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-4 col-sm-4 col-xs-12">
            <div class="x_panel tile fixed_height_320">
                <div class="x_title">
                    <h2>Cumpleaños del mes</h2>
                    <ul class="nav navbar-right panel_toolbox" style="min-width: 46px;">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div id="divCumple">
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <asp:HiddenField ID="hfListadoCitas" Value="[]" runat="server" />
    <asp:HiddenField ID="hfListadoCumple" Value="[]" runat="server" />
    <asp:HiddenField ID="hfListadoProductos" Value="[]" runat="server" />

    <script type="text/javascript">
        $(function () {

            Fn_ListarCitas();
            Fn_ListarCumple();
            Fn_ListarProductos();

            var arr_data1 = [
                [gd(2012, 1, 1), 17],
                [gd(2012, 1, 2), 74],
                [gd(2012, 1, 3), 6],
                [gd(2012, 1, 4), 39],
                [gd(2012, 1, 5), 20],
                [gd(2012, 1, 6), 85],
                [gd(2012, 1, 7), 7]
            ];

            var arr_data2 = [
                [gd(2012, 1, 1), 82],
                [gd(2012, 1, 2), 23],
                [gd(2012, 1, 3), 66],
                [gd(2012, 1, 4), 9],
                [gd(2012, 1, 5), 119],
                [gd(2012, 1, 6), 6],
                [gd(2012, 1, 7), 9]
            ];


            var arr_data3 = [
                [gd(2012, 1, 1), 2],
                [gd(2012, 1, 2), 89],
                [gd(2012, 1, 3), 65],
                [gd(2012, 1, 4), 45],
                [gd(2012, 1, 5), 6],
                [gd(2012, 1, 6), 76],
                [gd(2012, 1, 7), 9]
            ];


            var chart_plot_01_settings = {
                series: {
                    lines: {
                        show: false,
                        fill: true
                    },
                    splines: {
                        show: true,
                        tension: 0.4,
                        lineWidth: 1,
                        fill: 0.4
                    },
                    points: {
                        radius: 0,
                        show: true
                    },
                    shadowSize: 2
                },
                grid: {
                    verticalLines: true,
                    hoverable: true,
                    clickable: true,
                    tickColor: "#d5d5d5",
                    borderWidth: 1,
                    color: '#fff'
                },
                colors: ["#a27692", "#684c5f"],
                xaxis: {
                    tickColor: "rgba(51, 51, 51, 0.06)",
                    mode: "time",
                    tickSize: [1, "day"],
                    //tickLength: 10,
                    axisLabel: "Date",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 10
                },
                yaxis: {
                    ticks: 8,
                    tickColor: "rgba(51, 51, 51, 0.06)",
                },
                tooltip: false
            }


            if ($("#chart_plot_cu").length) {
                console.log('Plot1');

                $.plot($("#chart_plot_cu"), [arr_data1, arr_data2], chart_plot_01_settings);
            }

            function Fn_ListarCitas() {
                var object = {};
                object.items = $("input[type=hidden][id$=hfListadoCitas]").val() != "[]" ? $.parseJSON($("input[type=hidden][id$=hfListadoCitas]").val()) : "[]";
                var items = fn_CargarPlantilla("data-citas", object);
                $("[id$=divCitas]").html(items);
            }

            function Fn_ListarCumple() {
                var object = {};
                object.items = $("input[type=hidden][id$=hfListadoCumple]").val() != "[]" ? $.parseJSON($("input[type=hidden][id$=hfListadoCumple]").val()) : "[]";
                var items = fn_CargarPlantilla("data-cumple", object);
                $("[id$=divCumple]").html(items);
            }

            function Fn_ListarProductos() {
                var object = {};
                object.items = $("input[type=hidden][id$=hfListadoProductos]").val() != "[]" ? $.parseJSON($("input[type=hidden][id$=hfListadoProductos]").val()) : "[]";
                var items = fn_CargarPlantilla("data-productos", object);
                $("[id$=divProductos]").html(items);
            }

        })

    </script>

    <script type="text/x-handlebars-template" id="data-citas">
        {{# each items}}                   
            <article class="media event">
                <a class="pull-left date">
                    <p class="month">{{Mes}}</p>
                    <p class="day">{{Dia}}</p>
                </a>
                <div class="media-body">
                    <a class="title" href="#">{{Paciente}}</a>
                    <p>{{Motivo}}</p>
                </div>
            </article>
        {{/each}}
    </script>

    <script type="text/x-handlebars-template" id="data-cumple">
        {{# each items}}                   
            <article class="media event">
                <a class="pull-left date">
                    <p class="month">{{Mes}}</p>
                    <p class="day">{{Dia}}</p>
                </a>
                <div class="media-body">
                    <a class="title" href="#">{{Paciente}}</a>
                    <p>Edad: {{Edad}}</p>
                </div>
            </article>
        {{/each}}
    </script>

    <script type="text/x-handlebars-template" id="data-productos">
        {{# each items}}                   
            <div class="widget_summary">
                <div class="w_left" style="width: 80%">
                    <span>{{Nombre}}</span>
                </div>
                <div class="w_center w_55 hide">
                    <div class="progress">
                        <div class="progress-bar bg-green" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 66%;">
                            <span class="sr-only">60% Complete</span>
                        </div>
                    </div>
                </div>
                <div class="w_right w_20">
                    <span>{{Salida}}</span>
                </div>
            </div>
        {{/each}}
    </script>

</asp:Content>

