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

        public string? RoleLibelle { get; set; }

        [Required]
        [RegularExpression("^((?!^Last Name$)[a-zA-Z '])+$", ErrorMessage = "Votre nom doit contenir uniquement des lettres")]
        public string LastName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [RegularExpression("^((?!^First Name$)[a-zA-Z '])+$", ErrorMessage = "Votre nom doit contenir uniquement des lettres")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$", ErrorMessage = "Votre email n'est pas correcte")]
        public string Email { get; set; }

        public string? Token { get; set; }

        // [Required]
        // public string Login { get; set; }

        [Required]
        [RegularExpression("^(?=.*/d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*]).{8,}$", ErrorMessage = "Le mot de passe doit contenir au moins 8 caractères, dont une majuscule, une minuscule, un caractère spéciale et un chiffre")]
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
            this.RoleLibelle = role.Libelle;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Email = email;
            // this.Login = login;
            this.Password = password;
        }
    }
}
