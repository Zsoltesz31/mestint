using _2_32MestintBeadando.Allapotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_32MestintBeadando.Keresok
{
    class Negamax
    {
        int maxMelyseg = 2;

        public Operator ajanl(Allapot allapot)
        {
            List<Operator> ajanlottOperatorok = new List<Operator>();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Operator aktOperator = new Operator(allapot.Player, new System.Drawing.Point(i, j));
                    if (aktOperator.elofeltetel(allapot))
                    {
                        Allapot ujAllapot = aktOperator.placement(allapot);
                        bejaras(ujAllapot, aktOperator, 0, 1);
                        ajanlottOperatorok.Add(aktOperator);
                    }
                }
            }

            ajanlottOperatorok = ajanlottOperatorok.OrderByDescending(o => o.Suly).ToList();

            return ajanlottOperatorok[0];
        }

        private void bejaras(Allapot allapot, Operator eredetiOperator, int melyseg, int elojel)
        {
            if (allapot.celfeltetel())
            {
                eredetiOperator.Suly = elojel * allapot.heurisztika();
            }
            if (melyseg < maxMelyseg)
                {
                    int max = Int32.MinValue;
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            Operator aktOperator = new Operator(allapot.Player, new System.Drawing.Point(i, j));
                            if (aktOperator.elofeltetel(allapot))
                            {
                                Allapot ujAllapot = aktOperator.placement(allapot);
                                int aktSuly = ujAllapot.heurisztika();
                                if(aktSuly>max)
                                {
                                max = aktSuly;                               
                                }
                                bejaras(ujAllapot, aktOperator, melyseg + 1, -elojel);
                            }
                        }
                    }
                eredetiOperator.Suly += max;
                }
            }

        }   
    }

    

