using Android.App;
using Android.Widget;
using Android.OS;
using currencyconverter.AuthorizationModule;
using System.Threading.Tasks;
using Android.Views;

namespace currencyconverter.Droid
{
    [Activity(Label = "currencyconverter", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        Button LoginButton;
        EditText LoginField;
        EditText PasswordField;
        string Login;
        string Password;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            LoginButton = FindViewById<Button>(Resource.Id.loginButton);
            LoginField = FindViewById<EditText>(Resource.Id.loginField);
            PasswordField = FindViewById<EditText>(Resource.Id.passwordField);


            LoginButton.Click += (sender, e) => {
                Login = LoginField.Text;
                Password = PasswordField.Text;
                var LoginValidator = new LoginValidator();
                var PasswordValidator = new PasswordValidator();
                var AuthSender = new AuthSender();

                var Interactor = new AuthorizationInteractor(LoginValidator, PasswordValidator, AuthSender);
                var result = Interactor.Login(Login, Password).Result;

                Toast t = Toast.MakeText(Application.Context, GetMessage(result), ToastLength.Short);
                t.SetGravity(GravityFlags.Top | GravityFlags.Left, 20, 20);
                t.Show();
            };
        }

        private string GetMessage(EAuthResult result)
        {
            string message = "";
            switch (result)
            {
                case EAuthResult.InvalidData:
                    {
                        message = "Login or password is empty!";
                        break;
                    }
                case EAuthResult.Success:
                    {
                        message = "Authenticated successfully!";
                        break;
                    }
                case EAuthResult.Unauthorized:
                    {
                        message = "Your login or password is wrong!";
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
