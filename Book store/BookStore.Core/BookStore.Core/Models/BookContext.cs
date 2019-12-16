using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FA.BookStore.Core.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
    : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory + "/../../../")
            .AddJsonFile("appsettings.json")
            .Build();

            //  IConfigurationBuilder builder = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettings.json");

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BookStoreDbContext"));
            //optionsBuilder.useLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
            //Configuration.GetConnectionString("CoinToolDbContext");
            //optionsBuilder.UseSqlServer(@"Server=ADMIN;Database=BookStoreDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Category cate1 = new Category() { CateId = 1, CateName = "Anime", Description = "this is a Description 1" };
            Category cate2 = new Category() { CateId = 2, CateName = "Viet Nam", Description = "this is a Description 2" };
            Category cate3 = new Category() { CateId = 3, CateName = "Dan Gian", Description = "this is a Description 3" };
            modelBuilder.Entity<Category>().HasData(cate1, cate2, cate3);

            Publisher pub1 = new Publisher() { PubId = 1, PubName = "Doan Tung", Description = "he is a publisher" };
            Publisher pub2 = new Publisher() { PubId = 2, PubName = "Doan Tung 2", Description = "he is a publisher 2" };
            modelBuilder.Entity<Publisher>().HasData(pub1, pub2);

            Book book1 = new Book()
            {
                BookId = 1,
                Title = "Title 1",
                CateId = 1,
                //AuthorId = 1,
                PubId = 1,
                Summary = "Summary 1",
                //ImgUrl = "Image 1",
                Price = 100,
                Quantity = 50,
                CreateDate = new DateTime(2019, 01, 01),
                ModifieDate = new DateTime(2019, 02, 02),
                IsActive = true,
            };
            modelBuilder.Entity<Book>().HasData(book1);

            Comment comment1 = new Comment() { CommentId = 1, BookId = 1, Content = "this is perfect", CreateDate = new DateTime(2019, 02, 03), IsActive = true };
            Comment comment2 = new Comment() { CommentId = 2, BookId = 1, Content = "this is good", CreateDate = new DateTime(2019, 05, 03), IsActive = false };
            modelBuilder.Entity<Comment>().HasData(comment1, comment2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
