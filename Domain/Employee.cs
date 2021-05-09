using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }

        public PassportInfo PassportInfo { get; set; }

        public List<Project> Projects { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }

        public bool NameWithA()
        {
            return this.FirstName.StartsWith("a");
        }
    }
}
