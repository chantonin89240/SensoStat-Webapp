namespace SensoStat.Models.HttpResponse
{
    using SensoStat.Entities;

    public class CreateUserResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string RoleLibelle { get; set; }

        public CreateUserResponse(User user, string roleLibelle)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            RoleLibelle = roleLibelle;
        }
    }
}