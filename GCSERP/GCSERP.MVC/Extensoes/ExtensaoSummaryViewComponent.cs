using Microsoft.AspNetCore.Mvc;

namespace GCSERP.MVC.Extensoes
{
    public class ExtensaoSummaryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
            => View();
    }
}
