using Common.Application.Commands;
using System.ComponentModel.DataAnnotations;

namespace ESCMB.Application.UseCases.Client.Commands.CreateClient
{
    public class CreateClientCommand : IRequestCommand<string>
    {
        [Required]
        public string Apellido { get; set; }
        [Required]
        public long CuitCuil { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
