namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using PetClinic.App.Dtos.ExportDtos;
    using PetClinic.Data;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animal = context.Animals.Include(a => a.Passport)
                                        .Where(a => a.Passport.OwnerPhoneNumber == phoneNumber)
                                        .OrderBy(a => a.Age)
                                        .ThenBy(a => a.PassportSerialNumber) 
                                        .ToArray();

            var dto = Mapper.Map<AnimalDto[]>(animal);

            return JsonConvert.SerializeObject(dto, Newtonsoft.Json.Formatting.Indented);
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures.Select(p => new ExportProcedureDto
                                               {
                                                   Passport = p.Animal.PassportSerialNumber,
                                                   DateTime = p.DateTime.Date,
                                                   OwnerNumber = p.Animal.Passport.OwnerPhoneNumber,
                                                   AnimalAids = p.ProcedureAnimalAids.Select(paa => new ExportAnimalAids
                                                   {
                                                       Name = paa.AnimalAid.Name,
                                                       Price = paa.AnimalAid.Price
                                                   }).ToArray(),
                                                   TotalPrice = p.ProcedureAnimalAids.Sum(paa => paa.AnimalAid.Price)
                                               })
                                               .OrderBy(p => p.DateTime)
                                               .ThenBy(p => p.Passport)
                                               .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProcedureDto[]),
                new XmlRootAttribute("Procedures"));

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), procedures,
                new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString();
        }
    }
}
