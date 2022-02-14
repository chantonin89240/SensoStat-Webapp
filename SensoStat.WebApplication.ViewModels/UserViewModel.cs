using System;
using System.ComponentModel.DataAnnotations;

namespace SensoStat.WebApplication.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public IEnumerable<RoleViewModel> Roles { get; set; }

        public RoleViewModel? Role { get; set; }

        public int IdRole { get; set; }

        [Required]
        public string LastName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Token { get; set; }

        // [Required]
        // public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public List<SessionViewModel>? Sessions { get; set; }

        public UserViewModel()
        {
            this.Sessions = new List<SessionViewModel>();
            this.Roles = new List<RoleViewModel>();
        }

        public UserViewModel(RoleViewModel role, string lastName, string firstName, string email, /*string login,*/ string password) : this()
        {
            this.Role = role;
            this.IdRole = role.Id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Email = email;
            // this.Login = login;
            this.Password = password;
        }
    }
}
