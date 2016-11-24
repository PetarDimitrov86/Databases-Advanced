namespace ProductShop.Data
{
    using System.Data.Entity;
    using Models;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
            : base("name=ProductShopContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .Map(pc =>
                    {
                        pc.MapLeftKey("Category_Id");
                        pc.MapRightKey("Product_Id");
                        pc.ToTable("CategoryProducts");
                    }
                );

            modelBuilder.Entity<User>()
                .HasMany(user => user.Friends)
                .WithMany()
                .Map(userFriends =>
                {
                    userFriends.MapLeftKey("UserId");
                    userFriends.MapRightKey("FriendId");
                    userFriends.ToTable("UserFriends");
                });

            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }
    }
}