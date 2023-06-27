namespace ShoppingOnline.Models.DTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
