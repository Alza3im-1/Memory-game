using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Memory_game
{
    public partial class Kartenpaare_suchen : Form
    {      
        private bool spielGestartet = false;
        private int versuche = 0;
        public Kartenpaare_suchen()
        {
            InitializeComponent();
        }

        PictureBox Pbox;
        byte zustand = 0; //Zustand des Spiels verfolgen (0 keine Karte ausgewählt, 1 eine Karte ausgewählt).
        int verbleibenden_Karten = 8; // Anzahl der verbleibenden Karten im Spiel speicheren.
        byte zeigen = 3;                //Alle Karten Zeigen
        byte übrige_Zeit = 200;

        private void Kartenpaare_suchen_Load(object sender, EventArgs e)
        {
            Neues_Spiel();
        }

        void Bilder_zurücksetzen()
        {
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox pictureBox = control as PictureBox;
                    pictureBox.Image = Properties.Resources.frage;
                }
            }
        }

        void Bild_anzeigen(PictureBox box)
        {
            int tagValue = Convert.ToInt32(box.Tag);

            if (tagValue >= 1 && tagValue <= 8)
            {
                string Ressourcenname = "_" + tagValue.ToString();
                box.Image = (System.Drawing.Image)Properties.Resources.
                ResourceManager.GetObject(Ressourcenname);
            }
            else
            {
                box.Image = Properties.Resources.frage;
            }
        }

        /*#region kommentar
        überprüft wird, ob tagValue zwischen 1 und 8 liegt.Wenn ja, wird der entsprechende Ressourcenname generiert und 
        die entsprechende Ressource abgerufen und der Image-Eigenschaft der PictureBox 
        zugewiesen.Andernfalls wird das Bild "frage" aus den Resources verwendet.
        #endregion
        */

        void Tag_zufällig_festlegen() //Jede Picturebox repräsentiert eine Karte im Memory-Spiel,
                                      //und das Tag wird verwendet, um die Bildpaare zu identifizieren.
        {                             //Random = Zufällig
            List<int> tags = Enumerable.Range(1, 8).ToList();
            tags.AddRange(tags);      //Bereich hinzufügen(Tag)

            Random zufällig = new Random();

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    int randomIndex = zufällig.Next(tags.Count);
                    int tag = tags[randomIndex];
                    tags.RemoveAt(randomIndex);

                    (x as PictureBox).Tag = tag.ToString();
                }
            }
        }

        void Vergleichen(PictureBox previous, PictureBox aktuell)
        {
            if (previous.Tag.ToString() == aktuell.Tag.ToString())
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);//aktuellen Thread für "500" Millisekunden pausiren.
                                                   //dem Benutzer die sichtbare Darstellung der Karten
                                                   //ermöglichen, bevor sie wieder umgedreht werde.
                previous.Visible = false;
                aktuell.Visible = false;
                if (--verbleibenden_Karten == 0)
                {
                    Karten_zeit.Enabled = false;
                    label_verbleibende_Karten.Text = "Glückwunsch.";
                    MessageBox.Show("Glückwunsch. Du hast das Spiel beendet.", "Ende des Spiels");
                    btZeigen.Enabled = false;
                }
                else label_verbleibende_Karten.Text = "verbleibende Karten: " + verbleibenden_Karten;
            }
            else
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                previous.Image = Properties.Resources.frage;
                aktuell.Image = Properties.Resources.frage;
            }
        }

        void Alles_sichtbar_True()
        {
            foreach (Control x in this.Controls) if (x is PictureBox) (x as PictureBox).Visible = true;
        }
        void Alles_aktivieren()
        {
            foreach (Control x in this.Controls) if (x is PictureBox) (x as PictureBox).Enabled = true;
        }
        void Alles_deaktivieren()
        {
            foreach (Control x in this.Controls) if (x is PictureBox) (x as PictureBox).Enabled = false;
        }

        void Neues_Spiel()
        {
            versuche = 0;
            verbleibenden_Karten = 8;
            zeigen = 3;
            Tag_zufällig_festlegen();
            Alles_sichtbar_True();
            Bilder_zurücksetzen();
            btZeigen.Enabled = true;
            label_verbleibende_Karten.Text = "Verbleibende Karten: " + verbleibenden_Karten;
            btZeigen.Text = "Zeigen (" + zeigen + ")";
            zustand = 0;
            übrige_Zeit = 200;
            label_verbleibende_Zeit.Text = "Verbleibende Zeit: " + übrige_Zeit;
            Alles_aktivieren(); 
        }

        private void Karten_Box_Click(object sender, EventArgs e)
        {
            if (spielGestartet) // Prüfen, ob das Spiel gestartet wurde
            {
                PictureBox aktuell = (sender as PictureBox);
                Bild_anzeigen((sender as PictureBox));
                if (zustand == 0)
                {
                    Pbox = aktuell;
                    zustand = 1;
                }
                else if (Pbox != aktuell)
                {
                    Vergleichen(Pbox, aktuell);
                    zustand = 0;
                    versuche++; // Versuche erhöhen
                    label_Versuche.Text = "Versuche: " + versuche;
                }
            }
        }

        private void btZeigen_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls) if (x is PictureBox) Bild_anzeigen((x as PictureBox));
            Application.DoEvents();
            System.Threading.Thread.Sleep(1500);
            Bilder_zurücksetzen();
            if (--zeigen == 0) btZeigen.Enabled = false;

            btZeigen.Text = "Zeigen (" + zeigen + ")";
        }

        private void Karten_zeit_Tick(object sender, EventArgs e)
        {

            if (--übrige_Zeit == 0) // reduzierung der Wert der Variablen um 1.
            {
                Karten_zeit.Enabled = !Karten_zeit.Enabled;
                label_verbleibende_Zeit.Text = "Die Zeit ist abgelaufen.";
                MessageBox.Show("DIE ZEIT IST UM \nVersuche es noch einmal :)", "Ende des Spiels");
                Alles_deaktivieren();
                btZeigen.Enabled = false;

            }
            else
                label_verbleibende_Zeit.Text = "verbleibende Zeit: " + übrige_Zeit;
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (!spielGestartet)
            {
                // Starte das Spiel
                Neues_Spiel();

                // Aktiviere die Timer und setze den Spielstatus auf gestartet
                Karten_zeit.Enabled = true;
                spielGestartet = true;
            }
            else
            {
                Neues_Spiel();

                // Aktiviere die Timer und setze den Spielstatus auf gestartet
                Karten_zeit.Enabled = true;
                spielGestartet = true;

            }
        }

        private void Exit_Button_Karten_Click(object sender, EventArgs e)
        {
            this.Close();
            Spiel_Menü form2 = new Spiel_Menü();
            form2.Show();
        }
    }
}