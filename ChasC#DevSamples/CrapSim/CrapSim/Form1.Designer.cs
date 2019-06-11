namespace CrapSim
{
    partial class Form1
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
            this.Button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Bet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TimeRolls = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Gain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.TextBox();
            this.Perc7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Double7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.StartingAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Rounds = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(121, 265);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "BeginSim";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bet";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Bet
            // 
            this.Bet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Bet.Location = new System.Drawing.Point(121, 55);
            this.Bet.Name = "Bet";
            this.Bet.Size = new System.Drawing.Size(62, 13);
            this.Bet.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "# Rounds";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Time between rolls (min)";
            // 
            // TimeRolls
            // 
            this.TimeRolls.BackColor = System.Drawing.SystemColors.Window;
            this.TimeRolls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TimeRolls.Location = new System.Drawing.Point(121, 110);
            this.TimeRolls.Name = "TimeRolls";
            this.TimeRolls.Size = new System.Drawing.Size(62, 13);
            this.TimeRolls.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total Time";
            // 
            // Gain
            // 
            this.Gain.BackColor = System.Drawing.SystemColors.Menu;
            this.Gain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Gain.Location = new System.Drawing.Point(121, 216);
            this.Gain.Name = "Gain";
            this.Gain.Size = new System.Drawing.Size(62, 13);
            this.Gain.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Profit/Loss";
            // 
            // Time
            // 
            this.Time.BackColor = System.Drawing.SystemColors.Menu;
            this.Time.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Time.Location = new System.Drawing.Point(121, 138);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(62, 13);
            this.Time.TabIndex = 11;
            // 
            // Perc7
            // 
            this.Perc7.BackColor = System.Drawing.SystemColors.Menu;
            this.Perc7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Perc7.Location = new System.Drawing.Point(121, 161);
            this.Perc7.Name = "Perc7";
            this.Perc7.Size = new System.Drawing.Size(62, 13);
            this.Perc7.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "% 7s";
            // 
            // Double7
            // 
            this.Double7.BackColor = System.Drawing.SystemColors.Menu;
            this.Double7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Double7.Location = new System.Drawing.Point(121, 190);
            this.Double7.Name = "Double7";
            this.Double7.Size = new System.Drawing.Size(62, 13);
            this.Double7.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "%double 7 (16.67% is bar)";
            // 
            // StartingAmount
            // 
            this.StartingAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StartingAmount.Location = new System.Drawing.Point(121, 29);
            this.StartingAmount.Name = "StartingAmount";
            this.StartingAmount.Size = new System.Drawing.Size(62, 13);
            this.StartingAmount.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Starting amount";
            // 
            // Rounds
            // 
            this.Rounds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Rounds.Location = new System.Drawing.Point(121, 81);
            this.Rounds.Name = "Rounds";
            this.Rounds.Size = new System.Drawing.Size(62, 13);
            this.Rounds.TabIndex = 3;
            this.Rounds.TextChanged += new System.EventHandler(this.Rounds_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 366);
            this.Controls.Add(this.StartingAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Double7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Perc7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Gain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TimeRolls);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Rounds);
            this.Controls.Add(this.Bet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button1);
            this.Name = "Form1";
            this.Text = "CrapSim";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Bet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TimeRolls;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Gain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Time;
        private System.Windows.Forms.TextBox Perc7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Double7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox StartingAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Rounds;
    }
}

