using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    class Caballos
    {
        static readonly object control = new object();
        static Random rand = new Random();
        public int posicion;
        public int altura;
        public string nombre;


        public Caballos(int position, int line, string name)
        {
            this.nombre = name;
            this.altura = line;
            this.posicion = position;
        }
        public int Sleep()
        {
            return rand.Next(0, 200);
        }

        public void Run()
        {
            posicion = posicion + rand.Next(1, 6);

        }


    }
}