using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos
{
    [XmlType("user")]
    public class SecondUserSoldProductsDto
    {
        [XmlAttribute("firts-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public int Age { get; set; }
    }
}
