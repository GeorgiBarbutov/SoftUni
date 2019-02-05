using System.Xml.Serialization;

namespace PetClinic.App.Dtos.ExportDtos
{
    [XmlType("AnimalAid")]
    public class ExportAnimalAids
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}