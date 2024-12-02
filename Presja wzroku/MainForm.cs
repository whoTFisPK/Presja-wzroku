using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presja_wzroku
{
    public partial class MainForm : Form
    {
        private TimerPanel timerPanel;
        private HeartsPanel heartsPanel;
        private Panel currentChildPanel;

        public MainForm()
        {
            this.Text = "Presja Wzroku";
            this.Size = new Size(1280, 1024);

            this.StartPosition = FormStartPosition.CenterScreen;

            timerPanel = new TimerPanel(10)
            {
                Visible = false // Domyœlnie ukrywamy timer
            };
            this.Controls.Add(timerPanel);

            heartsPanel = new HeartsPanel(3) // 3 ¿ycia domyœlnie
            {
                Visible = false, // Domyœlnie ukrywamy panel serc
                Location = new Point(1050, 10) // W prawym górnym rogu
            };
            this.Controls.Add(heartsPanel);

            OpenChildForm(new Menu(this));
        }

        public void ShowHearts(int totalLives)
        {
            heartsPanel.ResetLives(totalLives);
            heartsPanel.Visible = true;
        }

        public void HideHearts()
        {
            heartsPanel.Visible = false;
        }

        public void LoseLife()
        {
            heartsPanel.LoseLife();
        }

        public void OpenChildForm(Panel childPanel)
        {
            // Usuwamy poprzedni panel
            if (currentChildPanel != null)
            {
                this.Controls.Remove(currentChildPanel);
            }

            // Dodajemy nowy panel
            currentChildPanel = childPanel;
            childPanel.Dock = DockStyle.Fill;
            this.Controls.Add(childPanel);

            // Upewniamy siê, ¿e timer jest na wierzchu
            timerPanel.BringToFront();
        }

        public void ShowTimer(int seconds)
        {
            timerPanel.Reset(seconds);
            timerPanel.Visible = true;
        }

        public void HideTimer()
        {
            timerPanel.Visible = false;
        }

        public void StopTimer()
        {
            timerPanel.Stop();
        }
    }
}
