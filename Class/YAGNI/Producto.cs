using System;

namespace Ejercicio_sobre_los_principios_KISS_DRY_YAGN_SOLID.Class.YAGNI
{
    public class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }
}
