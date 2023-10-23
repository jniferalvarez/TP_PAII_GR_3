using Common.Application.Commands;
using static ESCMB.Domain.Enums;

namespace ESCMB.Application.DomainEvents
{
    public class ClientCreated : DomainEvent
    {
        public string email { get; set; }
        public string? CuitCuil { get; set; }
        public ClientStatus ClientStatus { get; set; }
    }
}
