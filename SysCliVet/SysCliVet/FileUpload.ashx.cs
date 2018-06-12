using System;
using System.IO;
using System.Web;
using System.Web.SessionState;
using CapaEntidad;
using SysCliVet.src.app_code;

namespace SysCliVet
{
    /// <summary>
    /// Descripción breve de FileUpload
    /// </summary>
    public class FileUpload : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (context.Request.Files.Count == 0)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("No file received");
                }
                else
                {
                    string query = context.Request.QueryString["p"];

                    if (!string.IsNullOrEmpty(query) && query.Equals("1"))
                    {
                        HttpPostedFile uploadFile = context.Request.Files[0];
                        //clsUsuario objUsuario = Sesion.SsUsuario;
                        Random ran = new Random();
                        string nombreImagen = 99/*objUsuario.Id*/ + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "_" + ran.Next(0, 10000) + "pacienteImagen" + Path.GetExtension(uploadFile.FileName).ToLower();
                        string resourcePath = Config.PacienteRutaFisica + "imagenes\\" + nombreImagen;
                        if (!Directory.Exists(Config.PacienteRutaFisica + "imagenes\\"))
                            Directory.CreateDirectory(Config.PacienteRutaFisica + "imagenes\\");
                        try
                        {
                            uploadFile.SaveAs(resourcePath);
                            context.Response.ContentType = "text/plain";
                            context.Response.Write(
                                "{\"nombre\":\"" + Config.MascotaRutaVirtual + "imagenes/" + nombreImagen +
                                "\",\"Type\":\"" + uploadFile.ContentType +
                                "\",\"tag\":\"" + "?q=" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") +
                                "\",\"localFolder\":\"" + "/Recursos/paciente/imagenes/" + uploadFile.FileName + "\"}"
                                );
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            catch (Exception)
            {
                context.Response.Write(
                                "{\"nombre\":\"\" " +
                                "\",\"Type\":\"\" " +
                                "\",\"tag\":\"" + "?q=" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") +
                                "\",\"localFolder\":\"\"}"
                                );
            }
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