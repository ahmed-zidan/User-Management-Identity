using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserrManagementIdentity.Models;

namespace UserrManagementIdentity.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Profile Picture")]
            public byte[] ProfilePic { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            //var userName = await _userManager.GetUserNameAsync(user);
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var currUser = await _userManager.FindByIdAsync(user.Id);
            Username = currUser.UserName;

            Input = new InputModel
            {
                PhoneNumber = currUser.PhoneNumber,
                FirstName = currUser.FirstName,
                LastName = currUser.LastName,
                ProfilePic = currUser.ProfilePic
                
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            
                user.LastName = Input.LastName;
                user.FirstName = Input.FirstName;
                user.PhoneNumber = Input.PhoneNumber;
                if(Request.Form.Files.Count > 0)
            {
                using(var stream = new MemoryStream())
                {
                    Request.Form.Files[0].CopyTo(stream);
                    user.ProfilePic = stream.ToArray();
                }
              }
                

                var res = await _userManager.UpdateAsync(user);
                if (!res.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to update user.";
                    return RedirectToPage();
                }

           
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
