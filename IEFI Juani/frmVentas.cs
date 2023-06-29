using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEFI_Juani
{
    public partial class frmVentas : Form
    {
        string[,] matrizVentas = new string[10, 4];
        int indiceFila = 0;
        public frmVentas()
        {
            InitializeComponent();
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
             string id, producto, fecha, cantidad;
            id = nmcID.Value.ToString();
            producto = txtProducto.Text;
            fecha = dtpVenta.Value.ToString("dd/MM/yyyy");
            cantidad = nmcCantidad.Value.ToString();

            // CARGAMOS DATOS EN LA MATRIZ
            matrizVentas[indiceFila, 0] = id;
            matrizVentas[indiceFila, 1] = producto;
            matrizVentas[indiceFila, 2] = fecha;
            matrizVentas[indiceFila, 3] = cantidad;

            MessageBox.Show(matrizVentas[indiceFila, 1] + " se agrego correctamente.");
            indiceFila = indiceFila + 1;
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            dgvProductos.Rows.Clear();
            for (int f = 0; f < matrizVentas.GetLength(0); f++)
            {
                if (matrizVentas[f, 0] != null)
                {
                    dgvProductos.Rows.Add(matrizVentas[f, 0], matrizVentas[f, 1], matrizVentas[f, 2], matrizVentas[f, 3]);
                }
            }
        }

        private void cmdListado_Click(object sender, EventArgs e)
        {
            frmListado listado = new frmListado("Ventas", matrizVentas);
            listado.ShowDialog();
        }

        private void cmdFiltrar_Click(object sender, EventArgs e)
        {
            dgvProductos.Rows.Clear();
            string producto;
            producto = txtFiltro.Text;
            if (rbtnCantidad.Checked)
            {
                for (int f = 0; f < matrizVentas.GetLength(0); f++) 
                {
                    if (matrizVentas[f, 3] != null && int.Parse(matrizVentas[f, 3]) > 10)
                    {
                        dgvProductos.Rows.Add(matrizVentas[f, 0], matrizVentas[f, 1], matrizVentas[f, 2], matrizVentas[f, 3]);
                    }
                }
            }
            else if (rbtnProducto.Checked)
            {
                for (int f = 0; f < matrizVentas.GetLength(0); f++)
                {
                    if (matrizVentas[f, 1] != null && matrizVentas[f, 1] == producto)
                    {
                        MessageBox.Show(producto + "=" + matrizVentas[f, 1]);
                        dgvProductos.Rows.Add(matrizVentas[f, 0], matrizVentas[f, 1], matrizVentas[f, 2], matrizVentas[f, 3]);
                    }
                }
            }
        }
    }
}
