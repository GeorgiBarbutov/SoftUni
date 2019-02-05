using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace PetClinic.App.Dtos.ImportDtos
{
    [XmlType("AnimalAid")]
    public class AnimalAidsProcedureDto
    {
        [Required]
        public string Name { get; set; }
    }
}