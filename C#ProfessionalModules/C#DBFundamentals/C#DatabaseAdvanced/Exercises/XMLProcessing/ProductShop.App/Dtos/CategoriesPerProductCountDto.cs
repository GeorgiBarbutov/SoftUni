using System.Xml.Serialization;

namespace ProductShop.App.Dtos
{
    [XmlType("category")]
    public class CategoriesPerProductCountDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("products-count")]
        public int NumberOfProducts { get; set; }

        [XmlElement("average-price")]
        public decimal AveragePricePerProduct { get; set; }

        [XmlElement("total-revenue")]
        public decimal TotalRevenue { get; set; }
    }
}
