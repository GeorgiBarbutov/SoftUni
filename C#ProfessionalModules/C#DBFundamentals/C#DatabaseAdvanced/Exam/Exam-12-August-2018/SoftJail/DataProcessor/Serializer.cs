namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners.Where(p => ids.Contains(p.Id)).ToArray();

            var exportData = prisoners.Select(p => new
            {
                Id = p.Id,
                Name = p.FullName,
                CellNumber = p.Cell.CellNumber,
                Officers = p.PrisonerOfficers.Select(po => new
                {
                    OfficerName = po.Officer.FullName,
                    Department = po.Officer.Department.Name
                }).OrderBy(o => o.OfficerName).ToArray(),
                //rounding
                TotalOfficerSalary = p.PrisonerOfficers.Sum(po => po.Officer.Salary)
            }).OrderBy(p => p.Name).ThenBy(p => p.Id).ToArray();

            return JsonConvert.SerializeObject(exportData, Newtonsoft.Json.Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var splitNames = prisonersNames.Split(",");
            var prisoners = context.Prisoners.Where(p => splitNames.Contains(p.FullName)).ToArray();

            var sb = new StringBuilder();

            var dtos = prisoners.Select(p => new PrisonerDto
            {
                Id = p.Id,
                Name = p.FullName,
                IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                EncryptedMessages = p.Mails.Select(m => new EncryptedMessagesDto
                {
                    Description = new string(m.Description.Reverse().ToArray())
                }).ToArray()
            }).OrderBy(p => p.Name).ThenBy(p => p.Id).ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(PrisonerDto[]), new XmlRootAttribute("Prisoners"));

            serializer.Serialize(new StringWriter(sb), dtos, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString();

        }
    }
}