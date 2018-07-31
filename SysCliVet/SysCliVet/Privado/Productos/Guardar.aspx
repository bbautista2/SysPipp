<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="Guardar.aspx.cs" Inherits="SysCliVet.Privado.Productos.Guardar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EstilosPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>Producto</h3>
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
                        <div id="idMensaje"></div>

                        <div class="form-horizontal form-label-left">

                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="cmbProductoCategoria">
                                    Categoría <span class="required"></span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:DropDownList runat="server" ID="cmbProductoCategoria" CssClass="form-control col-md-7 col-xs-12"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Código <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtCodigo" runat="server" class="form-control col-md-7 col-xs-12" name="txtCodigo" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Descripción <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtDescripcion" runat="server" class="form-control col-md-7 col-xs-12" name="txtDescripcion" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Stock <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtCantidadIngreso" runat="server" class="form-control col-md-7 col-xs-12 solo-numero" required="required" name="txtCantidadIngreso" type="text">
                                </div>
                            </div>
                            <div class="item form-group" style="margin-top: 15px;" id="divStock" runat="server">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                </label>
                                <div class="col-md-9 col-sm-9 col-lg-9">
                                    <button type="button" style="background-color: #5cb85c; border-color: #4cae4c; margin-bottom: 5px;" class="btn btn-success" data-toggle="modal" data-target="#modalIngreso">Registrar Ingreso</button>
                                    <button type="button" style="margin-bottom: 5px;" class="btn btn-danger" data-toggle="modal" data-target="#modalSalida">Registrar Salida</button>
                                </div>
                            </div>
                            <div class="ln_solid"></div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <a type="submit" class="btn btn-default" href="Listar.aspx"><i class="fa fa-arrow-circle-left"></i>Regresar</a>
                                    <asp:Button ID="btnGuardar" runat="server"
                                        Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div id="modalIngreso" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog" style="z-index: 9999">
                <div class="modal-content">

                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Registrar Ingreso</h4>
                    </div>
                    <div class="modal-body">
                        <div style="padding: 5px 20px;">
                            <div class="form-horizontal calender" role="form">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Descripcion</label>
                                    <div class="col-sm-9">
                                        <input class="form-control" required="required" id="txtDescripcionIn">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Cantidad</label>
                                    <div class="col-sm-9">
                                        <input class="form-control solo-numero" required="required" id="txtCantidadIn">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnIngreso" style="background-color: #5cb85c; border-color: #4cae4c;" class="btn btn-success antosubmit2">Guardar</button>
                        <button type="button" class="btn btn-default antoclose2" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="modalSalida" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog" style="z-index: 9999">
                <div class="modal-content">

                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" id="myModalLabel2">Registrar Salida</h4>
                    </div>
                    <div class="modal-body">
                        <div style="padding: 5px 20px;">
                            <div class="form-horizontal calender" role="form">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Descripcion</label>
                                    <div class="col-sm-9">
                                        <input class="form-control" required="required" id="txtDescripcionSa">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Cantidad</label>
                                    <div class="col-sm-9">
                                        <input class="form-control solo-numero" required="required" id="txtCantidadSa">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnSalida" class="btn btn-danger">Guardar</button>
                        <button type="button" class="btn btn-default antoclose2" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <asp:HiddenField ID="hfProductoId" runat="server" />
    <script type="text/javascript">
        $(function () {
            $('.solo-numero').keyup(function () {
                this.value = (this.value + '').replace(/[^0-9]/g, '');
            });
            $('.solo-decimal').keyup(function () {
                this.value = (this.value + '').replace(/^[0-9]$ {0,2}/g, '');
            });

            $("[id$=btnGuardar]").click(function (x) {
                var submit = true;

                // evaluate the form using generic validaing
                if (!validator.checkAll($('#FormPrincipal'))) {
                    submit = false;
                }

                if (!submit) { x.preventDefault(); }

            });

        });

        $('#btnIngreso').unbind().click(function () {
            var descripcion = $("input[id$=txtDescripcionIn]").val();
            var cantidad = $("input[id$=txtCantidadIn]").val();
            FN_ActualizarStock(1, descripcion, cantidad);
        });

        $('#btnSalida').unbind().click(function () {
            var descripcion = $("input[id$=txtDescripcionSa]").val();
            var cantidad = $("input[id$=txtCantidadSa]").val();
            FN_ActualizarStock(2, descripcion, cantidad);
        });

        function FN_ActualizarStock(tipo, descripcion, cantidad) {

            var id = $("input[id$=hfProductoId]").val();

            success = function (response) {
                var result = response.d;
                if (result.correcto == true) {
                    $("input[id$=txtCantidadIngreso]").val(result.stockActual);
                    FN_Mensaje('s', result.mensaje);
                }
                else
                    FN_Mensaje('e', result.mensaje);
                if (tipo == 1) {
                    $("[id$=modalIngreso]").modal("hide");
                    $("input[id$=txtDescripcionIn], input[id$=txtCantidadIn]").val("");
                }
                else {
                    $("[id$=modalSalida]").modal("hide");
                    $("input[id$=txtDescripcionSa], input[id$=txtCantidadSa]").val("");
                }
            }

            error = function (xhr, ajaxOptions, thrownError) {
                if (tipo == 1) {
                    $("[id$=modalIngreso]").modal("hide");
                    $("input[id$=txtDescripcionIn], input[id$=txtCantidadIn]").val("");
                }
                else {
                    $("[id$=modalSalida]").modal("hide");
                    $("input[id$=txtDescripcionSa], input[id$=txtCantidadSa]").val("");
                }
            };

            FN_LlamarMetodo("Guardar.aspx/ActualizarStock", '{tipo: ' + tipo + ', id: "' + id + '", descripcion: "' + descripcion + '", cantidad: ' + cantidad + ' }', success, error);
        }

    </script>
</asp:Content>
