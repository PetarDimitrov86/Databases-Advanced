namespace _02_User
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
        }
        
        public virtual IDbSet<User> Users { get; set; }
    }
}