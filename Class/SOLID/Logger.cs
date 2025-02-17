namespace Ejercicio_sobre_los_principios_KISS_DRY_YAGN_SOLID.Class.SOLID
{
    public class Logger
    {
        public void Registrar(string mensaje)
        {
            System.Diagnostics.Debug.WriteLine($"Notificación registrada: {mensaje}");
        }
    }
}
