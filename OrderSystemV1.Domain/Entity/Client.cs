using OrderSystemV1.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderSystemV1.Domain.Entity
{
    public class Client
    {
        public Client()
        {
        }

        public Client(Guid id)
        {
            Id = id;
        }
        public Client(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public Guid Id { get; set; }
        [Display(Name = "Código")]
        public int ReferenceClient { get; set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public DateTime BirthDate { get; protected set; }

        [NotMapped]
        public List<BrokenRule> Errors { get; protected set; }

        [NotMapped]
        public bool HasErrors => Errors.Count > 0;

        public void AddBrokenRule(string field, string description)
        {
            BrokenRule rule = new BrokenRule(field, description);
            Errors.Add(rule);
        }
    }
}
