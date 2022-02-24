namespace SensoStat.WebApplication.Controllers
{
    using System;
    using System.Security.Claims;
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
            this.model = new UserViewModel();
            this._userService = userService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Authenticate()
        {

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Authenticate(AuthentificationViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var userAuthentified = this._userService.Authenticate(model);

                if (userAuthentified.Token == null)
                {
                    this.ModelState.AddModelError(string.Empty, "Utilisateur ou mot de passe incorrect.");
                    return this.View(model);
                }

                var claims = new ClaimsIdentity();
                var claimType = "Jwt";
                claims.AddClaim(new Claim(claimType, userAuthentified.Token));
                this.HttpContext.User.AddIdentity(claims);

                this.Response.Cookies.Append("Jwt", userAuthentified.Token, new CookieOptions { Expires = DateTime.Now.AddHours(1) });
                this.Response.Cookies.Append("Role", userAuthentified.RoleLibelle);
                this.Response.Cookies.Append("IdUser", userAuthentified.Id.ToString());

                return this.RedirectToAction(nameof(Index), "session");
            }
            return this.View(model);
        }

        public IActionResult Create()
        {
            listRoles = this._userService.GetRoles().ToList();
            this.model.Roles = listRoles;
            return this.View(this.model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("create")]
        public IActionResult Create(UserViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = this._userService.CreateUser(model);
                if (user.Id != 0)
                {
                    return this.RedirectToAction(nameof(Index), "session");
                }

                user.Roles = listRoles;
                this.ModelState.AddModelError(string.Empty, "Cet email est déjà utilisé pour un autre compte.");
                return this.View(user);
            }

            model.Roles = listRoles;
            return this.View(model);
        }
    }
}