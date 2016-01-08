
using System.Collections.Generic;
using SQLite;
using System;

namespace Fudger.Models
{
	[Table("Products")]
    public class Product : Entity
    {
        public String Name { get; set; }

		//[Ignore]
        //public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}