using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presja_wzroku
{
    public class Menu : Panel
    {
        private MainForm parentForm;

        public Menu(MainForm parent)
        {
            parentForm = parent;
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            this.BackColor = Color.White;
            this.Size = new Size(1280, 1024);

            Button btnStartGame = new Button
            {
                Text = "Rozpocznij grę",
                Size = new Size(200, 50),
                Location = new Point(500, 200)
            };
            btnStartGame.Click += (sender, e) =>
            {
                parentForm.OpenChildForm(new Poziom1(parentForm));
            };

            Button btnExit = new Button
            {
                Text = "Wyjdź z gry",
                Size = new Size(200, 50),
                Location = new Point(500, 300)
            };
            btnExit.Click += (sender, e) => Application.Exit();

            this.Controls.Add(btnStartGame);
            this.Controls.Add(btnExit);
        }
    }
}
