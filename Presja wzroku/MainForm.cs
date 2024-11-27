using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presja_wzroku
{
    public partial class MainForm : Form
    {
        private PictureBox pbBackground;
        private int waldoPosX;
        private int waldoPosY;
        private const int waldoWidth = 50;  // Szeroko�� Waldo
        private const int waldoHeight = 50; // Wysoko�� Waldo
        private Random rand;

        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitGame();
        }

        private void InitGame()
        {
            // Ustawienia g��wnego okna
            this.Text = "Presja wzroku";
            this.Size = new Size(1280, 1024);

            // Obraz t�a
            pbBackground = new PictureBox
            {
                Image = Properties.Resources.background,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(pbBackground);

            // Ustaw losow� pozycj� dla Waldo
            rand = new Random();
            ResetGame();

            // Event klikni�cia w t�o
            pbBackground.MouseDown += PbBackground_MouseDown; // U�yj MouseDown
        }

        private void PbBackground_MouseDown(object sender, MouseEventArgs e)
        {
            // Debugowanie - wy�wietl klikni�te wsp�rz�dne
            Console.WriteLine($"Clicked at: {e.X}, {e.Y}");
            Console.WriteLine($"Waldo position: {waldoPosX}, {waldoPosY}");

            // Sprawdzenie czy gracz klikn�� na Waldo
            if (e.X >= waldoPosX && e.X <= waldoPosX + waldoWidth &&
                e.Y >= waldoPosY && e.Y <= waldoPosY + waldoHeight)
            {
                MessageBox.Show("Gratulacje! Znalaz�e� Waldo!", "Sukces");
                // Reset gry
                ResetGame();
            }
            else
            {
                MessageBox.Show("Spr�buj jeszcze raz!", "Pud�o");
            }
        }

        private void ResetGame()
        {
            // Losowanie nowej pozycji dla Waldo
            waldoPosX = rand.Next(0, pbBackground.Width - waldoWidth);
            waldoPosY = rand.Next(0, pbBackground.Height - waldoHeight);
            pbBackground.Invalidate(); // Od�wie� t�o, aby zaktualizowa� ekran
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Rysowanie Waldo na tle
            e.Graphics.DrawImage(Properties.Resources.waldo, waldoPosX, waldoPosY, waldoWidth, waldoHeight);
        }
    }
}