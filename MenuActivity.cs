using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using zee.DataAccess;
using System.Threading.Tasks;

namespace zee
{
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {

        private LoginEntityRepository _database = new LoginEntityRepository();
        protected override void OnCreate(Bundle savedInstanceState)


        {
			base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Menu);


		// Get the latitude/longitude EditBox and button resources:

		EditText quiz01 = FindViewById<EditText>(Resource.Id.qText);
            EditText quiz02 = FindViewById<EditText>(Resource.Id.quText);
            Button button = FindViewById<Button>(Resource.Id.getDataButton);

            // When the user clicks the button ...
            button.Click += async (sender, e) =>
            {

                // Get the latitude and longitude entered by the user and create a query.
                string url = "http://http://introtoapps.com/quizzes_sample.json/findNearByDataJSON?q=" +
                             quiz01.Text +
                             "&qu=" +
                             quiz02.Text +
                             "&username=json";

                // Fetch the weather information asynchronously, 
                // parse the results, then update the screen:
                JsonValue json = await FetchDataAsync(url);
                // ParseAndDisplay (json);
            };

		
            {
              

                // Create your application here

                var xx = _database.GetUser(1);

                Toast.MakeText(this, "Welcome " + xx.Name, ToastLength.Long).Show();
            }

			///Gets weather data from the passed URL.

    async Task<JsonValue> FetchDataAsync(string url)
			{
				// Create an HTTP web request using the URL:
				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
				request.ContentType = "application/json";
				request.Method = "GET";

				// Send the request to the server and wait for the response:
				using (WebResponse response = await request.GetResponseAsync())
				{
					// Get a stream representation of the HTTP web response:
					using (InputStreamInvoker stream = (Android.Runtime.InputStreamInvoker)response.GetResponseStream())
					{
						// Use this stream to build a JSON document object:
						JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
						Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

						// Return the JSON document:
						return jsonDoc;
					}
				}
			}
        }

        private Task<JsonValue> FetchDataAsync(string url)
        {
            throw new NotImplementedException();
        }
    }

    internal class JsonObject
    {
        internal static JsonValue Load(InputStreamInvoker stream)
        {
            throw new NotImplementedException();
        }
    }

    internal class JsonValue
    {
    }
}