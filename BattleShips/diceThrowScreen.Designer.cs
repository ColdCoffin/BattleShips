namespace BattleShips
{
	partial class diceThrowScreen
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
			this.timePlayed_label = new System.Windows.Forms.Label();
			this.confirm_button = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.rock = new System.Windows.Forms.PictureBox();
			this.paper = new System.Windows.Forms.PictureBox();
			this.scissors = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.PlayerFinalSign_pictureBox = new System.Windows.Forms.PictureBox();
			this.enemyFinalSign_pictureBox = new System.Windows.Forms.PictureBox();
			this.won_label = new System.Windows.Forms.Label();
			this.lost_label = new System.Windows.Forms.Label();
			this.tryAgain_label = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rock)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paper)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.scissors)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PlayerFinalSign_pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.enemyFinalSign_pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// timePlayed_label
			// 
			this.timePlayed_label.BackColor = System.Drawing.Color.Sienna;
			this.timePlayed_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timePlayed_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.timePlayed_label.Location = new System.Drawing.Point(219, 17);
			this.timePlayed_label.Name = "timePlayed_label";
			this.timePlayed_label.Size = new System.Drawing.Size(133, 30);
			this.timePlayed_label.TabIndex = 1346;
			this.timePlayed_label.Text = "Chose a sign";
			this.timePlayed_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// confirm_button
			// 
			this.confirm_button.BackgroundImage = global::BattleShips.Properties.Resources.smallButton;
			this.confirm_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.confirm_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.confirm_button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.5F);
			this.confirm_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.confirm_button.Location = new System.Drawing.Point(416, 105);
			this.confirm_button.Name = "confirm_button";
			this.confirm_button.Size = new System.Drawing.Size(80, 25);
			this.confirm_button.TabIndex = 1345;
			this.confirm_button.Text = "Confirm";
			this.confirm_button.UseVisualStyleBackColor = true;
			this.confirm_button.Click += new System.EventHandler(this.confirm_button_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::BattleShips.Properties.Resources.diceThrowScreen;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(550, 170);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// rock
			// 
			this.rock.BackgroundImage = global::BattleShips.Properties.Resources.Hand_stone;
			this.rock.Location = new System.Drawing.Point(400, 43);
			this.rock.Name = "rock";
			this.rock.Size = new System.Drawing.Size(25, 25);
			this.rock.TabIndex = 1347;
			this.rock.TabStop = false;
			this.rock.Click += new System.EventHandler(this.rock_Click);
			// 
			// paper
			// 
			this.paper.BackgroundImage = global::BattleShips.Properties.Resources.Hand_paper;
			this.paper.Location = new System.Drawing.Point(444, 43);
			this.paper.Name = "paper";
			this.paper.Size = new System.Drawing.Size(25, 25);
			this.paper.TabIndex = 1348;
			this.paper.TabStop = false;
			this.paper.Click += new System.EventHandler(this.paper_Click);
			// 
			// scissors
			// 
			this.scissors.BackgroundImage = global::BattleShips.Properties.Resources.Hand_scissors;
			this.scissors.Location = new System.Drawing.Point(488, 43);
			this.scissors.Name = "scissors";
			this.scissors.Size = new System.Drawing.Size(25, 25);
			this.scissors.TabIndex = 1349;
			this.scissors.TabStop = false;
			this.scissors.Click += new System.EventHandler(this.scissors_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Sienna;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(394, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 1350;
			this.label1.Text = "Rock";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Sienna;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Location = new System.Drawing.Point(438, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 1351;
			this.label2.Text = "Paper";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Sienna;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Location = new System.Drawing.Point(480, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 1352;
			this.label3.Text = "Scissors";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PlayerFinalSign_pictureBox
			// 
			this.PlayerFinalSign_pictureBox.Location = new System.Drawing.Point(300, 73);
			this.PlayerFinalSign_pictureBox.Name = "PlayerFinalSign_pictureBox";
			this.PlayerFinalSign_pictureBox.Size = new System.Drawing.Size(25, 25);
			this.PlayerFinalSign_pictureBox.TabIndex = 1353;
			this.PlayerFinalSign_pictureBox.TabStop = false;
			this.PlayerFinalSign_pictureBox.Visible = false;
			// 
			// enemyFinalSign_pictureBox
			// 
			this.enemyFinalSign_pictureBox.Location = new System.Drawing.Point(234, 73);
			this.enemyFinalSign_pictureBox.Name = "enemyFinalSign_pictureBox";
			this.enemyFinalSign_pictureBox.Size = new System.Drawing.Size(25, 25);
			this.enemyFinalSign_pictureBox.TabIndex = 1354;
			this.enemyFinalSign_pictureBox.TabStop = false;
			this.enemyFinalSign_pictureBox.Visible = false;
			// 
			// won_label
			// 
			this.won_label.BackColor = System.Drawing.Color.Green;
			this.won_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.won_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.won_label.Location = new System.Drawing.Point(219, 122);
			this.won_label.Name = "won_label";
			this.won_label.Size = new System.Drawing.Size(133, 30);
			this.won_label.TabIndex = 1355;
			this.won_label.Text = "YOU WON!";
			this.won_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.won_label.Visible = false;
			// 
			// lost_label
			// 
			this.lost_label.BackColor = System.Drawing.Color.Red;
			this.lost_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lost_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lost_label.Location = new System.Drawing.Point(219, 122);
			this.lost_label.Name = "lost_label";
			this.lost_label.Size = new System.Drawing.Size(133, 30);
			this.lost_label.TabIndex = 1356;
			this.lost_label.Text = "YOU LOST!";
			this.lost_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lost_label.Visible = false;
			// 
			// tryAgain_label
			// 
			this.tryAgain_label.BackColor = System.Drawing.Color.Yellow;
			this.tryAgain_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tryAgain_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tryAgain_label.Location = new System.Drawing.Point(219, 122);
			this.tryAgain_label.Name = "tryAgain_label";
			this.tryAgain_label.Size = new System.Drawing.Size(133, 30);
			this.tryAgain_label.TabIndex = 1357;
			this.tryAgain_label.Text = "TRY AGAIN!";
			this.tryAgain_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.tryAgain_label.Visible = false;
			// 
			// timer1
			// 
			this.timer1.Interval = 3000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// diceThrowScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tryAgain_label);
			this.Controls.Add(this.lost_label);
			this.Controls.Add(this.won_label);
			this.Controls.Add(this.enemyFinalSign_pictureBox);
			this.Controls.Add(this.PlayerFinalSign_pictureBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.scissors);
			this.Controls.Add(this.paper);
			this.Controls.Add(this.rock);
			this.Controls.Add(this.timePlayed_label);
			this.Controls.Add(this.confirm_button);
			this.Controls.Add(this.pictureBox1);
			this.Name = "diceThrowScreen";
			this.Size = new System.Drawing.Size(550, 170);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rock)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paper)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.scissors)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PlayerFinalSign_pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.enemyFinalSign_pictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button confirm_button;
		private System.Windows.Forms.Label timePlayed_label;
		private System.Windows.Forms.PictureBox rock;
		private System.Windows.Forms.PictureBox paper;
		private System.Windows.Forms.PictureBox scissors;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox PlayerFinalSign_pictureBox;
		private System.Windows.Forms.PictureBox enemyFinalSign_pictureBox;
		private System.Windows.Forms.Label won_label;
		private System.Windows.Forms.Label lost_label;
		private System.Windows.Forms.Label tryAgain_label;
		private System.Windows.Forms.Timer timer1;
	}
}
