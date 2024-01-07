using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Models;

namespace TrainingApp.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Login(LoginVM model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);

                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(model.Email);
                }

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);
                    
                    if (result.Succeeded)
                    {
                        // Redirect to the dashboard after successful login
                         return RedirectToAction("Index", "Dashboard");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
             //   var user = new AppUser { UserName = model.Email, Email = model.Email };
                var user = new AppUser { UserName = model.UserName, Email = model.Email,FirstName=model.FirstName, LastName=model.LastName };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Dashboard");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccount()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Error");
            }
        }
    }
}
