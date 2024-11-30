using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presja_wzroku
{
    public class TimerPanel : Panel
    {
        private Label lblTimer;
        private System.Windows.Forms.Timer timer;
        private int timeLeft; // Pozostały czas w sekundach

        public TimerPanel(int countdownTime)
        {
            timeLeft = countdownTime;
            InitializeTimerPanel();
        }

        private void InitializeTimerPanel()
        {
            this.Size = new Size(200, 50);
            this.BackColor = Color.LightGray;
            this.Location = new Point(0, 0);

            lblTimer = new Label
            {
                Text = FormatTime(timeLeft),
                Font = new Font("Arial", 16, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblTimer);

            timer = new System.Windows.Forms.Timer { Interval = 1000 }; // 1000 ms = 1 sekunda
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                lblTimer.Text = FormatTime(timeLeft);
            }
            else
            {
                timer.Stop();
                OnTimeExpired(); // Wywołanie zdarzenia po zakończeniu odliczania
            }
        }

        private string FormatTime(int seconds)
        {
            int minutes = seconds / 60;
            int secs = seconds % 60;
            return $"{minutes:D2}:{secs:D2}"; // Format MM:SS
        }

        protected virtual void OnTimeExpired()
        {
            MessageBox.Show("Czas się skończył!", "Koniec gry");
            Application.Exit(); // Zakończenie programu lub przejście na inny ekran
        }
    }
}