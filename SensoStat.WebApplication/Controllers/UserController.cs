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

        /*public IActionResult Index(SessionViewModel session)
        {

            return this.View(session);
        }*/

        [HttpPost]
        public async Task<IActionResult> AddInstructionItem([FromBody] SessionVM session)
        {
            session.Instructions.Add(new InstructionItemViewModel());
            return PartialView("_InstructionItemsViewModel", session);
            //return this.View("Index", session);
        }
    }
}