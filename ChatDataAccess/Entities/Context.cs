using System.Collections.Generic;
using System.Data.Entity;

namespace ChatDataAccess.Entities
{
    public class Context : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        static Context()
        {
            Database.SetInitializer<Context>(new MyDatabaseContextInitializer());
        }

        public Context(string connectionString) : base(connectionString)
        {
        }
    }

    internal class MyDatabaseContextInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            context.Users.AddRange(new List<User> {
                new User {Login="admin", Password = "admin"},
                new User {Login="user", Password = "user"}
            });
        }
    }
}
