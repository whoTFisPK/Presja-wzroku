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
        private const int waldoWidth = 50;  // Szerokoœæ Waldo
        private const int waldoHeight = 50; // Wysokoœæ Waldo
        private Random rand;

        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitGame();
        }

        private void InitGame()
        {
            // Ustawienia g³ównego okna
            this.Text = "Presja wzroku";
            this.Size = new Size(1280, 1024);

            // Obraz t³a
            pbBackground = new PictureBox
            {
                Image = Properties.Resources.background,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(pbBackground);

            // Ustaw losow¹ pozycjê dla Waldo
            rand = new Random();
            ResetGame();

            // Event klikniêcia w t³o
            pbBackground.MouseDown += PbBackground_MouseDown; // U¿yj MouseDown
        }

        private void PbBackground_MouseDown(object sender, MouseEventArgs e)
        {
            // Debugowanie - wyœwietl klikniête wspó³rzêdne
            Console.WriteLine($"Clicked at: {e.X}, {e.Y}");
            Console.WriteLine($"Waldo position: {waldoPosX}, {waldoPosY}");

            // Sprawdzenie czy gracz klikn¹³ na Waldo
            if (e.X >= waldoPosX && e.X <= waldoPosX + waldoWidth &&
                e.Y >= waldoPosY && e.Y <= waldoPosY + waldoHeight)
            {
                MessageBox.Show("Gratulacje! Znalaz³eœ Waldo!", "Sukces");
                // Reset gry
                ResetGame();
            }
            else
            {
                MessageBox.Show("Spróbuj jeszcze raz!", "Pud³o");
            }
        }

        private void ResetGame()
        {
            // Losowanie nowej pozycji dla Waldo
            waldoPosX = rand.Next(0, pbBackground.Width - waldoWidth);
            waldoPosY = rand.Next(0, pbBackground.Height - waldoHeight);
            pbBackground.Invalidate(); // Odœwie¿ t³o, aby zaktualizowaæ ekran
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Rysowanie Waldo na tle
            e.Graphics.DrawImage(Properties.Resources.waldo, waldoPosX, waldoPosY, waldoWidth, waldoHeight);
        }
    }
}