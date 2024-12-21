namespace Luftborn.Task.Main.Domain.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
