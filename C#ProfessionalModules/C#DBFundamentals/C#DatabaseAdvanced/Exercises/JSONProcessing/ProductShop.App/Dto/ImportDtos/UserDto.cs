namespace ProductShop.App.Dto.ImportDtos
{
    using System.ComponentModel.DataAnnotations;

    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }
    }
}
