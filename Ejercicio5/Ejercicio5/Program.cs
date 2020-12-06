
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    class Program
    {
        static int contador = 0;
        static void aumentar()
        {
            contador++;
            Console.WriteLine(contador);
        }
        static void Main(string[] args)
        {
            Timer timer = new Timer(aumentar);
            timer.pausa = 1000;
            string op = "";

            do
            {
                Console.WriteLine("Pulsa una tecla para empezar a contar");
                Console.ReadKey();
                timer.run();
                Console.WriteLine("Pulsa una tecla para detener la cuenta");
                Console.ReadKey();
                timer.pause();
                Console.WriteLine("Pulsa s para seguir la cuenta");
                op = Console.ReadLine();
            } while (op == "s");
        }
    }
}