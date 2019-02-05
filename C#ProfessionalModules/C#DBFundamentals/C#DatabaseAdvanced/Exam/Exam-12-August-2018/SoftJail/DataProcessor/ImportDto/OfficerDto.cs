using SoftJail.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerDto
    {
        [StringLength(30, MinimumLength = 3)]
        [Required]
        [XmlElement("Name")]
        public string FullName { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [Required]
        [XmlElement("Money")]
        public decimal Salary { get; set; }

        [Required]
        [XmlElement("Position")]
        [RegularExpression("^Overseer$|^Guard$|^Watcher$|^Labour$")]
        public string Position { get; set; }

        [Required]
        [XmlElement("Weapon")]
        [RegularExpression("^Knife$|^FlashPulse$|^ChainRifle$|^Pistol$|^Sniper$")]
        public string Weapon { get; set; }

        [ForeignKey("Department")]
        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public PrisonerIdDto[] Prisoners { get; set; }
    }
}
