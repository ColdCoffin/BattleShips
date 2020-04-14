namespace BattleShips
{
	partial class MenuScreen
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
			this.components = new System.ComponentModel.Container();
			this.startGame_button = new System.Windows.Forms.Button();
			this.multiplayerGame_button = new System.Windows.Forms.Button();
			this.options_button = new System.Windows.Forms.Button();
			this.exit_button = new System.Windows.Forms.Button();
			this.backroundUpdate = new System.Windows.Forms.Timer(this.components);
			this.easyOption_button = new System.Windows.Forms.Button();
			this.hardOption_button = new System.Windows.Forms.Button();
			this.back_button = new System.Windows.Forms.Button();
			this.startStopAnimation_button = new System.Windows.Forms.Button();
			this.backroundLoad_progressbar = new System.Windows.Forms.ProgressBar();
			this.backround_box = new System.Windows.Forms.PictureBox();
			this.soundOn_button = new System.Windows.Forms.Button();
			this.soundOff_button = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.backround_box)).BeginInit();
			this.SuspendLayout();
			// 
			// startGame_button
			// 
			this.startGame_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.startGame_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startGame_button.Location = new System.Drawing.Point(490, 70);
			this.startGame_button.Name = "startGame_button";
			this.startGame_button.Size = new System.Drawing.Size(300, 70);
			this.startGame_button.TabIndex = 0;
			this.startGame_button.Text = "Solo Game";
			this.startGame_button.UseVisualStyleBackColor = true;
			this.startGame_button.Click += new System.EventHandler(this.startGame_button_Click);
			// 
			// multiplayerGame_button
			// 
			this.multiplayerGame_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.multiplayerGame_button.Location = new System.Drawing.Point(490, 223);
			this.multiplayerGame_button.Name = "multiplayerGame_button";
			this.multiplayerGame_button.Size = new System.Drawing.Size(300, 70);
			this.multiplayerGame_button.TabIndex = 1;
			this.multiplayerGame_button.Text = "Multiplayer Game";
			this.multiplayerGame_button.UseVisualStyleBackColor = true;
			// 
			// options_button
			// 
			this.options_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.options_button.Location = new System.Drawing.Point(490, 375);
			this.options_button.Name = "options_button";
			this.options_button.Size = new System.Drawing.Size(300, 70);
			this.options_button.TabIndex = 2;
			this.options_button.Text = "Options";
			this.options_button.UseVisualStyleBackColor = true;
			this.options_button.Click += new System.EventHandler(this.options_button_Click);
			// 
			// exit_button
			// 
			this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.exit_button.Location = new System.Drawing.Point(490, 541);
			this.exit_button.Name = "exit_button";
			this.exit_button.Size = new System.Drawing.Size(300, 70);
			this.exit_button.TabIndex = 3;
			this.exit_button.Text = "Exit Game";
			this.exit_button.UseVisualStyleBackColor = true;
			this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
			// 
			// backroundUpdate
			// 
			this.backroundUpdate.Interval = 35;
			this.backroundUpdate.Tick += new System.EventHandler(this.backroundUpdate_Tick);
			// 
			// easyOption_button
			// 
			this.easyOption_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.easyOption_button.Location = new System.Drawing.Point(193, 299);
			this.easyOption_button.Name = "easyOption_button";
			this.easyOption_button.Size = new System.Drawing.Size(300, 70);
			this.easyOption_button.TabIndex = 5;
			this.easyOption_button.Text = "Easy";
			this.easyOption_button.UseVisualStyleBackColor = true;
			this.easyOption_button.Visible = false;
			this.easyOption_button.Click += new System.EventHandler(this.easyOption_button_Click);
			// 
			// hardOption_button
			// 
			this.hardOption_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hardOption_button.Location = new System.Drawing.Point(790, 299);
			this.hardOption_button.Name = "hardOption_button";
			this.hardOption_button.Size = new System.Drawing.Size(300, 70);
			this.hardOption_button.TabIndex = 6;
			this.hardOption_button.Text = "Hard";
			this.hardOption_button.UseVisualStyleBackColor = true;
			this.hardOption_button.Visible = false;
			this.hardOption_button.Click += new System.EventHandler(this.hardOption_button_Click);
			// 
			// back_button
			// 
			this.back_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.back_button.Location = new System.Drawing.Point(490, 457);
			this.back_button.Name = "back_button";
			this.back_button.Size = new System.Drawing.Size(300, 70);
			this.back_button.TabIndex = 7;
			this.back_button.Text = "Back";
			this.back_button.UseVisualStyleBackColor = true;
			this.back_button.Visible = false;
			this.back_button.Click += new System.EventHandler(this.back_button_Click);
			// 
			// startStopAnimation_button
			// 
			this.startStopAnimation_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startStopAnimation_button.Location = new System.Drawing.Point(1177, 684);
			this.startStopAnimation_button.Name = "startStopAnimation_button";
			this.startStopAnimation_button.Size = new System.Drawing.Size(91, 24);
			this.startStopAnimation_button.TabIndex = 8;
			this.startStopAnimation_button.Text = "Start Animation";
			this.startStopAnimation_button.UseVisualStyleBackColor = true;
			this.startStopAnimation_button.Click += new System.EventHandler(this.startStopAnimation_button_Click);
			// 
			// backroundLoad_progressbar
			// 
			this.backroundLoad_progressbar.Location = new System.Drawing.Point(1177, 667);
			this.backroundLoad_progressbar.Maximum = 163;
			this.backroundLoad_progressbar.Name = "backroundLoad_progressbar";
			this.backroundLoad_progressbar.Size = new System.Drawing.Size(91, 11);
			this.backroundLoad_progressbar.Step = 1;
			this.backroundLoad_progressbar.TabIndex = 9;
			this.backroundLoad_progressbar.Visible = false;
			// 
			// backround_box
			// 
			this.backround_box.BackgroundImage = global::BattleShips.Properties.Resources.Backround359;
			this.backround_box.Location = new System.Drawing.Point(0, 0);
			this.backround_box.Name = "backround_box";
			this.backround_box.Size = new System.Drawing.Size(1280, 720);
			this.backround_box.TabIndex = 4;
			this.backround_box.TabStop = false;
			// 
			// soundOn_button
			// 
			this.soundOn_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.soundOn_button.Location = new System.Drawing.Point(193, 299);
			this.soundOn_button.Name = "soundOn_button";
			this.soundOn_button.Size = new System.Drawing.Size(300, 70);
			this.soundOn_button.TabIndex = 10;
			this.soundOn_button.Text = "Sound On";
			this.soundOn_button.UseVisualStyleBackColor = true;
			this.soundOn_button.Visible = false;
			this.soundOn_button.Click += new System.EventHandler(this.soundOn_button_Click);
			// 
			// soundOff_button
			// 
			this.soundOff_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.soundOff_button.Location = new System.Drawing.Point(790, 299);
			this.soundOff_button.Name = "soundOff_button";
			this.soundOff_button.Size = new System.Drawing.Size(300, 70);
			this.soundOff_button.TabIndex = 11;
			this.soundOff_button.Text = "Sound Off";
			this.soundOff_button.UseVisualStyleBackColor = true;
			this.soundOff_button.Visible = false;
			this.soundOff_button.Click += new System.EventHandler(this.soundOff_button_Click);
			// 
			// MenuScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1280, 720);
			this.Controls.Add(this.soundOff_button);
			this.Controls.Add(this.soundOn_button);
			this.Controls.Add(this.backroundLoad_progressbar);
			this.Controls.Add(this.startStopAnimation_button);
			this.Controls.Add(this.back_button);
			this.Controls.Add(this.hardOption_button);
			this.Controls.Add(this.easyOption_button);
			this.Controls.Add(this.exit_button);
			this.Controls.Add(this.options_button);
			this.Controls.Add(this.multiplayerGame_button);
			this.Controls.Add(this.startGame_button);
			this.Controls.Add(this.backround_box);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(1280, 720);
			this.Name = "MenuScreen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MenuScreen";
			((System.ComponentModel.ISupportInitialize)(this.backround_box)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button startGame_button;
		private System.Windows.Forms.Button multiplayerGame_button;
		private System.Windows.Forms.Button options_button;
		private System.Windows.Forms.Button exit_button;
		private System.Windows.Forms.PictureBox backround_box;
		private System.Windows.Forms.Timer backroundUpdate;
		private System.Windows.Forms.Button easyOption_button;
		private System.Windows.Forms.Button hardOption_button;
		private System.Windows.Forms.Button back_button;
		private System.Windows.Forms.Button startStopAnimation_button;
		private System.Windows.Forms.ProgressBar backroundLoad_progressbar;
		private System.Windows.Forms.Button soundOn_button;
		private System.Windows.Forms.Button soundOff_button;
	}
}