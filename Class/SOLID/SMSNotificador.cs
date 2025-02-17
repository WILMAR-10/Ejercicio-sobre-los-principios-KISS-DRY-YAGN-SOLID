using System.Windows.Forms;

namespace Ejercicio_sobre_los_principios_KISS_DRY_YAGN_SOLID.Class.SOLID
{
    public class SMSNotificador : INotificador
    {
        public void Enviar(string mensaje)
        {
            MessageBox.Show($"Enviando SMS: {mensaje}");
        }
    }
}
