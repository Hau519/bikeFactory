using BikeFactory1.WebUI.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeFactory1.WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        #region WS proxy methods vs Data proxy methods

        private void SignIn_WS()
        {
            try
            {
                var wsClient = new UserServiceSoapClient();
                bool success = wsClient.UserAndPasswordAreValid(txtEmail.Text, txtPassword.Text);
                if (success)
                    FormsAuthentication.RedirectFromLoginPage(txtEmail.Text, true);
                else
                    StaticMethods.DisplayMessage("Invalid e-mail or password", this);
            }
            catch (Exception ex)
            {
                StaticMethods.DisplayMessage(ex.Message, this);
            }
        }

        void RegisterUser_WS()
        {
            try
            {
                var wsClient = new UserServiceSoapClient();
                bool success = wsClient.Register(txtNewEmail.Text, txtNewPassword1.Text);
                if (success)
                {
                    StaticMethods.DisplayMessage($"{txtNewEmail.Text} has been successfully created!", Page);
                    txtEmail.Text = txtNewEmail.Text;
                    txtPassword.Text = txtNewPassword1.Text;
                }
                    
                else
                    StaticMethods.DisplayMessage("This e-mail is already registered", Page);
            }
            catch (Exception ex)
            {
                StaticMethods.DisplayMessage(ex.Message, this);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            SignIn_WS();
        }



        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtNewEmail.Text.Trim() == "")
            {
                StaticMethods.DisplayMessage("E-mail is required", Page);
                return;
            }
            else if (!Regex.IsMatch(txtNewEmail.Text, "^\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$"))
            {
                StaticMethods.DisplayMessage("E-mail is invalid", Page);
                return;
            }
            else if (txtNewPassword1.Text.Trim() == "")
            {
                StaticMethods.DisplayMessage("Password is required", Page);
                return;
            }
            else if (txtNewPassword1.Text != txtNewPassword2.Text)
            {
                StaticMethods.DisplayMessage("The passwords do not match", Page);
                return;
            }

            RegisterUser_WS();
        }
    }

}