using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows.Forms;
using System.Linq.Expressions;


namespace pryRodriguezCelesteTP
{
        public class clsAccesoClases
        { //declaro
            OleDbConnection conexionBD;
            OleDbCommand comandoBD;
            OleDbDataReader lectorBD;

            public string cadenaConexion;
            public string estadoConexion;
            public string Errores;

            OleDbDataAdapter AdaptadorDS;
            DataSet objDataSet = new DataSet();
            public void ConectarBD()
            {
                cadenaConexion = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source=../../BaseDatos/EMPLEADO.accdb";
                try
                {

                    conexionBD = new OleDbConnection(); //instancio en memoria
                    conexionBD.ConnectionString = cadenaConexion; //donde esta la conexion
                    conexionBD.Open(); //abre base de datos
                    estadoConexion = "Conectado";
                }
                catch (Exception ex)
                {
                    estadoConexion = "Error:" + ex.Message + "\nRuta: " + System.IO.Path.GetFullPath("../../BaseDatos/EMPLEADO.accdb");
                }
            }
        }
    
}
