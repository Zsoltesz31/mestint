using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_12EgyszemelyesMestintBeadando.Allapotter
{
    class Csomopont
    {
        Allapot allapot;
        Csomopont szulo;
        int operatorIndex;
        int heurisztika;

        internal Allapot Allapot { get => allapot; set => allapot = value; }
        internal Csomopont Szulo { get => szulo; set => szulo = value; }
        public int OperatorIndex { get => operatorIndex; set => operatorIndex = value; }
        public int Heurisztika { get => heurisztika; set => heurisztika = value; }

        public Csomopont(Allapot allapot, int operatorIndex)
        {
            this.allapot = allapot;
            this.OperatorIndex = operatorIndex;
        }
        public Csomopont(Allapot allapot, Csomopont szulo)
        {
            this.allapot = allapot;
            this.szulo = szulo;
            Heurisztika = 0;
            for (int i = 0; i < 11; i++)
            {
               
                    if (allapot.Rekesz[i]==1)
                    {
                        Heurisztika += 1;
                    }
                    else if (allapot.Rekesz[i] == 1 && Allapot.Rekesz[i+1]==1)
                    {
                        Heurisztika += 2;
                    }
                    else if (allapot.Rekesz[i] == 1 && allapot.Rekesz[i+1] == 1 && Allapot.Rekesz[i + 2] == 1)
                    {
                        Heurisztika += 3;
                    }
                    else if (allapot.Rekesz[i] == 1 && allapot.Rekesz[i+1] == 1 && allapot.Rekesz[i+2] == 1 && Allapot.Rekesz[i + 3] == 2)
                    {
                        Heurisztika += 4;
                    }
                    else if (allapot.Rekesz[i] == 1 && allapot.Rekesz[i+1] == 1 && allapot.Rekesz[i+2] == 1 && allapot.Rekesz[i+3] == 2 &&allapot.Rekesz[i + 4] == 2)
                    {
                        Heurisztika += 5;
                    }
                    else if (allapot.Rekesz[i] == 1 && allapot.Rekesz[i+1] == 1 && allapot.Rekesz[i+2] == 1 && allapot.Rekesz[i+3] == 2 && allapot.Rekesz[i+4] == 2 && allapot.Rekesz[i + 5] == 2)
                    {
                        Heurisztika += 6;
                    }
                
            }
        }
        public override bool Equals(object obj)
        {
            Csomopont osszehasonlitandoCsomopont = (Csomopont)obj;
            return this.allapot.Equals(osszehasonlitandoCsomopont.Allapot);
        }


    }

}
