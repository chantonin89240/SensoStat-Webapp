namespace SensoStat.WebAPI.Controllers
{
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        [HttpGet]

        // GET: InformationController
        public IActionResult Get()
        {
            var info = Assembly.GetEntryAssembly().GetReferencedAssemblies().Select(assembly => new
            {
                Name = assembly.Name,
                Version = assembly.Version,
            }).ToList();

            return this.Ok(info);
        }
    }
}
