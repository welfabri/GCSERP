using GCS.ERP.Identidade.API.Extensoes;
using GCS.ERP.Identidade.API.Modelos;
using GCS.ERP.Identidade.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GCS.ERP.Identidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentidadeController : BaseController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ConfiguracoesAPI _appSettings;

        public IdentidadeController(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<ConfiguracoesAPI> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(ViewModelUsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return RespostaCustomizada(ModelState);

            var user = new IdentityUser
            {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, usuarioRegistro.Senha);

            if (result.Succeeded)
                return RespostaCustomizada(await GerarJwt(usuarioRegistro.Email));
            
            foreach (var error in result.Errors)
                AdicionarErroProcessamento(error.Description);
            
            return RespostaCustomizada();
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(ViewModelUsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return RespostaCustomizada(ModelState);

            var result = await _signInManager.PasswordSignInAsync(
                usuarioLogin.Email, usuarioLogin.Senha,
                false, true);

            if (result.Succeeded)
            {
                return RespostaCustomizada(await GerarJwt(usuarioLogin.Email));
            }

            if (result.IsLockedOut)
            {
                AdicionarErroProcessamento("Usuário temporariamente bloqueado por tentativas inválidas");
                return RespostaCustomizada();
            }

            AdicionarErroProcessamento("Usuário ou Senha incorretos");

            return RespostaCustomizada();
        }
        
        private async Task<ViewModelUsuarioRespostaLogin> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            var identityClaims = await ObterClaimsUsuario(claims, user);
            var encodedToken = CodificarToken(identityClaims);

            return ObterRespostaToken(encodedToken, user, claims);
        }

        private async Task<ClaimsIdentity> ObterClaimsUsuario(ICollection<Claim> claims, IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }

        private string CodificarToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Segredo);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }

        private ViewModelUsuarioRespostaLogin ObterRespostaToken(string encodedToken, IdentityUser user, 
            IEnumerable<Claim> claims)
        {
            return new ViewModelUsuarioRespostaLogin
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UsuarioToken = new ViewModelUsuarioToken
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => 
                        new ViewModelUsuarioClaim { Type = c.Type, Value = c.Value })
                }
            };
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() 
                - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                .TotalSeconds);
    }
}
