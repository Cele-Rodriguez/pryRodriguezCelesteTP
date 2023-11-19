using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRodriguezCelesteTP
{
    public partial class frmListarEmpleados : Form
    {
        public frmListarEmpleados()
        {
            InitializeComponent();

        }

        clsAccesoClases objAccesoBD = new clsAccesoClases();
  
        private void ListarEmpleados_Load(object sender, EventArgs e)
        {
            clsAccesoClases objBaseDatos = new clsAccesoClases();

            objBaseDatos.ConectarBD();

            lblEstadoConexion.Text = objBaseDatos.estadoConexion;
        }
        private void btnApellido_Click(object sender, EventArgs e)
        {

            objAccesoBD.FiltrarApellido(dgvMostrar, txtApellido.Text);

        }
        

        private void btnCiudad_Click(object sender, EventArgs e)
        {
            objAccesoBD.FiltrarPorCiudad(dgvMostrar, txtCiudad.Text);

        }
    }
}
