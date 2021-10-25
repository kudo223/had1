using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace had1
{
    public partial class Form1 : Form
    {
        PictureBox had1;
        List<PictureBox> ocasHada1;
        double smer1;
        double rychlost1;

        PictureBox had2;
        List<PictureBox> ocasHada2;
        double rychlost2;
        double smer2;

        Timer timer;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.KeyDown += Form2_KeyDown;
            VytvorHady();
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                smer1 += 0.1;
            }
            else if (e.KeyCode == Keys.D)
            {
                smer1 -= 0.1;
            }
        }
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                smer1 += 0.1;
            }
            else if (e.KeyCode == Keys.Right)
            {
                smer1 -= 0.1;
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            ocasHada1.Add(had1);
            had1 = new PictureBox();
            had1.Size = new Size(10, 10);
            var zmenaX = rychlost1 * Math.Cos(smer1);
            var zmenaY = rychlost1 * -Math.Sin(smer1);
            had1.Location = new Point(ocasHada1.Last().Location.X + (int)zmenaX, ocasHada1.Last().Location.Y + (int)zmenaY);
            had1.BackColor = Color.Blue;
            Controls.Add(had1);

            ocasHada2.Add(had2);
            had2 = new PictureBox();
            had2.Size = new Size(10, 10);
            var zmenaX2 = rychlost2 * Math.Cos(smer2);
            var zmenaY2 = rychlost2 * -Math.Sin(smer2);
            had2.Location = new Point(ocasHada2.Last().Location.X + (int)zmenaX2, ocasHada2.Last().Location.Y + (int)zmenaY2);
            had2.BackColor = Color.Red;
            Controls.Add(had2);

        }
        private void VytvorHady()
        {
            ocasHada1 = new List<PictureBox>();
            smer1 = 0;
            rychlost1 = 2;
            had1 = new PictureBox();
            had1.Size = new Size(10, 10);
            had1.Location = new Point(10, 10);
            had1.BackColor = Color.Blue;
            Controls.Add(had1);

            ocasHada2 = new List<PictureBox>();
            smer2 = 0;
            rychlost2 = -2;
            had2 = new PictureBox();
            had2.Size = new Size(10, 10);
            had2.Location = new Point(935, 10);
            had2.BackColor = Color.Red;
            Controls.Add(had2);
        }
    }
}
