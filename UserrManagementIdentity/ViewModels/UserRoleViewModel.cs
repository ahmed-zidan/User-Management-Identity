using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserrManagementIdentity.ViewModels
{
    public class UserRoleViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
