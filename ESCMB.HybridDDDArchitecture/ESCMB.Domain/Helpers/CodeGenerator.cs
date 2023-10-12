using System.Text;

namespace ESCMB.Domain.Helpers
{
    internal static class CodeGenerator
    {
        private static Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GetCode(int length)
        {
            StringBuilder codigo = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int indice = random.Next(chars.Length);
                codigo.Append(chars[indice]);
            }

            return codigo.ToString();
        }
    }
}
