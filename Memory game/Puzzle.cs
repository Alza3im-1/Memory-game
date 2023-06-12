using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Memory_game
{
    public partial class Puzzle : Form
    {
        // Initialisierung der Variablen
        int Verbleibende_Zeit = 300; // Verbleibende Zeit in Sekunden
        private bool spielGestartet = false; // Gibt an, ob das Spiel gestartet wurde
        private int Index_leeren_Bildbox, versuche = 0; // Index der leeren Bildbox und Anzahl der Versuche
        private List<Bitmap> Bilder_list = new List<Bitmap>(); // Eine Liste von Bildern für das Memory-Spiel
        private Stopwatch Zeit = new Stopwatch(); // Ein Timer, um die Spielzeit zu messen
        private bool pauseAktiviert = false; // Gibt an, ob das Spiel pausiert ist

        public Puzzle()
        {
            InitializeComponent();

            // Hinzufügen der Bilder zur Bilderliste
            Bilder_list.AddRange(new Bitmap[]
            {
                Properties.Resources._21,
                Properties.Resources._22,
                Properties.Resources._23,
                Properties.Resources._24,
                Properties.Resources._25,
                Properties.Resources._26,
                Properties.Resources._27,
                Properties.Resources._28,
                Properties.Resources._29,
                Properties.Resources.Weiß
            });
        }

        private void Puzzle_Load(object sender, EventArgs e)
        {
            Mischen(); // Beim Laden des Spiels werden die Bilder gemischt
        }

        private void Mischen()
        {
            // Mischen der Bilder
            do
            {
                int j;
                List<int> Indexes = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 9 }); // Die Indexe der Bilder
                Random r = new Random();

                for (int i = 0; i < 9; i++)
                {
                    Indexes.Remove((j = Indexes[r.Next(0, Indexes.Count)])); // Zufällige Auswahl eines Indexes
                    ((PictureBox)gbPuzzleBox.Controls[i]).Image = Bilder_list[j]; // Das Bild des entsprechenden Indexes wird in die Bildbox eingefügt

                    if (j == 9)
                        Index_leeren_Bildbox = i; // Speichern des Indexes der leeren Bildbox
                }
            } while (Gewinn_Prüfen()); // Solange die Startanordnung ein Gewinnzustand ist, wird erneut gemischt
        }

        private void pbx1_Click(object sender, EventArgs e)
        {
            if (!spielGestartet)
            {
                Puzzle_Verbliebende_Zeit.Start(); // Starten der Verbleibenden-Zeit-Uhr, wenn das erste Bild angeklickt wird
                spielGestartet = true;
            }

            if (!pauseAktiviert)
            {
                int inPictureBoxIndex = gbPuzzleBox.Controls.IndexOf(sender as Control); // Index der angeklickten Bildbox ermitteln

                if (Index_leeren_Bildbox != inPictureBoxIndex)
                {
                    List<int> FourBrothers = new List<int>(new int[]
                    {
                        ((inPictureBoxIndex % 3 == 0) ? -1 : inPictureBoxIndex - 1),
                        inPictureBoxIndex - 3,
                        (inPictureBoxIndex % 3 == 2) ? -1 : inPictureBoxIndex + 1,
                        inPictureBoxIndex + 3
                    }); // Indexe der benachbarten Bildboxen

                    if (FourBrothers.Contains(Index_leeren_Bildbox))
                    {
                        PictureBox emptyPictureBox = (PictureBox)gbPuzzleBox.Controls[Index_leeren_Bildbox]; // Leere Bildbox
                        PictureBox clickedPictureBox = (PictureBox)gbPuzzleBox.Controls[inPictureBoxIndex]; // Angeklickte Bildbox

                        emptyPictureBox.Image = clickedPictureBox.Image; // Das Bild der angeklickten Bildbox wird in die leere Bildbox verschoben
                        clickedPictureBox.Image = Bilder_list[9]; // Die angeklickte Bildbox wird leer

                        Index_leeren_Bildbox = inPictureBoxIndex; // Der Index der leeren Bildbox wird aktualisiert

                        lb_gemachte_bew.Text = "Bewegungen gemacht: " + (++versuche); // Die Anzahl der Versuche wird erhöht

                        if (Gewinn_Prüfen()) // Überprüfen, ob das Spiel gewonnen wurde
                        {
                            Puzzle_Verbliebende_Zeit.Stop(); // Die Verbleibende-Zeit-Uhr wird gestoppt
                            (gbPuzzleBox.Controls[8] as PictureBox).Image = Bilder_list[8]; // Das letzte Bild wird an die richtige Stelle gesetzt

                            MessageBox.Show("Glückwunsch... : " + Zeit.Elapsed.ToString().Remove(8) +
                                "\nInsgesamt durchgeführte Bewegungen : " + versuche, "Puzzle"); // Eine Erfolgsmeldung wird angezeigt

                            versuche = 0; // Die Anzahl der Versuche wird zurückgesetzt
                            lb_gemachte_bew.Text = "Bewegungen gemacht : 0";
                            label_verbleibende_Zeit_Puzzle.Text = "verbleibende Zeit: ";
                            Zeit.Reset(); // Der Timer wird zurückgesetzt
                            lb_gemachte_bew.ResetText();
                            Mischen(); // Die Bilder werden erneut gemischt
                        }
                    }
                }
            }
        }

        private bool Gewinn_Prüfen()
        {
            // Überprüfen, ob das Spiel gewonnen wurde, indem die Bilder mit den richtigen Bildern verglichen werden
            for (int i = 0; i < 8; i++)
            {
                if ((gbPuzzleBox.Controls[i] as PictureBox).Image != Bilder_list[i])
                    return false;
            }

            return true;
        }

        private void Button_Neu_Starten_Click(object sender, EventArgs e)
        {
            DialogResult JaoderNein = new DialogResult();

            if (label_verbleibende_Zeit_Puzzle.Text != "verbleibende Zeit: ")
            {
                JaoderNein = MessageBox.Show("Sind Sie sicher, dass Sie das Spiel NEU STARTEN wollen?", "Puzzle Spiel",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question); // Eine Bestätigungsdialog wird angezeigt
            }

            if (JaoderNein == DialogResult.Yes || label_verbleibende_Zeit_Puzzle.Text == "verbleibende Zeit: ")
            {
                Mischen(); // Die Bilder werden erneut gemischt
                Zeit.Reset(); // Der Timer wird zurückgesetzt
                label_verbleibende_Zeit_Puzzle.Text = "verbleibende Zeit:";
                lb_gemachte_bew.Text = "Bewegungen gemacht: 0";
                pauseAktiviert = false;
                btnPause.Text = "Pause";
                spielGestartet = false;
                versuche = 0;
            }
        }

        private void Puzzle_Verbliebende_Zeit_Tick(object sender, EventArgs e)
        {
            if (--Verbleibende_Zeit == 0) // Reduzierung der verbleibenden Zeit um 1
            {
                Puzzle_Verbliebende_Zeit.Enabled = !Puzzle_Verbliebende_Zeit.Enabled; // Die Verbleibende-Zeit-Uhr wird gestoppt
                label_verbleibende_Zeit_Puzzle.Text = "Die Zeit ist abgelaufen.";
                MessageBox.Show("DIE ZEIT IST UM \nVersuchen Sie es noch einmal :)", "Ende des Spiels"); // Eine Meldung wird angezeigt
            }
            else
                label_verbleibende_Zeit_Puzzle.Text = "verbleibende Zeit: " + Verbleibende_Zeit; // Aktualisierung der verbleibenden Zeit
        }

        private void Button_Exit_Puzzle_Click(object sender, EventArgs e)
        {
            this.Close();
            Spiel_Menü form2 = new Spiel_Menü();
            form2.Show();
        }

        private void Anhalten_oder_fortsetzen(object sender, EventArgs e)
        {
            if (!spielGestartet)
                return;

            pauseAktiviert = !pauseAktiviert; // Wechseln zwischen Pause und Fortsetzen

            if (pauseAktiviert)
            {
                Puzzle_Verbliebende_Zeit.Stop(); // Die Verbleibende-Zeit-Uhr wird gestoppt
                btnPause.Text = "Fortsetzen";
            }
            else
            {
                Puzzle_Verbliebende_Zeit.Start(); // Die Verbleibende-Zeit-Uhr wird fortgesetzt
                btnPause.Text = "Pause";
            }
        }
    }
}
