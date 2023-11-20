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

        public void TraerDatos(DataGridView grilla)
        {
            comandoBD = new OleDbCommand();
            //lectorBD = new OleDbDataReader();
            try
            {
                comandoBD.Connection = conexionBD; //vinculo comando con conexion 
                comandoBD.CommandType = System.Data.CommandType.TableDirect; // el tipo de accion (traer tabla)
                comandoBD.CommandText = "APELLIDO"; // nombre de la tabla que ejecuta la accion 

                lectorBD = comandoBD.ExecuteReader(); //extraer tabla socios y meter dentro del lectorBD

                while (lectorBD.Read())
                {
                    grilla.Rows.Add(lectorBD[1], lectorBD[2], lectorBD[7]);
                }
            }

            catch (Exception ex)
            {
                Errores = ex.Message;
            }
        }

        public void TraerDatosDataSet(DataGridView grilla)
        {
            try
            {
                ConectarBD();  // Abre la conexión

                comandoBD = new OleDbCommand();
                comandoBD.Connection = conexionBD; // Vincula el comando con la conexión 
                comandoBD.CommandType = CommandType.Text; // Establece el tipo de comando (consulta SQL)

                // Define la consulta SQL para seleccionar todos los datos de la tabla "DATOS PERSONALES"
                comandoBD.CommandText = "SELECT * FROM [DPERSONALES]";

                AdaptadorDS = new OleDbDataAdapter(comandoBD);
                AdaptadorDS.Fill(objDataSet);  // Llena el conjunto de datos con los resultados de la consulta

                if (objDataSet.Tables["DPERSONALES"].Rows.Count > 0)
                {
                    // Agrega las columnas a la DataGridView
                    grilla.Columns.Add("CODIGO", "CODIGO");
                    grilla.Columns.Add("Nombre", "Nombre");
                    grilla.Columns.Add("Apellido", "Apellido");

                    // Agrega las filas a la DataGridView utilizando el conjunto de datos
                    foreach (DataRow fila in objDataSet.Tables["DPERSONALES"].Rows)
                    {
                        grilla.Rows.Add(fila["CODIGO"], fila["Nombre"], fila["Apellido"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Errores = ex.Message;
            }
            finally
            {
                if (conexionBD.State == ConnectionState.Open)
                {
                    conexionBD.Close();  // Cierra la conexión si está abierta
                }
            }
        }
        

        public void FiltrarPorCiudad(DataGridView dataGridView, string idIngresado)
        {
            if (!string.IsNullOrEmpty(idIngresado))
            {
                try
                {
                    ConectarBD();

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
                    ConectarBD();

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
                MessageBox.Show("Por favor, ingresa un ID antes de filtrar.");
            }
        }

    }
}
