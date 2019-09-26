<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="SysCliVet.Privado.Permisos.Administrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EstilosPlaceHolder" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>Administrar Permisos</h3>
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

                        <div class="form-horizontal form-label-left">

                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtNombre">
                                    Nombre <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="txtNombre" runat="server" class="form-control col-md-7 col-xs-12" name="txtNombre" required="required" type="text">
                                </div>
                            </div>

                             <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtNombre">
                                    Descripción
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <textarea id="txtDescripcion" runat="server" class="form-control col-md-7 col-xs-12" name="txtDescription"  type="text"></textarea>
                                </div>
                            </div>
                 
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="sexo">
                                    Estado 
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div id="gender" class="btn-group" data-toggle="buttons">
                                        <label class="btn btn-default" data-toggle-class="btn-primary" data-toggle-passive-class="btn-default">
                                            <input type="radio" name="estado" id="rbActivo" runat="server">
                                            &nbsp; Activo &nbsp;                           
                                        </label>
                                        <label class="btn btn-primary" data-toggle-class="btn-primary" data-toggle-passive-class="btn-default">
                                            <input type="radio" name="estado" id="rbInactivo" runat="server">
                                            Inactivo                           
                                        </label>
                                    </div>
                                </div>
                            </div>
                      
                    <div class="x_content">
                
                    <table id="tblPermisos" class="table table-striped table-bordered bulk_action">
                      <thead>
                        <tr >
					  <th class="hidden">Id</th>
                          <th>Url</th>
                         
                        </tr>
                      </thead>


                      <tbody id="tbodyPermisos">
                       
                      </tbody>
                    </table>
                  </div>


                          
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

        

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
     <asp:HiddenField ID="hfListadoPermisos" Value="[]" runat="server" />
    <asp:HiddenField ID="hfListaNavegacion" Value="[]" runat="server" />
 <script type="text/javascript">
        var tabla;
        $(function () {
            Fn_Iniciar();

               $("[id$=btnGuardar]").click(function (x) {
                var submit = true;
                Fn_ObtenerPermisos();
                // evaluate the form using generic validaing
                if (!validator.checkAll($('#FormPrincipal'))) {
                    submit = false;
                }
                if (!submit) { x.preventDefault(); }       

     });

        });

        function Fn_Iniciar() {
            Fn_ListarMascotas();
     }

    
     function Fn_ObtenerPermisos() {
       var listaPermisos = [];
         tabla.rows('.selected').data().each(function (element, index) {
                    listaPermisos.push({"Id":element[0]});
         });
          $("#<%=hfListaNavegacion.ClientID%>").val(''); 
          $("#<%=hfListaNavegacion.ClientID%>").val(JSON.stringify(listaPermisos)); 

     }
      function Fn_ListarMascotas() {
            var object = {};
            object.items = $("input[type=hidden][id$=hfListadoPermisos]").val() != "[]" ? $.parseJSON($("input[type=hidden][id$=hfListadoPermisos]").val()) : "[]";
            var items = fn_CargarPlantilla("tabla-permisos", object);
            $("[id$=tbodyPermisos]").append(items);
            tabla = $("[id$=tblPermisos]").DataTable( {
        dom: 'Bfrtip',
        select: true,
        buttons: [
            {
                text: 'Seleccione todo',
                action: function () {
                    tabla.rows().select();
                }
            },
            {
                text: 'Limpiar selección',
                action: function () {
                    tabla.rows().deselect();
                }
            }
        ]
          });

           tabla.rows('.acceso').select();
        }
      </script>

    <script type="text/x-handlebars-template" id="tabla-permisos">
        {{# each items}}                   
                         {{#if Acceso}}
                   <tr class="acceso">
                       {{else}}
                    <tr>
                        {{/if}} 
                         <td class="hidden">{{Id}}</td>     
                          <td>{{Descripcion}}</td>                          
                        </tr>    
        {{/each}}
    </script>
</asp:Content>
