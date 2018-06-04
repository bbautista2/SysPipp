<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="Guardar.aspx.cs" Inherits="SysCliVet.Privado.Propietario.Guardar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>Propietario</h3>
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
                        <h2>Información </h2>
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

                        <div class="form-horizontal form-label-left">

                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">
                                    Nombre <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtNombre" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="txtNombre" placeholder="Ambos nombres e.g Juan Perez" required="required" type="text">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">
                                    Email <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="email" id="txtEmail" name="txtEmail" required="required" class="form-control col-md-7 col-xs-12">
                                </div>
                            </div>
                       <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Fecha de Nacimiento <span class="required">*</span>
                        </label>
                        <div class="col-md-5 col-sm-6 col-xs-12">
                       <div class='input-group date' id='txtFechaNacimiento'>
                            <input type='text' id="txtFechaNac" class="form-control" required="required" />
                            <span class="input-group-addon">
                               <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                        </div>
                      </div>  
                       <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtDireccion">Direccion <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                          <input type="email" id="txtDireccion" name="txtDireccion" required="required" class="form-control col-md-7 col-xs-12">
                                </div>
                      </div>  
                            <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="telephone">Telefono <span class="required">*</span>
                                    Notas 
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                          <input type="tel" id="txtTelefono" name="txtTelefono" required="required" data-validate-length-range="8,20" class="form-control col-md-7 col-xs-12">
                                </div>
                      </div>   
                            <div class="ln_solid"></div>
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

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
  <script type="text/javascript">
        $(function () {
            $('#txtFechaNacimiento').datepicker();
         
    </script>
</asp:Content>
