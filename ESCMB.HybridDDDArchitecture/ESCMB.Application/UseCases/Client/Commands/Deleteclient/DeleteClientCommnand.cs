using Common.Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Commands.Deleteclient
{
    public class DeleteClientCommnand: IRequestCommand<Unit>
    {

        [Required]
        public string Id { get; set; }
    }
}
