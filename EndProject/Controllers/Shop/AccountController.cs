using EndProject.Abstractions.MailService;
using EndProject.Models.AppUser;
using EndProject.Models.ViewModels;
using EndProject.Models.ViewModels;
using EndProject.Models.ViewModels.MailSender;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EndProject.Controllers.Shop
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMailService _mailService;


        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IMailService mailService)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
            _mailService = mailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> CreateUser()
        //{
        //    AppUser user = new AppUser
        //    {
        //        FirstName = "Ayla",
        //        LastName = "Naghiyeva",
        //        Email = "sebinenagiyeva506@gmail.com",
        //        UserName = "AylaNagh"
        //    };

        //    //var res = await _userManager.CreateAsync(user, "SuperAdmin");

        //    var res = await _userManager.CreateAsync(user, "Test-123");
        //    return Ok(res.Succeeded);
        //}

        //public async Task<IActionResult> CreateRole()
        //{
        //   // IdentityRole superAdmin = new IdentityRole("SuperAdmin");
        //  //  IdentityRole admin = new IdentityRole("Admin");
        //   // IdentityRole assistant = new IdentityRole("Assistant");
        //    //  await _roleManager.CreateAsync(superAdmin);
        //    //  await _roleManager.CreateAsync(admin);
        //    var res = await _roleManager.CreateAsync(assistant);
        //    return Ok(res);
        //}


        //public async Task<IActionResult> AddRole()
        //{
        //    AppUser user = await _userManager.FindByNameAsync("AylaNagh");

        //    var res = await _userManager.AddToRoleAsync(user, "Assistant");
        //    return Ok(res);
        //}

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(loginVM.EmailOrUsername);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(loginVM.EmailOrUsername);
                if (user == null)
                {
                    ModelState.AddModelError("", "Login or Password Wrong!");
                    return View();
                }
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Login or Password Wrong!");
                return View();
            }
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByNameAsync(model.Username);

            if (user != null)
            {
                ModelState.AddModelError("UserName", "This Username has taken!");
                return View();
            }

            user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                ModelState.AddModelError("Email", "This Email has taken!");
                return View();
            }

            user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Username
            };

            var res = await _userManager.CreateAsync(user, model.ConfirmPassword);
            if (!res.Succeeded)
            {
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(user, "Member");

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            if (!ModelState.IsValid)  return View(forgotPasswordVM); 
            AppUser user = await _userManager.FindByEmailAsync(forgotPasswordVM.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email not found");
                return View(forgotPasswordVM);
            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string link = Url.Action("ResetPassword", "Account", new { userId = user.Id, token = token }, HttpContext.Request.Scheme);
            await _mailService.SendEmailAsync(new MailRequestVM { ToEmail = forgotPasswordVM.Email, Subject = "ResetPassword", Body = $"<a href='{link}'>Reset Password</a>" });

            return RedirectToAction(nameof(Login));
        }
        public async Task<IActionResult> ResetPassword(string userId, string token)
        {

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token)) return BadRequest();
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM, string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token)) { return BadRequest(); }
            if (!ModelState.IsValid) return View(resetPasswordVM);
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            var res = await _userManager.ResetPasswordAsync(user, token, resetPasswordVM.ComfirmPassword);
            return RedirectToAction("Login");
        }
    }
}
