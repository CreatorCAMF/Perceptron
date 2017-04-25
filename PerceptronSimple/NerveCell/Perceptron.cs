using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerveCell
{
    public class Perceptron
    {
        public List<Capa> Red = new List<Capa>();//Conjunto de capas que tendra el perceptron
        //Constructor que recibe el numero de entrdas iniciales, y un arreglo donde se pone cuantas neuronas tendra cada capa
        public Perceptron(int entradas, int[] NeuronasPorCapa)
        {
            Random r = new Random();
            Red.Add(new Capa(entradas, NeuronasPorCapa[0], r));//Entradas externas primera capa
            for (int i = 1; i < NeuronasPorCapa.Length; i++)
            {
                Red.Add(new Capa(NeuronasPorCapa[i - 1], NeuronasPorCapa[i], r));//Creacion del resto de capas
            }
        }

        //Se brindan las entradas externas y se obtiene la respuesta de la capa final.
        public double[] Salidas(double[] entradasExternas)
        {
            Red[0].Salidas(entradasExternas);//Primera capa que toma los valores de entrada
            for (int i = 1; i < Red.Count; i++)
            {
                Red[i].Salidas(Red[i - 1].Salida);//Capas ocultas sus entradas son la salida de la capa anterior
            }
            return Red[Red.Count - 1].Salida;//Capa final 
        }

    }
}
