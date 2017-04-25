using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerveCell
{
    public class Neurona
    {
        //double w1, w2, u;
        //Error->La razón por la que fingia los orgasmos, el por que ella nunca te quiso en otras palabras (Lo que tenemos - Lo que necesitamos);
        //Tasa se aprendizaje = alpha 0.3;
        //w->w+alpha*error*entrada

        public double[] wb;//Areeglo con los pesos anteriores
        public double[] w;//Arreglo con los pesos actuales
        public double u;//Umbral de la neurona
        public double ub;//Umbral anterior de la neurona
        public double alpha = 0.3;//Razón de aprendizaje 
        Random r;

        /* Dos constructores uno para la prueba de neuronas unitarias Neurona(int ws, double alpha = 0.3)
           El otro para cuando vas a tener multiples neuronas         Neurona(int ws, Random r,  double alpha = 0.3)*/
           
        //Para pruebas unitarias
        public Neurona(int ws, double alpha = 0.3)
        {
            this.alpha = alpha;
            w = new double[ws];
            wb = new double[ws];
            learn();
        }
        //Para pruebas de multiples neuronas
        public Neurona(int ws, Random r,  double alpha = 0.3)
        {
            this.r = r;
            this.alpha = alpha;
            w = new double[ws];
            wb = new double[ws];
            learn(r);
        }
        //Primera etapa de aprendizaje, sirve para las pruebas con multiples neuronas, ya que recibe
        //una entrada que es la salida de una neurona anterior
        public void learn(Random r)
        {
            //Random r = new Random(); // Activar para sólo una neurona
            for (int i = 0; i < wb.Length; i++)
            {
                wb[i] = r.NextDouble() - r.NextDouble();
            }
            ub = r.NextDouble() - r.NextDouble();
            w = wb;
            u = ub;
        }
        //Primera etapa de aprendizaje, sirve para las pruebas unitarias de neuronas
        public void learn()
        {
            Random r = new Random(); // Activar para sólo una neurona
            for (int i = 0; i < wb.Length; i++)
            {
                wb[i] = r.NextDouble() - r.NextDouble();
            }
            ub = r.NextDouble() - r.NextDouble();
            w = wb;
            u = ub;
        }
        //Proceseo de aprendizaje continuo
        public void learn(double[] dendritas, double axonEsperado)
        {
            if (wb != null)
            {
                double error = (axonEsperado - axon(dendritas));
                for (int i = 0; i < w.Length; i++)
                {
                    w[i] = wb[i] + alpha * error * dendritas[i];
                }
                u = ub + alpha * error;
                wb = w;
                ub = u;
            }
            else
            {
                //Random r = new Random(); //Ativar para sólo una neurona
                for (int i = 0; i < wb.Length; i++)
                {
                    wb[i] = r.NextDouble() - r.NextDouble();
                }
                ub = r.NextDouble() - r.NextDouble();
                w = wb;
                u = ub;
            }
        }
        //Función que emite la salida de la neurona, recibiendo las entradas
        public double axon(double[] dendritas)
        {
            return sigmoideF(neurona(dendritas));
        }

        //Operacion de la neurona aqui yace su comportamiento
        public double neurona(double[] dendritas)
        {
            double sum = 0;
            for (int i = 0; i < dendritas.Length; i++)
            {
                sum += dendritas[i] * w[i];//Sumatoria de entradas por pesos
            }
            return sum + u;//Por ultimo se agrega el umbral
        }
        //Función sigmoide que regresa un valor binario
        public double sigmoideF(double d)
        {
            return d > 0 ? 1 : 0;
        }
    }
}
