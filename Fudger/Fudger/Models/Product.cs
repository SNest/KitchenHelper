using System.Collections.Generic;
using SQLite;
using System;

namespace Fudger.Models
{
	[Table("Products")]
    public class Product : Entity
    {
        public string Name { get; set; }
    }
}