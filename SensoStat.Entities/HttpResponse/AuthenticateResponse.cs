﻿using System;
namespace SensoStat.Entities.HttpResponse
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int IdRole { get; set; }

        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            IdRole = user.IdRole;
            Token = token;
        }
    }
}