using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_12EgyszemelyesMestintBeadando.Allapotter
{
    class Operator
    {
        private int melyiket1;
        private int melyiket2;
        private int hova1;
        private int hova2;

        public int Melyiket1 { get => melyiket1; set => melyiket1 = value; }
        public int Melyiket2 { get => melyiket2; set => melyiket2 = value; }
        public int Hova1 { get => hova1; set => hova1 = value; }
        public int Hova2 { get => hova2; set => hova2 = value; }

        public Operator(int melyiket1, int melyiket2, int hova1, int hova2)
        {
            Melyiket1 = melyiket1;
            Melyiket2 = melyiket2;
            Hova1 = hova1;
            Hova2 = hova2;
        }

        public Allapot mozgatas(Allapot allapot)
        {
            Allapot ujallapot = new Allapot();
            for (int i = 0; i < 16; i++)
            {
                ujallapot.Rekesz[i] = 0;
            }
            for (int i = 0; i < 16; i++)
            {
                ujallapot.Rekesz[i] = allapot.Rekesz[i];
            }
            int mozgatas1 = ujallapot.Rekesz[Melyiket1];
            ujallapot.Rekesz[Hova1] = mozgatas1;
            int mozgatas2 = ujallapot.Rekesz[Melyiket2];
            ujallapot.Rekesz[Hova2] = mozgatas2;
            ujallapot.Rekesz[Melyiket1] = 0;         
            ujallapot.Rekesz[Melyiket2] = 0;
            return ujallapot;

        }

        public bool elofeltetel(Allapot allapot)
        {
            //olyat rekeszt választok ami üres
            if (allapot.Rekesz[Melyiket1]==0 || allapot.Rekesz[Melyiket2] == 0)
            {
                return false;
            }
            //üresnek kell lennie a mezőnek
            if (allapot.Rekesz[Hova1]!=0 || allapot.Rekesz[Hova2]!=0)
            {
                return false;
            }
            //nem egyhelyben toporgok
            if (Melyiket1==Hova1 || Melyiket2==Hova2)
            {
                return false;
            }
            return true;
        }
    }
}
