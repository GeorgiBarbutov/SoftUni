using System.Xml.Serialization;

namespace ProductShop.App.Dtos
{
    [XmlType("product")]
    public class SecondProductDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
