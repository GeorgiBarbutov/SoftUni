using System;

namespace PetClinic.App.Dtos.ExportDtos
{
    public class AnimalDto
    {
        public string OwnerName { get; set; }

        public string AnimalName { get; set; }

        public int Age { get; set; }

        public string SerialNumber { get; set; }

        public string RegisteredOn { get; set; }
    }
}
