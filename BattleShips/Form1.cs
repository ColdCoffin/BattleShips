using System;
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

		FishingBoat playerFishingBoat;
		FishingBoat enemyFishingBoat;

		Sloop playerSloop;
		Sloop enemySloop;

		Galleon playerGalleon;
		Galleon enemyGalleon;

		Brigantine playerBrigantine;
		Brigantine enemyBrigantine;

		PiratesShip playerPiratesShip;
		PiratesShip enemyPiratesShip;

		public GameScreen()
		{
			InitializeComponent();

			playerField = new PlayingField();
			enemyField = new PlayingField();

			playerFishingBoat = new FishingBoat(FishingBoat_horizontal_player,
				FishingBoat_vertical_player);
			enemyFishingBoat = new FishingBoat(FishingBoat_horizontal_enemy,
				FishingBoat_vertical_enemy);

			playerSloop = new Sloop(Sloop_horizontal_player,
				Sloop_vertical_player);
			enemySloop = new Sloop(Sloop_horizontal_enemy,
				Sloop_vertical_enemy);

			playerGalleon = new Galleon(Galleon_horizontal_player,
				Galleon_vertical_player);
			enemyGalleon = new Galleon(Galleon_horizontal_enemy,
				Galleon_vertical_enemy);

			playerBrigantine = new Brigantine(Brigantine_horizontal_player,
				Brigantine_vertical_player);
			enemyBrigantine = new Brigantine(Brigantine_horizontal_enemy,
				Brigantine_vertical_enemy);

			playerPiratesShip = new PiratesShip(PiratesShip_horizontal_player,
				 PiratesShip_vertical_player);
			enemyPiratesShip = new PiratesShip(PiratesShip_horizontal_enemy,
				PiratesShip_vertical_enemy);

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

				PiratesShip_horizontal_enemy.Location = p;
				PiratesShip_horizontal_enemy.Visible = true;

			}
		}

		private void SetShipsButton_Click(object sender, EventArgs e)
		{

			
		}
	}
}
