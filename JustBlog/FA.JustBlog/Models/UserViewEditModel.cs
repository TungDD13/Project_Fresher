using IdentitySample.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Models
{
    public class UserViewEditModel
    {
        public UserViewEditModel(ApplicationUser user, ApplicationRoleManager roleManager)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            foreach (var item in user.Roles)
            {
                var role = roleManager.FindByIdAsync(item.RoleId).Result;
                ListRole.Add(role);
            }
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public List<IdentityRole> ListRole { get; set; }
    }
}