using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerveCell
{
    public class Capa
    {
        public List<Neurona> capa = new List<Neurona>();//Aqui van las neuronas que va a tener la capa
        public double[] Salida;//Aqui las salidas de dichas neuronas
        Random r;

        /*Constructor que recibe el numero de entradas(este numero es igual 
          al numero de neuronas de la capa anterior) y el numero de neuronas que tiene la capa*/
        public Capa(int entradas, int nNeuronas, Random R)
        {
            r = R;
            for (int i = 0; i < nNeuronas; i++)
            {
                capa.Add(new Neurona(entradas, r));
            }

        }
        //Recibe las entradas  cada neurona las procesa y emiten sus salidas
        public void Salidas(double[] entradas)
        {
            Salida = new double[capa.Count];
            for (int i = 0; i < capa.Count; i++)
            {
                Salida[i] = capa[i].axon(entradas);// se toman los valores de salida de cada neurona
            }

        }
    }
}
