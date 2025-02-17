using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_sobre_los_principios_KISS_DRY_YAGN_SOLID.Class.YAGNI
{
    public class Inventario
    {
        private List<Producto> productos = new List<Producto>();

        public void AgregarProducto(string nombre, decimal precio)
        {
            productos.Add(new Producto(nombre, precio));
        }

        public void EliminarProducto(string nombre)
        {
            productos.RemoveAll(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public List<Producto> ObtenerProductos()
        {
            return productos;
        }
    }
}
