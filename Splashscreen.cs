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
using System.Threading;
using zee.DataAccess;

namespace zee
{
    [Activity(Label = "zee", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon")]
    public class Splashscreen : Activity
    {
        private LoginEntityRepository _database = new LoginEntityRepository();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _database.AddUser("Zee", "zee");
            

            //Display Splash Screen for 4 Sec  
            Thread.Sleep(4000);
            StartActivity(typeof(MainActivity));
        }
    }
}