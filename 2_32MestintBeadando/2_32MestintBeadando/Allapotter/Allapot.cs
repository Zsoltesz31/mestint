using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_32MestintBeadando.Allapotter
{
    class Allapot
    {
        int[,] board;
        int player;

        public int Player { get => player; set => player = value; }
        public int[,] Board { get => board; set => board = value; }

        public Allapot()
        {
            Board = new int[6, 6];
            Player = 1;
        }

        public bool celfeltetel()
        {
            bool vaneuresfield = false;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (board[i, j] == 0)
                    {
                        vaneuresfield = true;
                        return vaneuresfield;
                    }
                }
            }
            return vaneuresfield;
        }

        public int heurisztika()
        {
            int lepesszam = 0;
            int suly = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (board[i,j]==0)
                    {
                        lepesszam++;
                    }
                }
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (lepesszam % 2 != 0)
                    {
                        if (i-1>=0 && i+1<6 && j-1>=0 &&j+1<6)
                        {
                            if (board[i - 1, j] == 0 && board[i, j - 1] == 0 && board[i + 1, j] == 0 && board[i, j + 1] == 0)
                            {
                                suly += 1;
                            }
                            else if (board[i - 1, j] == 0 && board[i, j - 1] == 0)
                            {
                                suly += 5;
                            }
                            else if(board[i + 1, j] == 0 && board[i, j + 1] == 0)
                            {
                                suly += 5;
                            }
                            else if(board[i + 1, j] == 0 && board[i, j - 1] == 0)
                            {
                                suly += 5;
                            }
                            else if(board[i - 1, j] == 0 && board[i, j + 1] == 0)
                            {
                                suly += 5;
                            }
                            else
                            {
                                suly += 10;
                            }
                        }
                    }
                }
            }
            return suly;

        }

    }
}

