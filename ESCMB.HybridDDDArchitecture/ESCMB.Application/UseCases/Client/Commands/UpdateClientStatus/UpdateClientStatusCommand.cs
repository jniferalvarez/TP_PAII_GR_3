using Common.Application.Commands;

namespace ESCMB.Application.UseCases.Client.Commands.UpdateClientStatus
{
    public class UpdateClientStatusCommand : IRequestCommand
    {
        public string Id { get; set; }
    }
}
