using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gato
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        //----- MENU -----//
        public static void Menu()
        {
            bool opcionMenu = true;
            int numeroMenu = -1;
            int valorInicialMenu = 1;
            int valorFinalMenu = 4;

            Console.WriteLine("Bienvenido a MegaGato3000 240fps 4k");
            Console.WriteLine("");
            Console.WriteLine("Por favor, ingresa tu nombre");
            Jugador jugador1 = new Jugador(Console.ReadLine());

            do
            {
                Console.WriteLine("");
                Console.WriteLine(jugador1.Nombre + ", que deseas hacer?");
                Console.WriteLine("");
                Console.WriteLine("1. Iniciar juego Solo");
                Console.WriteLine("2. Iniciar juego con amigo");
                Console.WriteLine("3. Ver calificaciones");
                Console.WriteLine("4. Salir del programa");
                Console.WriteLine("");

                string respuestaMenu = Console.ReadLine();
                numeroMenu = ComprobacionNumero(respuestaMenu, valorInicialMenu, valorFinalMenu);

                Random ran = new Random();

                switch (numeroMenu)
                {
                    case 1:
                        // INICIAR JUEGO SOLO
                        Jugador jugadorIA = new Jugador(Listas.nombres[ran.Next(0, Listas.nombres.Count - 1)]
                                          + " "
                                          + Listas.apellidos[ran.Next(0, Listas.apellidos.Count - 1)]
                                          + " "
                                          + Listas.apellidos[ran.Next(0, Listas.apellidos.Count - 1)]);
                        Gato gatoSolo = new Gato(jugador1, jugadorIA);
                        bool gatoFin = true;
                        int valorColumna = 5;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("    ____1____|___2____|___3___");
                            Console.WriteLine("   |        %%       %%");
                            Console.WriteLine(" A |    " + gatoSolo.TablaDeJuego[0, 0] + "   %%   " + gatoSolo.TablaDeJuego[0, 1] + "   %%   " + gatoSolo.TablaDeJuego[0, 2] + "");
                            Console.WriteLine("   |        %%       %%");
                            Console.WriteLine("   | %%%%%%%%%%%%%%%%%%%%%%%%%");
                            Console.WriteLine("   |        %%       %%");
                            Console.WriteLine(" B |    " + gatoSolo.TablaDeJuego[1, 0] + "   %%   " + gatoSolo.TablaDeJuego[1, 1] + "   %%   " + gatoSolo.TablaDeJuego[1, 2] + "");
                            Console.WriteLine("   |        %%       %%");
                            Console.WriteLine("   | %%%%%%%%%%%%%%%%%%%%%%%%%");
                            Console.WriteLine("   |        %%       %%");
                            Console.WriteLine(" C |    " + gatoSolo.TablaDeJuego[2, 0] + "   %%   " + gatoSolo.TablaDeJuego[2, 1] + "   %%   " + gatoSolo.TablaDeJuego[2, 2] + "");
                            Console.WriteLine("   |        %%       %%");
                            Console.WriteLine("");

                            do
                            {
                                Console.WriteLine("En que columna deseas ingresar un valor (1, 2, 3)?");
                                valorColumna = ComprobacionNumero(Console.ReadLine(), 1, 3);

                                if (valorColumna < 0)
                                {
                                    Console.WriteLine("El valor ingresado no es correcto.");
                                }

                            } while (valorColumna < 0);


                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.ReadLine();

                        } while (gatoFin);


                        

                        break;

                    case 2:
                        // INICIAR JUEGO CON AMIGO
                        Console.WriteLine("Por favor jugador #2, ingresa tu nombre");
                        Jugador jugador2 = new Jugador(Console.ReadLine());
                        Gato gatoCompanero = new Gato(jugador1, jugador2);

                        break;

                    case 3:
                        // VER PUNTUACION
                        
                        break;

                    case 4:
                        // SALIR
                        opcionMenu = false;
                        break;

                    default:
                        // ERROR
                        Console.WriteLine("");
                        Console.WriteLine("El valor de ´" + respuestaMenu + "´, no es valido.");
                        Console.WriteLine("");
                        Console.WriteLine("Por favor ingrese un valor entre " + valorInicialMenu + " y " + valorFinalMenu + ".");
                        Console.WriteLine("");
                        Console.WriteLine("Por favor indiquenos,");
                        Console.WriteLine("");
                        break;
                }

            } while (opcionMenu);
        }

        //----- FUNCION PROBAR NUMERO DE MENU -----//
        public static int ComprobacionNumero(string datoIngresado, int numA, int numB)
        {
            if (!(int.TryParse(datoIngresado, out int opcion) && opcion >= numA && opcion <= numB))
            {
                opcion = -1;
            }
            return opcion;
        }
        class Listas
        {
            public static readonly List<string> nombres = new List<string>(new string[] { "Emma", "Liam", "Olivia", "Noah", "Ava", "Mason", "Sophia", "Lucas", "Isabella", "Oliver", "Mia", "Ethan", "Charlotte", "Elijah", "Amelia", "Aiden", "Harper", "Logan", "Aria", "James", "Abigail", "Benjamin", "Ella", "Jackson", "Evelyn", "Jacob", "Avery", "Carter", "Emily", "Sebastian", "Madison", "Alexander", "Scarlett", "Michael", "Sofia", "Matthew", "Lily", "Jayden", "Mila", "Jack", "Riley", "Luke", "Layla", "Wyatt", "Chloe", "Daniel", "Ellie", "Gabriel", "Grace", "William", "Zoey", "Grayson", "Penelope", "Henry", "Aubrey", "Owen", "Elizabeth", "Levi", "Victoria", "Jaxon", "Hannah", "Lincoln", "Nora", "Adam", "Stella", "David", "Addison", "Isaiah", "Luna", "Joseph", "Natalie", "Julian", "Paisley", "Josiah", "Skylar", "Ryan", "Savannah", "Samuel", "Maya", "Eli", "Camila", "Dylan", "Hazel", "Nathan", "Lillian", "Joshua", "Lucy", "Isaac", "Bella", "John", "Brooklyn", "Caleb", "Audrey", "Andrew", "Aaliyah", "Hunter", "Leah", "Leo", "Zoe", "Muhammad" });
            public static readonly List<string> apellidos = new List<string>(new string[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson", "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White", "Lopez", "Lee", "Gonzalez", "Harris", "Clark", "Lewis", "Robinson", "Walker", "Perez", "Hall", "Young", "Allen", "Sanchez", "Wright", "King", "Scott", "Green", "Baker", "Adams", "Nelson", "Hill", "Ramirez", "Campbell", "Mitchell", "Roberts", "Carter", "Phillips", "Evans", "Turner", "Torres", "Parker", "Collins", "Edwards", "Stewart", "Flores", "Morris", "Nguyen", "Murphy", "Rivera", "Cook", "Rogers", "Morgan", "Peterson", "Cooper", "Reed", "Bailey", "Bell", "Gomez", "Kelly", "Howard", "Ward", "Cox", "Diaz", "Richardson", "Wood", "Watson", "Brooks", "Bennett", "Gray", "James", "Reyes", "Cruz", "Hughes", "Price", "Myers", "Long", "Foster", "Sanders", "Ross", "Morales", "Powell", "Sullivan", "Russell", "Ortiz", "Jenkins", "Gutierrez", "Perry", "Butler", "Barnes", "Fisher" });
        }
    }
}
