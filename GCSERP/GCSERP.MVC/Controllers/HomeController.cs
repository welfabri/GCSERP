using GCS.ERP.Identidade.Aplicacao.ViewModels;
using GCSERP.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GCSERP.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet("entrar")]
        public IActionResult Entrar(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost("entrar")]
        public async Task<IActionResult> Entrar(ViewModelUsuarioLogin usuarioLogin, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid) return View(usuarioLogin);

            var result = await _signInManager.PasswordSignInAsync(
                usuarioLogin.Email, usuarioLogin.Senha,
                false, true);

            if (result.Succeeded)
            {
                await EntrarOk(usuarioLogin.Email, usuarioLogin.Email, new List<string>());
                return Redirect(returnUrl ?? "/");
            }

            if (result.IsLockedOut)
                ModelState.AddModelError(string.Empty, 
                    "Usuário temporariamente bloqueado por tentativas inválidas");

            ModelState.AddModelError(string.Empty,
                "Usuário ou Senha incorretos");

            return View(usuarioLogin);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("registrar")]
        public IActionResult Registrar()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Registrar(ViewModelUsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);

            var user = new IdentityUser
            {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, usuarioRegistro.Senha);

            if (result.Succeeded)
                return RedirectToAction(nameof(Index));

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(usuarioRegistro);
        }

        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("cadastro-usuarios")]
        public IActionResult CadastroUsuarios()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task EntrarOk(string email, string nome, List<string> roles)
        {
            var c = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, email),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name, nome)
            };

            foreach (var r in roles)
                c.Add(new Claim(ClaimTypes.Role, r));

            var ci = new ClaimsIdentity(c, CookieAuthenticationDefaults.AuthenticationScheme);
            var cp = new ClaimsPrincipal(ci);
            var ap = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1800),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                cp, ap);
        }   
    }
}
