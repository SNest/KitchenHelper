using System;
using System.IO;
using Mono.Data.Sqlite;
using SQLite;
using Fudger.Models;
using System.Collections.Generic;
using System.Linq;


namespace Fudger.DAL
{
	public class SQLiteRepository
	{
		public String dbPath { get; set; }
		public SQLiteConnection sqlConnection { get; set; }

		public SQLiteRepository ()
		{
			dbPath = Path.Combine (Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyDB.db3");
			sqlConnection = new SQLiteConnection (dbPath);
		}
			

		public String Seed()
		{
			try
			{
				sqlConnection.CreateTable<Ingredient>();
				sqlConnection.CreateTable<Product>();
				sqlConnection.CreateTable<RecipeStep>();
				sqlConnection.CreateTable<Recipe>();
				sqlConnection.CreateTable<UserGroup>();
				return "Tables Created";
			}
			catch(Exception ex) 
			{
				return "Error: " + ex.Message;
			}

		}

		#region Adders
		public void AddProduct (String s)
		{
			sqlConnection.Insert (new Product{ Name = s });				
		}

		public void AddIngredient (Int32 pId, Int32 rId, String q)//, String mes)
		{
			sqlConnection.Insert (new Ingredient{ ProductId = pId, RecipeId = rId, Quantity = q });//, 
				//Measure = mes });				
		}

		public void AddRecipeStep (String d, Int32 rId)
		{
			sqlConnection.Insert (new RecipeStep{ Description = d, RecipeId = rId});				
		}

		public void AddRecipe (String n, Int32 mForCooking )
		{
			
			sqlConnection.Insert (new Recipe{ Name = n, MinutesForCooking = mForCooking });				
		}

		public void SaveToken(UserGroup ug)
		{
			sqlConnection.DeleteAll<UserGroup>();
			sqlConnection.Insert (ug);
		}

		public UserGroup GetToken()
		{
			return sqlConnection.Table<UserGroup> ().FirstOrDefault ();
		}

		#endregion
	
		#region Getters(All)
		public IEnumerable<Product> GetAllProducts()
		{
			List<Product> res = sqlConnection.Table<Product>().ToList();
			res.ForEach (r => {
				
			});
			return res;
		}

		public IEnumerable<Ingredient> GetAllIngredients()
		{
			List<Ingredient> res = sqlConnection.Table<Ingredient>().ToList();
			res.ForEach (r => {
				r.Product = this.GetProductById(r.ProductId);
				r.Recipe = this.GetRecipeById(r.RecipeId);
			});
			return res;
		}

		public IEnumerable<RecipeStep> GetAllRecipeSteps()
		{
			List<RecipeStep> res = sqlConnection.Table<RecipeStep>().ToList();
			res.ForEach (r => {
				r.Recipe = this.GetRecipeById(r.RecipeId);
			});
			return sqlConnection.Table<RecipeStep>().ToList();
		}

		public IEnumerable<Recipe> GetAllRecipes()
		{
			List<Recipe> res = sqlConnection.Table<Recipe>().ToList();
			res.ForEach (r => {
				r.Ingredients = this.GetAllIngredientsForRecipe(r.Id);
				r.RecipeSteps = this.GetAllRecipeStepsForRecipe(r.Id);
			});
			return sqlConnection.Table<Recipe>().ToList();
		}


		//public Product GetProductById ()
		//{

		//}
		#endregion

		#region Getters(ById)

		public Product GetProductById(Int32 id)
		{
			return sqlConnection.Table<Product>().FirstOrDefault(p => p.Id == id);
		}

		public IEnumerable<Ingredient> GetAllIngredientsForRecipe(Int32 rId)
		{
			return sqlConnection.Table<Ingredient>().Where(i => i.RecipeId == rId).ToList();
		}

		public IEnumerable<RecipeStep> GetAllRecipeStepsForRecipe(Int32 rId)
		{
			return sqlConnection.Table<RecipeStep>().Where(rs => rs.RecipeId == rId).ToList();
		}

		public Recipe GetRecipeById(Int32 id)
		{
			return sqlConnection.Table<Recipe>().FirstOrDefault(r => r.Id == id);
		}

		#endregion

        #region Getters(Other)
        public Recipe GetRecipeByName(String name)
        {
			Recipe res = sqlConnection.Table<Recipe>().FirstOrDefault(p => p.Name == name);

				res.Ingredients = this.GetAllIngredientsForRecipe(res.Id);
				foreach (Ingredient item in res.Ingredients) 
				{
					item.Product = this.GetProductById (item.ProductId);
				}		
				res.RecipeSteps = this.GetAllRecipeStepsForRecipe(res.Id);

			return res;

        }

		public Product GetProductByName(String name)
		{
			return sqlConnection.Table<Product>().FirstOrDefault(p => p.Name == name);
		}
        #endregion
    }
}

