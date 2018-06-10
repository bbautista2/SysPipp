<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="SysCliVet.Privado.Propietario.Listar" %>
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
                      <button class="btn btn-default" type="button"  >Buscar</button>
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
                    <h2>Listado de Propietarios </h2>
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
                   					
     <div class="form-group">
                        <div class="col-md-12 left">
                          <a id="send" href="Guardar.aspx"  class="btn btn-success"><i class="fa fa-plus-square"></i> Añadir</a>
                        </div>
                      </div>
           <br />
           <br />
                    <table id="datatable-responsive2" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                      <thead>
                        <tr>
                          <th>Acciones</th>
                          <th>Nombre</th>
                          <th>Email</th>
                          <th>Teléfono</th>
                          <th>Fecha Nacimiento</th>
                          <th>Estado</th>
                        </tr>
                      </thead>
                      <tbody id="tbodyPropietario">
                      
                                   
                      </tbody>
                    </table>
					
					
                  </div>
                    </div>
                  </div>
        </div>
                  </div>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">  
     <asp:HiddenField ID="hfListadoPropietarios" Value="[]" runat="server" />
      <script type="text/javascript">
      $(function () {
          fn_iniciar();

          });

          function fn_iniciar(){
              Fn_ListarPropetarios();
          }

          function Fn_ListarPropetarios() {       
            var object = {};
            object.items = ($("input[type=hidden][id$=hfListadoPropietarios]").val() != "" && $("input[type=hidden][id$=hfListadoPropietarios]").val() != undefined) ? $.parseJSON($("input[type=hidden][id$=hfListadoPropietarios]").val()) : "[]" ;
            var items = fn_CargarPlantilla("table-propietario", object);
              $("[id$=tbodyPropietario]").append(items);
              $("[id$=datatable-responsive2]").DataTable();
          }



    </script>            

     <script type="text/x-handlebars-template" id="table-propietario">
        {{# each items}}                   
                        <tr>
                          <td>                            
                            <a onclick="fn_AbrirLink('Guardar.aspx?i={{Id}}')" class="btn btn-default btn-xs" data-toggle="tooltip" data-placement="top" data-original-title="Editar" ><i class="fa fa-pencil"></i>  </a>
                            <a href="#" class="btn btn-default btn-xs"  data-toggle="tooltip" data-placement="top" data-original-title="Eliminar" ><i class="fa fa-trash-o"></i>  </a>
                          </td>
                          <td>{{Nombre}}</td>
                          <td>{{Email}}</td>
                          <td>{{Telefono}}</td>
                          <td>{{FechaNacimiento}}</td>
                          {{#if Estado}}
                            <td><button type="button" class="btn btn-success btn-xs">Activo</button></td>
                          {{else}}
                           <td><button type="button" class="btn btn-danger btn-xs">Inactivo</button></td>
                          {{/if}}
                        </tr>               
            
        {{/each}}
    </script>     
</asp:Content>
