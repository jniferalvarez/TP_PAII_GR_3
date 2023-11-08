using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Domain.Helpers
{
    public class GeneradorCVU
    {
        private static Random random = new Random();
        private const string chars = "0123456789";

        public static string GetCVU(int length)
        {
            StringBuilder CVU = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int indice = random.Next(chars.Length);
                CVU.Append(chars[indice]);
            }

            return CVU.ToString();
        }
        public static string GetCuenta(int length)
        {
            StringBuilder cuenta = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int indice = random.Next(chars.Length);
                cuenta.Append(chars[indice]);
            }

            return cuenta.ToString();

        }
    }
}

