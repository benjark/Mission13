using System;
using System.ComponentModel.DataAnnotations;

namespace Mission13.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Phone { get; set; }

    }
}
