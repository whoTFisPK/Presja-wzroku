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

            /** Ustawiamy obraz z zasobów jako tło panelu */
            this.BackgroundImage = Properties.Resources.MENU;
            /** Dopasowanie do rozmiaru */
            this.BackgroundImageLayout = ImageLayout.Stretch; 

            Button btnStartGame = new Button
            {
                Text = "ROZPOCZNIJ GRĘ",
                Size = new Size(500, 100),
                Location = new Point(375, 318),
                BackColor = Color.LightBlue, 
                ForeColor = Color.DarkBlue,
                Font = new Font("Arial", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
            };
            //btnStartGame.MouseEnter += (s, e) => btnStartGame.BackColor = Color.DarkBlue; <---Hover
            //btnStartGame.MouseLeave += (s, e) => btnStartGame.BackColor = Color.LightBlue; <---Hover
            //btnStartGame.MouseEnter += (s, e) => btnStartGame.Size = new Size(520, 120); <---Powiększanie hover
            //btnStartGame.MouseLeave += (s, e) => btnStartGame.Size = new Size(500, 100); <---Powiększanie hover
            btnStartGame.Click += (sender, e) =>
            {
                MessageBox.Show("Witaj w grze PRESJA WZROKU!\n\n" +
                                "Twoim zadaniem jest znalezienie Waldo zanim upłynie czas. Szukając go pamiętaj o jego znakach rozpoznawczych: biało-czerwony sweter w " +
                                "paski, biało-czerwona czapka z pomponem oraz okulary. Czasami ma ze sobą rónież swój duży plecak podróżniczy ;)\n\n" +
                                "Gdy już znajdziesz Waldo naciśnij na niego LPM (Lewym Przyciskiem Myszy). Pamiętaj, że możesz pomylić się tylko 3 razy oraz, że możesz w " +
                                "dowolnym momencie przerwać rozgrywkę i wrócić do menu za pomocą klawisz P na klawiaturze\n\n" +
                                "POWODZENIA!", "Instrukcja");

                /** Tworzymy instancję konkretnego poziomu, np. Poziom1 */
                BaseLevel level = new Tutorial(parentForm);
                /** Otwórz poziom w formularzu głównym */
                parentForm.OpenChildForm(level);  
            };

            Button btnExit = new Button
            {
                Text = "WYJDŹ Z GRY",
                Size = new Size(500, 100),
                Location = new Point(375, 512),
                BackColor = Color.LightBlue,
                ForeColor = Color.DarkBlue,
                Font = new Font("Arial", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,  
            };
            btnExit.Click += (sender, e) => Application.Exit();

            this.Controls.Add(btnStartGame);
            this.Controls.Add(btnExit);
        }
    }
}
