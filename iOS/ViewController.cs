using System;
using System.Threading.Tasks;
using currencyconverter.AuthorizationModule;
using UIKit;

namespace currencyconverter.iOS
{
    public partial class ViewController : UIViewController
    {
        private String login;
        private String password;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            password_textField.SecureTextEntry = true;

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }










       

        partial void loginButton(UIButton sender)
        {


            login = loginField.Text;
            password = passwordField.Text;
            var message = "";
            var loginValidator = new LoginValidator();
            var passwordValidator = new PasswordValidator();
            var authSender = new AuthSender();
            var interactor = new AuthorizationInteractor(loginValidator, passwordValidator, authSender);
            var result = interactor.Login(login, password).Result;

            message = GetMessage(result);
            showAlert(message);
        }

        private void showAlert(string message)
        {
            UIAlertController alert = UIAlertController.Create("", message, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, (actionOK) => { }));
            this.PresentViewController(alert, true, null);
        }

        private string GetMessage(EAuthResult result)
        {
            string message = "";
            switch (result)
            {
                case EAuthResult.InvalidData:
                    {
                        message = "Login or password coldn't be blank!";
                        break;
                    }
                case EAuthResult.Success:
                    {
                        message = "Authenticated successfully!";
                        break;
                    }
                case EAuthResult.Unauthorized:
                    {
                        message = "Your login or password is incorrect! Try again!";
                        break;
                    }
                default: break;
            }
            return message;
        }
    }


    class AuthSender : IAuthSender
    {
        public async Task<bool> SendAuthRequest(string login, string pass)
        {
            if (login == "admin" && pass == "admin")
            {
                return true;
            }
            return false;
        }
    }

}