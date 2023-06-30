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
    public partial class frmProductos : Form
    {
        string[,] matrizProductos = new string[10,3];
        int indiceFila = 0;

        public frmProductos()
        {
            InitializeComponent();
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            string id, nombre, fecha;
            id = nmcID.Value.ToString();
            nombre = txtNombre.Text;
            fecha = dtpRegistro.Value.ToString("dd/MM/yyyy");
            matrizProductos[indiceFila, 0] = id;
            matrizProductos[indiceFila, 1] = nombre;
            matrizProductos[indiceFila, 2] = fecha;

            MessageBox.Show(matrizProductos[indiceFila, 1] + " se agrego correctamente.");           
            indiceFila = indiceFila + 1;
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            dgvProductos.Rows.Clear();
            for (int f = 0; f < matrizProductos.GetLength(0); f++)
            {
                if (matrizProductos[f,0] != null)
                {
                    dgvProductos.Rows.Add(matrizProductos[f, 0], matrizProductos[f, 1], matrizProductos[f, 2]);
                }
            }
        }

        private void cmdListado_Click(object sender, EventArgs e)
        {
            frmListado listado = new frmListado("Productos", matrizProductos);
            listado.ShowDialog();
        }
    }
}
