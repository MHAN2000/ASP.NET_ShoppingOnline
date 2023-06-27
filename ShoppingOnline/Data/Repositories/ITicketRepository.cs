using ShoppingOnline.Models;
using ShoppingOnline.Models.DTO;

namespace ShoppingOnline.Data.Repositories
{
    public interface ITicketRepository
    {
        Task<List<TicketDTO>> GetAllTickets();
        Task<Ticket?> GetTicketById(int id);
        Task<Ticket> AddTicket(TicketDTO request);
        Task<Ticket?> UpdateTicket(TicketDTO request, int id);
        Task<Ticket?> DeleteTicket(int id);
    }
}
