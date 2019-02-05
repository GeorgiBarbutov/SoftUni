using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Prisoner
    {
        //        •	Id – integer, Primary Key
        //•	FullName – text with min length 3 and max length 20 (required)
        //•	Nickname – text starting with "The " and a single word only of letters with an uppercase letter for beginning(example: The Prisoner) (required)
        //•	Age – integer in the range[18, 65] (required)
        //•	IncarcerationDate ¬– Date(required)
        //•	ReleaseDate– Date
        //•	Bail– decimal (non-negative, minimum value: 0)
        //•	CellId - integer, foreign key
        //•	Cell – the prisoner's cell
        //•	Mails - collection of type Mail
        //•	PrisonerOfficers - collection of type OfficerPrisoner

        [Key]
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string FullName { get; set; }

        [RegularExpression("^The [A-Z]{1}[a-zA-Z]+$")]
        [Required]
        public string Nickname { get; set; }

        [Range(18, 65)]
        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime IncarcerationDate { get; set; }

        //maybe DateTime?
        public DateTime? ReleaseDate { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        //maybe decimal?
        public decimal? Bail { get; set; }

        [ForeignKey("Cell")]
        //maybe int?
        public int? CellId { get; set; }
        public Cell Cell { get; set; }

        public ICollection<Mail> Mails { get; set; } = new List<Mail>();

        public ICollection<OfficerPrisoner> PrisonerOfficers { get; set; } = new List<OfficerPrisoner>();
    }
}