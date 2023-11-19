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
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();
        }

        private void registroDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroEmpleados frmRegistroEmpleados = new frmRegistroEmpleados();
            frmRegistroEmpleados.ShowDialog ();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {   DateTime dateTime = DateTime.Now;
            string dateString = dateTime.ToString("G");
            lblFechaHora.Text = dateString;  
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListarEmpleados frmListarEmpleados = new frmListarEmpleados();
            frmListarEmpleados .ShowDialog ();
        }
    }
}