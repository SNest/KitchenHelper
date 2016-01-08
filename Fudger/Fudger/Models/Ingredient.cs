using SQLite;
using System;

namespace Fudger.Models
{
	[Table("Ingredients")]
    public class Ingredient : Entity
    {
        public Int32 RecipeId { get; set; }

        public Int32 ProductId { get; set; }

        public Int32 Quantity { get; set; }

		public String Measure { get; set; }
    }
}