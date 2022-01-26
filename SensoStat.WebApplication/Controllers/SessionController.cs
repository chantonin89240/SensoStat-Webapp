namespace SensoStat.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        public ActionResult LoadCSV()
        {
            return View();
        }
    }
}
