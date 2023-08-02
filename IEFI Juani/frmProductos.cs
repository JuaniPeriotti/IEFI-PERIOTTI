﻿using System;
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
        //CREAMOS LA MATRIZ DE 10x3 PARA ALAMCENAR CADENAS DE TEXTO
        string[,] matrizProductos = new string[10,3];
        int indiceFila = 0;
        //VARIABLE NUMERICA PARA CONTROLAR LA FILA A LA QUE ACCEDO
        public frmProductos()
        {
            InitializeComponent();
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            //CARGO LA MATRIZ CON LOS VALORES DE LAS SIGUIENTES VARIABLES
            string id, nombre, fecha;
            id = nmcID.Value.ToString();
            nombre = txtNombre.Text;
            fecha = dtpRegistro.Value.ToString("dd/MM/yyyy");
            matrizProductos[indiceFila, 0] = id;
            matrizProductos[indiceFila, 1] = nombre;
            matrizProductos[indiceFila, 2] = fecha;
            //MUESTRO QUE LOS DATOS SE ENVIARON AL DGV
            MessageBox.Show(matrizProductos[indiceFila, 1] + " se agrego correctamente.");           
            indiceFila = indiceFila + 1;
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            //USO EL CICLO FOR PARA MOSTRAR LOS VALORES DE CADA FILA DE LA MATRIZ
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
            //PASO LOS DATOS DE UN FORMULARIO A OTRO
            frmListado listado = new frmListado("Productos", matrizProductos);
            listado.ShowDialog();
        }
    }
}
