using AutoMapper;
using ShoppingOnline.Models.DTO;

namespace ShoppingOnline.Models.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDTO>();
            CreateMap<TicketDTO, Ticket>();
        }
    }
}
