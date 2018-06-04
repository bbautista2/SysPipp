<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="Guardar.aspx.cs" Inherits="SysCliVet.Privado.HistorialClinico.Guardar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
   
    <div class="">
    
    <div class="clearfix"></div>

    <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Historia </h2>
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
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Fecha <span class="required">*</span>
                        </label>
                        <div class="col-md-5 col-sm-6 col-xs-12">
                       <div class='input-group date' id='txtFechaHistoria'>
                            <input type='text' class="form-control" required="required" />
                            <span class="input-group-addon">
                               <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                        </div>
                      </div> 
                      <div class="item form-group">
                        <div class="control-label col-md-3 col-sm-3 col-xs-12"><h4>Estado General</h4>
                        </div>                       
                      </div> 
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                        </label>
                        <div class="col-md-3 col-sm-6 col-xs-12">
                         <input type="checkbox" id="chkAgitacion" class="flat" > Agitación
                        </div>
                      </div> 
                       <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                        </label>
                        <div class="col-md-3 col-sm-6 col-xs-12">
                         <input type="checkbox" id="chkDepresion" class="flat" > Depresión
                        </div>
                      </div> 
                       <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">Apetito
                        </label>
                        <div class="col-md-5 col-sm-6 col-xs-12">
                            <div class="radio">
                            <label>
                             <input type="radio" class="flat"  name="rbApetito" value="1"> 
                                 Bueno  </label></div>
                            <div class="radio">
                            <label>
                             <input type="radio" class="flat"  name="rbApetito" value="2"> 
                              Malo  </label></div>
                           <div class="radio">
                            <label>
                                 <input type="radio" class="flat"  name="rbApetito" value="3">
                                Normal</label></div>
                        </div>
                      </div> 
                               <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">CC
                        </label>
                        <div class="col-md-5 col-sm-6 col-xs-12">
                            <div class="radio">
                            <label>
                             <input type="radio" class="flat"  name="rbCC" value="1"> 
                                 Normal  </label></div>
                            <div class="radio">
                            <label>
                             <input type="radio" class="flat"  name="rbCC" value="2"> 
                              Obeso  </label></div>
                           <div class="radio">
                            <label>
                                 <input type="radio" class="flat"  name="rbCC" value="3">
                                Caquésico</label></div>
                        </div>
                      </div> 
                       <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Peso Actual
                        </label>
                        <div class="col-md-1 col-sm-3 col-xs-12">
                          <input  id="txtPeso" name="txtEmail"  class="form-control col-md-7 col-xs-12">
                        </div>                    
                         <div class="col-md-2 col-sm-4 col-xs-12">
                          <input  id="txtPesoPerdida" name="txtEmail" placeholder="PÉRDIDA/KG/DÍA"  class="form-control col-md-7 col-xs-12">
                        </div>
                      </div>  

                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Signos Clínicos / Sintomas 
                        </label>   
                           <div class="col-md-6 col-sm-6 col-xs-12">
                          
                          <input id="tags_1" type="text" class="tags form-control" value="" placeholder="Agrega sintoma" />
                          <div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>
                        

                        </div>

                      </div>  
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Análisis Solicitados
                        </label>   
                           <div class="col-md-6 col-sm-6 col-xs-12">                                  
                                 <input id="tags_2" type="text" class="tags form-control" value="" placeholder="Agrega sintoma" />
                          <div id="suggestions-container2" style="position: relative; float: left; width: 250px; margin: 10px;"></div>
                        </div>
                      </div>  
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="textarea">Descarte 
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <textarea id="txtDescarte" name="txtDescarte" class="form-control col-md-7 col-xs-12"></textarea>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="textarea">Resultados 
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <textarea id="txtResultado" name="txtResultado" class="form-control col-md-7 col-xs-12"></textarea>
                        </div>
                      </div>
                     
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="textarea">Observaciones 
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <textarea id="txtObservacion" name="txtObservacion" class="form-control col-md-7 col-xs-12"></textarea>
                        </div>
                      </div>
                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <button type="submit" class="btn btn-default"><i class="fa fa-arrow-circle-left"></i> Regresar</button>
                          <button id="send" type="submit" class="btn btn-success"><i class="fa fa-floppy-o"></i> Guardar</button>
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
            $('#txtFechaHistoria').datetimepicker();
            $("#tags_2").tagsInput({ width: "auto",defaultText:'Añadir',autocomplete:{selectFirst:true,width:'100px',autoFill:true},typeahead: {
    source: ['Amsterdam', 'Washington', 'Sydney', 'Beijing', 'Cairo']
  },
   });
        })
        
    </script>
</asp:Content>
