﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gato
{
    class Jugador
    {
        public string Nombre { get; set; }
        public int Puntaje { get; private set; }

        public Jugador (string nombre)
        {
            Nombre = nombre;
        }
    }
}
