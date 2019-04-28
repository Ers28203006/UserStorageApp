namespace UserStoradge.DataAccess
{
    using System.Data.Entity;
    using UserStoradge.Models;

    public class UserRepoContext : DbContext
    {
        public UserRepoContext()
            : base("name=UserRepoContext")
        {
            Database.SetInitializer(new DataInitializer());
        }

       public DbSet<User> Users { get; set; }
    }
}