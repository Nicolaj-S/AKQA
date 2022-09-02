using Microsoft.AspNetCore.Mvc;

namespace AKQA.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
