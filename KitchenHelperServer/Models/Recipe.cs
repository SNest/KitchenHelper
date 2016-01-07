using System.Collections.Generic;

namespace KitchenHelperServer.Models
{
    public class Recipe : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public virtual ICollection<RecipeStep> RecipeSteps { get; set; }
    }
}