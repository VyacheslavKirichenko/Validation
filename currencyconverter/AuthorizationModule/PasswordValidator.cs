using System;
namespace currencyconverter.AuthorizationModule
{
    public class PasswordValidator: IValidator
    {
        bool IValidator.Validate(string pass)
        {
            return !string.IsNullOrEmpty(pass); ;
        }
    }
}
