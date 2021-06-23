using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GCSERP.MVC.Extensoes
{
    public class SummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
            => View();
    }
}
