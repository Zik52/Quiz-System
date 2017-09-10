using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using zee.DataAccess;
using System.Security.Cryptography;
using Android.Content.Res;

namespace zee
{
    [Activity(Label = "SignupActivity")]
    public class SignupActivity : Activity
    {
        private LoginEntityRepository _database = new LoginEntityRepository();
     
        private EditText confirmPasswordEditText;
        private EditText passwordEditText;
        private EditText usernameEditText;
        private Button signupButton;
        private string pwd,cpwd, uname;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Signup);
            FindViews();
            HandleEvents();
        }

        private void HandleEvents()
        {
            signupButton.Click += SignupButton_Click;
        }

        private void SignupButton_Click(object sender, EventArgs e)
        {   
            pwd = passwordEditText.Text;
            cpwd = confirmPasswordEditText.Text;
            uname = usernameEditText.Text;
            if (pwd != cpwd)
            {
                Toast.MakeText(this, "Password does not match", ToastLength.Long).Show();
            }
            else
            {
                ;
                _database.AddUser(uname, Utility.GetHashString(pwd));
                Toast.MakeText(this, "User Created", ToastLength.Long).Show();
                StartActivity(typeof(MainActivity));
            }
        }

        private void FindViews()
        {
            passwordEditText = FindViewById<EditText>(Resource.Id.NewPasswordTxt);
            confirmPasswordEditText = FindViewById<EditText>(Resource.Id.ConfirmPasswordTxt);
            usernameEditText = FindViewById<EditText>(Resource.Id.NewUsernameTxt);

            signupButton = FindViewById<Button>(Resource.Id.SignupBtn);
        }

    
    }
}