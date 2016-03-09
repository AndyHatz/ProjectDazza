namespace ProjectDazza.Data.Migrations
{
    using Framework.Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectDazza.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            CreateRoles(context);
            CreateAdminUser(context);
            CreateFrontUser(context);
        }

        private static void CreateAdminUser(ApplicationDbContext context) {
            CreateUserWithRole(context, "admin@dazza.com", "W3lcome1!", new List<string> { ApplicationRoles.ADMIN });
        }

        private static void CreateFrontUser(ApplicationDbContext context)
        {
            CreateUserWithRole(context, "frontuser@rtb.com", "W3lcome1!", new List<string> { ApplicationRoles.FRONTUSER });
        }

        private static void CreateRoles(ApplicationDbContext context) {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roles = context.Roles.ToList();
            var adminRole = context.Roles.Any(r => r.Name == ApplicationRoles.ADMIN);

            if (!roleManager.RoleExists(ApplicationRoles.ADMIN))
            {
                var role = new IdentityRole { Name = ApplicationRoles.ADMIN };
                roleManager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == ApplicationRoles.FRONTUSER))
            {
                var role = new IdentityRole { Name = ApplicationRoles.FRONTUSER };
                roleManager.Create(role);
            }
        }

        private static void CreateUserWithRole(ApplicationDbContext context, string userName, string password, List<string> roles)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            if (!context.Users.Any(u => u.UserName == userName))
            {
                var user = new ApplicationUser { UserName = userName };
                userManager.Create(user, password);
                foreach (var role in roles)
                {
                    userManager.AddToRole(user.Id, role);
                }
            }
            else
            {
                var user = context.Users.Where(u => u.UserName == userName).First();
                var uRoles = userManager.GetRoles(user.Id);
                foreach (var role in uRoles)
                {
                    if (!uRoles.Any(r => r == role))
                    {
                        userManager.AddToRole(user.Id, role);
                    }
                }
            }
        }
    }
}
