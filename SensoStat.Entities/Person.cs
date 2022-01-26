﻿namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Person
    {
        public int Id { get; set; }

        public Role Role { get; set; }

        public int IdRole { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Mail { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Session> Sessions { get; set; }

        public Person()
        {
            this.Sessions = new List<Session>();
        }

        public Person(int id, Role role, string lastName, string firstName, string mail, string login, string password) : this()
        {
            this.Id = id;
            this.Role = role;
            this.IdRole = role.Id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Mail = mail;
            this.Login = login;
            this.Password = password;
        }
    }
}
