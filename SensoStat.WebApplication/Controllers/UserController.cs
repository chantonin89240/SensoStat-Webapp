namespace SensoStat.WebApplication.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.WebApplication.Services.Contracts;
    using SensoStat.WebApplication.ViewModels;

    public class UserController : Controller
    {
        private UserViewModel model;

        private readonly IUserService _userService;

        private static List<RoleViewModel> listRoles;

        public UserController(IUserService userService)
        {
            model = new UserViewModel();
            this._userService = userService;
        }

        public IActionResult Index()
        {

            return this.View();
        }

        public IActionResult Authentificate(UserViewModel user)
        {
            // var userAuthentified = this._userService.Authenticate(user);
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddInstructionItem([FromBody] SessionVM session)
        {
            session.Instructions.Add(new InstructionItemViewModel());
            return PartialView("_InstructionItemsViewModel", session);
            //return this.View("Index", session);
        }

        public IActionResult Create()
        {
            listRoles = this._userService.GetRoles().ToList();
            model.Roles = listRoles;
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("create")]
        public IActionResult Create(UserViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = this._userService.CreateUser(model);
                if (user.Id != 0)
                {
                    return this.RedirectToAction(nameof(Create));
                }

                user.Roles = listRoles;
                ModelState.AddModelError(string.Empty, "Cet email est déjà utilisé pour un autre compte.");
                return this.View(user);
            }

            model.Roles = listRoles;
            return this.View(model);
        }
    }
}