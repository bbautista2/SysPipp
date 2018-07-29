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
                                    Cantidad
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtCantidadMinima"  runat="server" class="form-control col-md-7 col-xs-12 solo-numero"  name="txtCantidadMinima"  type="text">
                                </div>
                            </div>                           
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Cantidad Ingreso
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtCantidadIngreso" runat="server" class="form-control col-md-7 col-xs-12 solo-numero" name="txtCantidadIngreso" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Precio Costo
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtPrecioCosto" runat="server" class="form-control col-md-7 col-xs-12 solo-decimal" name="txtPrecioCosto" type="text">
                                </div>
                            </div>
                            <div class="ln_solid"></div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <button type="submit" class="btn btn-default">Regresar</button>
                                    <asp:Button ID="btnGuardar" runat="server"
                                        Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
       <script type="text/javascript">
        $(function () {
             $('.solo-numero').keyup(function (){
        this.value = (this.value + '').replace(/[^0-9]/g, '');
            });
               $('.solo-decimal').keyup(function (){
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



    </script>
</asp:Content>
