using Microsoft.AspNetCore.Mvc;

namespace TimeTrackerAutomationSWD.Controllers
{
    public class TimeTrackingController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}