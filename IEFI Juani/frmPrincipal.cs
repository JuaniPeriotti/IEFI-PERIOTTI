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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void cmdProductos_Click(object sender, EventArgs e)
        {
            frmProductos Productos = new frmProductos();
            Productos.ShowDialog();
        }

        private void cmdVentas_Click(object sender, EventArgs e)
        {
            frmVentas Ventas = new frmVentas();
            Ventas.ShowDialog();
        }
    }
    }

