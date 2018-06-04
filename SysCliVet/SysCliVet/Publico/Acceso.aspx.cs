using CapaEntidad;
using CapaLibreria.Base;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Publico
{
    public partial class Acceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String message = String.Empty;
            if (txtPassword.Text.Length <= 16)
            {
                if (!String.IsNullOrEmpty(txtUsuario.Text) && !String.IsNullOrEmpty(txtPassword.Text))
                {
                    clsBaseEntidad baseEntidad = new clsBaseEntidad();
                    clsUsuario objUser = clsLogica.Instance.Users_ValidatebyEmailAndPassword_v3(ref entity, txtEmail.Text, txtPassword.Text);

                    if (entity.Errors.Count == 0)
                    {
                        if (objUser != null)
                        {
                            #region Set Language for User
                            DataTable dt = xLogic.Instance.Language_GetByID(ref entity, objUser.Language.ID);
                            if (dt != null && entity.Errors.Count == 0)
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    String lanId = clsUtilities.ValidateDataRowKey(dt.Rows[0], "ID");
                                    String lanCultureInfo = clsUtilities.ValidateDataRowKey(dt.Rows[0], "CULTUREINFO");
                                    String lanIcon = clsUtilities.ValidateDataRowKey(dt.Rows[0], "ICON");
                                    String lanName = clsUtilities.ValidateDataRowKey(dt.Rows[0], "LANGUAGENAME");
                                    String lanIdCulture = clsUtilities.ValidateDataRowKey(dt.Rows[0], "IDCULTURE");

                                    BaseSession.SsLanguage = new List<string>();
                                    BaseSession.SsLanguage.Add(lanId);
                                    BaseSession.SsLanguage.Add(lanCultureInfo);
                                    BaseSession.SsLanguage.Add(lanIcon);
                                    BaseSession.SsLanguage.Add(lanName);
                                    BaseSession.SsLanguage.Add(lanIdCulture);
                                    CultureInfo ci = ManageGlobalization.GetUrlCulture(BaseSession.SsLanguage);
                                    Thread.CurrentThread.CurrentCulture = ci;
                                    Thread.CurrentThread.CurrentUICulture = ci;
                                }
                            }
                            #endregion

                            BaseSession.SsUser = (clsUsers)objUser;
                            BaseSession.SsTheme = objUser.Theme;

                            if (!String.IsNullOrEmpty(Request.QueryString["back_url"]))
                            {

                                Response.Redirect(Request.QueryString["back_url"].ToString());
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(objUser.NamePageDefault))
                                {
                                    Response.Redirect(objUser.NamePageDefault);
                                }
                                else
                                {
                                    Response.Redirect(Config.UrlPageDefault);
                                }
                            }



                        }
                        else
                        {
                            this.lblMessage.Text = CustomTranslation.ValidateAndReplace("Messages", ("INFO_NOFOUND_USER"), "User not found");//entity.Errors[0].MessageClient;
                        }
                    }
                    else
                    {
                        this.lblMessage.Text = entity.Errors[0].MessageClient;
                    }
                }
                else
                {
                    this.lblMessage.Text = "Enter your username and password");
                }
            }
            else
                this.lblMessage.Text = CustomTranslation.ValidateAndReplace("Messages", ("INFO_MAX_LENGHT_16_CHARACTER"), "*Password Max Length is 16 characters");
        }

    }
}