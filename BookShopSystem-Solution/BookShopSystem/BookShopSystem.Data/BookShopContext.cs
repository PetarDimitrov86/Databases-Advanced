namespace BookShopSystem.Data
{
    using System.Data.Entity;
    using BookShopSytem.Models;

    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BookShopContext>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(book => book.RelatedBooks)
                .WithMany()
                .Map(configuration =>
                {
                    configuration.MapLeftKey("BookId");
                    configuration.MapRightKey("RelatedBookId");
                    configuration.ToTable("BooksRelatedBooks");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}