namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentDtos = JsonConvert.DeserializeObject<DepartmentDto[]>(jsonString);

            var validatedDepartaments = new List<Department>();

            var sb = new StringBuilder();

            foreach (var dto in departmentDtos)
            {
                bool allCellsAreValid = true;
                foreach (var cell in dto.Cells)
                {
                    if (!IsValid(cell))
                    {
                        allCellsAreValid = false;
                        break;
                    }
                }

                if (!IsValid(dto) || !allCellsAreValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department()
                {
                    Name = dto.Name,
                    Cells = dto.Cells.Select(c => new Cell()
                    {
                        CellNumber = c.CellNumber,
                        HasWindow = c.HasWindow
                    }).ToArray()
                };

                validatedDepartaments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(validatedDepartaments);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonerDtos = JsonConvert.DeserializeObject<PrisonerDto[]>(jsonString);

            var validatedPrisoners = new List<Prisoner>();

            var sb = new StringBuilder();

            foreach (var dto in prisonerDtos)
            {
                bool allMailsAreValid = true;
                foreach (var mail in dto.Mails)
                {
                    if (!IsValid(mail))
                    {
                        allMailsAreValid = false;
                        break;
                    }
                }

                if (!IsValid(dto) || !allMailsAreValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var newRealeseDate = new DateTime();
                DateTime.TryParseExact(dto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out newRealeseDate);

                var prisoner = new Prisoner()
                {
                    FullName = dto.FullName,
                    Nickname = dto.Nickname,
                    Age = dto.Age,
                    IncarcerationDate = DateTime.ParseExact(dto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = newRealeseDate,
                    Bail = dto.Bail,
                    CellId = dto.CellId,
                    Mails = dto.Mails.Select(m => new Mail()
                    {
                        Description = m.Description,
                        Address = m.Address,
                        Sender = m.Sender
                    }).ToArray()
                };

                validatedPrisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }
            context.Prisoners.AddRange(validatedPrisoners);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OfficerDto[]), new XmlRootAttribute("Officers"));
            var officerDtos = (OfficerDto[])serializer.Deserialize(new StringReader(xmlString));

            var validatedOfficers = new List<Officer>();

            var sb = new StringBuilder();

            foreach (var dto in officerDtos)
            {
                if(!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer()
                {
                    FullName = dto.FullName,
                    Salary = dto.Salary,
                    Position = Enum.Parse<Position>(dto.Position),
                    Weapon = Enum.Parse<Weapon>(dto.Weapon),
                    DepartmentId = dto.DepartmentId,
                    OfficerPrisoners = dto.Prisoners.Select(p => new OfficerPrisoner()
                    {
                        PrisonerId = p.Id,
                    }).ToArray()
                };

                validatedOfficers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.AddRange(validatedOfficers);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}