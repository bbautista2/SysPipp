﻿using SysCliVet.src.app_code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.PaginaMaestra
{
    public partial class Inicio : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Sesion.SsUsuario.Apellidos = "prueba";
        }
    }
}