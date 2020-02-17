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




			FireButton.Enabled = false;
			LetterboxText.Enabled = false;
			NumberboxText.Enabled = false;

			PlayerShips = new List<Ship>
			{
				playerFishingBoat,
				playerGalleon,
				playerSloop,
				playerPiratesShip,
				playerBrigantine
			};


		}

		

		private void FireButton_Click(object sender, EventArgs e)
		{
			
		}

		

		private void SetShipsButton_Click(object sender, EventArgs e)
		{
			char hpos = SetHorizontalPosText.Text[0];
			SetHorizontalPosText.Text = string.Empty;

			if (hpos < 'A' || hpos > 'J')
			{
				ErrorDialogLabel.Text = "Bad coordinates";
				return;
			}

			int vpos = int.Parse(SetVerticalPosText.Text) - 1;
			SetVerticalPosText.Text = string.Empty;

			if (vpos < 0 || vpos > 9)
			{
				ErrorDialogLabel.Text = "Bad coordinates";
				return;
			}

			string sname = ShipName_texbox.Text;
			ShipName_texbox.Text = string.Empty;

			int index = ((hpos - 65) * 10) + vpos;

			string ship = ChooseShipComboBox.Text;
			string orientation;

			if (VerticalOption.Checked == true)
				orientation = "Vertical";
			else
				orientation = "Horizontal";

			switch (ship)
			{
				case "Fishing Boat":
					if (
					playerFishingBoat.SpawnShip(PlayerField.AllFields[index], orientation, sname) == false)
					{
						ErrorDialogLabel.Text = "Can't place your boat there";
						break;
					}
					FishingBoat_icon.Visible = true;
					FishingBoat_nameText.Text = playerFishingBoat.ShipName;
					FishingBoat_nameText.Visible = true;
					FishingBoat_progressBar.Visible = true;
					break;
				case "Brigantine":
					if (
					playerBrigantine.SpawnShip(PlayerField.AllFields[index], orientation, sname) == false)
					{
						ErrorDialogLabel.Text = "Can't place your boat there";
						break;
					}
					Brigantine_icon.Visible = true;
					Brigantine_nameText.Text = playerBrigantine.ShipName;
					Brigantine_nameText.Visible = true;
					Brigantine_progressBar.Visible = true;
					break;
				case "Sloop":
					if (
					playerSloop.SpawnShip(PlayerField.AllFields[index], orientation, sname) == false)
					{
						ErrorDialogLabel.Text = "Can't place your boat there";
						break;
					}
					Sloop_icon.Visible = true;
					Sloop_nameText.Text = playerSloop.ShipName;
					Sloop_nameText.Visible = true;
					Sloop_progressBar.Visible = true;
					break;
				case "Galleon":
					if (
					playerGalleon.SpawnShip(PlayerField.AllFields[index], orientation, sname) == false)
					{
						ErrorDialogLabel.Text = "Can't place your boat there";
						break;
					}
					Galleon_icon.Visible = true;
					Galleon_nameText.Text = playerGalleon.ShipName;
					Galleon_nameText.Visible = true;
					Galleon_progressBar.Visible = true;
					break;
				case "Pirate's ship":
					if (
					playerPiratesShip.SpawnShip(PlayerField.AllFields[index], orientation, sname) == false)
					{
						ErrorDialogLabel.Text = "Can't place your boat there";
						break;
					}
					PiratesShip_icon.Visible = true;
					PiratesShip_nameText.Text = playerPiratesShip.ShipName;
					PiratesShip_nameText.Visible = true;
					PiratesShip_progressBar.Visible = true;
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

		private void button1_Click(object sender, EventArgs e)
		{

			string ship = ChooseShipComboBox.Text;

			switch (ship)
			{
				case "Fishing Boat":
					playerFishingBoat.DespawnShip();
					FishingBoat_icon.Visible = false;
					FishingBoat_nameText.Visible = false;
					FishingBoat_progressBar.Visible = false;
					break;
				case "Brigantine":
					playerBrigantine.DespawnShip();
					Brigantine_icon.Visible = false;
					Brigantine_nameText.Visible = false;
					Brigantine_progressBar.Visible = false;
					break;
				case "Sloop":
					playerSloop.DespawnShip();
					Sloop_icon.Visible = false;
					Sloop_nameText.Visible = false;
					Sloop_progressBar.Visible = false;
					break;
				case "Galleon":
					playerGalleon.DespawnShip();
					Galleon_icon.Visible = false;
					Galleon_nameText.Visible = false;
					Galleon_progressBar.Visible = false;
					break;
				case "Pirate's ship":
					playerPiratesShip.DespawnShip();
					PiratesShip_icon.Visible = false;
					PiratesShip_nameText.Visible = false;
					PiratesShip_progressBar.Visible = false;
					break;

				default:
					ErrorDialogLabel.Text = "No such ship exists!";
					break;
			}

		}
	}
}
