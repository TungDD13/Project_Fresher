using FA.BookStore.Core.Models;
using FABookStore.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer
{
    public class BookStoreContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext() : base("name = BookStoreDbContext")
        {
            //Database.SetInitializer<BookStoreContext>(new BookInitializer());
        }

        public static BookStoreContext Create()
        {
            
            return new BookStoreContext();
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Comment> Comments { get; set; }

        static BookStoreContext()
        {
            // Set the database initializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<BookStoreContext>(new BookInitializer());
        }

    }
}
