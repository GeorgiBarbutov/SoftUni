using System.Xml.Serialization;

namespace ProductShop.App.Dtos
{
    [XmlType("product")]
    public class ProductsInRangeDto
    {
        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("buyer")]
        public string BuyerName { get; set; }
    }
}
