<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" CodeBehind="Guardar.aspx.cs" Inherits="SysCliVet.Privado.FichaClinica.Guardar" %>

<asp:Content ID="Content3" ContentPlaceHolderID="EstilosPlaceHolder" runat="server">
    <style>
        .modal{
            top: 30% !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="">

        <div class="clearfix"></div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Ficha Clínica </h2>
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
                        <br />
                        <div class="form-horizontal form-label-left">
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">
                                    Fecha <span class="required">*</span>
                                </label>
                                <div class="col-md-5 col-sm-6 col-xs-12">
                                    <div class='input-group'>
                                        <input type='text' id='txtFechaFicha' class="form-control" required="required" />
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
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
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtNombrePro">
                                    Nombre <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtNombrePro" class="form-control col-md-7 col-xs-12" name="txtNombrePro" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Fecha Nac <span class="required">*</span>
                                </label>
                                <div class="col-md-5 col-sm-6 col-xs-12">
                                    <div class='input-group'>
                                        <input type='text' id='txtFechaNacPro' class="form-control" required="required" />
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtDireccion">
                                    Dirección <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtDireccion" class="form-control col-md-7 col-xs-12" name="txtDireccion" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtTelefono">
                                    Teléfono <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="tel" id="txtTelefono" name="txtTelefono" required="required" data-validate-length-range="8,20" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtEmail">
                                    Email <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="email" id="txtEmail" name="txtEmail" required="required" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtMotivoCons">
                                </label>
                                <div class="control-label col-md-3 col-sm-3 col-xs-12">
                                    <h4 class="text-left">Información del Paciente</h4>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtNombrePac">
                                    Nombre <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtNombrePac" class="form-control col-md-7 col-xs-12" name="txtNombrePac" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Fecha Nac. <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtFechaNacPac" class="form-control col-md-7 col-xs-12" name="txtFechaNacPac" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Raza <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtRaza" class="form-control col-md-7 col-xs-12" name="txtRaza" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="color">
                                    Color <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="text" id="txtColor" name="txtColor" required="required" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Especie <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="text" id="txtEspecie" name="txtEspecie" required="required" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="sexo">
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
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Intac <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="text" id="txtIntac" name="txtIntac" required="required" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Cast <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="text" id="txtCast" name="txtCast" required="required" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Peso <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="text" id="txtPeso" name="txtPeso" required="required" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Marca distintiva <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="text" id="txtMarcaDist" name="txtMarcaDist" required="required" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtInfMedica">
                                    Información Médica Relevante <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <textarea id="txtInfMedica" required="required" name="txtInfMedica" class="form-control col-md-7 col-xs-12"></textarea>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Medio Ambiente <span class="required">*</span>
                                </label>
                                <p class="col-md-6 col-sm-6 col-xs-12" style="margin-bottom: 0; padding-top: 8px;">
                                    Vive Solo
                                            <input type="radio" class="flat" name="chkMedioAmbiente" id="medioAmb1" value="1" checked="" required />
                                    Otros Animales                       
                                            <input type="radio" class="flat" name="chkMedioAmbiente" id="medioAmb2" value="2" />
                                </p>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Tipo de dieta <span class="required">*</span>
                                </label>
                                <p class="col-md-6 col-sm-6 col-xs-12" style="padding-top: 8px;">
                                    Comida Casera
                                            <input type="radio" class="flat" name="chkTipoDieta" id="tipoDieta1" value="1" checked="" required />
                                    Concentrado                       
                                            <input type="radio" class="flat" name="chkTipoDieta" id="tipoDieta2" value="2" />
                                    Mixto                       
                                            <input type="radio" class="flat" name="chkTipoDieta" id="tipoDieta3" value="3" />
                                </p>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtMotivoCons">
                                    Motivo de la consulta <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <textarea id="txtMotivoCons" required="required" name="txtMotivoCons" class="form-control col-md-7 col-xs-12"></textarea>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtMotivoCons">
                                </label>
                                <div class="control-label col-md-3 col-sm-3 col-xs-12">
                                    <h4 class="text-left">Vacunas</h4>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <table class="table table-striped table-bordered nowrap" id="tbVacunas">
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

                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtMotivoCons">
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <button id="addVacuna" class="btn btn-primary">Agregar Vacuna</button>
                                </div>
                            </div>
                            <br />
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="textarea">
                                    Observaciones 
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <textarea id="txtObservacion" name="txtObservacion" class="form-control col-md-7 col-xs-12"></textarea>
                                </div>
                            </div>
                            <div class="ln_solid">
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <button type="submit" class="btn btn-default"><i class="fa fa-arrow-circle-left"></i>Regresar</button>
                                    <button id="send" type="submit" class="btn btn-success"><i class="fa fa-floppy-o"></i>Guardar</button>
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
    <script type="text/javascript">
        $(function () {
            var tablaVacuna;
            $('[id$=txtFechaFicha]').datetimepicker();
            $('[id$=txtFechaNacPro], [id$=txtFechaNacPac]').daterangepicker({
                singleDatePicker: true,
                singleClasses: "picker_3"
            }, function (start, end, label) {
                console.log(start.toISOString(), end.toISOString(), label);
            });
            tablaVacuna = $("#tbVacunas").DataTable({ searching: false, lengthChange: false, info: false });

            $("[id$=addVacuna]").on('click', function (e) {
                e.preventDefault();
                FN_AgregarFila();
            });

            function FN_AgregarFila() {
                var acciones,
                    data,
                    $row,
                    tabla = tablaVacuna;

                $("#addVacuna").attr({ 'disabled': 'disabled' });

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
                $('.fechaVacuna').daterangepicker({
                    singleDatePicker: true,
                    singleClasses: "picker_3"
                }, function (start, end, label) {
                    //console.log(start.toISOString(), end.toISOString(), label);
                });
            }

            function FN_EditarFila($row) {
                var data,
                    tabla = tablaVacuna;

                data = tabla.row($row.get(0)).data();

                $row.children('td').each(function (i) {
                    var $this = $(this);

                    if ($this.hasClass('acciones')) {
                        FN_SetAccionesEditar($row);
                    } else {
                        if (i == 1)
                            $this.html('<input type="text" class="form-control has-feedback-left fechaVacuna" value="' + data[i] + '"/>');
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
                    tabla = tablaVacuna;

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
                var tabla = tablaVacuna;
                if ($row.hasClass('adding')) {
                    $("#addVacuna").removeAttr('disabled');
                }
                tabla.row($row.get(0)).remove().draw();
            }

            function FN_GuardarFila($row) {
                var $acciones,
                    tabla = tablaVacuna;
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
                    $("#addVacuna").removeAttr('disabled');
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

        })

    </script>
</asp:Content>
