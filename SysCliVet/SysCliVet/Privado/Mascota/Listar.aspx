<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="SysCliVet.Privado.Mascota.Listar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="">
    <div class="page-title">
              <div class="title_left">
                <h3>Mascota</h3>
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
                    <h2>Listado de Mascotas </h2>
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
                          <button id="send" type="submit" class="btn btn-success"><i class="fa fa-plus-square"></i> Añadir</button>
                        </div>
                      </div>
           <br />
           <br />
                    <table id="datatable-responsive" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                      <thead>
                        <tr>
                          <th>Accion</th>
                          <th>Foto</th>
                          <th>Nombre</th>
                          <th>Dueño</th>                         
                          <th>Edad</th>
                          <th>En tratamiento</th>
                      
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <td>                            
                            <a href="#" class="btn btn-default btn-xs "><i class="fa fa-folder"></i> Ver</a>
                            <a href="#" class="btn btn-default btn-xs"><i class="fa fa-pencil"></i> Editar</a>
                            <a href="#" class="btn btn-default btn-xs"   ><i class="fa fa-trash-o"></i> Eliminar</a>
                          </td>
                          <td> <ul class="list-inline">
                              <li>
                                <img src="images/user.png" class="avatar" alt="Avatar">
                              </li>                             
                            </ul></td>
                          <td>System Architect</td>
                          <td>
                            
                         </td>
                          <td>61</td>
                     <td><div class="progress progress_sm">
                              <div class="progress-bar bg-green" role="progressbar" data-transitiongoal="77"></div>
                            </div>
                            <small>77% Complete</small>
</td>
                        </tr>
                        <tr>
                          <td>                       
                            <a href="#" class="btn btn-default btn-xs "><i class="fa fa-folder"></i> Ver</a>
                            <a href="#" class="btn btn-default btn-xs"><i class="fa fa-pencil"></i> Editar</a>
                            <a href="#" class="btn btn-default btn-xs"   ><i class="fa fa-trash-o"></i> Eliminar</a>
                          </td>
                          <td> <ul class="list-inline">
                              <li>
                                <img src="images/user.png" class="avatar" alt="Avatar">
                              </li>                             
                            </ul></td>
                          <td>Accountant</td>
                          <td></td>
                          <td>63</td>
                          <td><div class="progress progress_sm">
                              <div class="progress-bar bg-green" role="progressbar" data-transitiongoal="77"></div>
                            </div>
                            <small>77% Complete</small>
</td>
                        </tr>
                     
               
                      </tbody>
                    </table>
					
					
                  </div>
                    </div>
                  </div>
        </div>
                  </div>
</asp:Content>
