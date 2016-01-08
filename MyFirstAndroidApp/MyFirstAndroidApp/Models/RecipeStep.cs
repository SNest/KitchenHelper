using SQLite;
using System;

namespace Fudger.Models
{
	[Table("RecipeSteps")]
    public class RecipeStep : Entity
    {
        public String Description { get; set; }

        public Int32 RecipeId { get; set; }

		[Ignore]
        public Recipe Recipe { get; set; }
    }
}