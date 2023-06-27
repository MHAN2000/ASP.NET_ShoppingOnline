namespace ShoppingOnline.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; } = 0;
        public int Quantity { get; set; } = 100;
    }
}
