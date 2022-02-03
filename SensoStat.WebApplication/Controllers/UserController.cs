namespace SensoStat.WebApplication.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.WebApplication.ViewModels;

    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddInstructionItem([Bind("Instructions")] SessionViewModel session)
        {
            session.Instructions.Add(new InstructionItemViewModel());
            return PartialView("_InstructionItemsViewModel", session);
        }
    }
}