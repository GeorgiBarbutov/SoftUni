using System;
using System.Linq;
using System.Xml.Serialization;

namespace PetClinic.App.Dtos.ExportDtos
{
    [XmlType("Procedure")]
    public class ExportProcedureDto
    {
        public string Passport { get; set; }

        public string OwnerNumber { get; set; }

        public DateTime DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public ExportAnimalAids[] AnimalAids { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
