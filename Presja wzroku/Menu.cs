using Presja_wzroku;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presja_wzroku
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            // Ustawienia menu
            this.Text = "Menu Główne";
            this.BackColor = Color.White;
            this.Size = new Size(1280, 1024);

            // Przycisk "Rozpocznij grę"
            Button btnStartGame = new Button
            {
                Text = "Rozpocznij grę",
                Font = new Font("Arial", 16, FontStyle.Bold),
                Size = new Size(200, 50),
                Location = new Point((this.ClientSize.Width - 200) / 2, 200),
                Anchor = AnchorStyles.Top
            };
            btnStartGame.Click += BtnStartGame_Click;

            // Przycisk "Wyjdź z gry"
            Button btnExitGame = new Button
            {
                Text = "Wyjdź z gry",
                Font = new Font("Arial", 16, FontStyle.Bold),
                Size = new Size(200, 50),
                Location = new Point((this.ClientSize.Width - 200) / 2, 300),
                Anchor = AnchorStyles.Top
            };
            btnExitGame.Click += BtnExitGame_Click;

            // Dodanie przycisków do formularza
            this.Controls.Add(btnStartGame);
            this.Controls.Add(btnExitGame);
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            // Przejście do gry
            MainForm mainForm = (MainForm)this.ParentForm;
            mainForm.OpenChildForm(new Poziom1()); // Otwiera nowy poziom
        }

        private void BtnExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Zakończenie programu
        }
    }
}