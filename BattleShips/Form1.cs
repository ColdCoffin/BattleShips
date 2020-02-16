﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShips
{
	public partial class GameScreen : Form
	{
		PlayingField playerField;
		PlayingField enemyField;
		public GameScreen()
		{
			InitializeComponent();

			playerField = new PlayingField();
			enemyField = new PlayingField();
		}

		

		private String LoadFireCoordinates()
		{

			String letter = LetterboxText.Text;
			String number = NumberboxText.Text;
			String s = "EnemyField_" + letter + number;
			return s;
		}

		private void FireButton_Click(object sender, EventArgs e)
		{
			PictureBox pic = Controls.Find(LoadFireCoordinates(), true)
				.FirstOrDefault() as PictureBox;
			

			if (pic == null)
				ActionText.Text = "Bad coordinaates mate!";
			else
			{
				Point p = pic.Location;
				ActionText.Text = "Firing at " +
					pic.Name.Substring(pic.Name.IndexOf('_') + 1, 2);

				PiratesShip_horiznotal_enemy.Location = p;
				PiratesShip_horiznotal_enemy.Visible = true;

			}
		}

		private void SetShipsButton_Click(object sender, EventArgs e)
		{

			
		}
	}
}
