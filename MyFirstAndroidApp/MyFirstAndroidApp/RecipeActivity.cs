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

namespace MyFirstAndroidApp
{
    [Activity(Label = "RecipeActivity")]
    public class RecipeActivity : Activity
    {
        TextView name;
        TextView ingredients;
        TextView cookProc;

		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			SetContentView (Resource.Layout.Recipe);

            // Create your application here
            name = FindViewById<TextView>(Resource.Id.tvRecipeName);
            ingredients = FindViewById<TextView>(Resource.Id.tvIngrs);
            cookProc = FindViewById<TextView>(Resource.Id.tvHowToCook);

            SQLiteRepository qlr = new SQLiteRepository();
            Recipe res = qlr.GetRecipeByName(Intent.GetStringExtra("name"));       //activity2.PutExtra ("MyData", "Data from Activity1");

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
    }
}