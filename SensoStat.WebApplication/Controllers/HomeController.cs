namespace SensoStat.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            this.HttpContext.Request.Cookies = null;
            return this.View();
        }
    }
}
