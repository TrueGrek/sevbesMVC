using System.Collections.Generic;

namespace sevbesMVC.Models
{
    public class RoleEdit
    {
        public ApplicationRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
    }
}