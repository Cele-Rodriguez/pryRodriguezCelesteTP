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

        public void TraerDatosDataSet(DataGridView grilla)
        {
            try
            {
                ConectarBD();
                comandoBD = new OleDbCommand();
                comandoBD.Connection = conexionBD; //vinculo comando con conexion 
                comandoBD.CommandType = System.Data.CommandType.TableDirect; // el tipo de accion (traer tabla)
                comandoBD.CommandText = "DATOS PERSONALES"; // nombre de la tabla que ejecuta la accion 

                AdaptadorDS = new OleDbDataAdapter(comandoBD);
                AdaptadorDS.Fill(objDataSet);

                if (objDataSet.Tables["DATOS PERSONALES"].Rows.Count > 0)
                {
                    grilla.Columns.Add("CODIGO", "CODIGO");
                    grilla.Columns.Add("Nombre", "Nombre");
                    grilla.Columns.Add("Apellido", "Apellido");
                    foreach (DataRow fila in objDataSet.Tables[0].Rows)
                    {

                    }


                }

            }
            catch (Exception ex)
            {
                Errores = ex.Message;

            }
        }

        public void FiltrarPorCiudad(DataGridView dataGridView, string idIngresado)
        {
            if (!string.IsNullOrEmpty(idIngresado))
            {
                try
                {
                    // Define la consulta parametrizada
                    string consulta = "SELECT * FROM DPERSONALES WHERE CIUDAD = @Id";

                    using (OleDbCommand comando = new OleDbCommand(consulta, conexionBD))
                    {
                        // Agrega el parámetro a la consulta
                        comando.Parameters.AddWithValue("@Id", idIngresado);

                        // Crea un adaptador de datos y un conjunto de datos
                        using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando))
                        {
                            // Crea un nuevo conjunto de datos
                            DataSet dataSet = new DataSet();

                            // Llena el conjunto de datos con los resultados de la consulta
                            adaptador.Fill(dataSet, "DPERSONALES");



                            // Asigna el conjunto de datos a la DataGridView
                            dataGridView.DataSource = dataSet.Tables["DPERSONALES"];
                        }
                    }
                }

                catch (OleDbException ex)
                {
                    MessageBox.Show("Error al acceder a la base de datos: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Por favor, ingresa una ciudad antes de filtrar.");
            }
        }
        public void FiltrarApellido(DataGridView dataGridView, string idIngresado)
        {
            if (!string.IsNullOrEmpty(idIngresado))
            {
                try
                {
                    // Define la consulta parametrizada
                    string consulta = "SELECT * FROM DATOS PERSONALES WHERE APELLIDO = @Id";

                    using (OleDbCommand comando = new OleDbCommand(consulta, conexionBD))
                    {
                        // Agrega el parámetro a la consulta
                        comando.Parameters.AddWithValue("@Id", idIngresado);

                        // Crea un adaptador de datos y un conjunto de datos
                        using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando))
                        {
                            // Crea un nuevo conjunto de datos
                            DataSet dataSet = new DataSet();

                            // Llena el conjunto de datos con los resultados de la consulta
                            adaptador.Fill(dataSet, "DATOS PERSONALES");



                            // Asigna el conjunto de datos a la DataGridView
                            dataGridView.DataSource = dataSet.Tables["DATOS PERSONALES"];
                        }
                    }

                }

                catch (OleDbException ex)
                {
                    MessageBox.Show("Error al acceder a la base de datos: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Por favor, ingresa un ID antes de filtrar.");
            }
        }

    }
}
