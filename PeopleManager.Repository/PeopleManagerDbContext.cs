﻿using Microsoft.EntityFrameworkCore;
using PeopleManager.Model;

namespace PeopleManager.Repository
{
    public class PeopleManagerDbContext(DbContextOptions<PeopleManagerDbContext> options) : DbContext(options)
    {
        public DbSet<Function> Functions => Set<Function>();
        public DbSet<Person> People => Set<Person>();
        
            
        public void Seed()
        {
            var function = new Function { Name = "Manager" };
            Functions.Add(function);
            
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Function = function },
                new Person { FirstName = "Jane", LastName = "Smith", Email = null },  // No email
                new Person { FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com" },
                new Person { FirstName = "Bob", LastName = "Williams", Email = null, Function = function }, // No email
                new Person { FirstName = "Charlie", LastName = "Brown", Email = "charlie.brown@example.com" },
                new Person { FirstName = "David", LastName = "Miller", Email = null }, // No email
                new Person { FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com" },
                new Person { FirstName = "Frank", LastName = "Garcia", Email = "frank.garcia@example.com" },
                new Person { FirstName = "Grace", LastName = "Martinez", Email = null }, // No email
                new Person { FirstName = "Henry", LastName = "Rodriguez", Email = "henry.rodriguez@example.com", Function = function }
            };

            People.AddRange(people);

            SaveChanges();
        }
    }
}
