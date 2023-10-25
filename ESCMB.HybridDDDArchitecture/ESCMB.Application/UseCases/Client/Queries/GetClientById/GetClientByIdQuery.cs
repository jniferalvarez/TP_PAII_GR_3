using Common.Application.Commands;
using ESCMB.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Queries.GetClientById
{
    public class GetClientByIdQuery : IRequestQuery<ClientDto>
    {
        public GetClientByIdQuery()
        {
        }

        [Required]
        public string Id { get; set; }
    }

}
