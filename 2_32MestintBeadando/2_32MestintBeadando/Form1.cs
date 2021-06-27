using _2_32MestintBeadando.Allapotter;
using _2_32MestintBeadando.Keresok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_32MestintBeadando
{
    public partial class Form1 : Form
    {
        Allapot allapot = new Allapot();
        Button[,] board = new Button[6, 6];
        public Form1()
        {

            InitializeComponent();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Button field = new Button();
                    field.Size = new Size(60, 60);
                    field.Location = new Point(boardPanel.Width / 2 + 120 - (i * 60), boardPanel.Height / 2 + 120 - (j * 60));
                    field.Tag = i + "," + j;
                    field.BackColor = Color.White;
                    field.Font = new Font(this.Font.FontFamily, 30, FontStyle.Bold);

                    boardPanel.Controls.Add(field);

                    int x = i;
                    int y = j;

                    field.Click += (obj, e) => fieldClick(obj, x, y);
                    board[i, j] = field;
                }
            }

        }

        public void draw(Button field, int x, int y)
        {
            
            if (allapot.Player == 1)
            {
                board[x, y].Text = "1";
                board[x, y].ForeColor = Color.Blue;
                //felül
                if (y - 1 >= 0 && board[x, y - 1].Text == "")
                {
                    board[x,y-1].Text = "1";
                    board[x, y - 1].ForeColor = Color.Blue;
                }
                //jobbra
                if (x + 1 < 6 && board[x + 1, y].Text == "")
                {
                    board[x+1, y].Text = "1";
                    board[x + 1, y].ForeColor = Color.Blue;
                }
                //alul
                if (y + 1 < 6 && board[x, y+1].Text == "")
                {
                    board[x, y + 1].Text = "1";
                    board[x, y + 1].ForeColor = Color.Blue;
                }
                //balra
                if (x - 1 >= 0 && board[x - 1, y].Text == "")
                {
                    board[x-1, y].Text = "1";
                    board[x - 1, y].ForeColor = Color.Blue;
                }
            }
            else
            {
                board[x, y].Text = "0";
                board[x, y].ForeColor = Color.Red;
                //felül
                if (y - 1 >= 0 && board[x, y - 1].Text == "")
                {
                    board[x, y - 1].Text = "0";
                    board[x, y - 1].ForeColor = Color.Red;
                }
                //jobbra
                if (x + 1 < 6 && board[x + 1, y].Text == "")
                {
                    board[x+1, y].Text = "0";
                    board[x + 1, y].ForeColor = Color.Red;
                }
                //alul
                if (y + 1 < 6 && board[x, y + 1].Text == "")
                {
                    board[x, y + 1].Text = "0";
                    board[x, y + 1].ForeColor = Color.Red;
                }
                //balra
                if (x - 1 >= 0 && board[x - 1, y].Text == "")
                {
                    board[x-1, y].Text = "0";
                    board[x - 1, y].ForeColor = Color.Red;
                }
            }
        }
        public bool gameCheck()
        {
            if (allapot.celfeltetel()==false)
            {
                allapot.Player *= -1;
                if (allapot.Player==-1)
                {
                    MessageBox.Show("A nyertes a gép!");
                    return true;
                }
                else
                {
                    MessageBox.Show("A nyertes Ön!");
                    return true;
                }
            }
            return false;
        }
        public void fieldClick(object sender, int x, int y)
        {
            Button field = (Button)sender;
            
            Point point = new Point(x, y);
            Operator op = new Operator(allapot.Player, point);
            if (op.elofeltetel(allapot))
            {
                draw(field, x, y);

                allapot = op.placement(allapot);
                if (!gameCheck())
                {
                    Negamax negamax = new Negamax();
                    Operator botOp = negamax.ajanl(allapot);
                    Button fieldBot = board[botOp.Hova.X, botOp.Hova.Y];
                    draw(fieldBot, botOp.Hova.X, botOp.Hova.Y);
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            Console.Write(allapot.Board[j, i]);
                        }
                        Console.WriteLine();
                    }
                    allapot = botOp.placement(allapot);
                    Console.WriteLine();
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            Console.Write(allapot.Board[j, i]);
                        }
                        Console.WriteLine();
                    }
                    gameCheck();
                }
            }
            
           
        }
    }
}
