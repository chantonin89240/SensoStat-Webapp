namespace SensoStat.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            this.HttpContext.Request.Cookies = null;
            var test = this.HttpContext.Request.Cookies;
            this.HttpContext.Session.Clear();

            this.Response.Cookies.Delete("Jwt");
            this.Response.Cookies.Delete("Role");
            this.Response.Cookies.Delete("IdUser");

            return this.View();
        }
    }
}
