namespace SensoStat.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Entities;
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
            var model = this._sessionService.GetSessions().ToList();
            return this.View(model);
        }

        public IActionResult Archive()
        {
            var model = this._sessionService.GetSessionsClose().ToList();
            return this.View(model);
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
            Session sessionCreate = new Session() {
                Name = session.Name,
                IdPerson = 1,
                Etat = "Non-déployée",
            };
            sessionCreate.Instructions.Add(new Instruction() { Chronology = 0, Libelle = session.MsgAccueil, IsQuestion = 0 });

            foreach (var item in session.Messages.Select((value, index) => new { value, index }))
            {
                int isQuestion = 0;
                if (session.Types[item.index] == "Question")
                {
                    isQuestion = 1;
                }

                sessionCreate.Instructions.Add(new Instruction() { Chronology = item.index + 1, Libelle = item.value, IsQuestion = isQuestion });
            }

            sessionCreate.Instructions.Add(new Instruction() { Chronology = sessionCreate.Instructions.Count(), Libelle = session.MsgFinal, IsQuestion = 0 });

            this._clientService.PostDataFromHttpClient("api/Sessions", sessionCreate);
            return this.RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var model = this._sessionService.GetSessionById(id);
            model.Presentations = this._sessionService.GetPresentations(id);
            return this.View(model);
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
        public async Task<IActionResult> LoadFile(int id, IFormFile file)
        {
            var fileSave = this._sessionService.LoadFile(file, id);
            if (fileSave)
            {
                return RedirectToAction("create");
            }

            this.ModelState.AddModelError(string.Empty, "Un problème est survenue, le fichier n'a pas été enregistré, veuillez réessayer.");
            return RedirectToAction("create");
        }

        [HttpPost]
        public async Task<IActionResult> CloneSession(int id)
        {
            return RedirectToAction("create");
        }
    }
}
