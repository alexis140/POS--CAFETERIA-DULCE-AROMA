using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POS__CAFETERIA_DULCE_AROMA.capa_entidades
{
    public static class Validaciones
    {
        public static bool EsDecimal(string s)
        {
            decimal d;
            return decimal.TryParse(s, out d);

        }
        public static bool EsEntero(string s)
        {
            int i;
            return int.TryParse(s, out i);
        }
        public static bool EsCorreoValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            var patron= @"^[@\s]+@[^@\s]+\.[@\s]+$";
            return Regex.IsMatch(email, patron);
        }
    }
}
