﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Officer
    {
        //        •	Id – integer, Primary Key
        //•	FullName – text with min length 3 and max length 30 (required)
        //•	Salary – decimal (non-negative, minimum value: 0) (required)
        //•	Position - Position enumeration with possible values: “Overseer, Guard, Watcher, Labour” (required)
        //•	Weapon - Weapon enumeration with possible values: “Knife, FlashPulse, ChainRifle, Pistol, Sniper” (required)
        //•	DepartmentId - integer, foreign key
        //•	Department – the officer's department (required)
        //•	OfficerPrisoners - collection of type OfficerPrisoner

        [Key]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string FullName { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [Required]
        public decimal Salary { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required]
        public Weapon Weapon { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [Required]
        public Department Department { get; set; }

        public ICollection<OfficerPrisoner> OfficerPrisoners { get; set; } = new List<OfficerPrisoner>();
    }
}
