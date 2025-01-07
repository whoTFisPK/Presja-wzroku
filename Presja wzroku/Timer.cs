using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presja_wzroku
{
    public class TimerPanel : Panel
    {
        private Label timerLabel;
        private System.Windows.Forms.Timer timer;
        private int timeLeft;
        private MainForm parentForm;

        public TimerPanel(int seconds, MainForm parent)
        {
            timeLeft = seconds;
            parentForm = parent;
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
                Text = $"Czas: {timeLeft}",
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10),
            };
            this.Controls.Add(timerLabel);

            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            if (timeLeft <= 0)
            {
                EndTimer();
            }
            else
            {
                UpdateLabel();
            }
        }

        private void EndTimer()
        {
            timer.Stop();
            MessageBox.Show("Koniec czasu!", "Przegrana");
            this.Visible = false;
            parentForm.OpenChildForm(new Menu(parentForm));
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
                timer.Stop();
            }
        }

        private void UpdateLabel()
        {
            timerLabel.Text = $"Czas: {timeLeft}";
        }
    }
}
