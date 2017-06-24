using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gato.CustomExceptions;

namespace Gato
{
    class Gato
    {
        public string[,] TablaDeJuego { get; private set; }
        public Jugador Jugador1 { get; private set; }
        public Jugador Jugador2 { get; private set; }

        public Gato(Jugador jugador1, Jugador jugador2)
        {
            if (jugador1 == null)
            {
                throw new PlayerNullException(1)
            }

            TablaDeJuego = new string[3, 3];
            Jugador1 = jugador1;
            Jugador2 = jugador2;
        }


    }
}
