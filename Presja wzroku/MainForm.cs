using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presja_wzroku
{
    public partial class MainForm : Form
    {
        private Panel panelContainer; // Panel do wyœwietlania dynamicznych formularzy
        private Form activeForm; // Przechowywanie aktualnie otwartego formularza

        public MainForm()
        {
            InitializeComponent();
            InitializeMainForm();

            // Wyœwietlenie menu na starcie
            OpenChildForm(new Menu());
        }

        private void InitializeMainForm()
        {
            // Ustawienia g³ównego okna
            this.Text = "Presja Wzroku";
            this.Size = new Size(1280, 1024);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Inicjalizacja panelu
            panelContainer = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray // Opcjonalne t³o panelu
            };

            // Dodanie panelu do g³ównej formy
            this.Controls.Add(panelContainer);
        }

        /// <summary>
        /// Dynamiczne otwieranie formularza wewn¹trz panelu
        /// </summary>
        /// <param name="childForm">Formularz do otwarcia</param>
        public void OpenChildForm(Form childForm)
        {
            // Zamkniêcie aktualnego formularza, jeœli istnieje
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContainer.Controls.Clear(); // Usuñ poprzedni formularz z panelu
            panelContainer.Controls.Add(childForm); // Dodaj nowy formularz
            panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}