namespace SensoStat.Models.HttpRequest
{
    using System.ComponentModel.DataAnnotations;

    public class CreateUserRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int IdRole { get; set; }
    }
}