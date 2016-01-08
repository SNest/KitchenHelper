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
using RestSharp;
using Fudger.Models;

namespace MyFirstAndroidApp
{
	[Activity(Label = "LoginActivity",  MainLauncher = true)]
    public class LoginActivity : Activity
    {
        Button btnLogIn;
        EditText etLogin;
        EditText etPasswd;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);

            btnLogIn = FindViewById<Button>(Resource.Id.btnLogIn);
            etLogin = FindViewById<EditText>(Resource.Id.etLogin);
            etPasswd = FindViewById<EditText>(Resource.Id.etPasswd);

            btnLogIn.Click += (s, e) =>
            {
                if (etLogin.Text == String.Empty || etPasswd.Text == String.Empty)
                {
                    Toast.MakeText(this, "Login and password fields should be filled.", ToastLength.Long).Show();
                }
                else
                {
                    if (SendLoginRequest(etLogin.Text, etPasswd.Text))
                    {
                        StartActivity(typeof(MainActivity));
                    }
                    else
                    {
                        Toast.MakeText(this, "Login and password are wrong.", ToastLength.Long).Show();
                    }
                }
            };
            // Create your application here
        }

        private Boolean SendLoginRequest(String log, String pass)
        {

			var client = new RestClient ("http://fudger.azurewebsites.net");

			var request = new RestRequest("/api/UserGroups", Method.POST);
			request.AddObject(new UserGroup(){Name = log, Password = pass});

           

			IRestResponse<UserGroup> response2 = client.Execute<UserGroup>(request);
			if (response2.StatusCode != System.Net.HttpStatusCode.OK) {
				return false;
			}

			//write down user`s credentials in dB
			return true;

        }
    }
}