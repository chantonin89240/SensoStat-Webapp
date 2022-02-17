﻿namespace SensoStat.Models.HttpResponse
{
    using System;
    using SensoStat.Entities;

    public class AuthenticateResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string RoleLibelle { get; set; }

        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            RoleLibelle = user.Role.Libelle;
            Token = token;
        }
    }
}