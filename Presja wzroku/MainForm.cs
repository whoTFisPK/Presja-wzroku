using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Presja_wzroku
{
    public partial class MainForm : Form
    {
        private TimerPanel timerPanel;
        private HeartsPanel heartsPanel;
        private Panel currentChildPanel;
        private int currentLives = 3; // Tutaj dodajemy zmienn¹ dla ¿yæ
        private List<string> techniki; // Lista przechowuj¹ca linie z pliku Techniki.txt

        public MainForm()
        {
            this.Text = "Presja Wzroku";
            this.Size = new Size(1280, 1024);

            this.StartPosition = FormStartPosition.CenterScreen;

            heartsPanel = new HeartsPanel(3) // 3 ¿ycia domyœlnie
            {
                Visible = false, // Domyœlnie ukrywamy panel serc
                Location = new Point(1050, 10) // W prawym górnym rogu
            };
            this.Controls.Add(heartsPanel);


            timerPanel = new TimerPanel(10)
            {
                Visible = false // Domyœlnie ukrywamy timer
            };
            this.Controls.Add(timerPanel);


            OpenChildForm(new Menu(this));

            // Ustawienie nas³uchiwania na klawisze
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;

            ZaladujTechniki(); // £adowanie technik
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                // Zatrzymaj i ukryj timer
                StopTimer();
                HideTimer();

                // Ukryj serca
                HideHearts();

                // Przejœcie do menu
                OpenChildForm(new Menu(this));
            }
        }

        public void ShowHearts()
        {
            heartsPanel.ResetLives(currentLives);
            heartsPanel.Visible = true;
        }

        public void HideHearts()
        {
            heartsPanel.Visible = false;
        }

        public void LoseLife()
        {
            if (currentLives > 0)
            {
                currentLives--;
                heartsPanel.LoseLife();
            }

            if (currentLives == 0)
            {
                StopTimer(); // Zatrzymaj timer
                HideTimer();
                HideHearts();
                MessageBox.Show("Koniec gry! Brak ¿yæ.", "Przegrana");
                PokazLosowaTechnika(); // Wyœwietlenie losowej techniki 
                OpenChildForm(new Menu(this)); // Powrót do menu
            }
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

            // Reset ¿ycia tylko przy przejœciu do menu
            if (childPanel is Menu)
            {
                currentLives = 3;
            }

            // Upewniamy siê, ¿e timer i ¿ycia jest na wierzchu
            heartsPanel.BringToFront();
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

        private void ZaladujTechniki()
        {
            techniki = new List<string>();

            try
            {
                // Œcie¿ka do pliku Techniki.txt
                string[] lines = File.ReadAllLines("Techniki.txt");

                // Dodajemy ka¿d¹ liniê z pliku do listy
                techniki.AddRange(lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d wczytywania pliku: " + ex.Message);
            }
        }

        // Metoda, która wyœwietla losow¹ liniê z pliku
        public void PokazLosowaTechnika()
        {
            Random rand = new Random();
            int index = rand.Next(techniki.Count); // Losowanie indeksu z zakresu liczby linii
            string randomLine = techniki[index];  // Pobranie losowej linii

            // Wyœwietlenie losowej linii (np. w oknie dialogowym)
            MessageBox.Show(randomLine, "Nic siê nie sta³o! Nastêpnym razem spróbuj tego!");
        }
    }
}
