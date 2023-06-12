// Importieren der benötigten Namespaces
using System;
using System.Media;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace Memory_game
{
    // Die Klasse "Spiel_Menü" erbt von der Klasse "Form"
    public partial class Spiel_Menü : Form
    {
        private SoundPlayer player;  // SoundPlayer-Objekt zum Abspielen von Tönen
        private MMDeviceEnumerator enumerator;  // MMDeviceEnumerator-Objekt zum Zugriff auf Audiogeräte
        private MMDevice device;  // MMDevice-Objekt für das Standard-Audiogerät

        // Konstruktor der Klasse "Spiel_Menü"
        public Spiel_Menü()
        {
            InitializeComponent();

            // Initialisierung der verschiedenen Panels
            pnlHighscore.Visible = false;
            pnlInfo.Visible = false;
            pnlSpielen.Visible = false;
            pnlEinstellung.Visible = false;

            // Initialisierung des SoundPlayers und des Audiogeräts
            player = new SoundPlayer("Hintergrund-Sound.wav");
            enumerator = new MMDeviceEnumerator();
            device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            // Setzen des Anmeldenamens im Label "_lbl_Anmelde_Name"
            _lbl_Anmelde_Name.Text = Anmeldung.DM.ds.Tables["User"].Rows[0][0].ToString();
        }

        // Event-Handler für den Button "Button_Exit_Spiel"
        private void Button_Exit_Spiel_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Beenden der Anwendung
        }

        // Event-Handler für den Button "Button_Exit_Spiel_Highscore"
        private void Button_Exit_Spiel_Highscore_Click(object sender, EventArgs e)
        {
            this.Close();  // Schließen des aktuellen Formulars
            Spiel_Menü form2 = new Spiel_Menü();  // Erstellen einer neuen Instanz von "Spiel_Menü"
            form2.Show();  // Anzeigen des neuen Formulars
        }

        // Event-Handler für den Button "Button_Exit_Spiel_Fenster"
        private void Button_Exit_Spiel_Fenster_Click(object sender, EventArgs e)
        {
            this.Close();  // Schließen des aktuellen Formulars
            Spiel_Menü form2 = new Spiel_Menü();  // Erstellen einer neuen Instanz von "Spiel_Menü"
            form2.Show();  // Anzeigen des neuen Formulars
        }

        // Event-Handler für den Button "button14"
        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();  // Schließen des aktuellen Formulars
            Spiel_Menü form2 = new Spiel_Menü();  // Erstellen einer neuen Instanz von "Spiel_Menü"
            form2.Show();  // Anzeigen des neuen Formulars
        }

        // Event-Handler für den Button "Button_Exit_Spiel_Info"
        private void Button_Exit_Spiel_Info_Click(object sender, EventArgs e)
        {
            this.Close();  // Schließen des aktuellen Formulars
            Spiel_Menü form2 = new Spiel_Menü();  // Erstellen einer neuen Instanz von "Spiel_Menü"
            form2.Show();  // Anzeigen des neuen Formulars
        }

        // Event-Handler für den Button "Button_Einstellung_Spiel"
        private void Button_Einstellung_Spiel_Click(object sender, EventArgs e)
        {
            // Anpassen der Sichtbarkeiten der Panels
            pnlEinstellung.Visible = true;
            pnlEinstellung.Dock = DockStyle.Fill;
            pnlHighscore.Visible = false;
            pnlInfo.Visible = false;
            pnlSpielen.Visible = false;
        }

        // Event-Handler für den Button "Button_Spielen_Spiel"
        private void Button_Spielen_Spiel_Click(object sender, EventArgs e)
        {
            // Anpassen der Sichtbarkeiten der Panels
            pnlSpielen.Visible = true;
            pnlSpielen.Dock = DockStyle.Fill;
            pnlHighscore.Visible = false;
            pnlInfo.Visible = false;
            pnlEinstellung.Visible = false;
        }

        // Event-Handler für den Button "Button_Highscore_Spiel"
        private void Button_Highscore_Spiel_Click(object sender, EventArgs e)
        {
            // Anpassen der Sichtbarkeiten der Panels
            pnlHighscore.Visible = true;
            pnlHighscore.Dock = DockStyle.Fill;
            pnlInfo.Visible = false;
            pnlSpielen.Visible = false;
            pnlEinstellung.Visible = false;
        }

        // Event-Handler für den Button "Button_Info_Spiel"
        private void Button_Info_Spiel_Click(object sender, EventArgs e)
        {
            // Anpassen der Sichtbarkeiten der Panels
            pnlInfo.Visible = true;
            pnlInfo.Dock = DockStyle.Fill;
            pnlHighscore.Visible = false;
            pnlEinstellung.Visible = false;
            pnlSpielen.Visible = false;
        }

        // Event-Handler für den Button "Button_AB_Spiel_Einstellung"
        private void Button_AB_Spiel_Einstellung_Click(object sender, EventArgs e)
        {
            player.Stop();  // Stoppen der Wiedergabe von Hintergrundmusik
            this.Close();  // Schließen des aktuellen Formulars
            Anmeldung form1 = new Anmeldung();  // Erstellen einer neuen Instanz von "Anmeldung"
            form1.Show();  // Anzeigen des neuen Formulars
        }

        // Event-Handler für den Button "Button_Sound_Max"
        private void Button_Sound_Max_Click(object sender, EventArgs e)
        {
            SetVolume(1.0f);  // Setzen der Lautstärke auf den maximalen Wert
        }

        // Event-Handler für den Button "Button_Sound_Mittel"
        private void Button_Sound_Mittel_Click(object sender, EventArgs e)
        {
            SetVolume(0.3f);  // Setzen der Lautstärke auf einen mittleren Wert
        }

        // Event-Handler für den Button "Button_Sound_Null"
        private void Button_Sound_Null_Click(object sender, EventArgs e)
        {
            SetVolume(0.0f);  // Setzen der Lautstärke auf 0 (stumm)
        }

        // Methode zum Setzen der Lautstärke
        private void SetVolume(float volume)
        {
            device.AudioEndpointVolume.MasterVolumeLevelScalar = volume;  // Festlegen der Lautstärke des Audiogeräts
        }

        // Event-Handler für das Klicken des "Karten_Spiel_Logo"
        private void Karten_Spiel_Logo_Click(object sender, EventArgs e)
        {
            Kartenpaare_suchen form3 = new Kartenpaare_suchen();  // Erstellen einer neuen Instanz von "Kartenpaare_suchen"
            form3.Show();  // Anzeigen des neuen Formulars
            pnlSpielen.Visible = false;
            this.Close();  // Schließen des aktuellen Formulars
        }

        // Event-Handler für das Klicken des "Puzzle_Spiel_Logo"
        private void Puzzle_Spiel_Logo_Click(object sender, EventArgs e)
        {
            Puzzle form4 = new Puzzle();  // Erstellen einer neuen Instanz von "Puzzle"
            form4.Show();  // Anzeigen des neuen Formulars
            pnlSpielen.Visible = false;
            this.Close();  // Schließen des aktuellen Formulars
        }

        // Event-Handler für den Timer "Zeit_Spiel"
        private void Zeit_Spiel_Tick(object sender, EventArgs e)
        {
            label_Zeit_Spiel.Text = DateTime.Now.ToString("hh:mm:ss");  // Aktualisieren der Uhrzeitanzeige
        }

        // Event-Handler für das Laden des Formulars "Spiel_Menü"
        private void Spiel_Menü_Load(object sender, EventArgs e)
        {
            Zeit_Spiel.Start();  // Starten des Timers "Zeit_Spiel"
        }

        // Event-Handler für das Klicken des "pictureBox1"
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Wort_Raten wort_Raten = new Wort_Raten();  // Erstellen einer neuen Instanz von "Wort_Raten"
            wort_Raten.Show();  // Anzeigen des neuen Formulars
            pnlSpielen.Visible = false;
            this.Close();  // Schließen des aktuellen Formulars
        }

        // Event-Handler für den Button "Bt_Exit_Info"
        private void Bt_Exit_Info_Click(object sender, EventArgs e)
        {
            this.Close();  // Schließen des aktuellen Formulars
            Spiel_Menü form2 = new Spiel_Menü();  // Erstellen einer neuen Instanz von "Spiel_Menü"
            form2.Show();  // Anzeigen des neuen Formulars
        }
    }
}
