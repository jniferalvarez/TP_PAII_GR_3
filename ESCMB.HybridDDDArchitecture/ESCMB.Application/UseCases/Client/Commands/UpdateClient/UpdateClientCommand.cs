using Common.Application.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequestCommand
    {
        [Required]
        public string Apellido { get;  set; }
        [Required]
        public long CuitCuil { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Nombre { get;set; }
        [Required]
        public string Status { get;set; }

        public UpdateClientCommand()
        {

        }
    }
}
