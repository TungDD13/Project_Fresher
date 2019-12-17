using FA.BookStore.Core.Models;
using FABookStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer
{
    public class BookInitializer: DropCreateDatabaseAlways<BookStoreContext>
    {
        protected override void Seed(BookStoreContext context)
        {
            Category cate1 = new Category() { CateName = "Anime", CreateDate = new DateTime(2019, 01, 01), ModifieDate = new DateTime(2019, 02, 02), Description = "this is a Description 1" };
            Category cate2 = new Category() { CateName = "Viet Nam", CreateDate = new DateTime(2019, 01, 01), ModifieDate = new DateTime(2019, 02, 02), Description = "this is a Description 2" };
            Category cate3 = new Category() { CateName = "Dan Gian", CreateDate = new DateTime(2019, 01, 01), ModifieDate = new DateTime(2019, 02, 02), Description = "this is a Description 3" };
            //context.Categories.Add(cate1);
            //context.Categories.Add(cate2);
            //context.Categories.Add(cate3);
            context.Categories.AddOrUpdate(c => c.CateName, cate1, cate2, cate3);

            Publisher pub1 = new Publisher() { PubName = "Doan Tung", Description = "he is a publisher" };
            Publisher pub2 = new Publisher() { PubName = "Doan Tung 2", Description = "he is a publisher 2" };
            //context.Publishers.Add(pub1);
            //context.Publishers.Add(pub2);
            context.Publishers.AddOrUpdate(p => p.PubName, pub1, pub2);

            Book book1 = new Book()
            {
                Title = "Title 1",
                Categorys = cate1,
                //AuthorId = 1,
                Publishers = pub1,
                Summary = "Summary 1",
                //ImgUrl = "Image 1",
                Price = 100,
                Quantity = 50,
                CreateDate = new DateTime(2019, 01, 01),
                ModifieDate = new DateTime(2019, 02, 02),
                IsActive = true,
            };

            //context.Books.Add(book1);
            context.Books.AddOrUpdate(b => b.Title, book1);

            Comment comment1 = new Comment() { Books = book1, Content = "this is perfect", CreateDate = new DateTime(2019, 02, 03), IsActive = true };
            Comment comment2 = new Comment() { Books = book1, Content = "this is good", CreateDate = new DateTime(2019, 05, 03), IsActive = false };
            //context.Comments.Add(comment1);
            //context.Comments.Add(comment2);
            context.Comments.AddOrUpdate(c => c.Content, comment1, comment2);

            Task.Run(async () => { await SeedAsync(context); }).Wait();
            context.SaveChanges();

            base.Seed(context);
        }

        private async Task SeedAsync(BookStoreContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleResult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}
