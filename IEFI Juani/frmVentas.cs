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
        //CREAMOS LA MATRIZ DE 10x4 PARA ALAMCENAR CADENAS DE TEXTO
        string[,] matrizVentas = new string[10, 4];
        //VARIABLE NUMERICA PARA CONTROLAR LA FILA A LA QUE ACCEDO
        int indiceFila = 0;
        public frmVentas()
        {
            InitializeComponent();
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            //CARGO LA MATRIZ CON LOS VALORES DE LAS SIGUIENTES VARIABLES
             string id, producto, fecha, cantidad;
            id = nmcID.Value.ToString();
            producto = txtProducto.Text;
            fecha = dtpVenta.Value.ToString("dd/MM/yyyy");
            cantidad = nmcCantidad.Value.ToString();
            //ACCEDO A LA MATRIZ PARA ASIGNAR UN VALOR A CADA POSICION
            matrizVentas[indiceFila, 0] = id;
            matrizVentas[indiceFila, 1] = producto;
            matrizVentas[indiceFila, 2] = fecha;
            matrizVentas[indiceFila, 3] = cantidad;
            //MUESTRO QUE LOS DATOS SE ENVIARON AL DGV
            MessageBox.Show(matrizVentas[indiceFila, 1] + " se agrego correctamente.");
            indiceFila = indiceFila + 1;
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            //USO EL CICLO FOR PARA MOSTRAR LOS VALORES DE CADA FILA DE LA MATRIZ
            dgvVentas.Rows.Clear();
            for (int f = 0; f < matrizVentas.GetLength(0); f++)
            {
                if (matrizVentas[f, 0] != null)
                {
                    dgvVentas.Rows.Add(matrizVentas[f, 0], matrizVentas[f, 1], matrizVentas[f, 2], matrizVentas[f, 3]);
                }
            }
        }

        private void cmdListado_Click(object sender, EventArgs e)
        {
            //PASO LOS DATOS DE UN FORMULARIO A OTRO
            frmListado listado = new frmListado("Ventas", matrizVentas);
            listado.ShowDialog();
        }

        private void cmdFiltrar_Click(object sender, EventArgs e)
        {
            //LIMPIO EL DGV PARA PODER CARGAR LOS ELEMENTOS, RESPETANDO LOS FILTROS
            dgvVentas.Rows.Clear();
            string producto;
            producto = txtFiltro.Text;
            if (rbtnCantidad.Checked)
            {
                for (int f = 0; f < matrizVentas.GetLength(0); f++) 
                {
                    if (matrizVentas[f, 3] != null && int.Parse(matrizVentas[f, 3]) > 10)
                    {
                        dgvVentas.Rows.Add(matrizVentas[f, 0], matrizVentas[f, 1], matrizVentas[f, 2], matrizVentas[f, 3]);
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
                        dgvVentas.Rows.Add(matrizVentas[f, 0], matrizVentas[f, 1], matrizVentas[f, 2], matrizVentas[f, 3]);
                    }
                }
            }
        }
    }
}
