using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gato.CustomExceptions
{
    class PlayerNullException : Exception
    {
        public PlayerNullException(int numero):base("El objeto jugador" + numero + " no puede estar nulo")
        {
        }
    }
}
