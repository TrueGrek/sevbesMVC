using sevbesMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace sevbesMVC.Controllers
{
    public class RolesController : Controller
    {
        ///// <summary>
        ///// Добавляю реализацию назначения пользователям ролей
        ///// </summary>

        //private ApplicationRoleManager roleManager;
        //private UserManager<ApplicationUser> userManager;

        //public RolesController(ApplicationRoleManager roleMgr, UserManager<ApplicationUser> userMrg)
        //{
        //    roleManager = roleMgr;
        //    userManager = userMrg;
        //}

        //// other methods

        ////Изменил IActionResult на ActionResult
        //public async Task<ActionResult> Update(string id)
        //{
        //    ApplicationRole role = await roleManager.FindByIdAsync(id);
        //    List<ApplicationUser> members = new List<ApplicationUser>();
        //    List<ApplicationUser> nonMembers = new List<ApplicationUser>();
        //    foreach (ApplicationUser user in userManager.Users)
        //    {
        //        var list = await userManager.IsInRoleAsync(user.ToString(), role.Name) ? members : nonMembers;
        //        list.Add(user);
        //    }
        //    return View(new RoleEdit
        //    {
        //        Role = role,
        //        Members = members,
        //        NonMembers = nonMembers
        //    });
        //}

        //[HttpPost]
        //public async Task<ActionResult> Update(RoleModification model)
        //{
        //    IdentityResult result;
        //    if (ModelState.IsValid)
        //    {
        //        foreach (string userId in model.AddIds ?? new string[] { })
        //        {
        //            ApplicationUser user = await userManager.FindByIdAsync(userId);
        //            if (user != null)
        //            {
        //                result = await userManager.AddToRoleAsync(user.ToString(), model.RoleName);
                        
        //            }
        //        }
        //        foreach (string userId in model.DeleteIds ?? new string[] { })
        //        {
        //            ApplicationUser user = await userManager.FindByIdAsync(userId);
        //            if (user != null)
        //            {
        //                result = await userManager.RemoveFromRoleAsync(user.ToString(), model.RoleName);
                        
        //            }
        //        }
        //    }

        //    if (ModelState.IsValid)
        //        return RedirectToAction(nameof(Index));
        //    else
        //        return await Update(model.RoleId);
        //}

        ////Конец реализации 

        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }

        private ApplicationUser userManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUser>();
            }
        }

        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await RoleManager.CreateAsync(new ApplicationRole
                {
                    Name = model.Name
                });
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(string id)
        {
            ApplicationRole role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                return View(new EditRoleModel { Id = role.Id, Name = role.Name});
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> Edit(EditRoleModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole role = await RoleManager.FindByIdAsync(model.Id);
                if (role != null)
                {
                    role.Name = model.Name;
                    IdentityResult result = await RoleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Что-то пошло не так");
                    }
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Delete(string id)
        {
            ApplicationRole role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await RoleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        


    }
}