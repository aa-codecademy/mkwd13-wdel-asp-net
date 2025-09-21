namespace Lamazon.Domain.Entities
{
    public class Role
    {
        public string Key { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
        }
    }
}
