using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace IdentitySample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; }
        public string AboutMe { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name = JustBlogIdentity", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<FA.JustBlog.Core.Models.Post> Posts { get; set; }

        //public System.Data.Entity.DbSet<FA.JustBlog.Core.Models.Category> Categories { get; set; }
    }



    public class DbInitialize : ApplicationDbInitializer
    {
        //protected override void Seed(ApplicationDbContext context)
        //{

        //    base.Seed(context);
        //}
        //protected override void Seed(ApplicationDbContext context)
        //{
        //    //Step 1 Create the user.
        //    var passwordHasher = new PasswordHasher();
        //    //var user = new IdentityUser("Administrator");
        //    var user = new ApplicationUser();
        //    user.PasswordHash = passwordHasher.HashPassword("Admin12345");
        //    user.SecurityStamp = Guid.NewGuid().ToString();

        //    //Step 2 Create and add the new Role.
        //    var roleToChoose = new IdentityRole("Admin");
        //    context.Roles.Add(roleToChoose);

        //    //Step 3 Create a role for a user
        //    var role = new IdentityUserRole();
        //    role.RoleId = roleToChoose.Id;
        //    role.UserId = user.Id;

        //    //Step 4 Add the role row and add the user to DB)
        //    user.Roles.Add(role);
        //    context.Users.Add(user);
        //}

    }
}
