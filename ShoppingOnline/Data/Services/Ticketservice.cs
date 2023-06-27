using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Data.Repositories;
using ShoppingOnline.Models;
using ShoppingOnline.Models.DTO;

namespace ShoppingOnline.Data.Services
{
    public class Ticketservice : ITicketRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Ticketservice(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Ticket> AddTicket(TicketDTO request)
        {
            var ticket = _mapper.Map<Ticket>(request);
            _context.Tickets.Add(ticket);
            // Save changes
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<List<TicketDTO>> GetAllTickets()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return _mapper.Map<List<TicketDTO>>(tickets);
        }

        public async Task<Ticket?> GetTicketById(int id)
        {
            // Try to find the Ticket
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return null;
            return ticket;
        }

        public async Task<Ticket?> UpdateTicket(TicketDTO request, int id)
        {
            // Try to find the Ticket
            var ticket = await _context.Tickets.FindAsync(id);
            // If no Ticket is found return null, else update it
            if (ticket == null) return null;
            ticket.Quantity = request.Quantity;
            ticket.Total = request.Total;
            ticket.UserId = request.UserId;
            // Save changes
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket?> DeleteTicket(int id)
        {
            // Try to find the Ticket
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return null;
            _context.Tickets.Remove(ticket);
            return ticket;
        }
    }
}
