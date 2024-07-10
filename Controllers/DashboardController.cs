using Microsoft.AspNetCore.Mvc;

namespace SignalR8.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
