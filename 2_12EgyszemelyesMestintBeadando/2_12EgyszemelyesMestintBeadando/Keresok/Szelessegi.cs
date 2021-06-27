using _2_12EgyszemelyesMestintBeadando.Allapotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_12EgyszemelyesMestintBeadando.Keresok
{
    class Szelessegi : Kereso
    {
        public Szelessegi()
        {
            Kereses();
        }

        public override void Kereses()
        {
            Queue<Csomopont> nyiltcsucsok = new Queue<Csomopont>();
            List<Csomopont> zartcsucsok = new List<Csomopont>();

            nyiltcsucsok.Enqueue(new Csomopont(new Allapot(), null));

            while (nyiltcsucsok.Count > 0 && !nyiltcsucsok.Peek().Allapot.celfeltetel())
            {
                Csomopont aktualisCsomopont = nyiltcsucsok.Dequeue();
                foreach (Operator op in Operatorok)
                {
                    if (op.elofeltetel(aktualisCsomopont.Allapot))
                    {
                        Allapot ujAllpot = op.mozgatas(aktualisCsomopont.Allapot);

                        Csomopont ujCsomopont = new Csomopont(ujAllpot, aktualisCsomopont);
                        if (!nyiltcsucsok.Contains(ujCsomopont) && !zartcsucsok.Contains(ujCsomopont))
                        {
                            nyiltcsucsok.Enqueue(ujCsomopont);
                        }
                    }
                }
                zartcsucsok.Add(aktualisCsomopont);
            }

            if (nyiltcsucsok.Count > 0)
            {
                Csomopont celCsomopont = nyiltcsucsok.Peek();
                while (celCsomopont != null)
                {
                    this.Utvonal.Add(celCsomopont.Allapot);
                    celCsomopont = celCsomopont.Szulo;
                }
                this.Utvonal.Reverse();
            }
        }
    }
}
