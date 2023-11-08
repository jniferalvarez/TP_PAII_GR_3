using Common.Domain.Entities;
using ESCMB.Domain.Helpers;
using ESCMB.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESCMB.Domain.Entities;
namespace ESCMB.Domain.Entities
{
    internal class Account: DomainEntity<AccountValidator>
    {
        public string Id { get; private set; }
        public string tipo_cuenta { get; private set; }
        public string CVU { get; private set; }
        public string alias { get; private set;}
        public float importe_total { get; private set; }
        public string numero_cuenta { get; set; }
        public Client client;
        
        public Account()
        {

        }

        public Account(string id, string tipo_cuenta, int cVU, string alias, float importe_total, string numero_cuenta)
        {
            Id = GetAccounttId() ?? throw new ArgumentNullException(nameof(id));
            this.tipo_cuenta = "Caja de Ahorro" ?? throw new ArgumentNullException(nameof(tipo_cuenta));
            CVU = GetCvu() ;
            this.alias = $"{client.Apellido}.{client.Nombre}.pp" ?? throw new ArgumentNullException(nameof(alias));
            this.importe_total = 0;
            this.numero_cuenta = GetCuenta();
        }
        private static string GetCvu()
        {
            return GeneradorCVU.GetCVU(22);
        }
        private static string GetAccounttId()
        {
            return CodeGenerator.GetCode(10);
        }
       
        private static string GetCuenta()
        {
            return GeneradorCVU.GetCuenta(15);
        }

    }

}
