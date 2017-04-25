using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NerveCell;//DLL creado con las clases Neurona, Capa y Perceptron
namespace PerceptronMulticapa
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sw = false;
            Random r = new Random();
            while (!sw)
            {
                sw = true;
                //Declaración de un perceptron con 2 entradas y 2 capas la primera con 2 neuronas y la segunda con 1
                Perceptron perceptron = new Perceptron(2, new int[] { 2, 1 });
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("E1: 1 E2: 1 :" + perceptron.Salidas(new double[2] { 1, 1 })[0]);
                Console.WriteLine("E1: 1 E2: 0 :" + perceptron.Salidas(new double[2] { 1, 0 })[0]);
                Console.WriteLine("E1: 0 E2: 1 :" + perceptron.Salidas(new double[2] { 0, 1 })[0]);
                Console.WriteLine("E1: 0 E2: 0 :" + perceptron.Salidas(new double[2] { 0, 0 })[0]);
                /*Para comprobaciones de operaciones logicas*/
                if (perceptron.Salidas(new double[2] { 1, 1 })[0] != 1)
                {
                    sw = false;
                }
                if (perceptron.Salidas(new double[2] { 1, 0 })[0] != 0)
                {
                    sw = false;
                }
                if (perceptron.Salidas(new double[2] { 0, 1 })[0] != 0)
                {
                    sw = false;
                }
                if (perceptron.Salidas(new double[2] { 0, 0 })[0] != 1)
                {
                    sw = false;
                }
            }
            Console.ReadLine();
        }
    }
}
