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
using Fudger.Models;
using RestSharp;

namespace MyFirstAndroidApp
{
    [Activity(Label = "RecipeActivity")]
    public class RecipeActivity : Activity
    {
        TextView name;
        TextView ingredients;
        TextView cookProc;
        Button btnCook;

        Recipe res;

		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			SetContentView (Resource.Layout.Recipe);

            // Create your application here
            name = FindViewById<TextView>(Resource.Id.tvRecipeName);
            ingredients = FindViewById<TextView>(Resource.Id.tvIngrs);
            cookProc = FindViewById<TextView>(Resource.Id.tvHowToCook);
            btnCook = FindViewById<Button>(Resource.Id.btnCook);

            btnCook.Click += (s, e) =>
            {
                ApiController ac = new ApiController();
                ac.PutToFridge(res);        
            };

            btnCook.Clickable = this.CanRecipeBeCooked(res);

            SQLiteRepository qlr = new SQLiteRepository();
            res = qlr.GetRecipeByName(Intent.GetStringExtra("name"));       //activity2.PutExtra ("MyData", "Data from Activity1");

			name.Text = res.Name;

			String temp = String.Empty;
			foreach (Ingredient ing in res.Ingredients) 
			{
				temp += String.Format ("-{0}\t{1};\n", ing.Product.Name, ing.Quantity);
			}

			ingredients.Text = temp;


			temp = String.Empty;
			foreach (RecipeStep step in res.RecipeSteps) 
			{
				temp += String.Format ("{0}\n", step.Description);
			}
			cookProc.Text = temp;

        }

        private Boolean CanRecipeBeCooked(Recipe res)
        {

			var client = new RestClient ("http://fudger.azurewebsites.net");

			var request = new RestRequest("/api/PutFridge", Method.POST);
			SQLiteRepository slr = new SQLiteRepository ();

			String token = slr.GetToken ().AppToken;
			request.AddUrlSegment("appToken", token);
			request.AddObject(res);


			IRestResponse<List<Product>> response2 = client.Execute<List<Product>>(request);
			if (response2.StatusCode != System.Net.HttpStatusCode.OK) {
				return false;
			}
			return true;

        }
    }
}