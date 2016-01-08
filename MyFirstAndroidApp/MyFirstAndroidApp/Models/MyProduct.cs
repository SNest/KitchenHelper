using System;

namespace Fudger.Models
{
	public enum ProductType
	{
		Grains, //зерновые
		Nuts, 
		Herbs, 
		Berries, 
		Juices, 
		Meat, 
		Fish, 
		Eggs, 
		Milk, 
		Mushrooms, 
		Yeast, //дрожжи
		Inorganic
	}

	public class MyProduct
	{
		private ProductType type;

		public Int32 Id { get; set; }

		public String Name { get; set; }

		public String Type {
			get
			{
				return type.ToString ();  
			}
			set
			{
				//type = Enum.Parse(typeof(ProductType), value);
			}
		}


		#region Constructors
		public MyProduct (String pName, String pType)
		{
			this.Name = pName;
			this.Type = pType;
		}
		#endregion
	}
}

