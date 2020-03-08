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
			this.startGame_button = new System.Windows.Forms.Button();
			this.multiplayerGame_button = new System.Windows.Forms.Button();
			this.options_button = new System.Windows.Forms.Button();
			this.exit_button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// startGame_button
			// 
			this.startGame_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startGame_button.Location = new System.Drawing.Point(522, 71);
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
			this.multiplayerGame_button.Location = new System.Drawing.Point(522, 199);
			this.multiplayerGame_button.Name = "multiplayerGame_button";
			this.multiplayerGame_button.Size = new System.Drawing.Size(300, 70);
			this.multiplayerGame_button.TabIndex = 1;
			this.multiplayerGame_button.Text = "Multiplayer Game";
			this.multiplayerGame_button.UseVisualStyleBackColor = true;
			// 
			// options_button
			// 
			this.options_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.options_button.Location = new System.Drawing.Point(522, 314);
			this.options_button.Name = "options_button";
			this.options_button.Size = new System.Drawing.Size(300, 70);
			this.options_button.TabIndex = 2;
			this.options_button.Text = "Options";
			this.options_button.UseVisualStyleBackColor = true;
			// 
			// exit_button
			// 
			this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.exit_button.Location = new System.Drawing.Point(522, 448);
			this.exit_button.Name = "exit_button";
			this.exit_button.Size = new System.Drawing.Size(300, 70);
			this.exit_button.TabIndex = 3;
			this.exit_button.Text = "Exit Game";
			this.exit_button.UseVisualStyleBackColor = true;
			this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
			// 
			// MenuScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 681);
			this.Controls.Add(this.exit_button);
			this.Controls.Add(this.options_button);
			this.Controls.Add(this.multiplayerGame_button);
			this.Controls.Add(this.startGame_button);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximumSize = new System.Drawing.Size(1280, 720);
			this.Name = "MenuScreen";
			this.Text = "MenuScreen";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button startGame_button;
		private System.Windows.Forms.Button multiplayerGame_button;
		private System.Windows.Forms.Button options_button;
		private System.Windows.Forms.Button exit_button;
	}
}