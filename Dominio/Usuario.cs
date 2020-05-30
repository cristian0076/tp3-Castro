using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        private string user;
        private string clave;
        private byte estado;


        public string User { get => user; set => user = value; }
        public string Clave { get => clave; set => clave = value; }

        public byte Estado { get => estado; set => estado = value; }
    }
}
