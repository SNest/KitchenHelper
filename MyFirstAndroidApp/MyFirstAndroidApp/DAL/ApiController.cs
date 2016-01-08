
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fudger.Models;
using RestSharp;

namespace Fudger.DAL
{
	public class ApiController
	{
		
		public ApiController () 
		{
			
		}

		public Boolean PutToFridge(Recipe res)
		{
			var client = new RestClient ("http://fudger.azurewebsites.net");

			var request = new RestRequest("/api/PutFridge", Method.POST);
			SQLiteRepository slr = new SQLiteRepository ();

			String token = slr.GetToken ().AppToken;
			request.AddUrlSegment("appToken", token);
			request.AddObject(res);


			IRestResponse<UserGroup> response2 = client.Execute<UserGroup>(request);
			if (response2.StatusCode != System.Net.HttpStatusCode.OK) {
				return false;
			}

			//write down user`s credentials in dB
			return true;

		}

		public void UpdateShoppingList(ShoppingList sl)
		{
			
		}

		//public ShoppingList GetShoppingList(String token)
		//{
			
		//}



	}

}

