using System;
using SQLite;

namespace Fudger.Models
{
	[Table("Ingredients")]
    public class Ingredient : Entity
    {
        public Int32 RecipeId { get; set; }

        public Int32 ProductId { get; set; }

		//public int Quantity { get; set; }
		public string Quantity { get; set; }

        //public string Measure { get; set; }

		[Ignore]
        public Product Product { get; set; }

		[Ignore]
        public Recipe Recipe { get; set; }

        
    }
}