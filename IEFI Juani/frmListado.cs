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
    public partial class frmListado : Form
    {
        string Operacion;
        string[,] matriz;
        public frmListado(string operacion, string[,] matriz)
        {
            InitializeComponent();
            this.Operacion = operacion;
            if (operacion == "Productos")
            {
                this.matriz = matriz;
                this.Text = "Listado de Productos";
            }
            else
            {
                this.matriz = matriz;
                this.Text = "Listado de Ventas";
            }
        }

        private void frmListado_Load(object sender, EventArgs e)
        {
            listarElementosMatriz(matriz);
        }

        private void listarElementosMatriz(string[,] matriz)
        {
            //REGISTRO LOS DATOS EN UN ListBox
            lstListado.Items.Clear();
            if (Operacion == "Productos")
            {
                for (int f = 0; f < matriz.GetLength(0); f++)
                {
                    if (matriz[f, 0] != null)
                    {
                        lstListado.Items.Add("Producto " + (f+1).ToString());
                        lstListado.Items.Add("ID: " + matriz[f,0] + " - Nombre: " + matriz[f,1] + " - Fecha: " + matriz[f,2]);
                    }
                }
            }
            else
            {
                for (int f = 0; f < matriz.GetLength(0); f++)
                {
                    if (matriz[f, 0] != null)
                    {
                        lstListado.Items.Add("Producto " + (f + 1).ToString());
                        lstListado.Items.Add("ID: " + matriz[f, 0] + " - Nombre: " + matriz[f, 1] + " - Fecha: " + matriz[f, 2] + " - Cantidad: " + matriz[f, 3]);
                    }
                }
            }
        }
    }
}
