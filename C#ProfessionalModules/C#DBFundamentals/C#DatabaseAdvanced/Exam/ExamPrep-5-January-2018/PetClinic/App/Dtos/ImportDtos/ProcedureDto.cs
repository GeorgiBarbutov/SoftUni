using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace PetClinic.App.Dtos.ImportDtos
{
    [XmlType("Procedure")]
    public class ProcedureDto
    {
        [Required]
        public string Vet { get; set; }

        [Required]
        public string Animal { get; set; }

        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public AnimalAidsProcedureDto[] AnimalAids { get; set; }
    }
}
