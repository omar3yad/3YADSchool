using ITISchool.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace ITISchool.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View("Register");
        }


        [HttpPost]
        public async Task<IActionResult> SaveRegister(registerUserViewModel rum)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = rum.UserName,
                    PasswordHash = rum.Password,
                    Address = rum.Address,
                };

                var result = await userManager.CreateAsync(user,rum.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user,false);

                    return RedirectToAction("index","Department");
                }

                // If errors occurred, show them
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View("Register", rum);
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return View("Register");
        }
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> SaveLogin(LoginUserViewModel userVN)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser  AppUser = await  userManager.FindByNameAsync(userVN.UserName);
                if (AppUser != null){
                   bool found = await userManager.CheckPasswordAsync(AppUser, userVN.Password);
                    if (found) {
                        await signInManager.SignInAsync(AppUser, userVN.rememberMe);
                        return RedirectToAction("index", "Department");

                    }

                }

            }
            return View("Login", userVN);
        }
    }
}
