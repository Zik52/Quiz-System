using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using zee.DataAccess;

namespace zee
{
    [Activity(Label = "zee", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private LoginEntityRepository _database = new LoginEntityRepository();
        private Button loginButton;
        private Button signupButton;
        private EditText passwordEditText;
        private EditText usernameEditText;
        private string pwd;
        private string uname;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindViews();
            HandleEvents();
           
        }

        private void HandleEvents()
        {
            loginButton.Click += LoginButton_Click;
            signupButton.Click += SignupButton_Click;
        }

        private void SignupButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SignupActivity));
            StartActivity(intent);
        }

        private void FindViews()
        {
            loginButton = FindViewById<Button>(Resource.Id.Login);
            passwordEditText = FindViewById<EditText>(Resource.Id.PasswordTxt);
            usernameEditText = FindViewById<EditText>(Resource.Id.UsernameTxt);
            signupButton = FindViewById<Button>(Resource.Id.Signup);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            pwd = passwordEditText.Text;
            uname = usernameEditText.Text;

            var xxx = _database.Get().Find(x => x.Name == uname && x.Password == Utility.GetHashString(pwd));
            if (xxx != null)
            {
                var intent = new Intent(this, typeof(MenuActivity));
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "Incorrect Credentials ", ToastLength.Long).Show();
            }
           

        }
    }
}

