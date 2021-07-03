using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TPWebGroupe.Models;

[assembly: OwinStartupAttribute(typeof(TPWebGroupe.Startup))]
namespace TPWebGroupe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        // In this method we will create default User roles and Admin user for login
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            dbTpUtilisateurContext db = new dbTpUtilisateurContext();

            var roleManager = new Microsoft.AspNet.Identity.
                              RoleManager<Microsoft.AspNet.Identity.EntityFramework.
                              IdentityRole>(new RoleStore<IdentityRole>(context));

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                Profil p = new Profil();
                p.libelleProfil = role.Name;
                db.Profils.Add(p);
                db.SaveChanges();


                //Here we create a Admin super user who will maintain the website

                var user = new ApplicationUser();
                user.UserName = "berose";
                user.Email = "yberose@gmail.com";

                string userPWD = "BR@SE21SN";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");


                }
            }

            // creating Creating Manager role
            if (!roleManager.RoleExists("Client"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Client";
                roleManager.Create(role);
                Profil p = new Profil();
                p.libelleProfil = role.Name;
                db.Profils.Add(p);
                db.SaveChanges();

            }

            // creating Creating Invite
            if (!roleManager.RoleExists("Invite"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Invite";
                roleManager.Create(role);
                Profil p = new Profil();
                p.libelleProfil = role.Name;
                db.Profils.Add(p);
                db.SaveChanges();

            }
        }
    }
}
