using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        private int id;
        private string Codigo;
        private string Nombre;
        private string Descripcion;
        private Marca marca;
        private Categoria categoria;
        private string Imagen;
        private decimal Precio;

        public int ID { get => id; set => id = value; }
        public Categoria Categoria { get => categoria; set => categoria = value; }
        public Marca Marca { get => marca; set => marca = value; }
        public string codigo { get => Codigo; set => Codigo = value; }
        public string descripcion { get => Descripcion; set => Descripcion = value; }


        public string nombre { get => Nombre; set => Nombre = value; }
        public string imagen { get => Imagen; set => Imagen = value; }
        public decimal precio { get => Precio; set => Precio = value; }

        public Articulo()
        {

        }



        public override string ToString()
        {
            return Nombre;

        }
    }
}