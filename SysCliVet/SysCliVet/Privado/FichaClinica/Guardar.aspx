<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" CodeBehind="Guardar.aspx.cs" Inherits="SysCliVet.Privado.FichaClinica.Guardar" %>

<asp:Content ID="Content3" ContentPlaceHolderID="EstilosPlaceHolder" runat="server">
    <style>
        .modal {
            top: 30% !important;
        }

        .fechaVacuna {
            min-width: 100px !important;
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
                                        <input type='text' id='txtFechaFicha' class="form-control" required="required" runat="server" />
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
                                    <input id="txtNombrePro" runat="server" class="form-control col-md-7 col-xs-12" name="txtNombrePro" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Apellidos <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtApellidos" runat="server" class="form-control col-md-7 col-xs-12" name="txtApellidos" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Fecha Nac <span class="required">*</span>
                                </label>
                                <div class="col-md-5 col-sm-6 col-xs-12">
                                    <div class='input-group'>
                                        <input type='text' id='txtFechaNacPro' runat="server" class="form-control" required="required" />
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
                                    <input id="txtDireccion" runat="server" class="form-control col-md-7 col-xs-12" name="txtDireccion" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtTelefono">
                                    Teléfono <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="tel" id="txtTelefono" runat="server" name="txtTelefono" required="required" data-validate-length-range="8,20" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtEmail">
                                    Email <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="email" id="txtEmail" runat="server" name="txtEmail" required="required" class="form-control col-md-7 col-xs-12">
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
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtNombreMas">
                                    Nombre <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtNombreMas" runat="server" class="form-control col-md-7 col-xs-12" name="txtNombreMas" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Fecha Nac. <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtFechaNacMas" runat="server" class="form-control col-md-7 col-xs-12" name="txtFechaNacMas" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Raza <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtRaza" runat="server" class="form-control col-md-7 col-xs-12" name="txtRaza" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="color">
                                    Color <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="text" runat="server" id="txtColor" name="txtColor" required="required" class="form-control col-md-7 col-xs-12">
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
                                    Intac <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    Sí
                                            <input type="radio" runat="server" class="flat" name="rbIntac" id="rbIntacSi" />
                                    No
                                            <input type="radio" runat="server" class="flat" name="rbIntac" id="rbIntacNo" />
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Cast <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    Sí
                                            <input type="radio" runat="server" class="flat" name="rbCast" id="rbCastSi" />
                                    No
                                            <input type="radio" runat="server" class="flat" name="rbCast" id="rbCastNo" />
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Peso <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="text" runat="server" id="txtPeso" name="txtPeso" required="required" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Marca distintiva <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="text" runat="server" id="txtMarcaDist" name="txtMarcaDist" required="required" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtInfMedica">
                                    Información Médica Relevante <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <textarea id="txtInfMedica" runat="server" required="required" name="txtInfMedica" class="form-control col-md-7 col-xs-12"></textarea>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Medio Ambiente <span class="required">*</span>
                                </label>
                                <p class="col-md-6 col-sm-6 col-xs-12" style="margin-bottom: 0; padding-top: 8px;">
                                    Vive Solo
                                            <input type="radio" runat="server" class="flat" name="chkMedioAmbiente" id="rbViveSolo" />
                                    Otros Animales                       
                                            <input type="radio" runat="server" class="flat" name="chkMedioAmbiente" id="rbOtrosAnimales" />
                                </p>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Tipo de dieta <span class="required">*</span>
                                </label>
                                <p class="col-md-6 col-sm-6 col-xs-12" style="padding-top: 8px;">
                                    Comida Casera
                                            <input type="radio" runat="server" class="flat" name="rbTipoDieta" id="rbComidaCasera" />
                                    Concentrado                       
                                            <input type="radio" runat="server" class="flat" name="rbTipoDieta" id="rbConcentrado" />
                                    Mixto                       
                                            <input type="radio" runat="server" class="flat" name="rbTipoDieta" id="rbMixto" />
                                </p>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtMotivoCons">
                                    Motivo de la consulta <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <textarea id="txtMotivoCons" runat="server" required="required" name="txtMotivoCons" class="form-control col-md-7 col-xs-12"></textarea>
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
                                    <textarea id="txtObservacion" runat="server" name="txtObservacion" class="form-control col-md-7 col-xs-12"></textarea>
                                </div>
                            </div>
                            <div class="ln_solid">
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <a type="submit" class="btn btn-default" href="Listar.aspx"><i class="fa fa-arrow-circle-left"></i>Regresar</a>
                                    <asp:Button runat="server" ID="btnGuardarFicha" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardarFicha_Click" />
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
    <asp:HiddenField ID="hfIdPropietario" Value="0" runat="server" />
    <asp:HiddenField ID="hfVacunas" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script src="<%=ResolveUrl("~/Privado/FichaClinica/js/autocomplete.js") %>"></script>
    <script type="text/javascript">
        $(function () {
            var tablaVacuna;
            $('[id$=txtFechaFicha]').datetimepicker();
            $('[id$=txtFechaNacPro], [id$=txtFechaNacMas]').datetimepicker({
                format: 'DD/MM/YYYY'
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
                            $this.html('<input type="text" class="form-control fechaVacuna" value="' + data[i] + '"/>');
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
                        obj.Descripcion = tempRow.find("td:eq(2)").text();
                        lista[i] = $.extend(true, {}, obj);
                    }
                }
                $("input[id$=hfVacunas]").val(JSON.stringify(lista));
            }

            $("[id$=btnGuardarFicha]").click(function (e) {
                var issucces = true;

                if (validator.checkAll($('#FormPrincipal'))) {
                    FN_GuardarVacunas();
                } else {
                    issucces = false;
                }

                return issucces;

            });

            $("[id$=btnBuscarPropietario]").on('click', function (e) {
                FN_BuscarPropietario();
            });

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

                FN_LlamarMetodo("Guardar.aspx/ListaPropietariosPorDni", '{dni: "' + Dni + '" }', success, error);

            };

            function FN_LimpiarDatosPropietario() {
                $("input[id$=hfIdPropietario]").val("0");
				$("input[id$=txtNombrePro], input[id$=txtApellidos], input[id$=txtFechaNacPro], input[id$=txtDireccion], input[id$=txtTelefono], input[id$=txtEmail]").val("");				
            }

        })

    </script>
</asp:Content>
