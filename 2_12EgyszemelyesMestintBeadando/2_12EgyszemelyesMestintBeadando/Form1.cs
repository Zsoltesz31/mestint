using _2_12EgyszemelyesMestintBeadando.Allapotter;
using _2_12EgyszemelyesMestintBeadando.Keresok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_12EgyszemelyesMestintBeadando
{
    public partial class Form1 : Form
    {
        Allapot allapot = new Allapot();
        List<Kereso> kereso = new List<Kereso>();

        List<Allapot> megoldas = new List<Allapot>();

        int aktualisAllapot = 0;
        public Form1()
        {
            
            InitializeComponent();
            //kb 30 másodperc a build time
            kereso.Add(new Szelessegi());
            kereso.Add(new Backtrack());
            kereso.Add(new BestFirst());
            


            megoldas = kereso[0].Utvonal;

            foreach (Kereso k in kereso)
            {
                comboBox1.Items.Add(k.GetType().Name);
            }
            comboBox1.SelectedIndex = 0;
            Draw();
           
        }
        Graphics graphics;
        private void Draw()
        {
      
            Bitmap image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = image;
            graphics = Graphics.FromImage(image);

            graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, pictureBox1.Width, pictureBox1.Height-45);
            graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 45, pictureBox1.Width, pictureBox1.Height);
            int eltolasRekesz = 0;
            int[] rekesz = megoldas[aktualisAllapot].Rekesz;
            
            for (int i = 0; i < rekesz.Length; i++)
            {
                if (rekesz[i]==1)
                {
                    graphics.FillEllipse(new SolidBrush(Color.Red), 10+ eltolasRekesz, pictureBox1.Height / 2 - 15, 30,30);
                }
                else if (rekesz[i] == 2)
                {
                    graphics.FillEllipse(new SolidBrush(Color.Black), 10+ eltolasRekesz, pictureBox1.Height/2-15, 30, 30);
                }
                graphics.FillRectangle(new SolidBrush(Color.Blue), 0 + eltolasRekesz, 0, 5, pictureBox1.Height);
      
                eltolasRekesz += 45;
                label1.Text = "Lépések száma (Kezdőállapottal együtt): " + megoldas.Count;

               
            }
            Console.WriteLine();
     
            }

     

        private void next_btn_Click(object sender, EventArgs e)
        {
            if (aktualisAllapot < megoldas.Count - 1) aktualisAllapot++;
            Draw();
        }

        private void prev_btn_Click(object sender, EventArgs e)
        {
            if (aktualisAllapot > 0) aktualisAllapot--;
           Draw();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            megoldas = kereso[comboBox1.SelectedIndex].Utvonal;
            aktualisAllapot = 0;
            Draw();
        }
    }
}
