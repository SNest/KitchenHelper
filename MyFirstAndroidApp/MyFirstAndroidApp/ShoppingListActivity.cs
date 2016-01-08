
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
using Fudger.Models;
using Fudger.DAL;
using RestSharp;

namespace MyFirstAndroidApp
{
	[Activity (Label = "ShoppingListActivity")]			
	public class ShoppingListActivity : Activity
	{

		ListView lvShoppingItems;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView(Resource.Layout.ShoppingList);


			lvShoppingItems = FindViewById<ListView>(Resource.Id.lvShoppingItems);

			List<Product> items = this.GetShoppingProducts ();
			ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items.Select(t => t.Name).ToList());
			lvShoppingItems.Adapter = adapter;


			lvShoppingItems.ItemClick += (s, e) =>
			{
				Product p = new SQLiteRepository().GetProductByName(lvShoppingItems.GetItemAtPosition(e.Position).ToString());

				BuyShoppingProduct(p);

				items.Remove(p);
			};
			// Create your application here
		}

		private List<Product> GetShoppingProducts()
		{
			List<Product> res = new List<Product> ();

			return res;
		}

		private Boolean BuyShoppingProduct(Product p)
		{

			var client = new RestClient ("http://fudger.azurewebsites.net");

			var request = new RestRequest("/api/PostProductStorage", Method.POST);
			SQLiteRepository slr = new SQLiteRepository ();

			String token = slr.GetToken ().AppToken;
			request.AddUrlSegment("appToken", token);
			request.AddObject(p);


			IRestResponse<UserGroup> response2 = client.Execute<UserGroup>(request);
			if (response2.StatusCode != System.Net.HttpStatusCode.OK) {
				return false;
			}

			//write down user`s credentials in dB
			return true;


		}
	}
}

