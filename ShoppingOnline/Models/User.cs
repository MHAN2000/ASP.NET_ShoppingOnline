namespace ShoppingOnline.Models
{
    public class User
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public bool Genre { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
