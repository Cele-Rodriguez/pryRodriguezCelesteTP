using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using System.Linq.Expressions;

namespace pryRodriguezCelesteTP
{
    public partial class frmRegistroEmpleados : Form
    {
       // clsAccesoClases objBaseDatos;

        public frmRegistroEmpleados()
        {
            InitializeComponent();
        }

        private void frmRegistroEmpleados_Load(object sender, EventArgs e)
        {
            clsAccesoClases objBaseDatos = new clsAccesoClases();

            objBaseDatos.ConectarBD();

            lblEstadoConexion.Text = objBaseDatos.estadoConexion;
        }
    }
}
