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
    public partial class ListarEmpleados : Form
    {
        public ListarEmpleados()
        {
            InitializeComponent();

        }

        
        private void btnApellido_Click(object sender, EventArgs e)
        {
          
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListarEmpleados_Load(object sender, EventArgs e)
        {
            clsAccesoClases objBaseDatos = new clsAccesoClases();

            objBaseDatos.ConectarBD();

            lblEstadoConexion.Text = objBaseDatos.estadoConexion;
        }
    }
}
