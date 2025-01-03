using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Presja_wzroku
{
    public class Menu : Panel
    {
        private MainForm parentForm;
        private TimerPanel timerPanel;
        private HeartsPanel heartsPanel;

        public Menu(MainForm parent)
        {
            parentForm = parent;
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            this.BackColor = Color.White;
            this.Size = new Size(1280, 1024);

            // Ustawiamy obraz z zasobów jako tło panelu
            this.BackgroundImage = Properties.Resources.MENU; // Plik MENU.png w zasobach
            this.BackgroundImageLayout = ImageLayout.Stretch; // Dopasowanie do rozmiaru panelu

            Button btnStartGame = new Button
            {
                Text = "ROZPOCZNIJ GRĘ",
                Size = new Size(500, 100),
                Location = new Point(375, 318),
                BackColor = Color.LightBlue, // Tło przycisku
                ForeColor = Color.DarkBlue, // Kolor tekstu
                Font = new Font("Arial", 14, FontStyle.Bold), // Czcionka tekstu
                FlatStyle = FlatStyle.Flat, // Styl przycisku
            };
            btnStartGame.Click += (sender, e) =>
            {
                parentForm.OpenChildForm(new Poziom1(parentForm));
            };

            Button btnExit = new Button
            {
                Text = "WYJDŹ Z GRY",
                Size = new Size(500, 100),
                Location = new Point(375, 512),
                BackColor = Color.LightBlue, // Tło przycisku
                ForeColor = Color.DarkBlue, // Kolor tekstu
                Font = new Font("Arial", 14, FontStyle.Bold), // Czcionka tekstu
                FlatStyle = FlatStyle.Flat, // Styl przycisku   
            };
            btnExit.Click += (sender, e) => Application.Exit();

            this.Controls.Add(btnStartGame);
            this.Controls.Add(btnExit);
        }
    }
}
