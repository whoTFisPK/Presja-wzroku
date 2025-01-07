using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Presja_wzroku
{
    public abstract class BaseLevel : Panel
    {
        protected TimerPanel timerPanel;
        protected MainForm parent;
        protected PictureBox pbBackground;
        protected Label countdownLabel;
        protected System.Windows.Forms.Timer countdownTimer;
        protected int countdownValue = 3;
        protected bool gameEnded = false;
        protected bool technikaPokazana = false;

        protected abstract int WaldoPosX { get; }
        protected abstract int WaldoPosY { get; }
        protected abstract int WaldoWidth { get; }
        protected abstract int WaldoHeight { get; }
        protected abstract string BackgroundImageResource { get; }

        public BaseLevel(MainForm parent)
        {
            this.parent = parent;
            this.timerPanel = parent.timerPanel;
            InitGame();
            parent.ShowHearts(); 
            StartCountdown(); 
        }

        private void InitGame()
        {
            this.Size = new Size(1280, 1024);

            pbBackground = new PictureBox
            {
                Image = (Image)Properties.Resources.ResourceManager.GetObject(BackgroundImageResource),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(pbBackground);

            pbBackground.MouseDown += PbBackground_MouseDown;

            countdownLabel = new Label
            {
                Text = "",
                Font = new Font("Arial", 48, FontStyle.Bold),
                ForeColor = Color.Red,
                BackColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(countdownLabel);
            /** Ustawienie Label na wierzchu */
            countdownLabel.BringToFront(); 
        }

        private void StartCountdown()
        {
            /** Sprawdzamy, czy technika została już wyświetlona */
            if (!technikaPokazana)  
            {
                /** Wyświetlenie losowej techniki przed odliczaniem */
                parent.PokazLosowaTechnika();
                /** Oznaczamy, że technika została już pokazana */
                technikaPokazana = true; 
            }

            countdownTimer = new System.Windows.Forms.Timer
            {
                /** Odliczanie co sekundę */
                Interval = 1000 
            };
            countdownTimer.Tick += CountdownTimer_Tick;
            /** Ustawienie początkowej wartości odliczania */
            countdownValue = 3; 
            countdownLabel.Text = countdownValue.ToString();
            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            countdownValue--;
            if (countdownValue > 0)
            {
                countdownLabel.Text = countdownValue.ToString();
                /** Wymuszenie odświeżenia GUI */
                Application.DoEvents(); 
            }
            else
            {
                countdownTimer.Stop();
                /** Ukrycie etykiety odliczania */
                countdownLabel.Visible = false; 
                StartGame();
            }
        }

        protected abstract void StartGame();

        private void PbBackground_MouseDown(object sender, MouseEventArgs e)
        {
            if (gameEnded) return;

            if (e.X >= WaldoPosX && e.X <= WaldoPosX + WaldoWidth &&
                e.Y >= WaldoPosY && e.Y <= WaldoPosY + WaldoHeight)
            {
                gameEnded = true;
                SoundPlayer player = new SoundPlayer(Properties.Resources.dobrze);
                player.Play();

                timerPanel.Stop();
                MessageBox.Show("Gratulacje! Znalazłeś Waldo!", "Sukces");
                /** Przejście do kolejnego poziomu */
                parent.OpenChildForm(NextLevel()); 
            }
            else
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.zle);
                player.Play();
                parent.LoseLife();
            }
        }

        protected abstract Panel NextLevel();
    }
}
