// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace currencyconverter.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }


        [Outlet]
        UIKit.UITextField login_textField { get; set; }


        [Outlet]
        UIKit.UITextField password_textField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton logButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField loginField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField passwordField { get; set; }

        [Action ("loginButton:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void loginButton (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (logButton != null) {
                logButton.Dispose ();
                logButton = null;
            }

            if (login_textField != null) {
                login_textField.Dispose ();
                login_textField = null;
            }

            if (loginField != null) {
                loginField.Dispose ();
                loginField = null;
            }

            if (password_textField != null) {
                password_textField.Dispose ();
                password_textField = null;
            }

            if (passwordField != null) {
                passwordField.Dispose ();
                passwordField = null;
            }
        }
    }
}