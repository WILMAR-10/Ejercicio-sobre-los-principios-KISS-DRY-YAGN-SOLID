using Ejercicio_sobre_los_principios_KISS_DRY_YAGN_SOLID.Class;
using Ejercicio_sobre_los_principios_KISS_DRY_YAGN_SOLID.Class.DRY;
using Ejercicio_sobre_los_principios_KISS_DRY_YAGN_SOLID.Class.SOLID;
using Ejercicio_sobre_los_principios_KISS_DRY_YAGN_SOLID.Class.YAGNI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_sobre_los_principios_KISS_DRY_YAGN_SOLID
{
    public partial class Form1 : Form
    {
        private Inventario inventario = new Inventario();
        public Form1()
        {
            InitializeComponent();

            comboBoxTipo.Items.AddRange(new string[] { "Email", "SMS" });
        }

        private void buttonCalcular1_Click(object sender, EventArgs e)
        {
            // KISS: Cálculo del total con propina
            bool propinaPersonalizada = checkBoxPropinaPersonalizada.Checked;
            decimal propinaValor = propinaPersonalizada ? decimal.Parse(textBoxPropina.Text) : 0;

            decimal total = KISS.CalcularTotal(textBoxPrecios.Text, propinaPersonalizada, propinaValor);
            labelResultado1.Text = $"Total a pagar: {total}";
        }

        private void buttonCalcular2_Click(object sender, EventArgs e)
        {
            // DRY: Cálculo de salario
            Empleado empleado;

            if (radioTiempoCompleto.Checked)
            {
                empleado = new EmpleadoTiempoCompleto(decimal.Parse(textBoxSalario.Text));
            }
            else
            {
                empleado = new EmpleadoTiempoParcial(decimal.Parse(textBoxSueldoHora.Text), int.Parse(textBoxHoras.Text));
            }

            labelResultado2.Text = $"Salario neto después de impuestos y bono: {empleado.CalcularSalario()}";

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            // YAGNI: Gestión básica de productos
            if (!string.IsNullOrWhiteSpace(textBoxNombre.Text) && !string.IsNullOrWhiteSpace(textBoxPrecio.Text))
            {
                inventario.AgregarProducto(textBoxNombre.Text, decimal.Parse(textBoxPrecio.Text));
                ActualizarListaProductos();
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            // YAGNI: Eliminación de productos
            if (!string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                inventario.EliminarProducto(textBoxNombre.Text);
                ActualizarListaProductos();
            }
        }

        private void ActualizarListaProductos()
        {
            dataGridViewProductos.Rows.Clear();
            foreach (var producto in inventario.ObtenerProductos())
            {
                dataGridViewProductos.Rows.Add(producto.Nombre, producto.Precio);
            }
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            // SOLID: Aplicación del principio de responsabilidad única
            INotificador notificador;
            if (comboBoxTipo.SelectedIndex == 0)
            {
                notificador = new EmailNotificador();
            }
            else
            {
                notificador = new SMSNotificador();
            }

            string mensaje = textBoxMensaje.Text;
            notificador.Enviar(mensaje);

            // Registrar el mensaje en los logs
            Logger logger = new Logger();
            logger.Registrar(mensaje);

            labelResultado3.Text = "Notificación enviada.";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewProductos.Columns.Add("Nombre", "Nombre");
            dataGridViewProductos.Columns.Add("Precio", "Precio");
        }
    }
}
