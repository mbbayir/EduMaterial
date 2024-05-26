using Microsoft.AspNetCore.Mvc;

namespace EduMaterial.Controllers
{
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
