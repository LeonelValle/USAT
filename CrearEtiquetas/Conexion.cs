using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearEtiquetas
{
    class Conexion
    {
        private System.Data.SqlClient.SqlConnection Con; // Obj Conexion


        public Conexion() =>
        Con1 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MWTrace;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        //Con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDb"].ConnectionString);
        public SqlConnection Con1 { get => Con; set => Con = value; }

        public void CadenaConexion(String comando)
        {
            if (comando == null)
            {
                throw new ArgumentNullException(nameof(comando));
            }

            string conexion;

            conexion = ReturnValue("select conexion from ConfiguracionSistema where id_cs = 7");

            SqlConnection con = new SqlConnection("@" + conexion);
            Con1 = con;

        }

        /// <summary>
        /// Metodo para abrir la conexion con la base de datos
        /// </summary>
        public void Abrir() // Metodo para Abrir la Conexion
        {
            Con1.Open();
        }
        /// <summary>
        /// Metodo para cerrar la conexion con la base de datos
        /// </summary>
        public void Cerrar() // Metodo para Cerrar la Conexion
        {
            Con1.Close();
        }

        /// <summary>
        /// Metodo para llenar una DATAGRIDVIEW
        /// </summary>
        /// <param name="Comando"></param>
        /// <returns></returns>
        public DataSet LlenarDG(string Comando) // Metodo para Ejecutar Comandos
        {
            Abrir();
            SqlDataAdapter CMD = new SqlDataAdapter(Comando, Con1); // Creamos un DataAdapter con el Comando y la Conexion

            DataSet DS = new DataSet(); // Creamos el DataSet que Devolvera el Metodo

            CMD.Fill(DS); // Ejecutamos el Comando en la Tabla
            Cerrar();
            return DS; // Regresamos el DataSet
        }

        /// <summary>
        /// Metodo que regresa un valor dependiendo si se encontro en la base de datos, si no es asi regresa 0
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public string ReturnValue(string comando)
        {
            string valor;
            try
            {
                SqlCommand CMD = new SqlCommand(comando, Con1);
                Abrir();
                CMD.ExecuteNonQuery();
                valor = CMD.ExecuteScalar().ToString();
                if (valor == "")
                    valor = "0";
            }
            catch (Exception)
            {

                valor = "0";
            }
            Cerrar();
            return valor;
        }

        /// <summary>
        /// Metodo parar altas, baja, consultas y modificaciones
        /// </summary>
        /// <param name="comando"></param>
        public void Crud(string comando)
        {
            SqlCommand cmd = new SqlCommand(comando, Con1);
            Abrir();
            cmd.ExecuteNonQuery();
            Cerrar();
        }

        /// <summary>
        /// Metodo para leer y comparar los registros con la base de datos
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public SqlDataReader Leer(string comando)
        {
            SqlCommand cmd = new SqlCommand(comando, Con1);
            Abrir();
            SqlDataReader leer = cmd.ExecuteReader();
            return leer;
        }

        /// <summary>
        /// Metodo para llenar un   COMBOBOX
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public DataTable LlenarComboBox(string comando)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(comando, Con1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        /// <summary>
        /// Metodo para Leer los datos de la Base de Datos
        /// </summary>
        /// <param name="query"></param>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public DataView Leer_Datos(string query, string tabla)
        {
            DataSet res = new DataSet();

            try
            {
                SqlCommand cmd = new SqlCommand(query, Con1);
                Abrir();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(res, tabla);
                da.Dispose();
                Cerrar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ((DataTable)res.Tables["tb_ModeloOrden.id_modeloOrden, tb_ModeloOrden.scanmodem, tb_ModeloOrden.scansim , tb_ModeloOrden.fecharegistro, tb_ModeloOrden.id_orden , tb_Orden.orden, tb_caja.caja , tb_pallette.pellette, tb_pallette.id_pellette"]).DefaultView;
        }

        /// <summary>
        /// Metodo Para saber si ya existe un registro
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public bool Existe(string comando)
        {
            Cerrar();
            SqlCommand cmd = new SqlCommand(comando, Con1);
            Abrir();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            Cerrar();
            if (count == 0)
                return false;
            else
                return true;
        }




    } // Fin de la Clase
}

