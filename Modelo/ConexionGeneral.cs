using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Modelo
{
    public class ConexionGeneral
    {
        #region Declaracion de Variables 
        SqlConnection cnnConexion = null;
        SqlCommand cmdComando = null;
        SqlDataAdapter daAdaptador = null;
        DataTable Dtt = null;
        String CadenaConexion = string.Empty;
  
        #endregion

        #region Constructor
        public ConexionGeneral()
        {  CadenaConexion = @"Data Source=10.31.40.219\SQLEXPRESS2014;Initial Catalog=ComplianceConnected;User ID=sa;Password=harman123*;Application Name=MexicoCustomsComplianceConnected";
        }
        #endregion

        #region Metodos a Ejecutar

        public bool EjecutaProcedimientos(string parSPName, Boolean IsProcedure)
        {
            bool IsEjecutado = false;
            try
            {
                //Instanciamos el objeto conexion con la cadena de conexion
                cnnConexion = new SqlConnection(CadenaConexion);
                //Instanciamos el objeto comando con el TSQL y conexion a utilizar.
                cmdComando = new SqlCommand(); //
                cmdComando.Connection = cnnConexion;
                //Abrimos la conexion
                cnnConexion.Open();
                if (IsProcedure)
                {
                    //Asignamos el tipo de comando o ejecutar.
                    //cmdComando.CommandType = CommandType.StoredProcedure;
                    cmdComando.CommandType = CommandType.StoredProcedure;
                    //Agregamos el nombre de SProcedure
                    cmdComando.CommandText = parSPName;
                    //Agregamos los parametros a ejecutar
                    //cmdComando.Parameters.AddRange(parParametros);
                }
                else
                {
                    //Asignamos el tipo de comando o ejecutar.
                    cmdComando.CommandType = CommandType.Text;
                    //Agregamos la consulta
                    cmdComando.CommandText = parSPName;

                }
                cmdComando.CommandTimeout = 3600;
                //Ejecutamos el TSQL en el Servidor.
                cmdComando.ExecuteNonQuery();
                IsEjecutado = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
            }
            return IsEjecutado;
        }



        public bool EjecutarSP(SqlParameter[] parParametros, string parSPName, Boolean IsProcedure)
        {
            bool IsEjecutado = false;
            try
            {
                //Instanciamos el objeto conexion con la cadena de conexion
                cnnConexion = new SqlConnection(CadenaConexion);
                //Instanciamos el objeto comando con el TSQL y conexion a utilizar.
                cmdComando = new SqlCommand(); //
                cmdComando.Connection = cnnConexion;
                //Abrimos la conexion
                cnnConexion.Open();
                if (IsProcedure)
                {
                    //Asignamos el tipo de comando o ejecutar.
                    //cmdComando.CommandType = CommandType.StoredProcedure;
                    cmdComando.CommandType = CommandType.StoredProcedure;
                    //Agregamos el nombre de SProcedure
                    cmdComando.CommandText = parSPName;
                    //Agregamos los parametros a ejecutar
                    cmdComando.Parameters.AddRange(parParametros);
                }
                else
                {
                    //Asignamos el tipo de comando o ejecutar.
                    cmdComando.CommandType = CommandType.Text;
                    //Agregamos la consulta
                    cmdComando.CommandText = parSPName;

                }
                //Ejecutamos el TSQL en el Servidor.
                cmdComando.ExecuteNonQuery();
                IsEjecutado = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
            }
            return IsEjecutado;
        }
        //METODO QUE RETORNA UNA LISTA, EJECUTANDO UN QUERY O UN PROCEDURE
        public DataTable RetornaTabla(SqlParameter[] parParametros, string parTSQL, Boolean IsProcedure)
        {
            Dtt = null;
            try
            {
                Dtt = new DataTable();
                //Instanciamos el objeto conexion con la cadena de conexion
                cnnConexion = new SqlConnection(CadenaConexion);
                //Instanciamos el objeto comando con el TSQL y conexion a utilizar.
                cmdComando = new SqlCommand(); //
                cmdComando.Connection = cnnConexion;
                //Abrimos la conexion
                cnnConexion.Open();
                if (IsProcedure)
                {
                    //Asignamos el tipo de comando o ejecutar.
                    cmdComando.CommandType = CommandType.StoredProcedure;
                    //Agregamos el nombre de SProcedure
                    cmdComando.CommandText = parTSQL;
                    //Agregamos los parametros a ejecutar
                    cmdComando.Parameters.AddRange(parParametros);
                }
                else
                {
                    //Asignamos el tipo de comando o ejecutar.
                    cmdComando.CommandType = CommandType.Text;
                    //Agregamos la consulta
                    cmdComando.CommandText = parTSQL;
                }
                //Instanciamos el Objetp Adaptador con el comando a utilizar
                daAdaptador = new SqlDataAdapter(cmdComando);

                daAdaptador.SelectCommand.CommandTimeout = 36000; //Aumenta el tiempoe de default para query de 30 seg a el n-segundos que se le indiquen

                //Llenamos el Dataset con el adaptador de datos
                daAdaptador.Fill(Dtt);
                //Ejecutamos el TSQL en el Servidor.
                //cmdComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                daAdaptador.Dispose();
            }
            return Dtt;
        }

        #endregion
        //RETORNA UN DATASET
        public DataSet Dt_Lista(SqlParameter[] parParametros, string parTSQL, Boolean IsProcedure)
        {
            DataSet dataS_Lista = new DataSet();
            try
            {
                //Instanciamos el objeto conexion con la cadena de conexion
                cnnConexion = new SqlConnection(CadenaConexion);
                //Instanciamos el objeto comando con el TSQL y conexion a utilizar.
                cmdComando = new SqlCommand(); //
                cmdComando.Connection = cnnConexion;
                //Abrimos la conexion
                cnnConexion.Open();
                if (IsProcedure)
                {
                    //Asignamos el tipo de comando o ejecutar.
                    cmdComando.CommandType = CommandType.StoredProcedure;
                    //Agregamos el nombre de SProcedure
                    cmdComando.CommandText = parTSQL;
                    //Agregamos los parametros a ejecutar
                    cmdComando.Parameters.AddRange(parParametros);
                }
                else
                {
                    //Asignamos el tipo de comando o ejecutar.
                    cmdComando.CommandType = CommandType.Text;
                    //Agregamos la consulta
                    cmdComando.CommandText = parTSQL;
                }
                //Instanciamos el Objetp Adaptador con el comando a utilizar
                daAdaptador = new SqlDataAdapter(cmdComando);
                daAdaptador.SelectCommand.CommandTimeout = 36000;
                //Llenamos el Dataset con el adaptador de datos
                daAdaptador.Fill(dataS_Lista);
                //Ejecutamos el TSQL en el Servidor.
                //cmdComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                daAdaptador.Dispose();
            }


            return dataS_Lista;
        }



        public byte[] DisplayImage(string parTSQL)
        {
            //Instanciamos el objeto conexion con la cadena de conexion
            cnnConexion = new SqlConnection(CadenaConexion);
            //Instanciamos el objeto comando con el TSQL y conexion a utilizar.
            cmdComando = new SqlCommand(); //
            cmdComando.Connection = cnnConexion;

            try
            {
                cmdComando.CommandType = CommandType.Text;
                //Agregamos la consulta
                cmdComando.CommandText = parTSQL;
                SqlDataAdapter da = new SqlDataAdapter(cmdComando);
                daAdaptador.SelectCommand.CommandTimeout = 36000;
                SqlCommandBuilder cbd = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds);
                byte[] ByteImage = (byte[])(ds.Tables[0].Rows[0]["Imagen"]);


                return ByteImage;
            }
            catch
            {
                return null;
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
            }
        }
        //RETORNA EL ID SOLICITADO
        public int ValidarProceso(string parSPName)
        {
            int ID = 0;
            try
            {
                //Instanciamos el objeto conexion con la cadena de conexion
                cnnConexion = new SqlConnection(CadenaConexion);
                //Instanciamos el objeto comando con el TSQL y conexion a utilizar.
                cmdComando = new SqlCommand(parSPName, cnnConexion); //
                cmdComando.Connection = cnnConexion;
                //Abrimos la conexion
                cnnConexion.Open();

                ID = Convert.ToInt32(cmdComando.ExecuteScalar());
                cmdComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
            }
            return ID;
        }

        //INSERTA GRIDVIEW A LA BASE DE DATOS SQL
        public DataTable CargaTablaASQL(DataTable dt, string parTSQL)
        {
            //bool OperacionOk = false;
            DataTable dataS_Lista = new DataTable();
            try
            {
                //Instanciamos el objeto conexion con la cadena de conexion
                cnnConexion = new SqlConnection(CadenaConexion);
                //Instanciamos el objeto comando con el TSQL y conexion a utilizar.
                cmdComando = new SqlCommand(); //
                cmdComando.Connection = cnnConexion;
                //Abrimos la conexion
                cnnConexion.Open();
                //Asignamos el tipo de comando o ejecutar.
                cmdComando.CommandType = CommandType.StoredProcedure;
                //Agregamos el nombre de SProcedure
                cmdComando.CommandText = parTSQL;
                //Ejecutamos el TSQL en el Servidor.
                //cmdComando.ExecuteNonQuery();
                daAdaptador = new SqlDataAdapter(cmdComando);
                daAdaptador.SelectCommand.CommandTimeout = 36000;
                //Llenamos el Dataset con el adaptador de datos
                daAdaptador.Fill(dataS_Lista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
            }
            return dataS_Lista;
        }

        //INSERTA GRIDVIEW A LA BASE DE DATOS SQL
        public DataTable CargaTablaaSQL(DataTable dt, string parTSQL, string TipoTabla)
        {
            DataTable dataS_Lista = new DataTable();
            try
            {
                //Instanciamos el objeto conexion con la cadena de conexion
                cnnConexion = new SqlConnection(CadenaConexion);
                //Instanciamos el objeto comando con el TSQL y conexion a utilizar.
                cmdComando = new SqlCommand(); //
                cmdComando.Connection = cnnConexion;
                //Abrimos la conexion
                cnnConexion.Open();

                //Asignamos el tipo de comando o ejecutar.
                cmdComando.CommandType = CommandType.StoredProcedure;
                //Agregamos el nombre de SProcedure
                cmdComando.CommandText = parTSQL;
                //Agregamos los parametros a ejecutar
                cmdComando.Parameters.AddWithValue(TipoTabla, dt);
                //Ejecutamos el TSQL en el Servidor.
                //cmdComando.ExecuteNonQuery();
                daAdaptador = new SqlDataAdapter(cmdComando);
                daAdaptador.SelectCommand.CommandTimeout = 36000;
                //Llenamos el Dataset con el adaptador de datos
                daAdaptador.Fill(dataS_Lista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
            }
            return dataS_Lista;
        }

        //INSERTA GRIDVIEW A LA BASE DE DATOS SQL
        public DataTable CargaTablaASQL_ConPlanta(DataTable dt, string Planta,string parTSQL, string TipoTabla, string TipoPlanta)
        {
            //bool OperacionOk = false;
            DataTable dataS_Lista = new DataTable();
            try
            {
                //Instanciamos el objeto conexion con la cadena de conexion
                cnnConexion = new SqlConnection(CadenaConexion);
                //Instanciamos el objeto comando con el TSQL y conexion a utilizar.
                cmdComando = new SqlCommand(); //
                cmdComando.Connection = cnnConexion;
                //Abrimos la conexion
                cnnConexion.Open();

                //Asignamos el tipo de comando o ejecutar.
                cmdComando.CommandType = CommandType.StoredProcedure;
                //Agregamos el nombre de SProcedure
                cmdComando.CommandText = parTSQL;
                //Agregamos los parametros a ejecutar
                cmdComando.Parameters.AddWithValue(TipoTabla, dt);
                cmdComando.Parameters.AddWithValue(TipoPlanta, Planta);
                //Ejecutamos el TSQL en el Servidor.
                //cmdComando.ExecuteNonQuery();
                daAdaptador = new SqlDataAdapter(cmdComando);
                daAdaptador.SelectCommand.CommandTimeout = 36000;
                //Llenamos el Dataset con el adaptador de datos
                daAdaptador.Fill(dataS_Lista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
            }
            return dataS_Lista;
        }
    }
}
