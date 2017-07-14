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
        public static readonly Dictionary<string, Coordenada> Coordenadas = new Dictionary<string, Coordenada>
        {
            {"1A", new Coordenada(0,0)},
            {"1B", new Coordenada(0,1)},
            {"1C", new Coordenada(0,2)},
            {"2A", new Coordenada(1,0)},
            {"2B", new Coordenada(1,1)},
            {"2C", new Coordenada(1,2)},
            {"3A", new Coordenada(2,0)},
            {"3B", new Coordenada(2,1)},
            {"3C", new Coordenada(2,2)}
        };
        public const char P1 = 'X';
        public const char P2 = 'O';

        public char?[,] TablaDeJuego { get; private set; }
        public Jugador Jugador1 { get; private set; }
        public Jugador Jugador2 { get; private set; }
        public bool Turno { get; private set; }

        public Gato(Jugador jugador1, Jugador jugador2)
        {
            if (jugador1 == null)
            {
                throw new PlayerNullException(1);
            }

            if (jugador2 == null)
            {
                throw new PlayerNullException(2);
            }

            TablaDeJuego = new char?[3, 3];
            Jugador1 = jugador1;
            Jugador2 = jugador2;
            Turno = true;

            for (int i = 0; i<3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    TablaDeJuego[i, j] = null;
                }
            }

        }

        public List<Coordenada> ObtenerCamposVacios() {
            List<Coordenada> lista = new List<Coordenada>();

            for (int i = 0; i < TablaDeJuego.GetLength(0); i++)
            {
                for (int j = 0; j < TablaDeJuego.GetLength(1); j++)
                {
                    if (TablaDeJuego[i, j] == null)
                    {
                        lista.Add(new Coordenada(i, j));
                    }
                }
            }

            return lista;
        }

        public bool IngresarLocacion(int x, int y)
        {
            try
            {
                if (TablaDeJuego[x, y] == null)
                {
                    TablaDeJuego[x, y] = Turno ? P1 : P2;
                    Turno = !Turno;
                    return true;
                }
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public Jugador Comprobar(out bool termino)
        {
            Jugador ganador = null;
            termino = true;
            char? symbol = null;
            if (TablaDeJuego[0, 0] != null && TablaDeJuego[0, 0] == TablaDeJuego[0, 1] && TablaDeJuego[0, 0] == TablaDeJuego[0, 2])
            {
                symbol = TablaDeJuego[0, 0];
            }
            else if (TablaDeJuego[1, 0] != null && TablaDeJuego[1, 0] == TablaDeJuego[1, 1] && TablaDeJuego[1, 0] == TablaDeJuego[1, 2])
            {
                symbol = TablaDeJuego[1, 0];
            }
            else if (TablaDeJuego[2, 0] != null && TablaDeJuego[2, 0] == TablaDeJuego[2, 1] && TablaDeJuego[2, 0] == TablaDeJuego[2, 2])
            {
                symbol = TablaDeJuego[2, 0];
            }
            else if (TablaDeJuego[0, 0] != null && TablaDeJuego[0, 0] == TablaDeJuego[1, 0] && TablaDeJuego[0, 0] == TablaDeJuego[2, 0])
            {
                symbol = TablaDeJuego[0, 0];
            }
            else if (TablaDeJuego[0, 1] != null && TablaDeJuego[0, 1] == TablaDeJuego[1, 1] && TablaDeJuego[0, 1] == TablaDeJuego[2, 1])
            {
                symbol = TablaDeJuego[2, 1];
            }
            else if (TablaDeJuego[0, 2] != null && TablaDeJuego[0, 2] == TablaDeJuego[1, 2] && TablaDeJuego[0, 2] == TablaDeJuego[2, 2])
            {
                symbol = TablaDeJuego[0, 0];
            }
            else if (TablaDeJuego[0, 0] != null && TablaDeJuego[1, 1] == TablaDeJuego[0, 0] && TablaDeJuego[1, 1] == TablaDeJuego[2, 2])
            {
                symbol = TablaDeJuego[0, 0];
            }
            else if (TablaDeJuego[0, 2] != null && TablaDeJuego[0, 2] == TablaDeJuego[1, 1] && TablaDeJuego[1, 1] == TablaDeJuego[2, 0])
            {
                symbol = TablaDeJuego[0, 2];
            }
            else
            {
                if (ObtenerCamposVacios().Any()) {
                    termino = false;
                }
            }

            if (symbol != null)
            {
                ganador = symbol == P1 ? Jugador1 : Jugador2;
            }

            return ganador;
        }

    }
}
