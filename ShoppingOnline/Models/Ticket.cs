namespace ShoppingOnline.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
