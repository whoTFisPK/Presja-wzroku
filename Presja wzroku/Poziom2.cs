using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presja_wzroku
{
    public partial class Poziom2 : Panel
    {
        private MainForm parent;
        private PictureBox pbBackground;
        private TimerPanel timerPanel;

        private int waldoPosX = 771;
        private int waldoPosY = 382;
        private const int waldoWidth = 20;
        private const int waldoHeight = 50;

        public Poziom2(MainForm parent)
        {
            this.parent = parent;
            InitGame();
        }

        private void InitGame()
        {
            this.Size = new Size(1280, 1024);

            timerPanel = new TimerPanel(10); // Odliczanie 10 sekund
            this.Controls.Add(timerPanel);

            pbBackground = new PictureBox
            {
                Image = Properties.Resources.background2,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(pbBackground);

            pbBackground.MouseDown += PbBackground_MouseDown;
        }

        private void PbBackground_MouseDown(object sender, MouseEventArgs e)
        {
            //Console.WriteLine($"Clicked at: X={e.X}, Y={e.Y}");

            if (e.X >= waldoPosX && e.X <= waldoPosX + waldoWidth &&
                e.Y >= waldoPosY && e.Y <= waldoPosY + waldoHeight)
            {
                MessageBox.Show("Gratulacje! Znalazłeś Waldo!", "Sukces");
                parent.OpenChildForm(new Poziom2(parent));
            }
            else
            {
                MessageBox.Show("Spróbuj jeszcze raz!", "Pudło");
            }
        }
    }
}
