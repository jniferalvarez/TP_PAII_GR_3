using Common.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.DomainEvents
{
    internal sealed class ClientDeleted: DomainEvent
    {
        public string Id { get; set; }

        public ClientDeleted(string id)
        {
            this.Id = id;

        }

    }
}
