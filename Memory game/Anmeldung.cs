using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Memory_game
{
    public partial class Anmeldung : Form
    {
        public SoundPlayer player; // SoundPlayer-Objekt zum Abspielen von Sounddateien
        public Anmeldung()
        {
            InitializeComponent();
            player = new SoundPlayer("Hintergrund-Sound.wav"); // Initialisierung des SoundPlayer-Objekts mit der Sounddatei "Hintergrund-Sound.wav"
            ConnectToDatabank(); // Verbindung zur Datenbank herstellen
        }

        public static Datamodule DM; // Statische Instanz der Datamodule-Klasse

        private void ConnectToDatabank() // Methode zur Verbindungsherstellung mit der Datenbank
        {
            try
            {
                // Erstellung einer Instanz der Datamodule-Klasse mit den Verbindungsinformationen zur Datenbank
                DM = new Datamodule("SYSDBA", "masterkey",
                               @"C:\Users\anwar\Documents\Github\MEMORY_GAME-DB.FDB",
                               "localhost", 3050);
            }
            catch (Exception ex)
            {
                // Fehlermeldung anzeigen, falls die Verbindung zur Datenbank fehlschlägt
                MessageBox.Show("Datenbank kann nicht geöffnet werden!!. Versuchen Sie es " +
                "nochmal oder kontaktieren Sie uns über den verlinkten WhatsApp-Link " + ex.Message);
            }
        }

        private void Tb_Ben_An_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Tb_Ben_An.Text == "")
                {
                    Tb_Ben_An.Text = "Geben Sie den Benutzernamen ein";
                    return;
                }

                Tb_Ben_An.ForeColor = Color.White;
                panel_Meldung_An.Visible = false;

            }
            catch { }
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {
            Tb_Ben_An.SelectAll();
        }

        private void Tb_Paswort_A_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (Tb_Paswort_A.Text == "")
                {
                    return;
                }

                Tb_Paswort_A.ForeColor = Color.White;
                Tb_Paswort_A.PasswordChar = '*';
                panel_Meldung_An2.Visible = false;
            }
            catch { }

        }

        private void TextBox2_Click(object sender, EventArgs e)
        {
            Tb_Paswort_A.SelectAll();
        }

        private void Button_Anmelden_An_Click(object sender, EventArgs e)
        {
            // Überprüfen, ob der Benutzername nicht leer ist
            if (Tb_Ben_An.Text == "Geben Sie den Benutzernamen ein" || string.IsNullOrEmpty(Tb_Ben_An.Text))
            {
                panel_Meldung_An.Visible = true;
                Tb_Ben_An.Focus();
                return;
            }

            // Überprüfen, ob das Passwort nicht leer ist
            if (Tb_Paswort_A.Text == "Geben Sie den Passwort ein" || string.IsNullOrEmpty(Tb_Paswort_A.Text))
            {
                panel_Meldung_An2.Visible = true;
                Tb_Paswort_A.Focus();
                return;
            }

            string benutzername = Tb_Ben_An.Text;
            string passwort = Tb_Paswort_A.Text;

            // SQL-Befehl zum Überprüfen des Benutzernamens und Passworts in der Datenbank
            string sqlCommand = "SELECT a.ANMELDENAME, a.PASSWORT FROM T_USER a WHERE a.ANMELDENAME = '" + benutzername + "' AND  a.PASSWORT = '" + passwort + "'";

            // Daten aus der Datenbank laden und in eine Tabelle (DataTable) mit dem Namen "User" speichern
            DM.LoadData2Table(sqlCommand, "User");

            // Überprüfen, ob Datensätze in der Tabelle vorhanden sind
            if (DM.ds.Tables.Count > 0 && DM.ds.Tables[0].Rows.Count > 0)
            {
                // Überprüfen, ob der Benutzername und das Passwort übereinstimmen
                if (DM.ds.Tables[0].Rows[0][0].ToString() == benutzername && DM.ds.Tables[0].Rows[0][1].ToString() == passwort)
                {
                    // Wenn Benutzername und Passwort übereinstimmen, das Spiel-Menü anzeigen und das Anmeldeformular ausblenden
                    Spiel_Menü form2 = new Spiel_Menü();
                    form2.Show();
                    this.Hide();
                }

                player.PlayLooping(); // Sound in einer Endlosschleife abspielen
            }
            else
            {
                // Fehlermeldung anzeigen, wenn das Konto nicht existiert oder das Passwort falsch ist
                MessageBox.Show("Das Konto existiert nicht oder das Passwort ist falsch. " +
                    "Bitte erstellen Sie zunächst ein Konto oder korrigieren Sie die Daten" +
                    " und versuchen Sie es erneut.", "Fehlermeldung!!");
            }

            player.PlayLooping(); // Sound in einer Endlosschleife abspielen
        }


        private void whatsapp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Öffnen des WhatsApp-Links in einem Standardbrowser
            Process.Start("https://wa.me/qr/QSYEBURJ54PVM1 ");
        }

        private void Insta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Öffnen des Instagram-Links in einem Standardbrowser
            Process.Start("https://www.instagram.com/s_a_n_w_a_r_h/");
        }

        private void Zeit_Tick_An(object sender, EventArgs e)
        {
            label_Zeit_An.Text = DateTime.Now.ToString("hh:mm:ss"); // Aktualisieren der Anzeige der aktuellen Uhrzeit
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Zeit_An.Start(); // Starten des Timers zur Aktualisierung der Uhrzeit
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Beenden der Anwendung
        }

        private void button_Account_erstellen_Click(object sender, EventArgs e)
        {
            if (textBox_Benutzer_Acc.Text == "Geben Sie den Benutzernamen ein")
            {
                pnlNameER.Visible = true;
                textBox_Benutzer_Acc.Focus();
                return;
            }
            if (Passwort_Acc.Text == "Geben Sie den Passwort ein")
            {
                pnlPassER.Visible = true;
                Passwort_Acc.Focus();
                return;
            }
            if (textBox_Passwort2_Acc.Text == "Geben Sie den Passwort ein")
            {
                pnlPass2ER.Visible = true;
                textBox_Passwort2_Acc.Focus();
                return;
            }

            // Eingaben in Variablen speichern
            string benutzername = textBox_Benutzer_Acc.Text;
            string password = Passwort_Acc.Text;
            string password2 = textBox_Passwort2_Acc.Text;
            string SqlCommand = "";

            // Überprüfen, ob das Passwort und das bestätigte Passwort übereinstimmen
            if (password == password2)
            {
                // SQL-Befehl zum Einfügen des Benutzernamens und Passworts in die Datenbank
                SqlCommand = "INSERT INTO T_USER (ANMELDENAME, PASSWORT)VALUES('" + benutzername + "','" + password + "'); ";
                DM.ExecuteSimpleDML(SqlCommand);

                pnlAnmelden.Visible = true;
                pnlAnmelden.Dock = DockStyle.Fill;
                pnlLogo.Dock = DockStyle.Left;
                pnlAccount.Visible = false;
            }
            else
            {
                textBox_Passwort2_Acc.Text = "Das Passwort ist nicht identisch";
            }
        }

        private void TextBox8_Click(object sender, EventArgs e)
        {
            textBox_Benutzer_Acc.SelectAll();
        }

        private void TextBox7_Click(object sender, EventArgs e)
        {
            Passwort_Acc.SelectAll();
        }

        private void TextBox10_Click(object sender, EventArgs e)
        {
            textBox_Passwort2_Acc.SelectAll();
        }

        private void LinkLb_Anmelden_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlAnmelden.Visible = true;
            pnlAnmelden.Dock = DockStyle.Fill;
            pnlLogo.Dock = DockStyle.Left;
            pnlAccount.Visible = false;
        }

        private void Account_erstellen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlAccount.Visible = true;
            pnlAccount.Dock = DockStyle.Fill;
            pnlAnmelden.Visible = false;
        }
    }
}