using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NerveCell;//DLL creado con las clases Neurona, Capa y Perceptron

namespace PerceptronSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaración de una neurona con 2 entradas
            Neurona neuron = new Neurona(2);

            //double w1, w2, u;
            //Error->La razón por la que fingia los orgasmos, el por que ella nunca te quiso en otras palabras (Lo que tenemos - Lo que necesitamos);
            //Tasa se aprendizaje = alpha 0.3;
            //w->w+alpha*error*entrada

            bool sw = false;

            Random r = new Random();
            //Mientras la nuerona no consiga un AND u OR lo que el usuario quiera, la neurana seguira su proceso de aprendizaje.
            while (!sw)
            {
                sw = true;
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("W 1: "+neuron.w[0]);
                Console.WriteLine("W 2: " + neuron.w[1]);
                Console.WriteLine("U  : " + neuron.u);
                Console.WriteLine("E1: 1 E2: 1 :" + neuron.axon(new double[2] { 1, 1 }));
                Console.WriteLine("E1: 1 E2: 0 :" + neuron.axon(new double[2] { 1, 0 }));
                Console.WriteLine("E1: 0 E2: 1 :" + neuron.axon(new double[2] { 0, 1 }));
                Console.WriteLine("E1: 0 E2: 0 :" + neuron.axon(new double[2] { 0, 0 }));
                /*Para comprobaciones de operaciones logicas*/
                if (neuron.axon(new double[2] { 1, 1 }) != 1)
                {
                    neuron.learn(new double[2] { 1, 1 },1);
                    sw = false;
                }            
                if (neuron.axon(new double[2] { 1, 0 }) != 0)
                {
                    neuron.learn(new double[2] { 1, 0 }, 0);
                    sw = false;
                }
                if (neuron.axon(new double[2] { 0, 1 }) != 0)
                {
                    neuron.learn(new double[2] { 0, 1 }, 0);
                    sw = false;
                }
                if (neuron.axon(new double[2] { 0, 0 }) != 0)
                {
                    neuron.learn(new double[2] { 0, 0 }, 0);
                    sw = false;
                }
            }
            Console.ReadLine();
        }
    }
}
