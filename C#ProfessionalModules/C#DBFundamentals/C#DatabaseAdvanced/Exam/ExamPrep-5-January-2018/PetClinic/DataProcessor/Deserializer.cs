namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Newtonsoft.Json;
    using PetClinic.App.Dtos.ImportDtos;
    using PetClinic.Data;
    using PetClinic.Models;

    public class Deserializer
    {

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var animalAidDtos = JsonConvert.DeserializeObject<AnimalAidDto[]>(jsonString);

            var validatedAnimalAids = new List<AnimalAid>();

            var sb = new StringBuilder();

            foreach (var animalAidDto in animalAidDtos)
            {
                if (!IsValid(animalAidDto) || validatedAnimalAids.Any(va => va.Name == animalAidDto.Name)) 
                {
                    sb.AppendLine("Error: Invalid data.");
                }
                else
                {
                    validatedAnimalAids.Add(Mapper.Map<AnimalAid>(animalAidDto));
                    sb.AppendLine($"Record {animalAidDto.Name} successfully imported.");
                }
            }

            context.AnimalAids.AddRange(validatedAnimalAids);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var animalDtos = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);

            var validatedAnimas = new List<Animal>();

            var sb = new StringBuilder();

            foreach (var animalDto in animalDtos)
            {
                if (!IsValid(animalDto) || 
                    validatedAnimas.Any(va => va.PassportSerialNumber == animalDto.Passport.SerialNumber) ||
                    !IsValid(animalDto.Passport))
                {
                    sb.AppendLine("Error: Invalid data.");
                }
                else
                {
                    validatedAnimas.Add(Mapper.Map<Animal>(animalDto));
                    sb.AppendLine($"Record {animalDto.Name} Passport №: {animalDto.Passport.SerialNumber} successfully imported.");
                }
            }

            context.Animals.AddRange(validatedAnimas);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(VetDto[]), new XmlRootAttribute("Vets"));
            var vetDtos = (VetDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var validatedVets = new List<Vet>();

            foreach (var dto in vetDtos)
            {
                if(!IsValid(dto) || validatedVets.Any(vv => vv.PhoneNumber == dto.PhoneNumber))
                {
                    sb.AppendLine("Error: Invalid data.");
                }
                else
                {
                    validatedVets.Add(Mapper.Map<Vet>(dto));
                    sb.AppendLine($"Record {dto.Name} successfully imported.");
                }
            }

            context.Vets.AddRange(validatedVets);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProcedureDto[]), new XmlRootAttribute("Procedures"));
            var procedureDto = (ProcedureDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var validatedProcedures = new List<Procedure>();

            foreach (var dto in procedureDto)
            {
                var vetsExsists = context.Vets.Any(v => v.Name == dto.Vet);
                var animalsExists = context.Animals.Any(a => a.PassportSerialNumber == dto.Animal);
                var animalAidExists = true;
                var animalAidGivenMoreThanOnce = false;

                foreach (var animalAid in dto.AnimalAids)
                {
                    if(!context.AnimalAids.Any(aa => aa.Name == animalAid.Name))
                    {
                        animalAidExists = false;
                        break;
                    }
                }

                for (int i = 0; i < dto.AnimalAids.Length - 1; i++)
                {
                    for (int j = i + 1; j < dto.AnimalAids.Length; j++)
                    {
                        if(dto.AnimalAids[i].Name == dto.AnimalAids[j].Name)
                        {
                            animalAidGivenMoreThanOnce = true;
                            break;
                        }
                    }
                    if(animalAidGivenMoreThanOnce == true)
                    {
                        break;
                    }
                }

                if ( !vetsExsists
                    || !animalsExists
                    || !animalAidExists
                    || animalAidGivenMoreThanOnce)
                {
                    sb.AppendLine("Error: Invalid data.");
                }
                else
                {
                    var newProcedure = new Procedure()
                    {
                        AnimalId = context.Animals.First(a => a.PassportSerialNumber == dto.Animal).Id,
                        DateTime = DateTime.ParseExact(dto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        VetId = context.Vets.First(v => v.Name == dto.Vet).Id
                    };

                    foreach (var animalAid in dto.AnimalAids)
                    {
                        newProcedure.ProcedureAnimalAids.Add(new ProcedureAnimalAid()
                        {
                            AnimalAid = context.AnimalAids.First(aa => aa.Name == animalAid.Name),
                            Procedure = newProcedure
                        });
                    }

                    validatedProcedures.Add(newProcedure);
                    sb.AppendLine($"Record successfully imported.");
                }
            }

            context.Procedures.AddRange(validatedProcedures);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);

            return Validator.TryValidateObject(obj, validationContext, new List<ValidationResult>(), true);
        }
    }
}
