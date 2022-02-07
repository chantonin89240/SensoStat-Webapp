namespace SensoStat.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.WebApplication.Services;
    using SensoStat.WebApplication.Services.Contracts;
    using SensoStat.WebApplication.ViewModels;

    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly ClientService _clientService;

        public SessionController(ISessionService service, ClientService clientService)
        {
            this._sessionService = service;
            this._clientService = clientService;
        }

        public IActionResult Index()
        {
            var model = this._sessionService.GetSessions();
            return this.View(model);
        }

        public IActionResult Archive()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Archive(int id)
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(SessionVM session)
        {

            //this._clientService.PostDataFromHttpClient("api/Sessions", session);
            return this.View();
        }

        public IActionResult Edit(int id)
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(SessionViewModel session)
        {
            return this.View();
        }

        public IActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Delete(SessionViewModel session)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadFile(IFormFile file)
        {
            this._sessionService.LoadFile(file);
            return RedirectToAction("create");
        }

        [HttpPost]
        public async Task<IActionResult> CloneSession(int id)
        {
            return RedirectToAction("create");
        }
    }
}
