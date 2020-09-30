using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sevbesMVC.Models
{
    /// <summary>
    /// Мои добавления
    /// </summary>
    public class ApplicationRole : IdentityRole { 
        public ApplicationRole() { }

    }
    public class EditRoleModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class CreateRoleModel
    {
        public string Name { get; set; }
    }
}