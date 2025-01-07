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
        /** Panel wyœwietlaj¹cy timer, u¿ywane do odliczania czasu */
        public TimerPanel timerPanel;
        /** Panel wyœwietlaj¹cy serca, u¿ywane do œledzenia ¿ycia gracza */
        private HeartsPanel heartsPanel;
        /** Aktualnie aktywny panel (np. g³ówny panel gry) */
        private Panel currentChildPanel;
        /** Zmienna przechowuj¹ca liczbê ¿yæ gracza */
        private int currentLives = 3;
        /** Lista przechowuj¹ca linie z pliku Techniki.txt */
        private List<string> techniki;


        public MainForm()
        {
            this.Text = "Presja Wzroku";
            this.Size = new Size(1280, 1024);

            this.StartPosition = FormStartPosition.CenterScreen;

            /** 3 ¿ycia domyœlnie */
            heartsPanel = new HeartsPanel(3) 
            {
                /** Domyœlnie ukrywamy panel serc */
                Visible = false,
                /** W prawym górnym rogu */
                Location = new Point(1050, 10) 
            };
            this.Controls.Add(heartsPanel);


            timerPanel = new TimerPanel(10, this)
            {
                /** Domyœlnie ukrywamy timer */
                Visible = false 
            };
            this.Controls.Add(timerPanel);


            OpenChildForm(new Menu(this));

            /** Ustawienie nas³uchiwania na klawisze */
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;

            /** £adowanie technik */
            ZaladujTechniki(); 
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                /** Zatrzymaj i ukryj timer */
                timerPanel.Stop();
                timerPanel.Visible = false;

                /** Ukryj serca */
                heartsPanel.Visible = false;

                /** Przejœcie do menu */
                OpenChildForm(new Menu(this));
            }
        }

        public void ShowHearts()
        {
            /** Resetowanie liczby ¿yæ w panelu serca na wartoœæ currentLives */
            heartsPanel.ResetLives(currentLives);
            /** Ustawienie widocznoœci panelu serca na true */
            heartsPanel.Visible = true;
        }

        public void LoseLife()
        {
            /** Sprawdzenie, czy gracz ma jeszcze ¿ycia */
            if (currentLives > 0)
            {
                /** Zmniejszenie liczby ¿yæ o 1 */
                currentLives--;
                /** Aktualizacja panelu z sercami, aby odzwierciedliæ utratê ¿ycia */
                heartsPanel.LoseLife();
            }

            /** Sprawdzenie, czy gracz straci³ wszystkie ¿ycia */
            if (currentLives == 0)
            {
                /** Zatrzymanie timera */
                timerPanel.Stop();
                /** Ukrycie panelu timera */
                timerPanel.Visible = false;
                /** Ukrycie panelu serc */
                heartsPanel.Visible = false;
                /** Wyœwietlenie komunikatu o przegranej */
                MessageBox.Show("Koniec gry! Brak ¿yæ.", "Przegrana");
                /** Wyœwietlenie losowej techniki */
                PokazLosowaTechnika();
                /** Powrót do menu */
                OpenChildForm(new Menu(this));
            }
        }


        public void OpenChildForm(Panel childPanel)
        {
            /** Usuwamy poprzedni panel */
            if (currentChildPanel != null)
            {
                this.Controls.Remove(currentChildPanel);
            }

            /** Dodajemy nowy panel */
            currentChildPanel = childPanel;
            childPanel.Dock = DockStyle.Fill;
            this.Controls.Add(childPanel);

            /** Reset ¿ycia tylko przy przejœciu do menu */
            if (childPanel is Menu)
            {
                currentLives = 3;
            }

            /** Upewniamy siê, ¿e timer i ¿ycia jest na wierzchu */
            heartsPanel.BringToFront();
            timerPanel.BringToFront();
        }

        public void ShowTimer(int seconds)
        {
            timerPanel.Reset(seconds);
            timerPanel.Visible = true;
        }

        private void ZaladujTechniki()
        {
            techniki = new List<string>();

            try
            {
                /** Œcie¿ka do pliku Techniki.txt */
                string[] lines = File.ReadAllLines("Techniki.txt");

                /** Dodajemy ka¿d¹ liniê z pliku do listy */
                techniki.AddRange(lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d wczytywania pliku: " + ex.Message);
            }
        }

        /** Metoda, która wyœwietla losow¹ liniê z pliku */
        public void PokazLosowaTechnika()
        {
            Random rand = new Random();
            /** Losowanie indeksu z zakresu liczby linii */
            int index = rand.Next(techniki.Count);
            /** Pobranie losowej linii */
            string randomLine = techniki[index];

            /** Wyœwietlenie losowej linii (np. w oknie dialogowym) */
            MessageBox.Show(randomLine, "Spróbuj tej techniki!");
        }
    }
}
