using Common.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.DomainEvents
{
    internal sealed class ClientDelete: DomainEvent
    {
        public string Id { get; set; }

        public ClientDelete(string id)
        {
            this.Id = id;

        }

    }
}
