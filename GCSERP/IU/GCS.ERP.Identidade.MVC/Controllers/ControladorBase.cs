using GCS.ERP.Identidade.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GCS.ERP.Identidade.MVC.Controllers
{
    public abstract class ControladorBase : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if (resposta != null && resposta.Errors.Mensagens.Any())
            {
                foreach (var mensagem in resposta.Errors.Mensagens)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }
    }
}
