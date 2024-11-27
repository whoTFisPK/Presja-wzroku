using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presja_wzroku
{
    public partial class Poziom1 : Form
    {
        private PictureBox pbBackground;
        private int waldoPosX;
        private int waldoPosY;
        private const int waldoWidth = 50;  // Szerokość Waldo
        private const int waldoHeight = 50; // Wysokość Waldo
        private Random rand;

        public Poziom1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitGame();
        }

        private void InitGame()
        {
            // Ustawienia głównego okna
            this.Text = "Presja wzroku";
            this.Size = new Size(1280, 1024);

            // Obraz tła
            pbBackground = new PictureBox
            {
                Image = Properties.Resources.background,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(pbBackground);

            // Ustaw losową pozycję dla Waldo
            rand = new Random();
            ResetGame();

            // Event kliknięcia w tło
            pbBackground.MouseDown += PbBackground_MouseDown; // Użyj MouseDown
        }

        private void PbBackground_MouseDown(object sender, MouseEventArgs e)
        {
            // Debugowanie - wyświetl kliknięte współrzędne
            Console.WriteLine($"Clicked at: {e.X}, {e.Y}");
            Console.WriteLine($"Waldo position: {waldoPosX}, {waldoPosY}");

            // Sprawdzenie czy gracz kliknął na Waldo
            if (e.X >= waldoPosX && e.X <= waldoPosX + waldoWidth &&
                e.Y >= waldoPosY && e.Y <= waldoPosY + waldoHeight)
            {
                MessageBox.Show("Gratulacje! Znalazłeś Waldo!", "Sukces");
                // Reset gry
                ResetGame();
            }
            else
            {
                MessageBox.Show("Spróbuj jeszcze raz!", "Pudło");
            }
        }

        private void ResetGame()
        {
            // Losowanie nowej pozycji dla Waldo
            waldoPosX = rand.Next(0, pbBackground.Width - waldoWidth);
            waldoPosY = rand.Next(0, pbBackground.Height - waldoHeight);
            pbBackground.Invalidate(); // Odśwież tło, aby zaktualizować ekran
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Rysowanie Waldo na tle
            e.Graphics.DrawImage(Properties.Resources.waldo, waldoPosX, waldoPosY, waldoWidth, waldoHeight);
        }
    }
}
