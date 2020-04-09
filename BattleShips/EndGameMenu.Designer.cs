namespace BattleShips
{
	partial class EndGameMenu
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.playerShipsDestroyed_label = new System.Windows.Forms.Label();
			this.enemyShipsDestroyed_label = new System.Windows.Forms.Label();
			this.playerShipHits_label = new System.Windows.Forms.Label();
			this.playerShipMisses_label = new System.Windows.Forms.Label();
			this.playerAccuracy_label = new System.Windows.Forms.Label();
			this.enemyAccuracy_label = new System.Windows.Forms.Label();
			this.enemyShipMisses_label = new System.Windows.Forms.Label();
			this.EnemyShipHits_label = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.ActionButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(594, 200);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// timer1
			// 
			this.timer1.Interval = 35;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.DarkGreen;
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(45, 232);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(133, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "YOU";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.DarkRed;
			this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Location = new System.Drawing.Point(233, 232);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(133, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "ENEMY";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// playerShipsDestroyed_label
			// 
			this.playerShipsDestroyed_label.BackColor = System.Drawing.Color.Sienna;
			this.playerShipsDestroyed_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.playerShipsDestroyed_label.Location = new System.Drawing.Point(45, 274);
			this.playerShipsDestroyed_label.Name = "playerShipsDestroyed_label";
			this.playerShipsDestroyed_label.Size = new System.Drawing.Size(133, 16);
			this.playerShipsDestroyed_label.TabIndex = 4;
			this.playerShipsDestroyed_label.Text = "Ships destroyed:";
			this.playerShipsDestroyed_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// enemyShipsDestroyed_label
			// 
			this.enemyShipsDestroyed_label.BackColor = System.Drawing.Color.Sienna;
			this.enemyShipsDestroyed_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.enemyShipsDestroyed_label.Location = new System.Drawing.Point(233, 274);
			this.enemyShipsDestroyed_label.Name = "enemyShipsDestroyed_label";
			this.enemyShipsDestroyed_label.Size = new System.Drawing.Size(133, 16);
			this.enemyShipsDestroyed_label.TabIndex = 5;
			this.enemyShipsDestroyed_label.Text = "Ships destroyed:";
			this.enemyShipsDestroyed_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// playerShipHits_label
			// 
			this.playerShipHits_label.BackColor = System.Drawing.Color.Sienna;
			this.playerShipHits_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.playerShipHits_label.Location = new System.Drawing.Point(45, 299);
			this.playerShipHits_label.Name = "playerShipHits_label";
			this.playerShipHits_label.Size = new System.Drawing.Size(133, 16);
			this.playerShipHits_label.TabIndex = 6;
			this.playerShipHits_label.Text = "Ship hits:";
			this.playerShipHits_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// playerShipMisses_label
			// 
			this.playerShipMisses_label.BackColor = System.Drawing.Color.Sienna;
			this.playerShipMisses_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.playerShipMisses_label.Location = new System.Drawing.Point(45, 324);
			this.playerShipMisses_label.Name = "playerShipMisses_label";
			this.playerShipMisses_label.Size = new System.Drawing.Size(133, 16);
			this.playerShipMisses_label.TabIndex = 7;
			this.playerShipMisses_label.Text = "Ship misses:";
			this.playerShipMisses_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// playerAccuracy_label
			// 
			this.playerAccuracy_label.BackColor = System.Drawing.Color.Sienna;
			this.playerAccuracy_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.playerAccuracy_label.Location = new System.Drawing.Point(45, 350);
			this.playerAccuracy_label.Name = "playerAccuracy_label";
			this.playerAccuracy_label.Size = new System.Drawing.Size(133, 16);
			this.playerAccuracy_label.TabIndex = 8;
			this.playerAccuracy_label.Text = "Accuracy:";
			this.playerAccuracy_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// enemyAccuracy_label
			// 
			this.enemyAccuracy_label.BackColor = System.Drawing.Color.Sienna;
			this.enemyAccuracy_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.enemyAccuracy_label.Location = new System.Drawing.Point(233, 350);
			this.enemyAccuracy_label.Name = "enemyAccuracy_label";
			this.enemyAccuracy_label.Size = new System.Drawing.Size(133, 16);
			this.enemyAccuracy_label.TabIndex = 11;
			this.enemyAccuracy_label.Text = "Accuracy:";
			this.enemyAccuracy_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// enemyShipMisses_label
			// 
			this.enemyShipMisses_label.BackColor = System.Drawing.Color.Sienna;
			this.enemyShipMisses_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.enemyShipMisses_label.Location = new System.Drawing.Point(233, 324);
			this.enemyShipMisses_label.Name = "enemyShipMisses_label";
			this.enemyShipMisses_label.Size = new System.Drawing.Size(133, 16);
			this.enemyShipMisses_label.TabIndex = 10;
			this.enemyShipMisses_label.Text = "Ship misses:";
			this.enemyShipMisses_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EnemyShipHits_label
			// 
			this.EnemyShipHits_label.BackColor = System.Drawing.Color.Sienna;
			this.EnemyShipHits_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.EnemyShipHits_label.Location = new System.Drawing.Point(233, 299);
			this.EnemyShipHits_label.Name = "EnemyShipHits_label";
			this.EnemyShipHits_label.Size = new System.Drawing.Size(133, 16);
			this.EnemyShipHits_label.TabIndex = 9;
			this.EnemyShipHits_label.Text = "Ship hits:";
			this.EnemyShipHits_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Transparent;
			this.button1.BackgroundImage = global::BattleShips.Properties.Resources.BigButtton_2;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
			this.button1.Location = new System.Drawing.Point(441, 308);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 50);
			this.button1.TabIndex = 55;
			this.button1.Text = "Exit";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ActionButton
			// 
			this.ActionButton.BackColor = System.Drawing.Color.Transparent;
			this.ActionButton.BackgroundImage = global::BattleShips.Properties.Resources.BigButtton_2;
			this.ActionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ActionButton.FlatAppearance.BorderSize = 0;
			this.ActionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ActionButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
			this.ActionButton.Location = new System.Drawing.Point(441, 253);
			this.ActionButton.Margin = new System.Windows.Forms.Padding(0);
			this.ActionButton.Name = "ActionButton";
			this.ActionButton.Size = new System.Drawing.Size(100, 50);
			this.ActionButton.TabIndex = 54;
			this.ActionButton.Text = "Main Menu";
			this.ActionButton.UseVisualStyleBackColor = false;
			this.ActionButton.Click += new System.EventHandler(this.ActionButton_Click);
			// 
			// EndGameMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::BattleShips.Properties.Resources.EndGameMenu1;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.ActionButton);
			this.Controls.Add(this.enemyAccuracy_label);
			this.Controls.Add(this.enemyShipMisses_label);
			this.Controls.Add(this.EnemyShipHits_label);
			this.Controls.Add(this.playerAccuracy_label);
			this.Controls.Add(this.playerShipMisses_label);
			this.Controls.Add(this.playerShipHits_label);
			this.Controls.Add(this.enemyShipsDestroyed_label);
			this.Controls.Add(this.playerShipsDestroyed_label);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "EndGameMenu";
			this.Size = new System.Drawing.Size(600, 400);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label playerShipsDestroyed_label;
		private System.Windows.Forms.Label enemyShipsDestroyed_label;
		private System.Windows.Forms.Label playerShipHits_label;
		private System.Windows.Forms.Label playerShipMisses_label;
		private System.Windows.Forms.Label playerAccuracy_label;
		private System.Windows.Forms.Label enemyAccuracy_label;
		private System.Windows.Forms.Label enemyShipMisses_label;
		private System.Windows.Forms.Label EnemyShipHits_label;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button ActionButton;
	}
}
