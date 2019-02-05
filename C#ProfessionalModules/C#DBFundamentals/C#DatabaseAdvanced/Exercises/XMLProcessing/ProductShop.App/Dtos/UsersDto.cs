using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos
{
    [XmlRoot("users")]
    public class UsersDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("user")]
        public List<UserSoldProductDto> Users { get; set; }
    }
}
