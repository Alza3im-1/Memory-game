using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Memory_game
{
    public partial class Wort_Raten : Form
    {

        List<string> Wörter = new List<string>();
        string newText;
        int i = 0;
        int vermutet = 0;

        public Wort_Raten()
        {
            InitializeComponent();
            WörterVoid();
        }

        private void KeyIsPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (Wörter[i].ToLower() == textBox1.Text.ToLower())
                {
                    if (i < Wörter.Count - 1)
                    {
                        MessageBox.Show("Richtig!", "HAst du gut Gemacht :} ");
                        textBox1.Text = "";
                        i += 1;
                        newText = Buchstaben_mischen(Wörter[i]);
                        lb_Text.Text = newText;
                        lb_W_Zahl.Text = "Wörter: " + (i + 1) + " von " + Wörter.Count;
                        vermutet = 0;
                        lb_Versuche.Text = "Vermutet: " + vermutet + " mal.";
                    }
                    else
                    {
                        lb_Text.Text = "Du hast gewonnen, gut gemacht :}";
                        return;
                    }
                }
                else
                {
                    vermutet += 1;
                    lb_Versuche.Text = "Vermutet: " + vermutet + " mal.";
                }
                e.Handled = true;
            }
        }

        private void WörterVoid()
        {
            Wörter.Add("Kaffeetasse");
            Wörter.Add("Buchstabe");
            Wörter.Add("Computer");
            Wörter.Add("Fahrrad");
            Wörter.Add("Tisch");
            Wörter.Add("Sonnenblume");
            Wörter.Add("Schokolade");
            Wörter.Add("Gitarre");
            Wörter.Add("Regenschirm");
            Wörter.Add("Himmel");
            Wörter.Add("Berg");
            Wörter.Add("Strand");
            Wörter.Add("Wasserfall");
            Wörter.Add("Kamera");
            Wörter.Add("Musik");
            Wörter.Add("Tiger");
            Wörter.Add("Elefant");
            Wörter.Add("Löwe");
            Wörter.Add("Vogel");
            Wörter.Add("Wolke");


            Random zufall = new Random();
            Wörter = Wörter.OrderBy(wort => zufall.Next()).ToList();

            newText = Buchstaben_mischen(Wörter[i]);
            lb_Text.Text = newText;
            lb_W_Zahl.Text = "Wörter: " + (i + 1) + " von " + Wörter.Count;
        }


        private string Buchstaben_mischen(string text)
        {
            return new string(text.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());
            //Array von Zeichen um. Jedes Zeichen im Text wird zu einem Element im Array.
            //OrderBy(x => Guid.NewGuid()) :  Anweisung sortiert in zufälliger Reihenfolge.Sie verwendet die Guid.NewGuid()-Methode,
            //ToArray(): wandelt das sortierte Zeichenarray wieder in ein Array um.
            //new string: Diese Anweisung erstellt einen neuen String aus dem sortierten Zeichenarray.
        }

        private void Button_Neu_Starten_Click(object sender, EventArgs e)
        {
            i = 0; // Setze den Zähler für das aktuelle Wort zurück
            vermutet = 0; // Setze den Zähler für die Vermutungen zurück

            // Mische die Wörter erneut in zufälliger Reihenfolge
            Random zufall = new Random();
            Wörter = Wörter.OrderBy(wort => zufall.Next()).ToList();

            // Bereite das erste Wort vor und zeige es an
            newText = Buchstaben_mischen(Wörter[i]);
            lb_Text.Text = newText;
            lb_W_Zahl.Text = "Wörter: " + (i + 1) + " von " + Wörter.Count;
            lb_Versuche.Text = "Vermutet: " + vermutet + " mal.";

            textBox1.Text = ""; // Leere das Textfeld für die Eingabe

            // Aktiviere den "Zeigen"-Button
            Zeigen_Bt.Enabled = true;
        }


        private async void Zeigen_Bt_Click(object sender, EventArgs e)
        {
            // Zeige das richtige Wort im Label an
            lb_Text.Text = Wörter[i];

            // Warte für 3 Sekunden
            await Task.Delay(500);

            // Mische das Wort erneut, um fortzufahren
            newText = Buchstaben_mischen(Wörter[i]);
            lb_Text.Text = newText;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
            Spiel_Menü form2 = new Spiel_Menü();
            form2.Show();
        }
    }

}