namespace KitchenHelperServer.Models
{
    public class UserGroup : Entity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string AppToken { get; set; }
    }
}