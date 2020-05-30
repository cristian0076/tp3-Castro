using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
namespace Negocio
{
    public class NegocioArticulo
    {

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            Articulo aux;

            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source=DESKTOP-C6O1D33\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "select Codigo,Nombre,A.Descripcion,M.Descripcion,C.Descripcion,precio,ImagenUrl,A.Id from ARTICULOS As A inner join CATEGORIAS As C ON C.Id = A.IdCategoria inner join MARCAS As M ON M.Id = A.IdMarca";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    aux = new Articulo();
                    aux.codigo = lector.GetString(0);
                    aux.nombre = lector.GetString(1);
                    aux.descripcion = lector.GetString(2);
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Marca.Descripcion = lector.GetString(3);
                    aux.Categoria.Descripcion = lector.GetString(4);
                    aux.precio = lector.GetDecimal(5);
                    aux.imagen = lector.GetString(6);
                    aux.ID = lector.GetInt32(7);

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

        public Articulo BuscarPorArticulo(Articulo aux)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source=DESKTOP-C6O1D33\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "select Codigo,Nombre,Descripcion,IdMarca,IdCategoria,precio,ImagenUrl from ARTICULOS where Codigo='" + aux.codigo + "'";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    aux.nombre = lector.GetString(1);
                    aux.descripcion = lector.GetString(2);
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Marca.Id = lector.GetInt32(3);
                    aux.Categoria.Id = lector.GetInt32(4);
                    aux.precio = lector.GetDecimal(5);
                    aux.imagen = lector.GetString(6);


                }

                return aux;
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



        public List<Articulo> listarPorDescripcion(string descripcion)
        {
            List<Articulo> lista = new List<Articulo>();

            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            Articulo aux;
            try
            {
                conexion.ConnectionString = "data source=DESKTOP-C6O1D33\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "select distinct Nombre,Codigo from articulos where Descripcion Like '%" + descripcion + "%'";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    aux = new Articulo();

                    aux.nombre = lector.GetString(0);
                    aux.codigo = lector.GetString(1);

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



        public void agregar(Articulo aux)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = "data source=DESKTOP-C6O1D33\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;
                comando.CommandText = "Insert into ARTICULOS values ('" + aux.codigo + "','" + aux.nombre + "','" + aux.descripcion + "','" + aux.Marca.Id + "','" + aux.Categoria.Id + "','" + aux.imagen + "','" + aux.precio + "')";
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



        public void ModificarArticulo(Articulo aux, string codigo)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();


            try
            {


                conexion.ConnectionString = "data source=DESKTOP-C6O1D33\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;
                comando.CommandText = "update ARTICULOS set Codigo = '" + aux.codigo + "',Nombre = '" + aux.nombre + "',Descripcion = '" + aux.descripcion + "',IdMarca = '" + aux.Marca.Id + "',IdCategoria = '" + aux.Categoria.Id + "',ImagenUrl = '" + aux.imagen + "',Precio = '" + aux.precio + "' where Codigo = '" + codigo + "'";
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


        public void EliminarArticulo(Articulo aux)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();


            try
            {


                conexion.ConnectionString = "data source=DESKTOP-C6O1D33\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;
                comando.CommandText = "delete ARTICULOS where Codigo='" + aux.codigo + "'";
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



        public List<Articulo> ArticuloDetalle()
        {
            List<Articulo> lista = new List<Articulo>();

            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            Articulo aux;

            try
            {
                conexion.ConnectionString = "data source=DESKTOP-C6O1D33\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "select Codigo,Nombre,Articulos.Descripcion,M.descripcion as Marca ,C.Descripcion as Categoria,ARTICULOS.Precio,ARTICULOS.ImagenUrl from ARTICULOS inner join MARCAS as M on M.Id=ARTICULOS.IdMarca inner join CATEGORIAS as C on C.Id=ARTICULOS.IdCategoria";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    aux = new Articulo();

                    aux.codigo = lector.GetString(0);
                    aux.nombre = lector.GetString(1);
                    aux.descripcion = lector.GetString(2);
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Marca.Descripcion = lector.GetString(3);
                    aux.Categoria.Descripcion = lector.GetString(4);
                    aux.precio = lector.GetDecimal(5);
                    aux.imagen = lector.GetString(6);

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
