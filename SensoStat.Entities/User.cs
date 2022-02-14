namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    public class User
    {
        public int Id { get; set; }

        public Role Role { get; set; }

        public int IdRole { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string? Login { get; set; }

        // L'attribut [JsonIgnore] empêche la sérialisation des propriétés "password" et "salt", son renvoi dans les réponses à l'API.
        [JsonIgnore]
        [Required]
        public string Password { get; set; }

        [JsonIgnore]
        public string Salt { get; set; }

        public List<Session> Sessions { get; set; }

        public User()
        {
            this.Sessions = new List<Session>();
        }

        public User(Role role, string lastName, string firstName, string email, string login, string password, string salt) : this()
        {
            this.Role = role;
            this.IdRole = role.Id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Email = email;
            this.Login = login;
            this.Password = password;
            this.Salt = salt;
        }
    }
}
