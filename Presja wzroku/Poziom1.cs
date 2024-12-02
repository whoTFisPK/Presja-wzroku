using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presja_wzroku
{
    public partial class Poziom1 : Panel
    {
        private MainForm parent;
        private PictureBox pbBackground;

        private int waldoPosX = 1066;
        private int waldoPosY = 699;
        private const int waldoWidth = 28;
        private const int waldoHeight = 60;

        public Poziom1(MainForm parent)
        {
            this.parent = parent;
            InitGame();
            parent.ShowTimer(10); // Pokazanie timera przy rozpoczęciu poziomu
            parent.ShowHearts(3); // Wyświetl 3 życia
        }

        private void InitGame()
        {
            this.Size = new Size(1280, 1024);

            pbBackground = new PictureBox
            {
                Image = Properties.Resources.background1,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(pbBackground);

            pbBackground.MouseDown += PbBackground_MouseDown;
        }

        private void PbBackground_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X >= waldoPosX && e.X <= waldoPosX + waldoWidth &&
                e.Y >= waldoPosY && e.Y <= waldoPosY + waldoHeight)
            {
                parent.StopTimer(); // Zatrzymanie timera
                MessageBox.Show("Gratulacje! Znalazłeś Waldo!", "Sukces");
                parent.OpenChildForm(new Poziom2(parent)); // Przejście do kolejnego poziomu
            }
            else
            {
                MessageBox.Show("Spróbuj jeszcze raz!", "Pudło");
                parent.LoseLife(); // Gracz traci życie
            }
        }
    }
}
