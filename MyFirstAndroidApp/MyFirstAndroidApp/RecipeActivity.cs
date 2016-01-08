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

            // Create your application here
            name = FindViewById<TextView>(Resource.Id.tvRecipeName);
            ingredients = FindViewById<TextView>(Resource.Id.tvIngrs);
            cookProc = FindViewById<TextView>(Resource.Id.tvHowToCook);

            SQLiteRepository qlr = new SQLiteRepository();
            Recipe res = qlr.GetRecipeByName(Intent.GetStringExtra("name"));       //activity2.PutExtra ("MyData", "Data from Activity1");



        }
    }
}