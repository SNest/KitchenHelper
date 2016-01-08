
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
using Fudger.DAL;

namespace MyFirstAndroidApp
{
	[Activity (Label = "ProductListActivity")]			
	public class ProductListActivity : Activity
	{
        ListView lvProducts;

        private List<string> mItems;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            SetContentView(Resource.Layout.ProductList);

			lvProducts = FindViewById<ListView>(Resource.Id.lvProducts);

            SQLiteRepository slr = new SQLiteRepository();

            mItems = slr.GetAllProducts().Select(p => p.Name).ToList();

			ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems);
            lvProducts.Adapter = adapter;


			// Create your application here
		}
	}
}

