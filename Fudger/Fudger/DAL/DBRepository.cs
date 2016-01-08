using System;
using Mono.Data.Sqlite;
using System.IO;
using Fudger.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace ToolbarOverlay_Tutorial
{
	public class DBRepository
	{
		public String dbPath { get; set; }
		public SQLiteConnection sqlConnection { get; set; }

		public DBRepository ()
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
				return "Tables Created";
			}
			catch(Exception ex) 
			{
				return "Error: " + ex.Message;
			}

		}

		public void AddProduct (String s)
		{
			sqlConnection.Insert (new Product{ Name = s });				
		}

		public IEnumerable<Product> GetAllProducts()
		{
			return sqlConnection.Table<Product>().ToList();
		}

		//public Product GetProductById ()
		//{
			
		//}
	}
}

