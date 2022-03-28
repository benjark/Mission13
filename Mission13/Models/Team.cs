﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Mission13.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int TeamID { get; set; }

        public string BowlerID { get; set; }
    }
}
