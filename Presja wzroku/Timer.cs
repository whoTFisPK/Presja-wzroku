using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Presja_wzroku
{
    public class TimerPanel : Panel
    {
        private Label timerLabel;
        private System.Windows.Forms.Timer timer;
        private int timeLeft;

        public TimerPanel(int seconds)
        {
            timeLeft = seconds;
            InitializeTimerPanel();
        }

        private void InitializeTimerPanel()
        {
            this.Size = new Size(130, 50);
            this.BackColor = Color.LightGray;

            this.Padding = new Padding(5);
            this.BorderStyle = BorderStyle.FixedSingle;

            timerLabel = new Label
            {
                Text = $"Czas: {timeLeft}s",
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            this.Controls.Add(timerLabel);

            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += (sender, e) =>
            {
                timeLeft--;
                if (timeLeft <= 0)
                {
                    timer.Stop();
                    MessageBox.Show("Koniec czasu!", "Przegrana");
                }
                UpdateLabel();
            };
        }

        public void Reset(int seconds)
        {
            timer.Stop();
            timeLeft = seconds;
            UpdateLabel();
            timer.Start();
        }

        public void Stop()
        {
            if (timer != null)
            {
                timer.Stop(); // Zatrzymaj timer wewnętrzny
            }
        }

        private void UpdateLabel()
        {
            timerLabel.Text = $"Czas: {timeLeft}s";
        }
    }
}
