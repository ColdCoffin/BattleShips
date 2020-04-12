namespace BattleShips
{
	partial class InGameOptionsMenu
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.timePlayed_label = new System.Windows.Forms.Label();
			this.ActionButton = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.back_button = new System.Windows.Forms.Button();
			this.restart_button = new System.Windows.Forms.Button();
			this.mainMenu_button = new System.Windows.Forms.Button();
			this.cheat_button = new System.Windows.Forms.Button();
			this.cheat_label = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(594, 200);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// timePlayed_label
			// 
			this.timePlayed_label.BackColor = System.Drawing.Color.Sienna;
			this.timePlayed_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.timePlayed_label.Location = new System.Drawing.Point(45, 297);
			this.timePlayed_label.Name = "timePlayed_label";
			this.timePlayed_label.Size = new System.Drawing.Size(133, 16);
			this.timePlayed_label.TabIndex = 5;
			this.timePlayed_label.Text = "Time played:";
			this.timePlayed_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ActionButton
			// 
			this.ActionButton.BackColor = System.Drawing.Color.Black;
			this.ActionButton.BackgroundImage = global::BattleShips.Properties.Resources.BigButtton_2;
			this.ActionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ActionButton.FlatAppearance.BorderSize = 0;
			this.ActionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ActionButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
			this.ActionButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ActionButton.Location = new System.Drawing.Point(439, 245);
			this.ActionButton.Margin = new System.Windows.Forms.Padding(0);
			this.ActionButton.Name = "ActionButton";
			this.ActionButton.Size = new System.Drawing.Size(100, 50);
			this.ActionButton.TabIndex = 1336;
			this.ActionButton.Text = "Exit";
			this.ActionButton.UseVisualStyleBackColor = true;
			this.ActionButton.Click += new System.EventHandler(this.ActionButton_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 35;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// back_button
			// 
			this.back_button.BackColor = System.Drawing.Color.Black;
			this.back_button.BackgroundImage = global::BattleShips.Properties.Resources.BigButtton_2;
			this.back_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.back_button.FlatAppearance.BorderSize = 0;
			this.back_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.back_button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
			this.back_button.ForeColor = System.Drawing.SystemColors.ControlText;
			this.back_button.Location = new System.Drawing.Point(439, 312);
			this.back_button.Margin = new System.Windows.Forms.Padding(0);
			this.back_button.Name = "back_button";
			this.back_button.Size = new System.Drawing.Size(100, 50);
			this.back_button.TabIndex = 1339;
			this.back_button.Text = "Back";
			this.back_button.UseVisualStyleBackColor = true;
			this.back_button.Click += new System.EventHandler(this.back_button_Click);
			// 
			// restart_button
			// 
			this.restart_button.BackgroundImage = global::BattleShips.Properties.Resources.smallButton;
			this.restart_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.restart_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.restart_button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
			this.restart_button.Location = new System.Drawing.Point(262, 245);
			this.restart_button.Name = "restart_button";
			this.restart_button.Size = new System.Drawing.Size(80, 25);
			this.restart_button.TabIndex = 1340;
			this.restart_button.Text = "Restart";
			this.restart_button.UseVisualStyleBackColor = true;
			this.restart_button.Click += new System.EventHandler(this.restart_button_Click);
			// 
			// mainMenu_button
			// 
			this.mainMenu_button.BackgroundImage = global::BattleShips.Properties.Resources.smallButton;
			this.mainMenu_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.mainMenu_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainMenu_button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
			this.mainMenu_button.Location = new System.Drawing.Point(262, 294);
			this.mainMenu_button.Name = "mainMenu_button";
			this.mainMenu_button.Size = new System.Drawing.Size(80, 25);
			this.mainMenu_button.TabIndex = 1341;
			this.mainMenu_button.Text = "Main Menu";
			this.mainMenu_button.UseVisualStyleBackColor = true;
			this.mainMenu_button.Click += new System.EventHandler(this.mainMenu_button_Click);
			// 
			// cheat_button
			// 
			this.cheat_button.BackgroundImage = global::BattleShips.Properties.Resources.smallButton;
			this.cheat_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.cheat_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cheat_button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
			this.cheat_button.Location = new System.Drawing.Point(262, 337);
			this.cheat_button.Name = "cheat_button";
			this.cheat_button.Size = new System.Drawing.Size(80, 25);
			this.cheat_button.TabIndex = 1342;
			this.cheat_button.Text = "Cheat";
			this.cheat_button.UseVisualStyleBackColor = true;
			this.cheat_button.Click += new System.EventHandler(this.cheat_button_Click);
			// 
			// cheat_label
			// 
			this.cheat_label.BackColor = System.Drawing.Color.Sienna;
			this.cheat_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cheat_label.Location = new System.Drawing.Point(235, 364);
			this.cheat_label.Name = "cheat_label";
			this.cheat_label.Size = new System.Drawing.Size(133, 16);
			this.cheat_label.TabIndex = 1343;
			this.cheat_label.Text = "Can\'t cheat in hard mode";
			this.cheat_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cheat_label.Visible = false;
			// 
			// InGameOptionsMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::BattleShips.Properties.Resources.EndGameMenu;
			this.Controls.Add(this.cheat_label);
			this.Controls.Add(this.cheat_button);
			this.Controls.Add(this.mainMenu_button);
			this.Controls.Add(this.restart_button);
			this.Controls.Add(this.back_button);
			this.Controls.Add(this.ActionButton);
			this.Controls.Add(this.timePlayed_label);
			this.Controls.Add(this.pictureBox1);
			this.Name = "InGameOptionsMenu";
			this.Size = new System.Drawing.Size(600, 400);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label timePlayed_label;
		private System.Windows.Forms.Button ActionButton;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button back_button;
		private System.Windows.Forms.Button restart_button;
		private System.Windows.Forms.Button mainMenu_button;
		private System.Windows.Forms.Button cheat_button;
		private System.Windows.Forms.Label cheat_label;
	}
}
