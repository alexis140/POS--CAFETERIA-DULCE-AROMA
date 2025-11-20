using POS__CAFETERIA_DULCE_AROMA.capa_entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS__CAFETERIA_DULCE_AROMA.capa_presentaciom;

namespace POS__CAFETERIA_DULCE_AROMA.capa_presentaciom
{
    public partial class FrmClientes : Form
    {
        // Agrega este campo en la clase FrmClientes para definir chkEstado
        private CheckBox chkEstado;
        // Agrega este campo en la clase FrmClientes para definir txtBuscar
        private TextBox txtBuscar;

        // Nueva lista enlazable para que el DataGridView se actualice automáticamente
        private BindingList<Clientes> clientesList;

        public FrmClientes()
        {
            InitializeComponent();
            // NOTA: Se ha eliminado la inicialización automática de chkEstado
            // para que no aparezca como activo. Lo agregarás manualmente cuando lo necesites.

            // Inicializa txtBuscar si no está en el diseñador
            if (txtBuscar == null)
            {
                txtBuscar = new TextBox
                {
                    Name = "txtBuscar",
                    Location = new Point(10, 40), // Ajusta la ubicación según tu diseño
                    Width = 200
                };
                this.Controls.Add(txtBuscar);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            // Inicializa la lista enlazable y vincúlala al DataGridView
            clientesList = new BindingList<Clientes>
            {
                new Clientes
                {
                    Codigo = 1,
                    Nombre = "Alexander Lopez",
                    Telefono = "555-1234",
                    Direccion = "Calle Falsa 123",
                    Correo = "Alexanderlopez76@gmail.com"
                },
                new Clientes
                {
                    Codigo = 2,
                    Nombre = "RosarioGuevara",
                    Telefono = "555-1237",
                    Direccion = "Calle 123 ",
                    Correo = "RosarioGrv76@gmail.com"
                },
                new Clientes
                {
                    Codigo = 3,
                    Nombre = "MiguelVazquez",
                    Telefono = "555-5678",
                    Direccion = "Avenida Siempre Viva 742",
                    Correo = "MiguelVasquez32@gmail.com"
                }
            };

            // Configuración del DataGridView
            dgvClientes.AutoGenerateColumns = true;
            dgvClientes.DataSource = clientesList;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //validacion Basica
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCorreo.Text.Contains("@"))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtTelefono.Text.All(char.IsDigit))
            {
                MessageBox.Show("El teléfono debe contener solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("¿Está seguro de agregar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Lógica para agregar el nuevo cliente directamente a la lista enlazable
                Clientes nuevoCliente = new Clientes
                {
                    Codigo = (clientesList.Count > 0) ? clientesList.Max(c => c.Codigo) + 1 : 1,
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Correo = txtCorreo.Text,
                    Estado = (chkEstado != null) && chkEstado.Checked
                };

                clientesList.Add(nuevoCliente);

                MessageBox.Show("Cliente agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Limpiar los campos después de agregar
                txtNombre.Clear();
                txtTelefono.Clear();
                txtDireccion.Clear();
                txtCorreo.Clear();
                if (chkEstado != null) chkEstado.Checked = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de guardar los cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Lógica para guardar los cambios del cliente
                MessageBox.Show("Cambios guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Por favor, ingrese un término de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Lógica para buscar clientes por nombre o correo
            if (MessageBox.Show("¿Está seguro de buscar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Aquí se realizaría la búsqueda en la base de datos o lista
                MessageBox.Show("Búsqueda realizada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Por favor, ingrese un término de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Lógica para eliminar el cliente seleccionado
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var cliente = dgvClientes.CurrentRow.DataBoundItem as Clientes;
                if (cliente != null)
                {
                    clientesList.Remove(cliente);
                    MessageBox.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Limpiar los campos después de eliminar
                    txtNombre.Clear();
                    txtTelefono.Clear();
                    txtDireccion.Clear();
                    txtCorreo.Clear();
                    if (chkEstado != null) chkEstado.Checked = false;
                }
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Mostrar datos del cliente seleccionado en los controles
            if (e.RowIndex >= 0 && dgvClientes.Rows[e.RowIndex].DataBoundItem is Clientes seleccionado)
            {
                txtNombre.Text = seleccionado.Nombre;
                txtTelefono.Text = seleccionado.Telefono;
                txtDireccion.Text = seleccionado.Direccion;
                txtCorreo.Text = seleccionado.Correo;
                if (chkEstado != null) chkEstado.Checked = seleccionado.Estado;
            }
        }
        //metodo para refrescar datos en el datagridview
        private void RefrescarDatos()
        {
            // Si se usa BindingList no hace falta recargar manualmente, pero mantenemos el método por compatibilidad
            dgvClientes.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Ahora el botón agrega directamente al DataGridView usando la misma lógica que btnNuevo
            // (puedes llamar a btnNuevo_Click si prefieres reutilizar)
            btnNuevo_Click(sender, e);
        }

        private void cboActivo_CheckedChanged(object sender, EventArgs e)
        {
            // Lógica para filtrar clientes activos/inactivos
            if (clientesList == null) return;
            if (chkEstado != null && chkEstado.Checked)
            {
                dgvClientes.DataSource = new BindingList<Clientes>(clientesList.Where(c => c.Estado).ToList());
            }
            else
            {
                dgvClientes.DataSource = clientesList;

            }
        }
    }
}


