using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
namespace Negocio
{
    public class NegocioMarca
    {


        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            Marca aux;

            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source=DESKTOP-C6O1D33\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "select Id,Descripcion from MARCAS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    aux = new Marca();
                    aux.Id = lector.GetInt32(0);
                    aux.Descripcion = lector.GetString(1);


                    lista.Add(aux);
                }

                return lista;
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
