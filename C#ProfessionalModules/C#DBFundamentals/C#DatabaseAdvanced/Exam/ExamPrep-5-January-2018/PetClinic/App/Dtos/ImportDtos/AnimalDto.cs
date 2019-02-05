using System.ComponentModel.DataAnnotations;

namespace PetClinic.App.Dtos.ImportDtos
{
    public class AnimalDto
    {
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Type { get; set; }

        [Range(1, int.MaxValue)]
        [Required]
        public int Age { get; set; }

        public PassportDto Passport { get; set; }
    }
}
