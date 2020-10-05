using JobSearch.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobSearch.Startup))]
namespace JobSearch
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoleAndUser();
        }

        // make Default roles And user
        public void CreateRoleAndUser()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole myRole;
            if (!roleManager.RoleExists("Admins"))
            {
                myRole = new IdentityRole();
                myRole.Name = "Admins";
                roleManager.Create(myRole);
            }
            if (!roleManager.RoleExists("Managers"))
            {
                myRole = new IdentityRole();
                myRole.Name = "Managers";
                roleManager.Create(myRole);
            }
            if (!roleManager.RoleExists("Employees"))
            {
                myRole = new IdentityRole();
                myRole.Name = "Employees";
                roleManager.Create(myRole);
            }
            // Make default users
            var myUser = new ApplicationUser();
            myUser.UserName = "Admin";
            myUser.Email = "adminUser@admin.eg";
            string PWD = "Admin@123";
            var check = userManager.Create(myUser, PWD);

            if (check.Succeeded)
            {
                userManager.AddToRole(myUser.Id, "Admins");
            }
        }
    }
}
