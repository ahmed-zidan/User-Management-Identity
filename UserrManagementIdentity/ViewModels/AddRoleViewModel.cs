using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserrManagementIdentity.ViewModels
{
    public class AddRoleViewModel
    {
        [Required , StringLength(20)]
        public string RoleName { get; set; }
    }
}
