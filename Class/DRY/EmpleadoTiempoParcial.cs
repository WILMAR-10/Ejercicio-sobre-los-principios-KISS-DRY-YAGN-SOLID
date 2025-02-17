using System;

namespace Ejercicio_sobre_los_principios_KISS_DRY_YAGN_SOLID.Class.DRY
{
    internal class EmpleadoTiempoParcial : Empleado
    {
        private decimal sueldoPorHora;
        private int horasTrabajadas;

        public EmpleadoTiempoParcial(decimal sueldoPorHora, int horasTrabajadas)
        {
            this.sueldoPorHora = sueldoPorHora;
            this.horasTrabajadas = horasTrabajadas;
        }

        public override decimal CalcularSalario()
        {
            return AplicarImpuestosYBonos(sueldoPorHora * horasTrabajadas);
        }
    }
}
