using System.Collections.Generic;
using System.Data.Entity;
using UserStoradge.Models;

namespace UserStoradge.DataAccess
{
    public class DataInitializer : CreateDatabaseIfNotExists<UserRepoContext>
    {
        protected override void Seed(UserRepoContext context)
        {
            context.Users.AddRange
            (
                new List<User>
                {
                    new User
                    {
                        Login="admin",
                        Password="123456",
                        Address="Astana c., A-98 st., 9 h., 3 fl.",
                        Phone="+77013819614",
                        IsAdmin=true
                    },

                    new User
                    {
                        Login="nurik",
                        Password="123456",
                        Address="Astana c., A-96 st., 10 h., 10 fl.",
                        Phone="+77773819620",
                        IsAdmin=false
                    },

                    new User
                    {
                        Login="zhuzik",
                        Password="123456",
                        Address="Astana c., A-99 st., 20 h., 11fl.",
                        Phone="+77474589620",
                        IsAdmin=false
                    },
                    new User
                    {
                        Login="ers",
                        Password="123456",
                        Address="Astana c., A-98 st., 14 h., 12fl.",
                        Phone="+77474789620",
                        IsAdmin=true
                    },
                    new User
                    {
                        Login="zharik",
                        Password="123456",
                        Address="Astana c., A-88 st., 12 h., 9fl.",
                        Phone="+77028524720",
                        IsAdmin=false
                    }
                }
            );
        }
    }
}