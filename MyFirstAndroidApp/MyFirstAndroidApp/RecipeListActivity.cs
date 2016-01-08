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
using Android.Support.V7.App;
using Fudger.DAL;
using Android.Support.V4.View;

namespace MyFirstAndroidApp
{
	[Activity(Label = "RecipeListActivity",
		Theme = "@style/Theme.AppCompat.Light")]
    public class RecipeListActivity : ActionBarActivity 
    {
        private SearchView _searchView;
        private ListView _listView;
        private ArrayAdapter _adapter;

        private List<string> mItems;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RecipeList);

            _listView = FindViewById<ListView>(Resource.Id.lvRecipes);
             
            SQLiteRepository slr = new SQLiteRepository();

            mItems = slr.GetAllRecipes().Select(r => r.Name).ToList();

            _adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems);
            _listView.Adapter = _adapter;


            _searchView = FindViewById<SearchView>(Resource.Id.action_search);

            _searchView.QueryTextChange += (s, e) => _adapter.Filter.InvokeFilter(e.NewText);

            _searchView.QueryTextSubmit += (s, e) =>
            {
                Toast.MakeText(this, "Searched for: " + e.Query, ToastLength.Short).Show();
                e.Handled = true;
            };

            _listView.ItemClick += (s, e) =>
			{
                var activity2 = new Intent(this, typeof(RecipeActivity));
				String itm = _listView.GetItemAtPosition(e.Position).ToString();
                activity2.PutExtra("name", itm);
                StartActivity(activity2);
            };

        }      
    }
}
