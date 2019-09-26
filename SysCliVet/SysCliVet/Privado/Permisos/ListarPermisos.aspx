<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="ListarPermisos.aspx.cs" Inherits="SysCliVet.Privado.Permisos.ListarPermisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EstilosPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>Listar Permisos</h3>
            </div>
        </div>

        <div class="clearfix"></div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Permiso </h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <br>
                        <div id="idMensaje"></div>

                           <div class="form-group">
                            <div class="col-md-12 left">
                                <a id="send" href="Administrar.aspx" class="btn btn-success"><i class="fa fa-plus-square"></i>Añadir</a>
                            </div>
                        </div>
                        <br />
                        <br />

                        <table id="tblPermisos" class="table table-striped table-bordered bulk_action">
                            <thead>
                                <tr>
                                    <th>                                       
                                    <th>Acciones</th>
                                    <th>Nombre</th>
                                    <th>Descripción</th>
                                    <th>Estado</th>
                                </tr>
                            </thead>
                            <tbody id="tbodyPermisos">
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
      <asp:HiddenField ID="hfListadoPermisos" Value="[]" runat="server" />
 <script type="text/javascript">  
    var tabla;
        $(function () {
            Fn_Iniciar();

     });



        function Fn_Iniciar() {
            Fn_PermisosListar();
     }

      function Fn_PermisosListar() {
            var object = {};
            object.items = $("input[type=hidden][id$=hfListadoPermisos]").val() != "[]" ? $.parseJSON($("input[type=hidden][id$=hfListadoPermisos]").val()) : "[]";
            var items = fn_CargarPlantilla("tabla-permisos", object);
            $("[id$=tbodyPermisos]").append(items);
            tabla = $("[id$=tblPermisos]").DataTable();
        }
      </script>

    <script type="text/x-handlebars-template" id="tabla-permisos">
        {{# each items}}                   
                        <tr>
                             <td>
                                <a onclick="fn_AbrirLink('Administrar.aspx?i={{Id}}')" class="btn btn-default btn-xs" data-toggle="tooltip" data-placement="top" data-original-title="Editar"><i class="fa fa-pencil"></i></a></td> 
                          <td>{{Nombre}}</td>     
                          <td>{{Descripcion}}</td>
                          <td>{{Estado}}</td>
                        </tr>    
        {{/each}}
    </script>
</asp:Content>
