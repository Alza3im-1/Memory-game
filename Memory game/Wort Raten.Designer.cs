namespace Memory_game
{
    partial class Wort_Raten
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wort_Raten));
            this.lb_Wort_Raten = new System.Windows.Forms.Label();
            this.lb_Text = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lb_W_Zahl = new System.Windows.Forms.Label();
            this.lb_Versuche = new System.Windows.Forms.Label();
            this.Button_Neu_Starten = new System.Windows.Forms.Button();
            this.Zeigen_Bt = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_Wort_Raten
            // 
            this.lb_Wort_Raten.AutoSize = true;
            this.lb_Wort_Raten.BackColor = System.Drawing.Color.Gray;
            this.lb_Wort_Raten.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Wort_Raten.ForeColor = System.Drawing.Color.White;
            this.lb_Wort_Raten.Location = new System.Drawing.Point(355, 43);
            this.lb_Wort_Raten.Name = "lb_Wort_Raten";
            this.lb_Wort_Raten.Size = new System.Drawing.Size(441, 73);
            this.lb_Wort_Raten.TabIndex = 3;
            this.lb_Wort_Raten.Text = "Rate das Wort";
            // 
            // lb_Text
            // 
            this.lb_Text.AutoSize = true;
            this.lb_Text.BackColor = System.Drawing.Color.Gray;
            this.lb_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Text.ForeColor = System.Drawing.Color.White;
            this.lb_Text.Location = new System.Drawing.Point(84, 364);
            this.lb_Text.Name = "lb_Text";
            this.lb_Text.Size = new System.Drawing.Size(256, 73);
            this.lb_Text.TabIndex = 4;
            this.lb_Text.Text = "xxxxxxx";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(67, 480);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(445, 80);
            this.textBox1.TabIndex = 5;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyIsPressed);
            // 
            // lb_W_Zahl
            // 
            this.lb_W_Zahl.AutoSize = true;
            this.lb_W_Zahl.BackColor = System.Drawing.Color.Gray;
            this.lb_W_Zahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_W_Zahl.ForeColor = System.Drawing.Color.White;
            this.lb_W_Zahl.Location = new System.Drawing.Point(334, 702);
            this.lb_W_Zahl.Name = "lb_W_Zahl";
            this.lb_W_Zahl.Size = new System.Drawing.Size(462, 73);
            this.lb_W_Zahl.TabIndex = 6;
            this.lb_W_Zahl.Text = "Words: 0 von 0";
            // 
            // lb_Versuche
            // 
            this.lb_Versuche.AutoSize = true;
            this.lb_Versuche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lb_Versuche.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Versuche.ForeColor = System.Drawing.Color.White;
            this.lb_Versuche.Location = new System.Drawing.Point(797, 167);
            this.lb_Versuche.Name = "lb_Versuche";
            this.lb_Versuche.Size = new System.Drawing.Size(296, 39);
            this.lb_Versuche.TabIndex = 7;
            this.lb_Versuche.Text = "Versuche: 0 times";
            // 
            // Button_Neu_Starten
            // 
            this.Button_Neu_Starten.BackColor = System.Drawing.Color.White;
            this.Button_Neu_Starten.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Button_Neu_Starten.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Neu_Starten.Location = new System.Drawing.Point(831, 253);
            this.Button_Neu_Starten.Name = "Button_Neu_Starten";
            this.Button_Neu_Starten.Size = new System.Drawing.Size(262, 155);
            this.Button_Neu_Starten.TabIndex = 53;
            this.Button_Neu_Starten.Text = "Neu Starten";
            this.Button_Neu_Starten.UseVisualStyleBackColor = false;
            this.Button_Neu_Starten.Click += new System.EventHandler(this.Button_Neu_Starten_Click);
            // 
            // Zeigen_Bt
            // 
            this.Zeigen_Bt.BackColor = System.Drawing.Color.White;
            this.Zeigen_Bt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Zeigen_Bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zeigen_Bt.Location = new System.Drawing.Point(831, 452);
            this.Zeigen_Bt.Name = "Zeigen_Bt";
            this.Zeigen_Bt.Size = new System.Drawing.Size(262, 155);
            this.Zeigen_Bt.TabIndex = 54;
            this.Zeigen_Bt.Text = "Zeigen";
            this.Zeigen_Bt.UseVisualStyleBackColor = false;
            this.Zeigen_Bt.Click += new System.EventHandler(this.Zeigen_Bt_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Transparent;
            this.button13.BackgroundImage = global::Memory_game.Properties.Resources.stornieren;
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Location = new System.Drawing.Point(1057, 12);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(78, 70);
            this.button13.TabIndex = 55;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // Wort_Raten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Memory_game.Properties.Resources.Logisches_Denken;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1147, 814);
            this.ControlBox = false;
            this.Controls.Add(this.button13);
            this.Controls.Add(this.Zeigen_Bt);
            this.Controls.Add(this.Button_Neu_Starten);
            this.Controls.Add(this.lb_Versuche);
            this.Controls.Add(this.lb_W_Zahl);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lb_Text);
            this.Controls.Add(this.lb_Wort_Raten);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Wort_Raten";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Wort_Raten;
        private System.Windows.Forms.Label lb_Text;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lb_W_Zahl;
        private System.Windows.Forms.Label lb_Versuche;
        private System.Windows.Forms.Button Button_Neu_Starten;
        private System.Windows.Forms.Button Zeigen_Bt;
        private System.Windows.Forms.Button button13;
    }
}