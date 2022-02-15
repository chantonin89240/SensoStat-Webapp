namespace SensoStat.WebAPI.Controllers
{
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Models.HttpRequest;
    using SensoStat.Services.Contracts;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">userService fournit les services liés à l'authentification et à la création d'un utilisateur</param>
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = this._userService.Authenticate(model);
            Response.Cookies.Append("Jwt", response.Token, new CookieOptions { Expires = DateTime.Now.AddHours(1)});

            if (response == null)
            {
                return this.BadRequest(new { message = "Utilisateur ou mot de passe incorrect." });
            }

            return this.Ok(response);
        }

        // [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = this._userService.GetAll();
            return this.Ok(users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = this._userService.GetById(id);

            return this.Ok(user);
        }

        [HttpPost]
        public IActionResult Create(CreateUserRequest model)
        {
            var user = this._userService.CreateUser(model);
            return this.CreatedAtAction(nameof(UserController.GetById), new { id = user.Id }, user);
        }
    }
}
