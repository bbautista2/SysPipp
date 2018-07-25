using CapaLibreria.Base;
using System;
using System.Net;
using System.Net.Mail;

namespace CapaLibreria.General
{
    public class Email
    {
        public static Boolean EnviarEmail(String mailTo, String message, String subject)
        {

            try
            {

                    String mailFrom = "soporte@vetpippapets.com";
                    String mailServer = "smtp.sendgrid.net";
                    Int32 mailPort = 25;
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
                            EnableSsl = mailPort == 25 ? true : false,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(mailFromAccount, mailFromPassword)
                        };

                smtp.Send(insMail);

                    return true;
              
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
