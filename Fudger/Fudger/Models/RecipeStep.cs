using SQLite;
using System;

namespace Fudger.Models
{
	[Table("RecipeSteps")]
	public class RecipeStep : Entity
    {
        public string Description { get; set; }

        public Int32 RecipeId { get; set; }

        public virtual Int32 Recipe { get; set; }
    }
}