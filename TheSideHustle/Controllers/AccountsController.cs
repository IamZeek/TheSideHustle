using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TheSideHustle.Models;

namespace TheSideHustle.Controllers
{
    public class AccountsController : Controller
    {
        public UserManager<IdentityUser> _userManager;
        public SignInManager<IdentityUser> _signinManager;
        public AccountsController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
        }

        public IActionResult AuthenticationView()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(AuthModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser {  UserName = model.SignupProperties.Email, Email = model.SignupProperties.Email };
                var result = await _userManager.CreateAsync(user, model.SignupProperties.Password);

                if (result.Succeeded)
                {
                    _signinManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index","home");
                }

            }
            return View("AuthenticationView",model);
        }
        

        [HttpPost]
        public async Task<IActionResult> Login(AuthModel model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model.LoginProperties);

            if (Validator.TryValidateObject(model.LoginProperties, validationContext, validationResults, true))
            {
                var authResult = await _signinManager.PasswordSignInAsync(model.LoginProperties.Email, model.LoginProperties.Password, model.LoginProperties.RememberMe, false);

                if (authResult.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                }
            }
            else
            {
                foreach (var validationResult in validationResults)
                {
                    ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
                }
            }
            return View("AuthenticationView",model);
        }

    }
}
