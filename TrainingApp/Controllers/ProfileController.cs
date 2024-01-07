using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrainingApp.Models;

namespace TrainingApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        
        public async Task<IActionResult> UpdateProfile()
        {
            ViewBag.UserName = User.FindFirst(ClaimTypes.Name).Value;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UserProfileVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    user.FirstName = viewModel.FirstName;
                    user.LastName = viewModel.LastName;
                    user.Goals = viewModel.Goals;
                    user.Weight = viewModel.Weight;
                    user.Height = viewModel.Height;
                    
                    // Update other properties as needed

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        // Redirect to the user profile page or another relevant page
                        return RedirectToAction("Index");
                    }

                    // If the update fails, add errors to ModelState
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            ViewBag.Error = "You need to enter first name and last name";
            return RedirectToAction("UpdateProfile", "Profile");
            //return null;
        }
    }
}