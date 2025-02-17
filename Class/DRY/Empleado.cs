using System;

namespace Ejercicio_sobre_los_principios_KISS_DRY_YAGN_SOLID.Class
{
    internal abstract class Empleado
    {
        protected decimal AplicarImpuestosYBonos(decimal salario)
        {
            return salario * 0.87m; // Aplica el 18% de impuestos y un 5% de bono
        }

        public abstract decimal CalcularSalario();
    }
}