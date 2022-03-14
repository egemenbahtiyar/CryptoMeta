using CryptoMeta.EmailService;
using CryptoMeta.Identitiy;
using CryptoMeta.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMeta.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        public UserManager<User> _userManager;
        public SignInManager<User> _signInManager;
        public RoleManager<IdentityRole> _roleManager;
        public IEmailSender _emailSender;
        public IConfiguration _configuration;
        public IPasswordHasher<User> _passwordHasher;


        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender, IConfiguration configuration, RoleManager<IdentityRole> roleManager, ApplicationContext applicationContext, IPasswordHasher<User> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _configuration = configuration;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
        }

        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = model.Password

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // generate token
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code
                });

                // send email
                await _emailSender.SendEmailAsync(model.Email, "Hesabınızı Onaylayınız.", $"Lütfen email hesabınızı onaylamak için linke <a href='https://localhost:44319{callbackUrl}'>tıklayınız.</a>");

                //return RedirectToAction("Login", "Account");
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Bilinmeyen hata oluştu lütfen tekrar deneyiniz.");
            return View(model);
        }

        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Bu email ile daha önce hesap oluşturulmamış.");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Lütfen hesabınızı email ile onaylayınız.");
                return View(model);
            }


            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/");
            }

            ModelState.AddModelError("", "Email veya parola yanlış");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData["message"] = "Geçersiz token.";
                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TempData["message"] = "Hesabınız onaylandı";
                    return View();
                }
            }

            TempData["message"] = "Hesabınız onaylanmadı.";
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword", "Account", new
            {
                token = code
            });

            // send email
            await _emailSender.SendEmailAsync(Email, "Reset Password", $"Parolanızı yenilemek için linke <a href='https://localhost:44319{callbackUrl}'>tıklayınız.</a>");

            return RedirectToAction("Index", "Home");
        }


        public IActionResult ResetPassword(string token)
        {
            if (token == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new ResetPasswordModel { Token = token };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var result = await _userManager.ResetPasswordAsync(user,model.Token,model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Lütfen E-Mail adresinizi doğru girdiğinizden emin olun");
            return View(model);
        }
        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = model.Password,
                EmailConfirmed = true

            };
            var role = _configuration["Data:AdminUser:role"];
            //await _roleManager.CreateAsync(new IdentityRole(role));

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Bilinmeyen hata oluştu lütfen tekrar deneyiniz.");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            User user = await _userManager.FindByIdAsync(userId);

            var returnedModel = new UserManageModel
            {
                Username = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName

            };
            return View(returnedModel);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(UserManageModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = _userManager.GetUserId(HttpContext.User);
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(model.Username))
                    user.UserName = model.Username;
                else
                    ModelState.AddModelError("", "Username cannot be empty");
                if (!string.IsNullOrEmpty(model.Email))
                    user.Email = model.Email;
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                if (!string.IsNullOrEmpty(model.Password))
                    user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
                else
                    ModelState.AddModelError("", "Password cannot be empty");
                if (!string.IsNullOrEmpty(model.FirstName))
                    user.FirstName = model.FirstName;
                else
                    ModelState.AddModelError("", "Firstname cannot be empty");
                if (!string.IsNullOrEmpty(model.LastName))
                    user.LastName = model.LastName;
                else
                    ModelState.AddModelError("", "LastName cannot be empty");

                if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password) && !string.IsNullOrEmpty(model.Username) && !string.IsNullOrEmpty(model.FirstName) && !string.IsNullOrEmpty(model.LastName))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index","Home");
                    else
                        return View(model);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);
       
        }


    }
}
