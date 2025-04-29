using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ofima.Pildoras.VisorERP
{
    public class AccesoSQL
    {


        /// <summary>
        /// Permite ejecutar una sentencia de SQL
        /// </summary>
        /// <param name="querySQL"></param>
        /// <returns></returns>
        public static System.Data.DataTable EjecutarQuery(string querySQL)
        {
            //Crear conexion SQL
            string cadenaConexionSQL = ConfigurationManager.ConnectionStrings["OfimaBotEntities"].ConnectionString;
            EntityConnection conexionEF = new EntityConnection(cadenaConexionSQL);
            SqlConnection conexionSQL = new SqlConnection(conexionEF.StoreConnection.ConnectionString);

            SqlCommand cmd = new SqlCommand(querySQL, conexionSQL);

            DataTable dtResultado = new DataTable();

            try
            {
                conexionSQL.Open();

                dtResultado.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexionSQL.Close();
            }


            return dtResultado;
        }




        /// <summary>
        /// Ejecutar Query con parametros dados
        /// </summary>
        /// <param name="querySQL"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public static DataTable EjecutarQuery(string querySQL, Dictionary<string, object> parametros)
        {
            //Crear conexion SQL
            string cadenaConexionSQL = ConfigurationManager.ConnectionStrings["NotiOfimaEntities"].ConnectionString;
            EntityConnection conexionEF = new EntityConnection(cadenaConexionSQL);
            SqlConnection conexionSQL = new SqlConnection(conexionEF.StoreConnection.ConnectionString);

            SqlCommand cmd = new SqlCommand(querySQL, conexionSQL);


            //Adicionar los parametros al origen de datos
            if (parametros != null)
            {
                foreach (KeyValuePair<string, object> objParam in parametros)
                {
                    SqlParameter param = new SqlParameter(objParam.Key, objParam.Value);
                    cmd.Parameters.Add(param);
                }
            }


            DataTable dtResultado = new DataTable();

            try
            {
                conexionSQL.Open();

                dtResultado.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexionSQL.Close();
            }

            return dtResultado;
        }



        /// <summary>
        /// Ejecutar Query con parametros dados
        /// y recibe un string de conexion 
        /// </summary>
        public static DataTable EjecutarQuery(string querySQL, Dictionary<string, object> parametros, string conexionDataBase)
        {
            //Crear conexion SQL
            SqlConnection conexionSQL = new SqlConnection(conexionDataBase);

            SqlCommand cmd = new SqlCommand(querySQL, conexionSQL);


            //Adicionar los parametros al origen de datos
            if (parametros != null)
            {
                foreach (KeyValuePair<string, object> objParam in parametros)
                {
                    SqlParameter param = new SqlParameter(objParam.Key, objParam.Value);
                    cmd.Parameters.Add(param);
                }
            }


            DataTable dtResultado = new DataTable();

            try
            {
                conexionSQL.Open();

                dtResultado.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexionSQL.Close();
            }

            return dtResultado;
        }


        /// <summary>
        /// Ejecutar Query con parametros dados
        /// y recibe un string de conexion
        /// envia objeto tranasccion
        /// </summary>
        public static DataTable EjecutarQuery(string querySQL, Dictionary<string, object> parametros, SqlConnection conexionSQL, SqlTransaction transaccion)
        {

            SqlCommand cmd = new SqlCommand(querySQL, conexionSQL, transaccion);

            //Adicionar los parametros al origen de datos
            if (parametros != null)
            {
                foreach (KeyValuePair<string, object> objParam in parametros)
                {
                    SqlParameter param = new SqlParameter(objParam.Key, objParam.Value);
                    cmd.Parameters.Add(param);
                }
            }


            DataTable dtResultado = new DataTable();

            try
            {

                dtResultado.Load(cmd.ExecuteReader());

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return dtResultado;
        }



        /// <summary>
        /// Ejecutar SP con parametros dados retorna datos
        /// </summary>
        /// <param name="comandoSQL"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public static DataTable EjecutarSP(string comandoSQL, Dictionary<string, object> parametros)
        {
            //Crear conexion SQL
            string cadenaConexionSQL = ConfigurationManager.ConnectionStrings["NotiOfimaEntities"].ConnectionString;
            EntityConnection conexionEF = new EntityConnection(cadenaConexionSQL);
            SqlConnection conexionSQL = new SqlConnection(conexionEF.StoreConnection.ConnectionString);

            SqlCommand comandoEjecutar = new SqlCommand(comandoSQL, conexionSQL);
            comandoEjecutar.CommandType = CommandType.StoredProcedure;

            //Adicionar los parametros al origen de datos
            if (parametros != null)
            {
                foreach (KeyValuePair<string, object> objParam in parametros)
                {
                    SqlParameter param = new SqlParameter(objParam.Key, objParam.Value);
                    comandoEjecutar.Parameters.Add(param);
                }
            }

            DataTable dtResultado = new DataTable();

            try
            {
                conexionSQL.Open();

                dtResultado.Load(comandoEjecutar.ExecuteReader());
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexionSQL.Close();
            }


            return dtResultado;
        }


        /// <summary>
        /// Ejecutar SP con parametros dados retorna datos
        /// recibe el string de conexion de la data base
        /// </summary>
        public static DataTable EjecutarSP(string comandoSQL, Dictionary<string, object> parametros, string conexionDataBase)
        {
            //Crear conexion SQL
            SqlConnection conexionSQL = new SqlConnection(conexionDataBase);

            SqlCommand comandoEjecutar = new SqlCommand(comandoSQL, conexionSQL);
            comandoEjecutar.CommandType = CommandType.StoredProcedure;

            //Adicionar los parametros al origen de datos
            if (parametros != null)
            {
                foreach (KeyValuePair<string, object> objParam in parametros)
                {
                    SqlParameter param = new SqlParameter(objParam.Key, objParam.Value);
                    comandoEjecutar.Parameters.Add(param);
                }
            }

            DataTable dtResultado = new DataTable();

            try
            {
                conexionSQL.Open();

                dtResultado.Load(comandoEjecutar.ExecuteReader());
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexionSQL.Close();
            }



            return dtResultado;
        }

        /// <summary>
        /// Ejecutar SP con parametros dados retorna datos
        /// recibe el string de conexion de la data base
        /// </summary>
        public static DataTable EjecutarSP(string comandoSQL, Dictionary<string, object> parametros, SqlConnection conexionSQL, SqlTransaction transaccion)
        {

            SqlCommand comandoEjecutar = new SqlCommand(comandoSQL, conexionSQL, transaccion);
            comandoEjecutar.CommandType = CommandType.StoredProcedure;

            //Adicionar los parametros al origen de datos
            if (parametros != null)
            {
                foreach (KeyValuePair<string, object> objParam in parametros)
                {
                    SqlParameter param = new SqlParameter(objParam.Key, objParam.Value);
                    comandoEjecutar.Parameters.Add(param);
                }
            }

            DataTable dtResultado = new DataTable();

            try
            {
                dtResultado.Load(comandoEjecutar.ExecuteReader());
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }




            return dtResultado;
        }


    }
}
