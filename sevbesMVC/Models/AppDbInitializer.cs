using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace sevbesMVC.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var adminrole = new IdentityRole { Name = "admin" };
            var userrole = new IdentityRole { Name = "user" };
            var googlerole = new IdentityRole { Name = "google" };
            var yandexrole = new IdentityRole { Name = "yandex" };
            var gmailrole = new IdentityRole { Name = "gmail" };

            // добавляем роли в бд
            roleManager.Create(adminrole);
            roleManager.Create(userrole);
            roleManager.Create(googlerole);
            roleManager.Create(yandexrole);
            roleManager.Create(gmailrole);

            // создаем пользователей
            var defaultadmin = new ApplicationUser { Email = "MrGladiatorDead@gmail.com", UserName = "MrGladiatorDead@gmail.com" };
            string password = "ad46D_ewr3W";

            var defaultuser = new ApplicationUser { Email = "grekov_777@mail.ru", UserName = "grekov_777@mail.ru" };
            string password1 = "ad46D_ewr3W";

            var result = userManager.Create(defaultadmin, password);
            var result2 = userManager.Create(defaultuser, password1);

            // если создание пользователя прошло успешно
            if (result.Succeeded && result2.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(defaultadmin.Id, adminrole.Name);
                userManager.AddToRole(defaultadmin.Id, userrole.Name);

                userManager.AddToRole(defaultuser.Id, userrole.Name);
            }


            base.Seed(context);
        }
    }
}