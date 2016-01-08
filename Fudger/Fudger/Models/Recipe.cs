using System.Collections.Generic;
using System;
using SQLite;

namespace Fudger.Models
{
	[Table("Recipes")]
    public class Recipe : Entity
    {
        public string Name { get; set; }

		public Int32 MinutesForCooking { get; set; }

		[Ignore]
        public virtual List<Int32> IngredientIds { get; set; }

		[Ignore]
        public virtual List<Int32> RecipeStepIds { get; set; }
    }
}