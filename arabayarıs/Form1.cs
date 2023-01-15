using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace arabayarıs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        int kazanilanPuan = 0;
        int yolHizi = 5;
        int arabaHizi = 5;
        bool solYon = false;
        bool sagYon = false;
        int digerArabaHizi = 5;

       
        
        private void Form1_Load(object sender, EventArgs e)
        {
            oyunuBaslat();
            timer1.Enabled = true;
        }

        private void sesAc()
        {
            SoundPlayer müzik = new SoundPlayer();
            string Sesyol = Application.StartupPath + "\\muzik.wav";
            müzik.SoundLocation = Sesyol;
            müzik.Play();
        }
        private void patlamases()
        {
            SoundPlayer patlamases = new SoundPlayer();
            string sesyol = Application.StartupPath + "\\exp.wav";
            patlamases.SoundLocation = sesyol;
            patlamases.Play();

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            kazanilanPuan++;
            label2.Text = kazanilanPuan.ToString();
            yol.Top += arabaHizi;
            if (yol.Top > 125)
            {
                yol.Top = -100;
            }
            if (solYon) { bizimaraba.Left -= 5; }
            if (sagYon) { bizimaraba.Left += 5; }
            if (bizimaraba.Left < 1) { solYon = false; }
            else if (bizimaraba.Left + bizimaraba.Width > panel1.Width) { sagYon = false; }

            araba1.Top += arabaHizi;
            araba2.Top += arabaHizi;

            if (araba1.Top > panel1.Height)
            {
                araba1degistir();
                araba1.Left = rnd.Next(20, 155);
                araba1.Top = rnd.Next(40, 140)*(-1);
            }
            if (araba2.Top > panel1.Height)
            {
                araba2degistir();
                araba2.Left = rnd.Next(100, 300);
                araba2.Top = rnd.Next(40, 140)*(-1);
            }
            if (bizimaraba.Bounds.IntersectsWith(araba1.Bounds) || bizimaraba.Bounds.IntersectsWith(araba2.Bounds))
            {
                oyunbitti();

            }

        }
        public void oyunbitti()
        {
            timer1.Stop();
            btn_oyunbaslat.Enabled = true;
            patlama.Visible = true;
            patlamases();
            bizimaraba.Controls.Add(patlama);
            patlama.Location = new Point(7, -5);
            if(Convert.ToInt32(label2.Text) > Convert.ToInt32(label4.Text)) { label4.Text=label2.Text; }
            patlama.BringToFront();
            patlama.BackColor = Color.Transparent;
            MessageBox.Show("Tebrikler kazandığınız puan:" + label2.Text, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void oyunuBaslat()
        {
            sesAc();
            yol.Top += arabaHizi;
            btn_oyunbaslat.Enabled = false;
            patlama.Visible = false;
            arabaHizi = 5;
            digerArabaHizi = 5;
            kazanilanPuan = 0;

            bizimaraba.Left = 160;
            bizimaraba.Top = 300;

            araba1.Left = 30;
            araba1.Top = 50;
            araba2.Left = 320;
            araba2.Top = 50;

            solYon = false;
            sagYon = false;
            patlama.Left = 165;
            patlama.Top = 294;
            timer1.Enabled = true;

        }
        public void araba1degistir()
        {
            int sira = rnd.Next(1, 8);

            switch (sira)
            {
                case 1:
                    araba1.Image = Properties.Resources.araba3;
                    break;

                case 2:
                    araba1.Image = Properties.Resources.araba4;
                    break;
                case 3:
                    araba1.Image = Properties.Resources.araba5;
                    break;
                case 4:
                    araba1.Image = Properties.Resources.araba6;
                    break;
                case 5:
                    araba1.Image = Properties.Resources.araba7;
                    break;
                case 6:
                    araba1.Image = Properties.Resources.araba8;
                    break;
                case 7:
                    araba1.Image = Properties.Resources.araba9;
                    break;
                case 8:
                    araba1.Image = Properties.Resources.asd;
                    break;




            }


        }
        public void araba2degistir()
        {
            int sira = rnd.Next(1, 8);

            switch (sira)
            {
                case 1:
                    araba2.Image = Properties.Resources.araba3;
                    break;

                case 2:
                    araba2.Image = Properties.Resources.araba4;
                    break;
                case 3:
                    araba2.Image = Properties.Resources.araba5;
                    break;
                case 4:
                    araba2.Image = Properties.Resources.araba6;
                    break;
                case 5:
                    araba2.Image = Properties.Resources.araba7;
                    break;
                case 6:
                    araba2.Image = Properties.Resources.araba8;
                    break;
                case 7:
                    araba2.Image = Properties.Resources.araba9;
                    break;
                case 8:
                    araba2.Image = Properties.Resources.asd;
                    break;


            }
        }

        private void btn_oyunbaslat_Click(object sender, EventArgs e)
        {
            oyunuBaslat();
        }

        private void patlama_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && bizimaraba.Left > 0) { solYon = true; }
            if (e.KeyCode == Keys.Right && bizimaraba.Left+bizimaraba.Width < panel1.Width) { sagYon = true; }



        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) { solYon = false; }
            if ( e.KeyCode == Keys.Right) { sagYon = false; }
        }
    }
}
