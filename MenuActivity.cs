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

namespace zee
{
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {
        private LoginEntityRepository _database = new LoginEntityRepository();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

           var xx =  _database.GetUser(1);
            
            Toast.MakeText(this, "Welcome " +xx.Name, ToastLength.Long).Show();
        }
    }
}