
using System;
using System.Collections.Generic;
using System.Threading;

namespace Ejercicio4
{
    class Program
    {
        static readonly object l = new object();
        static bool fin = false;
        static string ganador = "";
        static void Main(string[] args)
        {
            string opcion = "";
            string caballoSeleccionado = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Seleccione un caballo");
                Console.WriteLine("1. Caballo1");
                Console.WriteLine("2. Caballo2");
                Console.WriteLine("3. Caballo3");
                Console.WriteLine("4. Caballo4");
                Console.WriteLine("5. Caballo5");
                caballoSeleccionado = Console.ReadLine();
                
                Console.Clear();
                fin = false;
                List<Caballos> caballos = new List<Caballos>();
                caballos.Add(new Caballos(0, 1, "Caballo 1"));
                caballos.Add(new Caballos(0, 2, "Caballo 2"));
                caballos.Add(new Caballos(0, 3, "Caballo 3"));
                caballos.Add(new Caballos(0, 4, "Caballo 4"));
                caballos.Add(new Caballos(0, 5, "Caballo 5"));
                Console.SetCursorPosition(100, 1);
                Console.WriteLine("|");
                Console.SetCursorPosition(100, 2);
                Console.WriteLine("|");
                Console.SetCursorPosition(100, 3);
                Console.WriteLine("|");
                Console.SetCursorPosition(100, 4);
                Console.WriteLine("|");
                Console.SetCursorPosition(100, 5);
                Console.WriteLine("|");

                Thread[] threads = new Thread[5];
                for (int i = 0; i < caballos.Count; i++)
                {
                    threads[i] = new Thread(correr);
                    threads[i].Start(caballos[i]);
                }
                threads[0].Join();

                Console.SetCursorPosition(0, 6);
                if (ganador == caballoSeleccionado)
                {
                    Console.WriteLine("Tu caballo ha ganado");
                }
                else
                {
                    Console.WriteLine("Has perdido, el caballo ganador es: " + ganador);
                }
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Pulsa s para volver a jugar");
                Console.SetCursorPosition(0, 8);

                opcion = Console.ReadLine();

            } while (opcion == "s");

        }

        public static void correr(object a)
        {
            Caballos caballo = (Caballos)a;
            while (!fin)
            {
                lock (l)
                {
                    if (!fin)
                    {
                        caballo.Run();
                        if (caballo.posicion >= 100)
                        {
                            caballo.posicion = 100;
                            Console.SetCursorPosition(caballo.posicion, caballo.altura);
                            Console.WriteLine(caballo.altura);
                            ganador = Convert.ToString(caballo.altura);
                            fin = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(caballo.posicion, caballo.altura);
                            Console.WriteLine(caballo.altura);
                            Console.SetCursorPosition(caballo.posicion, caballo.altura);
                            Console.WriteLine("-");
                        }
                    }

                }
                Thread.Sleep(caballo.Sleep());
            }
            if (fin)
            {
                lock (l)
                {
                    {
                        Console.SetCursorPosition(caballo.posicion, caballo.altura);
                        Console.WriteLine(caballo.altura);
                    }
                }
            }

        }
    }
}