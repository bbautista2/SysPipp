using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysCliVet
{
    /// <summary>
    /// Descripción breve de FileUpload
    /// </summary>
    public class FileUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "texto/normal";
            context.Response.Write("Hola a todos");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}