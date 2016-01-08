using System.Collections.Generic;
using System;
using SQLite;

namespace Fudger.Models
{
	[Table("Recipes")]
    public class Recipe : Entity
    {
        public String Name { get; set; }

		public Int32 MinutesForCooking { get; set; }

		[Ignore]
        public IEnumerable<Ingredient> Ingredients { get; set; }

		[Ignore]
		public IEnumerable<RecipeStep> RecipeSteps { get; set; }
    }
}