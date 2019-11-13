using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;

namespace IdentitySample.Models
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole,string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext> 
    {
        protected override void Seed(ApplicationDbContext context) {
            InitializeIdentityForEF(context);

            ////Step 1 Create the user.
            //var passwordHasher = new PasswordHasher();
            ////var user = new IdentityUser("Administrator");
            //var user = new ApplicationUser();
            //user.PasswordHash = passwordHasher.HashPassword("Admin12345");
            //user.SecurityStamp = Guid.NewGuid().ToString();

            ////Step 2 Create and add the new Role.
            //var roleToChoose = new IdentityRole("BlogOwner");
            //context.Roles.Add(roleToChoose);

            ////Step 3 Create a role for a user
            //var role = new IdentityUserRole();
            //role.RoleId = roleToChoose.Id;
            //role.UserId = user.Id;

            ////Step 4 Add the role row and add the user to DB)
            //user.Roles.Add(role);

            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db) {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name = "admin@example.com";
            const string password = "123456aA@";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null) {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null) {
                user = new ApplicationUser { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name)) {
                var result = userManager.AddToRole(user.Id, role.Name);
            }


            //create 3 role
            const string userRoleName = "User";
            const string contributorRoleName = "Contributor";
            const string blogOnwerRoleName = "BlogOnwer";

            //Create Role Admin if it does not exist
            var userRole = roleManager.FindByName(userRoleName);
            if (userRole == null)
            {
                userRole = new IdentityRole(userRoleName);
                var roleresult = roleManager.Create(userRole);
            }
            var contributorRole = roleManager.FindByName(contributorRoleName);
            if (contributorRole == null)
            {
                contributorRole = new IdentityRole(contributorRoleName);
                var roleresult = roleManager.Create(contributorRole);
            }
            var blogOnwerRole = roleManager.FindByName(blogOnwerRoleName);
            if (blogOnwerRole == null)
            {
                blogOnwerRole = new IdentityRole(blogOnwerRoleName);
                var roleresult = roleManager.Create(blogOnwerRole);
            }


            for (int i = 1; i < 4; i++)
            {
                string userName = $"user{i}@gmail.com";

                var userUser = userManager.FindByName(userName);
                if (userUser == null)
                {
                    userUser = new ApplicationUser { UserName = userName, Email = userName };
                    var result = userManager.Create(userUser, password);
                    result = userManager.SetLockoutEnabled(userUser.Id, false);
                }

                // Add user admin to Role Admin if not already added
                var userRolesForUser = userManager.GetRoles(userUser.Id);
                if (!userRolesForUser.Contains(userRole.Name))
                {
                    var result = userManager.AddToRole(userUser.Id, userRole.Name);
                }
            }



            //----------------------- create account Contributor
            for (int i = 1; i < 4; i++)
            {
                string contributorName = $"contributor{i}@gmail.com";

                var contributorUser = userManager.FindByName(contributorName);
                if (contributorUser == null)
                {
                    contributorUser = new ApplicationUser { UserName = contributorName, Email = contributorName };
                    var result = userManager.Create(contributorUser, password);
                    result = userManager.SetLockoutEnabled(contributorUser.Id, false);
                }

                // Add user admin to Role Admin if not already added
                var contributorRolesForUser = userManager.GetRoles(contributorUser.Id);
                if (!contributorRolesForUser.Contains(contributorRole.Name))
                {
                    var result = userManager.AddToRole(contributorUser.Id, contributorRole.Name);
                }
            }


            //----------------------- create account Blog Owner
            for (int i = 1; i < 4; i++)
            {
                string blogOnwerName = $"blogonwer{i}@gmail.com";

                var blogOnwerUser = userManager.FindByName(blogOnwerName);
                if (blogOnwerUser == null)
                {
                    blogOnwerUser = new ApplicationUser { UserName = blogOnwerName, Email = blogOnwerName };
                    var result = userManager.Create(blogOnwerUser, password);
                    result = userManager.SetLockoutEnabled(blogOnwerUser.Id, false);
                }

                // Add user admin to Role Admin if not already added
                var blogOnwerRolesForUser = userManager.GetRoles(blogOnwerUser.Id);
                if (!blogOnwerRolesForUser.Contains(blogOnwerRole.Name))
                {
                    var result = userManager.AddToRole(blogOnwerUser.Id, blogOnwerRole.Name);
                }
            }
            
        }
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) : 
            base(userManager, authenticationManager) { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}