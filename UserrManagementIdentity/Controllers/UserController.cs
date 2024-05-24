using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserrManagementIdentity.Models;
using UserrManagementIdentity.ViewModels;

namespace UserrManagementIdentity.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManger;
        private readonly UserManager<User> _userManager;
        public UserController(RoleManager<IdentityRole> roleManger , UserManager<User> userManager)
        {
            _roleManger = roleManger;
            _userManager = userManager;
        }
        public async Task<IActionResult> IndexAsync()
        {

            var users = await _userManager.Users.Select(x => new UserRoleViewModel()
            {
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Id = x.Id,
                Roles = _userManager.GetRolesAsync(x).Result

            }).ToListAsync();
            
            
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> ManageRolesAsync(string id)
        {

            var user = await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(user == null)
            {
                return NotFound();
            }
            var roles = await _roleManger.Roles.ToListAsync();
            var currUserRoles = await _userManager.GetRolesAsync(user);
            var userViewModel = new EditUserRoleViewModel()
            {
                Username = user.UserName,
                Id = user.Id,
                Roles = roles.Select(x => new RoleViewModel()
                {
                    RoleId = x.Id,
                    RoleName = x.Name,
                    Selected = _userManager.IsInRoleAsync(user,x.Name).Result
                }
                ).ToList()
            };


            return View(userViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRolesAsync(EditUserRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("ManageRolesAsync", model);
            }
            var user = await _userManager.FindByIdAsync(model.Id);
            if(user == null)
            {
                return NotFound();
            }

            foreach(var m in model.Roles)
            {
                if (m.Selected)
                {
                   await _userManager.AddToRoleAsync(user, m.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, m.RoleName);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
