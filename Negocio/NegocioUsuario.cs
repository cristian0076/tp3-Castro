using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
namespace Negocio
{
    public class NegocioUsuario
    {


        public int Ingresar(Usuario aux)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            Usuario datos = new Usuario();
            try
            {
                conexion.ConnectionString = "data source=DESKTOP-C6O1D33\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "select Usuario,Clave from USUARIOS where Usuario='" + aux.User + "' and Clave='" + aux.Clave + "'";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {


                    datos.User = lector.GetString(0);
                    datos.Clave = lector.GetString(1);


                }

                if (aux.User == datos.User && aux.Clave == datos.Clave)
                {

                    return 1;
                }

                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }



        }


        public void status(int e)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = "data source=DESKTOP-C6O1D33\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;
                if(e == 1)
                {
                    comando.CommandText = "UPDATE USUARIOS SET estado = 1; ";
                }
                else
                {
                    comando.CommandText = "UPDATE USUARIOS SET estado = 0; ";
                }


                
                comando.Parameters.Clear();

                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        public int Validar()
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            Usuario datos = new Usuario();
            try
            {
                conexion.ConnectionString = "data source=DESKTOP-C6O1D33\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "select distinct estado from USUARIOS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    datos.Estado = lector.GetByte(0);
                }

                if (datos.Estado == 1 )
                {

                    return 1;
                }

                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }



        }

    }
}
