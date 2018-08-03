using CapaLibreria.Base;
using CapaLibreria.Conexiones;
using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;

namespace CapaLibreria.General
{
    public static class Email
    {

        class MailView
        {
            public MailView()
            {

            }
            public MailView(String message, String subject, String mailFrom)
            {
                this.message = message;
                this.subject = subject;
                this.mailFrom = mailFrom;
            }
            public List<String> mailTo { get; set; }
            public String message { get; set; }
            public String subject { get; set; }
            public String mailFrom { get; set; }
        }

        public static Boolean EnviarEmail(String mailTo, String message, String subject)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                
                String mailFrom = "soporte@vetpippapets.com";
                String mailServer = "smtp.sendgrid.net";
                Int32 mailPort = 587;
                String mailFromAccount = "azure_940186b351a4c0b22655f2a90900c66b@azure.com";
                String mailFromPassword = "kepy0r2018";
                String mailSubject = subject;
                String mailBody = message;
                mailBody = message;
                MailMessage insMail = new MailMessage(new MailAddress(mailFrom), new MailAddress(mailTo));

                var _with1 = insMail;
                _with1.Subject = mailSubject;
                _with1.Body = mailBody;
                _with1.IsBodyHtml = true;
                _with1.From = new MailAddress(mailFrom);
                _with1.ReplyTo = new MailAddress(mailFrom);
                SmtpClient smtp = new SmtpClient
                {
                    Host = mailServer,
                    Port = mailPort,
                    EnableSsl = false,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(mailFromAccount, mailFromPassword)
                };

                //smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                smtp.Send(insMail);

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean EnviarEmailQr(String mailTo, String message, String subject, String url)
        {

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                QRCodeEncoder qrEncoder = new QRCodeEncoder();
                Bitmap imgQr = qrEncoder.Encode(url);
                var imageQrId = "myImgQr";

                // Create the HTML view
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                                                             message,
                                                             Encoding.UTF8,
                                                             MediaTypeNames.Text.Html);
                // Create a plain text message for client that don't support HTML
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(
                                                            Regex.Replace(message,
                                                                          "<[^>]+?>",
                                                                          String.Empty),
                                                            Encoding.UTF8,
                                                            MediaTypeNames.Text.Plain);

                System.IO.MemoryStream ms = new MemoryStream();
                imgQr.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;

                //using (MemoryStream ms = new MemoryStream())
                //{
                //    imgQr.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //    ms.Position = 0;
                    
                    LinkedResource img = new LinkedResource(ms);
                    img.ContentId = imageQrId;
                    img.ContentType = new ContentType("image/png");
                    htmlView.LinkedResources.Add(img);
                    
                //}

                String mailFrom = "soporte@vetpippapets.com";
                String mailServer = "smtp.sendgrid.net";
                Int32 mailPort = 587;
                String mailFromAccount = "azure_940186b351a4c0b22655f2a90900c66b@azure.com";
                String mailFromPassword = "kepy0r2018";
                String mailSubject = subject;
                MailMessage insMail = new MailMessage(new MailAddress(mailFrom), new MailAddress(mailTo));

                var _with1 = insMail;
                _with1.AlternateViews.Add(plainView);
                _with1.AlternateViews.Add(htmlView);

                _with1.Subject = mailSubject;
                _with1.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient
                {
                    Host = mailServer,
                    Port = mailPort,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Timeout = 10000,
                    Credentials = new NetworkCredential(mailFromAccount, mailFromPassword)
                };

                //smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                //MailView objMail = new MailView(message, subject, mailFrom);
                //objMail.mailTo = new List<string>();
                //objMail.mailTo.Add(mailTo);
                //smtp.SendAsync(insMail, objMail);
                smtp.Send(insMail);

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            MailView token = (MailView)e.UserState;
            BaseEntidad ent = new BaseEntidad();
            Boolean isCancelled = false;

            if (e.Cancelled)
            {
                isCancelled = true;
            }
            if (e.Error != null)
            {
                for (int i = 0; i < token.mailTo.Count; i++)
                {
                    Email_InsertLog(ref ent, token.mailTo[i], token.subject, token.message, token.mailFrom, e.Error.ToString(), isCancelled ? (Int16)3 : (Int16)2/*Error*/);
                }
            }
            else
            {
                for (int i = 0; i < token.mailTo.Count; i++)
                {
                    Email_InsertLog(ref ent, token.mailTo[i], token.subject, token.message, token.mailFrom, "", 1 /*Succes*/);
                }
            }
        }

        public static bool Email_InsertLog(ref BaseEntidad Base, string mailTo, string subject, string message, string mailFrom, string error, Int16 status)
        {
            Boolean isCorrect = false;
            SqlConnection objConnection = null;
            try
            {
                objConnection = Conexiones.Conexion.GetConexion();
                SqlCommand cmd = new SqlCommand("Email_InsertLog", objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAIL", message);
                cmd.Parameters.AddWithValue("@EMAILFROM", mailFrom);
                cmd.Parameters.AddWithValue("@EMAILTO", mailTo);
                cmd.Parameters.AddWithValue("@ERRORCODE", error);
                cmd.Parameters.AddWithValue("@SUBJECT", subject);
                cmd.Parameters.AddWithValue("@STATUS", status);

                cmd.ExecuteNonQuery();
                isCorrect = true;

            }
            catch (Exception ex)
            {
                Base.Errores.Add(new BaseEntidad.ListaError(ex, "Error en la base de datos"));
            }
            finally
            {
                objConnection.Close();
            }
            return isCorrect;
        }

    }
}
