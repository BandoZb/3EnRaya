using System;


namespace EnRalla
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[][] tablero =
            {
                new string[] {"1","2","3"},
                new string[] {"4","5","6"},
                new string[] {"7","8","9"}
            };

            string j1;
            string j2;
            string jugadorGanador;
            bool win = false;


            Console.WriteLine("Welcome to the game 3 in line");
              
                Console.WriteLine("Insert player 1 name");
                j1 = Console.ReadLine();
                Console.WriteLine("Insert player 2 name");
                j2 = Console.ReadLine();

            int turno = 0;


            do {
                string jugadorEnJuego = turno%2 == 0 ? j1 : j2;
                string simbolo = turno % 2 == 0 ? "X" : "O";
                jugadorGanador = jugadorEnJuego;

                Console.WriteLine("Turno jugador {0}", jugadorEnJuego +"\n");

                MostrarTablero(tablero);

                Console.WriteLine(jugadorEnJuego + " elige numero para colocar tu pieza");
                string pos = Console.ReadLine();
          
                ColocarPieza(tablero, pos, jugadorEnJuego,j1,j2);

                ResetMapa(tablero);
                win = ComprobarGanador(tablero,simbolo);

                turno++;
                Console.WriteLine();

            } while (!win);

            MostrarTablero(tablero);
            Console.WriteLine("Felicidades {0}, has ganado", jugadorGanador);

            Console.ReadLine();

        }

        public static void MostrarTablero(string[][] tablero)
        {
            for (int i = 0; i < tablero.Length; i++)
            {
                for (int j = 0; j < tablero[i].Length; j++)
                {
                    Console.Write("[" +tablero[i][j] +"]");
                }
                Console.WriteLine();
            }
        }

        public static bool LugarDisponible(string[][] tablero,string pos)
        {
            for (int i = 0; i < tablero.Length; i++)
            {
                for (int j = 0; j < tablero[i].Length; j++)
                {
                    if (tablero[i][j].Equals(pos))
                    {
                        return true;
                    }

                }

            }
            return false;
        }

        public static void ColocarPieza(string[][] tablero, string pos, string jugadorEnJuego, string j1, string j2)
        {
            if (LugarDisponible(tablero, pos))
            {
                for (int i = 0; i < tablero.Length; i++)
                {
                    for (int j = 0; j < tablero[i].Length; j++)
                    {
                        if (tablero[i][j].Equals(pos))
                        {
                            tablero[i][j] = jugadorEnJuego.Equals(j1) ? "X" : "O";
                            return;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Posición no disponible, intenta otra.");
            }
        }

        public static bool ComprobarGanador(string[][] tablero, string simbolo)
        {
            
            for (int i = 0; i < 3; i++)
            {
                if ((tablero[i][0] == simbolo && tablero[i][1] == simbolo && tablero[i][2] == simbolo) ||
                    (tablero[0][i] == simbolo && tablero[1][i] == simbolo && tablero[2][i] == simbolo))
                {
                    return true;
                }
            }
            if ((tablero[0][0] == simbolo && tablero[1][1] == simbolo && tablero[2][2] == simbolo) ||
                (tablero[0][2] == simbolo && tablero[1][1] == simbolo && tablero[2][0] == simbolo))
            {
                return true;
            }

            return false;
        }

        public static string[][] ResetMapa(string[][] tablero)
        {
            bool hayNumeros = false; 
       
            for (int i = 0; i < tablero.Length; i++)
            {
                for (int j = 0; j < tablero[i].Length; j++)
                {
                    if (!tablero[i][j].Equals("X") && !tablero[i][j].Equals("O"))
                    {
                        hayNumeros = true;
                    }
                }; 
            }

            if (hayNumeros == false)
            {
                Console.WriteLine("No hay más movimientos disponibles. \nReseteando el mapa...");

                int contador = 1;
                for (int i = 0; i < tablero.Length; i++)
                {
                    for (int j = 0; j < tablero[i].Length; j++)
                    {
                        tablero[i][j] = contador.ToString();
                        contador++;
                    }
                }
            }
            return tablero;
        }
    }
}
