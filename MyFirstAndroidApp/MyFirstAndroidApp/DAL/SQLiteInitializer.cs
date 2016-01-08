using System;
using Android.Widget;
using System.Collections.Generic;
using Fudger.Models;
using System.Linq;

namespace Fudger.DAL
{
	public class SQLiteInitializer
	{
        SQLiteRepository slr;
		public SQLiteInitializer ()
		{
			slr = new SQLiteRepository ();
			//String res = slr.Seed ();
			//Toast.MakeText (this, res, ToastLength.Long).Show ();

			//slr.AddProduct ("Melone");
			//slr.AddProduct ("Apple");
			//slr.AddProduct ("Banana");
			//slr.AddProduct ("Strawberry");

			//slr.AddRecipe ("Fruit salad", 15);

			//slr.AddIngredient (1, 1, "200 g");
			//slr.AddIngredient (2, 1, "300 g");
			//slr.AddIngredient (3, 1, "150 g");
			//slr.AddIngredient (4, 1, "200 g");

			//slr.AddRecipeStep ("Slice fruits.", 1);
			//slr.AddRecipeStep ("Mix sliced fruits.", 1);

            //IEnumerable<Product> lp = slr.GetAllProducts ();
            //IEnumerable<Ingredient> li = slr.GetAllIngredients ();
            //IEnumerable<Recipe> lr = slr.GetAllRecipes ();
            //IEnumerable<RecipeStep> lrs = slr.GetAllRecipeSteps ();



			//Toast.MakeText (this, lp.ToList().Count.ToString(), ToastLength.Long).Show ();


		}

        public void DeleteAllIngredient()
		{
			slr.sqlConnection.DeleteAll<Ingredient>();
            slr.sqlConnection.Commit();

			slr.Seed ();
		}

        public void DeleteAllProduct()
        {
           
            slr.sqlConnection.DeleteAll<Product>();
            slr.sqlConnection.Commit();

            slr.Seed();
        }

        public void DeleteAllRecipe()
        {

            slr.sqlConnection.DeleteAll<Recipe>();
            slr.sqlConnection.Commit();

            slr.Seed();
        }

        public void DeleteAllRecipeStep()
        {

            slr.sqlConnection.DeleteAll<RecipeStep>();
            slr.sqlConnection.Commit();

            slr.Seed();
        }

        public void MakeTrialQuery (String q)
        {
            slr.sqlConnection.Execute(q);
			slr.sqlConnection.Commit ();
        }


	}
}

