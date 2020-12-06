
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{

    delegate void MyDelegate();
    class Delegados
    {
        public void MenuGenerator(string[] options, MyDelegate[] menu)
        {
            int option = 0;
            int ultimo = options.Length + 1;
            string salir = "Exit";
                do
                {
                    Console.WriteLine("Selecciona una opción");

                    for (int i = 0; i < options.Length; i++)
                    {
                        Console.WriteLine("{0}{1,5}", i + 1, options[i]);
                    }

                    Console.WriteLine("{0}{1,5}", ultimo, salir);
                    try
                    {
                        option = Convert.ToInt16(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Introduce un número");
                    }

                    if (option > 0 && option <= ultimo)
                    {

                        if (option != ultimo)
                        {
                            menu[option - 1].Invoke();
                        }
                        else
                        {
                            Console.WriteLine("Saliendo del programa");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error, opción no válida");
                    }

                } while (option != ultimo);
            

        }
    }
    class Program
    {
        static void f1()
        {
            Console.WriteLine("A");
        }
        static void f2()
        {
            Console.WriteLine("B");
        }
        static void f3()
        {
            Console.WriteLine("C");
        }
        static void Main(string[] args)
        {
            Delegados delegaAll = new Delegados();
            delegaAll.MenuGenerator(new string[] { "Op1", "Op2", "Op3" },
            new MyDelegate[] { f1, f2, f3 });
            Console.ReadKey();
        }

    }
}