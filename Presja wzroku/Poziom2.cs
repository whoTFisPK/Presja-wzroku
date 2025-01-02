using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Presja_wzroku
{
    public partial class Poziom2 : Panel
    {
        private MainForm parent;
        private PictureBox pbBackground;

        private int waldoPosX = 771;
        private int waldoPosY = 382;
        private const int waldoWidth = 20;
        private const int waldoHeight = 50;

        public Poziom2(MainForm parent)
        {
            this.parent = parent;
            InitGame();
            parent.ShowTimer(10);
            parent.ShowHearts();
        }

        private void InitGame()
        {
            this.Size = new Size(1280, 1024);

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
            if (e.X >= waldoPosX && e.X <= waldoPosX + waldoWidth &&
                e.Y >= waldoPosY && e.Y <= waldoPosY + waldoHeight)
            {

                // Odtwarzanie dźwięku
                SoundPlayer player = new SoundPlayer(Properties.Resources.dobrze);  // successSound.wav w zasobach
                player.Play();

                parent.StopTimer(); // Zatrzymanie timera
                MessageBox.Show("Gratulacje! Znalazłeś Waldo!", "Sukces");

                parent.OpenChildForm(new Poziom2(parent)); // Przejście do kolejnego poziomu
            }
            else
            {
                // Odtwarzanie dźwięku
                SoundPlayer player = new SoundPlayer(Properties.Resources.zle);  // successSound.wav w zasobach
                player.Play();

                parent.LoseLife(); // Gracz traci życie
            }
        }
    }
}
