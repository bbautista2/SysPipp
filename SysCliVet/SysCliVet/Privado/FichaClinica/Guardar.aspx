<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Privado/PaginaMaestra/Inicio.Master" CodeBehind="Guardar.aspx.cs" Inherits="SysCliVet.Privado.FichaClinica.Guardar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>Ficha Clínica</h3>
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

                        <!-- Smart Wizard -->
                        <p>Pasos para registrar una Ficha Clínica.</p>
                        <div id="wizard" class="form_wizard wizard_horizontal">
                            <ul class="wizard_steps">
                                <li>
                                    <a href="#step-1">
                                        <span class="step_no">1</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#step-2">
                                        <span class="step_no">2</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#step-3">
                                        <span class="step_no">3</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#step-4">
                                        <span class="step_no">4</span>
                                    </a>
                                </li>
                            </ul>
                            <div id="step-1">
                                <div class="form-horizontal form-label-left">
                                    <h2 class="StepTitle">Paso 1: Información del Propietario</h2>
                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtNombrePro">
                                            Nombre <span class="required">*</span>
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <input id="txtNombrePro" class="form-control col-md-7 col-xs-12" name="txtNombrePro" required="required" type="text">
                                        </div>
                                    </div>
                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtFechaNacPro">
                                            Fecha Nac <span class="required">*</span>
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <input id="txtFechaNacPro" class="form-control col-md-7 col-xs-12" name="txtFechaNacPro" required="required" type="text">
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

                                </div>
                            </div>
                            <div id="step-2">
                                <div class="form-horizontal form-label-left">
                                    <h2 class="StepTitle">Paso 2: Información del Paciente</h2>
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
                                </div>
                            </div>
                            <div id="step-3">
                                <div class="form-horizontal form-label-left">
                                    <h2 class="StepTitle">Paso 3: Información Relevante</h2>
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
                                        <p class="col-md-6 col-sm-6 col-xs-12">
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
                                        <p class="col-md-6 col-sm-6 col-xs-12">
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
                                </div>
                            </div>
                            <div id="step-4">
                                <div class="form-horizontal form-label-left">
                                    <h2 class="StepTitle">Paso 4: Otros datos</h2>
                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="txtInfMedica">
                                            Vacunas <span class="required">*</span>
                                        </label>
                                    </div>
                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                            Observaciones <span class="required">*</span>
                                        </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <textarea id="txtObservacion" required="required" name="txtObservacion" class="form-control col-md-7 col-xs-12"></textarea>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <!-- End SmartWizard Content -->

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
        });

    </script>
</asp:Content>
