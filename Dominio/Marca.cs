using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        int id;
        string descripcion;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public override string ToString()
        {

            return Id.ToString();
        }

    }

}