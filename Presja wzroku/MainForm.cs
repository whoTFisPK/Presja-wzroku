using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presja_wzroku
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeMainForm();
            OpenChildForm(new Menu(this));
        }

        public void OpenChildForm(Panel childPanel)
        {
            // Usuwanie poprzedniego panelu z kontenera
            this.Controls.Clear();

            // Dodanie nowego panelu
            childPanel.Dock = DockStyle.Fill;
            this.Controls.Add(childPanel);
        }

        private void InitializeMainForm()
        {
            this.Text = "Presja Wzroku";
            this.Size = new Size(1280, 1024);

            // Dodanie panelu Menu jako startowego widoku
            Menu menuPanel = new Menu(this);
            menuPanel.Dock = DockStyle.Fill;
            this.Controls.Add(menuPanel);
        }

        public void OpenChildPanel(Control panel)
        {
            this.Controls.Clear(); // Usuniêcie istniej¹cych elementów (np. poprzednich paneli)
            panel.Dock = DockStyle.Fill;
            this.Controls.Add(panel);
        }
    }
}
