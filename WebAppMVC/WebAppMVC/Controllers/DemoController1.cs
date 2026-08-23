using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class DemoController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
