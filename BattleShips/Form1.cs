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

		List<Ship> PlayerShips;

		public GameScreen()
		{
			InitializeComponent();

			PlayerField.LoadFields();
			EnemyField.LoadFields();

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

			PlayerShips = new List<Ship>(5)
			{
				playerFishingBoat,
				playerSloop,
				playerGalleon,
				playerBrigantine,
				playerPiratesShip
			};


			FireButton.Enabled = false;
			LetterboxText.Enabled = false;
			NumberboxText.Enabled = false;


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
			char hpos = SetHorizontalPosText.Text[0];
			string vpos = SetVerticalPosText.Text;
			string sname = ShipName_texbox.Text;

			int index = ((hpos - 35) / 30) + ((int.Parse(vpos) / 30) * 10);

			string ship = ChooseShipComboBox.Text;
			string orientation;

			if (VerticalOption.Enabled == true)
				orientation = "Vertical";
			else
				orientation = "Horizontal";

			switch (ship)
			{
				case "Fishing Boat":
					playerFishingBoat.SpawnShip(ref PlayerField.AllFields[index], orientation, sname);
					break;
				case "Brigantine":
					playerBrigantine.SpawnShip(ref PlayerField.AllFields[index], orientation, sname);
					break;
				case "Sloop":
					playerSloop.SpawnShip(ref PlayerField.AllFields[index], orientation, sname);
					break;
				case "Galleon":
					playerGalleon.SpawnShip(ref PlayerField.AllFields[index], orientation, sname);
					break;
				case "Pirate's ship":
					playerPiratesShip.SpawnShip(ref PlayerField.AllFields[index], orientation, sname);
					break;

				default:
					ErrorDialogLabel.Text = "No such ship exists!";
					break;
			}


		}

		private void ActionButton_Click(object sender, EventArgs e)
		{
			foreach (Ship s in PlayerShips)
			{
				if (s.isSpawned == false)
					ErrorDialogLabel.Text = "Please spawn all the ships!";
			}
		}

		private void SetHorizontalPosText_TextChanged(object sender, EventArgs e)
		{
			ErrorDialogLabel.Text = string.Empty;
		}
	}
}
