using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {


        private int id;
        private string descripcion;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public Categoria() { }

        public Categoria(int ID, string Desc)
        {
            Id = ID;
            Descripcion = Desc;
        }

        public override string ToString()
        {

            return Id.ToString();
        }

    }
}
