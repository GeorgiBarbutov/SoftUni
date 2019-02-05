using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos
{
    [XmlType("user")]
    public class UserDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("firstName")]
        public string FirstName { get; set; }

        [XmlAttribute("lastName")]
        [MinLength(3)]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public string Age { get; set; }
    }
}
