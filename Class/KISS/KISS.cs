using System;
using System.Linq;

namespace Ejercicio_sobre_los_principios_KISS_DRY_YAGN_SOLID.Class
{
    internal class KISS
    {
        public static decimal CalcularTotal(string inputPrecios, bool propinaPersonalizada, decimal propinaValor)
        {
            var precios = inputPrecios.Split(',')
                                      .Select(p => decimal.TryParse(p, out decimal val) ? val : 0)
                                      .ToList();
            decimal total = precios.Sum();
            decimal propina = propinaPersonalizada ? propinaValor : total * 0.1m;
            return total + propina;
        }
    }
}
