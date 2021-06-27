using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_32MestintBeadando.Allapotter
{
    class Operator
    {
        int mit;
        Point hova;
        int suly;

        public int Mit { get => mit; set => mit = value; }
        public Point Hova { get => hova; set => hova = value; }
        public int Suly { get => suly; set => suly = value; }

        public Operator(int mit, Point hova)
        {
            Mit = mit;
            Hova = hova;
        }

        public bool elofeltetel(Allapot allpot)
        {
            return allpot.Board[hova.X, hova.Y] == 0;
        }
        public Allapot placement(Allapot allapot)
        {
            Allapot newAllapot = new Allapot();
            newAllapot.Board = (int[,])allapot.Board.Clone();
            newAllapot.Board[hova.X, hova.Y] = mit;
            //felül
            if(hova.Y-1>=0 && newAllapot.Board[hova.X, hova.Y - 1] == 0)
            {
                newAllapot.Board[hova.X, hova.Y - 1]=allapot.Player;
            }
            //jobbra
            if (hova.X + 1 < 6 && newAllapot.Board[hova.X + 1, hova.Y] == 0)
            {
                newAllapot.Board[hova.X+1, hova.Y] = allapot.Player;
            }
            //alul
            if (hova.Y + 1 < 6 && newAllapot.Board[hova.X, hova.Y + 1] == 0)
            {
                newAllapot.Board[hova.X, hova.Y + 1] = allapot.Player;
            }
            //balra
            if (hova.X - 1 >= 0 && newAllapot.Board[hova.X - 1, hova.Y] == 0)
            {
                newAllapot.Board[hova.X - 1, hova.Y] = allapot.Player;
            }
            newAllapot.Player = (-1) * allapot.Player;
            return newAllapot;
        }
    }
}
