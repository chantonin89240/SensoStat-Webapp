using System;
namespace SensoStat.Entities.HttpResponse
{
    public class CreateUserResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int IdRole { get; set; }

        public CreateUserResponse(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            IdRole = user.IdRole;
        }
    }
}