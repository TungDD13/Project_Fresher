using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FA.JustBlog.Models
{
    public class UserViewModel
    {
        public UserViewModel(ApplicationUser user, ApplicationRoleManager roleManager)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var item in user.Roles)
            {
                string tmp = roleManager.FindByIdAsync(item.RoleId).Result.Name;
                stringBuilder.Append(tmp + ", ");
            }
            RoleValues = stringBuilder.ToString().Remove(stringBuilder.Length - 2);
        }
        public string Id { get; set; }
        public string UserName { get; set; }

        public string RoleValues { get; set; }
    }
}