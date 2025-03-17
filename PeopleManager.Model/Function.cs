﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PeopleManager.Model
{
    [Table(nameof(Function))]
    public class Function
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        [JsonIgnore]
        public IList<Person> People { get; set; } = new List<Person>();
    }
}
