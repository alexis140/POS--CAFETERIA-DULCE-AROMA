using POS__CAFETERIA_DULCE_AROMA.capa_presentaciom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS__CAFETERIA_DULCE_AROMA
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // cuando de clic, abrira el fomulario de productos
            FrmProductos frmProductos = new FrmProductos();
            frmProductos.Show();

        }



        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            // cuando de clic, abrira el fomulario de clientes
            FrmClientes frmClientes = new FrmClientes();
            frmClientes.Show();

        }
    }
}
