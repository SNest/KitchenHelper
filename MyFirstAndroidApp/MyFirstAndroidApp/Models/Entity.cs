using SQLite;
using System;

namespace Fudger.Models
{
    public class Entity
    {
		[PrimaryKey, AutoIncrement]
        public Int32 Id { get; set; }
    }
}