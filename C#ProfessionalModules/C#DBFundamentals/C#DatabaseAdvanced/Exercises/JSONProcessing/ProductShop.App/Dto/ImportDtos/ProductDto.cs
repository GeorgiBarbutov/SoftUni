namespace ProductShop.App.Dto.ImportDtos
{
    using System.ComponentModel.DataAnnotations;

    public class ProductDto
    {
        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int SellerId { get; set; }

        public int? BuyerId { get; set; }
    }
}
