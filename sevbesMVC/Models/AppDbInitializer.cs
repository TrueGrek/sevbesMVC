using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using sevbesMVC.Controllers;

namespace sevbesMVC.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));

            // создаем две роли
            var adminrole = new ApplicationRole { Name = "admin" };
            var userrole = new ApplicationRole { Name = "user" };
            var googlerole = new ApplicationRole { Name = "google" };
            var yandexrole = new ApplicationRole { Name = "yandex" };
            var gmailrole = new ApplicationRole { Name = "gmail" };

            // добавляем роли в бд
            roleManager.Create(adminrole);
            roleManager.Create(userrole);
            roleManager.Create(googlerole);
            roleManager.Create(yandexrole);
            roleManager.Create(gmailrole);


            //roleManager.CreateAsync(new ApplicationRole
            //{
            //    Name = "admin"
            //});
            //roleManager.CreateAsync(new ApplicationRole
            //{
            //    Name = "user"
            //});
            //roleManager.CreateAsync(new ApplicationRole
            //{
            //    Name = "google"
            //});
            //roleManager.CreateAsync(new ApplicationRole
            //{
            //    Name = "yandex"
            //});
            //roleManager.CreateAsync(new ApplicationRole
            //{
            //    Name = "gmail"
            //});

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