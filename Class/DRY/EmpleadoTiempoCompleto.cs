using System;

namespace Ejercicio_sobre_los_principios_KISS_DRY_YAGN_SOLID.Class.DRY
{
    internal class EmpleadoTiempoCompleto : Empleado
    {
        private decimal salarioBase;

        public EmpleadoTiempoCompleto(decimal salarioBase)
        {
            this.salarioBase = salarioBase;
        }

        public override decimal CalcularSalario()
        {
            return AplicarImpuestosYBonos(salarioBase);
        }
    }
}
