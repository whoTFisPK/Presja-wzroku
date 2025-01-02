using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presja_wzroku
{
    public class HeartsPanel : Panel
    {
        private PictureBox[] hearts;
        private int currentLives;

        public HeartsPanel(int totalLives)
        {
            currentLives = totalLives;
            InitializeHearts(totalLives);

            this.BackColor = Color.Transparent; // Ustaw tło na przezroczyste
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void InitializeHearts(int totalLives)
        {
            this.Size = new Size(200, 60); // Rozmiar panelu na serca

            hearts = new PictureBox[totalLives];
            int heartWidth = 50;
            int spacing = 10;

            for (int i = 0; i < totalLives; i++)
            {
                hearts[i] = new PictureBox
                {
                    Image = Properties.Resources.Serce_c, // Domyślnie pełne serce
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(heartWidth, heartWidth),
                    Location = new Point(i * (heartWidth + spacing), 0),
                    BackColor = Color.Transparent // Tło obrazków serc również przezroczyste
                };
                this.Controls.Add(hearts[i]);
            }
        }

        public void LoseLife()
        {
            if (currentLives > 0)
            {
                currentLives--;
                hearts[currentLives].Image = Properties.Resources.Serce_b; // Puste serce
            }
        }

        public void ResetLives(int totalLives)
        {
            currentLives = totalLives;

            // Przejdź przez wszystkie serca i ustaw ich grafikę
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < currentLives)
                {
                    hearts[i].Image = Properties.Resources.Serce_c; // Pełne serce
                }
                else
                {
                    hearts[i].Image = Properties.Resources.Serce_b; // Puste serce
                }
            }
        }

    }
}
