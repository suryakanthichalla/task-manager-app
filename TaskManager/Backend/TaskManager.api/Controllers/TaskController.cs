using Microsoft.AspNetCore.Mvc;

namespace TaskManager.api.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
