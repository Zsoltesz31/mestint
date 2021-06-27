using _2_12EgyszemelyesMestintBeadando.Allapotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_12EgyszemelyesMestintBeadando.Keresok
{
    abstract class Kereso
    {
        List<Allapot> utvonal = new List<Allapot>(); 

        internal List<Allapot> Utvonal { get => utvonal; set => utvonal = value; }
        internal List<Operator> Operatorok { get => operatorok; set => operatorok = value; }

        List<Operator> operatorok = new List<Operator>();

        public Kereso()
        {
            operatorokGeneralasa();
        }
        private void operatorokGeneralasa()
        {
            List<int[]> lehetsegesPontParok = new List<int[]>();
            for (int i = 0; i < 15; i++)
            {
                lehetsegesPontParok.Add(new int[] {i,i+1});
            }
            Console.WriteLine();
            foreach (int[] item in lehetsegesPontParok)
            {
                for (int i = 0; i < 15; i++)
                {
                    Operator ujOperator = new Operator(item[0],item[1],i,i+1);
                        operatorok.Add(ujOperator);
                    

                }
            }
            Console.WriteLine();
        }
        public abstract void Kereses();
    }
}
