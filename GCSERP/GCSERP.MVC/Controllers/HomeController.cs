using GCSERP.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("entrar")]
        public IActionResult Entrar(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("validar")]
        public async Task<IActionResult> Validar(string email, string senha, string returnUrl)
        {
            if (email == "welisson.listas@gmail.com" && senha == "123456789")
            {
                await EntrarOk(email, "ALTERAR", new List<string>());
                return Redirect(returnUrl);
            }

            ViewData["ReturnUrl"] = returnUrl;
            TempData["Erro"] = "Usuário ou senha inválidos";
            return View(nameof(Entrar));
        }

        private async Task EntrarOk(string email, string nome, List<string> roles)
        {
            var c = new List<Claim>()
            { 
                new Claim(ClaimTypes.NameIdentifier, email),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name, nome)
            };

            foreach(var r in roles)
                c.Add(new Claim(ClaimTypes.Role, r));

            var ci = new ClaimsIdentity(c, CookieAuthenticationDefaults.AuthenticationScheme);
            var cp = new ClaimsPrincipal(ci);
            await HttpContext.SignInAsync(cp);        
        }

        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [Authorize]
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
    }
}
