using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos
{
    [XmlType("user")]
    public class UserSoldProductDto
    {
        [XmlAttribute("firstName")]
        public string FirstName { get; set; }

        [XmlAttribute("lastName")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public string Age { get; set; }

        [XmlElement("sold-products")]
        public SecondSoldProductDto SoldProduct { get; set; }
    }
}
