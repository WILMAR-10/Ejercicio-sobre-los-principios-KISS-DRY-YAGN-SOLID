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
        private decimal CalcularSalario(decimal salario) => salario * 0.87m;

        public interface INotificador { void Enviar(string mensaje); }
        public class EmailNotificador : INotificador { public void Enviar(string mensaje) => MessageBox.Show($"Enviando Email: {mensaje}"); }
        public class SMSNotificador : INotificador { public void Enviar(string mensaje) => MessageBox.Show($"Enviando SMS: {mensaje}"); }

        public Form1()
        {
            InitializeComponent();

            comboBoxTipo.Items.AddRange(new string[] { "Email", "SMS" });
        }

        private void buttonCalcular1_Click(object sender, EventArgs e)
        {
            // KISS: Cálculo del total con propina
            var precios = textBoxPrecios.Text.Split(',').Select(decimal.Parse).ToList();
            decimal total = precios.Sum() * 1.1m;
            labelResultado1.Text = $"Total a pagar: {total}";
        }

        private void buttonCalcular2_Click(object sender, EventArgs e)
        {
            // DRY: Cálculo de salario
            decimal salario = decimal.Parse(textBoxSalario.Text);
            labelResultado2.Text = $"Salario neto: {CalcularSalario(salario)}";
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            // YAGNI: Gestión básica de productos
            if (!string.IsNullOrWhiteSpace(textBoxNombre.Text) && !string.IsNullOrWhiteSpace(textBoxPrecio.Text))
            {
                dataGridViewProductos.Rows.Add(textBoxNombre.Text, textBoxPrecio.Text);
                textBoxNombre.Clear();
                textBoxPrecio.Clear();
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            // YAGNI: Eliminación de productos
            foreach (DataGridViewRow row in dataGridViewProductos.SelectedRows)
            {
                dataGridViewProductos.Rows.Remove(row);
            }
            textBoxNombre.Clear();
            textBoxPrecio.Clear();
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
            notificador.Enviar(textBoxMensaje.Text);
            labelResultado3.Text = "Notificación enviada.";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewProductos.Columns.Add("Nombre", "Nombre");
            dataGridViewProductos.Columns.Add("Precio", "Precio");
        }
    }
}
