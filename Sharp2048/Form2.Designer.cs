namespace Sharp2048
{
    partial class Form2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblScoreBack = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblNewGame = new System.Windows.Forms.Label();
            this.lblScoreText = new System.Windows.Forms.Label();
            this.lblScoreBestText = new System.Windows.Forms.Label();
            this.lblScoreBest = new System.Windows.Forms.Label();
            this.lblScoreBestBack = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAbout = new System.Windows.Forms.Label();
            this.panelAbout = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkGabriel = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkCode = new System.Windows.Forms.LinkLabel();
            this.lblAboutOK = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkOnline = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(239)))));
            this.pictureBox1.Location = new System.Drawing.Point(13, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(555, 551);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblScoreBack
            // 
            this.lblScoreBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.lblScoreBack.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreBack.Location = new System.Drawing.Point(585, 120);
            this.lblScoreBack.Name = "lblScoreBack";
            this.lblScoreBack.Size = new System.Drawing.Size(126, 90);
            this.lblScoreBack.TabIndex = 4;
            this.lblScoreBack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(616, 160);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(67, 35);
            this.lblScore.TabIndex = 5;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNewGame
            // 
            this.lblNewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(122)))), ((int)(((byte)(102)))));
            this.lblNewGame.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewGame.ForeColor = System.Drawing.Color.White;
            this.lblNewGame.Location = new System.Drawing.Point(585, 220);
            this.lblNewGame.Name = "lblNewGame";
            this.lblNewGame.Size = new System.Drawing.Size(153, 49);
            this.lblNewGame.TabIndex = 8;
            this.lblNewGame.Text = "New Game";
            this.lblNewGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScoreText
            // 
            this.lblScoreText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.lblScoreText.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(217)))));
            this.lblScoreText.Location = new System.Drawing.Point(585, 126);
            this.lblScoreText.Name = "lblScoreText";
            this.lblScoreText.Size = new System.Drawing.Size(126, 31);
            this.lblScoreText.TabIndex = 10;
            this.lblScoreText.Text = "SCORE";
            this.lblScoreText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScoreBestText
            // 
            this.lblScoreBestText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.lblScoreBestText.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreBestText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(217)))));
            this.lblScoreBestText.Location = new System.Drawing.Point(717, 126);
            this.lblScoreBestText.Name = "lblScoreBestText";
            this.lblScoreBestText.Size = new System.Drawing.Size(126, 31);
            this.lblScoreBestText.TabIndex = 13;
            this.lblScoreBestText.Text = "BEST";
            this.lblScoreBestText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScoreBest
            // 
            this.lblScoreBest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.lblScoreBest.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreBest.ForeColor = System.Drawing.Color.White;
            this.lblScoreBest.Location = new System.Drawing.Point(748, 160);
            this.lblScoreBest.Name = "lblScoreBest";
            this.lblScoreBest.Size = new System.Drawing.Size(67, 35);
            this.lblScoreBest.TabIndex = 12;
            this.lblScoreBest.Text = "0";
            this.lblScoreBest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScoreBestBack
            // 
            this.lblScoreBestBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.lblScoreBestBack.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreBestBack.Location = new System.Drawing.Point(717, 120);
            this.lblScoreBestBack.Name = "lblScoreBestBack";
            this.lblScoreBestBack.Size = new System.Drawing.Size(126, 90);
            this.lblScoreBestBack.TabIndex = 11;
            this.lblScoreBestBack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(110)))), ((int)(((byte)(101)))));
            this.label1.Location = new System.Drawing.Point(579, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 93);
            this.label1.TabIndex = 14;
            this.label1.Text = "2048";
            // 
            // lblAbout
            // 
            this.lblAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(122)))), ((int)(((byte)(102)))));
            this.lblAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.ForeColor = System.Drawing.Color.White;
            this.lblAbout.Location = new System.Drawing.Point(744, 220);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(98, 49);
            this.lblAbout.TabIndex = 15;
            this.lblAbout.Text = "About";
            this.lblAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAbout
            // 
            this.panelAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(239)))));
            this.panelAbout.Controls.Add(this.linkOnline);
            this.panelAbout.Controls.Add(this.label4);
            this.panelAbout.Controls.Add(this.lblAboutOK);
            this.panelAbout.Controls.Add(this.linkCode);
            this.panelAbout.Controls.Add(this.label3);
            this.panelAbout.Controls.Add(this.linkGabriel);
            this.panelAbout.Controls.Add(this.label2);
            this.panelAbout.Location = new System.Drawing.Point(12, 9);
            this.panelAbout.Name = "panelAbout";
            this.panelAbout.Size = new System.Drawing.Size(831, 1);
            this.panelAbout.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(110)))), ((int)(((byte)(101)))));
            this.label2.Location = new System.Drawing.Point(21, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(555, 45);
            this.label2.TabIndex = 0;
            this.label2.Text = "The Original of 2048 game created by";
            // 
            // linkGabriel
            // 
            this.linkGabriel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(110)))), ((int)(((byte)(101)))));
            this.linkGabriel.AutoSize = true;
            this.linkGabriel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkGabriel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(110)))), ((int)(((byte)(101)))));
            this.linkGabriel.Location = new System.Drawing.Point(582, 48);
            this.linkGabriel.Name = "linkGabriel";
            this.linkGabriel.Size = new System.Drawing.Size(235, 45);
            this.linkGabriel.TabIndex = 1;
            this.linkGabriel.TabStop = true;
            this.linkGabriel.Text = "Gabriele Cirulli.";
            this.linkGabriel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(110)))), ((int)(((byte)(101)))));
            this.linkGabriel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGabriel_Clicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(110)))), ((int)(((byte)(101)))));
            this.label3.Location = new System.Drawing.Point(21, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(633, 45);
            this.label3.TabIndex = 2;
            this.label3.Text = "This is a clone version using C# to develop.";
            // 
            // linkCode
            // 
            this.linkCode.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(110)))), ((int)(((byte)(101)))));
            this.linkCode.AutoSize = true;
            this.linkCode.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkCode.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(110)))), ((int)(((byte)(101)))));
            this.linkCode.Location = new System.Drawing.Point(21, 274);
            this.linkCode.Name = "linkCode";
            this.linkCode.Size = new System.Drawing.Size(580, 45);
            this.linkCode.TabIndex = 3;
            this.linkCode.TabStop = true;
            this.linkCode.Text = "https://github.com/kdevzilla/Sharp2048";
            this.linkCode.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(110)))), ((int)(((byte)(101)))));
            this.linkCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCode_Clicked);
            // 
            // lblAboutOK
            // 
            this.lblAboutOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(122)))), ((int)(((byte)(102)))));
            this.lblAboutOK.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAboutOK.ForeColor = System.Drawing.Color.White;
            this.lblAboutOK.Location = new System.Drawing.Point(703, 391);
            this.lblAboutOK.Name = "lblAboutOK";
            this.lblAboutOK.Size = new System.Drawing.Size(98, 49);
            this.lblAboutOK.TabIndex = 16;
            this.lblAboutOK.Text = "OK";
            this.lblAboutOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(110)))), ((int)(((byte)(101)))));
            this.label4.Location = new System.Drawing.Point(21, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(394, 45);
            this.label4.TabIndex = 17;
            this.label4.Text = "You can play it online here";
            // 
            // linkOnline
            // 
            this.linkOnline.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(110)))), ((int)(((byte)(101)))));
            this.linkOnline.AutoSize = true;
            this.linkOnline.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkOnline.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(110)))), ((int)(((byte)(101)))));
            this.linkOnline.Location = new System.Drawing.Point(412, 117);
            this.linkOnline.Name = "linkOnline";
            this.linkOnline.Size = new System.Drawing.Size(291, 45);
            this.linkOnline.TabIndex = 18;
            this.linkOnline.TabStop = true;
            this.linkOnline.Text = "https://play2048.co";
            this.linkOnline.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(110)))), ((int)(((byte)(101)))));
            this.linkOnline.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOnline_Clicked);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(848, 585);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblScoreBestText);
            this.Controls.Add(this.lblScoreBest);
            this.Controls.Add(this.lblScoreBestBack);
            this.Controls.Add(this.lblScoreText);
            this.Controls.Add(this.lblNewGame);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblScoreBack);
            this.Controls.Add(this.panelAbout);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "2048";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelAbout.ResumeLayout(false);
            this.panelAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblScoreBack;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblNewGame;
        private System.Windows.Forms.Label lblScoreText;
        private System.Windows.Forms.Label lblScoreBestText;
        private System.Windows.Forms.Label lblScoreBest;
        private System.Windows.Forms.Label lblScoreBestBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Panel panelAbout;
        private System.Windows.Forms.LinkLabel linkGabriel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAboutOK;
        private System.Windows.Forms.LinkLabel linkOnline;
        private System.Windows.Forms.Label label4;
    }
}