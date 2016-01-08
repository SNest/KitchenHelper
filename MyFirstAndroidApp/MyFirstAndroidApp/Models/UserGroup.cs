using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Fudger.Models
{
    class UserGroup : Entity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string AppToken { get; set; }

        public int FridgeId { get; set; }

        public int ProductStorageId { get; set; }

        public int ShoppingListId { get; set; }
    }
}