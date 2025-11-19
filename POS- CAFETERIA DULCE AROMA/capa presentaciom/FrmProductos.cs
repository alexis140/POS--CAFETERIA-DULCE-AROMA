using POS__CAFETERIA_DULCE_AROMA.capa_entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS__CAFETERIA_DULCE_AROMA.capa_presentaciom

{
    public partial class FrmProductos : Form

    {
        //Lista estatica para simular la conexion a base de datos
        private static List<capa_entidades.Producto> listaProductos = new List<capa_entidades.Producto>();
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            //carga inicial para poblar la lista con algunos productos
            if (!listaProductos.Any())
            {
                listaProductos.Add(new capa_entidades.Producto
                {
                    Id = 1,
                    Nombre = "Té",
                    Descripcion = "Té verde orgánico",
                    Precio = 1.50m,
                    Stock = 30,
                    estado = true
                });


                listaProductos.Add(new capa_entidades.Producto
                {
                    Id = 2,
                    Nombre = "Capuccino",
                    Descripcion = "Galleta Oreo",
                    Precio = 1.50m,
                    Stock = 30,
                    estado = true
                });
                listaProductos.Add(new capa_entidades.Producto
                {
                    Id = 3,
                    Nombre = "Chocolate Caliente",
                    Descripcion = "Chocolate con malvaviscos",
                    Precio = 2.00m,
                    Stock = 20,
                    estado = true
                });
            }
            //metodo para refrescar 
            RefrescarListaProductos();
        }
        //metodo para refrescar la lista de productos en el datagridview
        private void RefrescarListaProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaProductos;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //VALIDACION BASICA
            if (string.IsNullOrWhiteSpace(txtNombre.Text))


            {
                MessageBox.Show(" El nombre es obligatorio.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Validaciones.EsDecimal(txtPrecio.Text))
            {
                MessageBox.Show(" El precio debe ser un valor decimal.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Validaciones.EsEntero(txtStock.Text))
            {
                MessageBox.Show("Stock invalido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            //Crear nuevo producto
            int nuevoId = listaProductos.Any() ? listaProductos.Max(x => x.Id) + 1 : 1;
            var p = new Producto
            {
                Id = nuevoId,
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Precio = decimal.Parse(txtPrecio.Text.Trim()),
                Stock = int.Parse(txtStock.Text.Trim()),
                estado = chkEstado.Checked
            };
            listaProductos.Add(p);
            MessageBox.Show("Producto agregado exitosamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarListaProductos();
            //limpiar los controles
            LimpiarCampos();
        }

        //metodo para limpiar los controles

        private void LimpiarCampos()
            {
            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            chkEstado.Checked = false;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Mostrar detalles del producto seleccionado en los controles
            if (dgvProductos.CurrentRow == null) return;
            txtId.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            txtPrecio.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
            txtStock.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();
            chkEstado.Checked =
                Convert.ToBoolean(dgvProductos.CurrentRow.Cells[5].Value);

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Eliminar producto seleccionado
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Seleccione un producto válido para eliminar.",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var prod = listaProductos
                .FirstOrDefault(x => x.Id == id);
            if (prod==null)
            {
                MessageBox.Show("Producto no encontrado"); return;
            }
            if (MessageBox.Show("¿Está seguro de eliminar el producto seleccinado " +
                prod.Nombre + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listaProductos.Remove(prod);
                MessageBox.Show("Producto eliminado exitosamente.",
                    "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefrescarListaProductos();
                LimpiarCampos();



            }

           
            }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //validar que el ID sea correcto
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Seleccione un producto válido para editar.",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var prod = listaProductos
                .FirstOrDefault(x => x.Id == id);
            if (prod == null)
                {
                MessageBox.Show("Producto no encontrado"); return;
            }
            //VALIDACION BASICA
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(" El nombre es obligatorio.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Validaciones.EsDecimal(txtPrecio.Text))
            {
                MessageBox.Show(" El precio debe ser un valor decimal.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Validaciones.EsEntero(txtStock.Text))
            {
                MessageBox.Show("Stock invalido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Actualizar producto
            prod.Nombre = txtNombre.Text.Trim();
            prod.Descripcion = txtDescripcion.Text.Trim();
            prod.Precio = decimal.Parse(txtPrecio.Text.Trim());
            prod.Stock = int.Parse(txtStock.Text.Trim());
            prod.estado = chkEstado.Checked;


        }
    }
    }
    





























