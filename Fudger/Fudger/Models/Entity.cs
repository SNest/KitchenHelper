using System;
using Mono.Data.Sqlite;
using System.IO;
using System.Data;
using SQLite;

namespace Fudger.Models
{
    public class Entity
    {
		[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}