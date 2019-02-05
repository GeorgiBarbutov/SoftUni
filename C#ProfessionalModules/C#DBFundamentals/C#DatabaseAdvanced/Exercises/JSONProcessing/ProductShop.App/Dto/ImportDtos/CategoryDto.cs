namespace ProductShop.App.Dto.ImportDtos
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryDto
    {
        public int Id { get; set; }

        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
