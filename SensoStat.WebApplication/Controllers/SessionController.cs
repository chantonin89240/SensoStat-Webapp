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

        public SessionController(ISessionService service)
        {
            this._sessionService = service;
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
        public IActionResult Create(SessionViewModel session)
        {
            // IdPerson à remplacer
            session.IdPerson = 1;
            session.Etat = "Non-publiée";

            session = this._sessionService.MessagesToInstructions(session);

            this._sessionService.CreateSession(session);
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
            var sessionUpdated = this._sessionService.MessagesToInstructions(session);

            this._sessionService.UpdateSession(sessionUpdated);
            sessionUpdated.Presentations = this._sessionService.GetPresentations(sessionUpdated.Id);
            return this.View(sessionUpdated);
        }

        /*public IActionResult Delete()
        {
            return this.View();
        }*/

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (this._sessionService.DeleteSession(id))
            {
                return this.RedirectToAction("Index");
            }

            return this.RedirectToAction("edit", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> LoadFile(int id, IFormFile file)
        {
            var fileSave = this._sessionService.LoadFile(file, id);
            if (fileSave)
            {
                return this.RedirectToAction("edit", new { id = id });
            }

            this.ModelState.AddModelError(string.Empty, "Un problème est survenue, le fichier n'a pas été enregistré, veuillez réessayer.");
            return RedirectToAction("edit", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CloneSession(int id)
        {
            return RedirectToAction("index");
        }

        [HttpPost("{id}")]
        public IActionResult Publish(int id, SessionViewModel session)
        {
            var test = session;
            if (this._sessionService.Publish(id))
            {
                this.TempData["success"] = "La séance a bien été publiée.";
                return this.RedirectToAction("edit", new { id = id });
            }

            // ajouter message d'erreur de publication
            this.ModelState.AddModelError(string.Empty, "Un problème est survenue, le publication n'a pu être enregistrer, veuillez réessayer.");
            return this.RedirectToAction("edit", new { id = id });
        }
    }
}
