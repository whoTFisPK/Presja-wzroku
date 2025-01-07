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
        /** Panel wy�wietlaj�cy timer, u�ywane do odliczania czasu */
        public TimerPanel timerPanel;
        /** Panel wy�wietlaj�cy serca, u�ywane do �ledzenia �ycia gracza */
        private HeartsPanel heartsPanel;
        /** Aktualnie aktywny panel (np. g��wny panel gry) */
        private Panel currentChildPanel;
        /** Zmienna przechowuj�ca liczb� �y� gracza */
        private int currentLives = 3;
        /** Lista przechowuj�ca linie z pliku Techniki.txt */
        private List<string> techniki;


        public MainForm()
        {
            this.Text = "Presja Wzroku";
            this.Size = new Size(1280, 1024);

            this.StartPosition = FormStartPosition.CenterScreen;

            /** 3 �ycia domy�lnie */
            heartsPanel = new HeartsPanel(3) 
            {
                /** Domy�lnie ukrywamy panel serc */
                Visible = false,
                /** W prawym g�rnym rogu */
                Location = new Point(1050, 10) 
            };
            this.Controls.Add(heartsPanel);


            timerPanel = new TimerPanel(10, this)
            {
                /** Domy�lnie ukrywamy timer */
                Visible = false 
            };
            this.Controls.Add(timerPanel);


            OpenChildForm(new Menu(this));

            /** Ustawienie nas�uchiwania na klawisze */
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;

            /** �adowanie technik */
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

                /** Przej�cie do menu */
                OpenChildForm(new Menu(this));
            }
        }

        public void ShowHearts()
        {
            /** Resetowanie liczby �y� w panelu serca na warto�� currentLives */
            heartsPanel.ResetLives(currentLives);
            /** Ustawienie widoczno�ci panelu serca na true */
            heartsPanel.Visible = true;
        }

        public void LoseLife()
        {
            /** Sprawdzenie, czy gracz ma jeszcze �ycia */
            if (currentLives > 0)
            {
                /** Zmniejszenie liczby �y� o 1 */
                currentLives--;
                /** Aktualizacja panelu z sercami, aby odzwierciedli� utrat� �ycia */
                heartsPanel.LoseLife();
            }

            /** Sprawdzenie, czy gracz straci� wszystkie �ycia */
            if (currentLives == 0)
            {
                /** Zatrzymanie timera */
                timerPanel.Stop();
                /** Ukrycie panelu timera */
                timerPanel.Visible = false;
                /** Ukrycie panelu serc */
                heartsPanel.Visible = false;
                /** Wy�wietlenie komunikatu o przegranej */
                MessageBox.Show("Koniec gry! Brak �y�.", "Przegrana");
                /** Wy�wietlenie losowej techniki */
                PokazLosowaTechnika();
                /** Powr�t do menu */
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

            /** Reset �ycia tylko przy przej�ciu do menu */
            if (childPanel is Menu)
            {
                currentLives = 3;
            }

            /** Upewniamy si�, �e timer i �ycia jest na wierzchu */
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
                /** �cie�ka do pliku Techniki.txt */
                string[] lines = File.ReadAllLines("Techniki.txt");

                /** Dodajemy ka�d� lini� z pliku do listy */
                techniki.AddRange(lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("B��d wczytywania pliku: " + ex.Message);
            }
        }

        /** Metoda, kt�ra wy�wietla losow� lini� z pliku */
        public void PokazLosowaTechnika()
        {
            Random rand = new Random();
            /** Losowanie indeksu z zakresu liczby linii */
            int index = rand.Next(techniki.Count);
            /** Pobranie losowej linii */
            string randomLine = techniki[index];

            /** Wy�wietlenie losowej linii (np. w oknie dialogowym) */
            MessageBox.Show(randomLine, "Spr�buj tej techniki!");
        }
    }
}
