using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_12EgyszemelyesMestintBeadando.Allapotter
{
    class Allapot
    {
      
        private int[] rekesz = new int[16];

        public int[] Rekesz { get => rekesz; set => rekesz = value; }

        public Allapot()
        {
            for (int i = 0; i < 6; i++)
            {
                //1=piros korong
                //2=fekete korong
                if (i%2==0)
                {
                    Rekesz[i] = 1;
                }
                else
                {
                    Rekesz[i] = 2;
                }
            }
            
        }

        public bool celfeltetel()
        {
            
            for (int i = 0; i < 11; i++)
            {
                if (Rekesz[i]==1 && Rekesz[i+1]==1 && Rekesz[i+2]==1 && Rekesz[i+3]==2 && Rekesz[i + 4] == 2 && Rekesz[i + 5] == 2)
                {
                    return true;
                }
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            Allapot vizsgaltAllapot = (Allapot)obj;
            for (int i = 0; i < Rekesz.Length; i++)
            {
                if (this.Rekesz[i] != vizsgaltAllapot.Rekesz[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

