using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class EncryptedMessagesDto
    {
        public string Description { get; set; }
    }
}
