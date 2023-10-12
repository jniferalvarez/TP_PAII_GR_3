﻿using Common.Domain.Entities;
using ESCMB.Domain.Helpers;
using ESCMB.Domain.Validators;
using static ESCMB.Domain.Enums;

namespace ESCMB.Domain.Entities
{
    public class Client : DomainEntity<ClientValidator>
    {
        public string Apellido { get; private set; }
        public int CuitCuil { get; private set; }
        public string Email { get; private set; }
        public string Id { get; private set; }
        public string Nombre { get; private set; }
        public string Status { get; private set; }

        public Client()
        {
        }

        public Client(string apellido, int cuitCuil, string email, string nombre)
        {
            Id = GetClientId();
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            CuitCuil = cuitCuil;
            Status = ClientStatus.Pendiente.ToString();
        }

        private static string GetClientId()
        {
            return CodeGenerator.GetCode(10);
        }
    }
}
