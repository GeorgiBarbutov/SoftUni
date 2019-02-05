using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos
{
    [XmlType("sold-products")]
    public class SecondSoldProductDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("products")]
        public List<SecondProductDto> Products { get; set; }
    }
}
