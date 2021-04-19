using FileManager.Core.Application.Entities.Login;
using FileManager.Core.Application.Entities.User;
using FileManager.Core.Application.Mappings;
using FileManager.Infra.Security.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.App.WebApp.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_accountService.GetAllUsers().Select(s => s.ToUserViewModel()));
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterAsync(model.Email, model.Password);

                if (result.Succeeded)
                {
                    Notify("Usuário registrado com sucesso", false);
                    return RedirectToAction("Index", "Account");
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.LoginAsync(model.Email, model.Password, model.RememberMe);

                if (result.Succeeded)
                {
                    Notify($"Bem-vindo de volta!", false);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Login inválido");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
