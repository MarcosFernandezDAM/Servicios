
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio5
{
    public delegate void Delegado();

    class Timer
    {
        static readonly object l = new object();
        Delegado delegado;
        public int pausa;
        public bool run1 = true;
        public bool pausar = true;

        public Timer(Delegado deleg)
        {
            this.delegado = deleg;
            Thread thread = new Thread(start);
            thread.IsBackground = true;
            thread.Start();

        }

        public void run()
        {
            lock (l)
            {
                Monitor.Pulse(l);
                pausar = false;
            }

        }


        public void pause()
        {
            lock (l)
            {
                pausar = true;
            }
        }


        public void start()
        {
            while (run1)
            {
                lock (l)
                {
                    if (pausar)
                    {
                        Monitor.Wait(l);
                    }
                    delegado();
                    Thread.Sleep(pausa);
                }
            }

        }

    }

}