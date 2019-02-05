using SoftJail.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerDto
    {
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
        public string IncarcerationDate { get; set; }

        //maybe DateTime?
        public string ReleaseDate { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        //maybe decimal?
        public decimal? Bail { get; set; }

        [ForeignKey("Cell")]
        //maybe int?
        public int? CellId { get; set; }

        public ICollection<MailDto> Mails { get; set; } = new List<MailDto>();
    }
}
