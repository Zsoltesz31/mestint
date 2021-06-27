using _2_12EgyszemelyesMestintBeadando.Allapotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_12EgyszemelyesMestintBeadando.Keresok
{
    class Backtrack : Kereso
    {
        public Backtrack()
        {
            Kereses();
        }
        public override void Kereses()
        {
            Stack<Csomopont> ut = new Stack<Csomopont>();
            ut.Push(new Csomopont(new Allapot(), 0));

            while (ut.Count > 0 && !ut.Peek().Allapot.celfeltetel())
            {
                Csomopont aktualisCsomopont = ut.Peek();
                if (aktualisCsomopont.OperatorIndex < Operatorok.Count)
                {
                    Operator aktualisOperator = Operatorok[aktualisCsomopont.OperatorIndex];
                    if (aktualisOperator.elofeltetel(aktualisCsomopont.Allapot))
                    {
                        Allapot ujAllapot = aktualisOperator.mozgatas(aktualisCsomopont.Allapot);
                        Csomopont ujCsomopont = new Csomopont(ujAllapot, 0);
                        if (!ut.Contains(ujCsomopont))
                        {
                            ut.Push(ujCsomopont);
                        }
                    }
                    aktualisCsomopont.OperatorIndex++;
                }
                else
                {
                    ut.Pop();
                }

            }

            foreach (Csomopont csomopont in ut)
            {
                Utvonal.Add(csomopont.Allapot);
            }

            Utvonal.Reverse();
        }
    }
}
