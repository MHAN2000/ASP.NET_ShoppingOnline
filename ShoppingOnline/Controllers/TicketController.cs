using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Data;
using ShoppingOnline.Data.Repositories;
using ShoppingOnline.Models;
using ShoppingOnline.Models.DTO;

namespace ShoppingOnline.Controllers
{
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;
        public TicketController(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<TicketDTO>> AddTicket(TicketDTO request)
        {
            var ticket = await _ticketRepository.AddTicket(request);
            return Ok(ticket);
        }

        [HttpGet]
        public async Task<ActionResult<List<TicketDTO>>> GetAll()
        {
            var tickets = await _ticketRepository.GetAllTickets();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicketById(int id)
        {
            var ticket = await _ticketRepository.GetTicketById(id);
            if (ticket == null) return NotFound("The ticket has not been found");
            return Ok(ticket);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ticket>> UpdateTicket([FromBody] TicketDTO request, int id)
        {
            var ticket = await _ticketRepository.UpdateTicket(request, id);
            if (ticket == null) return NotFound("The ticket has not been found");
            return Ok(ticket);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> DeleteTicket(int id)
        {
            var ticket = await _ticketRepository.DeleteTicket(id);
            if (ticket == null) return NotFound("The ticket has not been found");
            return Ok(ticket);
        }
    }
}
