using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserrManagementIdentity.ViewModels
{
    public class EditUserRoleViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
