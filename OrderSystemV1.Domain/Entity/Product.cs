using OrderSystemV1.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderSystemV1.Domain.Entity
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;

        }

        public Guid Id { get; protected set; }
        [Display(Name = "Código")]
        public int RefenceProduct { get; private set; }
        public string Name { get; protected set; }    
        public decimal Price { get; protected set; }

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
